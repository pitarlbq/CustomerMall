<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="MinLogin.aspx.cs" Inherits="Web.MinLogin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="styles/page/login.css?v3" rel="stylesheet" />
    <style type="text/css">
        body, html, form, .wrapper {
            height: auto;
            float: none;
        }

        .wrapper {
            min-height: 0;
        }

        .inputbox {
            background-color: #fff;
            height: 42px;
            line-height: 42px;
            width: 80%;
            margin: 0 10%;
            vertical-align: middle;
            border: solid 1px #9EB2C3;
            border-radius: 3px;
            font-size: 14px;
            margin: 0 auto;
        }

            .inputbox label {
                float: left;
                font-family: "Helvetica Neue",Helvetica,sans-serif;
                height: 42px;
                width: 50px;
            }

            .inputbox input {
                background-image: none;
                float: left;
                margin: 0 1%;
                padding: 0;
                width: 98%;
                height: 40px;
                line-height: 40px;
            }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <form id="form1" runat="server">
        <div class="wrapper">
            <div class="inputbox" style="margin-top: 50px;">
                <asp:TextBox ID="tbLoginName" placeholder="支持邮箱手机号登录" runat="server" Style="border: none;"></asp:TextBox>
            </div>
            <div class="inputbox" style="margin-top: 10px;">
                <asp:TextBox ID="tbPassword" placeholder="密码" TextMode="Password" runat="server" Style="border: none;"></asp:TextBox>
            </div>
            <div style="text-align: center; margin-top: 15px;">
                <asp:Button CssClass="btnlogin" Text="登&nbsp;录" ID="btnLogin" runat="server" OnClientClick="return check();"
                    OnClick="btnLogin_Click" />
            </div>
            <div style="margin: 0 auto; text-align: center; padding: 10px 30px 0 30px;">
                <asp:Label ID="lbMsg" runat="server" CssClass="err"></asp:Label>
            </div>
        </div>
    </form>
    <script type="text/javascript">
        document.getElementById('<%= this.tbLoginName.ClientID%>').focus();
    </script>
</asp:Content>

