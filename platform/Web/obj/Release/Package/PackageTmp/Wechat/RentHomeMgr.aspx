<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="RentHomeMgr.aspx.cs" Inherits="Web.Wechat.RentHomeMgr" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../js/ztree/zTreeStyle/zTreeStyle.css?v1" rel="stylesheet" />
    <script src="../js/ztree/jquery.ztree.core.js"></script>
    <script src="../js/ztree/jquery.ztree.excheck.js"></script>
    <script src="../js/ztree/jquery.ztree.exedit.js"></script>
    <script src="../js/Page/Wechat/RentHomeMgr.js?v=<%=base.getToken() %>"></script>
    <style>
        .searcharea label {
            padding: 0px 5px;
        }
    </style>
    <style type="text/css">
        body, .panel-body, .textbox .textbox-text, .l-btn-text {
            font-size: 13px;
        }

        .l-btn-plain {
            display: inline;
        }

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
    <div class="easyui-layout" data-options="fit:true,border:false">
        <div data-options="region:'west',border:false" style="width: 260px;">
            <div class="easyui-panel searchlabel" style="max-height: 10%;">
                <input id="searchbox" class="easyui-searchbox" data-options="prompt:'',searcher:doSearchTree" style="height: 30px; width: 150px;" />
                <a href="#" onclick="reset()">刷新</a>
            </div>
            <div class="easyui-panel" style="max-height: 90%;">
                <div>
                    <a href="javascript:void(0)" onclick="addTree()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-add'">增加</a>
                    <a href="javascript:void(0)" onclick="editTree()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-edit'">修改</a>
                    <a href="javascript:void(0)" onclick="removeTree()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-remove'">删除</a>
                </div>
                <ul id="tt" class="ztree"></ul>
            </div>
        </div>
        <div data-options="region:'center',border:false">
            <div class="easyui-layout" data-options="fit:true,border:false">
                <div class="searcharea" data-options="region:'north',border:false" style="height: 60px; font-size: 12px; padding: 10px 0px 0px 10px;">
                    <label>
                        关键字:                
                        <input class="easyui-searchbox" id="tdKeyword" type="text" data-options="prompt:'关键字搜索',searcher:SearchTT" />
                    </label>
                    <label class="searchlabel">
                        <a href="javascript:void(0)" onclick="SearchTT()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-search'">搜索</a>
                    </label>
                </div>
                <div data-options="region:'center',border:false,fit:true">
                    <table id="tt_table"></table>
                    <div id="tt_mm">
                        <a href="javascript:void(0)" onclick="addRow()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-add'">新增</a>
                        <a href="javascript:void(0)" onclick="editRow()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-edit'">修改</a>
                        <a href="javascript:void(0)" onclick="removeRows()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-remove'">删除</a>
                        <a href="javascript:void(0)" onclick="viewWechatPage()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-detail'">微信通道</a>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
