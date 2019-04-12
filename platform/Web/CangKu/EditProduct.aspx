<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="EditProduct.aspx.cs" Inherits="Web.CangKu.EditProduct" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $(function () {
            loadCategory();
        });
        function loadCategory() {
            var categoryData = $("#<%=hdCategories.ClientID%>").val();
            var categorylist = [];
            if (categoryData != "") {
                categorylist = eval("(" + categoryData + ")");
            }
            var CategoryObj = $("#<%=this.tdProductCategory.ClientID%>");
            CategoryObj.combobox({
                editable: false,
                data: categorylist,
                valueField: 'ID',
                textField: 'ProductCategoryName',
            });
        }
        function do_save() {
            var isValid = $("#<%=this.ff.ClientID%>").form('enableValidation').form('validate');
            if (!isValid) {
                return;
            }
            var ID = "<%=this.ID%>";
            var ProductName = $("#<%=this.tdProductName.ClientID%>").textbox("getValue");
            var Unit = $("#<%=this.tdUnit.ClientID%>").textbox("getValue");
            var CategoryID = $("#<%=this.tdProductCategory.ClientID%>").combobox("getValue");
            var ModelNumber = $("#<%=this.tdModelNumber.ClientID%>").textbox("getValue");
            var InventoryMin = $("#<%=this.tdInventoryMin.ClientID%>").textbox("getValue");
            var InventoryMax = $("#<%=this.tdInventoryMax.ClientID%>").textbox("getValue");
            var AddMan = "<%=Web.WebUtil.GetUser(this.Context).RealName%>";
            var ProductUnitPrice = $("#<%=this.tdProductUnitPrice.ClientID%>").textbox("getValue");
            var ProductNumber = $('#<%=this.tdProductNumber.ClientID%>').textbox('getValue');
            var options = { visit: 'saveproduct', ID: ID, ProductName: ProductName, Unit: Unit, CategoryID: CategoryID, ModelNumber: ModelNumber, InventoryMin: InventoryMin, InventoryMax: InventoryMax, AddMan: AddMan, ProductNumber: ProductNumber, ProductUnitPrice: ProductUnitPrice };
            MaskUtil.mask('body', '提交中');
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/CKHandler.ashx',
                data: options,
                success: function (message) {
                    MaskUtil.unmask();
                    if (message.status) {
                        show_message('保存成功', 'success', function () {
                            do_close();
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
        function do_close() {
            parent.do_close_dialog(function () {
                parent.$("#tt_table").datagrid("reload");
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
                <tr>
                    <td>物品名称
                    </td>
                    <td>
                        <input type="text" class="easyui-textbox" id="tdProductName" runat="server" data-options="required:true" />
                    </td>
                    <td>物品编号
                    </td>
                    <td>
                        <input type="text" class="easyui-textbox" id="tdProductNumber" runat="server" data-options="required:true" />
                    </td>
                </tr>
                <tr>
                    <td>物品类别
                    </td>
                    <td>
                        <input type="text" class="easyui-combobox" id="tdProductCategory" runat="server" data-options="required:true" />
                        <asp:HiddenField runat="server" ID="hdCategories" />
                    </td>
                    <td>计量单位
                    </td>
                    <td>
                        <input type="text" class="easyui-textbox" id="tdUnit" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>规格型号
                    </td>
                    <td>
                        <input type="text" class="easyui-textbox" id="tdModelNumber" runat="server" />
                    </td>
                    <td>默认单价
                    </td>
                    <td colspan="3">
                        <input type="text" class="easyui-textbox" style="" id="tdProductUnitPrice" runat="server" />
                    </td>

                </tr>
                <tr>
                    <td>库存下限
                    </td>
                    <td>
                        <input type="text" class="easyui-textbox" style="" id="tdInventoryMin" runat="server" />
                    </td>
                    <td>库存上限
                    </td>
                    <td>
                        <input type="text" class="easyui-textbox" style="" id="tdInventoryMax" runat="server" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</asp:Content>
