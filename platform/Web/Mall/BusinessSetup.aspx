<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="BusinessSetup.aspx.cs" Inherits="Web.Mall.BusinessSetup" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript">
        $(function () {
        })
        function saveConfig() {
            var isValid = $("#<%=this.ff.ClientID%>").form('enableValidation').form('validate');
            if (!isValid) {
                return;
            }
            var BusinessDistance = $("#<%=this.tdBusinessDistance.ClientID%>").textbox("getValue");
            var options = {};
            options.visit = "savebusinessconfigparam";
            options.BusinessDistance = BusinessDistance;
            MaskUtil.mask('body', '提交中');
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/MallHandler.ashx',
                data: options,
                success: function (message) {
                    MaskUtil.unmask();
                    if (message.status) {
                        show_message('保存成功', 'success');
                    }
                    else {
                        show_message('系统错误', 'error');
                    }
                }
            });
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
                width: 70%;
                vertical-align: middle;
            }

                table.info td:nth-child(2n-1) {
                    text-align: right;
                    width: 30%;
                }

        input[type=text] {
            width: 60px;
            text-align: center;
        }

        table.info td.header_title {
            text-align: center;
            background-color: #0094ff;
            color: #fff;
            font-size: 14px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <form id="ff" runat="server">
        <div style="padding: 10px 0;">
            <table class="info">
                <tr>
                    <td colspan="4" class="header_title">距离配置
                    </td>
                </tr>
                <tr>
                    <td colspan="4" style="text-align: left;">超过
                        <input class="easyui-textbox" type="text" id="tdBusinessDistance" runat="server" />
                        公里的商家不显示</td>
                </tr>
            </table>
            <div style="text-align: center; margin: 10px 0;">
                <a href="javascript:void(0)" onclick="saveConfig()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-save'">保存</a>
            </div>
        </div>
    </form>
</asp:Content>
