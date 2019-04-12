<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewDefault.aspx.cs" Inherits="Web.NewDefault" Async="true" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title><%= Web.WebUtil.GetCompany(this.Context).CompanyName%></title>
    <link href="styles/Bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <link href="styles/Bootstrap/ace.css" rel="stylesheet" />
    <link href="styles/font-awesome/css/font-awesome.min.css" rel="stylesheet" />
    <link href="styles/buttons.css" rel="stylesheet" />
    <link href="js/easyui/gray/easyui.css" type="text/css" rel="stylesheet" />
    <link href="js/easyui/icon.css" type="text/css" rel="stylesheet" />
    <link href="styles/basic.css" rel="stylesheet" />
    <script src="js/jquery-1.8.3.min.js"></script>
    <script>
        var socketserverurl, loginname, guid, url;
        $(function () {
            socketserverurl = "<%=this.SocketURL%>";
            url = "<%=new Utility.SiteConfig().SITE_URL %>";
        })
    </script>
    <script src="js/socket/loginclient.js?t=<%=base.getToken()%>"></script>
    <script src="js/easyui/jquery.easyui.min.js" type="text/javascript"></script>
    <script src="js/easyui/easyui-lang-zh_CN.js" type="text/javascript"></script>
    <script src="http://<%=this.SocketURL%>/socket.io/socket.io.js"></script>
    <script src="js/Page/Main/Comm.js?t=<%=base.getToken()%>"></script>
    <script src="js/Page/Comm/unit.js?t=2_<%=base.getToken()%>"></script>
    <script src="js/Page/Main/Main.js?t=1_<%=base.getToken()%>"></script>
    <script>
        $(function () {
            getlogo();
            $('#btnmanual').bind("click", function () {
                window.open('http://admin.saasyy.com/manual/viewsysmanual.aspx');
            })
        })
        function getlogo() {
            var options = {};
            options.visit = "getcompanyinfo";
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: 'Handler/UserHandler.ashx',
                data: options,
                success: function (message) {
                    if (message.status) {
                        if (message.IsHideHome_LogoImg) {
                            $('.logo').hide()
                            $('.pageheader .headertitle .logo').hide();
                        }
                        else if (message.Home_LogoImg != '') {
                            $('.pageheader .headertitle .logo').css('background-image', 'url("' + message.Home_LogoImg + '")')
                        }
                        if (message.ExpiringShow) {
                            $('#servertime').show();
                            $('#servermsg').html(message.ExpiringMsg);
                            alertNotify(message.ExpiringMsg);
                        } else {
                            $('#servertime').hide();
                        }
                    }
                    else {
                        show_message('系统异常', 'error');
                    }
                }
            });
        }
    </script>
    <style>
        .panel-body {
            background: #fff;
        }

        .pageheader .headertitle {
            width: 100px;
            margin: 0;
            float: left;
        }

        .pageheader a {
            float: right;
            line-height: 40px;
            font-size: 25px;
            color: #fff;
            margin: 0 0 0 10px;
        }

        .pageheader .headertitle .logo {
            background-image: url("html/images/Logo_home.png");
            background-size: 141px 33px;
            background-repeat: no-repeat;
            width: 150px;
            height: 40px;
        }

        .tabs {
            border-color: #2f80d1;
        }

        .timerBox {
            float: right;
            height: 30px;
            overflow: visible;
            position: relative;
            margin-right: 10px;
        }

        .time {
            background-image: url("styles/images/buttons/head-time.png");
        }

        .time {
            background-position: 0 10px;
            background-repeat: no-repeat;
            background-size: 18px 18px;
            float: left;
            height: 100%;
            overflow: visible;
            width: 19px;
            cursor: pointer;
        }

        .notifymsg {
            background-image: url("styles/images/buttons/sysnotify.png");
        }

        .viewmanual {
            background-image: url("styles/images/buttons/manual.png");
        }

        .warningbar {
            background-image: url("styles/images/buttons/warning_icon.png");
        }

        .floatBox {
            background-color: #fff;
            border-radius: 8px;
            box-shadow: 3px 3px 18px #666;
            display: none;
            left: -92px;
            padding: 10px 0px;
            position: absolute;
            top: 45px;
            width: 205px;
            z-index: 1009;
        }

        div.arrows {
            border-bottom: 12px solid #fff;
            border-left: 6px solid transparent;
            border-right: 6px solid transparent;
            height: 0;
            left: 50%;
            margin-left: -6px;
            position: absolute;
            top: -12px;
            width: 0;
            z-index: 999;
        }

        .userCenter {
            float: right;
            height: 30px;
            overflow: visible;
            position: relative;
            padding: 8px 30px 0px 0px;
            cursor: pointer;
        }

            .userCenter span {
                font-size: 13px;
                color: #fff;
            }

        .fatable {
            font-size: 15px;
        }

        .dropdown-menu {
            border-radius: 4px !important;
            min-width: 150px;
            padding: 5px;
            top: 40px;
        }

            .dropdown-menu ul {
                list-style: outside none none;
                margin: 0px;
            }

                .dropdown-menu ul li a {
                    width: 100%;
                }

        .tabs-scroller-left {
            background: url(styles/images/buttons/leftarrow.png) no-repeat center center;
            background-size: 18px 18px;
            border: 0;
        }

        .tabs-scroller-right {
            background: url(styles/images/buttons/rightarrow.png) no-repeat center center;
            background-size: 18px 18px;
            border: 0;
        }

        .notify_point {
            min-width: 20px;
            position: absolute;
            top: 0px;
            right: 0px;
            background-color: #ff6a00;
            color: #fff;
            border-radius: 5px;
            font-family: 'Microsoft YaHei';
            padding-left: 0;
            display: none;
            text-align: center;
            font-size: 10px;
        }

            .notify_point.warning_point {
                font-size: 10px;
                right: 0px;
                top: 0px;
            }

        .pop_count {
            color: #ff0000;
            margin: 0 5px;
            font-size: 14px;
        }

        .view_more {
            color: #2f80d1;
        }

        .menubox {
            border: solid 1px #ccc;
            background-color: #808080;
            padding: 5px 10px;
            border-radius: 5px;
            margin-right: 10px;
            margin-top: 20px;
            color: #fff;
            cursor: pointer;
        }

            .menubox.active {
                background-color: #fff;
                color: #000;
            }

        .tabs-header {
            background-color: #2f80d1;
            border-color: #2f80d1;
            height: auto;
        }

        .tabs li a.tabs-inner {
            color: #fff;
        }
    </style>
</head>
<body class="easyui-layout" data-options="fit:true,border:false">
    <div data-options="region:'center',border:false" style="background: #2f80d1;">
        <div id="left_menu" style="position: fixed; left: 0; top: 50%; z-index: 999; margin-top: -150px;">
            <div data-id="wynk" class="menubox active">
                物业内控
            </div>
            <%if (this.show_appgl == 1)
              { %>
            <div data-id="appgl" class="menubox">
                APP管理
            </div>
            <%} %>
            <%if (this.show_jygl == 1)
              { %>
            <div data-id="jygl" class="menubox">
                交易管理
            </div>
            <%} %>
            <%if (this.show_jspt == 1)
              { %>
            <div data-id="jspt" class="menubox">
                结算平台
            </div>
            <%} %>
            <%if (this.show_sjzx == 1)
              { %>
            <div data-id="sjzx" class="menubox">
                数据中心
            </div>
            <%} %>
            <%if (this.show_xtsz == 1)
              { %>
            <div data-id="xtsz" class="menubox">
                系统设置
            </div>
            <%} %>
        </div>
        <div style="position: fixed; right: 20px; top: 0; z-index: 999;">
            <div class="userCenter" id="user_center">
                <span id="user_info">欢迎您 , <%=this.RealName%>!</span>
                <i class="fa fa-sort-desc white bigger fatable" style="" aria-hidden="true"></i>
                <div class="dropdown-menu">
                    <div class="arrows"></div>
                    <ul>
                        <li><a onclick="viewPersonal()" class="btn btn-toolbar btn-white myinfo" style="text-align: left;"><i class="ace-icon fa fa-user blue bigger"></i>个人中心</a></li>
                        <li><a href="Login.aspx?op=logout" id="ahover" target="_top" class="btn btn-toolbar btn-white myinfo" style="text-align: left;"><i class="ace-icon fa fa-sign-out blue bigger"></i>退出</a></li>
                    </ul>
                </div>
            </div>
            <div class="timerBox" id="servertime">
                <div id="time" class="time" style="margin-right: 10px;">
                    <div class="floatBox" id="timeFloat" style="display: none;">
                        <div class="arrows"></div>
                        <div><span class="btn btn-white" id="servermsg" style="white-space: pre-wrap;"></span></div>
                    </div>
                </div>
                <div class="notify_point expiring_point">1+</div>
            </div>
            <div class="timerBox">
                <div id="notifymsg" class="time notifymsg" style="margin-right: 10px;">
                    <div id="notify_img" class="notify_point"></div>
                </div>
            </div>
            <div class="timerBox">
                <div id="btnmanual" class="time viewmanual" style="margin-right: 10px;">
                </div>
            </div>
            <div class="timerBox" id="btnwarning">
                <div class="time warningbar" style="margin-right: 10px;">
                    <div id="warning_point" class="notify_point warning_point">0</div>
                </div>
                <div class="dropdown-menu" style="left: -120px; width: 260px;">
                    <div class="arrows"></div>
                    <ul>
                        <li><a href="#" id="sub_shoufei" class="btn btn-toolbar btn-white myinfo" style="text-align: left;">租金收取提醒<span class="pop_count" id="shoufei_count">0</span>条 <span class="view_more">点击查看详情</span></a></li>
                        <li><a href="#" id="sub_daoqi" class="btn btn-toolbar btn-white myinfo" style="text-align: left;">合同到期提醒<span class="pop_count" id="daoqi_count">0</span>条 <span class="view_more">点击查看详情</span></a></li>
                        <li><a href="#" id="sub_baoxiu" class="btn btn-toolbar btn-white myinfo" style="text-align: left;">报事报修提醒<span class="pop_count" id="service_count">0</span>条 <span class="view_more">点击查看详情</span></a></li>
                    </ul>
                </div>
            </div>
            <%--<a style="color: #fff;" onclick="viewPersonal()" class="btn btn-toolbar btn-white myinfo"><i class="ace-icon fa fa-user white bigger"></i><span style="color: #fff;">个人中心</span></a>
            <a href="Login.aspx?op=logout" id="ahover" target="_top" class="btn btn-toolbar btn-white myinfo"><i class="ace-icon fa fa-sign-out white bigger"></i><span style="color: #fff;">退出</span></a>--%>
        </div>
        <div class="pageheader" style="position: fixed; left: 10px; top: 0; z-index: 999; border: none;">
            <a class="headertitle" href="newdefault.aspx">
                <div class="logo"></div>
            </a>
        </div>
        <div id="tabs" class="easyui-tabs" data-options="fit:true,border:false" style="width: 100%; height: 100%; padding-top: 10px;">
        </div>
        <audio style="display: none;" id="message_ring" controls="controls" src="newmessage.mp3"></audio>
    </div>
    <!-- 鼠标右键菜单 -->
    <div id="mm" class="easyui-menu" style="width: 150px; display: none; margin-left: 5px;">
        <div id="mm-tabclose">
            关闭
        </div>
    </div>
</body>
</html>

