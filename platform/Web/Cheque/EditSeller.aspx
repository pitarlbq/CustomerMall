<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="EditSeller.aspx.cs" Inherits="Web.Cheque.EditSeller" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        var guid = "";
        $(function () {
            guid = "<%=Request.QueryString["guid"]%>";
            getSellerCategoryList();
        })
        function getSellerCategoryList() {
            var options = { visit: 'geteditsellercombobox' };
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/SettingHandler.ashx',
                data: options,
                success: function (data) {
                    if (data.sellercategorylist && data.sellercategorylist.length > 0) {
                        $("#<%=this.tdSellerCategoryID.ClientID%>").combobox({
                            editable: false,
                            data: data.sellercategorylist,
                            valueField: 'ID',
                            textField: 'SellerCategoryName'
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
            var SellerName = $("#<%=this.tdSellerName.ClientID%>").textbox("getValue");
            var TaxNumber = $("#<%=this.tdTaxNumber.ClientID%>").textbox("getValue");
            var AddressPhone = $("#<%=this.tdAddressPhone.ClientID%>").textbox("getValue");
            var BankAccount = $("#<%=this.tdBankAccount.ClientID%>").textbox("getValue");
            var SellerSocialCreditCode = $("#<%=this.tdSellerSocialCreditCode.ClientID%>").textbox("getValue");
            var SellerCategoryID = $("#<%=this.tdSellerCategoryID.ClientID%>").combobox("getValue");
            var SellerType = $("#<%=this.tdSellerType.ClientID%>").combobox("getValue");
            var options = { visit: 'savechequeseller', ID: ID, SellerName: SellerName, TaxNumber: TaxNumber, AddressPhone: AddressPhone, BankAccount: BankAccount, SellerSocialCreditCode: SellerSocialCreditCode, SellerCategoryID: SellerCategoryID, SellerType: SellerType, guid: guid };
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
                        <input type="text" class="easyui-textbox" id="tdSellerName" runat="server" data-options="required:true" />
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
                        <input type="text" class="easyui-textbox" id="tdSellerSocialCreditCode" runat="server" />
                    </td>
                    <td>单位分类
                    </td>
                    <td>
                        <input type="text" class="easyui-combobox" id="tdSellerCategoryID" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>单位性质
                    </td>
                    <td colspan="3">
                        <select class="easyui-combobox" id="tdSellerType" runat="server">
                            <option value="客户">客户</option>
                            <option value="供应商">供应商</option>
                            <option value="客户/供应商">客户/供应商</option>
                        </select>
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
