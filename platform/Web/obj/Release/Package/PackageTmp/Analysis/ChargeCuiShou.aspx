<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="ChargeCuiShou.aspx.cs" Inherits="Web.Analysis.ChargeCuiShou" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        $(function () {
            loadChargeType();
        });
        function loadChargeType() {
            var options = { visit: 'loadchargesummarytype' };
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/FeeCenterHandler.ashx',
                data: options,
                success: function (data) {
                    $("#tdChargeType").combobox({
                        editable: false,
                        data: data.list,
                        valueField: 'ChargeTypeID',
                        textField: 'ChargeTypeName',
                    });
                    $("#tdChargeType").combobox("setValue", data.list[0].ChargeTypeID);
                }
            });
        }
        function do_close() {
            parent.do_close_dialog(function () {
                parent.loadchargeHistoryBill();
            });
        }
        function do_save() {
            var rows = parent.$('#his_table').datagrid("getSelections");
            if (rows.length == 0) {
                show_message('请选择一条数据，操作取消', 'warning');
                return;
            }
            var isCancel = false;
            var isCharge = false;
            $.each(rows, function (index, row) {
                if (row.ChargeState == 2) {
                    isCancel = true;
                    return false;
                }
                if (row.ChargeState == 1 || row.ChargeState == 4) {
                    isCharge = true;
                    return false;
                }
            });
            if (isCancel) {
                show_message('选择的单据已作废，操作取消', 'warning');
                return;
            }
            if (isCharge) {
                show_message('选择的单据已收费，不能重复收费，操作取消', 'warning');
                return;
            }
            var isValid = $("#<%=this.ff.ClientID%>").form('enableValidation').form('validate');
            if (!isValid) {
                return;
            }
            top.$.messager.confirm("提示", "确认收费", function (r) {
                if (r) {
                    var RoomFeeIDList = [];
                    $.each(rows, function (index, row) {
                        RoomFeeIDList.push(row.HistoryID);
                    });
                    var CompanyName = "<%=Web.WebUtil.GetCompany(this.Context).CompanyName%>";
                    var AddMan = "<%=Web.WebUtil.GetUser(this.Context).RealName%>";
                    var ChargeMan = $("#tdChargeMan").textbox('getValue');
                    var ChargeType = $("#tdChargeType").combobox('getValue');
                    var ChargeTime = $("#tdChargeTime").datetimebox('getValue');
                    var Remark = $("#tdRemark").textbox('getValue');
                    MaskUtil.mask('body', '提交中');
                    var options = { visit: "confirmechargeroomfee", IDs: JSON.stringify(RoomFeeIDList), CompanyName: CompanyName, AddMan: AddMan, ChargeMan: ChargeMan, ChargeType: ChargeType, ChargeTime: ChargeTime, Remark: Remark };
                    $.ajax({
                        type: 'POST',
                        dataType: 'json',
                        url: '../Handler/FeeCenterHandler.ashx',
                        data: options,
                        success: function (data) {
                            MaskUtil.unmask();
                            if (data.status) {
                                show_message('收费成功', 'success');
                                do_close();
                                return;
                            }
                            else if (data.msg) {
                                show_message(data.msg, 'warning');
                            }
                            else {
                                show_message('系统错误', 'error');
                            }
                        }
                    });
                }
            })
        }
    </script>
    <style>
        .panel-body {
            background: #f0f0f0;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <form id="ff" runat="server">
        <div class="operation_box">
            <a href="#" onclick="do_save()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-shoufei'">收费</a>
            <a href="javascript:void(0)" onclick="do_close()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-close'">关闭</a>
        </div>
        <div class="table_container">
            <table class="info">
                <tr>
                    <td>收款人：
                    </td>
                    <td>
                        <input id="tdChargeMan" type="text" class="easyui-textbox" data-options="required:true" />
                    </td>
                    <td>收款方式：
                    </td>
                    <td>
                        <input id="tdChargeType" type="text" class="easyui-combobox" data-options="required:true" />
                    </td>
                </tr>
                <tr>
                    <td>收款日期：
                    </td>
                    <td colspan="3">
                        <input id="tdChargeTime" type="text" class="easyui-datetimebox" data-options="required:true" />
                    </td>
                </tr>
                <tr>
                    <td>备注：
                    </td>
                    <td colspan="3">
                        <input id="tdRemark" type="text" data-options="multiline:true" style="height: 60px;" class="easyui-textbox" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</asp:Content>
