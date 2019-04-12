<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="ChooseLotteryChecker.aspx.cs" Inherits="Web.Wechat.ChooseLotteryChecker" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        var ActivityID;
        $(function () {
            ActivityID = "<%=this.ActivityID%>";
        })
        function do_close() {
            parent.do_close_dialog(function () {
                parent.$('#tt_table').datagrid('reload');
            });
        }
    </script>
    <script src="../js/Page/Wechat/ChooseLotteryChecker.js?v=<%=base.getToken() %>"></script>
    <style>
        .searcharea label {
            padding: 0px 5px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <div class="easyui-layout" data-options="fit:true,border:false">
        <div class="searcharea" data-options="region:'north',border:false" style="height: 80px; font-size: 12px; padding: 40px 0px 0px 10px;">
            <div class="operation_box">
                <a href="javascript:void(0)" onclick="do_close()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-close'">关闭</a>
            </div>
            <label>
                关键字:
                <input class="easyui-searchbox" id="tdKeyword" type="text" data-options="prompt:'关键字搜索',searcher:SearchTT" />
            </label>
            <label>
                状态:
                <select class="easyui-combobox" id="tdChooseState" style="width: 80px;">
                    <option value="">全部</option>
                    <option value="1">已选择</option>
                    <option value="2">未选择</option>
                </select>
            </label>
            <label class="searchlabel">
                <a href="javascript:void(0)" onclick="SearchTT()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-search'">查询</a>
            </label>
        </div>
        <div data-options="region:'center',border:false">
            <table id="tt_table"></table>
            <div id="tt_mm">
                <a href="javascript:void(0)" onclick="chooseUser()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-setting'">选择</a>
            </div>
        </div>
    </div>
</asp:Content>
