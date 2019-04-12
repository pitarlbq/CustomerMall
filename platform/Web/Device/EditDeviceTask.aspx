<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="EditDeviceTask.aspx.cs" Inherits="Web.Device.EditDeviceTask" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>新增设备</title>
    <script>
        var ID, hdDeviceID, tdDeviceName, tdDeviceType, tdDeviceGroup, tdModelNo;
        $(function () {
            ID = "<%=this.TaskID%>";
            tdDeviceName = $('#<%=this.tdDeviceName.ClientID%>');
            tdDeviceType = $('#<%=this.tdDeviceType.ClientID%>');
            tdDeviceGroup = $('#<%=this.tdDeviceGroup.ClientID%>');
            tdModelNo = $('#<%=this.tdModelNo.ClientID%>');
            getComboboxs();
            addFile();
            loadattachs();
        });
        function getComboboxs() {
            var TaskFromList = [];
            if (Number(ID) <= 0) {
                TaskFromList.push({ ID: 'customerservice', Name: '客服中心' });
                TaskFromList.push({ ID: 'internalpost', Name: '内部报事' });
            }
            else {
                var Data_ID = '<%=this.device!=null?this.device.TaskFrom:""%>';
                var Data_Name = '<%=this.device!=null?this.device.TaskFromDesc:""%>';
                TaskFromList.push({ ID: Data_ID, Name: Data_Name });
            }
            $('#<%=this.tdTaskFrom.ClientID%>').combobox({
                editable: false,
                data: TaskFromList,
                valueField: 'ID',
                textField: 'Name'
            });

            var TaskTypeList = [];
            if (ID <= 0) {
                TaskTypeList.push({ ID: 'manual_repair', Name: '临时维保' });
                TaskTypeList.push({ ID: 'manual_check', Name: '临时巡检' });
                TaskTypeList.push({ ID: 'normal_task', Name: '日常维修' });
            }
            else {
                var Data_ID = '<%=this.device!=null?this.device.TaskType:""%>';
                var Data_Name = '<%=this.device!=null?this.device.TaskTypeDesc:""%>';
                TaskTypeList.push({ ID: Data_ID, Name: Data_Name });
            }
            $('#<%=this.tdTaskType.ClientID%>').combobox({
                editable: false,
                data: TaskTypeList,
                valueField: 'ID',
                textField: 'Name'
            });
            var options = { visit: "getdevicetaskparams" };
            $.ajax({
                type: 'POST',
                data: options,
                dataType: 'json',
                url: '../Handler/DeviceHandler.ashx',
                success: function (data) {
                    $("#<%=this.tdTaskChargeMan.ClientID%>").combobox({
                        editable: false,
                        data: data.users,
                        valueField: 'UserID',
                        textField: 'RealName'
                    });
                }
            })
            }
            function do_save() {
                var isValid = $("#<%=this.ff.ClientID%>").form('enableValidation').form('validate');
                if (!isValid) {
                    return;
                }
                $('#ff').form('submit', {
                    url: '../Handler/DeviceHandler.ashx',
                    onSubmit: function (param) {
                        param.visit = 'savedevicetask';
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
                            show_message("任务不存在", "warning");
                        }
                        else {
                            show_message('系统错误', 'error');
                        }
                    }
                });
            }
            var filecount = 0;
            function addFile() {
                $("#tdFile").find("a.fileadd").hide();
                $("#tdFile").find("a.fileremove").show();
                filecount++;
                var $html = "<div id=\"tdFile_" + filecount + "\">";
                $html += "<input class=\"easyui-filebox\" name=\"attachfile\" data-options=\"prompt:'请选择文件',buttonText: '选择文件'\" style=\"width: 60%\" />";
                $html += "<a href=\"javascript:void(0)\" onclick=\"addFile()\" class=\"easyui-linkbutton btnlinkbar fileadd\" data-options=\"plain:true,iconCls:'icon-add'\">添加</a>";
                $html += "<a href=\"javascript:void(0)\" onclick=\"deleteFile(" + filecount + ")\" class=\"easyui-linkbutton btnlinkbar fileremove\" style=\"display:none;\" data-options=\"plain:true,iconCls:'icon-remove'\">删除</a>";
                $html += "</div>";
                $("#tdFile").append($html);
                $.parser.parse("#tdFile_" + filecount);
            }
            function deleteFile(id) {
                $("#tdFile_" + id).html("");
            }
            function loadattachs() {
                var options = { visit: 'getdevicetaskimgs', ID: ID };
                $.ajax({
                    type: 'POST',
                    dataType: 'json',
                    url: '../Handler/DeviceHandler.ashx',
                    data: options,
                    success: function (message) {
                        if (message.status) {
                            var $html = '';
                            $("#trExistFiles").html($html);
                            if (message.list.length > 0) {
                                $("#trExistFiles").show();
                                $html += '<td>已上传附件</td>';
                                $html += '<td colspan="3">';
                                $.each(message.list, function (index, item) {
                                    $html += '<div>' + item.FileOriName + ' &nbsp;&nbsp;&nbsp;&nbsp;<a href="' + item.AttachedFilePath + '" target="_blank" >下载</a>&nbsp;&nbsp;&nbsp;&nbsp;';
                                    $html += '<a href="#" onclick="deleteAttach(' + item.ID + ')">删除</a></div>';
                                })
                                $html += '</td>';
                            }
                            $("#trExistFiles").append($html);
                            return;
                        }
                        show_message('系统错误', 'error');
                    }
                });
            }
            function deleteAttach(AttachID) {
                top.$.messager.confirm("提示", "是否删除选已上传的文件?", function (r) {
                    if (r) {
                        var options = { visit: 'removedevicetaskimg', ID: AttachID };
                        $.ajax({
                            type: 'POST',
                            dataType: 'json',
                            url: '../Handler/DeviceHandler.ashx',
                            data: options,
                            success: function (message) {
                                if (message.status) {
                                    show_message('删除成功', 'success', function () {
                                        loadattachs();
                                    });
                                    return;
                                }
                                show_message('系统错误', 'error');
                            }
                        });
                    }
                })
            }
            function choosedevice() {
                hdDeviceID = $('#<%=this.hdDeviceID.ClientID%>').val();
                var iframe = "../Device/ChooseDevice.aspx";
                do_open_dialog('选择设备', iframe);
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
            <div class="table_title">设备信息</div>
            <table class="info">
                <tr>
                    <td>设备名称</td>
                    <td>
                        <input type="text" runat="server" data-options="readonly:true" class="easyui-textbox" id="tdDeviceName" />
                        <asp:HiddenField runat="server" ID="hdDeviceID" />
                        <label>
                            <a href="javascript:void(0)" onclick="choosedevice()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-choose'">选择</a>
                        </label>
                    </td>
                    <td>设备类型</td>
                    <td>
                        <input type="text" runat="server" data-options="readonly:true" class="easyui-textbox" id="tdDeviceType" />
                    </td>
                </tr>
                <tr>
                    <td>设备分组</td>
                    <td>
                        <input type="text" runat="server" data-options="readonly:true" class="easyui-textbox" id="tdDeviceGroup" />
                    </td>
                    <td>规格型号</td>
                    <td>
                        <input type="text" runat="server" data-options="readonly:true" class="easyui-textbox" id="tdModelNo" /></td>
                </tr>
                <tr>
                    <td colspan="4" style="text-align: center;">任务信息</td>
                </tr>
                <tr>
                    <td>任务来源</td>
                    <td>
                        <input type="text" class="easyui-combobox" runat="server" id="tdTaskFrom" />
                    </td>
                    <td>任务类型
                    </td>
                    <td>
                        <input type="text" class="easyui-combobox" runat="server" id="tdTaskType" />
                    </td>
                </tr>
                <tr>
                    <td>紧急程度</td>
                    <td>
                        <select id="tdTaskLevel" class="easyui-combobox" runat="server">
                            <option value="紧急">紧急</option>
                            <option value="一般">一般</option>
                        </select></td>
                    <td>任务状态
                    </td>
                    <td>
                        <select id="tdTaskStatus" class="easyui-combobox" runat="server">
                            <option value="1">待处理</option>
                            <option value="2">处理中</option>
                            <option value="3">已完成</option>
                        </select></td>
                </tr>
                <tr>
                    <td>责任人</td>
                    <td>
                        <input type="text" class="easyui-combobox" id="tdTaskChargeMan" runat="server" />
                    </td>
                    <td>联系方式</td>
                    <td>
                        <input type="text" class="easyui-textbox" id="tdTaskChargeManPhone" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>工单内容</td>
                    <td colspan="3">
                        <input type="text" class="easyui-textbox" runat="server" id="tdTaskContent" data-options="multiline:true" style="height: 60px; width: 100%;" />
                    </td>
                </tr>
                <tr>
                    <td>任务时间</td>
                    <td colspan="3">
                        <input type="text" class="easyui-datebox" runat="server" id="tdTaskTime" />
                    </td>
                </tr>
                <tr>
                    <td colspan="4" style="text-align: center;">完成信息</td>
                </tr>
                <tr>
                    <td>完成时间</td>
                    <td colspan="3">
                        <input type="text" class="easyui-datetimebox" runat="server" id="tdTaskCompleteTime" />
                    </td>
                </tr>
                <tr>
                    <td>处理记录</td>
                    <td colspan="3">
                        <input type="text" class="easyui-textbox" runat="server" id="tdTaskCompleteContent" data-options="multiline:true" style="height: 60px; width: 100%;" />
                    </td>
                </tr>
                <tr id="trExistFiles" style="display: none;">
                </tr>
                <tr>
                    <td>现场图片</td>
                    <td colspan="3" id="tdFile"></td>
                </tr>
            </table>
        </div>
    </form>
</asp:Content>
