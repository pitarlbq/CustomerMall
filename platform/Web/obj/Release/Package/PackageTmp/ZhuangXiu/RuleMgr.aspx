<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="RuleMgr.aspx.cs" Inherits="Web.ZhuangXiu.RuleMgr" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../js/Page/ZhuangXiu/ZhuangXiuRuleMgr.js?v=<%=base.getToken() %>" type="text/javascript"></script>
    <style>
        .tdsearch label {
            margin-right: 10px;
        }

        .btn.btn-link {
            padding: 4px !important;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <form runat="server">
        <div class="easyui-layout" fit="true">
            <div data-options="region:'north'" style="height: 50px; padding: 5px 10px;">
                <div class="tdsearch">
                    <label>
                        模糊搜索：
                        <input type="text" class="easyui-searchbox" id="tdKeywords" style="width: 150px;" data-options="prompt:'违规项目',searcher:SearchTT" />
                    </label>
                    <label>
                        <a href="javascript:void(0)" onclick="SearchTT()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-search'">查询</a>
                    </label>
                </div>
            </div>
            <div data-options="region:'center'" title="">
                <table id="tt_table">
                </table>
                <div id="tb">
                    <a href="javascript:void(0)" onclick="addRow()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-add'">新增</a>
                    <a href="javascript:void(0)" onclick="editRow()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-edit'">修改</a>
                    <a href="javascript:void(0)" onclick="removeRows()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-remove'">删除</a>
                </div>
            </div>
        </div>
    </form>
</asp:Content>
