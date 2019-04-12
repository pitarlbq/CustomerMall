<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="ChooseMultipleProject.aspx.cs" Inherits="Web.APPSetup.ChooseMultipleProject" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../js/ztree/zTreeStyle/zTreeStyle.css?v1" rel="stylesheet" />
    <script src="../js/ztree/jquery.ztree.core.js"></script>
    <script src="../js/ztree/jquery.ztree.excheck.js"></script>
    <script src="../js/ztree/jquery.ztree.exedit.js"></script>
    <script>
        var CompanyID, ParentID;
        $(function () {
            CompanyID = "<%=Web.WebUtil.GetCompanyID(this.Context)%>";
            ParentID = "<%=this.ParentID%>";
        })
    </script>
    <script src="../js/Page/APPSetup/ChooseMultipleProject.js?t=<%=base.getToken() %>"></script>
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
    <div style="width: 90%; height: 80%; border: #d0d0d0 1px solid; margin: 0 auto;">
        <div class="easyui-panel" data-options="border:false,fit:true">
            <ul id="tt" class="ztree"></ul>
        </div>
    </div>
    <div style="height: 15%; text-align: center;">
        <a href="javascript:void(0)" onclick="Save()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-save'">选择</a>
    </div>
</asp:Content>
