using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Utility;

namespace YongYou.Server
{
    public partial class MainForm : Form
    {
        private Thread mAllBackgroundTask = null;
        private DateTime NextBackUpTime = DateTime.Now;
        private DateTime ShrinkLogTime = DateTime.Now;
        private DateTime NextDeleteLogTime = DateTime.Now;
        private List<Utility.ServerCompanyModel> urllist = new List<Utility.ServerCompanyModel>();
        private int TimmerSecond = 0;
        private int AllTaskWorkStartHour = 0;
        private int AllTaskWorkEndHour = 0;
        private int DBBackupHour = 0;
        private int DBShrinkHour = 0;
        private int DBRemoveLogHour = 0;
        private bool OnlySelf = false;
        public MainForm()
        {
            InitializeComponent();
            this.Load += Form1_Load;
            this.FormClosing += Form1_FormClosing;
        }
        void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("确认退出？", this.Text, MessageBoxButtons.YesNo) != System.Windows.Forms.DialogResult.Yes)
            {
                e.Cancel = true;
            }
        }
        void Form1_Load(object sender, EventArgs e)
        {
            int.TryParse(ConfigurationManager.AppSettings["TimmerSecond"], out TimmerSecond);
            TimmerSecond = TimmerSecond <= 0 ? 300 : TimmerSecond;

            int.TryParse(ConfigurationManager.AppSettings["AllTaskWorkStartHour"], out AllTaskWorkStartHour);
            AllTaskWorkStartHour = AllTaskWorkStartHour > 0 ? AllTaskWorkStartHour : 7;

            int.TryParse(ConfigurationManager.AppSettings["AllTaskWorkEndHour"], out AllTaskWorkEndHour);
            AllTaskWorkEndHour = AllTaskWorkEndHour > 0 ? AllTaskWorkEndHour : 20;

            int.TryParse(ConfigurationManager.AppSettings["DBShrinkHour"], out DBShrinkHour);
            DBShrinkHour = DBShrinkHour > 0 ? DBShrinkHour : 2;

            int.TryParse(ConfigurationManager.AppSettings["DBRemoveLogHour"], out DBRemoveLogHour);
            DBRemoveLogHour = DBRemoveLogHour > 0 ? DBRemoveLogHour : 3;

            int.TryParse(ConfigurationManager.AppSettings["DBBackupHour"], out DBBackupHour);
            DBBackupHour = DBBackupHour > 0 ? DBBackupHour : 1;

            bool.TryParse(ConfigurationManager.AppSettings["OnlySelf"], out OnlySelf);

            LogHelper.Log += LogHelper_Log;
            urllist = ApiHelper.GetAllAPIUrl();
            LogHelper.WriteInfo("AllAPIUrl:\r\n", string.Join("\r\n", urllist.Select(p => p.ApiURL).ToArray()));
            if (urllist.Count > 0)
            {
                #region 任务
                this.mAllBackgroundTask = new Thread(new ThreadStart(new Action(() =>
                {
                    Thread.Sleep(1000);
                    while (true)
                    {
                        //数据库日志收缩
                        try
                        {
                            DoShrinkDatabaseLog();
                        }
                        catch (Exception ex)
                        {
                            LogHelper.WriteError("mDatabaseBackup", "DoDatabaseBackup Error", ex);
                        }
                        //数据库备份
                        try
                        {
                            DoDatabaseBackup();
                        }
                        catch (Exception ex)
                        {
                            LogHelper.WriteError("mDatabaseBackup", "DoDatabaseBackup Error", ex);
                        }
                        //删除日志
                        try
                        {
                            DoRemoveErrorLog();
                        }
                        catch (Exception ex)
                        {
                            LogHelper.WriteError("mDoRemoveErrorLog", "DoRemoveErrorLog Error", ex);
                        }
                        //执行所有任务
                        try
                        {
                            DoALLTask();
                        }
                        catch (Exception ex)
                        {
                            LogHelper.WriteError("mDoALLTask", "DoALLTask Error", ex);
                        }
                        GC.Collect();
                        LogHelper_Log(LogType.LogType_Info, "下条生成时间", DateTime.Now.AddSeconds(TimmerSecond).ToString("yyyy-MM-dd HH:mm:ss"), null);
                        Thread.Sleep(TimmerSecond * 1000);
                    }
                })))
                {
                    IsBackground = true,
                };
                this.mAllBackgroundTask.Start();
                #endregion
            }
        }
        //后台通知
        void DoDoSendSystemMsg()
        {
            foreach (var item in urllist)
            {
                ApiHelper.DoSendSystemMsg(item.CompanyID);
            }
        }
        void DoALLTask()
        {
            if (DateTime.Now.Hour >= AllTaskWorkEndHour || DateTime.Now.Hour <= AllTaskWorkStartHour)
            {
                LogHelper_Log(LogType.LogType_Info, "任务休眠", DateTime.Now.AddSeconds(30).ToString("yyyy-MM-dd HH:mm:ss"), null);
                return;
            }
            foreach (var url in urllist)
            {
                string sendresult = ApiHelper.DoALLTask(url);
                if (!string.IsNullOrEmpty(sendresult))
                {
                    LogHelper.WriteInfo("DoALLTask", "{0}", sendresult);
                }
            }
            if (!OnlySelf)
            {
                DoDoSendSystemMsg();
            }
        }
        void DoShrinkDatabaseLog()
        {
            if (DateTime.Now.Hour != DBShrinkHour)
            {
                return;
            }
            if (ShrinkLogTime > DateTime.Now)
            {
                return;
            }
            foreach (var item in urllist)
            {
                if (string.IsNullOrEmpty(item.VirName))
                {
                    continue;
                }
                ApiHelper.DoShrinkDatabaseLog(item);
            }
            ShrinkLogTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd")).AddDays(1);
        }
        void DoDatabaseBackup()
        {
            if (DateTime.Now.Hour != DBBackupHour)
            {
                return;
            }
            if (NextBackUpTime > DateTime.Now)
            {
                return;
            }
            urllist = ApiHelper.GetAllAPIUrl();
            foreach (var item in urllist)
            {
                if (string.IsNullOrEmpty(item.VirName))
                {
                    continue;
                }
                ApiHelper.DoDatabaseBackup(item);
            }
            NextBackUpTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd")).AddDays(1);
        }
        void DoRemoveErrorLog()
        {
            if (DateTime.Now.Hour != DBRemoveLogHour)
            {
                return;
            }
            if (NextDeleteLogTime > DateTime.Now)
            {
                return;
            }
            urllist = ApiHelper.GetAllAPIUrl();
            foreach (var item in urllist)
            {
                if (string.IsNullOrEmpty(item.VirName))
                {
                    continue;
                }
                ApiHelper.DoRemoveErrorLog(item);
            }
            NextDeleteLogTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd")).AddDays(1);
        }
        private int mLogCount = 0;
        private void btnClearLog_Click(object sender, EventArgs e)
        {
            this.rtbLog.Text = string.Empty;
            this.mLogCount = 0;
        }
        void LogHelper_Log(LogType arg1, string arg2, string arg3, Exception arg4)
        {
            Color foreColor = Color.Black;
            switch (arg1)
            {
                case LogType.LogType_Debug:
                    {
                        foreColor = Color.Gray;
                        return;
                    }
                    break;
                case LogType.LogType_Info:
                    {
                        foreColor = Color.Black;
                    }
                    break;
                case LogType.LogType_Error:
                case LogType.LogType_Fatal:
                    {
                        foreColor = Color.Red;
                    }
                    break;
            }
            string msg = string.Format("{0}  {1}  {2}{3}" + Environment.NewLine, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"), arg2, arg3, arg4 == null ? string.Empty : (Environment.NewLine + arg4.ToString()));
            this.BeginInvoke(new Action(() =>
            {
                mLogCount++;
                if (mLogCount > 500)
                {
                    this.rtbLog.Text = string.Empty;
                    mLogCount = 0;
                }
                int start = this.rtbLog.TextLength;
                this.rtbLog.AppendText(msg);
                this.rtbLog.Select(start, msg.Length);
                this.rtbLog.SelectionColor = foreColor;
                this.rtbLog.Select(this.rtbLog.TextLength, 0);

                if (this.cbAutoScrollLog.Checked)
                {
                    this.rtbLog.ScrollToCaret();
                }
            }));
        }
    }
}
