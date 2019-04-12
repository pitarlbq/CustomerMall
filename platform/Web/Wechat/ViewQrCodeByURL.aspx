<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="ViewQrCodeByURL.aspx.cs" Inherits="Web.Wechat.ViewQrCodeByURL" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        $(function () {
            var pageurl = "<%=this.pageurl%>" || "";
            var QrCodeImgPath = "<%=this.QrCodeImgPath%>" || "";
            if (QrCodeImgPath != '') {
                $('#qrcodeimg').attr('src', QrCodeImgPath);
                $('#qrcodelink').attr('href', pageurl);
                return;
            }
            var options = { visit: 'viewqrcodebyurl', pageurl: pageurl };
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/WechatHandler.ashx',
                data: options,
                success: function (data) {
                    if (data.status) {
                        $('#qrcodeimg').attr('src', data.qrcodeurl);
                        $('#qrcodelink').attr('href', pageurl);
                    }
                    else {
                        show_message('系统错误', 'error');
                    }
                }
            });
        })
        function do_close() {
            parent.do_close_dialog();
        }
    </script>
    <style>
        .qrcodearea {
            padding-top: 50px;
            text-align: center;
        }

            .qrcodearea img {
                margin: 0 auto;
            }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <div class="operation_box">
        <a href="javascript:void(0)" onclick="do_close()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-close'">关闭</a>
    </div>
    <div class="table_container">
        <div class="qrcodearea">
            <img id="qrcodeimg" src="" />
            <br />
            <a id="qrcodelink" href="#" target="_blank">链接地址</a>
        </div>
    </div>
</asp:Content>
