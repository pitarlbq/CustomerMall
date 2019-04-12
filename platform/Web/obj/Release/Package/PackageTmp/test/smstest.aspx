<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="smstest.aspx.cs" Inherits="Web.smstest" %>

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
                    <td>电话
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="tdPhoneNumber" Style="width: 500px;"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>内容
                    </td>
                    <td>
                        <asp:TextBox runat="server" TextMode="MultiLine" ID="tdContent" Style="width: 500px; height: 100px;"></asp:TextBox>
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
            </table>
        </div>
    </form>
</body>
</html>
