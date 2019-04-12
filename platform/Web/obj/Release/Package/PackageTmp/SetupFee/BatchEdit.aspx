<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="BatchEdit.aspx.cs" Inherits="Web.SetupFee.BatchEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        $(function () {
            $("#tdStartTime").datebox({
                onChange: function (res) {
                    getEndTime(res);
                }
            })
        })
        function getEndTime(StartTime) {
            var rows = parent.$('#tt_table').datagrid("getSelections");
            var list = [];
            $.each(rows, function (index, row) {
                list.push(row.ID);
            })
            var options = { visit: "getendtime", StartTime: StartTime, IDList: JSON.stringify(list) };
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/FeeCenterHandler.ashx',
                data: options,
                success: function (data) {
                    if (data.status && data.EndTime != "") {
                        $("#tdEndTime").datebox('setValue', data.EndTime);
                    }
                }
            });
        }
        function do_save() {
            var rows = parent.$('#tt_table').datagrid("getSelections");
            var list = [];
            $.each(rows, function (index, row) {
                list.push(row.ID);
            })
            var UnitPrice = $("#tdUnitPrice").numberbox("getValue");
            var StartTime = $("#tdStartTime").datebox("getValue");
            var EndTime = $("#tdEndTime").datebox("getValue");
            var options = { visit: 'batchsavefee', ids: JSON.stringify(list), UnitPrice: UnitPrice, StartTime: StartTime, EndTime: EndTime };
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/FeeCenterHandler.ashx',
                data: options,
                success: function (message) {
                    if (message.status) {
                        show_message('保存成功', 'success', function () {
                            do_close()
                        });
                    }
                    else if (message.msg) {
                        show_message(message.msg, "error");
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
        function clearStartTime() {
            var rows = parent.$('#tt_table').datagrid("getSelections");
            var list = [];
            $.each(rows, function (index, row) {
                list.push(row.ID);
            })
            var options = { visit: 'batchsavefee', ids: JSON.stringify(list), clearstarttime: true };
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/FeeCenterHandler.ashx',
                data: options,
                success: function (message) {
                    if (message.status) {
                        show_message('保存成功', 'success', function () {
                            do_close()
                        });
                    }
                    else if (message.msg) {
                        show_message(message.msg, "error");
                    }
                    else {
                        show_message('系统错误', 'error');
                    }
                }
            });
        }
        function clearEndTime() {
            var rows = parent.$('#tt_table').datagrid("getSelections");
            var list = [];
            $.each(rows, function (index, row) {
                list.push(row.ID);
            })
            var options = { visit: 'batchsavefee', ids: JSON.stringify(list), clearendtime: true };
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/FeeCenterHandler.ashx',
                data: options,
                success: function (message) {
                    if (message.status) {
                        show_message('保存成功', 'success', function () {
                            do_close()
                        });
                    }
                    else if (message.msg) {
                        show_message(message.msg, "error");
                    }
                    else {
                        show_message('系统错误', 'error');
                    }
                }
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
        <a href="javascript:void(0)" onclick="clearStartTime()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-save'">清空计费开始日期</a>
        <a href="javascript:void(0)" onclick="clearEndTime()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-save'">清空计费结束日期</a>
        <a href="javascript:void(0)" onclick="do_save()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-save'">保存</a>
        <a href="javascript:void(0)" onclick="do_close()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-close'">关闭</a>
    </div>
    <div class="table_container">
        <table class="info">
            <tr>
                <td>计费开始日期</td>
                <td>
                    <input type="text" class="easyui-datebox" id="tdStartTime" />
                </td>
                <td>计算结束日期</td>
                <td>
                    <input type="text" class="easyui-datebox" id="tdEndTime" />
                </td>
            </tr>
            <tr>
                <td>单价(月度)</td>
                <td colspan="3">
                    <input type="text" id="tdUnitPrice" class="easyui-numberbox" data-options="min:0,precision:3" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
