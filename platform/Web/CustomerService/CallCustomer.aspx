<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="CallCustomer.aspx.cs" Inherits="Web.CustomerService.CallCustomer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        var ID;
        $(function () {
            ID = "<%=Request.QueryString["ID"]%>";
        });
        function do_save() {
            var isValid = $("#<%=this.ff.ClientID%>").form('enableValidation').form('validate');
            if (!isValid) {
                return;
            }
            MaskUtil.mask('body', '提交中');
            $('#ff').form('submit', {
                url: '../Handler/ServiceHandler.ashx',
                onSubmit: function (param) {
                    param.visit = 'savehuifang';
                    param.ID = ID;
                },
                success: function (data) {
                    MaskUtil.unmask();
                    var dataObj = eval("(" + data + ")");
                    if (dataObj.status) {
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
        function do_close() {
            parent.do_close_dialog(function () {
            }, true);
        }
    </script>
    <style type="text/css">
        .panel-body {
            background: #f0f0f0;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <form id="ff" runat="server">
        <div class="operation_box">
            <a href="javascript:void(0)" onclick="do_save()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-save'">保存</a>
            <a href="javascript:void(0)" onclick="do_close()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-close'">关闭</a>
        </div>
        <div class="table_container">
            <table class="info">
                <tr>
                    <td>接单人</td>
                    <td>
                        <input type="text" runat="server" name="AcceptMan" data-options="disabled:true" class="easyui-textbox" id="tdAcceptMan" /></td>
                    <td>预约时间</td>
                    <td>
                        <input type="text" runat="server" name="AppointTime" data-options="disabled:true" class="easyui-datetimebox" id="tdAppointTime" /></td>
                </tr>
                <tr>
                    <td>回访时间</td>
                    <td colspan="3">
                        <input type="text" runat="server" data-options="required:true" name="HuiFangTime" class="easyui-datetimebox" id="tdHuiFangTime" /></td>
                </tr>
                <tr>
                    <td>回访情况</td>
                    <td colspan="3">
                        <input type="text" runat="server" name="td" class="easyui-textbox" id="tdHuiFangNote" data-options="multiline:true" style="width: 100%; height: 60px;" /></td>
                </tr>
            </table>
            <asp:Repeater runat="server" ID="rptRecord">
                <HeaderTemplate>
                    <table class="info" style="margin-top: 10px">
                        <tr>
                            <td colspan="4" style="text-align: center;">回访历史记录
                            </td>
                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td>回访时间</td>
                        <td style="width: 20%;"><%# ((DateTime)Eval("HuiFangTime")) == DateTime.MinValue ? "" : Eval("HuiFangTime", "{0:yyyy-MM-dd HH:mm:ss}")%></td>
                        <td>回访情况</td>
                        <td style="width: 50%;"><%#Eval("HuiFangNote") %></td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
        </div>
    </form>
</asp:Content>
