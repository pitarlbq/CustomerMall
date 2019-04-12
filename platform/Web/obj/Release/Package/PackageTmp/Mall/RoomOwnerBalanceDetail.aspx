<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="RoomOwnerBalanceDetail.aspx.cs" Inherits="Web.Mall.RoomOwnerBalanceDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        var tdFullName, tdRoomName, tdTotalCost, tdTotalRestCost, tdTotalBalanceAmount;
        $(function () {
            tdFullName = $('#<%=this.tdFullName.ClientID%>');
            tdRoomName = $('#<%=this.tdRoomName.ClientID%>');
            tdTotalCost = $('#<%=this.tdTotalCost.ClientID%>');
            tdTotalRestCost = $('#<%=this.tdTotalRestCost.ClientID%>');
            tdTotalBalanceAmount = $('#<%=this.tdTotalBalanceAmount.ClientID%>');
        })
        function do_close() {
            parent.do_close_dialog(function () {
                parent.$('#tt_table').datagrid('reload');
            });
        }
    </script>
    <script src="../js/Page/Mall/Balance/RoomOwnerBalanceDetail.js?v=<%=base.getToken() %>"></script>
    <style>
        .panel-body {
            background: #f0f0f0;
        }

        table.info table.field {
            width: 100%;
            border: solid 1px #ccc;
            border-spacing: 0;
            border-collapse: collapse;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <form id="ff" runat="server" method="post" enctype="multipart/form-data">
        <div class="operation_box">
            <a href="javascript:void(0)" onclick="do_close()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-close'">关闭</a>
        </div>
        <div class="table_container">
            <div class="table_title">基本信息</div>
            <table class="info">
                <tr>
                    <td>房源位置</td>
                    <td>
                        <label id="tdFullName" runat="server"></label>
                    </td>
                    <td>房间编号</td>
                    <td>
                        <label id="tdRoomName" runat="server"></label>
                    </td>
                </tr>
                <tr>
                    <td>订单总金额</td>
                    <td>
                        <label id="tdTotalCost" runat="server"></label>
                    </td>
                    <td>待结算总金额</td>
                    <td>
                        <label id="tdTotalRestCost" runat="server"></label>
                    </td>
                </tr>
                <tr>
                    <td>已返现总金额</td>
                    <td colspan="3">
                        <label id="tdTotalBalanceAmount" runat="server"></label>
                    </td>
                </tr>
            </table>
            <div class="table_title">订单信息</div>
            <div class="easyui-panel" style="height: 300px;">
                <table id="tt_table"></table>
            </div>
        </div>
    </form>
</asp:Content>
