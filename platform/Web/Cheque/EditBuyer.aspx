<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="EditBuyer.aspx.cs" Inherits="Web.Cheque.EditBuyer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        var guid = "";
        $(function () {
            guid = "<%=Request.QueryString["guid"]%>";
            getBuyerCategoryList();
        })
        function getBuyerCategoryList() {
            var options = { visit: 'geteditbuyercombobox' };
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/SettingHandler.ashx',
                data: options,
                success: function (data) {
                    if (data.buyercategorylist && data.buyercategorylist.length > 0) {
                        $("#<%=this.tdBuyerCategoryID.ClientID%>").combobox({
                            editable: false,
                            data: data.buyercategorylist,
                            valueField: 'ID',
                            textField: 'BuyerCategoryName'
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
            var BuyerName = $("#<%=this.tdBuyerName.ClientID%>").textbox("getValue");
            var TaxNumber = $("#<%=this.tdTaxNumber.ClientID%>").textbox("getValue");
            var AddressPhone = $("#<%=this.tdAddressPhone.ClientID%>").textbox("getValue");
            var BankAccount = $("#<%=this.tdBankAccount.ClientID%>").textbox("getValue");
            var BuyerSocialCreditCode = $("#<%=this.tdBuyerSocialCreditCode.ClientID%>").textbox("getValue");
            var BuyerCategoryID = $("#<%=this.tdBuyerCategoryID.ClientID%>").combobox("getValue");
            var BuyerType = $("#<%=this.tdBuyerType.ClientID%>").combobox("getValue");
            var options = { visit: 'savechequebuyer', ID: ID, BuyerName: BuyerName, TaxNumber: TaxNumber, AddressPhone: AddressPhone, BankAccount: BankAccount, BuyerSocialCreditCode: BuyerSocialCreditCode, BuyerCategoryID: BuyerCategoryID, BuyerType: BuyerType, guid: guid };
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
                    <td>单位名称
                    </td>
                    <td>
                        <input type="text" class="easyui-textbox" id="tdBuyerName" runat="server" data-options="required:true" />
                    </td>
                    <td>纳税人识别号
                    </td>
                    <td>
                        <input type="text" class="easyui-textbox" id="tdTaxNumber" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>地址电话
                    </td>
                    <td>
                        <input type="text" class="easyui-textbox" id="tdAddressPhone" runat="server" />
                    </td>
                    <td>开户行账号
                    </td>
                    <td>
                        <input type="text" class="easyui-textbox" id="tdBankAccount" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>统一社会信用代码
                    </td>
                    <td>
                        <input type="text" class="easyui-textbox" id="tdBuyerSocialCreditCode" runat="server" />
                    </td>
                    <td>单位分类
                    </td>
                    <td>
                        <input type="text" class="easyui-combobox" id="tdBuyerCategoryID" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>单位性质
                    </td>
                    <td colspan="3">
                        <select class="easyui-combobox" id="tdBuyerType" runat="server">
                            <option value="客户">客户</option>
                            <option value="供应商">供应商</option>
                            <option value="客户/供应商">客户/供应商</option>
                        </select>
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
