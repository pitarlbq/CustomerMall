<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="EditWechatContact.aspx.cs" Inherits="Web.Wechat.EditWechatContact" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        var AddMan, hdProjectIDs, ID, type, tdPhoneType;
        $(function () {
            AddMan = "<%=Web.WebUtil.GetUser(this.Context).RealName%>";
            hdProjectIDs = $('#<%=this.hdProjectIDs.ClientID%>');
            ID = "<%=Request.QueryString["ID"]%>";
            type = "<%=this.type%>";
            tdPhoneType = $("#<%=this.tdPhoneType.ClientID%>");
            getwechatprojects();
            set_combobox();
            if (type != '') {
                $('#btn_add_category').hide();
            }
        })
        function set_combobox() {
            var options = { visit: 'getwechatcontactcategorylist', type: type };
            $.ajax({
                type: 'POST',
                dataType: 'json',
                data: options,
                url: "../Handler/WechatHandler.ashx",
                success: function (data) {
                    if (data.status) {
                        $(tdPhoneType).combobox({
                            data: data.list,
                            editable: false,
                            valueField: 'ID',
                            textField: 'Name'
                        })
                    }
                }
            });
        }
        function getwechatprojects() {
            MaskUtil.mask('body', '加载中');
            var options = { visit: 'getwechatprojects', ProjectIDs: hdProjectIDs.val() };
            $.ajax({
                type: 'POST',
                dataType: 'json',
                data: options,
                url: "../Handler/WechatHandler.ashx",
                success: function (data) {
                    MaskUtil.unmask();
                    if (data.status) {
                        $('#tdProjects').textbox('setValue', data.namestr);
                    } else {
                        show_message('系统错误', 'error');
                    }
                }
            });
        }
        var isupdate = false;
        function chooseproject() {
            isupdate = false;
            var iframe = "../Wechat/ConnectContactPhoneRoom.aspx?ContactID=" + ID;
            do_open_dialog('选择发布范围', iframe);
        }
        function do_save() {
            var isValid = $("#<%=this.ff.ClientID%>").form('enableValidation').form('validate');
            if (!isValid) {
                return;
            }
            var Name = $("#<%=this.tdName.ClientID%>").textbox("getValue");
            var PhoneNumber = $("#<%=this.tdPhoneNumber.ClientID%>").textbox("getValue");
            var Remark = $("#<%=this.tdRemark.ClientID%>").textbox("getValue");
            var PhoneType = tdPhoneType.combobox("getValue");
            var options = {};
            options.visit = "savewechatcontact";
            options.ID = ID;
            options.Name = Name;
            options.PhoneNumber = PhoneNumber;
            options.Remark = Remark;
            options.PhoneType = PhoneType;
            options.AddMan = AddMan;
            options.ProjectIDs = hdProjectIDs.val();
            options.type = type;
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
                    }
                    else {
                        show_message('系统错误', 'error');
                    }
                }
            });
        }
        function do_close() {
            parent.do_close_dialog(function () {
                parent.$("#tt_table").datagrid("reload");
            });
        }
        function do_add_category() {
            var iframe = "../Wechat/WechatContactCategoryMgr.aspx";
            do_open_dialog('便民电话分类', iframe);
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
                    <td>类型
                    </td>
                    <td>
                        <input class="easyui-combobox" runat="server" id="tdPhoneType" data-options="required:true,editable:false" />
                        <a id="btn_add_category" href="javascript:void(0)" onclick="do_add_category()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-add'"></a>
                        <%--<option value="fuwu">服务中心电话</option>
                            <option value="bianmin">便民电话</option>
                            <option value="tongyi">全国统一电话</option>
                            <option value="hujiaowuye">呼叫物业</option>--%>
                    </td>
                </tr>
                <tr>
                    <td>名称
                    </td>
                    <td>
                        <input class="easyui-textbox" id="tdName" runat="server" data-options="required:true" />
                    </td>
                </tr>
                <tr>
                    <td>电话
                    </td>
                    <td>
                        <input class="easyui-textbox" id="tdPhoneNumber" runat="server" data-options="required:true" />
                    </td>
                </tr>
                <tr>
                    <td>发布范围</td>
                    <td colspan="3">
                        <input type="text" class="easyui-textbox" id="tdProjects" data-options="multiline:true,readonly:true" style="height: 50px; width: 80%;" />
                        <asp:HiddenField runat="server" ID="hdProjectIDs" />
                        <label>
                            <a href="javascript:void(0)" onclick="chooseproject()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-choose'">选择</a>
                        </label>
                    </td>
                </tr>
                <tr>
                    <td>备注
                    </td>
                    <td>
                        <input type="text" class="easyui-textbox" id="tdRemark" runat="server" data-options="multiline:true" style="height: 100px; width: 100%;" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</asp:Content>
