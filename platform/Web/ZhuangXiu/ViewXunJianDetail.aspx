<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="ViewXunJianDetail.aspx.cs" Inherits="Web.ZhuangXiu.ViewXunJianDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $(function () {
            loadIframe();
            $('#ContractTab').tabs({
                onSelect: function (title, index) {
                    loadIframe();
                }
            });
        })
        function loadIframe() {
            var curTab = $('#ContractTab').tabs('getSelected');
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
    <div class="easyui-tabs" id="ContractTab" style="width: 100%; height: 99%; border: none;" data-options="tabHeight:35">
        <div title="正常记录" style="padding: 0px">
            <input type="hidden" value="ViewXunJianDetailInfo.aspx?ID=<%=Request.QueryString["ID"] %>&op=normal" />
            <iframe src="" style="width: 100%; height: 99%; border: 0"></iframe>
        </div>
        <div title="违规记录" style="padding: 0px">
            <input type="hidden" value="ViewXunJianDetailInfo.aspx?ID=<%=Request.QueryString["ID"] %>&op=weigui" />
            <iframe src="" style="width: 100%; height: 99%; border: 0"></iframe>
        </div>
    </div>
</asp:Content>
