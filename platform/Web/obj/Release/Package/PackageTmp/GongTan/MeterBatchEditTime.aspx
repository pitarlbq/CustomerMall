<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="MeterBatchEditTime.aspx.cs" Inherits="Web.GongTan.MeterBatchEditTime" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        function do_save() {
            var rows = parent.$('#tt_table').datagrid("getSelections");
            var list = [];
            $.each(rows, function (index, row) {
                list.push(row.ID);
            })
            var WriteDate = $("#tdWriteDate").datebox("getValue");
            var StartTime = $("#tdStartTime").datebox("getValue");
            var EndTime = $("#tdEndTime").datebox("getValue");
            var UnitPrice = $("#tdUnitPrice").textbox("getValue");
            var Coefficient = $("#tdCoefficient").textbox("getValue");
            var options = { visit: 'batchsavemeterfeetime', ids: JSON.stringify(list), StartTime: StartTime, EndTime: EndTime, WriteDate: WriteDate, UnitPrice: UnitPrice, Coefficient: Coefficient };
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/ImportFeeHandler.ashx',
                data: options,
                success: function (data) {
                    if (data.status) {
                        show_message('保存成功', 'success', function () {
                            do_close()
                        });
                        return;
                    }
                    if (data.error) {
                        show_message(data.error, 'warning');
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
    <div class="operation_box">
        <a href="javascript:void(0)" onclick="do_save()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-save'">保存</a>
        <a href="javascript:void(0)" onclick="do_close()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-close'">关闭</a>
    </div>
    <div class="table_container">
        <table class="info">
            <tr>
                <td style="width: 100px;">单价
                </td>
                <td>
                    <input id="tdUnitPrice" type="text" class="easyui-textbox" />
                </td>
                <td>系数
                </td>
                <td>
                    <input id="tdCoefficient" type="text" class="easyui-textbox" />
                </td>
            </tr>
            <tr>
                <td style="width: 100px;">计费开始日期
                </td>
                <td>
                    <input id="tdStartTime" type="text" class="easyui-datebox" />
                </td>
                <td>计费结束日期
                </td>
                <td>
                    <input id="tdEndTime" type="text" class="easyui-datebox" />
                </td>
            </tr>
            <tr>
                <td style="width: 100px;">账单日期
                </td>
                <td>
                    <input id="tdWriteDate" type="text" class="easyui-datebox" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
