<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="AddRule.aspx.cs" Inherits="Web.ZhuangXiu.AddRule" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title></title>
    <script>
        var ID, ProjectID, tdRuleCategory;
        $(function () {
            ID = "<%=this.ID%>";
            tdRuleCategory = $('#<%=this.tdRuleCategory.ClientID%>');
            loadComboboxParams(true);
        });
        function saveData() {
            var isValid = $("#<%=this.ff.ClientID%>").form('enableValidation').form('validate');
            if (!isValid) {
                return;
            }
            $('#ff').form('submit', {
                url: '../Handler/ZhuangXiuHandler.ashx',
                onSubmit: function (param) {
                    param.visit = 'savezhuangxiurule';
                    param.ID = ID;
                },
                success: function (data) {
                    var dataObj = eval("(" + data + ")");
                    if (dataObj.status) {
                        show_message('保存成功', 'success', function () {
                            closeWin();
                        });
                        return;
                    }
                    else {
                        show_message('系统错误', 'error');
                    }
                }
            });
        }
        function loadComboboxParams(load_category) {
            var options = { visit: 'getzhuangxiucategoryparams' };
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/ZhuangXiuHandler.ashx',
                data: options,
                success: function (data) {
                    if (load_category) {
                        tdRuleCategory.combobox({
                            editable: true,
                            data: data.category_list,
                            valueField: 'ID',
                            textField: 'Name'
                        });
                        if (ChosenInCategoryID > 0) {
                            tdRuleCategory.combobox('setValue', ChosenInCategoryID);
                        }
                    }
                }
            });
        }
        function closeWin() {
            parent.$("#winadd").window("close");
        }
        var ChosenInCategoryID = 0;
        function addCategory() {
            ChosenInCategoryID = tdRuleCategory.combobox('getValue') || 0;
            var iframe = "../SysSeting/EditZhuangXiuCategoryCombobox.aspx";
            do_open_dialog('选择类别', iframe);
        }
    </script>
    <style>
        table.info {
            width: 100%;
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

        input[type=text] {
            width: 70%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <form id="ff" runat="server" method="post" enctype="multipart/form-data">
        <table class="info">
            <tr>
                <td>项目类别</td>
                <td colspan="3">
                    <input type="text" runat="server" data-options="required:true" name="RuleName" class="easyui-combobox" id="tdRuleCategory" style="width: 50%;" />
                    <label><a href="javascript:void(0)" onclick="addCategory()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-add'">选择</a></label>
                </td>
            </tr>
            <tr>
                <td>巡检项目</td>
                <td colspan="3">
                    <input type="text" runat="server" data-options="required:true" name="RuleName" class="easyui-textbox" id="tdRuleName" />
                </td>
            </tr>
            <tr>
                <td>整改要求</td>
                <td colspan="3">
                    <input type="text" data-options="multiline:true" style="height: 60px;" runat="server" name="RuleRequire" class="easyui-textbox" id="tdRuleRequire" /></td>
            </tr>
            <tr>
                <td colspan="4" style="text-align: center;">
                    <a href="javascript:void(0)" onclick="saveData()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-save'">保存</a>
                    <a href="javascript:void(0)" onclick="closeWin()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-save'">关闭</a>
                </td>
            </tr>
        </table>
    </form>
</asp:Content>
