<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="OutMgr.aspx.cs" Inherits="Web.Setup.OutMgr" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../js/Page/DKSetup/loadouttt.js?v=<%=base.getToken() %>"></script>
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
                出库时间:
                <input class="easyui-datebox" id="tdStartTime" />
                -
                <input class="easyui-datebox" id="tdEndTime" />
            </label>
            <label>
                是否已打印:
               <select class="easyui-combobox" id="tdIsPrint">
                   <option value="">全部</option>
                   <option value="1">是</option>
                   <option value="0" selected="selected">否</option>
               </select>
            </label>
            <label class="searchlabel">
                <a href="#" class="easyui-linkbutton" onclick="SearchTitleOut()" data-options="iconCls:'icon-search'">查询</a>
            </label>
        </div>
        <div data-options="region:'center',border:false">
            <table id="tt_table"></table>
            <div id="tt_mm">
                <a href="#" class="easyui-linkbutton" onclick="SearchTitleIn()" data-options="iconCls:'icon-add',plain:true">库存查询</a>
                <a href="#" class="easyui-linkbutton" onclick="AddOut()" data-options="iconCls:'icon-add',plain:true">出库</a>
                <a href="#" class="easyui-linkbutton" onclick="CancelSource()" data-options="iconCls:'icon-remove',plain:true">取消</a>
                <a href="#" class="easyui-linkbutton" onclick="PrintTable()" data-options="iconCls:'icon-print',plain:true">打印</a>
            </div>
        </div>
    </div>
</asp:Content>
