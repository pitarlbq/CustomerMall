<%@ Page Title="" Language="C#" MasterPageFile="~/Master/NavContent4.Master" AutoEventWireup="true" CodeBehind="ChargeFeePreChargeAll.aspx.cs" Inherits="Web.Charge.ChargeFeePreChargeAll" %>

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
        <div title="单据明细" style="padding: 0px">
            <input type="hidden" value="ChargeFeePreChargeAllDetail.aspx" />
            <iframe src="" style="width: 100%; height: 99%; border: 0"></iframe>
        </div>
        <div title="历史单据" style="padding: 0px">
            <input type="hidden" value="ChargeFeePreChargeAllHistory.aspx" />
            <iframe src="" style="width: 100%; height: 99%; border: 0"></iframe>
        </div>
    </div>
</asp:Content>
