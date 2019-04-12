<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="upgradesite.aspx.cs" Inherits="Web.upgradesite" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script src="js/jquery-1.8.3.min.js"></script>
    <script src="js/easyui/jquery.easyui.min.js"></script>
    <script>
        $(function () {
        })
        function doupgrade() {
            $('#ff').form('submit', {
                url: 'Api/CommHandler.ashx',
                onSubmit: function (param) {
                    param.action = 'doupgradesite';
                },
                success: function (data) {
                    alert(data);
                }
            });
        }
    </script>
    <style>
        table.sitetitle, table.sitetable, table.fileup {
            width: 100%;
            border-spacing: 0;
            border-collapse: collapse;
            border: solid 1px #ccc;
        }

            table.sitetitle td, table.sitetable td, table.fileup td {
                border: solid 1px #ccc;
                padding: 10px;
            }

        input[type=text] {
            width: 100%;
        }
    </style>
</head>
<body>
    <form id="ff" runat="server">
        <div>
            <table class="fileup">
                <tr>
                    <td style="width: 30%">脚本上传
                    </td>
                    <td style="width: 70%">
                        <asp:FileUpload ID="uploadsql" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td style="width: 30%">后台系统代码
                    </td>
                    <td style="width: 70%">
                        <asp:FileUpload ID="uploadzip" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td style="width: 30%">微信后端代码
                    </td>
                    <td style="width: 70%">
                        <asp:FileUpload ID="uploadwechatbackend" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td style="width: 30%">微信前端代码
                    </td>
                    <td style="width: 70%">
                        <asp:FileUpload ID="uploadwechatfront" runat="server" />
                    </td>
                </tr>
            </table>
            <div style="text-align: center; margin-bottom: 10px;">
                <input type="button" onclick="doupgrade()" value="保存" />
            </div>
        </div>
    </form>
</body>
</html>
