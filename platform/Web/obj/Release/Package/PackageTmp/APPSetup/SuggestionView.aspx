<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="SuggestionView.aspx.cs" Inherits="Web.APPSetup.SuggestionView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
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
    <form id="ff" runat="server" method="post" enctype="multipart/form-data">
        <div class="operation_box">
            <a href="javascript:void(0)" onclick="do_close()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-close'">关闭</a>
        </div>
        <div class="table_container">
            <table class="info">
                <tr>
                    <td>用户昵称</td>
                    <td>
                        <label runat="server" id="tdNickName"></label>
                    </td>
                    <td>联系方式</td>
                    <td>
                        <label runat="server" id="tdPhoneNumber"></label>
                    </td>
                </tr>
                <tr>
                    <td>反馈内容
                    </td>
                    <td colspan="3">
                        <label runat="server" id="tdContentSummary"></label>
                    </td>
                </tr>
                <tr>
                    <td>反馈时间
                    </td>
                    <td colspan="3">
                        <label runat="server" id="tdAddTime"></label>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</asp:Content>
