<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="UserCheckMySelfMgr.aspx.cs" Inherits="Web.Mall.UserCheckMySelfMgr" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>岗位考核</title>
    <script>
        var approvestatus = -1, confirmstatus = 0, UserID = 0;
        $(function () {
            UserID = "<%=this.UserID%>";
        })
    </script>
    <script src="../js/Page/Mall/Balance/UserCheckMySelfMgr.js?v=<%=base.getToken() %>"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <div class="easyui-layout" data-options="fit:true,border:false">
        <div data-options="region:'north',border:false" style="height: 80px; font-size: 12px; padding: 40px 5px 5px 5px;">
            <div class="operation_box">
                <a href="javascript:void(0)" onclick="do_close()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-close'">关闭</a>
            </div>
            <label>
                关键字: 
                <input class="easyui-searchbox" style="width: 200px;" id="tdKeyword" type="text" data-options="prompt:'商品名称',searcher:SearchTT" />
            </label>
            <label>
                考核类型:
                <select class="easyui-combobox" style="width: 100px;" id="tdCheckType">
                    <option value="0">全部</option>
                    <option value="1">奖励</option>
                    <option value="2">惩罚</option>
                </select>
            </label>
            <label class="searchlabel">
                <a href="javascript:void(0)" onclick="SearchTT()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-search'">搜索</a>
            </label>
        </div>
        <div data-options="region:'center',border:false">
            <table id="tt_table"></table>
            <div id="tt_mm">
                <a href="javascript:void(0)" onclick="do_view()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-detail'">查看</a>
            </div>
        </div>
    </div>
</asp:Content>
