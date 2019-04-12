<%@ Page Title="" Language="C#" MasterPageFile="~/Master/NavContent4.Master" AutoEventWireup="true" CodeBehind="ShouRuZhiChuSummaryAnalysis.aspx.cs" Inherits="Web.Analysis.ShouRuZhiChuSummaryAnalysis" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        var CompanyID, tdStartTime, tdEndTime, hdRoomIDs, hdProjectIDs, hdALLProjectIDs;
        $(function () {
            //$("#layout").layout("collapse", "north");
            CompanyID = "<%=Web.WebUtil.GetCompanyID(this.Context)%>";
            tdStartTime = $('#<%=this.tdStartTime.ClientID%>');
            tdEndTime = $('#<%=this.tdEndTime.ClientID%>');
            hdRoomIDs = $('#<%=this.hdRoomIDs.ClientID%>');
            hdProjectIDs = $('#<%=this.hdProjectIDs.ClientID%>');
            hdALLProjectIDs = $('#<%=this.hdALLProjectIDs.ClientID%>');
        })
    </script>
    <script src="../js/Page/Analysis/ShouRuZhiChuSummaryAnalysis.js?t=<%=base.getToken() %>"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <form runat="server" id="ff">
        <div id="layout" class="easyui-layout" fit="true">
            <div data-options="region:'north',split:false,hideCollapsedContent:false," title="" style="height: 50px; padding: 5px 0 0 10px;">
                <label>
                    时间:
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
                <table id="fee_table" title="收入汇总" style="height: 300px;">
                </table>
                <div id="tbfee">
                    <a href="#" onclick="doExportFee()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-export'">导出</a>
                    <asp:HiddenField ID="hdRoomIDs" runat="server" />
                    <asp:HiddenField ID="hdProjectIDs" runat="server" />
                    <asp:HiddenField ID="hdALLProjectIDs" runat="server" />
                </div>
                <table id="chongxiao_table" title="冲销汇总">
                </table>
                <div id="tbchongxiao">
                    <a href="#" onclick="doExportChongXiaoFee()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-export'">导出</a>
                </div>
                <%-- <table id="yajin_table" title="押金汇总">
                </table>
                <div id="tbyajin">
                    <a href="#" onclick="openExportYaJin()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-export'">导出</a>
                    <asp:Button runat="server" Style="display: none;" ID="btnExportYaJin" OnClick="btnExportYaJin_Click" />
                </div>--%>
                <table id="zhichu_table" title="支出汇总">
                </table>
                <div id="tdzhichu">
                    <a href="#" onclick="doExportZhiChuFee()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-export'">导出</a>
                </div>
               <table id="type_table" title="收支方式汇总">
                </table>
                <div id="tbtype">
                    <a href="#" onclick="doExportTypeFee()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-export'">导出</a>
                </div>
            </div>
        </div>
    </form>
</asp:Content>
