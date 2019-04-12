<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="MemberAmountRuleMgr.aspx.cs" Inherits="Web.Mall.MemberAmountRuleMgr" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>储值管理</title>
    <script src="../js/Page/Mall/Balance/MemberAmountRuleMgr.js?v=<%=base.getToken() %>"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <div class="easyui-layout" data-options="fit:true,border:false">
        <div data-options="region:'north',border:false" style="height: 50px; font-size: 12px; padding: 5px 10px;">
            <label>
                关键字: 
                <input class="easyui-searchbox" style="width: 200px;" id="tdKeyword" type="text" data-options="prompt:'关键字',searcher:SearchTT" />
            </label>
            <label>
                规则类型: 
                <select id="tdAmountType" class="easyui-combobox" style="width: 100px" data-options="editable:false">
                    <option value="">全部</option>
                    <option value="1">充值</option>
                    <option value="2">消费</option>
                </select>
            </label>
            <label>
                赠送类型: 
                <select id="tdRuleType" class="easyui-combobox" style="width: 100px" data-options="editable:false">
                    <option value="">全部</option>
                    <option value="1">积分</option>
                    <option value="2">余额</option>
                    <option value="3">福顺券</option>
                </select>
            </label>
            <label class="searchlabel">
                <a href="javascript:void(0)" onclick="SearchTT()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-search'">搜索</a>
            </label>
        </div>
        <div data-options="region:'center',border:false">
            <table id="tt_table"></table>
            <div id="tt_mm">
                <%if (base.CheckAuthByModuleCode("1101457"))
                  { %>
                <a href="javascript:void(0)" onclick="do_add()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-add'">新增</a>
                <%} %>
                <%if (base.CheckAuthByModuleCode("1101458"))
                  { %>
                <a href="javascript:void(0)" onclick="do_edit()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-edit'">修改</a>
                <%} %>
                <%if (base.CheckAuthByModuleCode("1101459"))
                  { %>
                <a href="javascript:void(0)" onclick="do_remove()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-remove'">删除</a>
                <%} %>
            </div>
        </div>
    </div>
</asp:Content>
