<%@ Page Title="" Language="C#" MasterPageFile="~/Master/NavContent4.Master" AutoEventWireup="true" CodeBehind="PayServiceAnalysis.aspx.cs" Inherits="Web.PayService.PayServiceAnalysis" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        var tdStartTime, tdEndTime, hdProjectIDs, hdRoomIDs;
        $(function () {
            tdStartTime = $("#<%=this.tdStartTime.ClientID%>");
            tdEndTime = $("#<%=this.tdEndTime.ClientID%>");
            hdRoomIDs = $("#<%=this.hdRoomIDs.ClientID%>");
            hdProjectIDs = $("#<%=this.hdProjectIDs.ClientID%>");
        })
    </script>
    <script src="../js/Page/PayService/PayServiceAnalysis.js?t=<%=base.getToken() %>"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <form runat="server" id="ff">
        <div id="layout" class="easyui-layout" fit="true">
            <div data-options="region:'north',split:false,hideCollapsedContent:false," title="" style="height: 50px; padding: 5px 10px;">
                <label>
                    支出日期:
                    <input class="easyui-datebox" id="tdStartTime" runat="server" style="width: 120px; height: 25px;" />
                    -
                    <input class="easyui-datebox" id="tdEndTime" runat="server" style="width: 120px; height: 25px;" />
                </label>
                <label>
                    <a href="#" onclick="SearchFee()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-search'">搜索</a>
                </label>
            </div>
            <div data-options="region:'center'" title="">
                <table id="fee_table"></table>
                <div id="tbfee">
                    <a href="#" onclick="do_export()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-export'">导出</a>
                    <asp:HiddenField runat="server" ID="hdRoomIDs" />
                    <asp:HiddenField runat="server" ID="hdProjectIDs" />
                </div>
            </div>
        </div>
    </form>
</asp:Content>
