<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="OrderDoChangePrice.aspx.cs" Inherits="Web.Mall.OrderDoChangePrice" %>

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
            var rows = parent.get_selections();
            if (rows.length == 0 && ID <= 0) {
                show_message("请至少选择一条数据进行此操作", "info");
                return;
            }
            var IDList = [];
            var can_change = true;
            $.each(rows, function (index, row) {
                if (row.OrderStatus != 1) {
                    can_change = false;
                    return false;
                }
                IDList.push(row.OrderID);
            })
            if (!can_change) {
                show_message("请选择待付款状态订单", "info");
                return;
            }
            MaskUtil.mask('body', '提交中');
            $('#ff').form('submit', {
                url: '../Handler/MallHandler.ashx',
                onSubmit: function (param) {
                    param.visit = 'savemallordercost';
                    param.ID = ID;
                    param.IDList = JSON.stringify(IDList)
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
            <%if (this.Status == 1 || this.Status == 0)
              { %>
            <a href="javascript:void(0)" onclick="do_save()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-save'">保存</a>
            <%} %>
            <a href="javascript:void(0)" onclick="do_close()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-close'">关闭</a>
        </div>
        <div class="table_container">
            <table class="info">
                <%if (this.Status == 1)
                  { %>
                <tr>
                    <td>原来价格
                    </td>
                    <td colspan="3">
                        <label runat="server" id="tdOriginalTotalCost"></label>
                    </td>
                </tr>
                <%} %>
                <tr>
                    <td>新价格</td>
                    <td colspan="3">
                        <input type="text" class="easyui-textbox" runat="server" id="tdTotalCost" /></td>
                </tr>
            </table>
        </div>
    </form>
</asp:Content>
