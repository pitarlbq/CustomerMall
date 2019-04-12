<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="subpage.aspx.cs" Inherits="Web.Main.subpage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .subtitle {
            background: #f9f9f7 none repeat scroll 0 0;
            border-bottom: 1px solid #ddd;
            height: 30px;
            position: relative;
            z-index: 10;
            padding-left: 200px;
        }

        .titlename {
            float: left;
            height: 30px;
        }

            .titlename a {
                background: #2f80d1 none repeat scroll 0 0;
                border-radius: 10px;
                color: #fff;
                text-decoration: none;
                display: inline-block;
                margin-left: 20px;
                margin-top: 5px;
                padding: 0 10px;
            }

        .choosetitlename {
            float: left;
            height: 30px;
        }

            .choosetitlename a {
                background: #888888 none repeat scroll 0 0;
                border-radius: 10px;
                color: #fff;
                text-decoration: none;
                display: inline-block;
                margin-left: 20px;
                margin-top: 5px;
                padding: 0 10px;
            }
    </style>
    <script>
        $(function () {
            var url = "<%=this.iframeUrl%>";
            $("#siteFrame").attr("src", url);
        })
        window.onresize = dynsiteFramesize;
        function dynsiteFramesize() {
            var $height = parent.document.body.clientHeight;
            $("#siteFrame").css("height", ($height - 80) + "px");
        }
        function showsubpage(url) {
            $("#siteFrame").attr("src", url);
        }
        $(function () {
            var r = $(".subpagediv");
            if ($(r[0]).hasClass("titlename")) {
                $(r[0]).removeClass("titlename");
            }
            if (!$(r[0]).hasClass("choosetitlename")) {
                $(r[0]).addClass("choosetitlename");
            }
            $(".subpagediv").click(function () {
                var $this = $(this);
                var r = $(".subpagediv");
                for (var i = 0; i < r.length; i++) {
                    if ($(r[i]).hasClass("choosetitlename")) {
                        $(r[i]).removeClass("choosetitlename");
                    }
                    if (!$(r[i]).hasClass("titlename")) {
                        $(r[i]).addClass("titlename");
                    }
                }
                $this.removeClass("titlename");
                $this.addClass("choosetitlename");
            })
        })
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <div class="subtitle">
        <asp:Repeater runat="server" ID="rptsubpage">
            <ItemTemplate>
                <div class="titlename subpagediv"><a href="#" onclick="showsubpage('<%#Eval("Url") %>')"><%#Eval("Title") %></a></div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
    <div style="clear: both;"></div>
    <iframe id="siteFrame" name="siteFrame" style="width: 100%; height: 100%; border: none;" src="" onload="dynsiteFramesize()"></iframe>
</asp:Content>
