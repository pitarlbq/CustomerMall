<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="EditDepartment.aspx.cs" Inherits="Web.Cheque.EditDepartment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        var guid = "";
        $(function () {
            guid = "<%=Request.QueryString["guid"]%>";
            getComboboxList();
        })
        function getComboboxList() {
            var options = { visit: 'geteditdepartmentcombobox' };
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/SettingHandler.ashx',
                data: options,
                success: function (data) {
                    if (data.departmentcategorylist && data.departmentcategorylist.length > 0) {
                        $("#<%=this.tdDepartmentCategoryID.ClientID%>").combobox({
                            editable: false,
                            data: data.departmentcategorylist,
                            valueField: 'ID',
                            textField: 'DepartmentCategoryName'
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
            var DepartmentName = $("#<%=this.tdDepartmentName.ClientID%>").textbox("getValue");
            var Description = $("#<%=this.tdDescription.ClientID%>").textbox("getValue");
            var DepartmentNumber = $("#<%=this.tdDepartmentNumber.ClientID%>").textbox("getValue");
            var DepartmentInChargeMan = $("#<%=this.tdDepartmentInChargeMan.ClientID%>").textbox("getValue");
            var DepartmentCategoryID = $("#<%=this.tdDepartmentCategoryID.ClientID%>").textbox("getValue");
            var options = { visit: 'savechequedepartment', ID: ID, DepartmentName: DepartmentName, Description: Description, guid: guid, DepartmentNumber: DepartmentNumber, DepartmentInChargeMan: DepartmentInChargeMan, DepartmentCategoryID: DepartmentCategoryID };
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
                    <td>部门编码
                    </td>
                    <td>
                        <input type="text" class="easyui-textbox" id="tdDepartmentNumber" runat="server" data-options="required:true" />
                    </td>
                    <td>部门名称
                    </td>
                    <td>
                        <input type="text" class="easyui-textbox" id="tdDepartmentName" runat="server" data-options="required:true" />
                    </td>

                </tr>
                <tr>
                    <td>部门负责人
                    </td>
                    <td>
                        <input type="text" class="easyui-textbox" id="tdDepartmentInChargeMan" runat="server" />
                    </td>
                    <td>部门分类
                    </td>
                    <td>
                        <input type="text" class="easyui-combobox" id="tdDepartmentCategoryID" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>简介
                    </td>
                    <td colspan="3">
                        <input type="text" class="easyui-textbox" data-options="multiline:true" style="height: 50px; width: 80%;" id="tdDescription" runat="server" />
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
