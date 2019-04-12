<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="ChequeOutSign.aspx.cs" Inherits="Web.Cheque.ChequeOutSign" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
            var SignOperator = $("#<%=this.tdSignOperator.ClientID%>").textbox("getValue");
            var SignRemark = $("#<%=this.tdSignRemark.ClientID%>").textbox("getText");
            var SignTime = $("#<%=this.tdSignTime.ClientID%>").datetimebox("getValue");
            var options = { visit: 'savechequeoutsign', ID: ID, SignOperator: SignOperator, SignRemark: SignRemark, SignTime: SignTime };
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
                    <td>签收人员
                    </td>
                    <td>
                        <input type="text" class="easyui-textbox" id="tdSignOperator" runat="server" data-options="required:true" />
                    </td>
                    <td>签收日期
                    </td>
                    <td>
                        <input type="text" class="easyui-datetimebox" id="tdSignTime" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>签收备注
                    </td>
                    <td colspan="3">
                        <input type="text" class="easyui-textbox" data-options="multiline:true" style="width: 80%; height: 50px;" id="tdSignRemark" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td colspan="4" style="text-align: center;">
                        <%if (summary.SignState != 1)
                          {%>
                        <a href="javascript:void(0)" onclick="saveData()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-save'">保存</a>
                        <%} %>
                        <a href="javascript:void(0)" onclick="closeWin()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-close'">关闭</a>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</asp:Content>
