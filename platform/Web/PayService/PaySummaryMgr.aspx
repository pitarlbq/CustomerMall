﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="PaySummaryMgr.aspx.cs" Inherits="Web.PayService.PaySummaryMgr" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../js/Page/PayService/PaySummaryMgr.js?v=<%=base.getToken() %>"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <div class="easyui-layout" data-options="fit:true,border:false">
        <div data-options="region:'north',border:false" style="height: 50px; font-size: 12px;">
            <label>
                项目名称:
                <input class="easyui-searchbox" id="tdKeyword" type="text" data-options="prompt:'关键字搜索',searcher:SearchTT" />
            </label>
            <label class="searchlabel">
                <a href="javascript:void(0)" onclick="SearchTT()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-search'">查询</a>
            </label>
        </div>
        <div data-options="region:'center',border:false">
            <table id="tt_table"></table>
            <div id="tt_mm">
                <a href="javascript:void(0)" onclick="addRow()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-add'">查询</a>
                <a href="javascript:void(0)" onclick="removeRows()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-remove'">删除</a>
            </div>
        </div>
    </div>
</asp:Content>
