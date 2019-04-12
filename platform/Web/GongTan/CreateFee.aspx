<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="CreateFee.aspx.cs" Inherits="Web.GongTan.CreateFee" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        $(function () {
            loadFeeType();
            $('#tdCoefficient').textbox('setValue', 1);
        });
        function loadFeeType() {
            var CompanyID = "<%=Web.WebUtil.GetCompanyID(this.Context)%>";
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/FeeCenterHandler.ashx?visit=getchargesummarylist&CompanyID=' + CompanyID + '&IsAllowImport=true',
                success: function (data) {
                    $('#tdChargeSummary').combobox({
                        editable: false,
                        data: data,
                        valueField: 'ID',
                        textField: 'Name',
                        onSelect: function (rec) {
                            if (rec.StartPriceRange) {
                                $("#tdSummaryUnitPrice").textbox("setValue", '阶梯单价');
                                $("#tdSummaryUnitPrice").textbox({ disabled: true });
                            }
                            else {
                                $("#tdSummaryUnitPrice").textbox("setValue", (Number(rec.SummaryUnitPrice) < 0 ? 0 : rec.SummaryUnitPrice));
                                $("#tdSummaryUnitPrice").textbox({ disabled: false });
                            }
                            $("#tdCoefficient").textbox("setValue", (Number(rec.Coefficient) < 0 ? 1 : rec.Coefficient));
                        }
                    });
                    $('#tdChargeSummary').combobox("setValue", data[0].ID);
                    if (data[0].StartPriceRange) {
                        $("#tdSummaryUnitPrice").textbox("setValue", '阶梯单价');
                        $("#tdSummaryUnitPrice").textbox({ disabled: true });
                    }
                    else {
                        $("#tdSummaryUnitPrice").textbox("setValue", (Number(data[0].SummaryUnitPrice) < 0 ? 0 : data[0].SummaryUnitPrice));
                        $("#tdSummaryUnitPrice").textbox({ disabled: false });
                    }
                    $("#tdCoefficient").textbox("setValue", (Number(data[0].Coefficient) < 0 ? 1 : data[0].Coefficient));
                }
            });
        }
        function closeWin() {
            parent.do_close_dialog(function () {
                parent.create_fee_complete();
            });
        }
        function createFee() {
            var roomids = [];
            var projectids = [];
            try {
                roomids = parent.GetSelectedRooms();
                projectids = parent.GetSelectedProjects();
            } catch (e) {

            }
            if (roomids.length == 0 && projectids.length == 0) {
                show_message("请选择一个资源", "warning");
                return;
            }
            var WriteDate = $("#tdWriteDate").datebox("getValue");
            var ChargeID = $("#tdChargeSummary").combobox("getValue");
            if (WriteDate == null || WriteDate == "") {
                show_message("请填写账单日期", "warning");
                return;
            }
            if (ChargeID == null || ChargeID == "") {
                show_message("请选择收费项目", "warning");
                return;
            }
            var SummaryUnitPrice = $("#tdSummaryUnitPrice").textbox("getValue");
            var Coefficient = $("#tdCoefficient").textbox("getValue");
            var UseCount = $("#tdUseCount").textbox("getValue");
            var TotalCost = $("#tdTotalCost").textbox("getValue");
            var StartTime = $("#tdStartTime").datebox("getValue");
            var EndTime = $("#tdEndTime").datebox("getValue");
            top.$.messager.confirm("提示", "确认生成？", function (r) {
                if (r) {
                    var CompanyID = "<%=Web.WebUtil.GetCompanyID(this.Context)%>";
                    var options = { visit: 'createimportfee', ChargeID: ChargeID, WriteDate: WriteDate, roomids: JSON.stringify(roomids), projectids: JSON.stringify(projectids), SummaryUnitPrice: SummaryUnitPrice, Coefficient: Coefficient, UseCount: UseCount, TotalCost: TotalCost, StartTime: StartTime, EndTime: EndTime };
                    MaskUtil.mask('body', '提交中');
                    $.ajax({
                        type: 'POST',
                        dataType: 'json',
                        url: '../Handler/ImportFeeHandler.ashx',
                        data: options,
                        success: function (message) {
                            MaskUtil.unmask();
                            if (message.status == 1) {
                                show_message("生成成功", "success", function () {
                                    parent.chooseWriteDate = WriteDate;
                                    parent.chooseChargeID = ChargeID
                                    closeWin();
                                })
                                return;
                            }
                            if (message.status == 3) {
                                show_message("该费项不存在，请重新选择", "warning");
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
    <div class="operation_box">
        <a href="javascript:void(0)" onclick="createFee()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-shengcheng'">生成</a>
        <a href="javascript:void(0)" onclick="closeWin()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-close'">关闭</a>
    </div>
    <div class="table_container">
        <table class="info">
            <tr>
                <td style="width: 100px;">账单日期：
                </td>
                <td>
                    <input id="tdWriteDate" type="text" class="easyui-datebox" />
                </td>
                <td>收费项目：
                </td>
                <td>
                    <input id="tdChargeSummary" type="text" class="easyui-combobox" />
                </td>
            </tr>
            <tr>
                <td>单价：
                </td>
                <td>
                    <input id="tdSummaryUnitPrice" type="text" class="easyui-textbox" />
                </td>
                <td>系数：
                </td>
                <td>
                    <input id="tdCoefficient" type="text" class="easyui-textbox" value="1" />
                </td>
            </tr>
            <tr>
                <td>用量：
                </td>
                <td>
                    <input id="tdUseCount" type="text" class="easyui-textbox" />
                </td>
                <td>金额：
                </td>
                <td>
                    <input id="tdTotalCost" type="text" class="easyui-textbox" />
                </td>
            </tr>
            <tr>
                <td style="width: 100px;">计费开始日期：
                </td>
                <td>
                    <input id="tdStartTime" type="text" class="easyui-datebox" />
                </td>
                <td>结束日期：
                </td>
                <td>
                    <input id="tdEndTime" type="text" class="easyui-datebox" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
