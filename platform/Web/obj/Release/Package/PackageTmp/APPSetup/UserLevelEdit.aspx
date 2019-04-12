<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="UserLevelEdit.aspx.cs" Inherits="Web.APPSetup.UserLevelEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function do_save() {
            var isValid = $("#<%=this.ff.ClientID%>").form('enableValidation').form('validate');
            if (!isValid) {
                return;
            }
            var ID = "<%=this.LevelID%>";
            MaskUtil.mask('body', '提交中');
            $('#ff').form('submit', {
                url: '../Handler/MallHandler.ashx',
                onSubmit: function (param) {
                    param.visit = 'savemalluserlevel';
                    param.ID = ID;
                },
                success: function (data) {
                    MaskUtil.unmask();
                    var dataObj = eval("(" + data + ")");
                    if (dataObj.status) {
                        show_message('保存成功', 'success', function () {
                            do_close();
                        });
                        return;
                    }
                    if (dataObj.error) {
                        show_message(dataObj.error, 'warning');
                        return;
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
                    <td>等级名称
                    </td>
                    <td colspan="3">
                        <input class="easyui-textbox" id="tdName" runat="server" data-options="required:true" />
                    </td>
                </tr>
                <tr>
                    <td>等级描述
                    </td>
                    <td colspan="3">
                        <input class="easyui-textbox" id="tdRemark" data-options="multiline:true" runat="server" style="height: 60px;" />
                    </td>
                </tr>
                <tr>
                    <td>生效金额区间</td>
                    <td colspan="3">
                        <input type="text" runat="server" id="tdStartAmount" class="easyui-textbox" />(含)
                    -
                    <input type="text" runat="server" id="tdEndAmount" class="easyui-textbox" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</asp:Content>
