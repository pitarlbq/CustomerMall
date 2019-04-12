<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="BatchEdit.aspx.cs" Inherits="Web.Device.BatchEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        $(function () {
            loadServiceType();
        })
        function do_save() {
            var rows = parent.$('#tt_table').datagrid("getSelections");
            if (rows.length == 0) {
                show_message("请选择设备", "warning");
            }
            var list = [];
            $.each(rows, function (index, row) {
                list.push(row.ID);
            })
            var DeviceType = $("#tdDeviceType").combobox("getValue");
            var DeviceGroup = $("#tdDeviceGroup").combobox("getValue");
            var DeviceStatus = $("#tdDeviceStatus").combobox("getValue");
            var DeviceLevel = $("#tdDeviceLevel").combobox("getValue");
            var RepairType = $("#tdRepairType").textbox("getValue");
            var RepairCompany = $("#tdRepairCompany").textbox("getValue");
            var ThisRepairDate = $("#tdThisRepairDate").datebox("getValue");
            var ThisCheckDate = $("#tdThisCheckDate").datebox("getValue");
            var options = { visit: 'batchsavedevice', ids: JSON.stringify(list), DeviceType: DeviceType, DeviceGroup: DeviceGroup, DeviceStatus: DeviceStatus, DeviceLevel: DeviceLevel, RepairType: RepairType, RepairCompany: RepairCompany, ThisRepairDate: ThisRepairDate, ThisCheckDate: ThisCheckDate };
            MaskUtil.mask('body', '提交中');
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/DeviceHandler.ashx',
                data: options,
                success: function (message) {
                    MaskUtil.unmask();
                    if (message.status) {
                        show_message('保存成功', 'success', function () {
                            do_close()
                        });
                    }
                    else if (message.msg) {
                        show_message(message.msg, "warning");
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
        function loadServiceType() {
            var options = { visit: "getdeviceparams" };
            $.ajax({
                type: 'POST',
                data: options,
                dataType: 'json',
                url: '../Handler/DeviceHandler.ashx',
                success: function (data) {
                    $("#tdDeviceType").combobox({
                        editable: false,
                        data: data.devicetype,
                        valueField: 'ID',
                        textField: 'DeviceTypeName'
                    });
                    $("#tdDeviceGroup").combobox({
                        editable: false,
                        data: data.devicegroup,
                        valueField: 'ID',
                        textField: 'DeviceGroupName'
                    });
                }
            })
        }
    </script>
    <style>
       
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
                <td>设备类型</td>
                <td>
                    <input type="text" class="easyui-combobox" id="tdDeviceType" />
                </td>
                <td>设备分组</td>
                <td>
                    <input type="text" class="easyui-combobox" id="tdDeviceGroup" />
                </td>
            </tr>
            <tr>
                <td>设备状态</td>
                <td>
                    <select class="easyui-combobox" id="tdDeviceStatus">
                        <option value="1">正常</option>
                        <option value="2">停用</option>
                        <option value="3">报废</option>
                    </select>
                </td>
                <td>设备等级</td>
                <td>
                    <select class="easyui-combobox" id="tdDeviceLevel">
                        <option value="重要设备">重要设备</option>
                        <option value="关键设备">关键设备</option>
                        <option value="普通设备">普通设备</option>
                    </select></td>
            </tr>
            <tr>
                <td>维保类型</td>
                <td>
                    <input type="text" class="easyui-textbox" id="tdRepairType" /></td>
                <td>维保单位</td>
                <td>
                    <input type="text" class="easyui-textbox" id="tdRepairCompany" /></td>
            </tr>
            <tr>
                <td>本次维保日期
                </td>
                <td>
                    <input type="text" class="easyui-datebox" id="tdThisRepairDate" /></td>
                <td>本次巡检日期
                </td>
                <td>
                    <input type="text" class="easyui-datebox" id="tdThisCheckDate" /></td>
            </tr>
        </table>
    </div>
</asp:Content>
