<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="ThreadMgr.aspx.cs" Inherits="Web.APPSetup.ThreadMgr" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        var Type = 1, CanViewThread = 0, CanViewComment = 0, CanStopComment = 0;
        $(function () {
            Type = "<%=this.Type%>";
            CanViewThread = "<%=this.CanViewThread%>";
            CanViewComment = "<%=this.CanViewComment%>";
            CanStopComment = "<%=this.CanStopComment%>";
        })
    </script>
    <script src="../js/Page/APPSetup/ThreadMgr.js?v=<%=base.getToken() %>"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <div class="easyui-layout" data-options="fit:true,border:false">
        <div data-options="region:'north',border:false" style="height: 50px; font-size: 12px; padding: 5px 10px;">
            <label>
                关键字: 
                <input class="easyui-searchbox" style="width: 200px;" id="tdKeyword" type="text" data-options="prompt:'关键字',searcher:SearchTT" />
            </label>
            <label class="searchlabel">
                <a href="javascript:void(0)" onclick="SearchTT()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-search'">搜索</a>
            </label>
        </div>
        <div data-options="region:'center',border:false">
            <table id="tt_table"></table>
            <div id="tt_mm">
                <%if ((base.CheckAuthByModuleCode("1101354") && Type == 1) || (base.CheckAuthByModuleCode("1101362") && Type == 2))
                  { %>
                <a href="javascript:void(0)" onclick="do_view()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-detail'">查看</a>
                <%} %>
                <%if ((base.CheckAuthByModuleCode("1101355") && Type == 1) || (base.CheckAuthByModuleCode("1101363") && Type == 2))
                  { %>
                <a href="javascript:void(0)" onclick="do_remove()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-remove'">删除</a>
                <%} %>
            </div>
        </div>
    </div>
</asp:Content>
