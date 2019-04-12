<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChequeTest.aspx.cs" Inherits="Web.ChequeTest" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <style>
        table.info {
            width: 90%;
            margin: 0 auto;
            border: solid 1px #ccc;
            border-collapse: collapse;
            border-spacing: 0;
        }

            table.info td {
                width: 35%;
                text-align: left;
                border: solid 1px #ccc;
                padding: 10px;
            }

                table.info td:nth-child(2n-1) {
                    width: 15%;
                    text-align: right;
                }

            table.info input[type=text] {
                height: 30px;
                border-radius: 5px !important;
                border: solid 1px #ddd;
                width: 50%;
            }

        textarea {
            height: 100px;
            width: 100%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <table class="info">
            <tr>
                <td colspan="2" style="text-align: left;">登录
                </td>
            </tr>
            <tr>
                <td>用户名
                </td>
                <td>
                    <input type="text" runat="server" id="tdLoginName" />
                </td>
            </tr>
            <tr>
                <td>密码
                </td>
                <td>
                    <input type="text" runat="server" id="tdPassword" />
                </td>
            </tr>
            <tr>
                <td colspan="2" style="text-align: center;">
                    <asp:Button runat="server" ID="btnDoLogin" OnClick="btnDoLogin_Click" Text="提交" />
                </td>
            </tr>
            <tr>
                <td>返回结果
                </td>
                <td>
                    <textarea runat="server" id="tdLoginResponse"></textarea>
                </td>
            </tr>
            <tr>
                <td colspan="2" style="text-align: left;">开票
                </td>
            </tr>
            <tr>
                <td>TOCKET
                </td>
                <td>
                    <input type="text" runat="server" id="tdTOCKET" />
                </td>
            </tr>
            <tr>
                <td colspan="2" style="text-align: center;">
                    <asp:Button runat="server" ID="btnWriteInvoice" OnClick="btnWriteInvoice_Click" Text="提交" />
                </td>
            </tr>
            <tr>
                <td>返回结果
                </td>
                <td>
                    <textarea runat="server" id="tdWriteInvoiceResponse"></textarea>
                </td>
            </tr>
            <tr>
                <td colspan="2" style="text-align: left;">获取开票结果
                </td>
            </tr>
            <tr>
                <td>TOCKET
                </td>
                <td>
                    <input type="text" runat="server" id="tdReceiptTocket" />
                </td>
            </tr>
            <tr>
                <td>单据号
                </td>
                <td>
                    <input type="text" runat="server" id="tdReceiptNumber" />
                </td>
            </tr>
            <tr>
                <td colspan="2" style="text-align: center;">
                    <asp:Button runat="server" ID="btnGetInvoiceResult" OnClick="btnGetInvoiceResult_Click" Text="提交" />
                </td>
            </tr>
            <tr>
                <td>返回结果
                </td>
                <td>
                    <textarea runat="server" id="tdInvoiceResultResponse"></textarea>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
