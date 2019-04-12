<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="ToChargeAnalysisSummary.aspx.cs" Inherits="Web.Analysis.ToChargeAnalysisSummary" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        var CompanyID, tdStartTime, tdEndTime, tdChargeSummary, hdRoomIDs, hdProjectIDs, hdChargeSummary;
        $(function () {
            //$("#layout").layout("collapse", "north");
            CompanyID = "<%=Web.WebUtil.GetCompanyID(this.Context)%>";
            tdStartTime = $("#<%=this.tdStartTime.ClientID%>");
            tdEndTime = $("#<%=this.tdEndTime.ClientID%>");
            tdChargeSummary = $("#<%=this.tdChargeSummary.ClientID%>");
            hdRoomIDs = $("#<%=this.hdRoomIDs.ClientID%>");
            hdProjectIDs = $("#<%=this.hdProjectIDs.ClientID%>");
            hdChargeSummary = $("#<%=this.hdChargeSummary.ClientID%>");
        })
    </script>
    <script src="../js/Page/Analysis/ToChargeAnalysisSummary.js?t=<%=base.getToken() %>"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <form runat="server" id="ff">
        <div id="layout" class="easyui-layout" fit="true">
            <div data-options="region:'north',split:false,hideCollapsedContent:false," title="" style="height: 50px; padding: 5px 10px;">
                <label>
                    时间:
                <input class="easyui-datebox" id="tdStartTime" runat="server" />
                    -
                <input class="easyui-datebox" id="tdEndTime" runat="server" />
                </label>
                <label>
                    收费项目:
                <input class="easyui-combobox" id="tdChargeSummary" runat="server" style="width: 150px;" />
                </label>
                <label class="searchlabel" style="margin-left: 10px;">
                    <a href="#" onclick="SearchFee()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-search'">搜索</a>
                </label>
            </div>
            <div data-options="region:'center'" title="">
                <div class="easyui-panel" title="按收费项目汇总" style="width: 100%; height: 99%;">
                    <table id="fee_table">
                    </table>
                    <div id="tbfee">
                        <a href="#" onclick="do_export()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-export'">导出</a>
                        <asp:HiddenField ID="hdRoomIDs" runat="server" />
                        <asp:HiddenField ID="hdProjectIDs" runat="server" />
                        <asp:HiddenField ID="hdChargeSummary" runat="server" />
                    </div>
                </div>
            </div>
        </div>
    </form>
</asp:Content>
