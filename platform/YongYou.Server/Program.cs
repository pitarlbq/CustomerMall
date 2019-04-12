using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace YongYou.Server
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            #region 判断进程重复
            bool blnCreateNew = false;
            Process CurrentProcess = Process.GetCurrentProcess();

            string MutexName = ConfigurationManager.AppSettings["Mutex"];
            if (string.IsNullOrEmpty(MutexName))
            {
                MutexName = CurrentProcess.ProcessName;
            }

            int count = 0;
            do
            {
                count++;
                System.Threading.Mutex mutex = new Mutex(false, MutexName, out blnCreateNew);

                if (!blnCreateNew)
                {
                    if (count < 3)
                    {
                        Thread.Sleep(1000);
                    }
                    else
                    {
                        if (MessageBox.Show("该程序已经运行，不能同时运行两个这样的实例！是否需要关闭另外一个实例？", "错误", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            Process[] process = Process.GetProcessesByName(CurrentProcess.ProcessName);
                            string PrgPath = Application.ExecutablePath;

                            if (process.Length > 0)
                            {
                                for (int Index = 0; Index < process.Length; Index++)
                                {
                                    if (process[Index].Id != CurrentProcess.Id)
                                        process[Index].Kill();
                                }
                            }
                            Application.Run(new MainForm());
                            return;
                        }
                        else
                        {
                            return;
                        }
                    }
                }
                else
                {
                    Application.Run(new MainForm());
                    return;
                }
            } while (true);
            #endregion
        }
    }
}
