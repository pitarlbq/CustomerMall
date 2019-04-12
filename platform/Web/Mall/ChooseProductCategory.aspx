<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="ChooseProductCategory.aspx.cs" Inherits="Web.Mall.ChooseProductCategory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        var type, from;
        $(function () {
            type = Number("<%=this.type%>");
            from = "<%=this.from%>";
        })
    </script>
    <script src="../js/Page/Mall/Category/ChooseProductCategory.js?v=<%=base.getToken() %>"></script>
    <style>
        .datagrid-td-rownumber {
            height: 50px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <div class="easyui-layout" data-options="fit:true,border:false">
        <div data-options="region:'north',border:false" style="height: 80px; font-size: 12px; padding: 40px 10px 5px 5px;">
            <div class="operation_box">
                <a href="javascript:void(0)" onclick="do_choose()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-save'">选择</a>
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
        <div data-options="region:'center',border:false,fit:true">
            <table id="tt_table">
                <thead>
                    <tr>
                        <th data-options="field: 'ck', checkbox: true"></th>
                        <th data-options="field:'CoverImage',formatter:formatCoverImage,width:100">图片</th>
                        <th data-options="field:'name',width:200">分类名称</th>
                        <th data-options="field:'SortOrder',width:100">排序</th>
                        <th data-options="field:'AddTime',formatter:formatDateTime,width:150">创建时间</th>
                        <th data-options="field:'ProductCount',width:100">商品数量</th>
                    </tr>
                </thead>
            </table>
        </div>
    </div>
</asp:Content>
