<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="BatchEditTime.aspx.cs" Inherits="Web.GongTan.BatchEditTime" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        function do_save() {
            var rows = parent.$('#tt_table').datagrid("getSelections");
            var list = [];
            $.each(rows, function (index, row) {
                list.push(row.ID);
            })
            var UseCount = $("#tdUseCount").textbox("getValue");
            var UnitPrice = $("#tdUnitPrice").textbox("getValue");
            var Coefficient = $("#tdCoefficient").textbox("getValue");
            var TotalPrice = $("#tdTotalPrice").textbox("getValue");
            var FeeStatus = $("#tbFeeStatus").combobox("getValue");
            var WriteDate = $("#tdWriteDate").datebox("getValue");
            var StartTime = $("#tdStartTime").datebox("getValue");
            var EndTime = $("#tdEndTime").datebox("getValue");
            var Rate = $("#tdRate").textbox("getValue");
            var ReducePoint = $("#tdReducePoint").textbox("getValue");
            var AddMan = "<%=Web.WebUtil.GetUser(this.Context).RealName%>";
            var options = { visit: 'batchsavetime', ids: JSON.stringify(list), UseCount: UseCount, UnitPrice: UnitPrice, Coefficient: Coefficient, TotalPrice: TotalPrice, FeeStatus: FeeStatus, WriteDate: WriteDate, StartTime: StartTime, EndTime: EndTime, AddMan: AddMan, Rate: Rate, ReducePoint: ReducePoint };
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
                parent.do_choose_charge_done();
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
                <td>用量</td>
                <td>
                    <input type="text" class="easyui-textbox" id="tdUseCount" /></td>
                <td>单价</td>
                <td>
                    <input type="text" class="easyui-textbox" id="tdUnitPrice" /></td>
            </tr>
            <tr>
                <td>系数</td>
                <td>
                    <input type="text" class="easyui-textbox" id="tdCoefficient" /></td>
                <td>金额</td>
                <td>
                    <input type="text" class="easyui-textbox" id="tdTotalPrice" /></td>
            </tr>
            <tr>
                <td>倍率</td>
                <td>
                    <input type="text" class="easyui-textbox" id="tdRate" /></td>
                <td>扣减量</td>
                <td>
                    <input type="text" class="easyui-textbox" id="tdReducePoint" /></td>
            </tr>
            <tr>
                <td style="width: 100px;">计费开始日期
                </td>
                <td>
                    <input id="tdStartTime" type="text" class="easyui-datebox" />
                </td>
                <td>结束日期
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
                <td style="display: none;">是否为期初收款单</td>
                <td style="display: none;">
                    <select class="easyui-combobox" id="tbFeeStatus" style="height: 25px;">
                        <option value="0">否</option>
                        <option value="1">是</option>
                    </select>
                    (注：当选择"是"时，账单状态默认为已收)</td>
            </tr>
        </table>
    </div>
</asp:Content>
