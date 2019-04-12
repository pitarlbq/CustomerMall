<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="WechatSetup_APPPay.aspx.cs" Inherits="Web.Wechat.WechatSetup_APPPay" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../js/Page/Comm/util.js"></script>
    <script type="text/javascript">
        function do_save() {
            var isValid = $("#<%=this.ff.ClientID%>").form('enableValidation').form('validate');
            if (!isValid) {
                return;
            }
            MaskUtil.mask('body', '提交中');
            $('#ff').form('submit', {
                url: '../Handler/WechatHandler.ashx',
                onSubmit: function (param) {
                    param.visit = 'savewechatapppaysetup';
                },
                success: function (message) {
                    MaskUtil.unmask();
                    var data = eval('(' + message + ')');
                    if (data.status) {
                        show_message("保存成功", "success", function () {
                            window.location.reload();
                        });
                        return;
                    }
                    show_message("保存失败", "error");
                }
            });
        }
    </script>
    <style>
        .panel-body {
            background: #f0f0f0;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <form runat="server" id="ff" method="post" enctype="multipart/form-data">
        <div class="operation_box">
            <a href="javascript:void(0)" onclick="do_save()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-save'">保存</a>
        </div>
        <div class="table_container">
            <table class="info">
                <tr>
                    <td class="first">APPID</td>
                    <td class="second">
                        <input id="tdMobileAPPID" runat="server" class="easyui-textbox" type="text" name="MobileAPPID" />
                    </td>
                    <td class="first">密钥</td>
                    <td class="second">
                        <input id="tdMobileAppSecret" runat="server" class="easyui-textbox" type="text" name="MobileAppSecret" />
                    </td>
                </tr>
                <tr>
                    <td class="first">商户ID</td>
                    <td class="second">
                        <input id="tdMobileMCHID" runat="server" class="easyui-textbox" type="text" name="MobileMCHID" />
                    </td>
                    <td class="first">证书key</td>
                    <td class="second">
                        <input id="tdMobileMCHKey" runat="server" class="easyui-textbox" type="text" name="MobileMCHKey" />
                    </td>
                </tr>
                <tr>
                    <td class="first">证书</td>
                    <td class="second">
                        <%if (!string.IsNullOrEmpty(this.MobileCertFileLocaiton))
                          { %>
                        <a target="_blank" href="<%=this.MobileCertFileLocaiton %>">下载</a>
                        <%} %>
                        <input runat="server" class="easyui-filebox" type="text" name="MobileCertFile" style="width: 50%;" data-options="prompt:'请选择文件',buttonText: '选择文件'" /></td>
                    <td class="first">商户号Pwd</td>
                    <td class="second">
                        <input id="tdMobileSSLCERT_PASSWORD" runat="server" class="easyui-textbox" type="text" name="MobileSSLCERT_PASSWORD" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</asp:Content>
