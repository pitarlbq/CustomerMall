
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Security;
using WeiXin.Domain;
using System.IO;
using System.Xml;
using WeiXin.Util;
using WeiXin.Request;
using WeiXin.Response;
using Utility;

namespace WeiXin
{
    /// <summary>
    /// 消息处理类
    /// </summary>
    public class MessageHandler
    {
        #region 校验消息真实性

        /// <summary>
        /// 校验消息真实性
        /// </summary>
        /// <param name="token">用户在公众平台填写的token</param>
        /// <returns></returns>
        public static bool CheckSignature(string token)
        {

            string signature = System.Web.HttpContext.Current.Request.QueryString["signature"] == null ? "" : System.Web.HttpContext.Current.Request.QueryString["signature"].Trim();
            string timestamp = System.Web.HttpContext.Current.Request.QueryString["timestamp"] == null ? "" : System.Web.HttpContext.Current.Request.QueryString["timestamp"].Trim();
            string nonce = System.Web.HttpContext.Current.Request.QueryString["nonce"] == null ? "" : System.Web.HttpContext.Current.Request.QueryString["nonce"].Trim();

            string[] arrTmp = { token, timestamp, nonce };
            Array.Sort(arrTmp);
            string tmpStr = string.Join("", arrTmp);
            tmpStr = FormsAuthentication.HashPasswordForStoringInConfigFile(tmpStr, "SHA1");//对该字符串进行sha1加密
            tmpStr = tmpStr.ToLower();//对字符串中的字母部分进行小写转换，非字母字符不作处理
            Utility.LogHelper.WriteInfo("签名", tmpStr);
            return tmpStr == signature; //开发者获得加密后的字符串可与signature对比

        }
        #endregion

        #region 第一次接入时验证

        /// <summary>
        /// 第一次接入时验证
        /// </summary>
        /// <param name="token">用户在公众平台填写的token</param>
        public static void Valid(string token)
        {
            string echoStr = System.Web.HttpContext.Current.Request.QueryString["echostr"];
            if (CheckSignature(token))
            {
                if (!string.IsNullOrEmpty(echoStr))
                {
                    System.Web.HttpContext.Current.Response.Write(echoStr);
                }
            }
        }
        #endregion

        #region 将公众平台POST过来的数据转化成实体对象

        /// <summary>
        /// 将公众平台POST过来的数据转化成实体对象
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public static ReceiveMessageBase ConvertMsgToObject(string token)
        {
            //if (!CheckSignature(token))
            //{
            //    return null;
            //}
            try
            {
                string msgBody = string.Empty;
                Stream s = System.Web.HttpContext.Current.Request.InputStream;
                byte[] b = new byte[s.Length];
                s.Read(b, 0, (int)s.Length);
                msgBody = Encoding.UTF8.GetString(b);
                //Utility.LogHelper.WriteDebug("Foresight.Winxin_消息内容", msgBody);
                if (WebUtils.IsNullOrWhiteSpace(msgBody))
                {
                    return null;
                }
                XmlDocument doc = null;
                MsgType msgType = MsgType.UnKnown;
                EventType eventType = EventType.UnKnown;
                ReceiveMessageBase msg = new ReceiveMessageBase();
                msg.MsgType = msgType;
                msg.MessageBody = msgBody;
                XmlNode node = null;
                XmlNode tmpNode = null;
                try
                {
                    doc = new XmlDocument();
                    doc.LoadXml(msgBody);//读取XML字符串
                    XmlElement rootElement = doc.DocumentElement;
                    XmlNode msgTypeNode = rootElement.SelectSingleNode("MsgType");//获取字符串中的消息类型
                    node = rootElement.SelectSingleNode("FromUserName");
                    if (node != null)
                    {
                        msg.FromUserName = node.InnerText;
                    }
                    node = rootElement.SelectSingleNode("ToUserName");
                    if (node != null)
                    {
                        msg.ToUserName = node.InnerText;
                    }
                    node = rootElement.SelectSingleNode("CreateTime");
                    if (node != null)
                    {
                        msg.CreateTime = Convert.ToInt64(node.InnerText);
                    }
                    #region 获取具体的消息对象
                    string strMsgType = msgTypeNode.InnerText;
                    string msgId = string.Empty;
                    string content = string.Empty;
                    tmpNode = rootElement.SelectSingleNode("MsgId");
                    if (tmpNode != null)
                    {
                        msgId = tmpNode.InnerText.Trim();
                    }
                    switch (strMsgType)
                    {
                        case "text":
                            msgType = MsgType.Text;

                            tmpNode = rootElement.SelectSingleNode("Content");
                            if (tmpNode != null)
                            {
                                content = tmpNode.InnerText.Trim();
                            }
                            TextReceiveMessage txtMsg = new TextReceiveMessage()
                            {
                                CreateTime = msg.CreateTime,
                                FromUserName = msg.FromUserName,
                                MessageBody = msg.MessageBody,
                                MsgType = msgType,
                                ToUserName = msg.ToUserName,
                                MsgId = Convert.ToInt64(msgId),
                                Content = content
                            };

                            return txtMsg;
                        case "image":
                            msgType = MsgType.Image;

                            ImageReceiveMessage imgMsg = new ImageReceiveMessage()
                            {
                                CreateTime = msg.CreateTime,
                                FromUserName = msg.FromUserName,
                                MessageBody = msg.MessageBody,
                                MsgId = Convert.ToInt64(msgId),
                                MsgType = msgType,
                                ToUserName = msg.ToUserName,
                                MediaId = rootElement.SelectSingleNode("MediaId").InnerText,
                                PicUrl = rootElement.SelectSingleNode("PicUrl").InnerText
                            };

                            return imgMsg;
                        case "voice":
                            msgType = MsgType.Voice;
                            XmlNode node1 = rootElement.SelectSingleNode("Recognition");
                            if (node1 != null)
                            {
                                msgType = MsgType.VoiceResult;
                            }

                            VoiceReceiveMessage voiceMsg = new VoiceReceiveMessage()
                            {
                                CreateTime = msg.CreateTime,
                                FromUserName = msg.FromUserName,
                                ToUserName = msg.ToUserName,
                                MessageBody = msg.MessageBody,
                                MsgId = Convert.ToInt64(msgId),
                                MsgType = msgType,
                                Recognition = node1 == null ? string.Empty : node1.InnerText.Trim(),
                                Format = rootElement.SelectSingleNode("Format").InnerText,
                                MediaId = rootElement.SelectSingleNode("MediaId").InnerText
                            };

                            return voiceMsg;

                        case "video":
                            msgType = MsgType.Video;

                            VideoReceiveMessage videoMsg = new VideoReceiveMessage()
                            {
                                CreateTime = msg.CreateTime,
                                FromUserName = msg.FromUserName,
                                MediaId = rootElement.SelectSingleNode("MediaId").InnerText,
                                MessageBody = msg.MessageBody,
                                MsgId = Convert.ToInt64(msgId),
                                MsgType = msgType,
                                ToUserName = msg.ToUserName,
                                ThumbMediaId = rootElement.SelectSingleNode("ThumbMediaId").InnerText
                            };

                            return videoMsg;
                        case "location":
                            msgType = MsgType.Location;

                            LocationReceiveMessage locationMsg = new LocationReceiveMessage()
                            {
                                CreateTime = msg.CreateTime,
                                FromUserName = msg.FromUserName,
                                MessageBody = msg.MessageBody,
                                MsgId = Convert.ToInt64(msgId),
                                MsgType = msgType,
                                ToUserName = msg.ToUserName,
                                Label = rootElement.SelectSingleNode("Label").InnerText,
                                Location_X = rootElement.SelectSingleNode("Location_X").InnerText,
                                Location_Y = rootElement.SelectSingleNode("Location_Y ").InnerText,
                                Scale = rootElement.SelectSingleNode("Scale").InnerText
                            };

                            return locationMsg;
                        case "link":
                            msgType = MsgType.Link;

                            LinkReceiveMessage linkMsg = new LinkReceiveMessage()
                            {
                                CreateTime = msg.CreateTime,
                                Description = rootElement.SelectSingleNode("Description").InnerText,
                                FromUserName = msg.FromUserName,
                                MessageBody = msg.MessageBody,
                                MsgId = Convert.ToInt64(msgId),
                                MsgType = msgType,
                                Title = rootElement.SelectSingleNode("Title").InnerText,
                                ToUserName = msg.ToUserName,
                                Url = rootElement.SelectSingleNode("Url ").InnerText
                            };

                            return linkMsg;
                        case "event":
                            msgType = MsgType.Event;
                            eventType = EventType.UnKnown;
                            msg.MsgType = msgType;

                            XmlNode eventNode = rootElement.SelectSingleNode("Event");
                            if (eventNode != null)
                            {
                                switch (eventNode.InnerText.ToLower())
                                {
                                    case "subscribe":
                                        {
                                            eventType = EventType.Subscribe;
                                            var node_EventKey = rootElement.SelectSingleNode("EventKey");
                                            var node_Ticket = rootElement.SelectSingleNode("Ticket");
                                            //普通关注事件
                                            SubscribeEventMessage subEvt = new SubscribeEventMessage()
                                            {
                                                CreateTime = msg.CreateTime,
                                                EventType = EventType.Subscribe,
                                                FromUserName = msg.FromUserName,
                                                MessageBody = msg.MessageBody,
                                                MsgType = msgType,
                                                ToUserName = msg.ToUserName,
                                                EventKey = (node_EventKey != null && !string.IsNullOrEmpty(node_EventKey.InnerText) && node_EventKey.InnerText.StartsWith("qrscene_")) ? node_EventKey.InnerText : null,
                                                Ticket = (node_Ticket != null && !string.IsNullOrEmpty(node_Ticket.InnerText) && node_Ticket.InnerText.StartsWith("qrscene_")) ? node_Ticket.InnerText : null,
                                            };
                                            return subEvt;
                                        }
                                    case "unsubscribe":
                                        {
                                            eventType = EventType.UnSubscribe;

                                            UnSubscribeEventMessage unSubEvt = new UnSubscribeEventMessage()
                                            {
                                                CreateTime = msg.CreateTime,
                                                EventType = eventType,
                                                FromUserName = msg.FromUserName,
                                                MessageBody = msg.MessageBody,
                                                MsgType = msgType,
                                                ToUserName = msg.ToUserName
                                            };

                                            return unSubEvt;
                                        }
                                    case "scan":
                                        {
                                            eventType = EventType.Scan;
                                            var node_Ticket = rootElement.SelectSingleNode("Ticket");

                                            ScanEventMessage scanEvt = new ScanEventMessage()
                                            {
                                                CreateTime = msg.CreateTime,
                                                EventKey = rootElement.SelectSingleNode("EventKey").InnerText,
                                                EventType = eventType,
                                                FromUserName = msg.FromUserName,
                                                MessageBody = msg.MessageBody,
                                                MsgType = msgType,
                                                Ticket = (node_Ticket != null && !string.IsNullOrEmpty(node_Ticket.InnerText) && node_Ticket.InnerText.StartsWith("qrscene_")) ? node_Ticket.InnerText : null,
                                                ToUserName = msg.ToUserName
                                            };
                                            return scanEvt;
                                        }
                                    case "location":
                                        {
                                            eventType = EventType.Location;

                                            UploadLocationEventMessage locationEvt = new UploadLocationEventMessage()
                                            {
                                                CreateTime = msg.CreateTime,
                                                EventType = eventType,
                                                FromUserName = msg.FromUserName,
                                                Latitude = rootElement.SelectSingleNode("Latitude").InnerText,
                                                Longitude = rootElement.SelectSingleNode("Longitude").InnerText,
                                                MessageBody = msg.MessageBody,
                                                MsgType = msgType,
                                                Precision = rootElement.SelectSingleNode("Precision").InnerText,
                                                ToUserName = msg.ToUserName
                                            };

                                            return locationEvt;
                                        }
                                    case "click":
                                        {
                                            eventType = EventType.Click;

                                            MenuEventMessage menuEvt = new MenuEventMessage()
                                            {
                                                CreateTime = msg.CreateTime,
                                                EventKey = rootElement.SelectSingleNode("EventKey").InnerText,
                                                EventType = eventType,
                                                FromUserName = msg.FromUserName,
                                                MessageBody = msg.MessageBody,
                                                MsgType = msgType,
                                                ToUserName = msg.ToUserName
                                            };

                                            return menuEvt;
                                        }
                                    case "wificonnected":
                                        {
                                            eventType = EventType.WifiConnected;

                                            WifiConnectedEventMessage menuEvt = new WifiConnectedEventMessage()
                                            {
                                                CreateTime = msg.CreateTime,
                                                EventType = eventType,
                                                FromUserName = msg.FromUserName,
                                                MessageBody = msg.MessageBody,
                                                MsgType = msgType,
                                                ToUserName = msg.ToUserName,
                                                ConnectTime = Convert.ToInt32(rootElement.SelectSingleNode("ConnectTime").InnerText),
                                                ExpireTime = Convert.ToInt32(rootElement.SelectSingleNode("ExpireTime").InnerText),
                                                VendorId = rootElement.SelectSingleNode("VendorId").InnerText,
                                                ShopId = rootElement.SelectSingleNode("ShopId").InnerText,
                                                DeviceNo = rootElement.SelectSingleNode("DeviceNo").InnerText,
                                            };

                                            return menuEvt;
                                        }
                                    default:
                                        {
                                            EventMessage evtMsg = new EventMessage()
                                            {
                                                CreateTime = msg.CreateTime,
                                                EventType = EventType.UnKnown,
                                                FromUserName = msg.FromUserName,
                                                MessageBody = msg.MessageBody,
                                                MsgType = MsgType.Event,
                                                ToUserName = msg.ToUserName
                                            };
                                            return evtMsg;
                                        }
                                }
                            }

                            break;
                    }
                    msg.MsgType = msgType;
                    #endregion
                }
                finally
                {
                    if (doc != null)
                    {
                        doc = null;
                    }
                }
                msg.MsgType = msgType;
                return msg;
            }
            catch (Exception ex)
            {
                Utility.LogHelper.WriteError("Foresight.Winxin", "转化消息出错", ex);
                return null;
            }
        }
        #endregion

        #region 发送被动响应消息

        /// <summary>
        /// 发送被动响应消息(根据传递的参数是对应不同的子类发送不同的子类消息)
        /// </summary>
        /// <param name="msg">发送的消息内容</param>
        public static void SendReplyMessage(ReplyMessage msg)
        {
            System.Web.HttpContext.Current.Response.Write(msg.ToXmlString());
        }

        /// <summary>
        /// 发送被动响应消息
        /// </summary>
        /// <param name="xmlString">发送的消息内容</param>
        public static void SendReplyMessage(string xmlString)
        {
            Utility.LogHelper.WriteDebug("SendReplyMessage", xmlString);
            System.Web.HttpContext.Current.Response.Write(xmlString);
        }

        /// <summary>
        /// 发送被动响应文本消息
        /// </summary>
        /// <param name="fromUserName">发送方</param>
        /// <param name="toUserName">接收方</param>
        /// <param name="content">文本内容</param>
        public static void SendTextReplyMessage(string fromUserName, string toUserName, string content)
        {
            TextReplyMessage msg = new TextReplyMessage()
            {
                CreateTime = WeiXin.Util.Tools.ConvertDateTimeInt(DateTime.Now),
                FromUserName = fromUserName,
                ToUserName = toUserName,
                Content = content
            };
            System.Web.HttpContext.Current.Response.Write(msg.ToXmlString());

        }

        /// <summary>
        /// 发送被动响应图片信息，图片上传失败，则返回失败
        /// </summary>
        /// <param name="accessToken">调用接口凭证</param>
        /// <param name="fromUserName">发送方</param>
        /// <param name="toUserName">接收方</param>
        /// <param name="imgPath">图片绝对路径(最大128K，目前只支持jpg格式)</param>
        /// <returns>是否成功</returns>
        public static bool SendImageReplyMessage(string accessToken, string fromUserName, string toUserName, string imgPath)
        {
            IMpClient mpClient = new MpClient();
            UploadMediaRequest request = new UploadMediaRequest()
            {
                AccessToken = accessToken,
                Type = "image",
                FileName = imgPath
            };

            UploadMediaResponse response = mpClient.Execute(request);
            if (response.IsError)
            {
                return false;
            }
            else
            {
                ImageReplyMessage msg = new ImageReplyMessage()
                {
                    CreateTime = WeiXin.Util.Tools.ConvertDateTimeInt(DateTime.Now),
                    FromUserName = fromUserName,
                    ToUserName = toUserName,
                    MediaId = response.MediaId
                };
                System.Web.HttpContext.Current.Response.Write(msg.ToXmlString());
                return true;
            }
        }

        /// <summary>
        /// 发送被动响应语音消息
        /// </summary>
        /// <param name="accessToken">调用接口凭证</param>
        /// <param name="fromUserName">发送方</param>
        /// <param name="toUserName">接收方</param>
        /// <param name="voicePath">语音文件路径(支持AMR\MP3,最大256K，播放长度不超过60s)</param>
        /// <returns>是否成功</returns>
        public static bool SendVoiceReplyMessage(string accessToken, string fromUserName, string toUserName, string voicePath)
        {
            IMpClient mpClient = new MpClient();
            UploadMediaRequest request = new UploadMediaRequest()
            {
                AccessToken = accessToken,
                Type = "voice",
                FileName = voicePath
            };

            UploadMediaResponse response = mpClient.Execute(request);
            if (response.IsError)
            {
                return false;
            }
            else
            {
                VoiceReplyMessage msg = new VoiceReplyMessage()
                {
                    CreateTime = WeiXin.Util.Tools.ConvertDateTimeInt(DateTime.Now),
                    FromUserName = fromUserName,
                    ToUserName = toUserName,
                    MediaId = response.MediaId
                };
                System.Web.HttpContext.Current.Response.Write(msg.ToXmlString());
                return true;
            }
        }

        /// <summary>
        /// 发送被动响应视频消息
        /// </summary>
        /// <param name="accessToken">调用接口凭证</param>
        /// <param name="fromUserName">发送方</param>
        /// <param name="toUserName">接收方</param>
        /// <param name="title">标题</param>
        /// <param name="description">描述</param>
        /// <param name="videoPath">视频文件路径(1MB，支持MP4格式)</param>
        /// <returns>是否成功</returns>
        public static bool SendVideoReplyMessage(string accessToken, string fromUserName, string toUserName, string title, string description, string videoPath)
        {
            IMpClient mpClient = new MpClient();
            UploadMediaRequest request = new UploadMediaRequest()
            {
                AccessToken = accessToken,
                Type = "video",
                FileName = videoPath
            };

            UploadMediaResponse response = mpClient.Execute(request);
            if (response.IsError)
            {
                return false;
            }
            else
            {
                VideoReplyMessage msg = new VideoReplyMessage()
                {
                    CreateTime = WeiXin.Util.Tools.ConvertDateTimeInt(DateTime.Now),
                    FromUserName = fromUserName,
                    ToUserName = toUserName,
                    MediaId = response.MediaId,
                    Description = description,
                    Title = title
                };
                System.Web.HttpContext.Current.Response.Write(msg.ToXmlString());
                return true;
            }
        }

        /// <summary>
        /// 发送被动响应音乐消息
        /// </summary>
        /// <param name="accessToken">调用接口凭证</param>
        /// <param name="fromUserName">发送方</param>
        /// <param name="toUserName">接收方</param>
        /// <param name="title">标题</param>
        /// <param name="description">描述</param>
        /// <param name="musicUrl">音乐链接</param>
        /// <param name="hqMusicUrl">高质量音乐链接</param>
        /// <param name="thumbMediaFilePath">缩略图文件路径(64KB，支持JPG格式 )</param>
        /// <returns>是否成功</returns>
        public static bool SendMusicReplyMessage(string accessToken, string fromUserName, string toUserName, string title, string description, string musicUrl, string hqMusicUrl, string thumbMediaFilePath)
        {
            IMpClient mpClient = new MpClient();
            UploadMediaRequest request = new UploadMediaRequest()
            {
                AccessToken = accessToken,
                Type = "thumb",
                FileName = thumbMediaFilePath
            };

            UploadMediaResponse response = mpClient.Execute(request);
            if (response.IsError)
            {
                return false;
            }
            else
            {
                MusicReplyMessage msg = new MusicReplyMessage()
                {
                    CreateTime = WeiXin.Util.Tools.ConvertDateTimeInt(DateTime.Now),
                    FromUserName = fromUserName,
                    ToUserName = toUserName,
                    Description = description,
                    Title = title,
                    ThumbMediaId = response.MediaId,
                    HQMusicUrl = hqMusicUrl,
                    MusicURL = musicUrl
                };
                System.Web.HttpContext.Current.Response.Write(msg.ToXmlString());
                return true;
            }
        }

        public static void SendEmptyReply()
        {
            Utility.LogHelper.WriteDebug("SendEmptyReply", "success");
            System.Web.HttpContext.Current.Response.Write("success");
        }

        #endregion

        #region 发送客服信息

        /// <summary>
        /// 发送客服信息
        /// </summary>
        /// <param name="accessToken">调用凭据</param>
        /// <param name="msg">客服消息</param>
        /// <returns></returns>
        public static SendCustomMessageResponse SendCustomMessage(string accessToken, CustomMessage msg)
        {
            return SendCustomMessage(accessToken, msg.ToJsonString());
        }
        public static SendCustomMessageResponse SendCustomMessage(string accessToken, string sendData)
        {
            IMpClient mpClient = new MpClient();
            SendCustomMessageRequest request = new SendCustomMessageRequest()
            {
                AccessToken = accessToken,
                SendData = sendData
            };
            SendCustomMessageResponse response = mpClient.Execute(request);
            if (response.IsError)
            {
                Utility.LogHelper.WriteDebug("发送客服消息", sendData);
                Utility.LogHelper.WriteDebug("客服消息响应", response.Body);
            }
            return response;
        }
        /// <summary>
        /// 删除客服帐号
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="kf_account"></param>
        /// <param name="nickname"></param>
        /// <returns></returns>
        public static CustomerServiceRemoveAccountResponse RemoveCustomerServiceAccount(string accessToken, string kf_account)
        {
            CustomerServiceAccountRemove msg = new CustomerServiceAccountRemove()
            {
                AccessToken = accessToken,
                kf_account = kf_account
            };
            IMpClient mpClient = new MpClient();
            string sendData = msg.ToJsonString();
            CustomerServiceRemoveAccountRequest request = new CustomerServiceRemoveAccountRequest()
            {
                AccessToken = accessToken,
                kf_account = kf_account,
                SendData = sendData
            };
            CustomerServiceRemoveAccountResponse response = mpClient.Execute(request);
            if (response.IsError)
            {
                Utility.LogHelper.WriteDebug("删除客服", sendData);
                Utility.LogHelper.WriteDebug("删除客服", response.Body);
            }
            return response;
        }
        /// <summary>
        /// 更新客服信息
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="kf_account"></param>
        /// <param name="nickname"></param>
        /// <returns></returns>
        public static CustomerServiceEditAccountResponse UpdateCustomerServiceAccount(string accessToken, string kf_account, string nickname)
        {
            CustomerServiceAccount msg = new CustomerServiceAccount()
            {
                AccessToken = accessToken,
                kf_account = kf_account,
                nickname = nickname
            };
            IMpClient mpClient = new MpClient();
            string sendData = msg.ToJsonString();
            CustomerServiceEditAccountRequest request = new CustomerServiceEditAccountRequest()
            {
                AccessToken = accessToken,
                SendData = sendData
            };
            CustomerServiceEditAccountResponse response = mpClient.Execute(request);
            if (response.IsError)
            {
                Utility.LogHelper.WriteDebug("更新客服", sendData);
                Utility.LogHelper.WriteDebug("更新客服", response.Body);
            }
            return response;
        }
        /// <summary>
        /// 邀请绑定客服帐号
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="kf_account"></param>
        /// <param name="invite_wx"></param>
        /// <returns></returns>
        public static CustomerServiceInviteResponse InviteCustomerService(string accessToken, string kf_account, string invite_wx)
        {
            CustomerServiceInvite msg = new CustomerServiceInvite()
            {
                AccessToken = accessToken,
                kf_account = kf_account,
                invite_wx = invite_wx
            };
            IMpClient mpClient = new MpClient();
            string sendData = msg.ToJsonString();
            CustomerServiceInviteRequest request = new CustomerServiceInviteRequest()
            {
                AccessToken = accessToken,
                SendData = sendData
            };
            CustomerServiceInviteResponse response = mpClient.Execute(request);
            if (response.IsError)
            {
                Utility.LogHelper.WriteDebug("邀请绑定客服帐号", sendData);
                Utility.LogHelper.WriteDebug("邀请绑定客服帐号", response.Body);
            }
            return response;
        }
        /// <summary>
        /// 添加客服帐号
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="kf_account"></param>
        /// <param name="nickname"></param>
        /// <returns></returns>
        public static CustomerServiceCreateAccountResponse CreateCustomerServiceAccount(string accessToken, string kf_account, string nickname)
        {
            CustomerServiceAccount msg = new CustomerServiceAccount()
            {
                AccessToken = accessToken,
                kf_account = kf_account,
                nickname = nickname
            };
            IMpClient mpClient = new MpClient();
            string sendData = msg.ToJsonString();
            CustomerServiceCreateAccountRequest request = new CustomerServiceCreateAccountRequest()
            {
                AccessToken = accessToken,
                SendData = sendData
            };
            CustomerServiceCreateAccountResponse response = mpClient.Execute(request);
            if (response.IsError)
            {
                Utility.LogHelper.WriteDebug("创建客服", sendData);
                Utility.LogHelper.WriteDebug("创建客服", response.Body);
            }
            return response;
        }
        /// <summary>
        /// 创建会话
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="kf_account"></param>
        /// <param name="openid"></param>
        /// <returns></returns>
        public static CustomerServiceCreateResponse CreateCustomerService(string accessToken, string kf_account, string openid)
        {
            CustomerServiceCreate msg = new CustomerServiceCreate()
            {
                AccessToken = accessToken,
                kf_account = kf_account,
                openid = openid
            };
            IMpClient mpClient = new MpClient();
            string sendData = msg.ToJsonString();
            CustomerServiceCreateRequest request = new CustomerServiceCreateRequest()
            {
                AccessToken = accessToken,
                SendData = sendData
            };
            CustomerServiceCreateResponse response = mpClient.Execute(request);
            if (response.IsError)
            {
                Utility.LogHelper.WriteDebug("创建会话", sendData);
                Utility.LogHelper.WriteDebug("创建会话", response.Body);
            }
            return response;
        }

        /// <summary>
        /// 发送文本客服信息
        /// </summary>
        /// <param name="accessToken">调用凭据</param>
        /// <param name="toUser">接收方</param>
        /// <param name="content">信息内容</param>
        /// <returns></returns>
        public static SendCustomMessageResponse SendTextCustomMessage(string accessToken, string toUser, string content)
        {
            TextCustomMessage msg = new TextCustomMessage()
            {
                AccessToken = accessToken,
                ToUser = toUser,
                Content = content,
                MsgType = "text"
            };
            return SendCustomMessage(accessToken, msg);
        }

        /// <summary>
        /// 发送图片客服消息
        /// </summary>
        /// <param name="accessToken">调用凭据</param>
        /// <param name="toUser">接收方</param>
        /// <param name="imgPath">图片路径</param>
        /// <returns></returns>
        public static SendCustomMessageResponse SendImageCustomMessage(string accessToken, string toUser, string imgPath)
        {
            IMpClient mpClient = new MpClient();
            UploadMediaRequest request = new UploadMediaRequest()
            {
                AccessToken = accessToken,
                Type = "image",
                FileName = imgPath
            };

            UploadMediaResponse response = mpClient.Execute(request);
            if (response.IsError)
            {
                SendCustomMessageResponse response2 = new SendCustomMessageResponse()
                {
                    Body = response.Body,
                    ErrInfo = response.ErrInfo,
                    ReqUrl = response.ReqUrl
                };
                return response2;
            }
            ImageCustomMessage msg = new ImageCustomMessage()
            {
                AccessToken = accessToken,
                MediaId = response.MediaId,
                MsgType = "image",
                ToUser = toUser
            };
            return SendCustomMessage(accessToken, msg);
        }

        /// <summary>
        /// 发送语音客服信息
        /// </summary>
        /// <param name="accessToken">调用凭据</param>
        /// <param name="toUser">接收方</param>
        /// <param name="voicePath">语音文件路径</param>
        /// <returns></returns>
        public static SendCustomMessageResponse SendVoiceCustomMessage(string accessToken, string toUser, string voicePath)
        {
            IMpClient mpClient = new MpClient();
            UploadMediaRequest request = new UploadMediaRequest()
            {
                AccessToken = accessToken,
                Type = "voice",
                FileName = voicePath
            };

            UploadMediaResponse response = mpClient.Execute(request);
            if (response.IsError)
            {
                SendCustomMessageResponse response2 = new SendCustomMessageResponse()
                {
                    Body = response.Body,
                    ErrInfo = response.ErrInfo,
                    ReqUrl = response.ReqUrl
                };
                return response2;
            }
            VoiceCustomMessage msg = new VoiceCustomMessage()
            {
                AccessToken = accessToken,
                MediaId = response.MediaId,
                MsgType = "voice",
                ToUser = toUser
            };
            return SendCustomMessage(accessToken, msg);
        }

        /// <summary>
        /// 发送视频客服信息
        /// </summary>
        /// <param name="accessToken">调用凭据</param>
        /// <param name="toUser">接收方</param>
        /// <param name="title">视频标题</param>
        /// <param name="description">视频描述</param>
        /// <param name="videoPath">视频文件路径</param>
        /// <returns></returns>
        public static SendCustomMessageResponse SendVideoCustomMessage(string accessToken, string toUser, string title, string description, string videoPath)
        {
            IMpClient mpClient = new MpClient();
            UploadMediaRequest request = new UploadMediaRequest()
            {
                AccessToken = accessToken,
                Type = "video",
                FileName = videoPath
            };

            UploadMediaResponse response = mpClient.Execute(request);
            if (response.IsError)
            {
                SendCustomMessageResponse response2 = new SendCustomMessageResponse()
                {
                    Body = response.Body,
                    ErrInfo = response.ErrInfo,
                    ReqUrl = response.ReqUrl
                };
                return response2;
            }
            VideoCustomMessage msg = new VideoCustomMessage()
            {
                AccessToken = accessToken,
                MediaId = response.MediaId,
                MsgType = "video",
                ToUser = toUser,
                Description = description,
                Title = title
            };
            return SendCustomMessage(accessToken, msg);
        }

        /// <summary>
        /// 发送音乐客服信息
        /// </summary>
        /// <param name="accessToken">调用凭据</param>
        /// <param name="toUser">接收方</param>
        /// <param name="title">音乐标题</param>
        /// <param name="description">音乐描述</param>
        /// <param name="musicUrl">音乐地址</param>
        /// <param name="hqMusicUrl">高质量音乐地址</param>
        /// <param name="thumbMediaFilePath">音乐缩略图路径</param>
        /// <returns></returns>
        public static SendCustomMessageResponse SendMusicCustomMessage(string accessToken, string toUser, string title, string description, string musicUrl, string hqMusicUrl, string thumbMediaFilePath)
        {
            IMpClient mpClient = new MpClient();
            UploadMediaRequest request = new UploadMediaRequest()
            {
                AccessToken = accessToken,
                Type = "thumb",
                FileName = thumbMediaFilePath
            };

            UploadMediaResponse response = mpClient.Execute(request);
            if (response.IsError)
            {
                SendCustomMessageResponse response2 = new SendCustomMessageResponse()
                {
                    Body = response.Body,
                    ErrInfo = response.ErrInfo,
                    ReqUrl = response.ReqUrl
                };
                return response2;
            }
            MusicCustomMessage msg = new MusicCustomMessage()
            {
                AccessToken = accessToken,
                ThumbMediaId = response.MediaId,
                HqMusicUrl = hqMusicUrl,
                MusicUrl = musicUrl,
                MsgType = "music",
                ToUser = toUser,
                Description = description,
                Title = title
            };
            return SendCustomMessage(accessToken, msg);
        }

        /// <summary>
        /// 发送图文客服消息
        /// </summary>
        /// <param name="accessToken">调用凭据</param>
        /// <param name="msg">消息</param>
        /// <returns></returns>
        public static SendCustomMessageResponse SendNewsCustomMessage(string accessToken, NewsCustomMessage msg)
        {
            msg.AccessToken = accessToken;
            return SendCustomMessage(accessToken, msg);
        }

        #endregion

        #region 模板消息相关

        /// <summary>
        /// 设置所属行业
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static TemPlateMessageResponse SetIndustry(string accessToken, SetIndustry msg)
        {
            IMpClient mpClient = new MpClient();
            Request.TemPlateMessage request = new Request.TemPlateMessage()
            {
                Method = "POST",
                AccessToken = accessToken,
                ReqUrl = "https://api.weixin.qq.com/cgi-bin/template/api_set_industry?access_token={0}",
                SendData = msg.ToJsonString()
            };
            TemPlateMessageResponse response = mpClient.Execute(request);
            if (response.IsError)
            {
                Utility.LogHelper.WriteDebug("模板消息设置所属行业", request.SendData);
                Utility.LogHelper.WriteDebug("模板消息设置所属行业响应", response.Body);
            }
            return response;
        }

        /// <summary>
        /// 获取设置的行业信息
        /// </summary>
        /// <param name="accessToken"></param>
        /// <returns></returns>
        public static GetIndustryInfo GetIndustryInfo(string accessToken)
        {
            IMpClient mpClient = new MpClient();
            Request.TemPlateMessage request = new Request.TemPlateMessage()
            {
                Method = "GET",
                AccessToken = accessToken,
                ReqUrl = "https://api.weixin.qq.com/cgi-bin/template/get_industry?access_token={0}",
            };
            TemPlateMessageResponse response = mpClient.Execute(request);
            if (response.IsError)
            {
                Utility.LogHelper.WriteDebug("获取设置的行业信息响应", response.Body);
            }
            return response.IndustryInfo;
        }
        /// <summary>
        /// 获取模板ID
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static TemPlateMessageResponse GetTemplateId(string accessToken, GetTemPlateID msg)
        {
            IMpClient mpClient = new MpClient();
            Request.TemPlateMessage request = new Request.TemPlateMessage()
            {
                Method = "POST",
                AccessToken = accessToken,
                ReqUrl = "https://api.weixin.qq.com/cgi-bin/template/api_add_template?access_token={0}",
                SendData = msg.ToJsonString()
            };
            TemPlateMessageResponse response = mpClient.Execute(request);
            if (response.IsError)
            {
                Utility.LogHelper.WriteDebug("获取模板ID", request.SendData);
                LogHelper.WriteDebug("获取模板ID响应", response.Body);
            }
            return response;
        }

        /// <summary>
        /// 获取模板列表
        /// </summary>
        /// <param name="accessToken"></param>
        /// <returns></returns>
        public static GetTemplateInfo GetTemplateInfo(string accessToken)
        {
            IMpClient mpClient = new MpClient();
            Request.TemPlateMessage request = new Request.TemPlateMessage()
            {
                Method = "GET",
                AccessToken = accessToken,
                ReqUrl = "https://api.weixin.qq.com/cgi-bin/template/get_all_private_template?access_token={0}",
            };
            TemPlateMessageResponse response = mpClient.Execute(request);
            if (response.IsError)
            {
                Utility.LogHelper.WriteDebug("获取模板列表响应", response.Body);
            }
            return response.TemplateInfo;
        }
        /// <summary>
        /// 删除模板
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static TemPlateMessageResponse DeleteTemPlate(string accessToken, DeleteTemPlate msg)
        {
            IMpClient mpClient = new MpClient();
            Request.TemPlateMessage request = new Request.TemPlateMessage()
            {
                Method = "POST",
                AccessToken = accessToken,
                ReqUrl = "https://api.weixin.qq.com/cgi-bin/template/del_private_template?access_token={0}",
                SendData = msg.ToJsonString()
            };
            TemPlateMessageResponse response = mpClient.Execute(request);
            if (response.IsError)
            {
                Utility.LogHelper.WriteDebug("删除模板", request.SendData);
                Utility.LogHelper.WriteDebug("删除模板响应", response.Body);
            }
            return response;
        }
        /// <summary>
        /// 发送模板消息
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static TemPlateMessageResponse SendTemPlateMessageOperate(string accessToken, SendTemPlateMessage msg)
        {
            IMpClient mpClient = new MpClient();
            Request.TemPlateMessage request = new Request.TemPlateMessage()
            {
                Method = "POST",
                AccessToken = accessToken,
                ReqUrl = "https://api.weixin.qq.com/cgi-bin/message/template/send?access_token={0}",
                SendData = msg.ToJsonString()
            };
            //LogHelper.WriteInfo("template_msg: ", msg.ToJsonString());
            TemPlateMessageResponse response = mpClient.Execute(request);
            if (response.IsError)
            {
                LogHelper.WriteDebug("发送模板消息响应", response.Body);
            }
            return response;
        }
        /// <summary>
        /// 发送模板消息
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="touser"></param>
        /// <param name="configParm"></param>
        /// <param name="contentList"></param>
        /// <param name="url"></param>
        /// <returns></returns>
        public static TemPlateMessageResponse SendTemPlateMessage(string accessToken, string touser, string template_id, List<TemPlateMessageItem> msgitemlist, string url)
        {
            SendTemPlateMessage msg = new SendTemPlateMessage
            {
                data = msgitemlist,
                template_id = template_id,
                touser = touser,
                url = url
            };
            return SendTemPlateMessageOperate(accessToken, msg);
        }
        #endregion

        #region 素材相关消息
        public static string UploadImage(string accessToken, string imgPath)
        {
            UploadImgResponse response = UploadImg(accessToken, imgPath);
            Utility.LogHelper.WriteInfo("上传图片：", response.Body.ToString());
            if (response.IsError)
            {
                return string.Empty;
            }
            return response.media_id;
        }
        public static UploadImgResponse UploadImg(string accessToken, string imgPath)
        {
            IMpClient mpClient = new MpClient();
            UploadImgRequest request = new UploadImgRequest()
            {
                AccessToken = accessToken,
                FileName = imgPath,
                Type = "image"
            };
            UploadImgResponse response = mpClient.Execute(request);
            return response;
        }
        #endregion
    } // class end
}
