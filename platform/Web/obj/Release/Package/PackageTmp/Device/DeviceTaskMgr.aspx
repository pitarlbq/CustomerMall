<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="DeviceTaskMgr.aspx.cs" Inherits="Web.Device.DeviceTaskMgr" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>维保巡检任务</title>
    <script>
        function open_sub(ele, title, pageurl) {
            var $this = $(ele);
            var r = $(".act-item");
            for (var i = 0; i < r.length; i++) {
                $(r[i]).removeClass("active");
            }
            $this.addClass("active");
            var currentiframe = $('#TaskFrame');
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
            <div data-options="region:'north'" style="height: 60px; padding: 0px 10px;">
                <ul class="top-bar">
                    <li class="act-item active" onclick="open_sub(this,'待处理', 'DeviceTaskList.aspx?status=1')">
                        <a href="javascript:void(0);">待处理</a></li>
                    <li class="act-item" onclick="open_sub(this,'审批通过', 'DeviceTaskList.aspx?status=2')">
                        <a href="javascript:void(0);">处理中</a></li>
                    <li class="act-item" onclick="open_sub(this,'已完成', 'DeviceTaskList.aspx?status=3')">
                        <a href="javascript:void(0);">已完成</a></li>
                </ul>
            </div>
            <div data-options="region:'center'" title="">
                <div class="easyui-panel" style="border: none;" data-options="fit:true">
                    <iframe id="TaskFrame" name="TaskFrame" style="position: absolute; top: 0; left: 0; right: 0; bottom: 0; width: 100%; height: 100%; border: none;" src="DeviceTaskList.aspx?status=1"></iframe>
                </div>
            </div>
        </div>
    </form>
</asp:Content>
