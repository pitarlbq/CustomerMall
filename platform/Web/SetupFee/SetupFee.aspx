<%@ Page Title="" Language="C#" MasterPageFile="~/Master/NavContent.Master" AutoEventWireup="true" CodeBehind="SetupFee.aspx.cs" Inherits="Web.SetupFee.SetupFee" %>

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
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <div class="easyui-tabs" id="CostTab" style="width: 100%; height: 99%; border: none;" data-options="tabHeight:35">
        <%if (base.CheckAuthByModuleCode("1191042"))
          {%>
        <div title="收费标准" style="padding: 10px">
            <input type="hidden" value="ViewRoomFeeList.aspx" />
            <iframe src="" style="width: 100%; height: 99%; border: 0"></iframe>
        </div>
        <%} %>
        <%if (base.CheckAuthByModuleCode("1191043"))
          {%>
        <div title="收费项目" style="padding: 10px">
            <input type="hidden" value="SetupFeeSummary.aspx" />
            <iframe src="" style="width: 100%; height: 99%; border: 0"></iframe>
        </div>
        <%} %>
    </div>
</asp:Content>
