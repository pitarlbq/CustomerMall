<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="OrderShipCompanyEdit.aspx.cs" Inherits="Web.Mall.OrderShipCompanyEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        var ID, ParentID, type;
        $(function () {
            ID = "<%=this.CompanyID%>";
        });
        function do_save() {
            var isValid = $("#<%=this.ff.ClientID%>").form('enableValidation').form('validate');
            if (!isValid) {
                return;
            }
            MaskUtil.mask('body', '提交中');
            $('#ff').form('submit', {
                url: '../Handler/MallHandler.ashx',
                onSubmit: function (param) {
                    param.visit = 'savemallshipcompany';
                    param.ID = ID;
                },
                success: function (data) {
                    MaskUtil.unmask();
                    var dataObj = eval("(" + data + ")");
                    if (dataObj.status) {
                        if (dataObj.ID > 0) {
                            ID = dataObj.ID;
                            show_message('保存成功', 'success', function () {
                                do_close();
                            });
                            return;
                        }
                        show_message('数据不存在或已删除', 'warning');
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
        .image_box {
            width: 100px;
            display: inline-flexbox;
            margin-right: 10px;
        }

        .panel-body {
            background: #f0f0f0;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <form id="ff" runat="server" method="post" enctype="multipart/form-data">
        <div class="operation_box">
            <a href="javascript:void(0)" onclick="do_save()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-save'">保存</a>
            <a href="javascript:void(0)" onclick="do_close()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-close'">关闭</a>
        </div>
        <div class="table_container">
            <table class="info">
                <tr>
                    <td>发货方式名称</td>
                    <td>
                        <input type="text" class="easyui-textbox" runat="server" id="tdShipCompanyName" data-options="required:true" /></td>
                    <td>排序</td>
                    <td>
                        <input type="text" class="easyui-textbox" runat="server" id="tdSortOrder" data-options="required:true" /></td>
                </tr>
            </table>
        </div>
    </form>
</asp:Content>
