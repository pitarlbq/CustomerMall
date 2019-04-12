<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="WechatServiceUserEdit.aspx.cs" Inherits="Web.Wechat.WechatServiceUserEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        var ID, hdUserList, tdUserList, tdWx_Account, can_edit_wx, tdAccountName;
        $(function () {
            ID = '<%=this.ID%>';
            can_edit_wx = '<%=this.can_edit_wx%>';
            hdUserList = $('#<%=this.hdUserList.ClientID%>');
            tdUserList = $('#<%=this.tdUserList.ClientID%>');
            tdWx_Account = $('#<%=this.tdWx_Account.ClientID%>');
            tdAccountName = $('#<%=this.tdAccountName.ClientID%>');
            loadparams();
            if (can_edit_wx == 0) {
                tdWx_Account.textbox({
                    disabled: true
                })
                tdAccountName.textbox({
                    disabled: true
                })
            }
        });
        function loadparams() {
            if (hdUserList.val() == '') {
                return;
            }
            var user_list = eval("(" + hdUserList.val() + ")");
            tdUserList.combobox({
                editable: false,
                data: user_list,
                valueField: "ID",
                textField: "Name"
            })
        }
        function do_save() {
            var isValid = $("#<%=this.ff.ClientID%>").form('enableValidation').form('validate');
            if (!isValid) {
                return;
            }
            var NickName = $("#<%=this.tdNickName.ClientID%>").textbox("getValue");
            var AccountName = $("#<%=this.tdAccountName.ClientID%>").textbox("getValue");
            var Wx_Account = $("#<%=this.tdWx_Account.ClientID%>").textbox("getValue");
            var UserID = $("#<%=this.tdUserList.ClientID%>").combobox("getValue");

            var options = { visit: 'savewechatserviceuser', ID: ID, NickName: NickName, AccountName: AccountName, Wx_Account: Wx_Account, UserID: UserID };
            MaskUtil.mask('body', '提交中');
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/WechatHandler.ashx',
                data: options,
                success: function (message) {
                    MaskUtil.unmask();
                    if (message.status) {
                        show_message('保存成功', 'success', function () {
                            do_close();
                        });
                        return;
                    }
                    if (message.error) {
                        show_message(message.error, 'warning');
                        return;
                    }
                    show_message('系统错误', 'error');
                }
            });
        }
        function do_close() {
            parent.do_close_dialog(function () {
                parent.$("#tt_table").datagrid("reload");
            }, true);
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
                    <td>客服昵称
                    </td>
                    <td>
                        <input type="text" class="easyui-textbox" id="tdNickName" runat="server" data-options="required:true" />
                    </td>
                    <td>客服帐号
                    </td>
                    <td>
                        <input type="text" class="easyui-textbox" id="tdAccountName" runat="server" data-options="required:true" />(新增后不可修改)
                    </td>
                </tr>
                <tr>
                    <td>微信号
                    </td>
                    <td>
                        <input type="text" class="easyui-textbox" id="tdWx_Account" runat="server" data-options="required:true" />(新增后不可修改)
                    </td>
                    <td>关联帐号
                    </td>
                    <td>
                        <input id="tdUserList" class="easyui-combobox" runat="server" />
                        <asp:HiddenField runat="server" ID="hdUserList" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</asp:Content>
