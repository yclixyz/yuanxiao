using Gugubao.Award.Infrastructure;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace Gugubao.Award.Main
{
    static class Program
    {
        private const string NAMEMUTEX = "E3E074B59ABB45009A55FB3097D4B5B3";
        private const int ERROR_ALREADY_EXISTS = 183;
        private const int SW_RESTORE = 9;
        private static IServiceProvider serviceProvider;

        /// <summary>
        /// 应用程序的主入口点
        /// </summary>
        [STAThread]
        static void Main()
        {
            ServiceCollection service = new ServiceCollection();
            service.AddSingleton<FrmMain>();
            service.AddSingleton<FrmSet>();
            service.AddSingleton<AwardLevelEvent>();
            service.AddSingleton<SerilogLogger>();
            service.AddHttpClient();
            service.AddMemoryCache();

            serviceProvider = service.BuildServiceProvider();

            if (!Directory.Exists("images"))
            {
                Directory.CreateDirectory("images");
            }

            int pMutex = NativeMethods.CreateMutex(0, false, NAMEMUTEX);

            if (NativeMethods.GetLastError() == ERROR_ALREADY_EXISTS)
            {
                // 只打开一个有效窗口，并置前
                Process currentProcess = Process.GetCurrentProcess();
                Process[] processes = Process.GetProcessesByName(currentProcess.ProcessName);
                foreach (Process p in processes)
                {
                    if (p.Id != currentProcess.Id)
                    {
                        NativeMethods.SetForegroundWindow(p.MainWindowHandle);
                        NativeMethods.ShowWindowAsync(p.MainWindowHandle, SW_RESTORE);
                        NativeMethods.SwitchToThisWindow(p.MainWindowHandle, true);
                        break;
                    }
                }
            }
            else
            {
                // 初始化数据
                new DataSeed().InitData();

                Application.ThreadException += new ThreadExceptionEventHandler(Application_ThreadException);
                AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);

                Application.SetHighDpiMode(HighDpiMode.SystemAware);
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                var frmSet = serviceProvider.GetRequiredService<FrmSet>();

                Application.Run(frmSet);

                //Application.Run(new FrmLevel());
            }

            NativeMethods.ReleaseMutex(pMutex);
            NativeMethods.CloseHandle(pMutex);
        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            if (e.ExceptionObject is Exception)
            {
                HandleException((Exception)e.ExceptionObject);
            }
        }

        private static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            HandleException(e.Exception);
        }

        public static void HandleException(Exception e)
        {
            var serilogger = serviceProvider.GetRequiredService<SerilogLogger>();

            serilogger.Error(e, "系统异常");

            //强制退出，并强制结束消息循环
            Application.Exit();

            Environment.Exit(Environment.ExitCode);
        }
    }
}
