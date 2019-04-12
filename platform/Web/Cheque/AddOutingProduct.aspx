<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="AddOutingProduct.aspx.cs" Inherits="Web.Cheque.AddOutingProduct" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../js/Page/Comm/PinYin.js"></script>
    <script>
        var guid, OutingID, ID;
        $(function () {
            guid = "<%=Request.QueryString["guid"]%>";
            OutingID = "<%=Request.QueryString["OutingID"]%>";
            ID = "<%=Request.QueryString["ID"]%>";
        })
    </script>
    <script type="text/javascript">
        function saveData() {
            var isValid = $("#<%=this.ff.ClientID%>").form('enableValidation').form('validate');
            if (!isValid) {
                return;
            }
            var ProductName = $("#<%=this.tdProductName.ClientID%>").textbox("getValue");
            var TotalCount = $("#<%=this.tdTotalCount.ClientID%>").textbox("getText");
            var SellerAddress = $("#<%=this.tdSellerAddress.ClientID%>").textbox("getValue");
            var ProductTotalCost = $("#<%=this.tdProductTotalCost.ClientID%>").textbox("getValue");
            var ProductStartTime = $("#<%=this.tdProductStartTime.ClientID%>").datebox("getValue");
            var ProductEndTime = $("#<%=this.tdProductEndTime.ClientID%>").datebox("getValue");
            var options = { visit: 'savechequeoutingproduct', ID: ID, ProductName: ProductName, TotalCount: TotalCount, SellerAddress: SellerAddress, ProductTotalCost: ProductTotalCost, ProductStartTime: ProductStartTime, ProductEndTime: ProductEndTime, guid: guid, OutingID: OutingID };
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
                    <td>货物名称
                    </td>
                    <td>
                        <input type="text" class="easyui-textbox" id="tdProductName" runat="server" data-options="required:true" />
                    </td>
                    <td>数量
                    </td>
                    <td>
                        <input type="text" class="easyui-textbox" id="tdTotalCount" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>销售地点
                    </td>
                    <td>
                        <input type="text" class="easyui-textbox" id="tdSellerAddress" runat="server" />
                    </td>
                    <td>合同金额
                    </td>
                    <td>
                        <input type="text" class="easyui-textbox" id="tdProductTotalCost" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>有效期
                    </td>
                    <td colspan="3">
                        <input type="text" class="easyui-datebox" id="tdProductStartTime" runat="server" />
                        -
                        <input type="text" class="easyui-datebox" id="tdProductEndTime" runat="server" />
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
