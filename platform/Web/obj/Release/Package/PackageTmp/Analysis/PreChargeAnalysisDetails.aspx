<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="PreChargeAnalysisDetails.aspx.cs" Inherits="Web.Analysis.PreChargeAnalysisDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        var CompanyID, tdStartTime, tdEndTime, tdChargeSummary, tdPreChargeStatus, hdIDs, hdRoomIDs, hdProjectIDs, hdChargeSummary;
        $(function () {
            CompanyID = "<%=Web.WebUtil.GetCompanyID(this.Context)%>";
            tdStartTime = $('#<%=this.tdStartTime.ClientID%>');
            tdEndTime = $('#<%=this.tdEndTime.ClientID%>');
            tdChargeSummary = $('#<%=this.tdChargeSummary.ClientID%>');
            tdPreChargeStatus = $('#<%=this.tdPreChargeStatus.ClientID%>');
            hdIDs = $('#<%=this.hdIDs.ClientID%>');
            hdRoomIDs = $('#<%=this.hdRoomIDs.ClientID%>');
            hdProjectIDs = $('#<%=this.hdProjectIDs.ClientID%>');
            hdChargeSummary = $('#<%=this.hdChargeSummary.ClientID%>');
        })
    </script>
    <script src="../js/Page/Analysis/PreChargeAnalysisDetails.js?t=<%=base.getToken() %>"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <form runat="server" id="ff">
        <div id="layout" class="easyui-layout" fit="true">
            <div data-options="region:'north',split:false,hideCollapsedContent:false," title="" style="height: 50px; padding: 5px 10px;">
                <label>
                    收款(冲抵)时间:
                <input class="easyui-datebox" id="tdStartTime" runat="server" />
                    -
                <input class="easyui-datebox" id="tdEndTime" runat="server" />
                </label>
                <label>
                    收费项目:    
                    <input class="easyui-combobox" runat="server" id="tdChargeSummary" style="width: 150px;" />
                    <asp:HiddenField ID="hdChargeSummary" runat="server" />
                </label>
                <label>
                    单据类型
                <select class="easyui-combobox" id="tdPreChargeStatus" runat="server">
                    <option value="0">全部</option>
                    <option value="1">收款单据</option>
                    <option value="2">冲抵单据</option>
                    <option value="3">退款单据</option>
                </select>
                </label>
                <label class="searchlabel">
                    <a href="#" onclick="SearchHis()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-search'">搜索</a>
                </label>
            </div>
            <div data-options="region:'center'" title="">
                <table id="his_table">
                </table>
                <div id="tb">
                    <a href="#" onclick="do_export()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-export'">导出</a>
                    <asp:HiddenField ID="hdIDs" runat="server" />
                    <asp:HiddenField runat="server" ID="hdProjectIDs" />
                    <asp:HiddenField runat="server" ID="hdRoomIDs" />
                </div>
            </div>
        </div>
    </form>
</asp:Content>
