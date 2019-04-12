<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="DeviceTaskList.aspx.cs" Inherits="Web.Device.DeviceTaskList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        var status = 0;
        $(function () {
            status = "<%=Request.QueryString["status"]%>" || 0;
        })
    </script>
    <script src="../js/Page/Device/DeviceTaskList.js?v=<%=base.getToken() %>" type="text/javascript"></script>
    <style>
        select {
            width: 100px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <form runat="server" id="form1">
        <div class="easyui-layout" fit="true">
            <div data-options="region:'north'" style="height: 50px; padding: 5px 10px;">
                <div class="tdsearch">
                    <label>
                        模糊搜索：
                        <input type="text" class="easyui-searchbox" id="tdKeywords" style="width: 200px;" data-options="prompt:'设备名称,设备编号,规格型号',searcher:SearchTT" />
                    </label>
                    <label>
                        任务来源：
                        <select class="easyui-combobox" id="tdTaskFrom">
                            <option value="">全部</option>
                            <option value="system">系统生成</option>
                            <option value="customerservice">客服中心</option>
                            <option value="internalpost">内部报事</option>
                        </select>
                    </label>
                    <label>
                        任务类型：
                        <select class="easyui-combobox" id="tdTaskType">
                            <option value="">全部</option>
                            <option value="system_repair">定期维保</option>
                            <option value="system_check">定期巡检</option>
                            <option value="manual_repair">临时维保</option>
                            <option value="manual_check">临时巡检</option>
                            <option value="normal_task">日常维修</option>
                        </select>
                    </label>
                    <label>
                        <a href="javascript:void(0)" onclick="SearchTT()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-search'">搜索</a>
                    </label>
                </div>
            </div>
            <div data-options="region:'center'" title="">
                <table id="tt_table">
                </table>
                <div id="tb">
                    <a href="javascript:void(0)" onclick="addRow()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-add'">新增</a>
                    <a href="javascript:void(0)" onclick="editRow()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-edit'">修改</a>
                    <a href="javascript:void(0)" onclick="removeRows()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-remove'">删除</a>
                </div>
            </div>
        </div>
    </form>
</asp:Content>
