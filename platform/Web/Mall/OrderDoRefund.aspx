<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="OrderDoRefund.aspx.cs" Inherits="Web.Mall.OrderDoRefund" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        var ID;
        $(function () {
            ID = "<%=this.OrderID%>";
        });
        function do_save() {
            var isValid = $("#<%=this.ff.ClientID%>").form('enableValidation').form('validate');
            if (!isValid) {
                return;
            }
            if (ID <= 0) {
                show_message("请至少选择一条数据进行此操作", "info");
                return;
            }
            MaskUtil.mask('body', '提交中');
            $('#ff').form('submit', {
                url: '../Handler/MallHandler.ashx',
                onSubmit: function (param) {
                    param.visit = 'savemallorderrefund';
                    param.ID = ID;
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
                parent.content.getdata();
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
            <%if (this.Status == 6)
              { %>
            <a href="javascript:void(0)" onclick="do_save()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-save'">确认退款</a>
            <%} %>
            <a href="javascript:void(0)" onclick="do_close()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-close'">关闭</a>
        </div>
        <div class="table_container">
            <table class="info">
                <tr>
                    <td>订单金额
                    </td>
                    <td colspan="3">
                        <label runat="server" id="tdOrderTotalCost"></label>
                    </td>
                </tr>
                <tr>
                    <td>付款方式
                    </td>
                    <td colspan="3">
                        <label runat="server" id="tdOrderPaymentMethod"></label>
                    </td>
                </tr>
                <tr>
                    <td>申请退款时间</td>
                    <td colspan="3">
                        <label runat="server" id="tdRefundTime"></label>
                    </td>
                </tr>
                <tr>
                    <td>申请退款理由</td>
                    <td colspan="3">
                        <label runat="server" id="tdRefundReason"></label>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</asp:Content>
