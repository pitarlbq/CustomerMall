<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="PreChargeAnalysisSummary.aspx.cs" Inherits="Web.Analysis.PreChargeAnalysisSummary" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        var CompanyID, tdStartTime, tdEndTime, tdDepositStatus, tdChargeSummary, hdRoomIDs, hdProjectIDs, hdRoomType, hdChargeSummary;
        $(function () {
            CompanyID = "<%=Web.WebUtil.GetCompanyID(this.Context)%>";
            tdStartTime = $('#<%=this.tdStartTime.ClientID%>');
            tdEndTime = $('#<%=this.tdEndTime.ClientID%>');
            tdChargeSummary = $('#<%=this.tdChargeSummary.ClientID%>');
            hdRoomIDs = $('#<%=this.hdRoomIDs.ClientID%>');
            hdProjectIDs = $('#<%=this.hdProjectIDs.ClientID%>');
            hdRoomType = $('#<%=this.hdRoomType.ClientID%>');
            hdChargeSummary = $('#<%=this.hdChargeSummary.ClientID%>');
        })
    </script>
    <script src="../js/Page/Analysis/PreChargeAnalysisSummary.js?t=<%=base.getToken() %>"></script>
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
                    <input class="easyui-combobox" id="tdChargeSummary" style="width: 150px; height: 25px;" runat="server" />
                    <asp:HiddenField ID="hdChargeSummary" runat="server" />
                </label>
                <label class="searchlabel">
                    <a href="#" onclick="SearchFee()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-search'">搜索</a>
                </label>
                <label style="margin-right: 10px; line-height: 25px;">
                    <input type="radio" name="tabletype" value="Room" />资源明细
                </label>
                <label style="margin-right: 10px;">
                    <input type="radio" name="tabletype" value="Project" checked="checked" />项目汇总
                </label>
                <label>
                    <input type="radio" name="tabletype" value="ChargeSummary" />费项明细
                </label>
            </div>
            <div data-options="region:'center'" title="">
                <table id="fee_table">
                </table>
                <div id="tb">
                    <a href="#" onclick="do_export()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-export'">导出</a>
                    <asp:HiddenField runat="server" ID="hdRoomType" Value="Project" />
                    <asp:HiddenField ID="hdRoomIDs" runat="server" />
                    <asp:HiddenField ID="hdProjectIDs" runat="server" />
                </div>
            </div>
        </div>
    </form>
</asp:Content>
