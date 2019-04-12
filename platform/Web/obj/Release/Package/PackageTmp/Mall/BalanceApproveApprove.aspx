<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="BalanceApproveApprove.aspx.cs" Inherits="Web.Mall.BalanceApproveApprove" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        function do_approve(BalanceStatus) {
            var rows = parent.$("#tt_table").datagrid("getSelections");
            var IDList = [];
            $.each(rows, function (index, row) {
                IDList.push(row.ID);
            })
            MaskUtil.mask('body', '提交中');
            $('#ff').form('submit', {
                url: '../Handler/MallHandler.ashx',
                onSubmit: function (param) {
                    param.visit = 'savemallbalanceapprove';
                    param.IDList = JSON.stringify(IDList);
                    param.BalanceStatus = BalanceStatus;
                },
                success: function (data) {
                    MaskUtil.unmask();
                    var dataObj = eval("(" + data + ")");
                    if (dataObj.status) {
                        show_message("提交成功", "success", function () {
                            do_close();
                        });
                        return;
                    }
                    if (dataObj.error) {
                        show_message(dataObj.error, 'warning');
                        return;
                    }
                    show_message('系统错误', 'error');
                }
            });
        }
        function do_close() {
            parent.do_close_dialog(function () {
                parent.$('#tt_table').datagrid('reload');
            });
        }
    </script>
    <style>
        .panel-body {
            background: #f0f0f0;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <form runat="server" id="ff">
        <div class="operation_box">
            <a href="javascript:void(0)" onclick="do_approve(2)" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-save'">审核通过</a>
            <a href="javascript:void(0)" onclick="do_approve(3)" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-save'">审核不通过</a>
            <a href="javascript:void(0)" onclick="do_close()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-close'">关闭</a>
        </div>
        <div class="table_container">
            <table id="table_box" class="info">
                <tr>
                    <td>审批备注</td>
                    <td colspan="3">
                        <input type="text" id="tdApproveRemark" runat="server" class="easyui-textbox" data-options="multiline:true" style="height: 60px; width: 80%;" /></td>
                </tr>
            </table>
        </div>
    </form>
</asp:Content>
