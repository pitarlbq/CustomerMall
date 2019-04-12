<%@ Page Title="" Language="C#" MasterPageFile="~/Master/NavContent4.Master" AutoEventWireup="true" CodeBehind="ProjectCountAnalysis.aspx.cs" Inherits="Web.Analysis.ProjectCountAnalysis" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>收费率表</title>
    <script>
        var tdStartTime, tdEndTime, hdRoomIDs, hdProjectIDs
        $(function () {
            tdStartTime = $('#<%=this.tdStartTime.ClientID%>');
            tdEndTime = $('#<%=this.tdEndTime.ClientID%>');
            hdRoomIDs = $('#<%=this.hdRoomIDs.ClientID%>');
            hdProjectIDs = $('#<%=this.hdProjectIDs.ClientID%>');
        })
    </script>
    <script src="../js/Page/Analysis/ProjectCountAnalysis.js?t=<%=base.getToken()%>"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <form runat="server" id="ff">
        <div id="layout" class="easyui-layout" fit="true">
            <div data-options="region:'north',split:false,hideCollapsedContent:false," title="" style="height: 60px; padding: 5px 0 0 10px;">
                <label>
                    时间:
                <input class="easyui-datebox" runat="server" id="tdStartTime" />
                    -
                <input class="easyui-datebox" runat="server" id="tdEndTime" />
                </label>
                <label class="searchlabel">
                    <a href="#" onclick="SearchFee()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-search'">搜索</a>
                </label>
            </div>
            <div data-options="region:'center'" title="">
                <table id="fee_table">
                </table>
                <div id="tbfee">
                    <a href="#" onclick="do_export()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-export'">导出</a>
                    <asp:HiddenField ID="hdRoomIDs" runat="server" />
                    <asp:HiddenField ID="hdProjectIDs" runat="server" />
                    <asp:HiddenField ID="hdALLProjectIDs" runat="server" />
                </div>
            </div>
        </div>
    </form>
</asp:Content>
