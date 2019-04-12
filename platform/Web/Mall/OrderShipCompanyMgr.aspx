<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="OrderShipCompanyMgr.aspx.cs" Inherits="Web.Mall.OrderShipCompanyMgr" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>发货方式管理</title>
    <script src="../js/Page/Mall/Order/OrderShipCompanyMgr.js?v=<%=base.getToken() %>"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <div class="easyui-layout" data-options="fit:true,border:false">
        <div data-options="region:'north',border:false" style="height: 50px; font-size: 12px; padding: 5px 10px;">
            <label>
                关键字:
                <input class="easyui-searchbox" id="tdKeyword" type="text" data-options="prompt:'发货方式名称',searcher:SearchTT" />
            </label>
            <label class="searchlabel">
                <a href="javascript:void(0)" onclick="SearchTT()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-search'">搜索</a>
            </label>
        </div>
        <div data-options="region:'center',border:false">
            <table id="tt_table">
                <thead>
                    <tr>
                        <th data-options="field: 'ck', checkbox: true"></th>
                        <th data-options="field:'ShipCompanyName',width:200">发货方式名称</th>
                        <th data-options="field:'SortOrder',width:100">排序</th>
                        <th data-options="field:'AddTime',formatter:formatDateTime,width:150">创建时间</th>
                    </tr>
                </thead>
            </table>
            <div id="tt_mm">
                <a href="javascript:void(0)" onclick="do_add()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-add'">增加</a>
                <a href="javascript:void(0)" onclick="do_edit()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-edit'">修改</a>
                <a href="javascript:void(0)" onclick="do_remove()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-remove'">删除</a>
            </div>
        </div>
    </div>
</asp:Content>
