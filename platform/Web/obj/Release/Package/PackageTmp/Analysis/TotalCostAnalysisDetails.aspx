<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="TotalCostAnalysisDetails.aspx.cs" Inherits="Web.Analysis.TotalCostAnalysisDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        var CompanyID = "<%=Web.WebUtil.GetCompanyID(this.Context)%>";
        $(function () {
            //$("#layout").layout("collapse", "north");
        })
    </script>
    <script src="../js/Page/TotalCostAnalysisDetails.js?t=<%=base.getToken() %>"></script>
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
                <a href="#" onclick="SearchHis()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-search'">搜索</a>
            </label>
        </div>
        <div data-options="region:'center'" title="">
            <table id="his_table">
            </table>
        </div>
    </div>
</asp:Content>
