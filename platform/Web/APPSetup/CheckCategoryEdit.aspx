﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="CheckCategoryEdit.aspx.cs" Inherits="Web.APPSetup.CheckCategoryEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function do_save() {
            var isValid = $("#<%=this.ff.ClientID%>").form('enableValidation').form('validate');
            if (!isValid) {
                return;
            }
            var ID = "<%=this.CategoryID%>";
            var CategoryName = $("#<%=this.tdCategoryName.ClientID%>").textbox("getValue");
            var CategoryType = $("#<%=this.tdCategoryType.ClientID%>").combobox("getValue");
            var options = { visit: 'savemallcheckcategory', ID: ID, CategoryName: CategoryName, CategoryType: CategoryType };
            MaskUtil.mask('body', '提交中');
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/MallHandler.ashx',
                data: options,
                success: function (data) {
                    MaskUtil.unmask();
                    if (data.status) {
                        show_message('保存成功', 'success');
                        do_close();
                    }
                    else {
                        show_message('系统错误', 'error');
                    }
                }
            });
        }
        function do_close() {
            parent.close_container_dialog(function () {
                parent.doSearchTree();
            });
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
                    <td>项目名称
                    </td>
                    <td colspan="3">
                        <input type="text" class="easyui-textbox" id="tdCategoryName" runat="server" data-options="required:true" />
                    </td>
                </tr>
                <tr>
                    <td>项目类别
                    </td>
                    <td colspan="3">
                        <select class="easyui-combobox" id="tdCategoryType" runat="server" data-options="editable:false">
                            <option value="1">奖励</option>
                            <option value="2">惩罚</option>
                        </select>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</asp:Content>
