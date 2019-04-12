<%@ Page Title="" Language="C#" MasterPageFile="~/Master/NavContent4.Master" AutoEventWireup="true" CodeBehind="ChooseAPPUser.aspx.cs" Inherits="Web.APPSetup.ChooseAPPUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        var singleselect;
        $(function () {
            singleselect = "<%=this.singleselect%>";
        })
    </script>
    <script src="../js/Page/APPSetup/ChooseAPPUser.js?v=<%=base.getToken()%>"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <div class="easyui-layout" data-options="fit:true,border:false">
        <div data-options="region:'north',border:false" style="height: 80px; font-size: 12px; padding: 40px 10px 5px 5px;">
            <div class="operation_box">
                <a href="javascript:void(0)" onclick="do_choose()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-save'">选择</a>
                <a href="javascript:void(0)" onclick="do_close()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-close'">关闭</a>
            </div>
            <label>
                用户名:
                <input class="easyui-searchbox" id="tdKeyword" type="text" data-options="prompt:'关键字搜索',searcher:SearchTT" />
            </label>
            <label>
                用户类型:                       
                <select class="easyui-combobox" id="tdUserRoomType">
                    <option value="">全部</option>
                    <option value="1">注册业主</option>
                    <option value="2">游客注册</option>
                </select>
            </label>
            <label class="searchlabel">
                <a href="javascript:void(0)" onclick="SearchTT()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-search'">搜索</a>
            </label>
        </div>
        <div data-options="region:'center',border:false">
            <table id="tt_table"></table>
        </div>
    </div>
</asp:Content>
