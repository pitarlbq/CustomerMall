<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="BatchEditTaiZhangTime.aspx.cs" Inherits="Web.GongTan.BatchEditTaiZhangTime" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        function do_save() {
            var rows = parent.$('#tt_table').datagrid("getSelections");
            var list = [];
            $.each(rows, function (index, row) {
                list.push(row.ID);
            })
            var WriteDate = $("#tdWriteDate").datebox("getValue");
            var Rate = $("#tdRate").textbox("getValue");
            var Coefficient = $("#tdCoefficient").textbox("getValue");
            var UnitPrice = $("#tdUnitPrice").textbox("getValue");
            var options = { visit: 'batchsavetaizhangtime', ids: JSON.stringify(list), WriteDate: WriteDate, Rate: Rate, Coefficient: Coefficient, UnitPrice: UnitPrice };
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/ImportFeeHandler.ashx',
                data: options,
                success: function (message) {
                    if (message.status) {
                        show_message('保存成功', 'success', function () {
                            do_close()
                        });;
                    }
                    else {
                        show_message('系统错误', 'error');
                    }
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
    <div class="operation_box">
        <a href="javascript:void(0)" onclick="do_save()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-save'">保存</a>
        <a href="javascript:void(0)" onclick="do_close()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-close'">关闭</a>
    </div>
    <div class="table_container">
        <table class="info">
            <tr>
                <td style="width: 100px;">抄表日期
                </td>
                <td>
                    <input id="tdWriteDate" type="text" class="easyui-datebox" />
                </td>
                <td>倍率</td>
                <td>
                    <input type="text" class="easyui-textbox" id="tdRate" /></td>
            </tr>
            <tr>

                <td>系数</td>
                <td>
                    <input type="text" class="easyui-textbox" id="tdCoefficient" /></td>
                <td>单价</td>
                <td>
                    <input type="text" class="easyui-textbox" id="tdUnitPrice" /></td>
            </tr>
        </table>
    </div>
</asp:Content>
