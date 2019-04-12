<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="TotalCostAnalysisSummary.aspx.cs" Inherits="Web.Analysis.TotalCostAnalysisSummary" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        var CompanyID = "<%=Web.WebUtil.GetCompanyID(this.Context)%>";
        $(function () {
            $("#layout").layout("collapse", "north");
        })
    </script>
    <script src="../js/Page/Analysis/TotalCostAnalysisSummary.js?t=<%=base.getToken() %>"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <div id="layout" class="easyui-layout" fit="true">
        <div data-options="region:'north',split:false,hideCollapsedContent:false," title="" style="height: 50px; padding: 10px;">
            <label>
                收款时间:
                <input class="easyui-datebox" id="tdStartTime" />
                -
                <input class="easyui-datebox" id="tdEndTime" />
            </label>
            <label class="searchlabel">
                <a href="#" onclick="SearchFee()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-search'">搜索</a>
            </label>
        </div>
        <div data-options="region:'center'" title="">
            <div class="easyui-panel" title="按收费项目汇总" style="width: 100%; height: 99%;">
                <table id="fee_table">
                </table>
            </div>
        </div>
    </div>
</asp:Content>
