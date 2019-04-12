<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LlingTest.aspx.cs" Inherits="Web.LlingTest" %>

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
                    <td>页码
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="tdPage" Style="width: 500px;"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>页大小
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="tdRows" Style="width: 500px;"></asp:TextBox>
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
