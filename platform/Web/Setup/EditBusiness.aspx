<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="EditBusiness.aspx.cs" Inherits="Web.Setup.EditBusiness" %>

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
            var Category = $("#<%=this.tdCategory.ClientID%>").combobox("getValue");
            var ContactName = $("#<%=this.tdContactName.ClientID%>").textbox("getValue");
            var ContactPhone = $("#<%=this.tdContactPhone.ClientID%>").textbox("getValue");
            var Remark = $("#<%=this.tdRemark.ClientID%>").textbox("getValue");
            var options = { visit: 'savebusiness', ID: ID, Category: Category, ContactName: ContactName, ContactPhone: ContactPhone, Remark: Remark };
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
                <td>分类
                </td>
                <td colspan="3">
                    <select id="tdCategory" runat="server" class="easyui-combobox" name="dept">
                        <option value="大棚">大棚</option>
                        <option value="室内">室内</option>
                    </select>
                </td>
            </tr>
            <tr>
                <td>名称
                </td>
                <td colspan="3">
                    <input class="easyui-textbox" id="tdContactName" runat="server" data-options="required:true" />
                </td>
            </tr>
            <tr>
                <td>联系电话
                </td>
                <td colspan="3">
                    <input class="easyui-textbox" id="tdContactPhone" runat="server" data-options="required:true" />
                </td>
            </tr>
            <tr>
                <td>备注
                </td>
                <td colspan="3">
                    <input class="easyui-textbox" data-options="multiline:true" id="tdRemark" style="width: 80%; height: 60px;" runat="server" />
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
