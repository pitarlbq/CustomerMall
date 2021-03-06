﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="SetupFee_YuShou.aspx.cs" Inherits="Web.SetupFee.SetupFee_YuShou" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../styles/main.css" rel="stylesheet" />
    <script type="text/javascript">
        var CompanyID = "<%=Web.WebUtil.GetCompanyID(this.Context)%>";
    </script>
    <script src="../js/Page/SetupFee/SetupFee_YuShou.js?v=<%=base.getToken() %>"></script>
    <style type="text/css">
        table.projecttable {
            width: 100%;
            border-collapse: separate;
            border-spacing: 20px;
        }

            table.projecttable td.yttd {
                text-align: center;
            }

        .ytmain {
            float: none;
            margin: 10px 0 0 0;
            width: 100%;
        }

        .ytbox {
            float: none;
            width: 100%;
            min-height: 0;
        }

            .ytbox .yttitle .summaryname {
                font-size: 13px;
                font-weight: bold;
            }

            .ytbox .yttitle input {
                margin: 0 5px;
            }

        select {
            width: 100px;
        }

        .StartFee, .EndFee {
            float: left;
            width: 200px;
            margin: 10px;
        }

        .clear {
            clear: both;
        }

        table.feetable {
            width: 100%;
            border: none;
            margin: 0 auto;
            border-collapse: collapse;
            border-spacing: 0px;
        }

            table.feetable td {
                border: solid 1px #ccc;
            }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <div>
        <a href="javascript:viewByRoom()" class="easyui-linkbutton opebox" iconcls="icon-search">查看房间收费标准</a>
    </div>
    <table class="projecttable" id="projecttable">
        <tr class="yttr">
        </tr>
    </table>
</asp:Content>
