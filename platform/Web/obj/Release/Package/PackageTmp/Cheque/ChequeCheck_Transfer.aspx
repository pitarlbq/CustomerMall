<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="ChequeCheck_Transfer.aspx.cs" Inherits="Web.Cheque.ChequeCheck_Transfer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../js/Page/Comm/PinYin.js"></script>
    <script>
        var InSummaryID, ID;
        $(function () {
            InSummaryID = "<%=Request.QueryString["InSummaryID"]%>";
            ID = "<%=Request.QueryString["ID"]%>";
        })
    </script>
    <script type="text/javascript">
        function saveData() {
            var isValid = $("#<%=this.ff.ClientID%>").form('enableValidation').form('validate');
            if (!isValid) {
                return;
            }
            var TransferTime = $("#<%=this.tdTransferTime.ClientID%>").datebox("getValue");
            var TransferMan = $("#<%=this.tdTransferMan.ClientID%>").textbox("getText");
            var TransferRemark = $("#<%=this.tdTransferRemark.ClientID%>").textbox("getValue");
            var TransferMoney = $("#<%=this.tdTransferMoney.ClientID%>").textbox("getValue");
            var options = { visit: 'savechequechecktransfer', ID: ID, InSummaryID: InSummaryID, TransferTime: TransferTime, TransferMan: TransferMan, TransferRemark: TransferRemark, TransferMoney: TransferMoney };
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
            parent.$("#winaddproduct").window("close");
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
                    <td>转出日期
                    </td>
                    <td>
                        <input type="text" class="easyui-datebox" id="tdTransferTime" runat="server" />
                    </td>
                    <td>转出人
                    </td>
                    <td>
                        <input type="text" class="easyui-textbox" id="tdTransferMan" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>转出金额
                    </td>
                    <td colspan="3">
                        <input type="text" class="easyui-textbox" id="tdTransferMoney" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>备注
                    </td>
                    <td colspan="3">
                        <input type="text" class="easyui-textbox" id="tdTransferRemark" runat="server" data-options="multiline:true" style="height: 50px; width: 80%;" />
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
