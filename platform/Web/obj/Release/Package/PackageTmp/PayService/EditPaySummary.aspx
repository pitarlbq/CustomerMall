<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="EditPaySummary.aspx.cs" Inherits="Web.PayService.EditPaySummary" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function do_save() {
            var isValid = $("#<%=this.ff.ClientID%>").form('enableValidation').form('validate');
            if (!isValid) {
                return;
            }
            var ID = "<%=this.ID%>";
            var PayName = $("#<%=this.tdPayName.ClientID%>").textbox("getValue");
            var Remark = $("#<%=this.tdRemark.ClientID%>").textbox("getValue");
            var AddMan = "<%=Web.WebUtil.GetUser(this.Context).RealName%>";
            var RelateFeeType_Pay = 0;
            if ($('#<%=this.tdRelateFeeType_Pay.ClientID%>').prop('checked')) {
                RelateFeeType_Pay = 1;
            }
            var options = { visit: 'savepaysummary', ID: ID, PayName: PayName, Remark: Remark, AddMan: AddMan, RelateFeeType_Pay: RelateFeeType_Pay };
            MaskUtil.mask('body', '提交中');
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/ServiceHandler.ashx',
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
                parent.$("#tt_table").datagrid("reload");
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
                        <input type="text" class="easyui-textbox" id="tdPayName" runat="server" data-options="required:true" />
                    </td>
                </tr>
                <tr>
                    <td>关联单据类型
                    </td>
                    <td colspan="3">
                        <input type="checkbox" runat="server" id="tdRelateFeeType_Pay" />
                        付款单据
                    </td>
                </tr>
                <tr>
                    <td>说明</td>
                    <td colspan="3">
                        <input type="text" class="easyui-textbox" id="tdRemark" name="Remark" data-options="multiline:true" runat="server" style="height: 60px;" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</asp:Content>
