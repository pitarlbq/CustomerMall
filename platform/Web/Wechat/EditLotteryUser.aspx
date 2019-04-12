<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="EditLotteryUser.aspx.cs" Inherits="Web.Wechat.EditLotteryUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        var ID, ActivityID;
        $(function () {
            ID = "<%=this.ID%>";
            ActivityID = "<%=this.ActivityID%>";
        });
        function do_save() {
            var isValid = $("#<%=this.ff.ClientID%>").form('enableValidation').form('validate');
            if (!isValid) {
                return;
            }
            MaskUtil.mask('body', '提交中');
            $('#ff').form('submit', {
                url: '../Handler/WechatHandler.ashx',
                onSubmit: function (param) {
                    param.visit = 'savelotteryuser';
                    param.ID = ID;
                    param.ActivityID = ActivityID;
                },
                success: function (data) {
                    MaskUtil.unmask();
                    var dataObj = eval("(" + data + ")");
                    if (dataObj.status) {
                        ID = dataObj.ID;
                        show_message('保存成功', 'success', function () {
                            do_close();
                        });
                        return;
                    }
                    show_message('系统错误', 'error');
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
    <form id="ff" runat="server" method="post" enctype="multipart/form-data">
        <div class="operation_box">
            <a href="javascript:void(0)" onclick="do_save()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-save'">保存</a>
            <a href="javascript:void(0)" onclick="do_close()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-close'">关闭</a>
        </div>
        <div class="table_container">
            <table class="info">
                <tr>
                    <td>客户姓名
                    </td>
                    <td colspan="3">
                        <input type="text" class="easyui-textbox" id="tdCustomerName" runat="server" data-options="required:true" />
                    </td>
                </tr>
                <tr>
                    <td>手机号码
                    </td>
                    <td colspan="3">
                        <input type="text" class="easyui-textbox" id="tdPhoneNumber" runat="server" data-options="required:true" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</asp:Content>
