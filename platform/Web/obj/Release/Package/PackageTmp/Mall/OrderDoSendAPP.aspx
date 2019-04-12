<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="OrderDoSendAPP.aspx.cs" Inherits="Web.Mall.OrderDoSendAPP" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        var ID, tdAccpetUsers, hdUserIDList, tdSendType;
        $(function () {
            ID = "<%=this.OrderID%>";
            tdAccpetUsers = $('#<%=this.tdAccpetUsers.ClientID%>');
            hdUserIDList = $('#<%=this.hdUserIDList.ClientID%>');
            tdSendType = $('#<%=this.tdSendType.ClientID%>');
            getparams();
            tdSendType.combobox({
                editable: false,
                onSelect: function () {
                    check_status();
                }
            })
            check_status();
        });
        function check_status() {
            var send_type = tdSendType.combobox('getValue');
            if (send_type == 1) {
                $('#tr_userdata').show();
            } else {
                $('#tr_userdata').hide();
            }
        }
        function getparams() {
            var options = { visit: 'getdoordersendappparams' };
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/MallHandler.ashx',
                data: options,
                success: function (message) {
                    if (message.status) {
                        tdAccpetUsers.combobox({
                            editable: false,
                            multiple: true,
                            valueField: 'ID',
                            textField: 'Name',
                            data: message.list,
                            onSelect: function () {
                                var value = tdAccpetUsers.combobox('getValues');
                                hdUserIDList.val(JSON.stringify(value));
                            },
                            onUnselect: function () {
                                var value = tdAccpetUsers.combobox('getValues');
                                hdUserIDList.val(JSON.stringify(value));
                            }
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
                    param.visit = 'savemallordersendapp';
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
            <a href="javascript:void(0)" onclick="do_save()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-save'">派单</a>
            <%} %>
            <a href="javascript:void(0)" onclick="do_close()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-close'">关闭</a>
        </div>
        <div class="table_container">
            <table class="info">
                <tr>
                    <td>类型</td>
                    <td colspan="3">
                        <select id="tdSendType" runat="server" class="easyui-combobox">
                            <option value="1">派单</option>
                            <option value="2">抢单</option>
                        </select>
                    </td>
                </tr>
                <tr id="tr_userdata">
                    <td>接单人员
                    </td>
                    <td colspan="3">
                        <input type="text" class="easyui-combobox" runat="server" id="tdAccpetUsers" style="width: 300px;" />
                        <asp:HiddenField runat="server" ID="hdUserIDList" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</asp:Content>
