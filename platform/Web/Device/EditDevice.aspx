<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="EditDevice.aspx.cs" Inherits="Web.Device.EditDevice" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../js/Page/Comm/util.js"></script>
    <title>新增设备</title>
    <script>
        var ID;
        $(function () {
            ID = "<%=Request.QueryString["ID"]%>" || 0;
            loadServiceType(true, true, true, true, true, true);
            addFile();
            loadattachs();
        });
        function loadServiceType(loadDeviceType, loadRepairUser, loadCheckUser, loadDeviceGroup, loadTaskType, loadProject) {
            var options = { visit: "getdeviceparams" };
            $.ajax({
                type: 'POST',
                data: options,
                dataType: 'json',
                url: '../Handler/DeviceHandler.ashx',
                success: function (data) {
                    if (loadDeviceType) {
                        $("#<%=this.tdDeviceType.ClientID%>").combobox({
                            editable: false,
                            data: data.devicetype,
                            valueField: 'ID',
                            textField: 'DeviceTypeName'
                        });
                    }
                    if (loadRepairUser) {
                        $("#<%=this.tdRepairUser.ClientID%>").combobox({
                            editable: false,
                            data: data.users,
                            valueField: 'UserID',
                            textField: 'RealName'
                        });
                    }
                    if (loadCheckUser) {
                        $("#<%=this.tdCheckUser.ClientID%>").combobox({
                            editable: false,
                            data: data.users,
                            valueField: 'UserID',
                            textField: 'RealName'
                        });
                    }
                    if (loadDeviceGroup) {
                        $("#<%=this.tdDeviceGroup.ClientID%>").combobox({
                            editable: false,
                            data: data.devicegroup,
                            valueField: 'ID',
                            textField: 'DeviceGroupName',
                            onSelect: function (rec) {
                                if (rec.RepairUserID > 0) {
                                    $("#<%=this.tdRepairUser.ClientID%>").combobox('setValue', rec.RepairUserID);
                                }
                                if (rec.CheckUserID > 0) {
                                    $("#<%=this.tdCheckUser.ClientID%>").combobox('setValue', rec.CheckUserID);
                                }
                            }
                        });
                    }
                    if (loadTaskType) {
                        var tasktype = $("#<%=this.tdTaskType.ClientID%>").combobox('getValue');
                        $("#<%=this.tdTaskType.ClientID%>").combobox({
                            editable: false,
                            data: data.tasktypes,
                            valueField: 'ID',
                            textField: 'TaskTypeName'
                        });
                        if (tasktype != '') {
                            $("#<%=this.tdTaskType.ClientID%>").combobox('setValue', tasktype);
                        }
                    }
                    if (loadProject) {
                        var projectid = $("#<%=this.tdProjectName.ClientID%>").combobox('getValue');
                        $("#<%=this.tdProjectName.ClientID%>").combobox({
                            editable: false,
                            data: data.projects,
                            valueField: 'ID',
                            textField: 'Name'
                        });
                        if (tasktype != '') {
                            $("#<%=this.tdProjectName.ClientID%>").combobox('setValue', projectid);
                        }
                    }
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
                    param.visit = 'savedevice';
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
            Util.get({ action: "getdeviceimgs", ID: ID }, function (succeed, data, err) {
                if (succeed) {
                    var $html = '';
                    $("#trExistFiles").html($html);
                    if (data.length > 0) {
                        $("#trExistFiles").show();
                        $html += '<td>已上传附件</td>';
                        $html += '<td colspan="3">';
                        $.each(data, function (index, item) {
                            $html += '<div>' + item.FileOriName + ' &nbsp;&nbsp;&nbsp;&nbsp;<a href="' + item.AttachedFilePath + '" target="_blank" >下载</a>&nbsp;&nbsp;&nbsp;&nbsp;';
                            $html += '<a href="#" onclick="deleteAttach(' + item.ID + ')">删除</a></div>';
                        })
                        $html += '</td>';
                    }
                    $("#trExistFiles").append($html);
                }
                else {
                    show_message('系统错误', 'error');
                }
            });
        }
        function deleteAttach(AttachID) {
            top.$.messager.confirm("提示", "是否删除选已上传的文件?", function (r) {
                if (r) {
                    Util.post({ action: "deletedeviceimg", ID: AttachID }, function (succeed, data, err) {
                        if (succeed) {
                            show_message('删除成功', 'success', function () {
                                loadattachs();
                            });
                        }
                        else {
                            show_message('系统错误', 'error');
                        }
                    });
                }
            })
        }
        function addTaskType() {
            var iframe = "../SysSeting/EditDeviceTaskTypeCombobox.aspx";
            do_open_dialog('维保类型', iframe);
        }
        function OpenRepairCheckList(TaskType) {
            var title = '';
            if (TaskType === 'repair') {
                title = '维保记录';
            }
            else if (TaskType === 'check') {
                title = '巡检记录';
            }
            var iframe = "../Device/DeviceRepairCheckView.aspx?DeviceID=" + ID + "&TaskType=" + TaskType;
            do_open_dialog('维保类型', iframe);
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
            <div class="table_title">设备台帐</div>
            <table class="info">
                <tr>
                    <td>设备编码</td>
                    <td>
                        <input type="text" runat="server" data-options="required:true" class="easyui-textbox" id="tdDeviceNo" /></td>
                    <td>设备类型</td>
                    <td>
                        <input type="text" runat="server" data-options="required:true" class="easyui-combobox" id="tdDeviceType" />
                    </td>
                </tr>
                <tr>
                    <td>设备分组</td>
                    <td>
                        <input type="text" runat="server" data-options="required:true" class="easyui-combobox" id="tdDeviceGroup" />
                    </td>
                    <td>设备名称</td>
                    <td>
                        <input type="text" runat="server" data-options="required:true" class="easyui-textbox" id="tdDeviceName" /></td>
                </tr>
                <tr>
                    <td>所属项目</td>
                    <td>
                        <input type="text" runat="server" class="easyui-combobox" id="tdProjectName" /></td>
                    <td>存放位置</td>
                    <td>
                        <input type="text" runat="server" class="easyui-textbox" id="tdLocationPlace" /></td>
                </tr>
                <tr>
                    <td>规格型号</td>
                    <td>
                        <input type="text" runat="server" class="easyui-textbox" id="tdModelNo" /></td>
                    <td>设备状态</td>
                    <td>
                        <select type="text" runat="server" class="easyui-combobox" id="tdDeviceStatus">
                            <option value="1">正常</option>
                            <option value="2">停用</option>
                            <option value="3">报废</option>
                        </select>
                    </td>
                </tr>
                <tr>
                    <td>设备等级</td>
                    <td>
                        <select type="text" runat="server" class="easyui-combobox" id="tdDeviceLevel">
                            <option value="重要设备">重要设备</option>
                            <option value="关键设备">关键设备</option>
                            <option value="普通设备">普通设备</option>
                        </select></td>
                    <td>维保类型</td>
                    <td>
                        <input type="text" runat="server" class="easyui-combobox" id="tdTaskType" />
                        <label>
                            <a href="javascript:void(0)" onclick="addTaskType()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-add'">新增</a>
                        </label>
                    </td>
                </tr>
                <tr>
                    <td>供应商单位</td>
                    <td>
                        <input type="text" runat="server" class="easyui-textbox" id="tdSupplier" /></td>
                    <td>供应商联系人</td>
                    <td>
                        <input type="text" runat="server" class="easyui-textbox" id="tdSupplierMan" /></td>

                </tr>
                <tr>
                    <td>供应商联系方式</td>
                    <td>
                        <input type="text" runat="server" class="easyui-textbox" id="tdSupplierPhone" /></td>
                    <td>购入日期</td>
                    <td>
                        <input type="text" runat="server" class="easyui-datebox" id="tdPurchaseDate" /></td>
                </tr>
                <tr>
                    <td>质保期</td>
                    <td>
                        <input type="text" runat="server" class="easyui-textbox" id="tdGuaranteeDate" /></td>
                    <td>质保到期日期</td>
                    <td>
                        <input type="text" runat="server" class="easyui-datebox" id="tdGuaranteeEndDate" /></td>
                </tr>
                <tr>
                    <td>维保单位</td>
                    <td>
                        <input type="text" runat="server" class="easyui-textbox" id="tdRepairCompany" /></td>
                    <td>维保责任人</td>
                    <td>
                        <input type="text" runat="server" class="easyui-combobox" id="tdRepairUser" /></td>
                </tr>
                <tr>
                    <td>维保联系方式</td>
                    <td>
                        <input type="text" runat="server" class="easyui-textbox" id="tdRepairUserPhone" /></td>
                    <td>首次维保日期</td>
                    <td>
                        <input type="text" runat="server" class="easyui-datebox" id="tdFirstRepairDate" /></td>
                </tr>
                <tr>
                    <td>上次维保日期
                    </td>
                    <td>
                        <input type="text" runat="server" class="easyui-textbox" id="tdLastRepairDate" data-options="readonly:true" /></td>
                    <td>本次维保日期
                    </td>
                    <td>
                        <input type="text" runat="server" class="easyui-datebox" id="tdThisRepairDate" /></td>
                </tr>
                <tr>
                    <td>维保周期</td>
                    <td>
                        <input type="text" runat="server" class="easyui-textbox" id="tdRepairCount" />
                        <select style="margin-left: 5px; width: 60px;" runat="server" class="easyui-combobox" id="tdRepairCycle">
                            <option value="day">天</option>
                            <option value="month">月</option>
                        </select>
                    </td>
                    <%if (device != null)
                      { %>
                    <td>
                        <label>维保记录</label>
                    </td>
                    <td colspan="3">
                        <a href="javascript:void(0)" onclick="OpenRepairCheckList('repair')" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-detail'">点击查看</a>
                    </td>
                    <%} %>
                </tr>
                <tr>
                    <td>巡检责任人</td>
                    <td>
                        <input type="text" runat="server" class="easyui-combobox" id="tdCheckUser" /></td>
                    <td>首次巡检日期</td>
                    <td>
                        <input type="text" runat="server" class="easyui-datebox" id="tdFirstCheckDate" /></td>
                </tr>
                <tr>
                    <td>上次巡检日期
                    </td>
                    <td>
                        <input type="text" runat="server" class="easyui-textbox" id="tdLastCheckDate" data-options="readonly:true" /></td>
                    <td>本次巡检日期
                    </td>
                    <td>
                        <input type="text" runat="server" class="easyui-datebox" id="tdThisCheckDate" /></td>
                </tr>
                <tr>
                    <td>巡检周期</td>
                    <td>
                        <input type="text" runat="server" class="easyui-textbox" id="tdCheckCount" />
                        <select style="margin-left: 5px; width: 60px;" runat="server" class="easyui-combobox" id="tdCheckCycle">
                            <option value="day">天</option>
                            <option value="month">月</option>
                        </select>
                    </td>
                    <%if (device != null)
                      { %>
                    <td>巡检记录
                    </td>
                    <td>
                        <a href="javascript:void(0)" onclick="OpenRepairCheckList('check')" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-detail'">点击查看</a>
                    </td>
                    <%} %>
                </tr>
                <tr id="trExistFiles" style="display: none;">
                </tr>
                <tr>
                    <td>附件</td>
                    <td colspan="3" id="tdFile"></td>
                </tr>
                <tr>
                    <td>备注</td>
                    <td colspan="3">
                        <input runat="server" id="tdRemark" type="text" class="easyui-textbox" data-options="multiline:true" style="height: 80px; width: 100%;" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</asp:Content>
