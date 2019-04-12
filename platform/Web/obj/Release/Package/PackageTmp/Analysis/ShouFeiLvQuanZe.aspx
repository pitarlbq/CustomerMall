<%@ Page Title="" Language="C#" MasterPageFile="~/Master/NavContent4.Master" AutoEventWireup="true" CodeBehind="ShouFeiLvQuanZe.aspx.cs" Inherits="Web.Analysis.ShouFeiLvQuanZe" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        var CompanyID;
        $(function () {
            CompanyID = "<%=Web.WebUtil.GetCompanyID(this.Context)%>";
        })
    </script>
    <script src="../js/Page/Analysis/ShouFeiLvQuanZe.js?t=<%=base.getToken() %>"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <div id="layout" class="easyui-layout" fit="true">
        <div data-options="region:'north',split:false,hideCollapsedContent:false," title="" style="height: 50px; padding: 5px 10px;">
            <label>
                日期:
                    <input class="easyui-datebox" id="tdStartTime" />
                -
                    <input class="easyui-datebox" id="tdEndTime" />
            </label>
            <label>
                收费项目:   
                        <input class="easyui-combobox" id="tbChargeSummary" style="width: 150px; height: 25px;" />
            </label>
            <label>
                <a href="#" onclick="SearchFee()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-search'">搜索</a>
            </label>
            <label>
                <input type="radio" name="tabletype" value="Project" checked="checked" />项目汇总
            </label>
        </div>
        <div data-options="region:'center'" title="">
            <table id="fee_table"></table>
        </div>
    </div>
</asp:Content>
