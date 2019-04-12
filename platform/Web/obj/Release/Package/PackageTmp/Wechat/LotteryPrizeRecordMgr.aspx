<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="LotteryPrizeRecordMgr.aspx.cs" Inherits="Web.Wechat.LotteryPrizeRecordMgr" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        var ActivityID = 0;
        $(function () {
            ActivityID = "<%=this.ActivityID%>";
        })
        function do_close() {
            parent.do_close_dialog();
        }
    </script>
    <script src="../js/Page/Wechat/LotteryPrizeRecordMgr.js?v=<%=base.getToken() %>"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <div class="easyui-layout" data-options="fit:true,border:false">
        <div data-options="region:'north',border:false" style="height: 80px; font-size: 12px; padding-top: 40px;">
            <div class="operation_box">
                <a href="javascript:void(0)" onclick="do_close()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-close'">关闭</a>
            </div>
            <label>
                关键字:
                <input class="easyui-searchbox" id="tdKeyword" type="text" data-options="prompt:'关键字搜索',searcher:SearchTT" />
            </label>
            <label>
                <select class="easyui-combobox" id="tdSendComplete" style="width: 100px;">
                    <option value="">全部</option>
                    <option value="1">已发奖</option>
                    <option value="2">未发奖</option>
                </select>
            </label>
            <label class="searchlabel">
                <a href="javascript:void(0)" onclick="SearchTT()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-search'">查询</a>
            </label>
        </div>
        <div data-options="region:'center',border:false">
            <table id="tt_table"></table>
        </div>
    </div>
</asp:Content>
