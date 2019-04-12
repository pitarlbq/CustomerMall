<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MallDoorQrCode.aspx.cs" Inherits="Web.WeiXin.MallDoorQrCode" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="maximum-scale=1.0,minimum-scale=1.0,user-scalable=0,width=device-width,initial-scale=1.0" />
    <meta name="format-detection" content="telephone=no,email=no,date=no,address=no" />
    <title>访客二维码</title>
    <style>
        html, body {
            margin: 0;
            padding: 0;
        }

        .qrcode_img {
            margin: 20px 0;
            min-height: 5rem;
            text-align: center;
        }

            .qrcode_img img {
                max-width: 80%;
                margin: 0 auto;
            }

        .qrcode_summary {
            text-align: center;
        }

            .qrcode_summary label {
                font-size: 1rem;
            }
    </style>
</head>
<body>
    <form runat="server">
        <div class="qrcode_img">
            <img runat="server" id="tdPath" src="" />
        </div>
        <div class="qrcode_summary">
            <label id="tdSummary" runat="server"></label>
        </div>
    </form>
</body>
</html>
