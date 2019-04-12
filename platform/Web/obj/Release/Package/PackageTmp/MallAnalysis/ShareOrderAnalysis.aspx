<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="ShareOrderAnalysis.aspx.cs" Inherits="Web.MallAnalysis.ShareOrderAnalysis" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../js/Page/MallAnalysis/ShareOrderAnalysis.js?v=<%=base.getToken() %>"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <div class="easyui-layout" data-options="fit:true,border:false">
        <div data-options="region:'north',border:false" style="height: 50px; font-size: 12px; padding: 5px 10px;">
            <label>
                关键字
                <input class="easyui-searchbox" style="width: 200px;" id="tdKeyword" type="text" data-options="prompt:'用户名称',searcher:SearchTT" />
            </label>
            <label>
                订单状态
                <select class="easyui-combobox" data-options="editable:false" id="tdOrderStatus">
                    <option value="">全部</option>
                    <option value="1">待结算</option>
                    <option value="2">已结算</option>
                </select>
            </label>
            <label>
                订单日期
                <input class="easyui-datebox" style="width: 120px;" id="tdStartTime" type="text" />
                -
                <input class="easyui-datebox" style="width: 120px;" id="tdEndTime" type="text" />
            </label>
            <label class="searchlabel">
                <a href="javascript:void(0)" onclick="SearchTT()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-search'">搜索</a>
            </label>
        </div>
        <div data-options="region:'center',border:false">
            <table id="tt_table"></table>
        </div>
    </div>
</asp:Content>
