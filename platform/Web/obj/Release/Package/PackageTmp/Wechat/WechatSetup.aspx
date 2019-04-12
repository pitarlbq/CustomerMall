<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="WechatSetup.aspx.cs" Inherits="Web.Wechat.WechatSetup" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $(function () {
            loadIframe();
            $('#CommTab').tabs({
                onSelect: function (title, index) {
                    loadIframe();
                }
            });
        })
        function loadIframe() {
            var curTab = $('#CommTab').tabs('getSelected');
            if (curTab.find("iframe:first").attr("src") == "") {
                var iframesrc = curTab.find("input[type=hidden]:first").val();
                curTab.find("iframe:first").attr("src", iframesrc);
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <div class="easyui-tabs" id="CommTab" style="width: 100%; height: 99%; border: none;" data-options="tabHeight:35">
        <div title="公众号参数" style="padding: 10px">
            <input type="hidden" value="WechatSetup_WeiXin.aspx" />
            <iframe src="" style="width: 100%; height: 99%; border: 0"></iframe>
        </div>
        <div title="APP微信支付" style="padding: 10px">
            <input type="hidden" value="WechatSetup_APPPay.aspx" />
            <iframe src="" style="width: 100%; height: 99%; border: 0"></iframe>
        </div>
        <div title="微信网页内容" style="padding: 10px">
            <input type="hidden" value="WechatSetup_H5Page.aspx" />
            <iframe src="" style="width: 100%; height: 99%; border: 0"></iframe>
        </div>
    </div>
</asp:Content>
