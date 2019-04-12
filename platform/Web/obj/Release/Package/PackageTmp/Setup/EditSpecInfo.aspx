<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="EditSpecInfo.aspx.cs" Inherits="Web.Setup.EditSpecInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $(function () {

        })
        function saveResource() {
            var isValid = $("#<%=this.ff.ClientID%>").form('enableValidation').form('validate');
            if (!isValid) {
                return;
            }
            var ID = "<%=Request.QueryString["ID"]%>";
            var SpecName = $("#<%=this.tdSpecName.ClientID%>").textbox("getValue");
            var ColdPrice = $("#<%=this.tdColdPrice.ClientID%>").numberbox("getValue");
            var MovePrice = $("#<%=this.tdMovePrice.ClientID%>").numberbox("getValue");
            var BalancePrice = $("#<%=this.tdBalancePrice.ClientID%>").numberbox("getValue");
            var options = { visit: 'savespec', ID: ID, ColdPrice: ColdPrice, SpecName: SpecName, MovePrice: MovePrice, BalancePrice: BalancePrice };
            MaskUtil.mask('body', '提交中');
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/CommHandler.ashx',
                data: options,
                success: function (message) {
                    MaskUtil.unmask();
                    if (message.status) {
                        show_message('保存成功', 'success', function () {
                            parent.doSearch();
                        });
                    }
                    else {
                        show_message('系统错误', 'error');
                    }
                }
            });
        }
    </script>
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

        input {
            width: 200px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <form id="ff" runat="server">
        <table class="add">
            <tr>
                <td>规格
                </td>
                <td colspan="3">
                    <input id="tdSpecName" runat="server" class="easyui-textbox" data-options="required:true" />
                </td>
            </tr>
            <tr>
                <td>冷藏费标准
                </td>
                <td colspan="3">
                    <input class="easyui-numberbox" id="tdColdPrice" runat="server" data-options="required:true,min:0,precision:2" />
                </td>
            </tr>
            <tr>
                <td>搬运费标准
                </td>
                <td colspan="3">
                    <input class="easyui-numberbox" id="tdMovePrice" runat="server" data-options="required:true,min:0,precision:2" />
                </td>
            </tr>
            <tr>
                <td>搬运工结算
                </td>
                <td colspan="3">
                    <input class="easyui-numberbox" id="tdBalancePrice" runat="server" data-options="required:true,min:0,precision:2" />
                </td>
            </tr>
            <tr>
                <td colspan="4" style="text-align: center;">
                    <a href="javascript:void(0)" class="easyui-linkbutton" onclick="saveResource()" data-options="iconCls:'icon-add'">保存</a>
                </td>
            </tr>
        </table>
    </form>
</asp:Content>
