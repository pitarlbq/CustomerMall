<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="HotSaleEdit.aspx.cs" Inherits="Web.Mall.HotSaleEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        var ID, tdProductID, tdBusinessID, tdType;
        $(function () {
            ID = "<%=this.SaleID%>";
            tdProductID = $('#<%=this.tdProductID.ClientID%>');
            tdBusinessID = $('#<%=this.tdBusinessID.ClientID%>');
            tdType = $('#<%=this.tdType.ClientID%>');
            get_params();
            do_status_change();
            tdType.combobox({
                onSelect: function () {
                    do_status_change();
                }
            })
        });
        function do_status_change() {
            var value = tdType.combobox('getValue');
            if (value == 1) {
                $('.td_product').show();
                $('.td_business').hide();
            }
            else if (value == 2) {
                $('.td_product').hide();
                $('.td_business').show();
            }
        }
        function get_params() {
            var options = { visit: 'getmallhotsaleeditparams' };
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/MallHandler.ashx',
                data: options,
                success: function (data) {
                    tdProductID.combobox({
                        editable: false,
                        valueField: 'ID',
                        textField: 'Name',
                        data: data.product_list
                    });
                    tdBusinessID.combobox({
                        editable: false,
                        valueField: 'ID',
                        textField: 'Name',
                        data: data.business_list
                    });
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
                    param.visit = 'savemallhotsale';
                    param.ID = ID;
                },
                success: function (data) {
                    MaskUtil.unmask();
                    var dataObj = eval("(" + data + ")");
                    if (dataObj.status) {
                        if (dataObj.ID > 0) {
                            ID = dataObj.ID;
                            show_message('保存成功', 'success', function () {
                                do_close();
                            });
                            return;
                        }
                        show_message('数据不存在或已删除', 'warning');
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
            <a href="javascript:void(0)" onclick="do_save()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-save'">保存</a>
            <a href="javascript:void(0)" onclick="do_close()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-close'">关闭</a>
        </div>
        <div class="table_container">
            <table class="info">
                <tr>
                    <td>类型</td>
                    <td>
                        <select class="easyui-combobox" runat="server" id="tdType" data-options="required:true,editable:false">
                            <option value="1">商品</option>
                            <option value="2">商家</option>
                        </select></td>
                    <td>排序序号
                    </td>
                    <td>
                        <input type="text" class="easyui-textbox" runat="server" id="tdSortOrder" /></td>
                </tr>
                <tr>
                    <td class="td_product">选择商品</td>
                    <td class="td_product">
                        <input type="text" class="easyui-combobox" runat="server" id="tdProductID" /></td>
                    <td class="td_business">选择商家</td>
                    <td class="td_business">
                        <input type="text" class="easyui-combobox" runat="server" id="tdBusinessID" />
                    </td>
                </tr>
                <tr>
                    <td>有效期</td>
                    <td colspan="3">
                        <input type="text" class="easyui-datebox" runat="server" id="tdStartTime" />
                        -
                    <input type="text" class="easyui-datebox" runat="server" id="tdEndTime" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</asp:Content>
