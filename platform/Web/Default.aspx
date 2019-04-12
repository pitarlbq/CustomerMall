<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Web.Default" Async="true" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title><%= Web.WebUtil.GetCompany(this.Context).CompanyName %></title>
    <link href="styles/buttons.css" rel="stylesheet" />
    <link href="js/easyui/gray/easyui.css" type="text/css" rel="stylesheet" />
    <link href="js/easyui/icon.css" type="text/css" rel="stylesheet" />
    <script src="js/jquery-1.8.3.min.js"></script>
    <script src="js/vue.js"></script>
    <script>
        var socketserverurl, loginname, guid, url, disableEditRow = false;
        $(function () {
            socketserverurl = "<%=this.SocketURL %>";
            url = "<%=new Utility.SiteConfig().SITE_URL %>";
        })
    </script>
    <script src="js/socket/loginclient.js?t=<%=base.getToken() %>"></script>
    <script src="js/easyui/jquery.easyui.min.js" type="text/javascript"></script>
    <script src="js/easyui/easyui-lang-zh_CN.js" type="text/javascript"></script>
    <script src="http://<%=this.SocketURL %>/socket.io/socket.io.js"></script>
    <script src="js/Page/Main/Comm.js?t=<%=base.getToken() %>"></script>
    <script src="js/Page/Main/Main.js?t=2_<%=base.getToken() %>"></script>
    <script src="js/Page/Comm/MaskUtil.js?t=<%=getToken() %>"></script>
    <link href="../js/ztree/zTreeStyle/zTreeStyle.css?v1" rel="stylesheet" />
    <script src="../js/ztree/jquery.ztree.core.js"></script>
    <script src="../js/ztree/jquery.ztree.excheck.js"></script>
    <script src="../js/ztree/jquery.ztree.exedit.js"></script>
    <script src="js/Page/Main/zTreeLoad.js?t=<%=base.getToken() %>"></script>
    <script src="js/Page/Main/yyui.js?t=<%=base.getToken() %>"></script>
    <script>
        var HasWechatServiceAuth = 0, LogoPath;
        $(function () {
            getlogo();
            HasWechatServiceAuth = Number("<%=this.HasWechatServiceAuth%>");
            LogoPath = "<%=this.LogoPath%>";
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
                        else {
                            if (message.Home_LogoImg != '') {
                                $('.pageheader .headertitle .logo').css('background-image', 'url("' + message.Home_LogoImg + '")')
                            } else {
                                $('.pageheader .headertitle .logo').css('background-image', 'url("' + LogoPath + '")')
                            }
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
        .pageheader {
            position: absolute;
            left: 0;
            top: 0;
            right: 0;
            background-color: #233d64;
            height: 40px;
        }

            .pageheader .headertitle {
                width: 160px;
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
                background-size: auto 40px;
                background-repeat: no-repeat;
                background-position: left center;
                height: 40px;
                width: 160px;
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
            background-size: 25px 25px;
            float: left;
            height: 100%;
            overflow: visible;
            width: 25px;
            cursor: pointer;
        }

        a.customer_service {
            background-position: 0 10px;
            background-repeat: no-repeat;
            background-size: 18px 18px;
            float: left;
            height: 40px;
            overflow: visible;
            cursor: pointer;
            line-height: 40px;
            color: #fff;
        }

            a.customer_service:hover {
                color: #fff;
            }

        .notifymsg {
            background-image: url("styles/images/buttons/sysnotify_new.png");
        }

        .viewmanual {
            background-image: url("styles/images/buttons/manual_new.png");
            background-size: 20px 20px;
            width: 20px;
        }

        .warningbar {
            background-image: url("styles/images/buttons/warning_icon_new.png");
        }

        .wechatservicecss {
            background-image: url("styles/images/buttons/wechat_service_new.png");
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
            padding: 10px 10px 0px 0px;
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
            border: solid 1px #ddd;
            border-radius: 5px !important;
            min-width: 100px;
            padding: 5px;
            top: 40px;
            display: none;
            position: absolute;
            background-color: #fff;
        }

            .dropdown-menu ul {
                list-style: outside none none;
                margin: 0px;
                padding: 0px;
            }

                .dropdown-menu ul li a:hover {
                    background-color: #f0f0f0;
                }

                .dropdown-menu ul li a {
                    text-decoration: none;
                    color: #000;
                    line-height: 25px;
                    height: 25px;
                    display: block;
                    padding: 0 5px;
                    font-size: 14px;
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
                right: 0px;
                top: 0px;
            }

            .notify_point.expiring_point {
                font-size: 10px;
                right: 0px;
                top: 0px;
                display: block;
            }

        .pop_count {
            color: #ff0000;
            margin: 0 5px;
            font-size: 14px;
        }

        .view_more {
            color: #2f80d1;
        }

        .topHeader {
            position: absolute;
            top: 0;
            right: 0;
            left: 0;
            height: 40px;
            background: #233d64;
        }

        .open {
            position: relative;
        }

        .userCenter.open .dropdown-menu {
            width: 100px;
            display: block;
            left: -10px;
        }

        .timerBox.open .dropdown-menu {
            width: 260px;
            display: block;
            left: -124px;
        }

        .leftBox {
            position: absolute;
            top: 40px;
            left: 0;
            width: 200px;
            bottom: 0;
            border-right: solid 1px #ddd;
        }

        .menuLeft, .treeLeft {
            position: absolute;
            top: 40px;
            left: 0;
            width: 200px;
            bottom: 0;
        }

        .menuTitle {
            position: absolute;
            top: 0px;
            left: 0;
            bottom: 0;
            width: 200px;
            height: 38px;
            border: solid 1px #ddd;
            border-right: 0px;
            z-index: 9999;
        }

            .menuTitle label {
                display: inline-block;
                line-height: 38px;
                width: 97px;
                color: #000;
                text-align: center;
                font-size: 14px;
                cursor: pointer;
            }

                .menuTitle label.active {
                    background-color: #ddd;
                }

        .rightBox {
            position: absolute;
            top: 40px;
            left: 201px;
            bottom: 0;
            right: 0;
        }

        .topMenuBox {
            position: absolute;
            top: 5px;
            left: 201px;
            width: 60%;
            height: 35px;
        }

            .topMenuBox label {
                display: inline-block;
                line-height: 35px;
                color: #fff;
                padding: 0 20px;
                font-size: 14px;
            }

                .topMenuBox label.active {
                    background-color: #fff;
                    color: #000;
                    border-top-left-radius: 5px;
                    border-top-right-radius: 5px;
                }
    </style>
    <script>
        var totalLiCount = 0, hideLiCount = 0, pageLiCount = 10;
        $(function () {
            var self;
            $('.topMenuBox label').bind('click', function () {
                var elems = $('.topMenuBox label');
                $.each(elems, function (index, self) {
                    $(self).removeClass('active');
                })
                $(this).addClass('active');
                var group = $(this).attr('data-group');
                vueMenu.get_my_menus(group);
            })
            $('.menuTitle label').bind('click', function () {
                var elems = $('.menuTitle label');
                $.each(elems, function (index, self) {
                    $(self).removeClass('active');
                })
                $(this).addClass('active');
                var id = $(this).attr('data-id');
                if (id == 0) {
                    $('.menuLeft').show();
                    $('.treeLeft').hide();
                } else {
                    $('.menuLeft').hide();
                    $('.treeLeft').show();
                    loadTree();
                }
            })
            $('.bottomPre').bind('click', function () {
                if (hideLiCount == 0) {
                    return;
                }
                getPageLiCount();
                hideLiCount = 0;
                autoScroll(".yyui_menuBox", pageLiCount, 'reduce');
            })
            $('.bottomNext').bind('click', function () {
                getPageLiCount();
                var restCount = totalLiCount - hideLiCount;
                if (restCount <= pageLiCount) {
                    return;
                }
                if (restCount > pageLiCount) {
                    hideLiCount += pageLiCount;
                    autoScroll(".yyui_menuBox", hideLiCount, 'plus');
                }
            })
        })
        function getPageLiCount() {
            var leftHeight = $('.menuLeft').height();
            pageLiCount = parseInt(leftHeight / 50);
            if (pageLiCount > 0) {
                pageLiCount--;
            }
            if (pageLiCount <= 0) {
                pageLiCount = 0;
            }
        }
        function openTreeContent(cancelExChange) {
            if (!cancelExChange) {
                var elems = $('.menuTitle label');
                $.each(elems, function (index, self) {
                    $(self).removeClass('active');
                })
                $('label#treeLabel').addClass('active');
                $('.menuLeft').hide();
                $('.treeLeft').show();
            }
            loadTree();
        }
        function autoScroll(obj, count, type) {
            var n = 0;
            if (type == 'plus') {
                n = -50;
            }
            $(obj).find("ul.yyui_menu1").animate({
                marginTop: n * count
            }, 500)
        }
    </script>
    <style>
        .ztree li {
            padding: 5px 0 0 0;
            /*background:url("../js/ztree/zTreeStyle/img/line_conn.gif") repeat-y scroll 0 0*/
        }

            .ztree li > input {
                margin: 0;
            }

        .ztree input[type=radio] {
            width: 15px;
            height: 15px;
        }
    </style>
    <script>
</script>
    <style type="text/css">
        .yyui_menu1 {
            font-size: 15px;
            background-color: #f2f2f2;
            width: 200px;
        }

        ul, li {
            margin: 0;
            padding: 0;
        }

        .yyui_menu1 li {
            float: left;
            position: relative;
            width: 200px;
            list-style-type: none;
        }
            /*这一级是导航*/
            .yyui_menu1 li a {
                display: block;
                line-height: 50px;
                text-decoration: none;
                color: #333333;
                text-align: left;
                width: 170px;
                padding-left: 30px;
                cursor: pointer;
            }

                .yyui_menu1 li a:hover {
                    background: #EFEFEF;
                }

                .yyui_menu1 li a.more:after {
                    content: " »";
                }

            .yyui_menu1 li ul {
                position: absolute;
                left: 200px;
                width: 200px;
                border: 1px solid #D2D2D2;
                display: none;
                background-color: #FFFfff;
                z-index: 9999;
            }
                /*这是第二级菜单*/
                .yyui_menu1 li ul a {
                    width: 170px;
                    text-decoration: none;
                    color: #333333;
                }

                    .yyui_menu1 li ul a:hover {
                        background: #f2f2f2;
                    }

                .yyui_menu1 li ul ul {
                    top: 0;
                    left: 200px;
                }

        .topMenuBox label {
            cursor: pointer;
        }

        .bottomPre {
            position: absolute;
            bottom: 0;
            left: 0;
            width: 99px;
            color: #000;
            background-color: #f0f0f0;
            line-height: 40px;
            text-align: center;
            border-right: solid 1px #fff;
            font-size: 13px;
        }

        .bottomNext {
            line-height: 40px;
            position: absolute;
            bottom: 0;
            left: 100px;
            width: 99px;
            color: #000;
            background-color: #f0f0f0;
            text-align: center;
            font-size: 13px;
        }
        /*从第三级菜单开始,所有的子级菜单都相对偏移*/
    </style>
</head>
<body>
    <div class="easyui-layout" data-options="fit:true,border:false">
        <div data-options="region:'center'" style="border: 0px; background: #fff;">
            <div class="topHeader">
                <div class="pageheader" style="position: absolute;">
                    <a class="headertitle" href="Default.aspx">
                        <div class="logo"></div>
                    </a>
                </div>
                <div class="topMenuBox">
                    <label class="active" data-group="wynk">智慧物业</label>
                    <label data-group="appgl">社区运营</label>
                </div>
                <div style="position: absolute; right: 20px; top: 0; z-index: 999;">
                    <div class="userCenter" id="user_center">
                        <span id="user_info">欢迎您 , <%=this.RealName %>!</span>
                        <div class="dropdown-menu">
                            <div class="arrows"></div>
                            <ul>
                                <li><a onclick="viewPersonal()" style="text-align: left;">个人中心</a></li>
                                <li><a href="Login.aspx?op=logout" id="ahover" target="_top" style="text-align: left;">退出</a></li>
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
                        <a id="notifymsg" href="#" title="系统通知" class="time notifymsg" style="margin-right: 10px;">
                            <div id="notify_img" class="notify_point"></div>
                        </a>
                    </div>
                    <div class="timerBox" id="btnwarning">
                        <a href="#" title="提醒事项" class="time warningbar" style="margin-right: 10px;">
                            <div id="warning_point" class="notify_point warning_point">0</div>
                        </a>
                        <div class="dropdown-menu">
                            <div class="arrows"></div>
                            <ul>
                                <li><a href="#" id="sub_shoufei" style="text-align: left;">租金收取提醒<span class="pop_count" id="shoufei_count">0</span>条 <span class="view_more">点击查看详情</span></a></li>
                                <li><a href="#" id="sub_daoqi" style="text-align: left;">合同到期提醒<span class="pop_count" id="daoqi_count">0</span>条 <span class="view_more">点击查看详情</span></a></li>
                                <li><a href="#" id="sub_baoxiu" style="text-align: left;">报事报修提醒<span class="pop_count" id="service_count">0</span>条 <span class="view_more">点击查看详情</span></a></li>
                            </ul>
                        </div>
                    </div>
                    <%if (this.HasWechatServiceAuth == 1)
                        { %>
                    <div class="timerBox">
                        <%--<a class="customer_service" href="https://mpkf.weixin.qq.com/" target="_blank">客服系统</a>--%>
                        <a href="https://mpkf.weixin.qq.com/" title="客服系统" target="_blank" class="time wechatservicecss" style="margin-right: 10px;"></a>
                    </div>
                    <%} %>
                </div>
            </div>
            <div class="leftBox">
                <div class="menuTitle">
                    <label class="active" data-id="0">菜单</label>
                    <label id="treeLabel" data-id="1">资源</label>
                </div>
                <div class="menuLeft">
                    <div style="height: 100%;" class="yyui_menuBox" id="menuVue">
                        <ul class="yyui_menu1">
                            <li v-for="item in menulist">
                                <a v-on:click="do_open_menu(item)">{{item.Title}}</a>
                                <ul class="one" v-if="item.Children.length>0">
                                    <li v-for="item2 in item.Children">
                                        <a v-on:click="do_open_menu(item2)">{{item2.Title}}</a>
                                        <ul class="two" v-if="item2.Children.length>0">
                                            <li v-for="item3 in item2.Children">
                                                <a v-on:click="do_open_menu(item3)">{{item3.Title}}</a>
                                            </li>
                                        </ul>
                                    </li>
                                </ul>
                            </li>
                        </ul>
                    </div>
                    <div class="bottomPre">第一页</div>
                    <div class="bottomNext">下一页</div>
                </div>
                <div class="treeLeft" style="display: none;">
                    <div class="easyui-panel" style="height: 50px; width: 200px; padding-top: 10px; border: 0px;">
                        <input id="searchbox" class="easyui-searchbox" data-options="prompt:'',searcher:doSearch" style="height: 30px; width: 150px;" />
                        <label id="labelALL" style="vertical-align: middle; margin: 0;">
                            <input type="checkbox" id="btnAll" style="height: 15px; width: 15px; vertical-align: middle; margin: 0;" />全选</label>
                    </div>
                    <div class="easyui-panel" style="height: 90%; width: 200px; border: 0px;">
                        <ul id="tt" class="ztree"></ul>
                    </div>
                </div>
            </div>
            <div class="rightBox">
                <div class="easyui-tabs" id="tabs" style="width: 100%; height: 99%; border: none;" data-options="tabHeight:40,border:5">
                </div>
            </div>
        </div>
    </div>
    <style>
        .tabs-header {
            background: #fff;
            border: 0px;
            padding: 0px;
        }

        .tabs li {
            margin: 0px;
            border-right: solid 1px #ddd;
        }

            .tabs li:last-child {
                border-right: 0px;
            }

            .tabs li a.tabs-inner {
                color: #000;
                background: #fff;
                padding: 0 20px;
                border-radius: 0px;
            }

            .tabs li a:hover.tabs-inner {
                background: #ddd;
                color: #000;
            }

            .tabs li.tabs-selected a.tabs-inner {
                border-bottom: 0;
                background: #ddd;
                color: #000;
                border-radius: 0px;
            }

        ul.tabs {
            border: 0;
            padding-left: 0px;
        }
    </style>
</body>
</html>

