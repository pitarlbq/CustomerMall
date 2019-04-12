<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WxCustomerServiceTest.aspx.cs" Inherits="Web.test.WxCustomerServiceTest" Async="true" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <style>
        table.info {
            width: 100%;
            border: 0;
            border-spacing: 0;
            border-collapse: collapse;
        }

            table.info td {
                width: 10%;
                text-align: left;
                padding: 10px;
            }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <table>
            <tr>
                <td colspan="2" style="text-align: center;">创建客服
                </td>
            </tr>
            <tr>
                <td>客服帐号
                </td>
                <td>
                    <input type="text" runat="server" id="tdAccountName" style="width: 300px; height: 30px;" />
                </td>
            </tr>
            <tr>
                <td>昵称
                </td>
                <td>
                    <input type="text" runat="server" id="tdAccountNickName" style="width: 300px; height: 30px;" />
                </td>
            </tr>
            <tr>
                <td colspan="2" style="text-align: center;">
                    <asp:Button runat="server" ID="btnSave1" OnClick="btnSave1_Click" Text="保存" />
                </td>
            </tr>
            <tr>
                <td>响应内容
                </td>
                <td>
                    <asp:TextBox runat="server" ID="tdResponse1" Height="200" Width="500"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="2" style="text-align: center;">创建会话
                </td>
            </tr>
            <tr>
                <td>客服帐号
                </td>
                <td>
                    <input type="text" runat="server" id="tdCustomerAccount" style="width: 300px; height: 30px;" />
                </td>
            </tr>
            <tr>
                <td>用户OpenID
                </td>
                <td>
                    <input type="text" runat="server" id="tdOpenID" style="width: 300px; height: 30px;" />
                </td>
            </tr>
            <tr>
                <td colspan="2" style="text-align: center;">
                    <asp:Button runat="server" ID="btnSave" OnClick="btnSave_Click" Text="保存" />
                </td>
            </tr>
            <tr>
                <td>响应内容
                </td>
                <td>
                    <asp:TextBox runat="server" ID="tdResponse" Height="200" Width="500"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="2" style="text-align: center;">发送推送
                </td>
            </tr>
            <tr>
                <td colspan="2" style="text-align: center;">
                    <asp:Button runat="server" ID="Button2" OnClick="btnSave2_Click" Text="保存" />
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
