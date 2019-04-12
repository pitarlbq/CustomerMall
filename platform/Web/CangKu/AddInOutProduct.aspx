<%@ Page Title="" Language="C#" MasterPageFile="~/Master/CKProductCategoryContent.Master" AutoEventWireup="true" CodeBehind="AddInOutProduct.aspx.cs" Inherits="Web.CangKu.AddInOutProduct" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        var CKCategoryID;
        $(function () {
            CKCategoryID = "<%=Request.QueryString["CKCategoryID"]%>" || 0;
        })
    </script>
    <script src="../js/Page/CangKu/CKAddInOutProduct.js?v=<%=base.getToken() %>"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <form runat="server" id="myform">
        <div class="easyui-layout" data-options="fit:true,border:false">
            <div data-options="region:'north',border:false" style="height: 80px; font-size: 12px; padding: 40px 5px 5px 5px;">
                <div class="operation_box">
                    <a href="javascript:void(0)" onclick="do_close()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-close'">关闭</a>
                </div>
                <label>
                    关键字:
                <input class="easyui-searchbox" id="tdKeyword" type="text" data-options="prompt:'关键字搜索',searcher:SearchTT" />
                    <asp:HiddenField runat="server" ID="hdKeywords" />
                    <asp:HiddenField runat="server" ID="hdTreeID" />
                </label>
                <label class="searchlabel">
                    <a href="javascript:void(0)" onclick="SearchTT()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-search'">搜索</a>
                </label>
            </div>
            <div data-options="region:'center',border:false">
                <table id="tt_table"></table>
                <div id="tt_mm">
                    <a href="javascript:void(0)" onclick="chooseRow()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-choose'">选择</a>
                    <a href="javascript:void(0)" onclick="addRow()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-add'">增加</a>
                </div>
            </div>
        </div>
    </form>
</asp:Content>
