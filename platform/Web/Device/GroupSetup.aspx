<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="GroupSetup.aspx.cs" Inherits="Web.Device.GroupSetup" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../js/Page/Device/DeviceGroupSetup.js?token=<%=base.getToken() %>"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <div data-options="fit:true" class="easyui-layout">
        <div data-options="region:'north'" style="height: 50px; padding: 5px 10px;">
            <div class="tdsearch">
                <label>
                    模糊搜索：
                        <input type="text" class="easyui-searchbox" id="tdKeywords" style="width: 300px;" data-options="prompt:'编码、分组名称、维保责任人、巡检责任人',searcher:SearchTT" />
                </label>
                <label>
                    <a href="javascript:void(0)" onclick="SearchTT()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-search'">搜索</a>
                </label>
            </div>
        </div>
        <div data-options="region:'center',split:true,border:false" style="background-color: #eee;">
            <table id="tt_table"></table>
            <div id="tb">
                <a href="javascript:void(0)" onclick="addRow()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-add'">新增</a>
                <a href="javascript:void(0)" onclick="editRow()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-edit'">修改</a>
                <a href="javascript:void(0)" onclick="removeRows()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-remove'">删除</a>
            </div>
        </div>
    </div>
</asp:Content>
