<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="MemberAmountMgr.aspx.cs" Inherits="Web.Mall.MemberAmountMgr" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>储值管理</title>
    <script src="../js/Page/Mall/Balance/MemberAmountMgr.js?v=<%=base.getToken() %>"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <div class="easyui-layout" data-options="fit:true,border:false">
        <div data-options="region:'north',border:false" style="height: 50px; font-size: 12px; padding: 5px 10px;">
            <label>
                关键字: 
                <input class="easyui-searchbox" style="width: 200px;" id="tdKeyword" type="text" data-options="prompt:'客户名称',searcher:SearchTT" />
            </label>
            <label>
                时间:
                <input class="easyui-datebox" style="width: 120px;" id="tdStartTime" type="text" />
                -
                <input class="easyui-datebox" style="width: 120px;" id="tdEndTime" type="text" />
            </label>
            <label>
                储值类型:
                <select class="easyui-combobox" style="width: 100px;" id="tdAmountType" data-options="editable:false">
                    <option value="0">全部</option>
                    <option value="1">充值</option>
                    <option value="2">消费</option>
                </select>
            </label>
            <label>
                充值方式:
                <select class="easyui-combobox" style="width: 120px;" id="tdIncomingType" data-options="editable:false">
                    <option value="0">全部</option>
                    <option value="2">微信充值</option>
                    <option value="3">支付宝充值</option>
                    <option value="4">订单退款返还</option>
                    <option value="5">充值赠与</option>
                    <option value="6">消费赠与</option>
                    <option value="8">线下充值</option>
                    <option value="9">业主结算</option>
                </select>
            </label>
            <label>
                消费方式:
                <select class="easyui-combobox" style="width: 120px;" id="tdOutcomingType" data-options="editable:false">
                    <option value="0">全部</option>
                    <option value="1">购买商品消费</option>
                    <option value="7">退款消费赠与取消</option>
                    <option value="10">线下扣除</option>
                </select>
            </label>
            <label class="searchlabel">
                <a href="javascript:void(0)" onclick="SearchTT()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-search'">搜索</a>
            </label>
        </div>
        <div data-options="region:'center',border:false">
            <table id="tt_table"></table>
            <div id="tt_mm">
                <a href="javascript:void(0)" onclick="do_add(1)" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-add'">充值</a>
                <a href="javascript:void(0)" onclick="do_add(2)" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-balance'">扣除</a>
            </div>
        </div>
    </div>
</asp:Content>
