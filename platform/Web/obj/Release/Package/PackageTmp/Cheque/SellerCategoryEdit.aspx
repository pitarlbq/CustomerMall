<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="SellerCategoryEdit.aspx.cs" Inherits="Web.Cheque.SellerCategoryEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        var ID;
        $(function () {
            ID = "<%=this.ID%>";
        });
        function saveData() {
            var isValid = $("#<%=this.ff.ClientID%>").form('enableValidation').form('validate');
            if (!isValid) {
                return;
            }
            var SellerCategoryNumber = $("#<%=this.tdSellerCategoryNumber.ClientID%>").textbox("getValue");
            var SellerCategoryName = $("#<%=this.tdSellerCategoryName.ClientID%>").textbox("getValue");
            var options = { visit: 'savesellercategory', ID: ID, SellerCategoryNumber: SellerCategoryNumber, SellerCategoryName: SellerCategoryName };
            top.$.messager.progress();
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/SettingHandler.ashx',
                data: options,
                success: function (data) {
                    top.$.messager.progress('close');
                    if (data.status) {
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
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <form id="ff" runat="server">
        <div style="padding: 10px 0;">
            <table class="info">
                <tr class="detail">
                    <td>销售单位分类编码
                    </td>
                    <td colspan="3">
                        <input type="text" class="easyui-textbox" id="tdSellerCategoryNumber" runat="server" data-options="required:true" />
                    </td>
                </tr>
                <tr>
                    <td>销售单位分类名称
                    </td>
                    <td colspan="3">
                        <input type="text" class="easyui-textbox" id="tdSellerCategoryName" runat="server" data-options="required:true" />
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
