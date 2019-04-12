<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="EditDeviceType.aspx.cs" Inherits="Web.Device.EditDeviceType" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>新增设备类型</title>
    <script>
        var ID, ParentID;
        $(function () {
            ID = "<%=Request.QueryString["ID"]%>";
            ParentID = "<%=Request.QueryString["ParentID"]%>";
        });
        function do_save() {
            var isValid = $("#<%=this.ff.ClientID%>").form('enableValidation').form('validate');
            if (!isValid) {
                return;
            }
            $('#ff').form('submit', {
                url: '../Handler/DeviceHandler.ashx',
                onSubmit: function (param) {
                    param.visit = 'savedevicetype';
                    param.ID = ID;
                    param.ParentID = ParentID;
                },
                success: function (data) {
                    var dataObj = eval("(" + data + ")");
                    if (dataObj.status) {
                        if (dataObj.ID > 0) {
                            ID = dataObj.ID;
                            show_message('保存成功', 'success', function () {
                                do_close();
                            });
                            return;
                        }
                        show_message("设备不存在", "warning");
                    }
                    else {
                        show_message('系统错误', 'error');
                    }
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
            <a href="javascript:void(0)" onclick="do_save()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-save'">保存</a>
            <a href="javascript:void(0)" onclick="do_close()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-close'">关闭</a>
        </div>
        <div class="table_container">
            <table class="info">
                <tr>
                    <td>编码</td>
                    <td>
                        <input type="text" runat="server" name="Code" class="easyui-textbox" id="tdCode" />
                    </td>
                    <td>上级类型</td>
                    <td>
                        <input type="text" runat="server" name="ParentID" data-options="disabled:true" class="easyui-textbox" id="tdParentID" /></td>
                </tr>
                <tr>
                    <td>设备类型</td>
                    <td colspan="3">
                        <input type="text" runat="server" style="width: 80%;" data-options="required:true" name="DeviceTypeName" class="easyui-textbox" id="tdDeviceTypeName" />
                    </td>
                </tr>
                <tr>
                    <td>说明</td>
                    <td colspan="3">
                        <input type="text" runat="server" name="Description" data-options="multiline:true" class="easyui-textbox" id="tdDescription" style="width: 80%; height: 50px;" /></td>
                </tr>
            </table>
        </div>
    </form>
</asp:Content>
