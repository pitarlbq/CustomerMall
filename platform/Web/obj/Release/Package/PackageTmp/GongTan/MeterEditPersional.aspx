<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="MeterEditPersional.aspx.cs" Inherits="Web.GongTan.MeterEditPersional" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        var hdProjectIDs, hdRoomType;
        $(function () {
        });
        function do_save() {
            var isValid = $("#<%=this.ff.ClientID%>").form('enableValidation').form('validate');
            if (!isValid) {
                return;
            }
            var roomids = [];
            var projectids = [];
            try {
                roomids = parent.GetSelectedRooms();
                projectids = parent.GetSelectedProjects();
            } catch (e) {
            }
            if (roomids.length == 0 && projectids.length == 0) {
                show_message('请选择关联资源', "warning");
                return;
            }
            $('#ff').form('submit', {
                url: '../Handler/ImportFeeHandler.ashx',
                onSubmit: function (param) {
                    param.visit = 'doaddmeterdata';
                    param.RoomIDList = JSON.stringify(roomids);
                    param.ProjectIDList = JSON.stringify(projectids);
                    param.MeterType = 1;
                },
                success: function (data) {
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
                    <td>仪表名称
                    </td>
                    <td>
                        <input type="text" id="tdMeterName" class="easyui-textbox" data-options="required:true" style="width: 200px;" runat="server" />
                    </td>
                    <td>仪表编号</td>
                    <td>
                        <input type="text" id="tdMeterNumber" class="easyui-textbox" style="width: 200px;" runat="server" /></td>
                </tr>
                <tr>
                    <td>资源编号</td>
                    <td colspan="3">
                        <input type="text" id="tdProjectNames" class="easyui-textbox" data-options="readonly:true,placeholder:'请选择资源数'" style="width: 85%;" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>仪表种类</td>
                    <td>
                        <select type="text" data-options="editable:false" id="tdMeterCategory" class="easyui-combobox" style="width: 200px;" runat="server">
                            <option value="1">水表</option>
                            <option value="2">电表</option>
                            <option value="3">气表</option>
                        </select></td>
                    <td>仪表类型</td>
                    <td>
                        <select type="text" data-options="editable:false,readonly:true" id="tdMeterType" class="easyui-combobox" style="width: 200px;" runat="server">
                            <option value="1">住户</option>
                            <option value="2">公共</option>
                        </select>
                    </td>
                </tr>
                <tr>
                    <td>仪表规格</td>
                    <td>
                        <select type="text" data-options="editable:false" id="tdMeterSpec" class="easyui-combobox" style="width: 200px;" runat="server">
                            <option value="1">分表</option>
                            <option value="2">总表</option>
                        </select>
                    </td>
                    <td>倍率</td>
                    <td>
                        <input type="text" id="tdMeterCoefficient" class="easyui-textbox" data-options="required:false" style="width: 200px;" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>缴费户号</td>
                    <td>
                        <input type="text" id="tdMeterHouseNo" class="easyui-textbox" style="width: 200px;" runat="server" />
                    </td>

                    <td>仪表位置</td>
                    <td>
                        <input type="text" id="tdMeterLocation" class="easyui-textbox" style="width: 200px;" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>排序序号</td>
                    <td colspan="3">
                        <input type="text" id="tdSortOrder" class="easyui-textbox" style="width: 200px;" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>备注</td>
                    <td colspan="3">
                        <input type="text" id="tdMeterRemark" class="easyui-textbox" style="width: 85%;" runat="server" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</asp:Content>
