﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="BusinessUserMgr.aspx.cs" Inherits="Web.Mall.BusinessUserMgr" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        var BusinessID = 0;
        $(function () {
            BusinessID = Number("<%=this.BusinessID%>");
        })
    </script>
    <script src="../js/Page/Mall/Business/BusinessUserMgr.js?v=<%=base.getToken() %>"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <div class="easyui-layout" data-options="fit:true,border:false">
        <div data-options="region:'center',border:false">
            <div class="easyui-layout" data-options="fit:true,border:false">
                <div data-options="region:'north',border:false" style="height: 50px; font-size: 12px; padding: 10px;">
                    <label>
                        用户名:               
                        <input class="easyui-searchbox" id="tdKeyword" type="text" data-options="prompt:'关键字搜索',searcher:SearchTT" />
                    </label>
                    <label class="searchlabel">
                        <a href="javascript:void(0)" onclick="SearchTT()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-search'">搜索</a>
                    </label>
                </div>
                <div data-options="region:'center',border:false">
                    <table id="tt_table"></table>
                    <div id="tt_mm">
                        <a href="javascript:void(0)" onclick="addUser()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-add'">新增</a>
                        <a href="javascript:void(0)" onclick="editUser()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-edit'">修改</a>
                        <a href="javascript:void(0)" onclick="removeUser()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-remove'">删除</a>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
