<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="ChaoBiaoCostAnalysisSummary.aspx.cs" Inherits="Web.Analysis.ChaoBiaoCostAnalysisSummary" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>抄表台账汇总</title>
    <script>
        var FeeTypeObj, CompanyID, StartTimeObj, EndTimeObj;
        $(function () {
            FeeTypeObj = $("#<%=this.tbFeeType.ClientID%>");
            StartTimeObj = $("#<%=this.tdStartTime.ClientID%>");
            EndTimeObj = $("#<%=this.tdEndTime.ClientID%>");
            CompanyID = "<%=Web.WebUtil.GetCompanyID(this.Context)%>";
        });
    </script>
    <script src="../js/Page/Analysis/ChaoBiaoCostAnalysisSummary.js?v=<%=base.getToken() %>" type="text/javascript"></script>
    <style>
        .tdsearch label {
            margin-right: 10px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <form runat="server">
        <div class="easyui-layout" fit="true">
            <div data-options="region:'north'" style="height: 80px; padding: 10px;">
                <div class="tdsearch">
                    <label>
                        日期:                
                        <input class="easyui-datebox" id="tdStartTime" runat="server" style="width: 150px" />
                        -
                        <input class="easyui-datebox" id="tdEndTime" runat="server" style="width: 150px" />
                    </label>
                    <label>
                        收费项目:   
                        <input class="easyui-combobox" runat="server" id="tbFeeType" style="width: 150px; height: 25px;" />
                    </label>
                    <label style="margin-right: 10px; line-height: 25px;">
                        <input type="radio" name="tabletype" value="Room" />资源明细
                    </label>
                    <label style="margin-right: 10px;">
                        <input type="radio" name="tabletype" value="Project" checked="checked" />项目汇总
                    </label>
                    <label>
                        <a href="#" onclick="SearchFee()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-search'">搜索</a>
                    </label>
                </div>
            </div>
            <div data-options="region:'center'" title="">
                <table id="fee_table">
                </table>
            </div>
        </div>
    </form>
</asp:Content>

