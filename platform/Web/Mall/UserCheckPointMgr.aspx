<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="UserCheckPointMgr.aspx.cs" Inherits="Web.Mall.UserCheckPointMgr" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>岗位积分</title>
    <script src="../js/Page/Mall/Balance/UserCheckPointMgr.js?v=<%=base.getToken() %>"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <div class="easyui-layout" data-options="fit:true,border:false">
        <div data-options="region:'north',border:false" style="height: 50px; font-size: 12px; padding: 5px 10px;">
            <label>
                关键字: 
                <input class="easyui-searchbox" style="width: 200px;" id="tdKeyword" type="text" data-options="prompt:'关键字搜索',searcher:SearchTT" />
            </label>
            <label>
                考核日期:  
                <input class="easyui-datebox" style="width: 120px;" id="tdStartTime" />
                -
                <input class="easyui-datebox" style="width: 120px;" id="tdEndTime" />
            </label>
            <label class="searchlabel">
                <a href="javascript:void(0)" onclick="SearchTT()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-search'">搜索</a>
            </label>
        </div>
        <div data-options="region:'center',border:false">
            <table id="tt_table"></table>
            <div id="tt_mm">
            </div>
        </div>
    </div>
</asp:Content>
