<%@ Page Title="" Language="C#" MasterPageFile="~/Master/CKContent.Master" AutoEventWireup="true" CodeBehind="InMgr.aspx.cs" Inherits="Web.CangKu.InMgr" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        var tdStartTime, tdEndTime, tdKeyword, hdIDs, hdCKCategoryID, tdProductCategory;
        $(function () {
            tdStartTime = $('#<%=this.tdStartTime.ClientID%>');
            tdEndTime = $('#<%=this.tdEndTime.ClientID%>');
            tdKeyword = $('#<%=this.tdKeyword.ClientID%>');
            hdIDs = $('#<%=this.hdIDs.ClientID%>');
            hdCKCategoryID = $('#<%=this.hdCKCategoryID.ClientID%>');
            tdProductCategory = $('#<%=this.tdProductCategory.ClientID%>');
        })
    </script>
    <script src="../js/Lodop/LodopFuncs.js?t=<%=base.getToken() %>"></script>
    <script src="../js/Page/CangKu/CKInMgr.js?v=<%=base.getToken() %>"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <form runat="server">
        <div class="easyui-layout" data-options="fit:true,border:false">
            <div data-options="region:'north',border:false" style="height: 50px; font-size: 12px; padding: 5px 10px;">
                <label>
                    关键字:
                <input class="easyui-searchbox" id="tdKeyword" type="text" data-options="prompt:'关键字搜索',searcher:SearchTT" runat="server" />
                </label>
                <label>
                    入库时间:
                <input class="easyui-datebox" id="tdStartTime" type="text" runat="server" style="width: 120px;" />
                    -
                <input class="easyui-datebox" id="tdEndTime" type="text" runat="server" style="width: 120px;" />
                </label>
                <label>
                    物品类别:
                    <input type="text" class="easyui-combobox" id="tdProductCategory" runat="server" />
                </label>
                <label class="searchlabel">
                    <a href="javascript:void(0)" onclick="SearchTT()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-search'">搜索</a>
                </label>
            </div>
            <div data-options="region:'center',border:false">
                <table id="tt_table"></table>
                <div id="tt_mm">
                    <%if (base.CheckAuthByModuleCode("1101181"))
                      { %>
                    <a href="javascript:void(0)" onclick="addRow()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-add'">增加</a>
                    <%} %>
                    <%if (base.CheckAuthByModuleCode("1101182"))
                      { %>
                    <a href="javascript:void(0)" onclick="editRow('edit')" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-edit'">编辑</a>
                    <%} %>
                    <%if (base.CheckAuthByModuleCode("1101183"))
                      { %>
                    <a href="javascript:void(0)" onclick="removeRow()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-remove'">删除</a>
                    <%} %>
                    <%if (base.CheckAuthByModuleCode("1101184"))
                      { %>
                    <a href="javascript:void(0)" onclick="doPrintIn()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-print'">打印</a>
                    <%} %>
                    <%if (base.CheckAuthByModuleCode("1101185"))
                      { %>
                    <a href="javascript:void(0)" onclick="editRow('view')" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-detail'">详情</a>
                    <%} %>
                    <%if (base.CheckAuthByModuleCode("1101186"))
                      { %>
                    <a href="javascript:void(0)" onclick="openImport()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-import'">导入</a>
                    <%} %>
                    <%if (base.CheckAuthByModuleCode("1101187"))
                      { %>
                    <a href="javascript:void(0)" onclick="doApprove()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-shenhe'">审核</a>
                    <%} %>
                    <%if (base.CheckAuthByModuleCode("1101194"))
                      { %>
                    <a href="javascript:void(0)" onclick="do_export()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-export'">导出</a>
                    <asp:HiddenField runat="server" ID="hdIDs" />
                    <asp:HiddenField runat="server" ID="hdCKCategoryID" />
                    <%} %>
                    <a href="javascript:void(0)" onclick="do_out()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-edit'">转出库单</a>
                </div>
            </div>
        </div>
    </form>
    <iframe name="myiframe" id="myframe" style="display: none;" src="" width="100%" height="100%"></iframe>
</asp:Content>
