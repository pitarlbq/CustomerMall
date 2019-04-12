<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="EditTaiZhang.aspx.cs" Inherits="Web.GongTan.EditTaiZhang" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        function do_save() {
            var options = {};
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/ImportFeeHandler.ashx',
                data: options,
                success: function (message) {
                    if (message.status) {
                        show_message('保存成功', 'success', function () {
                            do_close()
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
                <td>房间名称</td>
                <td>
                    <input type="text" class="easyui-textbox" id="tdRoomName" data-options="readonly:true" runat="server" /></td>
                <td style="width: 100px;">表种类
                </td>
                <td>
                    <input id="tdBiaoCategory" type="text" class="easyui-combobox" data-options="readonly:true" runat="server" />
                </td>
            </tr>
            <tr>
                <td style="width: 100px;">表名称
                </td>
                <td>
                    <input id="tdBiaoName" type="text" class="easyui-textbox" runat="server" />
                </td>
                <td>表规格</td>
                <td>
                    <select class="easyui-combobox" id="tdBiaoGuiGe" style="width: 200px;" runat="server">
                        <option value="总表">总表</option>
                        <option value="分表">分表</option>
                    </select>
                </td>
            </tr>
            <tr>
                <td>倍率</td>
                <td>
                    <input type="text" class="easyui-textbox" id="tdRate" /></td>
                <td style="width: 100px;">扣减量
                </td>
                <td>
                    <input id="tdReducePoint" type="text" class="easyui-textbox" runat="server" />
                </td>
            </tr>
            <tr>
                <td>系数</td>
                <td>
                    <input type="text" class="easyui-textbox" id="tdCoefficient" /></td>
            </tr>
        </table>
    </div>
</asp:Content>
