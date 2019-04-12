<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="BasicSetup.aspx.cs" Inherits="Web.Device.BasicSetup" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>基础设置</title>
    <link href="../styles/page/initialdefault.css?t=<%=base.getToken() %>" rel="stylesheet" />
    <style>
        .gnsz {
            background: url(../styles/images/equparameter-bg.png) no-repeat center center;
            background-size: 80px 80px;
        }

        .sblx {
            background: url(../styles/images/equipMentType-bg.png) no-repeat center center;
            background-size: 80px 80px;
        }

        .sbfz {
            background: url(../styles/images/equprojects-bg.png) no-repeat center center;
            background-size: 80px 80px;
        }

        .ModuleBox {
            margin: 30px 50px 0px 50px;
        }

        .ModuleDesc {
            text-align: center;
            width: 150px;
            margin: 0 auto;
            margin-top: 150px;
        }

        a {
            float: left;
            border: solid 1px #ccc;
            margin: 5px;
            height: 220px;
        }

            a:hover {
                text-decoration: none;
            }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <div style="padding: 0 50px;">
        <asp:Repeater runat="server" ID="rptSummary">
            <ItemTemplate>
                <a href="#" onclick="top.addTab('<%#Eval("Title") %>', '<%#Eval("Url") %>', '')">
                    <div class="ModuleBox <%#Eval("CssClass") %>">
                        <%#Eval("Title") %>
                    </div>
                    <div class="ModuleDesc">
                        <%#Eval("Description") %>
                    </div>
                </a>
            </ItemTemplate>
        </asp:Repeater>
        <div style="clear: both;"></div>
    </div>
</asp:Content>
