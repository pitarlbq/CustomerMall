<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="DoorCardEdit.aspx.cs" Inherits="Web.APPSetup.DoorCardEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        var ID, tdProjectID, tdDeviceList, tdUserName, hdUserID, hdDeviceList, hdRelationID, tdUserName;
        $(function () {
            ID = "<%=this.CardID%>";
            tdProjectID = $('#<%=this.tdProjectID.ClientID%>');
            tdDeviceList = $('#<%=this.tdDeviceList.ClientID%>');
            hdDeviceList = $('#<%=this.hdDeviceList.ClientID%>');
            tdUserName = $('#<%=this.tdUserName.ClientID%>');
            hdUserID = $('#<%=this.hdUserID.ClientID%>');
            hdRelationID = $('#<%=this.hdRelationID.ClientID%>');
            getmalldoordeviceeditparams();
            tdUserName.textbox('setValue', $('#<%=this.hdUserName.ClientID%>').val());
        })
        function do_save() {
            var isValid = $("#<%=this.ff.ClientID%>").form('enableValidation').form('validate');
            if (!isValid) {
                return;
            }
            MaskUtil.mask('body', '提交中');
            $('#ff').form('submit', {
                url: '../Handler/MallHandler.ashx',
                onSubmit: function (param) {
                    param.visit = 'savemalldoorcard';
                    param.ID = ID;
                    param.ProjectName = tdProjectID.combobox('getText');
                    param.UserID = hdUserID.val();
                    param.RelationID = hdRelationID.val();
                    param.DeviceIDList = hdDeviceList.val();
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
        var device_list = [];
        function get_my_devices(ProjectID) {
            var list = [];
            $.each(device_list, function (index, item) {
                if (ProjectID == item.ProjectID) {
                    list.push(item);
                }
            })
            tdDeviceList.combobox({
                editable: false,
                valueField: "ID",
                textField: "Name",
                data: list,
                multiple: true,
                onSelect: function (ret) {
                    var values = tdDeviceList.combobox('getValues');
                    hdDeviceList.val(JSON.stringify(values));
                },
                onUnSelect: function (ret) {
                    var values = tdDeviceList.combobox('getValues');
                    hdDeviceList.val(JSON.stringify(values));
                }
            })
            var IDList = [];
            $.each(list, function (index, item) {
                IDList.push(item.ID);
            })
            $('#tdCheckAll').bind('click', function () {
                if ($(this).prop('checked')) {
                    tdDeviceList.combobox('setValues', IDList);
                    hdDeviceList.val(JSON.stringify(IDList));
                } else {
                    tdDeviceList.combobox('setValues', []);
                    hdDeviceList.val("[]");
                }
            })
        }
        function getmalldoordeviceeditparams() {
            var options = { visit: 'getmalldoorcardeditparams' };
            $.ajax({
                type: 'POST',
                dataType: 'json',
                data: options,
                url: "../Handler/MallHandler.ashx",
                success: function (data) {
                    if (data.status) {
                        device_list = data.device_list;
                        tdProjectID.combobox({
                            editable: false,
                            valueField: "ID",
                            textField: "Name",
                            data: data.project_list,
                            onSelect: function (ret) {
                                get_my_devices(ret.ID);
                            }
                        })
                        var ProjectID = tdProjectID.combobox('getValue');
                        if (ProjectID > 0) {
                            get_my_devices(ProjectID);
                        }
                    }
                }
            });
        }
        function choose_user() {
            var ProjectID = tdProjectID.combobox('getValue');
            if (ProjectID == '' || ProjectID == 0) {
                show_message('请选择小区', 'warning');
                return;
            }
            var iframe = "../APPSetup/ChooseProjectUser.aspx?singleselect=1&ProjectID=" + ProjectID;
            do_open_dialog('选择用户', iframe);
        }
        function do_close() {
            parent.do_close_dialog(function () {
                parent.$("#tt_table").datagrid("reload");
            })
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
                        <input type="text" class="easyui-combobox" id="tdProjectID" runat="server" data-options="required:true" />
                    </td>
                </tr>
                <tr>
                    <td>设备
                    </td>
                    <td colspan="3">
                        <input type="text" class="easyui-combobox" id="tdDeviceList" runat="server" data-options="required:true" />
                        <input style="width: 30px;" type="checkbox" id="tdCheckAll" />全选
                        <asp:HiddenField runat="server" ID="hdDeviceList" />
                    </td>
                </tr>
                <tr>
                    <td>用户
                    </td>
                    <td colspan="3">
                        <input type="text" class="easyui-textbox" id="tdUserName" runat="server" data-options="multiline:true,editable:false" />
                        <asp:HiddenField runat="server" ID="hdUserName" />
                        <asp:HiddenField runat="server" ID="hdUserID" />
                        <asp:HiddenField runat="server" ID="hdRelationID" />
                        <a href="javascript:void(0)" onclick="choose_user()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-choose'">选择</a>
                    </td>
                </tr>
                <tr>
                    <td>门卡名称
                    </td>
                    <td colspan="3">
                        <input type="text" class="easyui-textbox" id="tdCardName" runat="server" data-options="required:true" />
                    </td>
                </tr>
                <tr>
                    <td>卡片UID
                    </td>
                    <td colspan="3">
                        <input type="text" class="easyui-textbox" id="tdCardUID" runat="server" data-options="required:true" />
                    </td>
                </tr>
                <tr>
                    <td>卡片编号
                    </td>
                    <td colspan="3">
                        <input type="text" class="easyui-textbox" id="tdDoorNumber" runat="server" data-options="required:true" />
                    </td>
                </tr>
                <tr>
                    <td>排序序号
                    </td>
                    <td colspan="3">
                        <input type="text" class="easyui-textbox" id="tdSortOrder" runat="server" data-options="required:true" />
                    </td>
                </tr>
                <tr>
                    <td>截止日期
                    </td>
                    <td colspan="3">
                        <input type="text" class="easyui-datebox" id="tdExpireDate" runat="server" data-options="required:true" />
                    </td>
                </tr>
                <tr>
                    <td>描述
                    </td>
                    <td colspan="3">
                        <input type="text" class="easyui-textbox" id="tdCardSummary" runat="server" data-options="multiline:true" style="width: 70%; height: 50px;" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</asp:Content>
