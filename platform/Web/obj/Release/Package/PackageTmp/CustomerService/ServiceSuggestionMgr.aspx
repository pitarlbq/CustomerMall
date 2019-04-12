<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="ServiceSuggestionMgr.aspx.cs" Inherits="Web.CustomerService.ServiceSuggestionMgr" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>任务看板</title>
    <script>
        var Status;
        $(function () {
            Status = "<%=Request.QueryString["status"]%>" || "";
        })
    </script>
    <script src="../js/Lodop/LodopFuncs.js?t=<%=base.getToken() %>"></script>
    <script src="../js/Page/CustomerService/ServiceSuggestionMgr.js?v=<%=base.getToken() %>" type="text/javascript"></script>
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
            <div data-options="region:'north'" style="height: 60px; padding: 0px 10px;">
                <div class="tdsearch">
                    <label>
                        模糊搜索:
                        <input type="text" class="easyui-searchbox" id="tdKeywords" style="width: 150px;" data-options="prompt:'模糊搜索',searcher:SearchTT" />
                    </label>
                    <label>
                        <a href="javascript:void(0)" onclick="SearchTT()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-search'">搜索</a>
                    </label>
                </div>
            </div>
            <div data-options="region:'center'" title="">
                <table id="tt_table">
                </table>
                <div id="tb">
                    <a href="javascript:void(0)" onclick="do_view()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-detail'">详情</a>
                    <a href="javascript:void(0)" onclick="do_remove()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-remove'">删除</a>
                </div>
            </div>
        </div>
    </form>
</asp:Content>
