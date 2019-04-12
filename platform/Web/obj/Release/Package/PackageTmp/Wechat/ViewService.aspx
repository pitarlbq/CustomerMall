<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="ViewService.aspx.cs" Inherits="Web.Wechat.ViewService" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
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
            <a href="javascript:void(0)" onclick="do_close()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-close'">关闭</a>
        </div>
        <div class="table_container">
            <table class="info">
                <tr class="detail">
                    <td colspan="4" style="text-align: center;">
                        <label runat="server" id="labTitle"></label>
                    </td>
                </tr>
                <tr class="detail">
                    <td>服务地址
                    </td>
                    <td colspan="3">
                        <input type="text" class="easyui-textbox" id="tdFullName" runat="server" style="width: 100%;" />
                    </td>
                </tr>
                <tr class="detail">
                    <td>反馈内容
                    </td>
                    <td colspan="3">
                        <input type="text" class="easyui-textbox" id="tdServiceContent" runat="server" data-options="multiline:true" style="height: 100px; width: 100%;" />
                    </td>
                </tr>
                <tr>
                    <td>联系电话
                    </td>
                    <td colspan="3">
                        <input type="text" class="easyui-textbox" id="tdPhoneNumber" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>预约时间
                    </td>
                    <td colspan="3">
                        <input type="text" class="easyui-datetimebox" style="" id="tdServiceAddTime" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>预约人
                    </td>
                    <td colspan="3">
                        <input type="text" class="easyui-textbox" id="tdOpenID" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>上传图片
                    </td>
                    <td colspan="3">
                        <asp:Repeater runat="server" ID="rptImg">
                            <ItemTemplate>
                                <div style="float: left; width: 200px; margin: 1%;">
                                    <a target="_blank" href="<%#getFullPath(Eval("Large").ToString()) %>">
                                        <img style="width: 150px;" src="<%#Eval("Icon") %>" />
                                    </a>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</asp:Content>
