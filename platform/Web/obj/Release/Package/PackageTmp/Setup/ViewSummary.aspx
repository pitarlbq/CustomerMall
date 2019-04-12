﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="ViewSummary.aspx.cs" Inherits="Web.Setup.ViewSummary" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../js/PageDKSetup/ViewSummary.js?v=<%=base.getToken() %>"></script>
    <style>
        label.searchlabel {
            margin: 10px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <div class="easyui-layout" data-options="fit:true,border:false">
        <div data-options="region:'north',border:false" style="height: 50px; font-size: 12px;">
            <label>
                入库时间:
                <input class="easyui-datebox" id="tdStartTime" />
                -
                <input class="easyui-datebox" id="tdEndTime" />
            </label>
             <label>
                出库时间:
                <input class="easyui-datebox" id="tdOutStartTime" />
                -
                <input class="easyui-datebox" id="tdOutEndTime" />
            </label>
            <label class="searchlabel">
                <a href="#" class="easyui-linkbutton" onclick="SearchTT()" data-options="iconCls:'icon-search'">查询</a>
            </label>
        </div>
        <div data-options="region:'center',border:false">
            <table id="tt_table"></table>
            <div id="tt_mm">
                <%--<a href="#" class="easyui-linkbutton" onclick="AddIn()" data-options="iconCls:'icon-add',plain:true">入库</a>--%>
            </div>
        </div>
    </div>
</asp:Content>
