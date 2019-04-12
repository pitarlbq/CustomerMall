<%@ Page Title="" Language="C#" MasterPageFile="~/Master/CKDepartmentContent.Master" AutoEventWireup="true" CodeBehind="PropertyMgr.aspx.cs" Inherits="Web.CangKu.PropertyMgr" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        var tdKeyword, tdStartTime, tdEndTime;
        $(function () {
            tdKeyword = $('#<%=this.tdKeyword.ClientID%>');
            tdStartTime = $('#<%=this.tdStartTime.ClientID%>');
            tdEndTime = $('#<%=this.tdEndTime.ClientID%>');
        })
    </script>
    <script src="../js/Page/CangKu/CKPropertyMgr.js?v=<%=base.getToken() %>"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <form runat="server" id="myform">
        <div class="easyui-layout" data-options="fit:true,border:false">
            <div data-options="region:'north',border:false" style="height: 50px; font-size: 12px; padding: 5px 10px;">
                <label>
                    关键字:
                <input class="easyui-searchbox" id="tdKeyword" type="text" data-options="prompt:'关键字搜索',searcher:SearchTT" runat="server" />
                    <asp:HiddenField runat="server" ID="hdTreeID" />
                </label>
                <label>
                    购入日期
                    <input class="easyui-datebox" runat="server" id="tdStartTime" />
                    -
                    <input class="easyui-datebox" runat="server" id="tdEndTime" />
                </label>
                <label class="searchlabel">
                    <a href="javascript:void(0)" onclick="SearchTT()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-search'">搜索</a>
                </label>
            </div>
            <div data-options="region:'center',border:false">
                <table id="tt_table"></table>
                <div id="tt_mm">
                    <a href="javascript:void(0)" onclick="viewData()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-detail'">查看</a>
                    <a href="javascript:void(0)" onclick="addRow()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-add'">增加</a>
                    <a href="javascript:void(0)" onclick="editRow()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-edit'">修改</a>
                    <a href="javascript:void(0)" onclick="removeRow()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-remove'">删除</a>
                    <a href="javascript:void(0)" onclick="doChange()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-edit'">变更</a>
                    <a href="javascript:void(0)" onclick="openImport()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-import'">导入</a>
                    <a href="javascript:void(0)" onclick="do_export()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-export'">导出</a>
                    <a href="javascript:void(0)" onclick="openTableSetUp()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-setting'">配置</a>
                </div>
            </div>
        </div>
    </form>
</asp:Content>
