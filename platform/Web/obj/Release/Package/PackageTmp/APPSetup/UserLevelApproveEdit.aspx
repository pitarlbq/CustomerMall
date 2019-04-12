<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="UserLevelApproveEdit.aspx.cs" Inherits="Web.APPSetup.UserLevelApproveEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        var ID, tdUserName, hdRelationID, hdUserID, tdUserLevelID;
        $(function () {
            ID = "<%=this.ApproveID%>";
            tdUserName = $('#<%=this.tdUserName.ClientID%>');
            hdRelationID = $('#<%=this.hdRelationID.ClientID%>');
            hdUserID = $('#<%=this.hdUserID.ClientID%>');
            tdUserLevelID = $('#<%=this.tdUserLevelID.ClientID%>');
            get_params();
            tdUserName.textbox('setValue', $('#<%=this.hdUserName.ClientID%>').val());
        })
        function get_params() {
            var options = { visit: 'getuserlevelapproveeditparam' };
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/MallHandler.ashx',
                data: options,
                success: function (message) {
                    if (message.status) {
                        tdUserLevelID.combobox({
                            editable: false,
                            valueField: 'id',
                            textField: 'value',
                            data: message.list
                        })
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
        function do_save() {
            var isValid = $("#<%=this.ff.ClientID%>").form('enableValidation').form('validate');
            if (!isValid) {
                return;
            }
            MaskUtil.mask('body', '提交中');
            $('#ff').form('submit', {
                url: '../Handler/MallHandler.ashx',
                onSubmit: function (param) {
                    param.visit = 'saveapprovemalluserlevel';
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
        function choose_user() {
            var iframe = "../APPSetup/ChooseProjectUser.aspx?singleselect=1";
            do_open_dialog('选择用户', iframe);
        }
    </script>
    <style type="text/css">
        .panel-body {
            background: #f0f0f0;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <form id="ff" runat="server" method="post" enctype="multipart/form-data">
        <div class="operation_box">
            <a href="javascript:void(0)" onclick="do_save()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-save'">保存</a>
            <a href="javascript:void(0)" onclick="do_close()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-close'">关闭</a>
        </div>
        <div class="table_container">
            <table class="info">
                <tr>
                    <td>申请人
                    </td>
                    <td>
                        <input type="text" class="easyui-textbox" runat="server" id="tdUserName" data-options="multiline:true,editable:false" />
                        <asp:HiddenField runat="server" ID="hdUserName" />
                        <asp:HiddenField runat="server" ID="hdUserID" />
                        <asp:HiddenField runat="server" ID="hdRelationID" />
                        <a href="javascript:void(0)" onclick="choose_user()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-choose'">选择</a>

                    </td>
                    <td>合伙人等级
                    </td>
                    <td>
                        <input id="tdUserLevelID" runat="server" class="easyui-combobox" data-options="editable:false" />
                    </td>
                </tr>
                <tr>
                    <td>充值金额
                    </td>
                    <td>
                        <input type="text" class="easyui-textbox" runat="server" id="tdIncomingAmount" />
                    </td>
                    <td>充值方式
                    </td>
                    <td>
                        <select id="tdIncomingType" runat="server" class="easyui-combobox" data-options="editable:false">
                            <option value="现金">现金</option>
                            <option value="刷卡">刷卡</option>
                            <option value="转账">转账</option>
                            <option value="赠送">赠送</option>
                            <option value="微信支付">微信支付</option>
                            <option value="支付宝支付">支付宝支付</option>
                            <option value="其他">其他</option>
                        </select>
                    </td>
                </tr>
                <tr>
                    <td>充值时间
                    </td>
                    <td>
                        <input type="text" class="easyui-datetimebox" runat="server" id="tdIncomingTime" />
                    </td>
                    <td>经办人
                    </td>
                    <td>
                        <input type="text" class="easyui-textbox" runat="server" id="tdDealManName" />
                    </td>
                </tr>
                <tr>
                    <td>证明材料</td>
                    <td colspan="3">
                        <%if (!string.IsNullOrEmpty(this.FilePath))
                          { %>
                        <div class="file_box">
                            <a target="_blank" href="<%=this.FilePath %>">下载</a>
                        </div>
                        <%} %>
                        <input class="easyui-filebox" name="attachfile" data-options="prompt:'请选择文件',buttonText: '选择文件'" style="width: 60%" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</asp:Content>
