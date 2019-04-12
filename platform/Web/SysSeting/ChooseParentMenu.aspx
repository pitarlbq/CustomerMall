<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="ChooseParentMenu.aspx.cs" Inherits="Web.SysSeting.ChooseParentMenu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../js/ztree/zTreeStyle/zTreeStyle.css?v1" rel="stylesheet" />
    <script src="../js/ztree/jquery.ztree.core.js"></script>
    <script>
        var ID = 0;
        $(function () {
            ID = Number("<%=Request.QueryString["ID"]%>");
        })
    </script>
    <script src="../js/Page/SysSetting/ChooseParentMenu.js?token=<%=base.getToken() %>"></script>
    <link href="../styles/treecss.css" rel="stylesheet" />
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

        .searchlabel a#tdsearch {
            display: none;
        }

        .datagrid-mask {
            position: absolute;
            left: 0;
            top: 0;
            width: 100%;
            height: 100%;
            opacity: 0.3;
            filter: alpha(opacity=30);
            display: none;
        }

        .datagrid-mask-msg {
            position: absolute;
            top: 50%;
            margin-top: -10px;
            padding: 12px 5px 12px 30px;
            width: auto;
            height: 50px;
            border-width: 2px;
            border-style: solid;
            display: none;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <div class="easyui-layout" data-options="fit:true">
        <div data-options="region:'center',border:false">
            <div class="easyui-panel" style="max-height: 90%;" data-options="fit:true">
                <ul id="tt" class="ztree"></ul>
            </div>
            <div class="easyui-panel" style="max-height: 10%;" data-options="fit:true">
                <a href="javascript:void(0)" onclick="do_save()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-save'">选择</a>
                <input type="hidden" id="hdID" />
            </div>
        </div>
    </div>
</asp:Content>
