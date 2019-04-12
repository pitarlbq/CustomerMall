using ICSharpCode.SharpZipLib.Zip;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace Utility
{
    public class Tools
    {
        /// <summary>
        /// 转换人民币大小金额
        /// </summary>
        /// <param name="num">金额</param>
        /// <returns>返回大写形式</returns>
        public static string CmycurD(decimal num)
        {
            string str1 = "零壹贰叁肆伍陆柒捌玖";            //0-9所对应的汉字
            string str2 = "万仟佰拾亿仟佰拾万仟佰拾元角分"; //数字位所对应的汉字
            string str3 = "";    //从原num值中取出的值
            string str4 = "";    //数字的字符串形式
            string str5 = "";  //人民币大写金额形式
            int i;    //循环变量
            int j;    //num的值乘以100的字符串长度
            string ch1 = "";    //数字的汉语读法
            string ch2 = "";    //数字位的汉字读法
            int nzero = 0;  //用来计算连续的零值是几个
            int temp;            //从原num值中取出的值

            num = Math.Round(Math.Abs(num), 2, MidpointRounding.AwayFromZero);    //将num取绝对值并四舍五入取2位小数
            str4 = ((long)(num * 100)).ToString();        //将num乘100并转换成字符串形式
            j = str4.Length;      //找出最高位
            if (j > 15) { return "溢出"; }
            str2 = str2.Substring(15 - j);   //取出对应位数的str2的值。如：200.55,j为5所以str2=佰拾元角分

            //循环取出每一位需要转换的值
            for (i = 0; i < j; i++)
            {
                str3 = str4.Substring(i, 1);          //取出需转换的某一位的值
                temp = Convert.ToInt32(str3);      //转换为数字
                if (i != (j - 3) && i != (j - 7) && i != (j - 11) && i != (j - 15))
                {
                    //当所取位数不为元、万、亿、万亿上的数字时
                    if (str3 == "0")
                    {
                        ch1 = "";
                        ch2 = "";
                        nzero = nzero + 1;
                    }
                    else
                    {
                        if (str3 != "0" && nzero != 0)
                        {
                            ch1 = "零" + str1.Substring(temp * 1, 1);
                            ch2 = str2.Substring(i, 1);
                            nzero = 0;
                        }
                        else
                        {
                            ch1 = str1.Substring(temp * 1, 1);
                            ch2 = str2.Substring(i, 1);
                            nzero = 0;
                        }
                    }
                }
                else
                {
                    //该位是万亿，亿，万，元位等关键位
                    if (str3 != "0" && nzero != 0)
                    {
                        ch1 = "零" + str1.Substring(temp * 1, 1);
                        ch2 = str2.Substring(i, 1);
                        nzero = 0;
                    }
                    else
                    {
                        if (str3 != "0" && nzero == 0)
                        {
                            ch1 = str1.Substring(temp * 1, 1);
                            ch2 = str2.Substring(i, 1);
                            nzero = 0;
                        }
                        else
                        {
                            if (str3 == "0" && nzero >= 3)
                            {
                                ch1 = "";
                                ch2 = "";
                                nzero = nzero + 1;
                            }
                            else
                            {
                                if (j >= 11)
                                {
                                    ch1 = "";
                                    nzero = nzero + 1;
                                }
                                else
                                {
                                    ch1 = "";
                                    ch2 = str2.Substring(i, 1);
                                    nzero = nzero + 1;
                                }
                            }
                        }
                    }
                }
                if (i == (j - 11) || i == (j - 3))
                {
                    //如果该位是亿位或元位，则必须写上
                    ch2 = str2.Substring(i, 1);
                }
                str5 = str5 + ch1 + ch2;

                if (i == j - 1 && str3 == "0")
                {
                    //最后一位（分）为0时，加上“整”
                    str5 = str5 + '整';
                }
            }
            if (num == 0)
            {
                str5 = "零元整";
            }
            return str5;
        }
        public static void DeleteFile(string srcPath, string filetype, int keepday = 0, int keepcount = 0)
        {
            try
            {
                filetype = string.IsNullOrEmpty(filetype) ? "zip" : filetype;
                DirectoryInfo dir = new DirectoryInfo(srcPath);
                FileInfo[] fileinfo = dir.GetFiles().OrderBy(p => p.CreationTime).ToArray();
                DateTime keeptime = DateTime.Now.AddDays(-keepday);
                int total = fileinfo.Length;
                foreach (FileInfo file in fileinfo)
                {
                    if (keepday > 0 && file.CreationTime >= keeptime)
                    {
                        continue;
                    }
                    if (keepcount > 0 && total <= keepcount)
                    {
                        continue;
                    }
                    if (file.Extension.ToLower().Contains(filetype))
                    {
                        File.Delete(file.FullName);
                    }
                    total--;
                }
            }
            catch (Exception)
            {
            }
        }
        public static void UnZipFile(string zipFilePath, string newFilePath, string newFileName)
        {
            if (!File.Exists(zipFilePath))
            {
                //Console.WriteLine("Cannot find file '{0}'", zipFilePath);
                return;
            }
            string newZipFolderPath = newFilePath + newFileName;
            if (!Directory.Exists(newZipFolderPath))
            {
                Directory.CreateDirectory(newZipFolderPath);
            }
            DeleteFile(newZipFolderPath, "zip");
            string newZipFilePath = newZipFolderPath + "\\Web_" + DateTime.Now.ToString("yyyyMMddHHmm") + ".zip";
            System.IO.File.Copy(zipFilePath, newZipFilePath, true);
            using (ZipInputStream s = new ZipInputStream(File.OpenRead(newZipFilePath)))
            {
                ZipEntry theEntry;
                while ((theEntry = s.GetNextEntry()) != null)
                {
                    //Console.WriteLine(theEntry.Name);
                    string directoryName = Path.GetDirectoryName(theEntry.Name);
                    string fileName = Path.GetFileName(theEntry.Name);
                    // create directory
                    if (directoryName.Length > 0)
                    {
                        if (!Directory.Exists(newZipFolderPath + "\\" + directoryName))
                        {
                            Directory.CreateDirectory(newZipFolderPath + "\\" + directoryName);
                        }
                    }

                    if (fileName != String.Empty)
                    {
                        using (FileStream streamWriter = File.Create(newZipFolderPath + "\\" + theEntry.Name))
                        {

                            int size = 2048;
                            byte[] data = new byte[2048];
                            while (true)
                            {
                                size = s.Read(data, 0, data.Length);
                                if (size > 0)
                                {
                                    streamWriter.Write(data, 0, size);
                                }
                                else
                                {
                                    break;
                                }
                            }
                        }
                    }
                }
            }
        }
        public static DateTime GetRoomFeeEndTime(int FeeType, int SummaryChargeTypeCount, int EndNumberType, int EndTypeID, bool AutoToMonthEnd, DateTime StartTime, DateTime? FeeEndTime = null)
        {
            if (FeeType != 1)
            {
                return DateTime.MinValue;
            }
            if (EndTypeID == 3)
            {
                return FeeEndTime.HasValue ? Convert.ToDateTime(FeeEndTime) : DateTime.MinValue;
            }
            if (StartTime == DateTime.MinValue)
            {
                //StartTime = DateTime.Now;
                return DateTime.MinValue;
            }
            SummaryChargeTypeCount = SummaryChargeTypeCount < 0 ? 0 : SummaryChargeTypeCount;
            EndNumberType = EndNumberType == int.MinValue ? 1 : EndNumberType;
            EndTypeID = EndTypeID == int.MinValue ? 1 : EndTypeID;
            DateTime EndTime = DateTime.MinValue;
            if (EndTypeID == 1)
            {
                StartTime = StartTime < DateTime.Now ? DateTime.Now : StartTime;
            }
            if (SummaryChargeTypeCount == 0)
            {
                EndTime = StartTime.AddDays(1 - StartTime.Day).AddMonths(1).AddDays(-1);
            }
            else if (AutoToMonthEnd)
            {
                if (EndNumberType == 1)
                {
                    if (StartTime.Day > 1)
                    {
                        SummaryChargeTypeCount = SummaryChargeTypeCount + 1;
                    }
                    EndTime = StartTime.AddDays(1 - StartTime.Day).AddMonths(SummaryChargeTypeCount).AddDays(-1);
                }
                else
                {
                    StartTime = StartTime.AddDays(SummaryChargeTypeCount);
                    EndTime = StartTime.AddDays(1 - StartTime.Day).AddMonths(1).AddDays(-1);
                }
            }
            else
            {
                if (EndNumberType == 1)
                {
                    EndTime = StartTime.AddMonths(SummaryChargeTypeCount).AddDays(-1);
                }
                else
                {
                    EndTime = StartTime.AddDays(SummaryChargeTypeCount);
                }
            }
            return EndTime;
        }
        public static string FormatMoney(decimal money, int defaultcount = 2)
        {

            if (money < 0)
            {
                return "0.00";
            }
            if (defaultcount > 2 && money.ToString().IndexOf('.') > -1)
            {
                int total = getdecimalxiaoshu(money, defaultcount: defaultcount);
                if (total > defaultcount)
                {
                    return string.Format("{0:N" + defaultcount + "}", money);
                }
                else if (total > 2)
                {
                    return string.Format("{0:N" + total + "}", money);
                }
                else
                {
                    return string.Format("{0:N2}", money);
                }
            }
            return string.Format("{0:N2}", money);
        }
        public static int getdecimalxiaoshu(decimal value, int defaultcount = 4)
        {
            if (value <= 0)
            {
                return 0;
            }
            string format = string.Empty;
            for (int i = 0; i < defaultcount; i++)
            {
                format += "#";
            }
            string[] results = value.ToString("0." + format).Split('.');
            if (results.Length == 1)
            {
                return 0;
            }
            return results[1].Length;
        }
        public static string Md5Hash(string input)
        {
            MD5CryptoServiceProvider md5Hasher = new MD5CryptoServiceProvider();
            byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(input));
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            return sBuilder.ToString();
        }
        public static int calculatemonth(DateTime starttime, DateTime endtime)
        {
            try
            {
                if (starttime == DateTime.MinValue || endtime == DateTime.MinValue)
                {
                    return 0;
                }
                int count = 0;
                int year1 = starttime.Year;
                int month1 = starttime.Month;
                int day1 = starttime.Day;
                int year2 = endtime.Year;
                int month2 = endtime.Month;
                int day2 = endtime.Day;
                int newday2 = endtime.AddDays(1 - day2).AddMonths(1).AddDays(-1).Day;
                bool endtime_is_lastday = false;
                if (endtime.AddDays(1).Day == 1)
                {
                    endtime_is_lastday = true;
                }
                if (endtime_is_lastday)
                {
                    count = (year2 - year1) * 12 + (month2 - month1);
                }
                else if (day1 == 1)
                {
                    if (day2 == newday2)
                    {
                        count = (year2 - year1) * 12 + (month2 - month1) + 1;
                    }
                    else
                    {
                        count = (year2 - year1) * 12 + (month2 - month1);
                    }
                }
                else if (day2 < (day1 - 1))
                {
                    count = (year2 - year1) * 12 + (month2 - month1) - 1;
                }
                else
                {
                    count = (year2 - year1) * 12 + (month2 - month1);
                }
                return count;
            }
            catch (Exception)
            {
                return 0;
            }
        }
        public static int calculateTotaldays(DateTime starttime, DateTime endtime, int monthnumber, bool isTotal)
        {
            try
            {
                //var newstarttime, newendtime, temp1, temp2, startdate, enddate, date, time, count;
                if (starttime == DateTime.MinValue || endtime == DateTime.MinValue)
                {
                    if (isTotal)
                    {
                        return 1;
                    }
                    return 0;
                }
                string newendtime = string.Empty;
                int count = 0;
                bool endtime_is_lastday = false;
                if (endtime.AddDays(1).Day == 1 && monthnumber >= 1 && starttime.Day != 1)
                {
                    endtime_is_lastday = true;
                }
                string newstarttime = string.Empty;
                if (isTotal)
                {
                    if (endtime_is_lastday)
                    {
                        newstarttime = starttime.AddDays(1 - starttime.Day).ToString("yyyy-MM-dd");
                        newendtime = starttime.AddDays(1 - starttime.Day).AddMonths(1).ToString("yyyy-MM-dd");
                    }
                    else
                    {
                        newstarttime = getNextMonth(starttime, monthnumber);
                        newendtime = getNextMonth(DateTime.Parse(newstarttime), 1);
                    }
                    count = 0;
                }
                else
                {
                    if (starttime == endtime)
                    {
                        return 1;
                    }
                    if (endtime_is_lastday)
                    {
                        newstarttime = starttime.ToString("yyyy-MM-dd");
                        newendtime = starttime.AddDays(1 - starttime.Day).AddMonths(1).AddDays(-1).ToString("yyyy-MM-dd");
                    }
                    else
                    {
                        newstarttime = getNextMonth(starttime, monthnumber);
                        newendtime = endtime.ToString("yyyy-MM-dd");
                    }
                    count = 1;
                }
                DateTime startdate = DateTime.Parse(newstarttime);
                DateTime enddate = DateTime.Parse(newendtime);
                if (startdate > enddate)
                {
                    if (isTotal)
                    {
                        return 1;
                    }
                    return 0;
                }
                TimeSpan date = enddate - startdate;
                int time = Convert.ToInt32(date.TotalMilliseconds / (1000 * 60 * 60 * 24)) + count;
                return time;
            }
            catch (Exception)
            {
                return 0;
            }
        }
        public static string getNextMonth(DateTime date, int monthnumber)
        {
            try
            {
                //var arr, year1, month1, day1, year2, month2, day2, newmonth2, addyearcount, newdate, lastday;
                //arr = date.split('-');
                int year1 = date.Year; //获取当前日期的年份
                int month1 = date.Month; //获取当前日期的月份
                int day1 = date.Day; //获取当前日期的日
                int newmonth2 = month1 + monthnumber;
                int addyearcount = (newmonth2 - 1) / 12;
                int year2 = year1 + addyearcount;
                int month2 = newmonth2 - (12 * addyearcount);
                int day2 = day1;
                DateTime newdate = DateTime.Parse(year2 + "-" + month2 + "-01").AddMonths(1).AddDays(-1);
                int lastday = newdate.Day;
                string month2str = month2.ToString("D2");
                if (day2 > lastday)
                {
                    day2 = lastday;
                }
                string day2str = day2.ToString("D2");
                string t2 = year2 + "-" + month2str + "-" + day2str;
                return t2;
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }
        public static string GetRandomString(int CodeCount)
        {
            string allChar = "1,2,3,4,5,6,7,8,9,A,B,C,D,E,F,G,H,i,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z";
            string[] allCharArray = allChar.Split(',');
            string RandomCode = "";
            int temp = -1;
            Random rand = new Random();
            for (int i = 0; i < CodeCount; i++)
            {
                if (temp != -1)
                {
                    rand = new Random(temp * i * ((int)DateTime.Now.Ticks));
                }
                int t = rand.Next(allCharArray.Length - 1);
                while (temp == t)
                {
                    t = rand.Next(allCharArray.Length - 1);
                }
                temp = t;
                RandomCode += allCharArray[t];
            }

            return RandomCode;
        }
        public static string GetWebClientIp()
        {
            string userIP = "IP";

            try
            {
                if (System.Web.HttpContext.Current == null
            || System.Web.HttpContext.Current.Request == null
            || System.Web.HttpContext.Current.Request.ServerVariables == null)
                    return "";

                string CustomerIP = "";

                //CDN加速后取到的IP   
                CustomerIP = System.Web.HttpContext.Current.Request.Headers["Cdn-Src-Ip"];
                if (!string.IsNullOrEmpty(CustomerIP))
                {
                    return CustomerIP;
                }

                CustomerIP = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];


                if (!String.IsNullOrEmpty(CustomerIP))
                    return CustomerIP;

                if (System.Web.HttpContext.Current.Request.ServerVariables["HTTP_VIA"] != null)
                {
                    CustomerIP = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
                    if (CustomerIP == null)
                        CustomerIP = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
                }
                else
                {
                    CustomerIP = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];

                }

                if (string.Compare(CustomerIP, "unknown", true) == 0)
                    return System.Web.HttpContext.Current.Request.UserHostAddress;
                return CustomerIP;
            }
            catch { }

            return userIP;
        }
        public static HttpWebResponse CreatePostHttpResponse(string url, string datas, Encoding charset, string cert, string password)
        {

            HttpWebRequest request = null;
            //HTTPSQ请求
            try
            {
                ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(CheckValidationResult);
                request = WebRequest.Create(url) as HttpWebRequest;

                ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(CheckValidationResult);
                X509Certificate cer = new X509Certificate(cert, password, X509KeyStorageFlags.MachineKeySet);
                request.ClientCertificates.Add(cer);

                request.ProtocolVersion = HttpVersion.Version10;
                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";

                //如果需要POST数据   
                //if (!(parameters == null || parameters.Count == 0))
                //{
                StringBuilder buffer = new StringBuilder();
                //int i = 0;
                //foreach (string key in parameters.Keys)
                //{
                //    if (i > 0)
                //    {
                //        buffer.AppendFormat("&{0}={1}", key, parameters[key]);
                //    }
                //    else
                //    {
                //        buffer.AppendFormat("{0}={1}", key, parameters[key]);
                //    }
                //    i++;
                //}
                buffer.AppendFormat(datas);
                byte[] data = charset.GetBytes(buffer.ToString());
                using (Stream stream = request.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                }
                //}
            }
            catch (Exception ex)
            {
                LogHelper.WriteError("HttpWebResponse", "error", ex);
            }
            return request.GetResponse() as HttpWebResponse;
        }
        public static string GetSignString(Dictionary<string, string> dic, string key)
        {
            dic = dic.OrderBy(d => d.Key).ToDictionary(d => d.Key, d => d.Value);
            //连接字段
            var sign = dic.Aggregate("", (current, d) => current + (d.Key + "=" + d.Value + "&"));
            sign += "key=" + key;
            //MD5
            sign = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(sign, "MD5").ToUpper();

            return sign;
        }
        private static bool CheckValidationResult(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors)
        {
            return true; //总是接受   
        }
        public static long GetTimeStamp(int Days = 0)
        {
            DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
            TimeSpan ts = DateTime.Now.AddDays(Days) - startTime;
            return Convert.ToInt64(ts.TotalSeconds) * 1000;
        }
        public static string GetVerifyCode()
        {
            Random rnd = new Random();
            string VerifyCode = rnd.Next(1000, 9999).ToString();
            return VerifyCode;
        }
        public static string SendVerifyCode(string mobile, string content)
        {
            var config = new SiteConfig();
            string VerifyCode = "123456";
            if (mobile.Length == 11)
            {
                VerifyCode = mobile.Substring(mobile.Length - 6, 6);
            }
            if (!config.SmsServerEnable)
            {
                return VerifyCode;
            }
            VerifyCode = GetVerifyCode();
            content = string.Format(content, VerifyCode);
            Utility.SmsHelper.SendSms(mobile, content, VerifyCode);
            return VerifyCode;
        }
        #region 加密、解密

        // Encrypt the string.
        public static string Encrypt_Old(string PlainText)
        {
            SymmetricAlgorithm key = new DESCryptoServiceProvider()
            {
                Key = Encoding.UTF8.GetBytes("vU$5)=By"),
                IV = Encoding.UTF8.GetBytes("20180123")
            };
            // Create a memory stream.
            MemoryStream ms = new MemoryStream();

            // Create a CryptoStream using the memory stream and the 
            // CSP DES key.  
            CryptoStream encStream = new CryptoStream(ms, key.CreateEncryptor(), CryptoStreamMode.Write);

            // Create a StreamWriter to write a string
            // to the stream.
            StreamWriter sw = new StreamWriter(encStream);

            // Write the plaintext to the stream.
            sw.WriteLine(PlainText);

            // Close the StreamWriter and CryptoStream.
            sw.Close();
            encStream.Close();

            // Get an array of bytes that represents
            // the memory stream.
            byte[] buffer = ms.ToArray();

            // Close the memory stream.
            ms.Close();

            // Return the encrypted byte array.
            return Convert.ToBase64String(buffer);
        }

        // Decrypt the byte array.
        public static string Decrypt_Old(string base64Str)
        {
            byte[] CypherText = Convert.FromBase64String(base64Str);
            SymmetricAlgorithm key = new DESCryptoServiceProvider()
            {
                Key = Encoding.UTF8.GetBytes("vU$5)=By"),
                IV = Encoding.UTF8.GetBytes("20180123")
            };
            // Create a memory stream to the passed buffer.
            MemoryStream ms = new MemoryStream(CypherText);

            // Create a CryptoStream using the memory stream and the 
            // CSP DES key. 
            CryptoStream encStream = new CryptoStream(ms, key.CreateDecryptor(), CryptoStreamMode.Read);

            // Create a StreamReader for reading the stream.
            StreamReader sr = new StreamReader(encStream);

            // Read the stream as a string.
            string val = sr.ReadLine();

            // Close the streams.
            sr.Close();
            encStream.Close();
            ms.Close();

            return val;
        }
        /// <summary>  
        /// DES加密算法  
        /// sKey为8位或16位  
        /// </summary>  
        /// <param name="pToEncrypt">需要加密的字符串</param>  
        /// <param name="sKey">密钥</param>  
        /// <returns></returns>  
        public static string sKey = "saasyy06";
        public static string Encrypt(string pToEncrypt)
        {
            StringBuilder ret = new StringBuilder();

            try
            {
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                byte[] inputByteArray = Encoding.Default.GetBytes(pToEncrypt);
                des.Key = ASCIIEncoding.ASCII.GetBytes(sKey);
                des.IV = ASCIIEncoding.ASCII.GetBytes(sKey);
                MemoryStream ms = new MemoryStream();
                CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write);
                cs.Write(inputByteArray, 0, inputByteArray.Length);
                cs.FlushFinalBlock();
                foreach (byte b in ms.ToArray())
                {
                    ret.AppendFormat("{0:X2}", b);
                }
                ret.ToString();
            }
            catch
            {
            }
            return ret.ToString();
        }
        /// <summary>  
        /// DES解密算法  
        /// sKey为8位或16位  
        /// </summary>  
        /// <param name="pToDecrypt">需要解密的字符串</param>  
        /// <param name="sKey">密钥</param>  
        /// <returns></returns>  
        public static string Decrypt(string pToDecrypt)
        {
            MemoryStream ms = new MemoryStream();
            try
            {
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                byte[] inputByteArray = new byte[pToDecrypt.Length / 2];
                for (int x = 0; x < pToDecrypt.Length / 2; x++)
                {
                    int i = (Convert.ToInt32(pToDecrypt.Substring(x * 2, 2), 16));
                    inputByteArray[x] = (byte)i;
                }
                des.Key = ASCIIEncoding.ASCII.GetBytes(sKey);
                des.IV = ASCIIEncoding.ASCII.GetBytes(sKey);

                CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Write);
                cs.Write(inputByteArray, 0, inputByteArray.Length);
                cs.FlushFinalBlock();
                StringBuilder ret = new StringBuilder();
            }
            catch
            {

            }
            return System.Text.Encoding.Default.GetString(ms.ToArray());
        }
        #endregion
        public static string GetClientIP()
        {
            string uip = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"].ToString();
            if (System.Web.HttpContext.Current.Request.ServerVariables["HTTP_VIA"] != null)
            {
                uip = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"].ToString();
            }
            else
            {
                uip = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"].ToString();
            }
            return uip;
        }
        public static string GetByteString(int length = 4)
        {
            string s = GetRandomString(4, useLow: true, useUpp: true);
            Encoding encode = Encoding.UTF8;
            byte[] b = encode.GetBytes(s);//按照指定编码将string编程字节数组
            string result = string.Empty;
            for (int i = 0; i < b.Length; i++)//逐字节变为16进制字符
            {
                result += Convert.ToString(b[i], 16);
            }
            return result;
        }
        public static string GetRandomString(int length, bool useNum = false, bool useLow = false, bool useUpp = true)
        {
            string str = string.Empty;
            byte[] b = new byte[4];
            new System.Security.Cryptography.RNGCryptoServiceProvider().GetBytes(b);
            Random r = new Random(BitConverter.ToInt32(b, 0));
            string s = null;
            if (useNum == true) { str += "0123456789"; }
            if (useLow == true) { str += "abcdefghijklmnopqrstuvwxyz"; }
            if (useUpp == true) { str += "ABCDEFGHIJKLMNOPQRSTUVWXYZ"; }
            for (int i = 0; i < length; i++)
            {
                s += str.Substring(r.Next(0, str.Length - 1), 1);
            }
            return s;
        }
        public static T GetValueFromDic<T>(Dictionary<string, object> dic, string key)
        {
            if (dic.ContainsKey(key))
            {
                var value = dic[key];
                return (T)value;
            }
            return default(T);
        }
        public static string GetContextPath()
        {
            string domain_path = "http://" + HttpContext.Current.Request.ServerVariables["HTTP_HOST"].ToString();
            if (domain_path.EndsWith("/"))
            {
                domain_path = domain_path.Substring(0, domain_path.Length - 1);
            }
            return domain_path + getApplicationPath();
        }
        public static string getApplicationPath()
        {
            string _ApplicationPath = HttpContext.Current.Request.ApplicationPath;
            if (_ApplicationPath.Length == 1)
            {
                _ApplicationPath = "";
            }
            else if (!_ApplicationPath.StartsWith("/"))
            {
                _ApplicationPath = "/" + _ApplicationPath;
            }
            return _ApplicationPath;
        }
        public static int GetAppVersionCode(string version)
        {
            try
            {
                if (string.IsNullOrEmpty(version))
                {
                    return 0;
                }
                string[] version_array = version.Split('.');
                string versioncode = string.Empty;
                for (int i = 0; i < version_array.Length; i++)
                {
                    var item = version_array[i];
                    if (i > 0)
                    {
                        versioncode += Convert.ToInt32(item).ToString("D2");
                        continue;
                    }
                    versioncode += item;
                }
                LogHelper.WriteInfo("version." + version, Convert.ToInt32(versioncode).ToString());
                return Convert.ToInt32(versioncode);
            }
            catch (Exception)
            {
                return 0;
            }
        }
        public static bool CheckVersionCode(string newversion, string oldversion)
        {
            return GetAppVersionCode(newversion) < GetAppVersionCode(oldversion);
        }
        public static string GetJosnValue(string jsonStr, string key)
        {
            string result = string.Empty;
            if (!IsNullOrWhiteSpace(jsonStr))
            {
                key = "\"" + key.Trim('"') + "\"";
                int index = jsonStr.IndexOf(key) + key.Length + 1;
                if (index > key.Length + 1)
                {
                    //先截逗号，若是最后一个，截“｝”号，取最小值

                    int end = jsonStr.IndexOf(',', index);
                    if (end == -1)
                    {
                        end = jsonStr.IndexOf('}', index);
                    }
                    //index = json.IndexOf('"', index + key.Length + 1) + 1;
                    result = jsonStr.Substring(index, end - index);
                    //过滤引号或空格
                    result = result.Trim(new char[] { '"', ' ', '\'' });
                }
            }
            return result;
        }
        public static bool IsNullOrWhiteSpace(string value)
        {
            if (value != null)
            {
                for (int i = 0; i < value.Length; i++)
                {
                    if (!char.IsWhiteSpace(value[i]))
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        public static DateTime GetDateTimeByTimeStamp(long timeSpan)
        {
            DateTime start = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
            TimeSpan ts = new TimeSpan(timeSpan * 10000);
            return start.Add(ts);
        }
        public static bool IsNumeric(string value)
        {
            return Regex.IsMatch(value, @"^[+-]?\d*[.]?\d*$");
        }
    }
}
