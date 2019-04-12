<%@ Page Title="" Language="C#" MasterPageFile="~/Master/NavContent4.Master" AutoEventWireup="true" CodeBehind="Setup.aspx.cs" Inherits="Web.ZhuangXiu.Setup" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        function open_sub(ele, title, pageurl) {
            var $this = $(ele);
            var r = $(".act-item");
            for (var i = 0; i < r.length; i++) {
                $(r[i]).removeClass("active");
            }
            $this.addClass("active");
            var currentiframe = $('#ZhuangXiuFrame');
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
                    <li class="act-item active" onclick="open_sub(this,'申请中', 'ZhuangXiuList.aspx?status=shenqing')">
                        <a href="javascript:void(0);">申请中</a></li>
                    <li class="act-item" onclick="open_sub(this,'审批通过', 'ZhuangXiuList.aspx?status=shenpiyes')">
                        <a href="javascript:void(0);">审批通过</a></li>
                    <li class="act-item" onclick="open_sub(this,'审批拒绝', 'ZhuangXiuList.aspx?status=shenpino')">
                        <a href="javascript:void(0);">审批拒绝</a></li>
                    <li class="act-item" onclick="open_sub(this,'装修中', 'ZhuangXiuList.aspx?status=zhuangxiu')">
                        <a href="javascript:void(0);">装修中</a></li>
                    <li class="act-item" onclick="open_sub(this,'已验收', 'ZhuangXiuList.aspx?status=yanshou')">
                        <a href="javascript:void(0);">已验收</a></li>
                </ul>
            </div>
            <div data-options="region:'center'" title="">
                <div class="easyui-panel" style="border: none;" data-options="fit:true">
                    <iframe id="ZhuangXiuFrame" name="ZhuangXiuFrame" style="position: absolute; top: 0; left: 0; right: 0; bottom: 0; width: 100%; height: 100%; border: none;" src="ZhuangXiuList.aspx?status=shenqing"></iframe>
                </div>
            </div>
        </div>
    </form>
</asp:Content>
