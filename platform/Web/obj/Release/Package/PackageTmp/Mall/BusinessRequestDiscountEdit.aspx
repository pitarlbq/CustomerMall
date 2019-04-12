<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="BusinessRequestDiscountEdit.aspx.cs" Inherits="Web.Mall.BusinessRequestDiscountEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        var ID, filecount = 0, tdCategoryName;
        $(function () {
            ID = "<%=this.ID%>";
        });
        function do_close() {
            parent.do_close_dialog(function () {
            }, true);
        }
    </script>
    <script src="../js/Page/Mall/Business/BusinessRequestDiscountEdit.js?t=<%=base.getToken() %>"></script>
    <style>
        .panel-body {
            background: #f0f0f0;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <form id="ff" runat="server" method="post" enctype="multipart/form-data">
        <div class="operation_box">
            <a href="javascript:void(0)" onclick="do_close()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-close'">关闭</a>
        </div>
        <div class="table_container">
            <table class="info">
                <tr>
                    <td>申请人</td>
                    <td>
                        <label runat="server" id="labelAddUserMan"></label>
                    </td>
                    <td>申请时间
                    </td>
                    <td>
                        <label runat="server" id="labelAddTime"></label>
                    </td>
                </tr>
                <tr>
                    <td>商家名称</td>
                    <td colspan="3">
                        <label runat="server" id="labelBusinessName"></label>
                    </td>
                </tr>
                <tr>
                    <td>开始时间</td>
                    <td>
                        <label runat="server" id="labelStartTime"></label>
                    </td>
                    <td>截至时间
                    </td>
                    <td>
                        <label runat="server" id="labelEndTime"></label>
                    </td>
                </tr>
                <tr>
                    <td>备注信息
                    </td>
                    <td colspan="3">
                        <label runat="server" id="labelRequestContent"></label>
                    </td>
                </tr>
            </table>
            <div class="easyui-panel" style="height: 300px;">
                <table id="tt_table"></table>
            </div>
        </div>
    </form>
</asp:Content>
