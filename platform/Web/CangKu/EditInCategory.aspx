<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="EditInCategory.aspx.cs" Inherits="Web.CangKu.EditInCategory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        var IsSystemAdd;
        $(function () {
            IsSystemAdd = Number("<%=this.IsSystemAdd%>");
            if (IsSystemAdd == 1) {
                $("#<%=this.tdInCategoryName.ClientID%>").textbox({
                    readonly: true
                })
                $("#<%=this.tdCategoryType.ClientID%>").combobox({
                    readonly: true
                })
            }
        })
        function do_save() {
            var isValid = $("#<%=this.ff.ClientID%>").form('enableValidation').form('validate');
            if (!isValid) {
                return;
            }
            var ID = "<%=this.ID%>";
            var InCategoryName = $("#<%=this.tdInCategoryName.ClientID%>").textbox("getValue");
            var InCategoryDesc = $("#<%=this.tdInCategoryDesc.ClientID%>").textbox("getValue");
            var CategoryType = $("#<%=this.tdCategoryType.ClientID%>").combobox("getValue");
            var PrintLineCount = $("#<%=this.tdPrintLineCount.ClientID%>").textbox("getValue");
            var options = { visit: 'saveincategory', ID: ID, InCategoryName: InCategoryName, InCategoryDesc: InCategoryDesc, CategoryType: CategoryType, PrintLineCount: PrintLineCount };
            MaskUtil.mask('body', '提交中');
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/CKHandler.ashx',
                data: options,
                success: function (data) {
                    MaskUtil.unmask();
                    if (data.status) {
                        show_message('保存成功', 'success', function () {
                            try {
                                parent.ContractID = data.ID;
                                parent.ContractName = ContractName;
                                parent.ContractPhoneNumber = PhoneNumber;
                                parent.ContractContactMan = ContactMan;
                            } catch (e) {

                            }
                            do_close();
                        });
                    }
                    else {
                        show_message('系统错误', 'error');
                    }
                }
            });
        }
        function do_close() {
            parent.do_close_dialog(function () {
                parent.$("#tt_table").datagrid("reload");
            }, true);
        }
    </script>
    <style type="text/css">
        .panel-body {
            background: #f0f0f0;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <form id="ff" runat="server">
        <div class="operation_box">
            <a href="javascript:void(0)" onclick="do_save()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-save'">保存</a>
            <a href="javascript:void(0)" onclick="do_close()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-close'">关闭</a>
        </div>
        <div class="table_container">
            <table class="info">
                <tr>
                    <td>分类名称
                    </td>
                    <td colspan="3">
                        <input type="text" class="easyui-textbox" id="tdInCategoryName" runat="server" data-options="required:true" />
                    </td>
                </tr>
                <tr>
                    <td>类型
                    </td>
                    <td colspan="3">
                        <select runat="server" id="tdCategoryType" class="easyui-combobox">
                            <option value="ruku">入库</option>
                            <option value="chuku">出库</option>
                        </select>
                    </td>
                </tr>
                <tr>
                    <td>单据行数
                    </td>
                    <td colspan="3">
                        <input type="text" class="easyui-textbox" id="tdPrintLineCount" runat="server" data-options="required:true" />(行)
                    </td>
                </tr>
                <tr>
                    <td>描述
                    </td>
                    <td colspan="3">
                        <input class="easyui-textbox" id="tdInCategoryDesc" data-options="multiline:true" runat="server" style="height: 60px;" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</asp:Content>
