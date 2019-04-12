<%@ Page Title="" Language="C#" MasterPageFile="~/Master/CKContent.Master" AutoEventWireup="true" CodeBehind="OutMgr.aspx.cs" Inherits="Web.CangKu.OutMgr" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        var tdAccpetTeam, tdStartTime, tdEndTime, tdKeyword, tdProductCategory, tdAccpetMan;
        $(function () {
            tdAccpetTeam = $('#<%=this.tdAccpetTeam.ClientID%>');
            tdStartTime = $('#<%=this.tdStartTime.ClientID%>');
            tdEndTime = $('#<%=this.tdEndTime.ClientID%>');
            tdKeyword = $('#<%=this.tdKeyword.ClientID%>');
            hdIDs = $('#<%=this.hdIDs.ClientID%>');
            hdCKCategoryID = $('#<%=this.hdCKCategoryID.ClientID%>');
            tdProductCategory = $('#<%=this.tdProductCategory.ClientID%>');
            tdAcceptUser = $('#<%=this.tdAcceptUser.ClientID%>');
        })
    </script>
    <script src="../js/Lodop/LodopFuncs.js?t=<%=base.getToken() %>"></script>
    <script src="../js/Page/CangKu/CKOutMgr.js?v=<%=base.getToken() %>"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <form runat="server">
        <div class="easyui-layout" data-options="fit:true,border:false">
            <div data-options="region:'north',border:false" style="height: 80px; font-size: 12px; padding: 5px 10px;">
                <label>
                    关键字:
                <input class="easyui-searchbox" id="tdKeyword" type="text" data-options="prompt:'关键字搜索',searcher:SearchTT" runat="server" />
                </label>
                <label>
                    领用部门:
                <input class="easyui-combobox" id="tdAccpetTeam" type="text" runat="server" style="width: 100px;" />
                </label>
                 <label>
                    领用人:
                <input class="easyui-combobox" id="tdAcceptUser" type="text" runat="server" style="width: 100px;" />
                </label>
                <label>
                    物品类别:
                    <input type="text" class="easyui-combobox" id="tdProductCategory" runat="server" style="width: 100px;" />
                </label>
                <label>
                    出库时间:
                <input class="easyui-datebox" id="tdStartTime" type="text" runat="server" style="width: 120px;" />
                    -
                <input class="easyui-datebox" id="tdEndTime" type="text" runat="server" style="width: 120px;" />
                </label>
                <label class="searchlabel">
                    <a href="javascript:void(0)" onclick="SearchTT()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-search'">搜索</a>
                </label>
            </div>
            <div data-options="region:'center',border:false">
                <table id="tt_table"></table>
                <div id="tt_mm">
                    <%if (base.CheckAuthByModuleCode("1101188"))
                      { %>
                    <a href="javascript:void(0)" onclick="addRow()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-add'">增加</a>
                    <%} %>
                    <%if (base.CheckAuthByModuleCode("1101189"))
                      { %>
                    <a href="javascript:void(0)" onclick="editRow('edit')" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-edit'">编辑</a>
                    <%} %>
                    <%if (base.CheckAuthByModuleCode("1101190"))
                      { %>
                    <a href="javascript:void(0)" onclick="removeRow()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-remove'">删除</a>
                    <%} %>
                    <%if (base.CheckAuthByModuleCode("1101191"))
                      { %>
                    <a href="javascript:void(0)" onclick="doPrintIn()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-print'">打印</a>
                    <%} %>
                    <%if (base.CheckAuthByModuleCode("1101192"))
                      { %>
                    <a href="javascript:void(0)" onclick="editRow('view')" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-detail'">详情</a>
                    <%} %>
                    <%if (base.CheckAuthByModuleCode("1101193"))
                      { %>
                    <a href="javascript:void(0)" onclick="doApprove()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-shenhe'">审核</a>
                    <%} %>
                    <%if (base.CheckAuthByModuleCode("1101195"))
                      { %>
                    <a href="javascript:void(0)" onclick="do_export()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-export'">导出</a>
                    <asp:HiddenField runat="server" ID="hdIDs" />
                    <asp:HiddenField runat="server" ID="hdCKCategoryID" />
                    <%} %>
                </div>
            </div>
        </div>
    </form>
    <iframe name="myiframe" id="myframe" style="display: none;" src="" width="100%" height="100%"></iframe>
</asp:Content>
