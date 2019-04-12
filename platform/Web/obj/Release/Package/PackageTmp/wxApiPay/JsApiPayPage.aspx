<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JsApiPayPage.aspx.cs" Inherits="Web.wxApiPay.JsApiPayPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="content-type" content="text/html;charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>微信支付</title>
    <script src="../js/jquery-1.8.3.min.js"></script>

    <script type="text/javascript">
        $(function () {
            $('#btnsubmit').bind('click', function () {
                callpay();
            })
        })
        //调用微信JS api 支付
        function jsApiCall() {
            WeixinJSBridge.invoke(
            'getBrandWCPayRequest',
            <%=wxJsApiParam%>,//josn串
         function (res) {
             WeixinJSBridge.log(res.err_msg);
             alert(res.err_code + res.err_desc + res.err_msg);
         }
         );
        }

        function callpay() {
            if (typeof WeixinJSBridge == "undefined") {
                if (document.addEventListener) {
                    alert(1);
                    document.addEventListener('WeixinJSBridgeReady', jsApiCall, false);
                }
                else if (document.attachEvent) {
                    alert(2);
                    document.attachEvent('WeixinJSBridgeReady', jsApiCall);
                    document.attachEvent('onWeixinJSBridgeReady', jsApiCall);
                }
            }
            else {
                alert(3);
                jsApiCall();
            }
        }

    </script>
</head>
<body>
    <form runat="server">
        <br />
        <div align="center">
            <br />
            <br />
            <br />
            <div id="result" runat="server"></div>
            <input type="button" id="btnsubmit" value="支付" style="width: 210px; height: 50px; border-radius: 15px; background-color: #00CD00; border: 0px #FE6714 solid; cursor: pointer; color: white; font-size: 16px;" />
            <asp:Button ID="submit" runat="server" Text="立即支付" OnClientClick="callpay()" Style="width: 210px; height: 50px; border-radius: 15px; background-color: #00CD00; border: 0px #FE6714 solid; cursor: pointer; color: white; font-size: 16px;" />
        </div>
    </form>
</body>
</html>
