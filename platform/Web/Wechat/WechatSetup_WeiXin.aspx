<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="WechatSetup_WeiXin.aspx.cs" Inherits="Web.Wechat.WechatSetup_WeiXin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../js/Page/Comm/util.js"></script>
    <script type="text/javascript">
        var Is_Active = 0;
        $(function () {
            Is_Active = Number("<%=this.Is_Active%>");
            if (Is_Active == 1) {
                $('#yes_active').removeClass('hidden');
                $('#no_active').addClass('hidden');
                $.parser.parse('#yes_active');
            }
            else {
                $('#yes_active').addClass('hidden');
                $('#no_active').removeClass('hidden');
            }
        })
        function do_start() {
            var options = {};
            options.action = "startwechat";
            MaskUtil.mask('body', '提交中');
            Util.get(options, function (succeed, data, err) {
                MaskUtil.unmask();
                if (succeed) {
                    window.location.reload();
                } else if (err) {
                    show_message(err, "info");
                }
            });
        }
        function do_save() {
            var isValid = $("#<%=this.ff.ClientID%>").form('enableValidation').form('validate');
            if (!isValid) {
                return;
            }
            MaskUtil.mask('body', '提交中');
            $('#ff').form('submit', {
                url: '../Handler/WechatHandler.ashx',
                onSubmit: function (param) {
                    param.visit = 'savewechatsetup';
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

        table.info.hidden {
            display: none;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <form runat="server" id="ff" method="post" enctype="multipart/form-data">
        <table class="info" id="no_active">
            <tr>
                <td colspan="2" style="text-align: center;">
                    <a href="javascript:void(0)" onclick="do_start()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-save'">启用</a>
                </td>
            </tr>
        </table>
        <div id="yes_active">
            <div class="operation_box">
                <a href="javascript:void(0)" onclick="do_save()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-save'">保存</a>
            </div>
            <div class="table_container">
                <table class="info">
                    <tr>
                        <td class="first">APPID</td>
                        <td class="second">
                            <input id="tdAppID" runat="server" class="easyui-textbox" type="text" name="AppID" />
                        </td>
                        <td class="first">密钥</td>
                        <td class="second">
                            <input id="tdAppSecret" runat="server" class="easyui-textbox" type="text" name="AppSecret" />
                        </td>
                    </tr>
                    <tr>
                        <td class="first">Token</td>
                        <td class="second">
                            <input id="tdToken" runat="server" class="easyui-textbox" type="text" name="Token" />
                        </td>
                        <td class="first">授权URL</td>
                        <td class="second">
                            <input id="tdOauth2Url" runat="server" class="easyui-textbox" type="text" name="Oauth2Url" />
                        </td>
                    </tr>
                    <tr>
                        <td class="first">授权URL验证文件</td>
                        <td class="second">
                            <input type="text" class="easyui-filebox" name="attachfile" data-options="prompt:'请选择文件',buttonText: '选择文件'" style="width: 70%" />
                        </td>
                        <td class="first">接口地址</td>
                        <td class="second">
                            <input id="tdWxApiUrl" runat="server" class="easyui-textbox" type="text" name="WxApiUrl" />
                        </td>
                    </tr>
                    <tr>
                        <td class="first">商户ID</td>
                        <td class="second">
                            <input id="tdMCHID" runat="server" class="easyui-textbox" type="text" name="MCHID" />
                        </td>
                        <td class="first">证书key</td>
                        <td class="second">
                            <input id="tdMCHKey" runat="server" class="easyui-textbox" type="text" name="MCHKey" />
                        </td>
                    </tr>
                    <tr>
                        <td class="first">证书</td>
                        <td class="second">
                            <%if (!string.IsNullOrEmpty(this.CertFileLocaiton))
                              { %>
                            <a target="_blank" href="<%=this.CertFileLocaiton %>">下载</a>
                            <%} %>
                            <input runat="server" class="easyui-filebox" type="text" name="CertFile" style="width: 70%;" data-options="prompt:'请选择文件',buttonText: '选择文件'" /></td>
                        <td class="first">商户号Pwd</td>
                        <td class="second">
                            <input id="tdSSLCERT_PASSWORD" runat="server" class="easyui-textbox" type="text" name="SSLCERT_PASSWORD" />
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </form>
</asp:Content>
