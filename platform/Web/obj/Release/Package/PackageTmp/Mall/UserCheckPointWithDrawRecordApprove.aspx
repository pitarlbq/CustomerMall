<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="UserCheckPointWithDrawRecordApprove.aspx.cs" Inherits="Web.Mall.UserCheckPointWithDrawRecordApprove" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        var ID;
        $(function () {
            ID = "<%=this.ID%>";
        });
        function do_save(status) {
            var isValid = $("#<%=this.ff.ClientID%>").form('enableValidation').form('validate');
            if (!isValid) {
                return;
            }
            MaskUtil.mask('body', '提交中');
            $('#ff').form('submit', {
                url: '../Handler/MallHandler.ashx',
                onSubmit: function (param) {
                    param.visit = 'approvecheckpointwithdraw';
                    param.ID = ID;
                    param.Status = status;
                },
                success: function (data) {
                    MaskUtil.unmask();
                    var dataObj = eval("(" + data + ")");
                    if (dataObj.status) {
                        show_message('操作成功', 'success', function () {
                            do_close();
                        });
                        return;
                    }
                    if (dataObj.error) {
                        show_message(dataObj.error, 'warning');
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
    <style>
        .panel-body {
            background: #f0f0f0;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <form id="ff" runat="server" method="post" enctype="multipart/form-data">
        <div class="operation_box">
            <%if (this.CanApprove)
              { %>
            <a href="javascript:void(0)" onclick="do_save(1)" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-shenhe'">通过</a>
            <a href="javascript:void(0)" onclick="do_save(3)" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-shenhe'">不通过</a>
            <%} %>
            <a href="javascript:void(0)" onclick="do_close()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-close'">关闭</a>
        </div>
        <div class="table_container">
            <table class="info">
                <tr>
                    <td>申请人</td>
                    <td>
                        <label runat="server" id="tdAddUserName"></label>
                    </td>
                    <td>申请时间</td>
                    <td>
                        <label runat="server" id="tdAddTime"></label>
                    </td>
                </tr>
                <tr>
                    <td>提现岗位积分</td>
                    <td>
                        <label runat="server" id="tdPointValue"></label>
                    </td>
                    <td>状态</td>
                    <td>
                        <label runat="server" id="tdStatus"></label>
                    </td>
                </tr>
                <tr>
                    <td>审核人</td>
                    <td>
                        <label runat="server" id="tdApproveUserName"></label>
                    </td>
                    <td>审核时间</td>
                    <td>
                        <label runat="server" id="tdApproveTime"></label>
                    </td>
                </tr>
                <tr>
                    <td>审核备注</td>
                    <td colspan="3">
                        <input type="text" runat="server" id="tdApproveRemark" class="easyui-textbox" data-options="multiline:true" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</asp:Content>
