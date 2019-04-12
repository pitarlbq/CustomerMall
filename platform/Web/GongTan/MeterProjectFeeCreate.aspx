<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="MeterProjectFeeCreate.aspx.cs" Inherits="Web.GongTan.MeterProjectFeeCreate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        var hdChargeIDList;
        $(function () {
            hdChargeIDList = $('#<%=this.hdChargeIDList.ClientID%>');
            $('#tdCoefficient').textbox('setValue', 1);
            var charge_list = [];
            if (hdChargeIDList.val() != '') {
                charge_list = eval('(' + hdChargeIDList.val() + ')');
            }
            $('#tdChargeName').combobox({
                data: charge_list,
                valueField: 'id',
                textField: 'name',
                editable: false,
                multiple: true
            })
        });
        function do_close() {
            parent.do_close_dialog(function () {
                parent.$('#tt_table').datagrid('reload');
            });
        }
        function do_save() {
            var rows = parent.$('#tt_table').datagrid('getSelections');
            if (rows.length == 0) {
                show_message('请选择一条数据，操作取消', 'warning');
                return;
            }
            var IDList = [];
            $.each(rows, function (index, row) {
                IDList.push(row.ID);
            })
            var WriteDate = $("#tdWriteDate").datebox("getValue");
            if (WriteDate == null || WriteDate == "") {
                show_message('请填写账单日期', 'warning');
                return;
            }
            var SummaryUnitPrice = $("#tdSummaryUnitPrice").textbox("getValue");
            var Coefficient = $("#tdCoefficient").textbox("getValue");
            var StartTime = $("#tdStartTime").datebox("getValue");
            var EndTime = $("#tdEndTime").datebox("getValue");
            var ChargeIDs = $("#tdChargeName").combobox("getValues");
            top.$.messager.confirm("提示", "确认生成？", function (r) {
                if (r) {
                    var options = { visit: 'createmeterprojectfee', IDList: JSON.stringify(IDList), WriteDate: WriteDate, SummaryUnitPrice: SummaryUnitPrice, Coefficient: Coefficient, StartTime: StartTime, EndTime: EndTime, ChargeIDs: JSON.stringify(ChargeIDs) };
                    MaskUtil.mask('body', '提交中');
                    $.ajax({
                        type: 'POST',
                        dataType: 'json',
                        url: '../Handler/ImportFeeHandler.ashx',
                        data: options,
                        success: function (message) {
                            MaskUtil.unmask();
                            if (message.status) {
                                show_message('生成成功', 'success');
                                setTimeout(function () {
                                    do_close();
                                }, 1000);
                                return;
                            }
                            if (message.error) {
                                show_message(message.error, 'error');
                                return;
                            }
                            show_message('系统错误', 'error');
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
    <form runat="server">
        <div class="operation_box">
            <a href="javascript:void(0)" onclick="do_save()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-save'">生成</a>
            <a href="javascript:void(0)" onclick="do_close()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-close'">关闭</a>
        </div>
        <div class="table_container">
            <table class="info">
                <tr>
                    <td style="width: 100px;">账单日期：
                    </td>
                    <td>
                        <input id="tdWriteDate" type="text" class="easyui-datebox" />
                    </td>
                    <td style="width: 100px;">收费项目：
                    </td>
                    <td>
                        <input class="easyui-combobox" id="tdChargeName" style="width: 150px; height: 25px;" />
                        <asp:HiddenField runat="server" ID="hdChargeIDList" />
                    </td>
                </tr>
                <tr>
                    <td>单价：
                    </td>
                    <td>
                        <input id="tdSummaryUnitPrice" data-options="required:true" type="text" class="easyui-textbox" />
                    </td>
                    <td>系数：
                    </td>
                    <td>
                        <input id="tdCoefficient" type="text" class="easyui-textbox" value="1" />
                    </td>
                </tr>
                <tr>
                    <td style="width: 100px;">计费开始日期：
                    </td>
                    <td>
                        <input id="tdStartTime" type="text" class="easyui-datebox" />
                    </td>
                    <td>计费结束日期：
                    </td>
                    <td>
                        <input id="tdEndTime" type="text" class="easyui-datebox" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</asp:Content>
