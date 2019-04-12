<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="updatechargeid.aspx.cs" Inherits="Web.test.updatechargeid" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script src="../js/jquery-1.8.3.min.js"></script>
    <script src="../js/easyui/jquery.easyui.min.js"></script>
    <script src="../js/easyui/easyui-lang-zh_CN.js"></script>
    <link href="../js/easyui/gray/easyui.css" rel="stylesheet" />
    <link href="../styles/buttons.css?v=35" rel="stylesheet" />
    <script src="../js/Page/Comm/unit.js"></script>
    <script type="text/javascript">
        function do_save() {
            var filebox = $("#attached").filebox("getValue");
            if (filebox == "") {
                $("#<%=this.errMsg.ClientID%>").html("请选择文件");
                return;
            }
            top.$.messager.confirm("提示", "确认上传?", function (r) {
                $('#ff').form('submit', {
                    url: "../CommHandler.ashx",
                    onSubmit: function (param) {
                        param.visit = "updatehistoryfeechageid"
                    },
                    dataType: "html",
                    success: function (data) {
                        data = data.replace(/&lt;/g, "<");
                        data = data.replace(/&gt;/g, ">");
                        $("#<%=this.errMsg.ClientID%>").html(data);
                    }
                });
            })
        }
    </script>
    <style>
        body, html {
            margin: 0 !important;
            padding: 0;
        }

        table.info {
            width: 96%;
            margin: 0 auto;
            border: 0px;
            border-spacing: 0;
            border-collapse: collapse;
        }

            table.info td {
                width: 35%;
                text-align: left;
                padding: 5px 10px;
            }

                table.info td:nth-child(2n+1) {
                    width: 15%;
                }

        .notifyMsg {
            text-align: center;
            color: #ff0000;
        }
    </style>
</head>
<body>
    <form id="ff" method="post" runat="server" enctype="multipart/form-data">
        <table class="info">
            <tr>
                <td>文件</td>
                <td colspan="3">
                    <input class="easyui-filebox" name="attachfile" id="attached" data-options="prompt:'请选择文件',buttonText: '选择文件'" style="width: 60%" />
                </td>
            </tr>
            <tr>
                <td colspan="4" style="text-align: center; width: 100%;">
                    <a href="javascript:void(0)" onclick="do_save()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-save'">保存</a>
                </td>
            </tr>
        </table>
        <div class="notifyMsg">
            <label runat="server" id="errMsg"></label>
        </div>

    </form>
</body>
</html>
