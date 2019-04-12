<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="BusinessUserEdit.aspx.cs" Inherits="Web.Mall.BusinessUserEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        var op, UserID, hdCustomerName, BusinessID;
        $(function () {
            hdCustomerName = $('#<%=this.hdCustomerName.ClientID%>');
            UserID = "<%=this.UserID%>";
            BusinessID = "<%=this.BusinessID%>";
            setTimeout(function () {
                $("#<%=this.tdCustomerName.ClientID%>").textbox("setText", hdCustomerName.val());
                $("#<%=this.tdCustomerName.ClientID%>").textbox("setValue", hdCustomerName.val());
                $("#tdPassword").textbox("setText", '');
                $("#tdPassword").textbox("setValue", '');
            }, 100);
        });
        function saveResource() {
            var isValid = $("#<%=this.ff.ClientID%>").form('enableValidation').form('validate');
            if (!isValid) {
                return;
            }
            var LoginName = $("#<%=this.tdLoginName.ClientID%>").textbox("getValue");
            var Password = $("#tdPassword").textbox("getValue");
            var RePwd = $("#tdRePassword").textbox("getValue");
            if (Password != RePwd && Password != '') {
                show_message("两次密码不一致", "info");
                return;
            }
            var RealName = $("#<%=this.tdCustomerName.ClientID%>").textbox("getValue");
            var PhoneNumber = $("#<%=this.tdPhoneNumber.ClientID%>").textbox("getValue");
            var Gender = $("#<%=this.tdGender.ClientID%>").combobox("getValue");
            var IsLocked = $("#<%=this.tdIsLocked.ClientID%>").combobox("getValue");
            var options = { visit: 'savebusinessuserinfo', UserID: UserID, BusinessID: BusinessID, RealName: RealName, NickName: RealName, PhoneNumber: PhoneNumber, Gender: Gender, IsLocked: IsLocked, LoginName: LoginName, Password: Password };
            MaskUtil.mask('body', '提交中');
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/UserHandler.ashx',
                data: options,
                success: function (message) {
                    MaskUtil.unmask();
                    if (message.status) {
                        show_message('保存成功', 'success', function () {
                            closeWin();
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
        function closeWin() {
            parent.do_close_dialog(function () {
                parent.$("#tt_table").datagrid("reload");
            }, true);
        }
    </script>
    <style type="text/css">
        .panel-body {
            background: #f0f0f0;
        }

        .hidefield {
            display: none;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <form id="ff" runat="server">
        <div class="operation_box">
            <a href="javascript:void(0)" onclick="saveResource()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-save'">保存</a>
            <a href="javascript:void(0)" onclick="closeWin()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-save'">关闭</a>
        </div>
        <div class="table_container">
            <table class="info">
                <tr>
                    <td>登录名
                    </td>
                    <td>
                        <input type="text" class="easyui-textbox" id="tdLoginName" runat="server" data-options="required:true" />
                    </td>
                    <td>姓名
                    </td>
                    <td>
                        <input type="text" class="easyui-textbox" id="tdCustomerName" runat="server" name="CustomerName" data-options="required:true" />
                        <asp:HiddenField runat="server" ID="hdCustomerName" />
                    </td>
                </tr>
                <tr>
                    <td>密码
                    </td>
                    <td>
                        <input id="tdPassword" name="pwd" type="password" class="easyui-textbox" />
                        <asp:HiddenField ID="hdPwd" runat="server" />
                    </td>
                    <td>确认密码
                    </td>
                    <td>
                        <input id="tdRePassword" name="rpwd" type="password" class="easyui-textbox" />
                    </td>
                </tr>
                <tr>
                    <td>联系电话
                    </td>
                    <td>
                        <input type="text" class="easyui-textbox" style="" id="tdPhoneNumber" runat="server" />
                    </td>
                    <td>性别
                    </td>
                    <td>
                        <select id="tdGender" style="width: 200px;" runat="server" class="easyui-combobox">
                            <option value="男">男</option>
                            <option value="女">女</option>
                        </select>
                    </td>
                </tr>
                <tr>
                    <td>是否有效
                    </td>
                    <td colspan="3">
                        <select id="tdIsLocked" style="width: 200px;" runat="server" class="easyui-combobox">
                            <option value="0">正常</option>
                            <option value="1">失效</option>
                        </select>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</asp:Content>
