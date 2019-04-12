<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="EditCategory.aspx.cs" Inherits="Web.CangKu.EditCategory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function do_save() {
            var isValid = $("#<%=this.ff.ClientID%>").form('enableValidation').form('validate');
            if (!isValid) {
                return;
            }
            var ID = "<%=this.ID%>";
            var ParentID = "<%=this.ParentID%>";
            var CategoryName = $("#<%=this.tdCategoryName.ClientID%>").textbox("getValue");
            var Remark = $("#<%=this.tdRemark.ClientID%>").textbox("getValue");
            var AddMan = "<%=Web.WebUtil.GetUser(this.Context).RealName%>";
            var CategoryType = $("#<%=this.hdCategoryType.ClientID%>").val();
            var options = { visit: 'savecategory', ID: ID, CategoryName: CategoryName, Remark: Remark, AddMan: AddMan, ParentID: ParentID, CategoryType: CategoryType };
            MaskUtil.mask('body', '提交中');
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/CKHandler.ashx',
                data: options,
                success: function (message) {
                    MaskUtil.unmask();
                    if (message.status) {
                        show_message('保存成功', 'success', function () {
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
                parent.$("#tt_table").treegrid("reload");
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
                    <td><span id="tdCategoryType" runat="server">类别</span>名称
                        <input type="text" style="display: none;" runat="server" id="hdCategoryType" />
                    </td>
                    <td colspan="3">
                        <input type="text" class="easyui-textbox" id="tdCategoryName" runat="server" data-options="required:true" style="width: 70%;" />
                    </td>
                </tr>
                <tr>
                    <td>描述</td>
                    <td colspan="3">
                        <input class="easyui-textbox" id="tdRemark" name="Remark" data-options="multiline:true" runat="server" style="height: 60px; width: 70%;" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</asp:Content>
