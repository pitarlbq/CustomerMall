<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="MemberPointMgr.aspx.cs" Inherits="Web.Mall.MemberPointMgr" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>会员积分</title>
    <script src="../js/Page/Mall/Balance/MemberPointMgr.js?v=<%=base.getToken() %>"></script>
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
            <label class="searchlabel">
                <a href="javascript:void(0)" onclick="SearchTT()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-search'">搜索</a>
            </label>
        </div>
        <div data-options="region:'center',border:false">
            <table id="tt_table"></table>
            <div id="tt_mm">
              <%--  <a href="javascript:void(0)" onclick="do_send()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-paidan'">批量赠送</a>
                <a href="javascript:void(0)" onclick="do_reduce()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-tuikuan'">批量减免</a>
                <a href="javascript:void(0)" onclick="do_edit()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-edit'">调整审计</a>
                <a href="javascript:void(0)" onclick="do_active()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-setting'">参数配置</a>--%>
            </div>
        </div>
    </div>
</asp:Content>
