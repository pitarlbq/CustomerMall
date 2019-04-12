<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="AddTaiZhang.aspx.cs" Inherits="Web.GongTan.AddTaiZhang" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">

        $(function () {
            loadBiao();
            $('#tdBiaoGuiGe').combobox('setValue', '分表');
        });
        function loadBiao() {
            var biaoData = $("#<%=this.hdBiaoCategory.ClientID%>").val();
            var biaolist = [];
            if (biaoData != "") {
                biaolist = eval("(" + biaoData + ")");
            }
            if (biaolist.length > 0) {
                $("#tdBiaoCategory").combobox({
                    editable: false,
                    data: biaolist,
                    valueField: 'ID',
                    textField: 'BiaoCategory',
                    onSelect: function (rec) {
                        $("#tdBiaoName").textbox('setValue', rec.BiaoName);
                        $("#tdBiaoGuiGe").textbox('setValue', rec.BiaoGuiGe);
                        $("#tdRemark").textbox('setValue', rec.Remark);
                    }
                });
                $("#tdBiaoCategory").combobox('setValue', biaolist[0].ID);
                $("#tdBiaoName").textbox('setValue', biaolist[0].BiaoName);
                if (biaolist[0].BiaoGuiGe != '') {
                    $("#tdBiaoGuiGe").textbox('setValue', biaolist[0].BiaoGuiGe);
                }
                $("#tdRemark").textbox('setValue', biaolist[0].Remark);
            }
        }
        function do_save() {
            var isValid = $("#<%=this.ff.ClientID%>").form('enableValidation').form('validate');
            if (!isValid) {
                return;
            }
            var roomids = [];
            var projectids = [];
            try {
                roomids = parent.parent.GetSelectedRooms();
                projectids = parent.parent.GetSelectedProjects();
            } catch (e) {

            }
            if (roomids.length == 0 && projectids.length == 0) {
                show_message("请选择一个资源", "warning");
                return;
            }
            var BiaoID = $("#tdBiaoCategory").combobox('getValue');
            var options = { visit: 'saveprojectbiao', BiaoID: BiaoID, RoomIDs: JSON.stringify(roomids), ProjectIDs: JSON.stringify(projectids), BiaoCategory: $("#tdBiaoCategory").combobox('getText'), BiaoName: $("#tdBiaoName").textbox('getValue'), BiaoGuiGe: $('#tdBiaoGuiGe').combobox('getValue'), Remark: $('#tdRemark').textbox('getValue'), Rate: $('#tdRate').textbox('getValue'), ChargeRoomNo: $('#tdChargeRoomNo').textbox('getValue') };
            MaskUtil.mask('body', '提交中');
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/ImportFeeHandler.ashx',
                data: options,
                success: function (message) {
                    MaskUtil.unmask();
                    if (message.status) {
                        show_message('保存成功', 'success', function () {
                            do_close();
                        });
                    }
                    else if (message.error) {
                        show_message(message.error, "warningng");
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
    <style type="text/css">
        .panel-body {
            background: #f0f0f0;
        }

        .hidefield {
            display: none;
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
                    <td>表种类
                    </td>
                    <td>
                        <input type="hidden" id="tdID" />
                        <input type="text" id="tdBiaoCategory" class="easyui-combobox" data-options="required:true" />
                        <asp:HiddenField runat="server" ID="hdBiaoCategory" />
                    </td>
                    <td>表名称</td>
                    <td>
                        <input type="text" id="tdBiaoName" class="easyui-textbox" data-options="required:true" /></td>
                </tr>
                <tr>
                    <td>表规格</td>
                    <td>
                        <select class="easyui-combobox" id="tdBiaoGuiGe" data-options="editable:false">
                            <option value="总表">总表</option>
                            <option value="分表">分表</option>
                        </select>
                    </td>
                    <td>缴费户号</td>
                    <td>
                        <input type="text" id="tdChargeRoomNo" class="easyui-textbox" /></td>
                </tr>
                <tr>
                    <td>倍率</td>
                    <td>
                        <input type="text" id="tdRate" class="easyui-textbox" /></td>
                    <td>备注</td>
                    <td>
                        <input type="text" id="tdRemark" data-options="multiline:true" class="easyui-textbox" style="height: 60px;" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</asp:Content>
