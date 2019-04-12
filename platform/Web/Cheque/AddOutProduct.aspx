<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="AddOutProduct.aspx.cs" Inherits="Web.Cheque.AddOutProduct" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../js/Page/Comm/PinYin.js"></script>
    <script>
        var guid, OutSummaryID, ID;
        $(function () {
            guid = "<%=Request.QueryString["guid"]%>";
            OutSummaryID = "<%=Request.QueryString["OutSummaryID"]%>";
            ID = "<%=Request.QueryString["ID"]%>";
        })
    </script>
    <script type="text/javascript">
        $(function () {
            getProductList();
            $("#<%=this.tdUnitPrice.ClientID%>").textbox({
                onChange: function (newValue, oldValue) {
                    calculateTotalSumCost();
                }
            });
            $("#<%=this.tdTotalCount.ClientID%>").textbox({
                onChange: function (newValue, oldValue) {
                    calculateTotalSumCost();
                }
            });
            $("#<%=this.tdTaxRate.ClientID%>").textbox({
                onChange: function (newValue, oldValue) {
                    calculateTotalSumCost();
                }
            });
        })
        function getProductList() {
            var options = { visit: 'getproductlist' };
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/ChequeHandler.ashx',
                data: options,
                success: function (data) {
                    if (data.status) {
                        $("#<%=this.tdProductName.ClientID%>").combobox({
                            editable: true,
                            data: data.ProductList,
                            valueField: 'ID',
                            textField: 'ProductName',
                            filter: function (q, row) {
                                var opts = $(this).combobox('options');
                                return __pinyin.getFirstLetter(row[opts.textField]).indexOf(q.toLowerCase()) != -1 || row[opts.textField].indexOf(q) != -1;
                            },
                            onSelect: function (rec) {
                                $("#<%=this.tdModelNumber.ClientID%>").textbox('setValue', rec.ModelNumber);
                                $("#<%=this.tdUnit.ClientID%>").textbox('setValue', rec.Unit);
                                $("#<%=this.tdUnitPrice.ClientID%>").textbox('setValue', rec.UnitPrice);
                            }
                        })
                    }
                }
            });
        }
        function saveData() {
            var isValid = $("#<%=this.ff.ClientID%>").form('enableValidation').form('validate');
            if (!isValid) {
                return;
            }
            var ProductID = $("#<%=this.tdProductName.ClientID%>").combobox("getValue");
            var ProductName = $("#<%=this.tdProductName.ClientID%>").combobox("getText");
            var ModelNumber = $("#<%=this.tdModelNumber.ClientID%>").textbox("getValue");
            var Unit = $("#<%=this.tdUnit.ClientID%>").textbox("getValue");
            var UnitPrice = $("#<%=this.tdUnitPrice.ClientID%>").textbox("getValue");
            var TotalCount = $("#<%=this.tdTotalCount.ClientID%>").textbox("getValue");
            var TaxRate = $("#<%=this.tdTaxRate.ClientID%>").textbox("getValue");
            var options = { visit: 'savechequeoutproduct', ID: ID, ProductID: ProductID, ProductName: ProductName, ModelNumber: ModelNumber, Unit: Unit, UnitPrice: UnitPrice, TotalCount: TotalCount, TaxRate: TaxRate, guid: guid, OutSummaryID: OutSummaryID };
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
            parent.$("#winaddproduct").window("close");
        }
        function calculateTotalCost() {
            var UnitPrice = $("#<%=this.tdUnitPrice.ClientID%>").textbox("getValue");
            var TotalCount = $("#<%=this.tdTotalCount.ClientID%>").textbox("getValue");
            UnitPrice = (Number(UnitPrice) > 0 ? Number(UnitPrice) : 0);
            TotalCount = (Number(TotalCount) > 0 ? Number(TotalCount) : 0);
            var TotalCost = Number(UnitPrice) * Number(TotalCount);
            $("#<%=this.tdTotalCost.ClientID%>").textbox('setValue', TotalCost);
            return TotalCost;
        }
        function calculateTotalTaxCost() {
            var TotalCost = calculateTotalCost();
            var TaxRate = $("#<%=this.tdTaxRate.ClientID%>").textbox("getValue");
            TaxRate = (Number(TaxRate) > 0 ? Number(TaxRate) : 0);
            var TotalTaxCost = (Number(TotalCost) * Number(TaxRate) / 100).toFixed(2);
            $("#<%=this.tdTotalTaxCost.ClientID%>").textbox('setValue', TotalTaxCost);
            return TotalTaxCost;
        }
        function calculateTotalSumCost() {
            var TotalCost = calculateTotalCost();
            var TotalTaxCost = calculateTotalTaxCost();
            var TotalSumCost = Number(TotalCost) + Number(TotalTaxCost);
            return TotalSumCost;
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
                    <td>货品名称
                    </td>
                    <td>
                        <input type="text" class="easyui-combobox" id="tdProductName" runat="server" data-options="required:true" />
                    </td>
                    <td>规格型号
                    </td>
                    <td>
                        <input type="text" class="easyui-textbox" id="tdModelNumber" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>计量单位
                    </td>
                    <td>
                        <input type="text" class="easyui-textbox" id="tdUnit" runat="server" />
                    </td>
                    <td>单价
                    </td>
                    <td>
                        <input type="text" class="easyui-textbox" id="tdUnitPrice" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>数量
                    </td>
                    <td>
                        <input type="text" class="easyui-textbox" id="tdTotalCount" runat="server" />
                    </td>
                    <td>税率(%)
                    </td>
                    <td>
                        <input type="text" class="easyui-textbox" id="tdTaxRate" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>金额
                    </td>
                    <td>
                        <input type="text" class="easyui-textbox" id="tdTotalCost" runat="server" data-options="readonly:true" />
                    </td>
                    <td>税额
                    </td>
                    <td>
                        <input type="text" class="easyui-textbox" id="tdTotalTaxCost" runat="server" data-options="readonly:true" />
                    </td>
                </tr>
                <tr>
                    <td colspan="4" style="text-align: center;">
                         <a href="javascript:void(0)" onclick="saveData()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-save'">保存</a>
                         <a href="javascript:void(0)" onclick="closeWin()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-close'">关闭</a>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</asp:Content>
