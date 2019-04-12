<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="BusinessRequestDiscountApprove.aspx.cs" Inherits="Web.Mall.BusinessRequestDiscountApprove" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        var ID, filecount = 0;
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
                    param.visit = 'approverequestdiscount';
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
                parent.$("#tt_table").datagrid("reload");
            }, true);
        }
    </script>
    <script src="../js/Page/Mall/Business/BusinessRequestDiscountEdit.js?t=<%=base.getToken() %>"></script>
    <style>
        .image_box {
            width: 100px;
            display: inline-block;
            margin-right: 10px;
            text-align: center;
        }

            .image_box img {
                width: 100%;
            }

        .panel-body {
            background: #f0f0f0;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <form id="ff" runat="server" method="post" enctype="multipart/form-data">
        <div class="operation_box">
            <%if (this.Status == 1)
              { %>
            <a href="javascript:void(0)" onclick="do_save(2)" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-save'">审核通过</a>
            <a href="javascript:void(0)" onclick="do_save(3)" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-save'">审核不通过</a>
            <%} %>
            <a href="javascript:void(0)" onclick="do_close()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-close'">关闭</a>
        </div>
        <div class="table_container">
            <table class="info">
                <tr>
                    <td>审核人</td>
                    <td>
                        <input type="text" class="easyui-textbox" runat="server" id="tdApproveMan" data-options="readonly:true" /></td>
                    <td>审核时间</td>
                    <td>
                        <input type="text" class="easyui-textbox" runat="server" id="tdApproveTime" data-options="readonly:true" /></td>
                </tr>
                <tr>
                    <td>审核备注</td>
                    <td colspan="3">
                        <input type="text" id="tdApproveRemark" runat="server" class="easyui-textbox" data-options="multiline:true" style="width: 85%; height: 50px;" />
                    </td>
                </tr>
            </table>
            <table class="info">
                <tr>
                    <td>申请人</td>
                    <td>
                        <label runat="server" id="labelAddUserMan"></label>
                    </td>
                    <td>申请时间
                    </td>
                    <td>
                        <label runat="server" id="labelAddTime"></label>
                    </td>
                </tr>
                <tr>
                    <td>商家名称</td>
                    <td colspan="3">
                        <label runat="server" id="labelBusinessName"></label>
                    </td>
                </tr>
                <tr>
                    <td>备注信息
                    </td>
                    <td colspan="3">
                        <label runat="server" id="labelRequestContent"></label>
                    </td>
                </tr>
            </table>
            <div class="easyui-panel" style="height: 300px;">
                <table id="tt_table"></table>
            </div>
        </div>
    </form>
</asp:Content>
