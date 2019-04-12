<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="PrintChequeView.aspx.cs" Inherits="Web.PrintPage.PrintChequeView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        var RoomID, RelationID, PrintID;
        $(function () {
            RoomID = "<%=this.RoomID%>";
            RelationID = "<%=this.RelationID%>";
            PrintID = "<%=this.PrintID%>";
        })
        function do_save() {
            $('#ff').form('submit', {
                url: '../Handler/PrintHandler.ashx',
                onSubmit: function (param) {
                    param.visit = 'saveprintchequedata';
                    param.RoomID = RoomID;
                    param.RelationID = RelationID;
                    param.PrintID = PrintID;
                },
                success: function (data) {
                    var data_obj = eval("(" + data + ")");
                    if (data_obj.status) {
                        if (PrintID > 0) {
                            show_message('电子发票创建成功', 'success', function () {
                                parent.do_close_dialog();
                            });
                            return;
                        }
                        parent.do_close_dialog(function () {
                            parent.RelationID = RelationID;
                            parent.do_print_cheque_process()
                        });
                        return;
                    }
                    if (data_obj.error) {
                        show_message(data_obj.error, 'warning');
                        return;
                    }
                    show_message('系统异常', 'warning');
                }
            });
        }
        function do_close() {
            parent.do_close_dialog();
        }
    </script>
    <style>
        .panel-body {
            background: #f0f0f0;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <form id="ff" runat="server">
        <div class="operation_box">
            <a href="#" onclick="do_save()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-print'">打印</a>

            <a href="#" onclick="do_close()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-close'">放弃</a>
        </div>
        <div class="table_container">
            <div class="table_title">购买方</div>
            <table class="info">
                <tr>
                    <td>客户名称</td>
                    <td>
                        <input type="text" class="easyui-textbox" data-options="required:true" runat="server" id="tdCompanyName" /></td>
                    <td>纳税人识别号</td>
                    <td>
                        <input type="text" class="easyui-textbox" runat="server" data-options="required:true" id="tdBuyerTaxpayerNumber" /></td>
                </tr>
                <tr>
                    <td>开户银行</td>
                    <td>
                        <input type="text" class="easyui-textbox" runat="server" id="tdBuyerBankName" /></td>
                    <td>银行账号</td>
                    <td>
                        <input type="text" class="easyui-textbox" runat="server" id="tdBuyerBankAccountNo" /></td>
                </tr>
                <tr>
                    <td>地址电话</td>
                    <td>
                        <input type="text" class="easyui-textbox" runat="server" id="tdAddress" /></td>
                    <td>电子信箱</td>
                    <td>
                        <input type="text" class="easyui-textbox" runat="server" id="tdBuyerEmailAddress" /></td>
                </tr>
            </table>
            <div class="table_title">销售方</div>
            <table class="info">
                <tr>
                    <td>客户名称</td>
                    <td>
                        <input type="text" class="easyui-textbox" runat="server" data-options="required:true" id="tdSellerCompanyName" /></td>
                    <td>纳税人识别号</td>
                    <td>
                        <input type="text" class="easyui-textbox" runat="server" id="tdSellerTaxpayerNumber" /></td>
                </tr>
                <tr>
                    <td>税率</td>
                    <td>
                        <input type="text" class="easyui-textbox" data-options="required:true" runat="server" id="tdCheque_SL" />(%)</td>
                    <td>分类编码</td>
                    <td>
                        <input type="text" class="easyui-textbox" data-options="required:true" runat="server" id="tdCheque_FLBM" /></td>
                </tr>
                <tr>
                    <td>银行账号</td>
                    <td>
                        <input type="text" class="easyui-textbox" data-options="required:true" runat="server" id="tdSellerBankNo" /></td>
                    <td>开户银行</td>
                    <td>
                        <input type="text" class="easyui-textbox" runat="server" id="tdSellerBankName" /></td>
                </tr>
                <tr>
                    <td>地址电话</td>
                    <td>
                        <input type="text" class="easyui-textbox" runat="server" id="tdSellerAddress" /></td>

                    <td>复核人</td>
                    <td>
                        <input type="text" class="easyui-textbox" runat="server" id="tdReCheckUserName" /></td>
                </tr>
            </table>
        </div>
    </form>
</asp:Content>
