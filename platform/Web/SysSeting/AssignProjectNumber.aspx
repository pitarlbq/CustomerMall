<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="AssignProjectNumber.aspx.cs" Inherits="Web.SysSeting.AssignProjectNumber" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../js/ztree/zTreeStyle/zTreeStyle.css?v1" rel="stylesheet" />
    <script src="../js/ztree/jquery.ztree.core.js"></script>
    <script src="../js/ztree/jquery.ztree.excheck.js"></script>
    <script src="../js/ztree/jquery.ztree.exedit.js"></script>
    <script>
        var CompanyID, OrderNumberID, UserID;
        $(function () {
            CompanyID = "<%=Web.WebUtil.GetCompanyID(this.Context)%>";
            OrderNumberID = "<%=Request.QueryString["OrderNumberID"]%>";
            UserID = "<%=Web.WebUtil.GetUser(this.Context).UserID%>";
        })
    </script>
    <script src="../js/Page/SysSetting/AssignProjectNumber.js?t=<%=base.getToken() %>"></script>
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
    <div style="width: 100%; height: 95%; border: #d0d0d0 1px solid; padding: 0.5% 0.5%;">
        <div class="easyui-panel" data-options="border:false,fit:true">
            <div>
                <a href="javascript:void(0)" onclick="Save()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-save'">保存</a>
            </div>
            <ul id="tt" class="ztree"></ul>
        </div>
    </div>
</asp:Content>
