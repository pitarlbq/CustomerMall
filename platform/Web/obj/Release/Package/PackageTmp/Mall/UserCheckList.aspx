<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="UserCheckList.aspx.cs" Inherits="Web.Mall.UserCheckList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>岗位考核</title>
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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <form runat="server">
        <div class="easyui-layout" fit="true">
            <div data-options="region:'north'" style="height: 50px; padding: 5px 10px;">
                <ul class="top-bar">
                    <li class="act-item active" onclick="open_sub(this,'全部', 'UserCheckMgr.aspx?approvestatus=-1')">
                        <a href="javascript:void(0);">全部</a></li>
                    <li class="act-item" onclick="open_sub(this,'待处理', 'UserCheckMgr.aspx?confirmstatus=2&&processstatus=0')">
                        <a href="javascript:void(0);">待处理</a></li>
                     <li class="act-item" onclick="open_sub(this,'已处理', 'UserCheckMgr.aspx?confirmstatus=2&&processstatus=1')">
                        <a href="javascript:void(0);">已处理</a></li>
                    <li class="act-item" onclick="open_sub(this,'待审核', 'UserCheckMgr.aspx?approvestatus=3')">
                        <a href="javascript:void(0);">待审核</a></li>
                    <li class="act-item" onclick="open_sub(this,'审核通过', 'UserCheckMgr.aspx?approvestatus=1')">
                        <a href="javascript:void(0);">审核通过</a></li>
                    <li class="act-item" onclick="open_sub(this,'审核未通过', 'UserCheckMgr.aspx?approvestatus=2')">
                        <a href="javascript:void(0);">审核未通过</a></li>
                    <li class="act-item" onclick="open_sub(this,'已发放', 'UserCheckMgr.aspx?confirmstatus=1')">
                        <a href="javascript:void(0);">已发放</a></li>
                    <li class="act-item" onclick="open_sub(this,'待申请', 'UserCheckMgr.aspx?approvestatus=0')">
                        <a href="javascript:void(0);">待申请</a></li>
                </ul>
            </div>
            <div data-options="region:'center'" title="">
                <div class="easyui-panel" style="border: none;" data-options="fit:true">
                    <iframe id="ProductFrame" name="ProductFrame" style="position: absolute; top: 0; left: 0; right: 0; bottom: 0; width: 100%; height: 100%; border: none;" src="UserCheckMgr.aspx?approvestatus=-1"></iframe>
                </div>
            </div>
        </div>
    </form>
</asp:Content>
