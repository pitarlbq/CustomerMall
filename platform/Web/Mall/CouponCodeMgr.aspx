﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="CouponCodeMgr.aspx.cs" Inherits="Web.Mall.CouponCodeMgr" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>卡券管理</title>
    <script>
        var CanEdit = 0;
        $(function () {
            CanEdit = Number("<%=this.CanEdit%>");
        })
    </script>
    <script src="../js/Page/Mall/CouponCode/CouponCodeMgr.js?v=<%=base.getToken() %>"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <div class="easyui-layout" data-options="fit:true,border:false">
        <div data-options="region:'north',border:false" style="height: 50px; font-size: 12px; padding: 5px 10px;">
            <label>
                关键字: 
                <input class="easyui-searchbox" style="width: 200px;" id="tdKeyword" type="text" data-options="prompt:'卡卷名称',searcher:SearchTT" />
            </label>
            <label class="searchlabel">
                <a href="javascript:void(0)" onclick="SearchTT()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-search'">搜索</a>
            </label>
        </div>
        <div data-options="region:'center',border:false">
            <table id="tt_table"></table>
            <div id="tt_mm">
                <%if (base.CheckAuthByModuleCode("1101454"))
                  { %>
                <a href="javascript:void(0)" onclick="do_add()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-add'">新增</a>
                <%} %>
                <%if (base.CheckAuthByModuleCode("1101455"))
                  { %>
                <a href="javascript:void(0)" onclick="do_edit()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-edit'">修改</a>
                <%} %>
                <%if (base.CheckAuthByModuleCode("1101456"))
                  { %>
                <a href="javascript:void(0)" onclick="do_remove()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-remove'">删除</a>
                <%} %>
                <%if (base.CheckAuthByModuleCode("1101471"))
                  { %>
                <a href="javascript:void(0)" onclick="do_send()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-paidan'">发放</a>
                <%} %>
            </div>
        </div>
    </div>
</asp:Content>
