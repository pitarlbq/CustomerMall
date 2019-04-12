<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="ChangeChargeMan.aspx.cs" Inherits="Web.Charge.ChangeChargeMan" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        var RoomIDs;
        $(function () {
            CompanyID = "<%=Web.WebUtil.GetCompanyID(this.Context)%>";
            RoomIDs = "<%=Request.QueryString["RoomIDs"]%>" || "";
            loadRoomObj();
        })
        function loadRoomObj() {
            var RoomIDList = [];
            if (RoomIDs != '') {
                RoomIDList = eval("(" + RoomIDs + ")");
            }
            if (RoomIDList.length == 0) {
                show_message('请选择一个房间', 'warning');
                return;
            }
            var options = { visit: 'loadroomresourceobj', RoomID: RoomIDList[0] };
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/RoomResourceHandler.ashx',
                data: options,
                success: function (message) {
                    if (message.status) {
                        $("#tbRoomOwner").combobox({
                            data: message.data.RelationNameList,
                            valueField: 'ID',
                            textField: 'RelationName'
                        });
                        if (message.data.RelationNameID > 0) {
                            $("#tbRoomOwner").combobox("setValue", message.data.RelationNameID);
                        }
                        else {
                            $("#tbRoomOwner").combobox("setValue", "");
                        }
                    }
                }
            });
        }
        function do_save() {
            var chargeman_id = $("#tbRoomOwner").combobox('getValue');
            var chargeman_name = $("#tbRoomOwner").combobox('getText');
            if (chargeman_id == "" || chargeman_name == "") {
                show_message('请选择客户名称', 'warning');
                return;
            }
            var NewEndTime = $("#tdNewEndTime").datebox('getText');
            var results = {};
            var rows = parent.$('#tt_table').datagrid("getSelections");
            if (rows.length == 0) {
                show_message('请选择账单明细', 'warning');
                return;
            }
            var ids = [];
            $.each(rows, function (index, row) {
                ids.push(row.ID);
            })
            var options = { visit: 'changechargeman', IDs: JSON.stringify(ids), DefaultChargeManID: chargeman_id, DefaultChargeManName: chargeman_name, NewEndTime: NewEndTime };
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/FeeCenterHandler.ashx',
                data: options,
                success: function (message) {
                    if (message.status) {
                        show_message('挂账成功', 'success', function () {
                            do_close();
                        });
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
    <div class="operation_box">
        <a href="javascript:void(0)" onclick="do_save()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-save'">保存</a>
        <a href="javascript:void(0)" onclick="do_close()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-close'">关闭</a>
    </div>
    <div class="table_container">
        <table class="info">
            <tr>
                <td>客户名称</td>
                <td colspan="3">
                    <input class="easyui-combobox" type="text" id="tbRoomOwner" /></td>
            </tr>
            <tr>
                <td>计费停用日期</td>
                <td colspan="3">
                    <input class="easyui-datebox" type="text" id="tdNewEndTime" /></td>
            </tr>
        </table>
    </div>
</asp:Content>
