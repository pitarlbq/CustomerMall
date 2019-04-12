<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="BuyerCategoryEdit.aspx.cs" Inherits="Web.Cheque.BuyerCategoryEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        var ID;
        $(function () {
            ID = "<%=this.ID%>";
        });
        function do_save() {
            var isValid = $("#<%=this.ff.ClientID%>").form('enableValidation').form('validate');
            if (!isValid) {
                return;
            }
            var BuyerCategoryNumber = $("#<%=this.tdBuyerCategoryNumber.ClientID%>").textbox("getValue");
            var BuyerCategoryName = $("#<%=this.tdBuyerCategoryName.ClientID%>").textbox("getValue");
            var options = { visit: 'savebuyercategory', ID: ID, BuyerCategoryNumber: BuyerCategoryNumber, BuyerCategoryName: BuyerCategoryName };
            top.$.messager.progress();
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/SettingHandler.ashx',
                data: options,
                success: function (data) {
                    top.$.messager.progress('close');
                    if (data.status) {
                        show_message('保存成功', 'success', function () {
                            do_close();
                        });
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
            <a href="javascript:void(0)" onclick="do_save()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-save'">保存</a>
            <a href="javascript:void(0)" onclick="do_close()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-close'">关闭</a>
        </div>
        <div class="table_container">
            <table class="info">
                <tr class="detail">
                    <td>购货单位分类编码
                    </td>
                    <td colspan="3">
                        <input type="text" class="easyui-textbox" id="tdBuyerCategoryNumber" runat="server" data-options="required:true" />
                    </td>
                </tr>
                <tr>
                    <td>购货单位分类名称
                    </td>
                    <td colspan="3">
                        <input type="text" class="easyui-textbox" id="tdBuyerCategoryName" runat="server" data-options="required:true" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</asp:Content>
