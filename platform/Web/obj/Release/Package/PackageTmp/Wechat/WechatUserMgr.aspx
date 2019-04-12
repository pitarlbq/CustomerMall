<%@ Page Title="" Language="C#" MasterPageFile="~/Master/NavContent4.Master" AutoEventWireup="true" CodeBehind="WechatUserMgr.aspx.cs" Inherits="Web.Wechat.WechatUserMgr" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../js/Page/Wechat/WechatUserMgr.js?v=<%=base.getToken() %>"></script>
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
                用户名:
                <input class="easyui-searchbox" id="tdKeyword" type="text" data-options="prompt:'关键字搜索',searcher:SearchTT" />
            </label>
            <label>
                <input type="radio" name="roomstatus" id="AllRoom" value="1" checked="checked" />全部房间
            </label>
            <label>
                <input type="radio" name="roomstatus" id="Subscribe" value="1" />关注资源
            </label>
            <label>
                <input type="radio" name="roomstatus" id="UnSubscribe" value="1" />未关注资源
            </label>
            <label class="searchlabel">
                <a href="javascript:void(0)" onclick="SearchTT()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-search'">搜索</a>
            </label>
        </div>
        <div data-options="region:'center',border:false">
            <table id="tt_table"></table>
            <div id="tt_mm">
                <a href="javascript:void(0)" onclick="tongBuUser()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-tongbu'">同步粉丝</a>
                <a href="javascript:void(0)" onclick="cancelSubscribe()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-tingyong'">取消关注</a>
                <a href="javascript:void(0)" onclick="openTableSetUp()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-setting'">配置</a>
            </div>
        </div>
    </div>
</asp:Content>
