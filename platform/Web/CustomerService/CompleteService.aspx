<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="CompleteService.aspx.cs" Inherits="Web.CustomerService.CompleteService" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        var ID;
        $(function () {
            ID = "<%=Request.QueryString["ID"]%>";
        });
        function do_save() {
            var isValid = $("#<%=this.ff.ClientID%>").form('enableValidation').form('validate');
            if (!isValid) {
                return;
            }
            MaskUtil.mask('body', '提交中');
            $('#ff').form('submit', {
                url: '../Handler/ServiceHandler.ashx',
                onSubmit: function (param) {
                    param.visit = 'savebanjie';
                    param.ID = ID;
                },
                success: function (data) {
                    MaskUtil.unmask();
                    var dataObj = eval("(" + data + ")");
                    if (dataObj.status) {
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
                parent.document.getElementById('SubTabFrame').contentWindow.$("#tt_table").datagrid("reload");
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
            <%if (service.ServiceStatus == 0 || service.ServiceStatus == 3 || service.ServiceStatus == 10)
              { %>
            <a href="javascript:void(0)" onclick="do_save()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-save'">保存</a>
            <%} %>
            <a href="javascript:void(0)" onclick="do_close()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-close'">关闭</a>
        </div>
        <div class="table_container">
            <table class="info">
                <tr>
                    <td>接单人</td>
                    <td>
                        <input type="text" runat="server" name="AcceptMan" data-options="disabled:true" class="easyui-textbox" id="tdAcceptMan" /></td>
                    <td>预约时间</td>
                    <td>
                        <input type="text" runat="server" name="AppointTime" data-options="disabled:true" class="easyui-datetimebox" id="tdAppointTime" /></td>
                </tr>
                <tr>
                    <td>办结时间</td>
                    <td colspan="3">
                        <input type="text" runat="server" data-options="required:true" name="ChuLiTime" class="easyui-datetimebox" id="tdBanJieTime" /></td>
                </tr>
                <tr>
                    <td>办结情况</td>
                    <td colspan="3">
                        <input type="text" runat="server" name="td" class="easyui-textbox" id="tdBanJieNote" data-options="multiline:true" style="width: 100%; height: 60px;" /></td>
                </tr>
                <tr>
                    <%if (service.ServiceStatus == 1)
                      { %>
                    <td colspan="4" style="text-align: center;">该条任务已完成</td>
                    <%} %>
                </tr>
            </table>
        </div>
    </form>
</asp:Content>
