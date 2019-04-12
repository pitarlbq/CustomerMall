<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="UserCheckRejectProcess.aspx.cs" Inherits="Web.Mall.UserCheckRejectProcess" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        var ID = 0;
        $(function () {
            ID = "<%=this.RequestID%>";
        })
        function do_save(status) {
            var isValid = $("#<%=this.ff.ClientID%>").form('enableValidation').form('validate');
            if (!isValid) {
                return;
            }
            var rows = parent.$("#tt_table").datagrid("getSelections");
            if (rows.length == 0 && ID == 0) {
                show_message("请至少选择一条数据进行此操作", "info");
                return;
            }
            var IDList = [];
            $.each(rows, function (index, row) {
                IDList.push(row.ID);
            })
            MaskUtil.mask('body', '提交中');
            $('#ff').form('submit', {
                url: '../Handler/MallHandler.ashx',
                onSubmit: function (param) {
                    param.visit = 'processmallusercheck';
                    param.IDList = JSON.stringify(IDList);
                    param.ID = ID;
                    param.Status = status;
                },
                success: function (data) {
                    MaskUtil.unmask();
                    var dataObj = eval("(" + data + ")");
                    if (dataObj.status) {
                        show_message('操作成功', 'success', function () {
                            do_close();
                        });
                        return;
                    }
                    if (dataObj.error) {
                        show_message(dataObj.error, 'warning');
                        return;
                    }
                    show_message('系统错误', 'error');
                }
            });
        }
        function do_close() {
            parent.do_close_dialog(function () {
                parent.$('#tt_table').datagrid('reload');
            });
        }
    </script>
    <style>
        .panel-body {
            background: #f0f0f0;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <form id="ff" runat="server" method="post" enctype="multipart/form-data">
        <div class="operation_box">
            <a href="javascript:void(0)" onclick="do_save(2)" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-save'">作废原考核</a>
            <a href="javascript:void(0)" onclick="do_save(1)" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-save'">维持原考核</a>
            <a href="javascript:void(0)" onclick="do_close()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-close'">关闭</a>
        </div>
        <div class="table_container">
            <table class="info">
                <tr>
                    <td>申诉时间</td>
                    <td colspan="3">
                        <input type="text" class="easyui-datetimebox" runat="server" id="tdConfirmTime" data-options="readonly:true" /></td>
                </tr>
                <tr>
                    <td>申诉人</td>
                    <td colspan="3">
                        <input type="text" class="easyui-textbox" runat="server" id="tdConfirmMan" data-options="readonly:true" /></td>
                </tr>
                <tr>
                    <td>申诉原因</td>
                    <td colspan="3">
                        <input type="text" class="easyui-textbox" runat="server" id="tdConfirmRemark" data-options="multiline:true,readonly:true" style="width: 85%; height: 60px;" /></td>
                </tr>
                <tr>
                    <td>处理结果</td>
                    <td colspan="3">
                        <input type="text" class="easyui-textbox" runat="server" id="tdProcessRemark" data-options="multiline:true" style="width: 85%; height: 60px;" /></td>
                </tr>
            </table>
        </div>
    </form>
</asp:Content>
