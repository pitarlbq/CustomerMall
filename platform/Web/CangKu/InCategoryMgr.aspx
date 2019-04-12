<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="InCategoryMgr.aspx.cs" Inherits="Web.CangKu.InCategoryMgr" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script>
        var op = '';
        var CategoryType;
        $(function () {
            op = "<%=this.op%>";
            CategoryType = "";
            if (op == "choose") {
                CategoryType = "<%=Request.QueryString["type"]%>";
                setTimeout(function () {
                    $("#main_form_layout").layout('panel', 'north').panel("options").height = 80;
                    $("#main_form_layout").layout("resize");
                    $('.operation_box').show();
                }, 100);
            }
        })
        function do_close() {
            parent.do_close_dialog(function () {
                parent.do_choose_category_done();
            })
        }
    </script>
    <script src="../js/Page/CangKu/CKInCategoryMgr.js?v=<%=base.getToken() %>"></script>
    <style>
        .btn.btn-link {
            padding: 0 !important;
        }

        .operation_box {
            position: relative;
            text-align: right;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <div id="main_form_layout" class="easyui-layout" data-options="fit:true,border:false">
        <div data-options="region:'north',border:false" style="height: 50px; font-size: 12px; padding: 5px 10px;">
            <div class="operation_box" style="display: none;">
                <a href="javascript:void(0)" onclick="do_close()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-close'">关闭</a>
            </div>
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
                <a href="javascript:void(0)" onclick="addRow()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-add'">增加</a>
                <a href="javascript:void(0)" onclick="removeRow()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-remove'">删除</a>
                <%if (!string.IsNullOrEmpty(Request.QueryString["op"]) && Request.QueryString["op"].Equals("choose"))
                  { %>
                <a href="javascript:void(0)" onclick="chooseRow()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-choose'">选择</a>
                <%} %>
            </div>
        </div>
    </div>
</asp:Content>
