<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="EditLinShiFee.aspx.cs" Inherits="Web.SetupFee.EditLinShiFee" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../js/Page/Comm/GetTypeList.js?v=<%=base.getToken() %>"></script>
    <script type="text/javascript">

        function addfee() {
            var isValid = $("#ff").form('enableValidation').form('validate');
            if (!isValid) {
                return;
            }
            var id = "<%=Request.QueryString["ID"]%>";
            var name = $("#<%=this.tdName.ClientID%>").textbox("getValue");
            var op = "<%=Request.QueryString["op"]%>";
            var CategoryID = 0;
            switch (op) {
                case "收入":
                    CategoryID = 1;
                    break;
                case "代收":
                    CategoryID = 2;
                    break;
                case "押金":
                    CategoryID = 3;
                    break;
                case "预收":
                    CategoryID = 4;
                    break;
                default:
                    break;

            }
            var summaryunitprice = $("#<%=this.tdSummaryUnitPrice.ClientID%>").numberbox("getValue");
            var AllowImport = $("#<%=this.tbAllowImport.ClientID%>").combobox("getValue");
            var EndNumberCount = $("#<%=this.tbEndNumberCount.ClientID%>").numberbox("getValue");
            var options = { visit: 'savesummaryfee', id: id, name: name, chargetype: 2, endnumber: 2, category: CategoryID, summaryunitprice: summaryunitprice, coefficient: 1, unit: "", sortorder: 1, CompanyID: "<%=Web.WebUtil.GetCompanyID(this.Context)%>", FeeType: 4, AllowImport: AllowImport, EndNumberCount: EndNumberCount };
            MaskUtil.mask('body', '提交中');
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/FeeCenterHandler.ashx',
                data: options,
                success: function (message) {
                    MaskUtil.unmask();
                    if (message.status) {
                        show_message('保存成功', 'success', function () {
                            parent.$("#winadd").window('close');
                        });
                    }
                    else {
                        show_message('系统错误', 'error');
                    }
                }
            });
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <style type="text/css">
        table.add {
            width: 80%;
            margin: 0 auto;
            margin-top: 10px;
            border-collapse: collapse;
            border-spacing: 0px;
        }

            table.add td {
                padding: 10px;
            }
    </style>
    <form id="ff" runat="server" method="post">
        <table class="add">
            <tr>
                <td>收费项目
                </td>
                <td>
                    <input id="tdName" class="easyui-textbox" runat="server" type="text" data-options="required:true" />
                </td>
            </tr>
            <tr>
                <td>默认价格
                </td>
                <td>
                    <input id="tdSummaryUnitPrice" class="easyui-numberbox" runat="server" type="text" data-options="precision:2" />
                </td>
            </tr>
            <tr>
                <td>允许导入费用
                </td>
                <td>
                    <select class="easyui-combobox" runat="server" id="tbAllowImport" data-options="required:true">
                        <option value="1">是</option>
                        <option value="0">否</option>
                    </select>
                </td>
            </tr>
            <tr>
                <td>小数位数
                </td>
                <td>
                    <input class="easyui-numberbox" runat="server" id="tbEndNumberCount"
                        data-options="required:true" />
                </td>
            </tr>
            <tr>
                <td colspan="2" style="text-align: center;">
                    <a id="btn" href="javascript:void(0)" class="savebutton" onclick="addfee()" data-options="iconCls:'icon-add'"></a>
                </td>
            </tr>
        </table>
    </form>
</asp:Content>
