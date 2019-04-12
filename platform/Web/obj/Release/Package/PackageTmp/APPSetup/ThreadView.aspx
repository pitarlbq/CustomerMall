<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="ThreadView.aspx.cs" Inherits="Web.APPSetup.ThreadView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function do_close() {
            parent.do_close_dialog();
        }
    </script>
    <style type="text/css">
        .panel-body {
            background: #f0f0f0;
        }

        .image_box {
            width: 100px;
            text-align: center;
        }

            .image_box a image {
                width: 100%;
            }

            .image_box a {
                margin: 0 auto;
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
                    <td>发帖人
                    </td>
                    <td colspan="3">
                        <label runat="server" id="tdUserName"></label>
                    </td>
                </tr>
                <tr>
                    <td>发帖时间
                    </td>
                    <td colspan="3">
                        <label runat="server" id="tdAddTime"></label>
                    </td>
                </tr>
                <tr>
                    <td>发帖分类
                    </td>
                    <td colspan="3">
                        <label runat="server" id="tdCategoryID"></label>
                    </td>

                </tr>
                <tr>
                    <td>发帖内容
                    </td>
                    <td colspan="3">
                        <label runat="server" id="tdDescription"></label>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</asp:Content>
