<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PayTest.aspx.cs" Inherits="Web.PayTest" %>

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
                    <td>支付金额
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="tdPayMoney" Style="width: 500px;"></asp:TextBox>（分）
                    </td>
                </tr>
                 <tr>
                    <td>通道类型
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="tdchannel_type" Style="width: 500px;"></asp:TextBox>（分）
                    </td>
                </tr>
                <tr>
                    <td>返回</td>
                    <td>
                        <asp:TextBox runat="server" TextMode="MultiLine" ID="tdResult" Style="width: 500px; height: 100px;"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Button runat="server" ID="tdSumit" OnClick="tdSumit_Click" Text="提交" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Button runat="server" ID="btnChangeWebConfigErrorMode" OnClick="btnChangeWebConfigErrorMode_Click" Text="修改错误显示模式" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
