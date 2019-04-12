<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="BalanceApproveList.aspx.cs" Inherits="Web.Mall.BalanceApproveList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>付款结算</title>
    <script>
        function open_sub(ele, title, pageurl) {
            var $this = $(ele);
            var r = $(".act-item");
            for (var i = 0; i < r.length; i++) {
                $(r[i]).removeClass("active");
            }
            $this.addClass("active");
            var currentiframe = $('#ProductFrame');
            var iframesrc = pageurl;
            currentiframe.attr("src", iframesrc);
            var $height = $(window).height();
            currentiframe.css("height", ($height - 50) + "px");
        }
    </script>
    <link href="../styles/maintab.css?t=<%=base.getToken() %>" rel="stylesheet" />
    <style>
        .act-item {
            margin-right: 30px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <form runat="server">
        <div class="easyui-layout" fit="true">
            <div data-options="region:'north'" style="height: 50px; padding: 5px 10px;">
                <ul class="top-bar">
                    <li class="act-item active" onclick="open_sub(this,'全部', 'BalanceApproveMgr.aspx?status=0')">
                        <a href="javascript:void(0);">全部</a></li>
                    <li class="act-item" onclick="open_sub(this,'代付明细', 'BalanceApproveMgr.aspx?status=10')">
                        <a href="javascript:void(0);">代付明细</a></li>
                    <li class="act-item" onclick="open_sub(this,'付款审核', 'BalanceApproveMgr.aspx?status=1')">
                        <a href="javascript:void(0);">付款审核</a></li>
                    <li class="act-item" onclick="open_sub(this,'付款记录', 'BalanceApproveMgr.aspx?status=2')">
                        <a href="javascript:void(0);">付款记录</a></li>
                </ul>
            </div>
            <div data-options="region:'center'" title="">
                <div class="easyui-panel" style="border: none;" data-options="fit:true">
                    <iframe id="ProductFrame" name="ProductFrame" style="position: absolute; top: 0; left: 0; right: 0; bottom: 0; width: 100%; height: 100%; border: none;" src="BalanceApproveMgr.aspx?status=0"></iframe>
                </div>
            </div>
        </div>
    </form>
</asp:Content>
