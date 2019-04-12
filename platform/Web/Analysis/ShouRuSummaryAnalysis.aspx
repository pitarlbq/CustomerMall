<%@ Page Title="" Language="C#" MasterPageFile="~/Master/NavContent4.Master" AutoEventWireup="true" CodeBehind="ShouRuSummaryAnalysis.aspx.cs" Inherits="Web.Analysis.ShouRuSummaryAnalysis" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        var CompanyID, tdStartTime, tdEndTime, tdChargeSummary, hdChargeSummary, hdProjectIDs, hdRoomIDs, tdChargeMan;
        $(function () {
            CompanyID = "<%=Web.WebUtil.GetCompanyID(this.Context)%>";
            tdStartTime = $('#<%=this.tdStartTime.ClientID%>');
            tdEndTime = $('#<%=this.tdEndTime.ClientID%>');
            tdChargeSummary = $('#<%=this.tdChargeSummary.ClientID%>');
            hdChargeSummary = $('#<%=this.hdChargeSummary.ClientID%>');
            hdProjectIDs = $('#<%=this.hdProjectIDs.ClientID%>');
            hdRoomIDs = $('#<%=this.hdRoomIDs.ClientID%>');
            tdChargeMan = $('#<%=this.tdChargeMan.ClientID%>');
        })
    </script>
    <script src="../js/Page/Analysis/ShouRuSummaryAnalysis.js?t=<%=base.getToken() %>"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <form runat="server">
        <div id="layout" class="easyui-layout" fit="true">
            <div data-options="region:'north',hideCollapsedContent:false," title="" style="height: 60px; padding: 5px 10px;">
                <label>
                    收费日期:              
                    <input class="easyui-datebox" id="tdStartTime" runat="server" />
                    -                                   
                    <input class="easyui-datebox" id="tdEndTime" runat="server" />
                </label>
                <label>
                    收费项目:                                        
                    <input class="easyui-combobox" id="tdChargeSummary" runat="server" style="width: 150px; height: 25px;" />
                    <asp:HiddenField runat="server" ID="hdProjectIDs" />
                    <asp:HiddenField runat="server" ID="hdRoomIDs" />
                    <asp:HiddenField runat="server" ID="hdChargeSummary" />
                </label>
                <label>
                    收款人:
                    <input class="easyui-searchbox" id="tdChargeMan" runat="server" data-options="prompt:'模糊搜索',searcher:SearchFee" />
                </label>
                <label>
                    <a href="#" onclick="SearchFee()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-search'">搜索</a>
                </label>
            </div>
            <div data-options="region:'center'" title="">
                <table id="fee_table"></table>
                <div id="tbfee">
                    <a href="#" onclick="do_export()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-export'">导出</a>
                </div>
            </div>
        </div>
    </form>
</asp:Content>
