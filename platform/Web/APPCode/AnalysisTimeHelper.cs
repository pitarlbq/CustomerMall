using Foresight.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.APPCode
{
    public class AnalysisTimeHelper
    {
        public static void GetSK(int UserID, out DateTime StartTime, out DateTime EndTime, out string Title)
        {
            StartTime = DateTime.Today;
            EndTime = DateTime.Today.AddDays(1);
            Title = "今日收款";
            AnalysisSummary analysisSummary = AnalysisSummary.GetAnalysisSummaryByCode(UserID, "jrsk");
            if (analysisSummary == null)
            {
                return;
            }
            Title = analysisSummary.AnalysisName + "收款";
            switch (analysisSummary.AnalysisCode)
            {
                case "jrsk_jr":
                    break;
                case "jrsk_zr":
                    {
                        string _endtime = DateTime.Today.AddDays(-1).ToString("yyyy-MM-dd") + " 23:59:59";
                        StartTime = DateTime.Today.AddDays(-1);
                        EndTime = Convert.ToDateTime(_endtime);
                    }
                    break;
                case "jrsk_bz":
                    {
                        StartTime = GetWeekFirstDayMon(DateTime.Today);
                        string _endtime = (StartTime.AddDays(7)).ToString("yyyy-MM-dd") + " 23:59:59";
                        EndTime = Convert.ToDateTime(_endtime);
                    }
                    break;
                case "jrsk_byd":
                    {
                        StartTime = DateTime.Today.AddDays(1 - DateTime.Today.Day);
                        string _endtime = (StartTime.AddMonths(1).AddDays(-1)).ToString("yyyy-MM-dd") + " 23:59:59";
                        EndTime = Convert.ToDateTime(_endtime);
                    }
                    break;
                case "jrsk_bjd":
                    {
                        StartTime = DateTime.Today.AddMonths(0 - ((DateTime.Today.Month - 1) % 3)).AddDays(1 - DateTime.Today.Day);
                        string _endtime = (StartTime.AddMonths(3).AddDays(-1)).ToString("yyyy-MM-dd") + " 23:59:59";
                        EndTime = Convert.ToDateTime(_endtime);
                    }
                    break;
                case "jrsk_bnd":
                    {
                        StartTime = DateTime.Parse(DateTime.Now.ToString("yyyy-01-01"));
                        string _endtime = (DateTime.Parse(DateTime.Now.ToString("yyyy-12-31"))).ToString("yyyy-MM-dd") + " 23:59:59";
                        EndTime = Convert.ToDateTime(_endtime);
                    }
                    break;
                default:
                    break;
            }
        }
        public static void GetQK(int UserID, out DateTime StartTime, out DateTime EndTime, out string Title)
        {
            StartTime = DateTime.MinValue;
            EndTime = DateTime.MinValue;
            Title = "累计欠款";
            AnalysisSummary analysisSummary = AnalysisSummary.GetAnalysisSummaryByCode(UserID, "ljqf");
            if (analysisSummary == null)
            {
                return;
            }
            Title = analysisSummary.AnalysisName + "欠款";
            switch (analysisSummary.AnalysisCode)
            {
                case "ljqf_jzjr":
                    StartTime = DateTime.MinValue;
                    EndTime = DateTime.Today;
                    break;
                case "ljqf_byd":
                    {
                        StartTime = DateTime.Today.AddDays(1 - DateTime.Today.Day);
                        string _endtime = (StartTime.AddMonths(1).AddDays(-1)).ToString("yyyy-MM-dd") + " 23:59:59";
                        EndTime = Convert.ToDateTime(_endtime);
                    }
                    break;
                case "ljqf_bnd":
                    {
                        StartTime = DateTime.Parse(DateTime.Now.ToString("yyyy-01-01"));
                        string _endtime = (DateTime.Parse(DateTime.Now.ToString("yyyy-12-31"))).ToString("yyyy-MM-dd") + " 23:59:59";
                        EndTime = Convert.ToDateTime(_endtime);
                    }
                    break;
                case "ljqf_lslj":
                    {
                        StartTime = DateTime.MinValue;
                        string _endtime = (DateTime.Parse(DateTime.Now.ToString("yyyy-01-01")).AddDays(-1)).ToString("yyyy-MM-dd") + " 23:59:59";
                        EndTime = Convert.ToDateTime(_endtime);
                    }
                    break;
                default:
                    break;
            }
        }
        public static void GetSFL(int UserID, out DateTime StartTime, out DateTime EndTime, out string Title)
        {
            StartTime = DateTime.Today.AddDays(1 - DateTime.Today.Day);
            EndTime = StartTime.AddMonths(1);
            Title = "本月度收费率";
            AnalysisSummary analysisSummary = AnalysisSummary.GetAnalysisSummaryByCode(UserID, "bysfl");
            if (analysisSummary == null)
            {
                return;
            }
            Title = analysisSummary.AnalysisName + "收费率";
            switch (analysisSummary.AnalysisCode)
            {
                case "bysfl_byd":
                    break;
                case "bysfl_bjd":
                    {
                        StartTime = DateTime.Today.AddMonths(0 - ((DateTime.Today.Month - 1) % 3)).AddDays(1 - DateTime.Today.Day);
                        string _endtime = (StartTime.AddMonths(3).AddDays(-1)).ToString("yyyy-MM-dd") + " 23:59:59";
                        EndTime = Convert.ToDateTime(_endtime);
                    }
                    break;
                case "bysfl_bnd":
                    {
                        StartTime = DateTime.Parse(DateTime.Now.ToString("yyyy-01-01"));
                        string _endtime = (DateTime.Parse(DateTime.Now.ToString("yyyy-12-31"))).ToString("yyyy-MM-dd") + " 23:59:59";
                        EndTime = Convert.ToDateTime(_endtime);
                    }
                    break;
                case "bysfl_lslj":
                    {
                        StartTime = DateTime.MinValue;
                        EndTime = DateTime.Now;
                    }
                    break;
                default:
                    break;
            }
        }
        public static bool GetQFHS(int UserID, out DateTime StartTime, out DateTime EndTime, out string Title)
        {
            StartTime = DateTime.MinValue;
            EndTime = DateTime.MinValue;
            Title = "欠费户数";
            AnalysisSummary analysisSummary = AnalysisSummary.GetAnalysisSummaryByCode(UserID, "ljqf");
            if (analysisSummary == null)
            {
                return false;
            }
            GetQK(UserID, out StartTime, out EndTime, out Title);
            Title = "欠费户数";
            return true;
        }
        public static DateTime GetWeekFirstDayMon(DateTime datetime)
        {
            //星期一为第一天  
            int weeknow = Convert.ToInt32(datetime.DayOfWeek);

            //因为是以星期一为第一天，所以要判断weeknow等于0时，要向前推6天。  
            weeknow = (weeknow == 0 ? (7 - 1) : (weeknow - 1));
            int daydiff = (-1) * weeknow;

            //本周第一天  
            string FirstDay = datetime.AddDays(daydiff).ToString("yyyy-MM-dd");
            return Convert.ToDateTime(FirstDay);
        }
        public static void GetZCKB(int UserID, out DateTime StartTime, out DateTime EndTime, out string Title)
        {
            StartTime = GetWeekFirstDayMon(DateTime.Today);
            EndTime = StartTime.AddDays(8);
            Title = "本周支出";
            AnalysisSummary analysisSummary = AnalysisSummary.GetAnalysisSummaryByCode(UserID, "zckb");
            if (analysisSummary == null)
            {
                return;
            }
            Title = analysisSummary.AnalysisName + "支出";
            switch (analysisSummary.AnalysisCode)
            {
                case "zckb_bz":
                    break;
                case "zckb_byd":
                    {
                        StartTime = DateTime.Today.AddDays(1 - DateTime.Today.Day);
                        string _endtime = (StartTime.AddMonths(1).AddDays(-1)).ToString("yyyy-MM-dd") + " 23:59:59";
                        EndTime = Convert.ToDateTime(_endtime);
                    }
                    break;
                case "zckb_bjd":
                    {
                        StartTime = DateTime.Today.AddMonths(0 - ((DateTime.Today.Month - 1) % 3)).AddDays(1 - DateTime.Today.Day);
                        string _endtime = (StartTime.AddMonths(3).AddDays(-1)).ToString("yyyy-MM-dd") + " 23:59:59";
                        EndTime = Convert.ToDateTime(_endtime);
                    }
                    break;
                case "zckb_bnd":
                    {
                        StartTime = DateTime.Parse(DateTime.Now.ToString("yyyy-01-01"));
                        string _endtime = (DateTime.Parse(DateTime.Now.ToString("yyyy-12-31"))).ToString("yyyy-MM-dd") + " 23:59:59";
                        EndTime = Convert.ToDateTime(_endtime);
                    }
                    break;
                case "zckb_lslj":
                    {
                        StartTime = DateTime.MinValue;
                        EndTime = DateTime.MinValue;
                    }
                    break;
                default:
                    break;
            }
        }
    }
}