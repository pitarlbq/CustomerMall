<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="DoorDeviceEdit.aspx.cs" Inherits="Web.APPSetup.DoorDeviceEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        var ID, tdProjectID, hdRoomID, tdRoomID, tdUseForAll;
        $(function () {
            ID = "<%=this.DeviceID%>";
            tdProjectID = $('#<%=this.tdProjectID.ClientID%>');
            hdRoomID = $('#<%=this.hdRoomID.ClientID%>');
            tdRoomID = $('#<%=this.tdRoomID.ClientID%>');
            tdUseForAll = $('#<%=this.tdUseForAll.ClientID%>');
            getmalldoordeviceeditparams();
            tdUseForAll.combobox({
                onSelect: function () {
                    do_change_status();
                }
            })
            do_change_status();
        })
        function do_change_status() {
            var value = tdUseForAll.combobox('getValue');
            if (value == 1) {
                $('.show_choose_room').hide();
            }
            else {
                $('.show_choose_room').show();
            }
        }
        function do_save() {
            var isValid = $("#<%=this.ff.ClientID%>").form('enableValidation').form('validate');
            if (!isValid) {
                return;
            }
            MaskUtil.mask('body', '提交中');
            $('#ff').form('submit', {
                url: '../Handler/MallHandler.ashx',
                onSubmit: function (param) {
                    param.visit = 'savemalldoordevice';
                    param.ID = ID;
                    param.ProjectName = tdProjectID.combobox('getText');
                    param.RoomIDs = hdRoomID.val();
                },
                success: function (data) {
                    MaskUtil.unmask();
                    var dataObj = eval("(" + data + ")");
                    if (dataObj.status) {
                        show_message('保存成功', 'success', function () {
                            do_close();
                        });
                        return;
                    }
                    if (dataObj.error) {
                        show_message(dataObj.error, 'warning');
                        return;
                    }
                    else {
                        show_message('系统错误', 'error');
                    }
                }
            });
        }
        function getmalldoordeviceeditparams() {
            var options = { visit: 'getmalldoordeviceeditparams' };
            $.ajax({
                type: 'POST',
                dataType: 'json',
                data: options,
                url: "../Handler/MallHandler.ashx",
                success: function (data) {
                    if (data.status) {
                        tdProjectID.combobox({
                            editable: false,
                            valueField: "ID",
                            textField: "Name",
                            data: data.project_list
                        })
                    }
                }
            });
        }
        function do_close() {
            parent.do_close_dialog(function () {
                parent.$('#tt_table').datagrid('reload');
            });
        }
        var isupdate = false;
        function do_choose() {
            isupdate = false;
            var ProjectID = tdProjectID.combobox('getValue');
            if (ProjectID == '' || ProjectID == 0) {
                show_message('请选择小区', 'warning');
                return;
            }
            var iframe = "../APPSetup/ChooseProject.aspx?ParentID=" + ProjectID;
            do_open_dialog('选择楼栋', iframe);
        }
    </script>
    <style type="text/css">
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
                    <td>小区
                    </td>
                    <td colspan="3">
                        <input type="text" class="easyui-combobox" id="tdProjectID" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>名称
                    </td>
                    <td colspan="3">
                        <input type="text" class="easyui-textbox" id="tdDeviceName" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>串码
                    </td>
                    <td colspan="3">
                        <input type="text" class="easyui-textbox" id="tdDeviceCode" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>排序序号
                    </td>
                    <td colspan="3">
                        <input type="text" class="easyui-numberbox" id="tdSortOrder" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>使用范围
                    </td>
                    <td colspan="3">
                        <select id="tdUseForAll" runat="server" class="easyui-combobox" data-options="editable:false">
                            <option value="1">所有楼栋</option>
                            <option value="2">具体楼栋/单元</option>
                        </select>
                    </td>
                </tr>
                <tr class="show_choose_room">
                    <td>选择楼栋</td>
                    <td colspan="3">
                        <input type="text" class="easyui-textbox" id="tdRoomID" runat="server" data-options="readonly:true" />
                        <asp:HiddenField runat="server" ID="hdRoomID" />
                        <a href="javascript:void(0)" onclick="do_choose()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-choose'">选择</a>
                    </td>
                </tr>
                <tr>
                    <td>二维码开门
                    </td>
                    <td colspan="3">
                        <select id="tdDisableQrCodeOpen" runat="server" class="easyui-combobox" data-options="editable:false">
                            <option value="1">启用</option>
                            <option value="0">停用</option>
                        </select>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</asp:Content>
