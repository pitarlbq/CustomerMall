<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="AddOutingService.aspx.cs" Inherits="Web.Cheque.AddOutingService" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../js/Page/Comm/PinYin.js"></script>
    <script>
        var guid, OutingID, ID;
        $(function () {
            guid = "<%=Request.QueryString["guid"]%>";
            OutingID = "<%=Request.QueryString["OutingID"]%>";
            ID = "<%=Request.QueryString["ID"]%>";
        })
    </script>
    <script type="text/javascript">
        function saveData() {
            var isValid = $("#<%=this.ff.ClientID%>").form('enableValidation').form('validate');
            if (!isValid) {
                return;
            }
            var ServiceName = $("#<%=this.tdServiceName.ClientID%>").textbox("getValue");
            var ServiceAddress = $("#<%=this.tdServiceAddress.ClientID%>").textbox("getText");
            var ServiceStartTime = $("#<%=this.tdServiceStartTime.ClientID%>").datebox("getValue");
            var ServiceEndTime = $("#<%=this.tdServiceEndTime.ClientID%>").datebox("getValue");
            var ContractMoney = $("#<%=this.tdContractMoney.ClientID%>").textbox("getValue");
            var options = { visit: 'savechequeoutingservice', ID: ID, ServiceName: ServiceName, ServiceAddress: ServiceAddress, ServiceStartTime: ServiceStartTime, ServiceEndTime: ServiceEndTime, ContractMoney: ContractMoney, guid: guid, OutingID: OutingID };
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
                    <td>应税劳务名称
                    </td>
                    <td>
                        <input type="text" class="easyui-textbox" id="tdServiceName" runat="server" data-options="required:true" />
                    </td>
                    <td>劳务地点
                    </td>
                    <td>
                        <input type="text" class="easyui-textbox" id="tdServiceAddress" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>有效期
                    </td>
                    <td colspan="3">
                        <input type="text" class="easyui-datebox" id="tdServiceStartTime" runat="server" />
                        -
                        <input type="text" class="easyui-datebox" id="tdServiceEndTime" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>合同金额
                    </td>
                    <td colspan="3">
                        <input type="text" class="easyui-textbox" id="tdContractMoney" runat="server" />
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
