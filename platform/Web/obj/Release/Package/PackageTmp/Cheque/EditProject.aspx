<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="EditProject.aspx.cs" Inherits="Web.Cheque.EditProject" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        var guid = "";
        $(function () {
            guid = "<%=Request.QueryString["guid"]%>";
            getComboboxList();
        })
        function getComboboxList() {
            var options = { visit: 'geteditprojectcombobox' };
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/SettingHandler.ashx',
                data: options,
                success: function (data) {
                    if (data.projectcategorylist && data.projectcategorylist.length > 0) {
                        $("#<%=this.tdProjectCategoryID.ClientID%>").combobox({
                            editable: false,
                            data: data.projectcategorylist,
                            valueField: 'ID',
                            textField: 'ProjectCategoryName'
                        });
                    }
                    if (data.departmentlist && data.departmentlist.length > 0) {
                        $("#<%=this.tdDepartmentID.ClientID%>").combobox({
                            editable: false,
                            data: data.departmentlist,
                            valueField: 'ID',
                            textField: 'DepartmentName'
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
            var ProjectName = $("#<%=this.tdProjectName.ClientID%>").textbox("getValue");
            var options = { visit: 'savechequeproject', ID: ID, ProjectName: ProjectName, guid: guid };
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
                    <td>项目档案编码
                    </td>
                    <td>
                        <input type="text" class="easyui-textbox" id="tdProjectNumber" runat="server" data-options="required:true" />
                    </td>
                    <td>项目档案名称
                    </td>
                    <td>
                        <input type="text" class="easyui-textbox" id="tdProjectName" runat="server" data-options="required:true" />
                    </td>
                </tr>
                <tr>
                    <td>项目分类
                    </td>
                    <td>
                        <input type="text" class="easyui-combobox" id="tdProjectCategoryID" runat="server" />
                    </td>
                    <td>部门名称
                    </td>
                    <td>
                        <input type="text" class="easyui-textbox" id="tdDepartmentName" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>所属直管部
                    </td>
                    <td>
                        <input type="text" class="easyui-combobox" id="tdDepartmentID" runat="server" />
                    </td>
                    <td>项目经理
                    </td>
                    <td>
                        <input type="text" class="easyui-textbox" id="tdManagerName" runat="server" />
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
