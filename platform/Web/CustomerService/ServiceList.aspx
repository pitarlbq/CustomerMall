<%@ Page Title="" Language="C#" MasterPageFile="~/Master/NavContent4.Master" AutoEventWireup="true" CodeBehind="ServiceList.aspx.cs" Inherits="Web.CustomerService.ServiceList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>任务看板</title>
    <script>
        function open_sub(ele, title, pageurl) {
            var $this = $(ele);
            var r = $(".act-item");
            for (var i = 0; i < r.length; i++) {
                $(r[i]).removeClass("active");
            }
            $this.addClass("active");
            var currentiframe = $('#SubTabFrame');
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
                    <%if (base.CheckAuthByModuleCode("1101206"))
                      { %>
                    <li class="act-item active" onclick="open_sub(this,'任务清单', 'ServiceMgr.aspx?status=101')">
                        <a href="javascript:void(0);">任务清单</a></li>
                    <li class="act-item" onclick="open_sub(this,'调度台', 'ServiceMgr.aspx?status=100')">
                        <a href="javascript:void(0);">调度台</a></li>
                    <%}
                      else
                      {%>
                    <li class="act-item active" onclick="open_sub(this,'调度台', 'ServiceMgr.aspx?status=100')">
                        <a href="javascript:void(0);">调度台</a></li>
                    <%} %>
                    <%--<li class="act-item " onclick="open_sub(this,'待接单', 'ServiceMgr.aspx?status=10')">
                        <a href="javascript:void(0);">待接单</a></li>
                    <li class="act-arrow"></li>--%>
                    <li class="act-item" onclick="open_sub(this,'审批通过', 'ServiceMgr.aspx?status=0')">
                        <a href="javascript:void(0);">处理中</a></li>
                    <li class="act-item" onclick="open_sub(this,'已办结', 'ServiceMgr.aspx?status=1')">
                        <a href="javascript:void(0);">已办结</a></li>
                    <li class="act-item" onclick="open_sub(this,'已销单', 'ServiceMgr.aspx?status=2')">
                        <a href="javascript:void(0);">已销单</a></li>
                    <%-- <li class="act-arrow"></li>
                    <li class="act-item" onclick="open_sub(this,'待抢单', 'ServiceMgr.aspx?status=3')">
                        <a href="javascript:void(0);">待抢单</a></li>--%>
                </ul>
            </div>
            <div data-options="region:'center'" title="">
                <div class="easyui-panel" style="border: none;" data-options="fit:true">
                    <%if (base.CheckAuthByModuleCode("1101206"))
                      { %>
                    <iframe id="SubTabFrame" name="SubTabFrame" style="position: absolute; top: 0; left: 0; right: 0; bottom: 0; width: 100%; height: 100%; border: none;" src="ServiceMgr.aspx?status=101"></iframe>
                    <%}
                      else
                      {%>
                    <iframe id="SubTabFrame" name="SubTabFrame" style="position: absolute; top: 0; left: 0; right: 0; bottom: 0; width: 100%; height: 100%; border: none;" src="ServiceMgr.aspx?status=100"></iframe>
                    <%} %>
                </div>
            </div>
        </div>
    </form>
    <iframe name="myiframe" id="myframe" style="display: none;" src="" width="100%" height="100%"></iframe>
</asp:Content>
