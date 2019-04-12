<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="ConnectContactPhoneRoom.aspx.cs" Inherits="Web.Wechat.ConnectContactPhoneRoom" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../js/ztree/zTreeStyle/zTreeStyle.css?v1" rel="stylesheet" />
    <script src="../js/ztree/jquery.ztree.core.js"></script>
    <script src="../js/ztree/jquery.ztree.excheck.js"></script>
    <script src="../js/ztree/jquery.ztree.exedit.js"></script>
    <script>
        var CompanyID, ContactID;
        $(function () {
            CompanyID = "<%=Web.WebUtil.GetCompanyID(this.Context)%>";
            ContactID = "<%=Request.QueryString["ContactID"]%>";
        })
    </script>
    <script src="../js/Page/Wechat/ConnectContactPhoneRoom.js?t=<%=base.getToken() %>"></script>
    <style>
        .l-btn-plain {
            display: inline;
        }

        .ztree li {
            padding: 5px 0 0 0;
            /*background:url("../js/ztree/zTreeStyle/img/line_conn.gif") repeat-y scroll 0 0*/
        }

            .ztree li > input {
                margin: 0;
            }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <div class="easyui-layout" data-options="fit:true,border:false">
        <div data-options="region:'north',border:false" style="height: 40px; font-size: 12px; padding: 5px;">
            <div class="operation_box">
                <a href="javascript:void(0)" onclick="do_save()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-save'">保存</a>
                <a href="javascript:void(0)" onclick="do_close()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-close'">关闭</a>
            </div>
        </div>
        <div data-options="region:'center',border:false">
            <div class="easyui-panel" data-options="border:false,fit:true">
                <ul id="tt" class="ztree"></ul>
            </div>
        </div>
    </div>
</asp:Content>
