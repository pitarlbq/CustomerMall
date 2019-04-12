<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="RealCostAnalysisDetails.aspx.cs" Inherits="Web.Analysis.RealCostAnalysisDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        var CompanyID, hdIDs, tdStartTime, tdEndTime, tdChargeMan, tdChargeSummary, hdChargeSummary, tdChargeType, hdChargeType, tdCategory, hdCategory, hdChargeStatus, hdChargeMan, hdRoomIDs, hdProjectIDs;
        $(function () {
            CompanyID = "<%=Web.WebUtil.GetCompanyID(this.Context)%>";
            hdIDs = $("#<%=this.hdIDs.ClientID%>");
            tdStartTime = $('#<%=this.tdStartTime.ClientID%>');
            tdEndTime = $('#<%=this.tdEndTime.ClientID%>');
            tdChargeMan = $('#<%=this.tdChargeMan.ClientID%>');
            hdChargeMan = $('#<%=this.hdChargeMan.ClientID%>');
            tdChargeSummary = $('#<%=this.tdChargeSummary.ClientID%>');
            hdChargeSummary = $('#<%=this.hdChargeSummary.ClientID%>');
            tdChargeType = $('#<%=this.tdChargeType.ClientID%>');
            hdChargeType = $('#<%=this.hdChargeType.ClientID%>');
            tdCategory = $('#<%=this.tdCategory.ClientID%>');
            hdCategory = $('#<%=this.hdCategory.ClientID%>');
            tdChargeStatus = $('#<%=this.tdChargeStatus.ClientID%>');
            hdChargeStatus = $('#<%=this.hdChargeStatus.ClientID%>');
            hdRoomIDs = $('#<%=this.hdRoomIDs.ClientID%>');
            hdProjectIDs = $('#<%=this.hdProjectIDs.ClientID%>');
        })
    </script>
    <script src="../js/Page/Analysis/RealCostAnalysisDetails.js?t=<%=base.getToken() %>"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <form runat="server">
        <div id="layout" class="easyui-layout" fit="true">
            <div data-options="region:'north',split:false,hideCollapsedContent:false," title="" style="height: 80px; padding: 5px 10px;">
                <label>
                    收款时间:
                    <input class="easyui-datebox" runat="server" id="tdStartTime" style="width: 120px;" />
                    -                
                    <input class="easyui-datebox" id="tdEndTime" runat="server" style="width: 120px;" />
                </label>
                <label>
                    收款人:               
                    <input class="easyui-combobox" runat="server" id="tdChargeMan" style="width: 120px;" />
                    <asp:HiddenField runat="server" ID="hdProjectIDs" />
                    <asp:HiddenField runat="server" ID="hdRoomIDs" />
                    <asp:HiddenField runat="server" ID="hdChargeMan" />
                </label>
                <label>
                    收费项目:               
                    <input class="easyui-combobox" runat="server" id="tdChargeSummary" style="width: 120px;" />
                    <asp:HiddenField runat="server" ID="hdChargeSummary" />
                </label>
                <label>
                    收款方式:               
                    <input class="easyui-combobox" runat="server" id="tdChargeType" style="width: 120px;" />
                    <asp:HiddenField runat="server" ID="hdChargeType" />
                </label>
                <label>
                    费项分类:               
                    <input class="easyui-combobox" runat="server" id="tdCategory" style="width: 120px;" />
                    <asp:HiddenField runat="server" ID="hdCategory" />
                </label>
                <label>
                    单据类型:
                    <select class="easyui-combobox" runat="server" id="tdChargeStatus" style="width: 120px;">
                        <option value="1">收费单据</option>
                        <option value="3">付款单据</option>
                        <option value="4">冲抵单据</option>
                        <option value="2">作废单据</option>
                    </select>
                    <asp:HiddenField runat="server" ID="hdChargeStatus" Value="[1]" />
                </label>
                <label>
                    付款方式:
                    <select class="easyui-combobox" id="tdPayOnLineStatus" style="width: 120px;" data-options="editable:false">
                        <option value="">全部</option>
                        <option value="1">线下付款</option>
                        <option value="2">在线付款</option>
                    </select>
                </label>
                <label class="searchlabel" style="margin-left: 10px;">
                    <a href="#" onclick="SearchHis()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-search'">搜索</a>
                </label>
            </div>
            <div data-options="region:'center'" title="">
                <table id="his_table">
                </table>
                <div id="tb">
                    <a href="#" onclick="do_export()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-export'">导出</a>
                    <asp:HiddenField ID="hdIDs" runat="server" />
                    <a href="#" onclick="openTableSetUp()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-setting'">配置</a>
                </div>
            </div>
        </div>
    </form>
</asp:Content>
