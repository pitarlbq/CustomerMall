<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="OrderDoShip.aspx.cs" Inherits="Web.Mall.OrderDoShip" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        var ID, tdShipCompany;
        $(function () {
            ID = "<%=this.OrderID%>";
            tdShipCompany = $('#<%=this.tdShipCompany.ClientID%>');
            getparams();
        });
        function getparams() {
            var options = { visit: 'getdoordershipparams' };
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/MallHandler.ashx',
                data: options,
                success: function (message) {
                    if (message.status) {
                        tdShipCompany.combobox({
                            editable: false,
                            valueField: 'Name',
                            textField: 'Name',
                            data: message.ship_list
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
            var can_send = true;
            $.each(rows, function (index, row) {
                if (row.OrderStatus != 5 && row.OrderStatus != 2) {
                    can_send = false;
                    return false;
                }
                IDList.push(row.OrderID);
            })
            if (!can_send) {
                show_message("请选择待发货状态订单", "info");
                return;
            }
            MaskUtil.mask('body', '提交中');
            $('#ff').form('submit', {
                url: '../Handler/MallHandler.ashx',
                onSubmit: function (param) {
                    param.visit = 'savemallordership';
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
            <%if (this.Status == 2 || this.Status == 5 || this.Status == 0)
              { %>
            <a href="javascript:void(0)" onclick="do_save()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-save'">保存</a>
            <%} %>
            <a href="javascript:void(0)" onclick="do_close()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-close'">关闭</a>
        </div>
        <div class="table_container">
            <table class="info">
                <tr>
                    <td>发货公司
                    </td>
                    <td colspan="3">
                        <input type="text" class="easyui-combobox" runat="server" id="tdShipCompany" data-options="required:true" /></td>
                </tr>
                <tr>
                    <td>运单号</td>
                    <td colspan="3">
                        <input type="text" class="easyui-textbox" runat="server" id="tdShipTrackNo" /></td>
                </tr>
                <tr>
                    <td>发货时间
                    </td>
                    <td colspan="3">
                        <input type="text" class="easyui-datetimebox" runat="server" id="tdShipTime" /></td>
                </tr>
                <tr>
                    <td>发货人
                    </td>
                    <td colspan="3">
                        <input type="text" class="easyui-textbox" runat="server" id="tdShipUserName" /></td>
                </tr>
                <tr>
                    <td>配送人
                    </td>
                    <td colspan="3">
                        <input type="text" class="easyui-textbox" runat="server" id="tdShipDelivererName" /></td>
                </tr>
            </table>
        </div>
    </form>
</asp:Content>
