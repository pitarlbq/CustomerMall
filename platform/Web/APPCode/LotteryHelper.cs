using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.APPCode
{
    public class LotteryHelper
    {
        static readonly Dictionary<int, Foresight.DataAccess.Wechat_LotteryActivity> sActivities = new Dictionary<int, Foresight.DataAccess.Wechat_LotteryActivity>();
        static readonly Dictionary<int, Dictionary<string, List<Foresight.DataAccess.Wechat_LotteryActivityRecord>>> sRecords = new Dictionary<int, Dictionary<string, List<Foresight.DataAccess.Wechat_LotteryActivityRecord>>>();
        static readonly Dictionary<int, Dictionary<int, Foresight.DataAccess.Wechat_LotteryActivityPrize>> sPrize = new Dictionary<int, Dictionary<int, Foresight.DataAccess.Wechat_LotteryActivityPrize>>();
        static readonly Dictionary<int, Stack> sPrizeQueue = new Dictionary<int, Stack>();

        internal static void ClearCache()
        {
            lock (sActivities)
            {
                lock (sRecords)
                {
                    lock (sPrizeQueue)
                    {
                        sActivities.Clear();
                        sRecords.Clear();
                        sPrize.Clear();
                        sPrizeQueue.Clear();
                    }
                }
            }
            GC.Collect();
        }

        internal static void ClearCache(int activityID)
        {
            lock (sActivities)
            {
                lock (sRecords)
                {
                    lock (sPrizeQueue)
                    {
                        sActivities.Remove(activityID);
                        sRecords.Remove(activityID);
                        sPrize.Remove(activityID);
                        sPrizeQueue.Remove(activityID);
                    }
                }
            }
            GC.Collect();
        }

        /// <summary>
        /// Test Only
        /// </summary>
        /// <param name="activityID"></param>
        /// <returns></returns>
        internal static int[] GetPrizeQueue(int activityID)
        {
            InitData(activityID);
            var queue = sPrizeQueue[activityID];
            int[] arr = null;
            lock (queue)
            {
                arr = new int[queue.Count];
                queue.CopyTo(arr, 0);
            }
            return arr;
        }

        internal static Foresight.DataAccess.Wechat_LotteryActivity GetActivity(int activityID)
        {
            InitData(activityID);
            if (sActivities.ContainsKey(activityID))
            {
                return sActivities[activityID];
            }
            return null;
        }
        internal static Foresight.DataAccess.Wechat_LotteryActivityPrize[] GetActivityPrizeList(int activityID)
        {
            Foresight.DataAccess.Wechat_LotteryActivityPrize[] list = new Foresight.DataAccess.Wechat_LotteryActivityPrize[] { };
            InitData(activityID);
            if (sPrize.ContainsKey(activityID))
            {
                list = sPrize[activityID].Values.ToArray();
            }
            return list;
        }
        internal static bool CheckRecord(int activityID, string openID, out string err, out int leftTime)
        {
            InitData(activityID);

            var activity = sActivities[activityID];
            List<Foresight.DataAccess.Wechat_LotteryActivityRecord> allRecords = null;
            if (sRecords[activityID].ContainsKey(openID))
            {
                allRecords = sRecords[activityID][openID];
            }
            leftTime = 0;
            err = string.Empty;
            #region 该活动限制用户参与
            Foresight.DataAccess.Wechat_LotteryActivityUser joinuser = null;
            if (activity.UserLimit)
            {
                joinuser = Foresight.DataAccess.Wechat_LotteryActivityUser.GetWechatLotteryActivityUserByOpenID(activity.ID, openID);
                if (joinuser == null)
                {
                    err = "您暂时无权参与此活动";
                    return false;
                }
            }
            #endregion
            if (allRecords != null && allRecords.Count > 0)
            {
                switch (activity.LotteryRepeat)
                {
                    case Utility.EnumModel.LotteryRepeatDefine.Everyday:
                        {
                            leftTime = activity.RepeatTime - allRecords.Where(p => p.RecordTime >= DateTime.Today).Count();
                            if (leftTime > 0)
                            {
                                err = string.Format("您今天还有{0}次抽奖机会", leftTime);
                                return true;
                            }
                            else
                            {
                                err = "您已用光今天的抽奖机会，请明天再来。";
                                return false;
                            }
                        }
                        break;
                    case Utility.EnumModel.LotteryRepeatDefine.Everyweek:
                        {
                            var monday = DateTime.Today.AddDays(1 - (int)DateTime.Today.DayOfWeek);
                            if (DateTime.Today.DayOfWeek == DayOfWeek.Sunday)
                            {
                                monday = DateTime.Today.AddDays(-6);
                            }

                            leftTime = activity.RepeatTime - allRecords.Where(p => p.RecordTime >= monday).Count();

                            if (leftTime > 0)
                            {
                                err = string.Format("您本周还有{0}次抽奖机会", leftTime);
                                return true;
                            }
                            else
                            {
                                err = "您已用光本周的抽奖机会，不能再抽奖了。";
                                return false;
                            }
                        }
                        break;
                    case Utility.EnumModel.LotteryRepeatDefine.Everymonth:
                        {
                            var firstDay = DateTime.Today.AddDays(1 - (int)DateTime.Today.Day);

                            leftTime = activity.RepeatTime - allRecords.Where(p => p.RecordTime >= firstDay).Count();

                            if (leftTime > 0)
                            {
                                err = string.Format("您本月还有{0}次抽奖机会", leftTime);
                                return true;
                            }
                            else
                            {
                                err = "您已用光本月的抽奖机会，不能再抽奖了。";
                                return false;
                            }
                        }
                        break;
                    case Utility.EnumModel.LotteryRepeatDefine.Wholeactive:
                    default:
                        {
                            leftTime = activity.RepeatTime - allRecords.Count;
                            if (leftTime > 0)
                            {
                                err = string.Format("您还有{0}次抽奖机会", leftTime);
                                return true;
                            }
                            else
                            {
                                err = "您已用光所有抽奖机会，不能再抽奖了";
                                return false;
                            }
                        }
                        break;
                }
            }

            return true;
        }

        internal static LotteryCodeDefine CreateRecord(int activityID, string openID, out Foresight.DataAccess.Wechat_LotteryActivityRecord record, out Foresight.DataAccess.Wechat_LotteryActivityPrize prize, out string err, out int leftTime)
        {
            InitData(activityID);
            record = null;
            prize = null;
            err = string.Empty;
            leftTime = 0;

            var activity = GetActivity(activityID);

            if (activity == null)
            {
                return LotteryCodeDefine.ActivityNotExists;
            }

            DateTime timenow = DateTime.Now;

            if (activity.StartTime > timenow)
            {
                return LotteryCodeDefine.NotBegin;
            }
            if (activity.EndTime < timenow)
            {
                return LotteryCodeDefine.HasEnd;
            }


            if (!sRecords[activityID].ContainsKey(openID))
            {
                lock (sRecords[activityID])
                {
                    if (!sRecords[activityID].ContainsKey(openID))
                    {
                        sRecords[activityID].Add(openID, new List<Foresight.DataAccess.Wechat_LotteryActivityRecord>());
                    }
                }
            }

            var myRecords = sRecords[activityID][openID];
            lock (myRecords)
            {

                bool canjoin = CheckRecord(activityID, openID, out err, out leftTime);

                if (canjoin)
                {
                    leftTime--;

                    int prizeID = 0;
                    var queue = sPrizeQueue[activityID];

                    lock (queue)
                    {
                        if (queue.Count > 0)
                        {
                            prizeID = (int)(queue.Pop());
                        }
                    }
                    if (prizeID > 0)
                    {
                        prize = sPrize[activityID][prizeID];
                        if (prize.RepeatTime > 1)//可以重复中奖
                        {
                            if (myRecords.Count(p => p.PrizeID == prizeID) >= prize.RepeatTime)//超过允许中奖次数
                            {
                                prize = null;
                                lock (queue)
                                {
                                    queue.Push(prizeID);
                                }
                            }
                        }
                        else//不能重复中奖
                        {
                            if (myRecords.Count(p => p.PrizeID > 0 && sPrize[activityID][p.PrizeID].RepeatTime <= 1) > 0)//已经有中奖纪录
                            {
                                prize = null;
                                lock (queue)
                                {
                                    queue.Push(prizeID);
                                }
                            }
                        }
                    }

                    var newRecord = new Foresight.DataAccess.Wechat_LotteryActivityRecord()
                    {
                        ActivityID = activityID,
                        OpenID = openID,
                        PrizeID = prize == null ? 0 : prize.ID,
                        RecordTime = timenow,
                    };

                    newRecord.Save();

                    myRecords.Add(newRecord);

                    record = newRecord;


                    return LotteryCodeDefine.Succeed;
                }
                else
                {
                    return LotteryCodeDefine.HasRecord;
                }
            }
        }


        private static void InitData(int activityID)
        {
            if (!sActivities.ContainsKey(activityID))
            {
                lock (sActivities)
                {
                    if (!sActivities.ContainsKey(activityID))
                    {
                        var activity = Foresight.DataAccess.Wechat_LotteryActivity.GetWechat_LotteryActivity(activityID);
                        sActivities.Add(activityID, activity);
                    }
                }
            }
            if (!sRecords.ContainsKey(activityID))
            {
                lock (sRecords)
                {
                    if (!sRecords.ContainsKey(activityID))
                    {
                        var recordArr = Foresight.DataAccess.Wechat_LotteryActivityRecord.GetWechat_LotteryActivityRecords(activityID, false);
                        List<Foresight.DataAccess.Wechat_LotteryActivityRecord> list = new List<Foresight.DataAccess.Wechat_LotteryActivityRecord>();
                        if (recordArr.Length > 0)
                        {
                            list.AddRange(recordArr);
                        }
                        Dictionary<string, List<Foresight.DataAccess.Wechat_LotteryActivityRecord>> rec = new Dictionary<string, List<Foresight.DataAccess.Wechat_LotteryActivityRecord>>();
                        foreach (var gp in list.GroupBy(p => p.OpenID))
                        {
                            rec.Add(gp.Key, gp.ToList());
                        }
                        sRecords.Add(activityID, rec);
                        var prizes = Foresight.DataAccess.Wechat_LotteryActivityPrize.GetWechat_LotteryActivityPrizes(activityID);
                        sPrize.Add(activityID, prizes.ToDictionary(p => p.ID));
                    }
                }
            }

            if (sActivities.ContainsKey(activityID))
            {
                if (!sPrizeQueue.ContainsKey(activityID))
                {
                    lock (sPrizeQueue)
                    {
                        if (!sPrizeQueue.ContainsKey(activityID))
                        {
                            var activity = sActivities[activityID];
                            var prizes = sPrize[activityID].Values.ToArray();
                            Stack queue = null;
                            if (prizes.Length > 0)
                            {
                                #region 生成中奖队列

                                var records = sRecords[activityID];
                                int participantNumber = activity.ParticipantNumber - records.Count();//剩余参与人数

                                Dictionary<int, int> dicPrizeIndex = new Dictionary<int, int>();

                                List<int> orderList = new List<int>(participantNumber);
                                for (int i = 0; i < participantNumber; i++)
                                {
                                    orderList.Add(i);
                                    dicPrizeIndex.Add(i, 0);
                                }

                                Random r = new Random(DateTime.Now.Millisecond);
                                foreach (var prize in prizes)
                                {
                                    int prizeCount = prize.Quota - records.Sum(arg => arg.Value.Count(rec => rec.PrizeID == prize.ID));//剩余奖品数量

                                    if (prizeCount < 1)
                                    {
                                        continue;
                                    }

                                    if (orderList.Count > prizeCount)//一个奖品对应一个人以上
                                    {
                                        int participantNumberPerPrize = (int)(orderList.Count * 1.0 / prizeCount);//一个奖品对应参与人数

                                        if (participantNumberPerPrize > 1)//如果一个奖品对应2个人以上，需要将奖品均匀化，避免集中中奖导致最后没有奖品的情况
                                        {
                                            List<int> usedOrderList = new List<int>();
                                            for (int prizeIndex = 0; prizeIndex < prizeCount; prizeIndex++)
                                            {
                                                int newIndex = r.Next(0, participantNumberPerPrize - 1) + prizeIndex * participantNumberPerPrize;
                                                var order = orderList[newIndex];
                                                dicPrizeIndex[order] = prize.ID;
                                                usedOrderList.Add(newIndex);
                                            }
                                            foreach (var idx in usedOrderList.OrderByDescending(p => p))
                                            {
                                                orderList.RemoveAt(idx);
                                            }
                                        }
                                        else//一个奖品对应2个人以下，则随机分配奖品即可
                                        {
                                            for (int prizeIndex = 0; prizeIndex < prizeCount; prizeIndex++)
                                            {
                                                int newIndex = r.Next(0, orderList.Count);
                                                var order = orderList[newIndex];
                                                dicPrizeIndex[order] = prize.ID;
                                                orderList.RemoveAt(newIndex);
                                            }
                                        }
                                    }
                                    else//人人都有奖品
                                    {
                                        for (int i = 0; i < prizeCount; i++)
                                        {
                                            if (orderList.Count > 0)
                                            {
                                                var order = orderList[0];
                                                orderList.RemoveAt(0);
                                                dicPrizeIndex[order] = prize.ID;
                                            }
                                            else
                                            {
                                                dicPrizeIndex.Add(dicPrizeIndex.Count, prize.ID);
                                            }
                                        }
                                    }
                                }

                                queue = new Stack(dicPrizeIndex.Values.Reverse().ToArray());

                                #endregion
                            }
                            else
                            {
                                queue = new Stack();
                            }

                            sPrizeQueue.Add(activityID, queue);
                        }
                    }
                }
            }
        }
    }


    public enum LotteryCodeDefine
    {
        [System.ComponentModel.Description("成功抢到红包")]
        Succeed = 0,
        [System.ComponentModel.Description("活动不存在")]
        ActivityNotExists,
        [System.ComponentModel.Description("活动还未开始")]
        NotBegin,
        [System.ComponentModel.Description("活动已经结束")]
        HasEnd,
        [System.ComponentModel.Description("已经参加过活动")]
        HasRecord,
    }
}