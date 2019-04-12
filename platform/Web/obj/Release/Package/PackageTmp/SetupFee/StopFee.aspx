<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="StopFee.aspx.cs" Inherits="Web.SetupFee.StopFee" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function stopfee() {
            var isValid = $("#ff").form('enableValidation').form('validate');
            if (!isValid) {
                return;
            }
            var stoptime = $("#starttime").datebox("getValue");
            var rows = parent.$('#tt_table').datagrid("getSelections");
            if (rows.length == 0) {
                show_message("请选择一个费项档案");
                return;
            }
            var feeidarry = [];
            $.each(rows, function (index, item) {
                feeidarry.push(item.ID);
            })
            if (feeidarry.length == 0) {
                show_message("请选择一个费项档案");
                return;
            }
            MaskUtil.mask('body', '提交中');
            var options = { visit: "cancelroomfee", RoomFeeIDs: JSON.stringify(feeidarry), stoptime: stoptime };
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/FeeCenterHandler.ashx',
                data: options,
                success: function (data) {
                    MaskUtil.unmask();
                    if (data.status == 1) {
                        show_message("停用成功", "success", function () {
                            do_close();
                        });
                    }
                    else if (data.status == 3) {
                        show_message("计费停用日期不得小于当前房间计费开始日期，停用失败", "info", function () {
                        });
                    }
                    else if (data.status == 2) {
                        show_message("该标准没有启用", "info", function () {
                        });
                    }
                    else if (data.status == 4) {
                        show_message("有" + data.errorcount + "条费项计费开始日期在计费停用日期之前，业务逻辑错误，请复核！", "info", function () {
                        });
                    }
                    else {
                        show_message('系统错误', 'error');
                    }
                }
            });
        }
        function clearfee() {
            var stoptime = $("#starttime").datebox("getValue");
            var rows = parent.$('#tt_table').datagrid("getSelections");
            if (rows.length == 0) {
                show_message("请选择一个费项档案", "warning");
                return;
            }
            var feeidarry = [];
            $.each(rows, function (index, item) {
                feeidarry.push(item.ID);
            })
            if (feeidarry.length == 0) {
                show_message("请选择一个费项档案", "warning");
                return;
            }
            MaskUtil.mask('body', '提交中');
            var options = { visit: "cancelroomfee", RoomFeeIDs: JSON.stringify(feeidarry), stoptime: stoptime };
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/FeeCenterHandler.ashx',
                data: options,
                success: function (data) {
                    MaskUtil.unmask();
                    if (data.status == 1) {
                        show_message("清除成功", "success", function () {
                            do_close();
                        });
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
    <style type="text/css">
        .panel-body {
            background: #f0f0f0;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <form id="ff" method="post">
        <div class="operation_box">
            <a href="javascript:void(0)" onclick="stopfee()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-tingyong'">停用</a>
            <a href="javascript:void(0)" onclick="clearfee()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-tingyong'">清除停用</a>
            <a href="javascript:void(0)" onclick="do_close()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-close'">关闭</a>
        </div>
        <div class="table_container">
            <table class="info">
                <tr>
                    <td style="width: 35%; text-align: right;">计费停用日期
                    </td>
                    <td style="width: 65%; text-align: left;">
                        <input id="starttime" type="text" class="easyui-datebox" data-options="required:true" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</asp:Content>
