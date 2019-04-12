<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="hsytest.aspx.cs" Inherits="Web.hsytest" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table>
                <tr>
                    <td>订单号:</td>
                    <td>
                        <input type="text" style="width: 300px" runat="server" id="tdtradeno" />
                    </td>
                </tr>
                <tr>
                    <td>总金额:</td>
                    <td>
                        <input type="text" style="width: 300px" runat="server" id="tdTotalFee" />
                    </td>
                </tr>
                <tr>
                    <td>退款金额:</td>
                    <td>
                        <input type="text" style="width: 300px" runat="server" id="tdRefundFee" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Button runat="server" ID="btn_Click" OnClick="btn_Click_Click" Text="退款" />
                    </td>
                </tr>
                <tr>
                    <td>退款单号</td>
                    <td>
                        <input type="text" style="width: 300px" runat="server" id="tdrefundno" />
                    </td>
                </tr>
                <tr>
                    <td>request:</td>
                    <td>
                        <textarea runat="server" id="tdRequestData" style="width: 300px; height: 100px;"></textarea>
                    </td>
                </tr>
                <tr>
                    <td>response:</td>
                    <td>
                        <textarea runat="server" id="tdResponseData" style="width: 300px; height: 100px;"></textarea>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
