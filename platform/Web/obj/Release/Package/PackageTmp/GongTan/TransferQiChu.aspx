<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="TransferQiChu.aspx.cs" Inherits="Web.GongTan.TransferQiChu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        $(function () {
            $("#tdChargeStatus").combobox({
                onSelect: function (res) {
                    if (res.value == "canceled") {
                        $(".trCharge").hide();
                    }
                    else {
                        $(".trCharge").show();
                    }
                }
            })
            loadchargesummarytype();
        })
        function loadchargesummarytype() {
            var options = { visit: 'loadchargesummarytype' };
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/FeeCenterHandler.ashx',
                data: options,
                success: function (data) {
                    $("#tdChargeMoneyType").combobox({
                        editable: false,
                        data: data.list,
                        valueField: 'ChargeTypeID',
                        textField: 'ChargeTypeName',
                    });
                    ChargeMoneyType1.combobox("setValue", 0);
                }
            });
        }
        function do_save() {
            var rows = parent.$('#tt_table').datagrid("getSelections");
            var list = [];
            $.each(rows, function (index, row) {
                list.push(row.ID);
            })
            var ChargeMan = $("#tdChargeMan").textbox("getValue");
            var ChargeTime = $("#tdChargeTime").datetimebox("getValue");
            var Remark = $("#tdRemark").textbox("getValue");
            var AddMan = "<%=Web.WebUtil.GetUser(this.Context).RealName%>";
            var ChargeStatus = $("#tdChargeStatus").combobox("getValue");
            var ChargeMoneyType = $("#tdChargeMoneyType").combobox("getValue");
            var options = { visit: 'batchsaveqichu', ids: JSON.stringify(list), ChargeMan: ChargeMan, ChargeTime: ChargeTime, Remark: Remark, AddMan: AddMan, ChargeStatus: ChargeStatus, ChargeMoneyType: ChargeMoneyType };
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/ImportFeeHandler.ashx',
                data: options,
                success: function (data) {
                    if (data.status) {
                        show_message('保存成功', 'success', function () {
                            do_close();
                        });
                        return;
                    }
                    if (data.error) {
                        show_message(data.error, "warning");
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
                <td>收款状态</td>
                <td>
                    <select id="tdChargeStatus" class="easyui-combobox" data-options="editable:false">
                        <option value="charged">已收</option>
                        <option value="canceled">作废</option>
                    </select>
                </td>
                <td class="trCharge">收款方式: </td>
                <td class="trCharge">
                    <input class="easyui-combobox" id="tdChargeMoneyType" type="text" />
                </td>
            </tr>
            <tr class="trCharge">
                <td>收款人</td>
                <td>
                    <input type="text" class="easyui-textbox" id="tdChargeMan" /></td>
                <td>收款日期</td>
                <td>
                    <input type="text" class="easyui-datetimebox" id="tdChargeTime" /></td>
            </tr>
            <tr>
                <td>备注</td>
                <td colspan="3">
                    <input type="text" class="easyui-textbox" data-options="multiline:true" style="width: 100%; height: 60px;" id="tdRemark" /></td>
            </tr>
        </table>
    </div>
</asp:Content>
