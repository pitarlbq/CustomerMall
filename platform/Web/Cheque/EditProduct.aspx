<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="EditProduct.aspx.cs" Inherits="Web.Cheque.EditProduct" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $(function () {
            getComboboxList();
        })
        function getComboboxList() {
            var options = { visit: 'geteditproductcombobox' };
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/SettingHandler.ashx',
                data: options,
                success: function (data) {
                    if (data.productcategorylist && data.productcategorylist.length > 0) {
                        $("#<%=this.tdProductCategoryID.ClientID%>").combobox({
                            editable: false,
                            data: data.productcategorylist,
                            valueField: 'ID',
                            textField: 'ProductCategoryName'
                        });
                    }
                }
            });
        }
        function saveData() {
            var isValid = $("#<%=this.ff.ClientID%>").form('enableValidation').form('validate');
            if (!isValid) {
                return;
            }
            var ID = "<%=this.ID%>";
            var ProductName = $("#<%=this.tdProductName.ClientID%>").textbox("getValue");
            var ModelNumber = $("#<%=this.tdModelNumber.ClientID%>").textbox("getValue");
            var Unit = $("#<%=this.tdUnit.ClientID%>").textbox("getValue");
            var UnitPrice = $("#<%=this.tdUnitPrice.ClientID%>").textbox("getValue");
            var ProductNumber = $("#<%=this.tdProductNumber.ClientID%>").textbox("getValue");
            var ProductCategoryID = $("#<%=this.tdProductCategoryID.ClientID%>").combobox("getValue");
            var options = { visit: 'savechequeproduct', ID: ID, ProductName: ProductName, ModelNumber: ModelNumber, Unit: Unit, UnitPrice: UnitPrice, ProductNumber: ProductNumber, ProductCategoryID: ProductCategoryID };
            top.$.messager.progress();
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/ChequeHandler.ashx',
                data: options,
                success: function (message) {
                    top.$.messager.progress('close');
                    if (message.status) {
                        show_message('保存成功', 'success', function () {
                            closeWin();
                        });
                    }
                    else {
                        show_message('系统错误', 'error');
                    }
                }
            });
        }
        function closeWin() {
            parent.$("#winsubadd").window("close");
        }
    </script>
    <style type="text/css">
        table.info {
            width: 90%;
            margin: 0 auto;
            border: solid 1px #ccc;
            border-spacing: 0;
            border-collapse: collapse;
        }

            table.info td {
                border: solid 1px #ccc;
                padding: 10px;
                text-align: left;
                width: 35%;
            }

                table.info td:nth-child(2n-1) {
                    text-align: right;
                    width: 15%;
                }

        input {
            width: 200px;
        }

        .hidefield {
            display: none;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <form id="ff" runat="server">
        <div style="padding: 10px 0;">
            <table class="info">
                <tr>
                    <td>货物编码
                    </td>
                    <td>
                        <input type="text" class="easyui-textbox" id="tdProductNumber" runat="server" data-options="required:true" />
                    </td>
                    <td>货品名称
                    </td>
                    <td>
                        <input type="text" class="easyui-textbox" id="tdProductName" runat="server" data-options="required:true" />
                    </td>
                </tr>
                <tr>
                    <td>规格型号
                    </td>
                    <td>
                        <input type="text" class="easyui-textbox" id="tdModelNumber" runat="server" />
                    </td>
                    <td>计量单位
                    </td>
                    <td>
                        <input type="text" class="easyui-textbox" id="tdUnit" runat="server" />
                    </td>

                </tr>
                <tr>
                    <td>货物名称分类
                    </td>
                    <td>
                        <input type="text" class="easyui-combobox" id="tdProductCategoryID" runat="server" />
                    </td>
                    <td>单价
                    </td>
                    <td>
                        <input type="text" class="easyui-textbox" id="tdUnitPrice" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td colspan="4" style="text-align: center;">
                        <a href="javascript:void(0)" onclick="saveData()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-save'">保存</a>
                        <a href="javascript:void(0)" onclick="closeWin()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-save'">关闭</a>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</asp:Content>
