<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="WechatSetup_H5Page.aspx.cs" Inherits="Web.Wechat.WechatSetup_H5Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        var tdWechatConnnectRoomSummary;
        $(function () {
            tdWechatConnnectRoomSummary = $('#<%=this.tdWechatConnnectRoomSummary.ClientID%>');
        })
        function do_save() {
            var isValid = $("#<%=this.ff.ClientID%>").form('enableValidation').form('validate');
            if (!isValid) {
                return;
            }
            MaskUtil.mask('body', '提交中');
            $('#ff').form('submit', {
                url: '../Handler/WechatHandler.ashx',
                onSubmit: function (param) {
                    param.visit = 'savewechathtmlpageconfig';
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
    <style type="text/css">
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
                    <td class="first">首页图片</td>
                    <td class="second">
                        <%if (!string.IsNullOrEmpty(this.HomeBannerPath))
                          { %>
                        <a target="_blank" href="<%=this.HomeBannerPath %>">下载</a>
                        <%} %>
                        <input runat="server" class="easyui-filebox" type="text" name="homebanner" style="width: 75%;" data-options="prompt:'请选择文件',buttonText: '选择文件'" /></td>
                    <td class="first">房间认证图片</td>
                    <td class="second">
                        <%if (!string.IsNullOrEmpty(this.ConnectRoomBannerPath))
                          { %>
                        <a target="_blank" href="<%=this.ConnectRoomBannerPath %>">下载</a>
                        <%} %>
                        <input runat="server" class="easyui-filebox" type="text" name="connectroombanner" style="width: 50%;" data-options="prompt:'请选择文件',buttonText: '选择文件'" /></td>
                </tr>
                <tr>
                    <td>房间认证说明</td>
                    <td colspan="3">
                        <input class="easyui-textbox" type="text" id="tdWechatConnnectRoomSummary" runat="server" data-options="multiline:true" style="height: 80px; width: 85%;" /></td>
                </tr>
            </table>
        </div>
    </form>
</asp:Content>
