<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="GroupProductMgr.aspx.cs" Inherits="Web.Mall.GroupProductMgr" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../js/Page/Mall/Product/GroupProductMgr.js?v=<%=base.getToken() %>"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <div class="easyui-layout" data-options="fit:true,border:false">
        <div data-options="region:'north',border:false" style="height: 50px; font-size: 12px; padding: 5px 10px;">
            <label>
                关键字: 
                <input class="easyui-searchbox" style="width: 200px;" id="tdKeyword" type="text" data-options="prompt:'商品标题',searcher:SearchTT" />
            </label>
            <label>
                排序:  
                <select class="easyui-combobox" id="tdSortOrder" style="width: 100px;">
                    <option value="1">创建时间</option>
                    <option value="2">库存</option>
                    <option value="3">销量</option>
                </select>
            </label>
            <label class="searchlabel">
                <a href="javascript:void(0)" onclick="SearchTT()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-search'">搜索</a>
            </label>
        </div>
        <div data-options="region:'center',border:false">
            <table id="tt_table"></table>
            <div id="tt_mm">
                <a href="javascript:void(0)" onclick="do_add()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-add'">新增</a>
                <a href="javascript:void(0)" onclick="do_edit()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-edit'">修改</a>
                <a href="javascript:void(0)" onclick="do_remove()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-remove'">删除</a>
                <a href="javascript:void(0)" onclick="do_change_category()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-edit'">批量分类</a>
                <a href="javascript:void(0)" onclick="do_change_price()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-edit'">批量改价</a>
                <a href="javascript:void(0)" onclick="do_offline()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-edit'">批量下架</a>
            </div>
        </div>
    </div>
</asp:Content>
