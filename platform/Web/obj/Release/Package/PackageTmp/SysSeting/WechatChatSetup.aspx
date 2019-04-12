<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="WechatChatSetup.aspx.cs" Inherits="Web.SysSeting.WechatChatSetup" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript">
        $(function () {

        })
        function do_save() {
            var isValid = $("#<%=this.ff.ClientID%>").form('enableValidation').form('validate');
            if (!isValid) {
                return;
            }
            MaskUtil.mask('body', '提交中');
            $('#ff').form('submit', {
                url: '../Handler/SysSettingHandler.ashx',
                onSubmit: function (param) {
                    param.visit = 'savewechatchatconfig';
                },
                success: function (data) {
                    MaskUtil.unmask();
                    var dataObj = eval("(" + data + ")");
                    if (dataObj.status) {
                        show_message("保存成功", "success", function () {
                            do_close();
                        });
                        return;
                    }
                    if (dataObj.error) {
                        show_message(dataObj.error, 'error');
                        return;
                    }
                    show_message('内部异常', 'error');
                }
            });
        }
        function do_close() {
            parent.do_close_dialog();
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
                    <td>客服服务工作时间</td>
                    <td colspan="3">
                        <input class="easyui-timespinner" style="width: 100px;" type="text" id="tdWechatChatStartTime" runat="server" />
                        -
                        <input class="easyui-timespinner" style="width: 100px;" type="text" id="tdWechatChatEndTime" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>工作时间客服申请回复内容</td>
                    <td colspan="3">
                        <input class="easyui-textbox" type="text" id="tdWechatChatLeaveMsg" runat="server" data-options="multiline:true" style="height: 60px; width: 85%;" />
                    </td>
                </tr>
                <tr>
                    <td>非工作时间客服申请回复内容</td>
                    <td colspan="3">
                        <input class="easyui-textbox" type="text" id="tdWechatChatNotWorkMsg" runat="server" data-options="multiline:true" style="height: 60px; width: 85%;" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</asp:Content>
