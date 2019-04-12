<%@ Page Title="" Language="C#" MasterPageFile="~/Master/NavContent4.Master" AutoEventWireup="true" CodeBehind="ToCuiShouMgr.aspx.cs" Inherits="Web.Analysis.ToCuiShouMgr" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $(function () {
            loadIframe();
            $('#CostTab').tabs({
                onSelect: function (title, index) {
                    loadIframe();
                }
            });
        })
        function loadIframe() {
            var curTab = $('#CostTab').tabs('getSelected');
            if (curTab.find("iframe:first").attr("src") == "") {
                var iframesrc = curTab.find("input[type=hidden]:first").val();
                curTab.find("iframe:first").attr("src", iframesrc);
                var $height = $(window).height();
                curTab.find("iframe:first").css("height", ($height - 65) + "px");
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <div class="easyui-tabs" id="CostTab" style="width: 100%; height: 99%; border: none;" data-options="tabHeight:35">
        <div title="待收明细" style="padding: 0px">
            <input type="hidden" value="ToCuiKuanList.aspx" />
            <iframe src="" style="width: 100%; height: 99%; border: 0"></iframe>
        </div>
        <div title="催收单据" style="padding: 0px">
            <input type="hidden" value="ToCuiKuanDetails.aspx" />
            <iframe src="" style="width: 100%; height: 99%; border: 0"></iframe>
        </div>
    </div>
</asp:Content>
