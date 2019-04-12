<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Web.Login" EnableSessionState="True" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta name="renderer" content="webkit" />
    <title>
        <%= this.CompanyName %></title>
    <link href="styles/basic.css" rel="stylesheet" type="text/css" />
    <link href="styles/page/login.css?v12" rel="stylesheet" />

    <script src="js/jquery-1.8.3.min.js" type="text/javascript"></script>

    <script type="text/javascript">
        $(function () {
            $(".login_input input").focus(function () {
                $(".login_input .input_icon").css('background-image', 'url("styles/images/username_active_icon.png")');
                $(".inputbox.login_input").css('border', 'solid 1px #0081D1');
            });
            $(".pwd_input input").focus(function () {
                $(".pwd_input .input_icon").css('background-image', 'url("styles/images/pwd_active_icon.png")');
                $(".inputbox.pwd_input").css('border', 'solid 1px #0081D1');
            });
            $(".login_input input").blur(function () {
                $(".login_input .input_icon").css('background-image', 'url("styles/images/username_icon.png")');
                $(".inputbox.login_input").css('border', 'solid 1px #D4D4D4');
            });
            $(".pwd_input input").blur(function () {
                $(".pwd_input .input_icon").css('background-image', 'url("styles/images/pwd_icon.png")');
                $(".inputbox.pwd_input").css('border', 'solid 1px #D4D4D4');
            });
            var page_width = $(window).width();
            if (page_width > 1500) {
                $('.mainimg').css('background-size', '60% auto');
            }
            else {
                $('.mainimg').css('background-size', 'auto auto');
            }
            getlogo();
            var loginHomeLink = "<%=string.IsNullOrEmpty(ConfigurationManager.AppSettings["LoginHomeLink"])?"http://saasyy.com/":ConfigurationManager.AppSettings["LoginHomeLink"]%>";
            $('#home_a').attr('href', loginHomeLink);
        });
        function getlogo() {
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: 'Handler/UserHandler.ashx',
                data: { visit: 'getcompanyinfo' },
                success: function (message) {
                    if (message.status) {
                        if (message.IsHideLogin_LogImg) {
                            $('.logo').hide()
                        }
                        else if (message.Login_LogoImg != '') {
                            $('.logo').css('background-image', 'url("' + message.Login_LogoImg + '")')
                        }
                        if (message.IsHideLogin_BodyImg) {
                            $('.mainimg').hide()
                        }
                        else if (message.Login_BodyImg != '') {
                            $('.mainimg').css('background-image', 'url("' + message.Login_BodyImg + '")')
                        }
                        if (message.CompanyName != '') {
                            $('#tdCompanyName').html(message.CompanyName);
                        }
                        if (message.IsHideCopyRightText) {
                            $('.footer').hide()
                        }
                        else if (message.CopyRightText != '') {
                            $('.footer').html(message.CopyRightText);
                        }
                    }
                    else {
                        //show_message('系统异常', 'error');
                    }
                }
            });
        }
    </script>
    <style type="text/css">
        .top {
            width: 100%;
            height: 75px;
            background-color: #fff;
            margin: 0 auto;
            border-bottom: solid 1px #ccc;
            position: relative;
        }

        .logo {
            background-image: url("html/images/NewLogo.png");
            background-repeat: no-repeat;
            background-position-x: left;
            background-position-y: center;
            background-size: auto 55px;
            width: 40%;
            margin-left: 10%;
            display: block;
            height: 75px;
            margin-left: 5%;
        }

        .center {
            position: absolute;
            top: 75px;
            left: 0;
            right: 0;
            bottom: 40px;
        }

        .mainimg {
            position: absolute;
            width: 50%;
            background-image: url("styles/images/login_1.png?v1");
            background-repeat: no-repeat;
            background-position: right center;
            top: 0;
            bottom: 0;
            left: 0;
        }

        .loginbox {
            position: absolute;
            width: 40%;
            left: 60%;
            right: 0;
            top: 50%;
            bottom: 0;
            height: 400px;
            margin-top: -200px;
        }

        .footer {
            position: fixed;
            bottom: 0;
            line-height: 40px;
            text-align: center;
            color: #fff;
            clear: both;
            width: 100%;
            background-color: #2E7ECE;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="wrapper">
            <div class="top">
                <div class="logo"></div>
            </div>
            <div class="center">
                <div class="mainimg"></div>
                <div class="loginbox">
                    <div class="title">
                        <img src="styles/images/cloudsystem_bg.jpg" />
                    </div>
                    <div class="inputbox login_input">
                        <div class="input_icon"></div>
                        <asp:TextBox ID="tbLoginName" placeholder="支持邮箱手机号登录" runat="server" Style="border: none;"></asp:TextBox>
                    </div>
                    <div class="inputbox pwd_input">
                        <div class="input_icon"></div>
                        <asp:TextBox ID="tbPassword" placeholder="密码" TextMode="Password" runat="server" Style="border: none;"></asp:TextBox>
                    </div>
                    <div class="auto_login" style="">
                        <asp:CheckBox runat="server" ID="autoLogin" Text="下次自动登录" Style="font-size: 14px;" />
                    </div>
                    <div class="login_btn">
                        <asp:Button CssClass="btnlogin" Text="登&nbsp;录" ID="btnLogin" runat="server"
                            OnClick="btnLogin_Click" />
                    </div>
                    <div style="text-align: center; font-size: 12px; color: #888888; padding-top: 40px; width: 206px;">
                        授权信息:
                        <label id="tdCompanyName"></label>
                    </div>
                    <div style="text-align: left; padding: 10px 30px 0 30px;">
                        <asp:Label ID="lbMsg" runat="server" CssClass="err"></asp:Label>
                    </div>
                </div>
            </div>
            <%--<div class="footer">
                Copyright&copy;<%=DateTime.Now.Year %> 重庆永友网络有限公司,Inc.All Rights
            </div>--%>
        </div>
    </form>
    <script type="text/javascript">
        document.getElementById('<%= this.tbLoginName.ClientID%>').focus();
    </script>
</body>
</html>
