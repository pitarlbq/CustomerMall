<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="ImportInSummary.aspx.cs" Inherits="Web.Cheque.ImportInSummary" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function ImportData() {
            var filebox = $("#attached").filebox("getValue");
            if (filebox == "") {
                $("#<%=this.errMsg.ClientID%>").html("请选择文件");
                return;
            }
            $.messager.progress();
            $('#ff').form('submit', {
                url: "../Handler/ImportChequeHandler.ashx?visit=importinsummary",
                dataType: "html",
                success: function (data) {
                    $.messager.progress('close');
                    data = data.replace(/&lt;/g, "<");
                    data = data.replace(/&gt;/g, ">");
                    $("#<%=this.errMsg.ClientID%>").html(data);
                }
            });
        }
        function closeWin() {
            parent.$("#winadd").window("close");
        }
    </script>
    <style type="text/css">
        table.info {
            margin: 0 auto;
            margin-top: 10px;
            width: 90%;
            border-collapse: collapse;
            border-spacing: 0;
            border: solid 1px #ccc;
        }

            table.info td {
                padding: 5px 10px;
                text-align: left;
                vertical-align: middle;
                border: solid 1px #ccc;
                text-align: left;
                width: 35%;
            }

                table.info td:nth-child(2n-1) {
                    text-align: right;
                    width: 15%;
                }

        .notifyMsg {
            text-align: center;
            color: #ff0000;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <form id="ff" method="post" runat="server" enctype="multipart/form-data">
        <table class="info">
            <tr>
                <td>文件</td>
                <td>
                    <input class="easyui-filebox" name="attachfile" id="attached" data-options="prompt:'请选择文件',buttonText: '选择文件'" style="width: 60%" />
                </td>
            </tr>
            <tr>
                <td colspan="2" style="text-align: center;">
                    <a href="javascript:void(0)" onclick="ImportData()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-save'">导入</a>
                    <a href="javascript:void(0)" onclick="closeWin()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-save'">关闭</a>
                </td>
            </tr>
        </table>
        <div class="notifyMsg">
            <label runat="server" id="errMsg"></label>
        </div>
    </form>
</asp:Content>
