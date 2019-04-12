<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="BusinessBalanceMgr.aspx.cs" Inherits="Web.Mall.BusinessBalanceMgr" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../js/Page/Mall/Balance/BusinessBalanceMgr.js?v=<%=base.getToken() %>"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <div class="easyui-layout" data-options="fit:true,border:false">
        <div data-options="region:'north',border:false" style="height: 50px; font-size: 12px; padding: 5px 10px;">
            <label>
                关键字: 
                <input class="easyui-searchbox" style="width: 200px;" id="tdKeyword" type="text" data-options="prompt:'商品名称，商家名称',searcher:SearchTT" />
            </label>
            <label>
                商户类型: 
                <select class="easyui-combobox" style="width: 100px;" id="tdBusinessType" data-options="editable:false">
                    <option value="0">全部</option>
                    <option value="1">自营</option>
                    <option value="2">非自营</option>
                </select>
            </label>
            <label>
                订单日期:  
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
            <div id="tt_mm">
                <a href="javascript:void(0)" onclick="do_balance()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-balance'">结算申请</a>
            </div>
        </div>
    </div>
</asp:Content>
