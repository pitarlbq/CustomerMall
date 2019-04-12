<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="RealCostAnalysisSummary.aspx.cs" Inherits="Web.Analysis.RealCostAnalysisSummary" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        var CompanyID, tdStartTime, tdEndTime, hdRoomIDs, hdProjectIDs;
        $(function () {
            //$("#layout").layout("collapse", "north");
            CompanyID = "<%=Web.WebUtil.GetCompanyID(this.Context)%>";
            tdStartTime = $('#<%=this.tdStartTime.ClientID%>');
            tdEndTime = $('#<%=this.tdEndTime.ClientID%>');
            hdRoomIDs = $('#<%=this.hdRoomIDs.ClientID%>');
            hdProjectIDs = $('#<%=this.hdProjectIDs.ClientID%>');
        })
    </script>
    <script src="../js/Page/Analysis/RealCostAnalysisSummary.js?t=<%=base.getToken() %>"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <form runat="server" id="ff">
        <div id="layout" class="easyui-layout" fit="true">
            <div data-options="region:'north',split:true,hideCollapsedContent:false," title="" style="height: 60px; padding: 5px 0 0 10px;">
                <label>
                    收款时间:
                <input class="easyui-datebox" runat="server" id="tdStartTime" />
                    -
                <input class="easyui-datebox" runat="server" id="tdEndTime" />
                </label>
                <label style="display: none;">
                    收款人:
                <input class="easyui-searchbox" id="tdChargeMan" type="text" data-options="prompt:'收款人搜索',searcher:SearchFee" style="width: 100px;" />
                </label>
                <label style="display: none;">
                    收费项目:
                <input class="easyui-combobox" id="tdChargeSummary" style="width: 100px;" />
                </label>
                <label style="display: none;">
                    收款方式:
                <input class="easyui-combobox" id="tdChargeType" style="width: 100px;" />
                </label>
                <label class="searchlabel">
                    <a href="#" onclick="SearchFee()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-search'">搜索</a>
                </label>
            </div>
            <div data-options="region:'center'" title="">
                <table id="fee_table" title="实收汇总" fit="true">
                </table>
                <div id="tbfee">
                    <a href="#" onclick="do_export()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-export'">导出</a>
                    <asp:HiddenField ID="hdRoomIDs" runat="server" />
                    <asp:HiddenField ID="hdProjectIDs" runat="server" />
                </div>
            </div>
        </div>
    </form>
</asp:Content>
