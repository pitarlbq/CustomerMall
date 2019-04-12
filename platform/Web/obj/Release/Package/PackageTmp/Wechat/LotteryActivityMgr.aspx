<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="LotteryActivityMgr.aspx.cs" Inherits="Web.Wechat.LotteryActivityMgr" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../js/Page/Wechat/LotteryActivityMgr.js?v=<%=base.getToken() %>"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <div class="easyui-layout" data-options="fit:true,border:false">
        <div data-options="region:'north',border:false" style="height: 50px; font-size: 12px;">
            <label>
                关键字:
                <input class="easyui-searchbox" id="tdKeyword" type="text" data-options="prompt:'关键字搜索',searcher:SearchTT" />
            </label>
            <label class="searchlabel">
                <a href="javascript:void(0)" onclick="SearchTT()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-search'">查询</a>
            </label>
        </div>
        <div data-options="region:'center',border:false">
            <table id="tt_table"></table>
            <div id="tt_mm">
                <a href="javascript:void(0)" onclick="addRow()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-add'">增加</a>
                <a href="javascript:void(0)" onclick="editRow()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-edit'">修改</a>
                <a href="javascript:void(0)" onclick="removeRows()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-remove'">删除</a>
                <a href="javascript:void(0)" onclick="editPrize()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-edit'">奖项管理</a>
                <a href="javascript:void(0)" onclick="viewPrizeUser()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-detail'">中奖</a>
                <a href="javascript:void(0)" onclick="viewRecordUser()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-detail'">概况</a>
                <a href="javascript:void(0)" onclick="viewUsers()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-edit'">参与人员</a>
                <a href="javascript:void(0)" onclick="editSendPrizeUser()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-edit'">发奖人员</a>
                <a href="javascript:void(0)" onclick="viewQrCode()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-detail'">微信通道</a>
            </div>
        </div>
    </div>
</asp:Content>
