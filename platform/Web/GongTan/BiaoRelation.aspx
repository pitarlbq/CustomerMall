<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="BiaoRelation.aspx.cs" Inherits="Web.GongTan.BiaoRelation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        var ID = 0, hdBiaoCategory;
        $(function () {
            ID = "<%=Request.QueryString["ID"]%>" || 0;
            hdBiaoCategory = $('#<%=this.hdBiaoCategory.ClientID%>');
        })
        function do_close() {
            parent.do_close_dialog();
        }
    </script>
    <script src="../js/Page/GongTan/BiaoRelation.js?v=<%=base.getToken() %>" type="text/javascript"></script>
    <style>
        .tdsearch label {
            margin-right: 10px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <form runat="server">
        <input type="hidden" runat="server" id="hdPriceRangeList" />
        <div class="easyui-layout" fit="true">
            <div data-options="region:'north'" style="height: 80px; padding: 40px 5px 5px 5px;">
                <div class="operation_box">
                    <a href="javascript:void(0)" onclick="do_close()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-close'">关闭</a>
                </div>
                <label>
                    关键字:                
                        <input class="easyui-searchbox" id="tdKeyword" type="text" data-options="prompt:'关键字搜索          ',searcher:SearchTT" style="width: 200px" />
                </label>
                <label>
                    表种类:   
                        <input class="easyui-combobox" id="tdBiaoCategory" style="width: 150px; height: 25px;" />
                    <asp:HiddenField runat="server" ID="hdBiaoCategory" />
                </label>
                <label>
                    作废状态：
                <select class="easyui-combobox" id="tdActiveStatus" style="width: 100px; height: 25px;">
                    <option value="">全部</option>
                    <option value="0">已作废</option>
                    <option value="1">未作废</option>
                </select>
                </label>
                <label>
                    关联状态：
                <select class="easyui-combobox" id="tdRelationStatus" style="width: 100px; height: 25px;">
                    <option value="">全部</option>
                    <option value="1">已关联</option>
                    <option value="0">未关联</option>
                </select>
                </label>
                <label>
                    <a href="javascript:void(0)" onclick="SearchTT()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-save'">查询</a>
                </label>
            </div>
            <div data-options="region:'center'" title="">
                <table id="tt_table">
                </table>
                <div id="tb">
                    <a href="javascript:void(0)" onclick="activeRows()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-add'">关联</a>
                    <a href="javascript:void(0)" onclick="cancelRows()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-remove'">取消关联</a>
                </div>
            </div>
        </div>
    </form>
</asp:Content>
