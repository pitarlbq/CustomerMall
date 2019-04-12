<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="EditCarrierGroup.aspx.cs" Inherits="Web.Setup.EditCarrierGroup" %>

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
            var CarrierGroupName = $("#<%=this.tdCarrierGroupName.ClientID%>").textbox("getValue");
            var options = { visit: 'savecarriergroup', ID: ID, CarrierGroupName: CarrierGroupName };
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
                <td>名称
                </td>
                <td colspan="3">
                    <input class="easyui-textbox" id="tdCarrierGroupName" runat="server" data-options="required:true" />
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
