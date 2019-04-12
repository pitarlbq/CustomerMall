<%@ Page Title="" Language="C#" MasterPageFile="~/Master/NavContent4.Master" AutoEventWireup="true" CodeBehind="MonthFeeAnalysis.aspx.cs" Inherits="Web.Analysis.MonthFeeAnalysis" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>月度分析表</title>
    <script>
        var tdChargeSummary, hdChargeSummary, tdYear, hdRoomIDs, hdProjectIDs;
        $(function () {
            tdChargeSummary = $('#<%=this.tdChargeSummary.ClientID%>');
            hdChargeSummary = $('#<%=this.hdChargeSummary.ClientID%>');
            tdYear = $('#<%=this.tdYear.ClientID%>');
            hdRoomIDs = $('#<%=this.hdRoomIDs.ClientID%>');
            hdProjectIDs = $('#<%=this.hdProjectIDs.ClientID%>');
        })
    </script>
    <script src="../js/Page/Analysis/MonthFeeAnalysis.js?t=<%=base.getToken() %>"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <form runat="server" id="ff">
        <div id="layout" class="easyui-layout" fit="true">
            <div data-options="region:'north',hideCollapsedContent:false," title="" style="height: 50px; padding: 5px 10px;">
                <label>
                    收费项目:    
                    <input class="easyui-combobox" runat="server" id="tdChargeSummary" style="width: 150px;" />
                    <asp:HiddenField ID="hdChargeSummary" runat="server" />
                </label>
                <label>
                    日期:    
                    <input class="easyui-combobox" runat="server" id="tdYear" style="width: 150px;" />
                </label>
                <label class="searchlabel">
                    <a href="#" onclick="SearchHis()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-search'">搜索</a>
                </label>
            </div>
            <div data-options="region:'center'" title="">
                <table id="tt_table">
                </table>
                <div id="tb">
                    <a href="#" onclick="openSetting()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-setting'">配置</a>
                    <a href="#" onclick="do_export()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-export'">导出</a>
                    <asp:HiddenField runat="server" ID="hdProjectIDs" />
                    <asp:HiddenField runat="server" ID="hdRoomIDs" />
                </div>
            </div>
        </div>
    </form>
</asp:Content>
