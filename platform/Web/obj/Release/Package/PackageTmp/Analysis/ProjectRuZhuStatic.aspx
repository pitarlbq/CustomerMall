<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="ProjectRuZhuStatic.aspx.cs" Inherits="Web.Analysis.ProjectRuZhuStatic" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>任务统计</title>
    <script src="../js/Page/Analysis/ProjectRuZhuStatic.js?v=<%=base.getToken() %>" type="text/javascript"></script>
    <style>
        .tdsearch label {
            margin-right: 10px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <form runat="server">
        <div class="easyui-layout" fit="true">
            <div data-options="region:'center'" title="">
                <table id="tt_table">
                </table>
            </div>
        </div>
    </form>
</asp:Content>
