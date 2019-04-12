<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="BalanceRuleMgr.aspx.cs" Inherits="Web.Mall.BalanceRuleMgr" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>结算规则</title>
    <script src="../js/Page/Mall/Balance/BalanceRuleMgr.js?v=<%=base.getToken() %>"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <div class="easyui-layout" data-options="fit:true,border:false">
        <div data-options="region:'north',border:false" style="height: 50px; font-size: 12px; padding: 5px 10px;">
            <label>
                关键字: 
                <input class="easyui-searchbox" style="width: 200px;" id="tdKeyword" type="text" data-options="prompt:'规则名称',searcher:SearchTT" />
            </label>
            <label>
                规则类型: 
               <select id="tdRuleType" class="easyui-combobox" data-options="editable:false">
                   <option value="">全部</option>
                   <option value="1">商家结算</option>
                   <option value="2">业主结算</option>
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
            </div>
        </div>
    </div>
</asp:Content>
