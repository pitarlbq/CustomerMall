<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="EditAcceptUser.aspx.cs" Inherits="Web.CangKu.EditAcceptUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function do_save() {
            var isValid = $("#<%=this.ff.ClientID%>").form('enableValidation').form('validate');
            if (!isValid) {
                return;
            }
            var ID = "<%=this.ID%>";
            var AcceptUserName = $("#<%=this.tdAcceptUserName.ClientID%>").textbox("getValue");
            var options = { visit: 'saveckacceptuser', ID: ID, AcceptUserName: AcceptUserName };
            MaskUtil.mask('body', '提交中');
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/CKHandler.ashx',
                data: options,
                success: function (data) {
                    MaskUtil.unmask();
                    if (data.status) {
                        show_message('保存成功', 'success', function () {
                            //try {
                            //    parent.ChosenDepartmentID = data.ID;
                            //} catch (e) {

                            //}
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
                    <td>领用人名称
                    </td>
                    <td colspan="3">
                        <input type="text" class="easyui-textbox" id="tdAcceptUserName" runat="server" data-options="required:true" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</asp:Content>
