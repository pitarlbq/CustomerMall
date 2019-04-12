<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="ChatSensitiveEdit.aspx.cs" Inherits="Web.APPSetup.ChatSensitiveEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .add, .exist {
            width: 100%;
            margin: 0 auto;
            margin-top: 10px;
            border-collapse: collapse;
            border-spacing: 0px;
            border: solid 1px #ccc;
        }

        .field {
            padding: 3px 5px;
            text-align: left;
            border: solid 1px #ccc;
            width: 33%;
            display: inline-table;
        }

        .exist_field {
            padding: 3px 5px;
            text-align: left;
            border: solid 1px #ccc;
            width: 50%;
            display: inline-table;
        }

            .exist_field .exist_field_label {
                text-align: right;
                width: 30%;
                display: inline-table;
            }

            .exist_field input {
                text-align: left;
                width: 70%;
                display: inline-table;
                padding-left: 10px;
                border: 0;
                border-left: 1px #ccc solid;
            }

        input {
            width: 70%;
        }

        .add .title, .exist .title {
            text-align: center;
            padding: 5px 0;
            color: #000;
            background-color: #ccc;
        }
    </style>
    <script>
        var CanRemove = 0;
        $(function () {
            CanRemove = Number("<%=this.CanRemove%>");
        })
    </script>
    <script src="../js/Page/APPSetup/ChatSensitiveEdit.js?t=<%=base.getToken() %>"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <form id="ff" runat="server">
        <div class="add" id="keywords_field">
            <div class="title">屏蔽关键字</div>
        </div>
        <div style="text-align: center;">
            <%if (base.CheckAuthByModuleCode("1101369"))
              { %>
            <a href="javascript:void(0)" onclick="addkeywords()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-add'">新增</a>
            <%} %>
            <%if (base.CheckAuthByModuleCode("1101370"))
              { %>
            <a href="javascript:void(0)" onclick="savekeywords('keywords')" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-save'">保存</a>
            <%} %>
        </div>
    </form>
</asp:Content>
