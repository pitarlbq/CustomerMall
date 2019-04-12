<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="CategoryMgr.aspx.cs" Inherits="Web.Mall.CategoryMgr" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>分类管理</title>
    <script>
        var type;
        $(function () {
            type = Number("<%=this.type%>");
        })
    </script>
    <script src="../js/Page/Mall/Category/CategoryMgr.js?v=<%=base.getToken() %>"></script>
    <style>
        .datagrid-td-rownumber {
            height: 50px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <div class="easyui-layout" data-options="fit:true,border:false">
        <div data-options="region:'north',border:false" style="height: 50px; font-size: 12px; padding: 5px 10px;">
            <label>
                关键字:
                <input class="easyui-searchbox" id="tdKeyword" type="text" data-options="prompt:'分类名称',searcher:SearchTT" />
            </label>
            <label class="searchlabel">
                <a href="javascript:void(0)" onclick="SearchTT()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-search'">搜索</a>
            </label>
        </div>
        <div data-options="region:'center',border:false">
            <table id="tt_table">
                <thead>
                    <tr>
                        <th data-options="field: 'ck', checkbox: true"></th>
                        <th data-options="field:'CoverImage',formatter:formatCoverImage,width:100">图片</th>
                        <th data-options="field:'name',width:200">分类名称</th>
                        <th data-options="field:'SortOrder',width:100">排序</th>
                        <th data-options="field:'AddTime',formatter:formatDateTime,width:150">创建时间</th>
                        <th data-options="field:'ProductCount',width:100">商品数量</th>
                        <th data-options="field:'IsDisabledDesc',width:100">是否禁用</th>
                    </tr>
                </thead>
            </table>
            <div id="tt_mm">
                <%if (this.CanAdd == 1)
                  { %>
                <a href="javascript:void(0)" onclick="do_add()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-add'">增加</a>
                <%} %>
                <%if (this.CanEdit == 1)
                  { %>
                <a href="javascript:void(0)" onclick="do_edit()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-edit'">修改</a>
                <%} %>
                <%if (this.CanRemove == 1)
                  { %>
                <a href="javascript:void(0)" onclick="do_remove()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-remove'">删除</a>
                <%} %>
            </div>
        </div>
    </div>
</asp:Content>
