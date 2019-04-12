<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="UserEdit.aspx.cs" Inherits="Web.APPSetup.UserEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        var op, hdOpenID, UserID, hdCustomerName, hdIsAllowSysLogin, hdIsAllowAPPUserLogin, tdDepartment, type, tdUserType;
        $(function () {
            hdCustomerName = $('#<%=this.hdCustomerName.ClientID%>');
            hdIsAllowSysLogin = $('#<%=this.hdIsAllowSysLogin.ClientID%>');
            hdIsAllowAPPUserLogin = $('#<%=this.hdIsAllowAPPUserLogin.ClientID%>');
            tdDepartment = $('#<%=this.tdDepartment.ClientID%>');
            UserID = "<%=this.UserID%>";
            type = "<%=this.type%>";
            tdUserType = $('#<%=this.tdUserType.ClientID%>');
            setTimeout(function () {
                $("#<%=this.tdNickName.ClientID%>").textbox("setText", hdCustomerName.val());
                $("#<%=this.tdNickName.ClientID%>").textbox("setValue", hdCustomerName.val());
                $("#tdPassword").textbox("setText", '');
                $("#tdPassword").textbox("setValue", '');
            }, 100);
            get_combobox_params();
            $('.sysuser_box').hide();
            if (type == 2) {
                $('.sysuser_box').show();
            }
        });
        function get_combobox_params() {
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/MallHandler.ashx',
                data: { visit: 'getusereditparams' },
                success: function (data) {
                    if (data.status) {
                        tdDepartment.combobox({
                            editable: false,
                            valueField: "ID",
                            textField: "Name",
                            data: data.departments
                        })
                    }
                }
            });
            var type_list = [];
            var default_value = '';
            if (type == 2) {
                type_list.push({ ID: "APPUser", Name: "员工APP用户" });
                default_value = 'APPUser';
            } else {
                type_list.push({ ID: "APPCustomer", Name: "业主APP用户" });
                default_value = 'APPCustomer';
            }
            tdUserType.combobox({
                editable: false,
                valueField: "ID",
                textField: "Name",
                data: type_list
            })
            if (tdUserType.combobox('getValue') == '') {
                tdUserType.combobox('setValue', default_value);
            }
        }
        function do_save() {
            var isValid = $("#<%=this.ff.ClientID%>").form('enableValidation').form('validate');
            if (!isValid) {
                return;
            }
            var LoginName = $("#<%=this.tdLoginName.ClientID%>").textbox("getValue");
            var Password = $("#tdPassword").textbox("getValue");
            var RePwd = $("#tdRePassword").textbox("getValue");
            if (Password != RePwd && Password != '') {
                show_message('两次密码不一致，操作取消', 'warning');
                return;
            }
            var RealName = $("#<%=this.tdNickName.ClientID%>").textbox("getValue");
            var PhoneNumber = $("#<%=this.tdPhoneNumber.ClientID%>").textbox("getValue");
            var Gender = $("#<%=this.tdGender.ClientID%>").combobox("getValue");
            var IsLocked = $("#<%=this.tdIsLocked.ClientID%>").combobox("getValue");
            var UserType = $("#<%=this.tdUserType.ClientID%>").combobox("getValue");
            var IsAllowAPPUserLogin = hdIsAllowAPPUserLogin.val();
            var IsAllowSysLogin = hdIsAllowSysLogin.val();
            var PositionName = $("#<%=this.tdPositionName.ClientID%>").textbox("getValue");
            var Education = $("#<%=this.tdEducation.ClientID%>").combobox("getValue");
            var DepartmentID = $("#<%=this.tdDepartment.ClientID%>").combobox("getValue");
            var FixedPoint = $("#<%=this.tdFixedPoint.ClientID%>").textbox("getValue");
            var FixedPointUpdateDate = $('#<%=this.tdFixedPointUpdateDate.ClientID%>').datebox('getValue');
            var IsAllowPhrase = $('#<%=this.tdIsAllowPhrase.ClientID%>').combobox('getValue');

            var options = { visit: 'saveuserinfo', UserID: UserID, RealName: RealName, NickName: RealName, PhoneNumber: PhoneNumber, Gender: Gender, IsLocked: IsLocked, LoginName: LoginName, Password: Password, UserType: UserType, IsAllowAPPUserLogin: IsAllowAPPUserLogin, IsAllowSysLogin: IsAllowSysLogin, PositionName: PositionName, DepartmentID: DepartmentID, Education: Education, FixedPoint: FixedPoint, FixedPointUpdateDate: FixedPointUpdateDate, IsAllowPhrase: IsAllowPhrase, user_type: type };
            MaskUtil.mask('body', '提交中');
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/UserHandler.ashx',
                data: options,
                success: function (message) {
                    MaskUtil.unmask();
                    if (message.status) {
                        if (message.addfailed) {
                            show_message('添加失败,授权用户数已达上限', 'warning', function () {
                                do_close();
                            });
                            return;
                        }
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

        table.info td input[type=text], table.info td select, table.info td input[type=password] {
            width: 25%;
        }

        .hidefield {
            display: none;
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
                    <td>登录名
                    </td>
                    <td>
                        <input type="text" class="easyui-textbox" id="tdLoginName" runat="server" data-options="required:true" />
                    </td>
                    <td>姓名
                    </td>
                    <td>
                        <input type="text" class="easyui-textbox" id="tdNickName" runat="server" data-options="required:true" />
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
                        <select id="tdGender" runat="server" data-options="editable:false" class="easyui-combobox">
                            <option value="男">男</option>
                            <option value="女">女</option>
                        </select>
                    </td>
                </tr>
                <tr>
                    <td>是否有效
                    </td>
                    <td>
                        <select id="tdIsLocked" runat="server" data-options="editable:false" class="easyui-combobox">
                            <option value="0">正常</option>
                            <option value="1">失效</option>
                        </select></td>
                    <td style="display: none;">用户性质
                    </td>
                    <td style="display: none;">
                        <input id="tdUserType" type="text" runat="server" class="easyui-combobox" data-options="editable:false" />
                        <asp:HiddenField runat="server" ID="hdIsAllowSysLogin" />
                        <asp:HiddenField runat="server" ID="hdIsAllowAPPUserLogin" />
                    </td>
                </tr>
                <tr class="sysuser_box">
                    <td>岗位名称</td>
                    <td>
                        <input type="text" class="easyui-textbox" runat="server" id="tdPositionName" />
                    </td>
                    <td>所属部门</td>
                    <td>
                        <input class="easyui-combobox" runat="server" data-options="editable:false" id="tdDepartment" />
                    </td>
                </tr>
                <tr class="sysuser_box">
                    <td>固定积分
                    </td>
                    <td>
                        <input type="text" class="easyui-textbox" runat="server" id="tdFixedPoint" />
                    </td>
                    <td>上次固定积分发放时间</td>
                    <td>
                        <input type="text" class="easyui-datebox" runat="server" id="tdFixedPointUpdateDate" />
                    </td>
                </tr>
                <tr class="sysuser_box">
                    <td>学历
                    </td>
                    <td>
                        <select runat="server" data-options="editable:false" id="tdEducation" class="easyui-combobox">
                            <option value="本科">本科</option>
                            <option value="硕士">硕士</option>
                            <option value="博士">博士</option>
                            <option value="大专">大专</option>
                            <option value="中专">中专</option>
                            <option value="小学">小学</option>
                            <option value="初中">初中</option>
                            <option value="高中">高中</option>
                            <option value="其他">其他</option>
                        </select>
                    </td>
                    <td>允许被点赞
                    </td>
                    <td>
                        <select id="tdIsAllowPhrase" runat="server" data-options="editable:false" class="easyui-combobox">
                            <option value="1">允许</option>
                            <option value="0">不允许</option>
                        </select>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</asp:Content>
