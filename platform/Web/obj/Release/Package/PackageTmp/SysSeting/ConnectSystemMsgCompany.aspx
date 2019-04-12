<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="ConnectSystemMsgCompany.aspx.cs" Inherits="Web.SysSeting.ConnectSystemMsgCompany" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../js/ztree/zTreeStyle/zTreeStyle.css?v1" rel="stylesheet" />
    <script src="../js/ztree/jquery.ztree.core.js"></script>
    <script src="../js/ztree/jquery.ztree.excheck.js"></script>
    <script src="../js/ztree/jquery.ztree.exedit.js"></script>
    <script>
        var MsgID;
        $(function () {
            MsgID = "<%=Request.QueryString["MsgID"]%>";
        })
    </script>
    <script src="../js/Page/SysSetting/ConnectSystemMsgCompany.js?t=<%=base.getToken() %>"></script>
    <style>
        .l-btn-plain {
            display: inline;
        }

        .ztree li {
            padding: 5px 0 0 0;
        }

            .ztree li > input {
                margin: 0;
            }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <div style="width: 90%; height: 80%; border: #d0d0d0 1px solid; margin: 0 auto;">
        <div class="easyui-panel" data-options="border:false,fit:true">
            <ul id="tt" class="ztree"></ul>
        </div>
    </div>
    <div style="height: 15%; text-align: center;">
        <a href="javascript:void(0)" onclick="Save()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-save'">保存</a>
    </div>
</asp:Content>
