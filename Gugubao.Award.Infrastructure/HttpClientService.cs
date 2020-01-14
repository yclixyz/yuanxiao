using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text.Json;

namespace Gugubao.Award.Infrastructure
{
    public class HttpClientService
    {
        private IMemoryCache _cache;

        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <remarks>
        /// 1、获取本地数据库数据
        /// 2、获取远程数据的总客户量，如果和本地的数据一致，则采用本地数据
        /// 3、如果不一样，则获取用户的增量，根据创建时间和雪花Id
        /// 4、如果当前用户的数据为0，则从远程获取所有用户
        /// </remarks>
        /// <param name="cache">将当前的头像存入内存流</param>
        /// <param name="httpClient">httpClient对象</param>
        public void LoadAccount(IMemoryCache cache, HttpClient httpClient, SerilogLogger _logger)
        {
            using AwardDbConetxt dbConetxt = new AwardDbConetxt();

            var localAccounts = dbConetxt.Account.ToList();

            _cache = cache;

            var builder = new ConfigurationBuilder().AddJsonFile("appsettings.json");

            var configuration = builder.Build();

            var url = configuration.GetValue<string>("AccountApiUrl");

            var getCountUrl = configuration.GetValue<string>("AccountCountApiUrl");

            GetAccounts(url, getCountUrl, localAccounts, httpClient,_logger);

            var lastAccounts = dbConetxt.Account.ToList();

            // 如果没有微信图片，默认一个图片
            var defaultHeadUrl = Path.Combine("images", $"ggb.png");

            _cache.Set("ggb", new Bitmap(defaultHeadUrl));

            lastAccounts.ForEach(c =>
            {
                byte[] bytes = null;

                var imagePath = Path.Combine("images", $"{c.Id}.png");

                if (File.Exists(imagePath))
                {
                    _cache.Set(c.Id, new Bitmap(imagePath));
                }
                else
                {
                    try
                    {
                        bytes = httpClient.GetByteArrayAsync(c.HeadImageUrl).Result;

                        using FileStream fs = new FileStream(imagePath, FileMode.Create, FileAccess.Write);

                        fs.Write(bytes, 0, bytes.Length);
                        fs.Flush();
                        fs.Close();

                        c.HeadImageLocalUrl = imagePath;

                        dbConetxt.Update(c);

                        dbConetxt.SaveChanges();

                        _cache.Set(c.Id, new Bitmap(imagePath));
                    }
                    catch (Exception ex)
                    {
                        _logger.Error(ex, "下载微信头像异常");
                    }
                }
            });
        }

        private void GetAccounts(string url, string getCountUrl, List<Account> localAccounts, HttpClient httpClient, SerilogLogger _logger)
        {
            try
            {
                httpClient.DefaultRequestHeaders.Add("Accept", "application/json");

                httpClient.DefaultRequestHeaders.Add("User-Agent", "gugubao");

                var response = httpClient.GetAsync(getCountUrl).Result;

                if (response.IsSuccessStatusCode)
                {
                    if (int.Parse(response.Content.ReadAsStringAsync().Result) != localAccounts.Count)
                    {
                        var lastId = localAccounts.Count == 0 ? 0 : localAccounts.Max(c => c.Id);

                        var query = string.Concat(url, $"?id={lastId}");

                        var responseMessage = httpClient.GetAsync(query).Result;

                        if (responseMessage.IsSuccessStatusCode)
                        {
                            var result = responseMessage.Content.ReadAsStringAsync().Result;

                            var accounts = JsonSerializer.Deserialize<List<Account>>(result);

                            using AwardDbConetxt context = new AwardDbConetxt();

                            var dbAccounts = context.Account.ToList();

                            var groupId = context.Group.FirstOrDefault(c => c.Name == "External").Id;

                            accounts.ForEach(c =>
                            {
                                if (dbAccounts.FirstOrDefault(d => d.Id == c.Id) == null)
                                {
                                    c.GroupId = groupId;
                                    context.Account.Add(c);
                                }
                            });

                            context.SaveChanges();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "获取用户接口异常");
            }
        }
    }
}