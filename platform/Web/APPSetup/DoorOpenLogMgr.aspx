﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Master/NavContent4.Master" AutoEventWireup="true" CodeBehind="DoorOpenLogMgr.aspx.cs" Inherits="Web.APPSetup.DoorOpenLogMgr" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../js/Page/APPSetup/DoorOpenLogMgr.js?v=<%=base.getToken() %>"></script>
    <style>
        .searcharea label {
            padding: 0px 5px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <div class="easyui-layout" data-options="fit:true,border:false">
        <div class="searcharea" data-options="region:'north',border:false" style="height: 50px; font-size: 12px; padding: 10px 0px 0px 10px;">
            <label>
                关键字:
                <input class="easyui-searchbox" id="tdKeyword" type="text" data-options="prompt:'关键字搜索',searcher:SearchTT" />
            </label>
            <label>
                开门时间:
                <input class="easyui-datetimebox" id="tdStartTime" type="text" />
                -
                <input class="easyui-datetimebox" id="tdEndTime" type="text" />
            </label>
            <label class="searchlabel">
                <a href="javascript:void(0)" onclick="SearchTT()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-search'">搜索</a>
            </label>
        </div>
        <div data-options="region:'center',border:false">
            <table id="tt_table"></table>
            <div id="tt_mm">
                <a href="javascript:void(0)" onclick="do_export()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-export'">导出</a>
            </div>
        </div>
    </div>
</asp:Content>
