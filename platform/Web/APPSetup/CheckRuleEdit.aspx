<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="CheckRuleEdit.aspx.cs" Inherits="Web.APPSetup.CheckRuleEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        var RuleID = 0, CategoryID = 0;
        $(function () {
            RuleID = "<%=this.RuleID%>";
            CategoryID = "<%=this.CategoryID%>";
        })
        function do_save() {
            var isValid = $("#<%=this.ff.ClientID%>").form('enableValidation').form('validate');
            if (!isValid) {
                return;
            }
            var CheckName = $("#<%=this.tdCheckName.ClientID%>").textbox("getValue");
            var CheckSummary = $("#<%=this.tdCheckSummary.ClientID%>").textbox("getValue");
            var EndPoint = $("#<%=this.tdEndPoint.ClientID%>").textbox("getValue");
            var StartPoint = $("#<%=this.tdStartPoint.ClientID%>").textbox("getValue");
            var options = { visit: 'savemallcheckrule', ID: RuleID, CategoryID: CategoryID, CheckName: CheckName, CheckSummary: CheckSummary, EndPoint: EndPoint, StartPoint: StartPoint };
            MaskUtil.mask('body', '提交中');
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/MallHandler.ashx',
                data: options,
                success: function (data) {
                    MaskUtil.unmask();
                    if (data.status) {
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
            parent.close_container_dialog(function () {
                parent.$('#tt_table').datagrid('reload');
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
                    <td>标准名称
                    </td>
                    <td colspan="3">
                        <input type="text" class="easyui-textbox" id="tdCheckName" runat="server" data-options="required:true" />
                    </td>
                </tr>
                <tr>
                    <td>考核说明
                    </td>
                    <td colspan="3">
                        <input type="text" class="easyui-textbox" id="tdCheckSummary" runat="server" data-options="multiline:true" style="height: 60px;" />
                    </td>
                </tr>
                <tr>
                    <td>分值范围
                    </td>
                    <td colspan="3">
                        <input type="text" class="easyui-textbox" id="tdStartPoint" runat="server" data-options="required:true" />
                        -
                        <input type="text" class="easyui-textbox" id="tdEndPoint" runat="server" data-options="required:true" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</asp:Content>
