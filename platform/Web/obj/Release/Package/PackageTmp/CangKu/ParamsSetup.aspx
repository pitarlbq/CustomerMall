<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="ParamsSetup.aspx.cs" Inherits="Web.CangKu.ParamsSetup" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>基础设置</title>
    <link href="../styles/page/initialdefault.css?t=<%=base.getToken() %>" rel="stylesheet" />
    <style>
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
                    <div class="ModuleBox sfsz">
                        <%#Eval("Title") %>
                    </div>
                    <div class="ModuleDesc">
                    </div>
                </a>
            </ItemTemplate>
        </asp:Repeater>
        <div style="clear: both;"></div>
    </div>
</asp:Content>
