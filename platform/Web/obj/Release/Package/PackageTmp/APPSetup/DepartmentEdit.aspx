<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="DepartmentEdit.aspx.cs" Inherits="Web.APPSetup.DepartmentEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function do_save() {
            var isValid = $("#<%=this.ff.ClientID%>").form('enableValidation').form('validate');
            if (!isValid) {
                return;
            }
            var ID = "<%=this.DepartmentID%>";
            var DepartmentName = $("#<%=this.tdDepartmentName.ClientID%>").textbox("getValue");
            var Description = $("#<%=this.tdDescription.ClientID%>").textbox("getValue");
            var SortOrder = $("#<%=this.tdSortOrder.ClientID%>").textbox("getValue");
            var options = { visit: 'savemalldepartment', ID: ID, DepartmentName: DepartmentName, Description: Description, SortOrder: SortOrder };
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
                    <td>部门名称
                    </td>
                    <td colspan="3">
                        <input type="text" class="easyui-textbox" id="tdDepartmentName" runat="server" data-options="required:true" />
                    </td>
                </tr>
                <tr>
                    <td>排序序号
                    </td>
                    <td colspan="3">
                        <input type="text" class="easyui-textbox" id="tdSortOrder" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>描述</td>
                    <td colspan="3">
                        <input class="easyui-textbox" id="tdDescription" name="Description" data-options="multiline:true" runat="server" style="height: 60px; width: 70%;" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</asp:Content>
