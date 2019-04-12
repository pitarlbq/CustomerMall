<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="DepartmentMgr.aspx.cs" Inherits="Web.APPSetup.DepartmentMgr" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        var CanEdit = 0;
        $(function () {
            CanEdit = Number("<%=this.CanEdit%>");
        })
    </script>
    <script src="../js/Page/APPSetup/DepartmentMgr.js?v=<%=base.getToken() %>"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <div class="easyui-layout" data-options="fit:true,border:false">
        <div data-options="region:'north',border:false" style="height: 50px; font-size: 12px; padding: 5px 10px;">
            <label>
                关键字:
                <input class="easyui-searchbox" id="tdKeyword" type="text" data-options="prompt:'关键字搜索',searcher:SearchTT" />
            </label>
            <label class="searchlabel">
                <a href="javascript:void(0)" onclick="SearchTT()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-search'">搜索</a>
            </label>
        </div>
        <div data-options="region:'center',border:false">
            <table id="tt_table"></table>
            <div id="tt_mm">
                <%if (base.CheckAuthByModuleCode("1101384"))
                  { %>
                <a href="javascript:void(0)" onclick="addRow()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-add'">增加</a>
                <%} %>
                <%if (base.CheckAuthByModuleCode("1101386"))
                  { %>
                <a href="javascript:void(0)" onclick="removeRow()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-remove'">删除</a>
                <%} %>
            </div>
        </div>
    </div>

</asp:Content>
