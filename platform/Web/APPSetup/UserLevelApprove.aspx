<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="UserLevelApprove.aspx.cs" Inherits="Web.APPSetup.UserLevelApprove" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function do_save(status) {
            var isValid = $("#<%=this.ff.ClientID%>").form('enableValidation').form('validate');
            if (!isValid) {
                return;
            }
            var ID = "<%=this.ApproveID%>";
            MaskUtil.mask('body', '提交中');
            $('#ff').form('submit', {
                url: '../Handler/MallHandler.ashx',
                onSubmit: function (param) {
                    param.visit = 'approvemalluserlevel';
                    param.ID = ID;
                    param.status = status
                },
                success: function (data) {
                    MaskUtil.unmask();
                    var dataObj = eval("(" + data + ")");
                    if (dataObj.status) {
                        show_message("审核成功", "success", function () {
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
            <a href="javascript:void(0)" onclick="do_save(1)" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-save'">通过</a>
            <a href="javascript:void(0)" onclick="do_save(2)" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-save'">不通过</a>
            <a href="javascript:void(0)" onclick="do_close()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-close'">关闭</a>
        </div>
        <div class="table_container">
            <table class="info">
                <tr>
                    <td>申请人
                    </td>
                    <td>
                        <label runat="server" id="label_NickName"></label>
                    </td>
                    <td>申请人电话
                    </td>
                    <td>
                        <label runat="server" id="label_PhoneNumber"></label>
                    </td>
                </tr>
                <tr>
                    <td>申请时间
                    </td>
                    <td>
                        <label runat="server" id="label_RequestTime"></label>
                    </td>
                    <td>合伙人等级
                    </td>
                    <td>
                        <label runat="server" id="label_LevelName"></label>
                    </td>
                </tr>
                <tr>
                    <td>充值金额
                    </td>
                    <td>
                        <label runat="server" id="label_IncomingAmount"></label>
                    </td>
                    <td>充值类型
                    </td>
                    <td>
                        <label runat="server" id="label_IncomingWay"></label>
                    </td>
                </tr>
                <tr>
                    <td>充值时间
                    </td>
                    <td>
                        <label runat="server" id="label_IncomingTime"></label>
                    </td>
                    <td>经办人
                    </td>
                    <td>
                        <label runat="server" id="label_DealManName"></label>
                    </td>
                </tr>
                <%if (!string.IsNullOrEmpty(this.FilePath))
                  { %>
                <tr>
                    <td>证明材料</td>
                    <td>
                        <a target="_blank" href="<%=this.FilePath %>">下载</a>
                    </td>
                </tr>
                <%} %>
                <tr>
                    <td>审核意见</td>
                    <td colspan="3">
                        <input type="text" data-options="multiline:true" style="width: 85%; height: 60px;" runat="server" id="tdApproveRemark" class="easyui-textbox" />
                    </td>
                </tr>
                <tr>
                    <td colspan="4" style="text-align: center;"></td>
                </tr>
            </table>
        </div>
    </form>
</asp:Content>
