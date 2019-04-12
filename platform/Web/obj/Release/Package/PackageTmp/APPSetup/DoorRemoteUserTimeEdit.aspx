<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="DoorRemoteUserTimeEdit.aspx.cs" Inherits="Web.APPSetup.DoorRemoteUserTimeEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function do_save() {
            var isValid = $("#<%=this.ff.ClientID%>").form('enableValidation').form('validate');
            if (!isValid) {
                return;
            }
            var rows = parent.$('#tt_table').datagrid("getSelections");
            if (rows.length == 0) {
                show_message('请选择需要修改的房间', 'warning');
                return;
            }
            var list = [];
            $.each(rows, function (index, row) {
                var item = { RoomID: row.RoomID, TimeID: row.TimeID };
                list.push(item);
            })
            if (list.length == 0) {
                show_message('请选择需要修改的房间', 'warning');
                return;
            }
            var Enable = $('#<%=this.tdEnable.ClientID%>').combobox('getValue');
            var DelayDate = $('#<%=this.tdDelayDate.ClientID%>').datebox('getValue');
            var options = { visit: 'savedroorremoteusertime', list: JSON.stringify(list), Enable: Enable, DelayDate: DelayDate };
            MaskUtil.mask('body', '提交中');
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/MallHandler.ashx',
                data: options,
                success: function (data) {
                    MaskUtil.unmask();
                    if (data.status) {
                        show_message('保存成功', 'success', function () {
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
    <form id="ff" runat="server">
        <div class="operation_box">
            <a href="javascript:void(0)" onclick="do_save()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-save'">保存</a>
            <a href="javascript:void(0)" onclick="do_close()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-close'">关闭</a>
        </div>
        <div class="table_container">
            <table class="info">
                <tr>
                    <td>是否启用
                    </td>
                    <td colspan="3">
                        <select type="text" class="easyui-combobox" id="tdEnable" runat="server">
                            <option value="1">启用</option>
                            <option value="0">停用</option>
                        </select>
                    </td>
                </tr>
                <tr>
                    <td>延期到
                    </td>
                    <td colspan="3">
                        <input type="text" class="easyui-datebox" id="tdDelayDate" runat="server" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</asp:Content>
