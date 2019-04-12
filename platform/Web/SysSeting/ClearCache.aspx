<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="ClearCache.aspx.cs" Inherits="Web.SysSeting.ClearCache" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        table.info {
            width: 100%;
            border: solid 1px #ccc;
            border-spacing: 0;
            border-collapse: collapse;
        }

            table.info td {
                width: 35%;
                text-align: left;
                border: solid 1px #ccc;
                padding: 5px 10px;
            }

                table.info td:nth-child(2n-1) {
                    width: 15%;
                    text-align: right;
                }

        input[type=checkbox] {
            width: 20px;
            height: 20px;
        }
    </style>
    <script>
        function do_save() {
            var options = {};
            options.visit = 'cleardata';
            options.clear_project = ($('#tdProject').prop('checked') ? 1 : 0);
            options.clear_chargesummary = ($('#tdChargeSummary').prop('checked') ? 1 : 0);
            options.clear_fee = ($('#tdFee').prop('checked') ? 1 : 0);
            options.clear_importfee = ($('#tdImportFee').prop('checked') ? 1 : 0);
            options.clear_historyfee = ($('#tdFeeHistory').prop('checked') ? 1 : 0);
            options.clear_feeorder = ($('#tdFeeOrder').prop('checked') ? 1 : 0);
            options.clear_contract = ($('#tdContract').prop('checked') ? 1 : 0);
            options.clear_cangku = ($('#tdCKInOut').prop('checked') ? 1 : 0);
            options.clear_customerservice = ($('#tdCustomerService').prop('checked') ? 1 : 0);
            options.clear_payservice = ($('#tdPayService').prop('checked') ? 1 : 0);
            options.clear_divice = ($('#tdDevice').prop('checked') ? 1 : 0);
            top.$.messager.confirm('提示', '确认删除?', function (r) {
                if (r) {
                    $.ajax({
                        type: 'POST',
                        dataType: 'json',
                        url: '../Handler/SysSettingHandler.ashx',
                        data: options,
                        success: function (data) {
                            if (data.status) {
                                show_message('删除成功,请重新登录', 'success', function () {
                                    window.location.reload();
                                })
                                return;
                            }
                            if (data.error) {
                                show_message(data.error, 'info');
                                return;
                            }
                            show_message("系统错误", 'info')
                        }
                    });
                }
            })
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <table class="info">
        <tr>
            <td colspan="4" style="color: #ff0000; text-align: center; font-size: 18px;">删除数据后无法恢复，请谨慎使用
            </td>
        </tr>
        <tr>
            <td>资源信息
            </td>
            <td>
                <input type="checkbox" id="tdProject" checked />
            </td>
            <td>收费项目
            </td>
            <td>
                <input type="checkbox" id="tdChargeSummary" checked />
            </td>
        </tr>
        <tr>
            <td>费项明细
            </td>
            <td>
                <input type="checkbox" id="tdFee" checked />
            </td>
            <td>抄表账单
            </td>
            <td>
                <input type="checkbox" id="tdImportFee" checked />
            </td>
        </tr>
        <tr>
            <td>历史单据
            </td>
            <td>
                <input type="checkbox" id="tdFeeHistory" checked />
            </td>
            <td>交班报表
            </td>
            <td>
                <input type="checkbox" id="tdFeeOrder" checked />
            </td>
        </tr>
        <tr>
            <td>租赁合同
            </td>
            <td>
                <input type="checkbox" id="tdContract" checked />
            </td>
            <td>仓库信息
            </td>
            <td>
                <input type="checkbox" id="tdCKInOut" checked />
            </td>
        </tr>
        <tr>
            <td>客服总台
            </td>
            <td>
                <input type="checkbox" id="tdCustomerService" checked />
            </td>
            <td>支出登记
            </td>
            <td>
                <input type="checkbox" id="tdPayService" checked />
            </td>
        </tr>
        <tr>
            <td>工程设备
            </td>
            <td colspan="3">
                <input type="checkbox" id="tdDevice" checked />
            </td>
        </tr>
        <tr>
            <td colspan="4" style="text-align: center;">
                <a href="javascript:void(0)" onclick="do_save()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-save'">提交</a>
            </td>
        </tr>
    </table>
</asp:Content>
