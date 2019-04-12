<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="ChequeCheck_Approve.aspx.cs" Inherits="Web.Cheque.ChequeCheck_Approve" %>

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
            var ApproveTime = $("#<%=this.tdApproveTime.ClientID%>").datebox("getValue");
            var ApproveMan = $("#<%=this.tdApproveMan.ClientID%>").textbox("getText");
            var ApproveMethod = $("#<%=this.tdApproveMethod.ClientID%>").textbox("getValue");
            var ApproveMonth = $("#<%=this.tdApproveMonth.ClientID%>").textbox("getValue");
            var ApproveRemark = $("#<%=this.tdApproveRemark.ClientID%>").textbox("getValue");
            var options = { visit: 'savechequecheckapprove', ID: ID, InSummaryID: InSummaryID, ApproveTime: ApproveTime, ApproveMan: ApproveMan, ApproveMethod: ApproveMethod, ApproveMonth: ApproveMonth, ApproveRemark: ApproveRemark };
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
                    <td>认证日期
                    </td>
                    <td>
                        <input type="text" class="easyui-datebox" id="tdApproveTime" runat="server" />
                    </td>
                    <td>认证人
                    </td>
                    <td>
                        <input type="text" class="easyui-textbox" id="tdApproveMan" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>认证方式
                    </td>
                    <td>
                        <input type="text" class="easyui-textbox" id="tdApproveMethod" runat="server" />
                    </td>
                    <td>认证月度
                    </td>
                    <td>
                        <input type="text" class="easyui-textbox" id="tdApproveMonth" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>认证结果
                    </td>
                    <td colspan="3">
                        <input type="text" class="easyui-textbox" id="tdApproveRemark" runat="server" data-options="multiline:true" style="height: 50px; width: 80%;" />
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
