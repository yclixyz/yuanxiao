using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gugubao.Award.Infrastructure
{
    public class DataSeed
    {
        /// <summary>
        /// 初始组信息，和奖品等级信息
        /// </summary>
        public void InitData()
        {
            using AwardDbConetxt dbConetxt = new AwardDbConetxt();

            if (dbConetxt.Group.Count() > 0)
            {
                return;
            }

            dbConetxt.Group.AddRange(new List<Group>
            {
                 new Group { Id = SnowflakeId.Default().NextId(), Name = "Internal" },
                 new Group { Id = SnowflakeId.Default().NextId(), Name = "External" }
            });

            //var levels = new List<AwardLevel>
            //{
            //    new AwardLevel { Name = "特等奖", Id = SnowflakeId.Default().NextId() },
            //    new AwardLevel { Name = "一等奖", Id = SnowflakeId.Default().NextId() },
            //    new AwardLevel { Name = "二等奖", Id = SnowflakeId.Default().NextId() },
            //    new AwardLevel { Name = "三等奖", Id = SnowflakeId.Default().NextId() },
            //    new AwardLevel { Name = "四等奖", Id = SnowflakeId.Default().NextId() },
            //    new AwardLevel { Name = "五等奖", Id = SnowflakeId.Default().NextId() },
            //};

            //dbConetxt.AwardLevel.AddRange(levels);

            //var awardItems = new List<AwardItem>
            //{
            //    new AwardItem { Name = "5000元", Id = SnowflakeId.Default().NextId(),LevelId=levels[0].Id ,ImageUrl="Images/award.png"},
            //    new AwardItem { Name = "2000元", Id = SnowflakeId.Default().NextId(),LevelId=levels[1].Id ,ImageUrl="Images/award2.png"},
            //    new AwardItem { Name = "1000元", Id = SnowflakeId.Default().NextId(),LevelId=levels[2].Id ,ImageUrl="Images/award.png"},
            //    new AwardItem { Name = "500元", Id = SnowflakeId.Default().NextId(),LevelId=levels[3].Id ,ImageUrl="Images/award2.png"},
            //    new AwardItem { Name = "200元", Id = SnowflakeId.Default().NextId(),LevelId=levels[4].Id ,ImageUrl="Images/award.png"},
            //    new AwardItem { Name = "100元", Id = SnowflakeId.Default().NextId(),LevelId=levels[5].Id ,ImageUrl="Images/award2.png"},
            //};

            //dbConetxt.AwardItem.AddRange(awardItems);

            dbConetxt.SaveChanges();
        }
    }
}
