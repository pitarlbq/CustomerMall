<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="EditDeviceGroup.aspx.cs" Inherits="Web.Device.EditDeviceGroup" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../js/Page/Comm/PinYin.js?t=1_<%=base.getToken() %>"></script>
    <title>新增设备分组</title>
    <script>
        var ID;
        $(function () {
            ID = "<%=Request.QueryString["ID"]%>";
            getUserList();
        });
        function do_save() {
            var isValid = $("#<%=this.ff.ClientID%>").form('enableValidation').form('validate');
            if (!isValid) {
                return;
            }
            $('#ff').form('submit', {
                url: '../Handler/DeviceHandler.ashx',
                onSubmit: function (param) {
                    param.visit = 'savedevicegroup';
                    param.ID = ID;
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
        function getUserList() {
            var options = { visit: 'getuserlist' };
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/DeviceHandler.ashx',
                data: options,
                success: function (data) {
                    $("#<%=this.tdRepairUserID.ClientID%>").combobox({
                        editable: true,
                        data: data.UserList,
                        valueField: 'UserID',
                        textField: 'RealName',
                        filter: function (q, row) {
                            var opts = $(this).combobox('options');
                            return __pinyin.getFirstLetter(row[opts.textField]).indexOf(q.toLowerCase()) != -1 || row[opts.textField].indexOf(q) != -1;
                        }
                    });
                    $("#<%=this.tdCheckUserID.ClientID%>").combobox({
                        editable: true,
                        data: data.UserList,
                        valueField: 'UserID',
                        textField: 'RealName',
                        filter: function (q, row) {
                            var opts = $(this).combobox('options');
                            return __pinyin.getFirstLetter(row[opts.textField]).indexOf(q.toLowerCase()) != -1 || row[opts.textField].indexOf(q) != -1;
                        }
                    });
                }
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
                    <td>分组名称</td>
                    <td>
                        <input type="text" runat="server" name="DeviceGroupName" data-options="required:true" class="easyui-textbox" id="tdDeviceGroupName" /></td>
                </tr>
                <tr>
                    <td>维保责任人</td>
                    <td>
                        <input type="text" runat="server" name="RepairUserID" class="easyui-combobox" id="tdRepairUserID" />
                    </td>
                    <td>巡检责任人</td>
                    <td>
                        <input type="text" runat="server" name="CheckUserID" class="easyui-combobox" id="tdCheckUserID" />
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
