<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="ChequeOutWriteCheque.aspx.cs" Inherits="Web.Cheque.ChequeOutWriteCheque" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../js/Page/Comm/PinYin.js"></script>
    <script>
        var ID;
        $(function () {
            ID = "<%=Request.QueryString["ID"]%>";
        })
    </script>
    <script type="text/javascript">
        function saveData() {
            var isValid = $("#<%=this.ff.ClientID%>").form('enableValidation').form('validate');
            if (!isValid) {
                return;
            }
            var ChequeNumber = $("#<%=this.tdChequeNumber.ClientID%>").textbox("getValue");
            var ChequeCode = $("#<%=this.tdChequeCode.ClientID%>").textbox("getText");
            var ChequeTime = $("#<%=this.tdChequeTime.ClientID%>").datebox("getValue");
            var WriteMan = $("#<%=this.tdWriteMan.ClientID%>").textbox("getValue");
            var options = { visit: 'savechequeoutwritecheque', ID: ID, ChequeNumber: ChequeNumber, ChequeCode: ChequeCode, ChequeTime: ChequeTime, WriteMan: WriteMan };
            top.$.messager.progress();
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/ChequeHandler.ashx',
                data: options,
                success: function (message) {
                    top.$.messager.progress('close');
                    if (message.status) {
                        show_message('保存成功', 'success', function () {
                            closeWin();
                        });
                    }
                    else {
                        show_message('系统错误', 'error');
                    }
                }
            });
        }
        function closeWin() {
            parent.$("#winadd").window("close");
        }
    </script>
    <style type="text/css">
        table.info {
            width: 90%;
            margin: 0 auto;
            border: solid 1px #ccc;
            border-spacing: 0;
            border-collapse: collapse;
        }

            table.info td {
                border: solid 1px #ccc;
                padding: 10px;
                text-align: left;
                width: 35%;
            }

                table.info td:nth-child(2n-1) {
                    text-align: right;
                    width: 15%;
                }

        input {
            width: 200px;
        }

        .hidefield {
            display: none;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <form id="ff" runat="server">
        <div style="padding: 10px 0;">
            <table class="info">
                <tr>
                    <td>发票编号
                    </td>
                    <td>
                        <input type="text" class="easyui-textbox" id="tdChequeNumber" runat="server" />
                    </td>
                    <td>发票代码</td>
                    <td>
                        <input type="text" class="easyui-textbox" id="tdChequeCode" runat="server" /></td>

                </tr>
                <tr>
                    <td>开票日期
                    </td>
                    <td>
                        <input type="text" class="easyui-datebox" id="tdChequeTime" runat="server" />
                    </td>
                    <td>开票人
                    </td>
                    <td>
                        <input type="text" class="easyui-textbox" id="tdWriteMan" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td colspan="4" style="text-align: center;">
                        <a href="javascript:void(0)" onclick="saveData()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-save'">保存</a>
                        <a href="javascript:void(0)" onclick="closeWin()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-close'">关闭</a>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</asp:Content>
