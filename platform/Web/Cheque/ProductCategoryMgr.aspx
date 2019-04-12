<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="ProductCategoryMgr.aspx.cs" Inherits="Web.Cheque.ProductCategoryMgr" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../js/Page/Cheque/ChequeProductCategoryMgr.js?v=<%=base.getToken() %>"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <div class="easyui-layout" data-options="fit:true,border:false">
        <div data-options="region:'north',border:false" style="height: 50px; font-size: 12px; padding: 10px;">
            <label>
                关键字搜索:
                <input class="easyui-searchbox" id="tdKeyword" type="text" data-options="prompt:'关键字搜索',searcher:SearchTT" />
            </label>
            <label class="searchlabel">
                <a href="javascript:void(0)" onclick="SearchTT()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-search'">搜索</a>
            </label>
        </div>
        <div data-options="region:'center',border:false">
            <table id="tt_table"></table>
            <div id="tt_mm">
                <a href="javascript:void(0)" onclick="addRow()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-add'">新增</a>
                <a href="javascript:void(0)" onclick="editRow()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-edit'">修改</a>
                <a href="javascript:void(0)" onclick="removeRows()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-remove'">删除</a>
            </div>
        </div>
    </div>
</asp:Content>
