<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="CheckRuleMgr.aspx.cs" Inherits="Web.APPSetup.CheckRuleMgr" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../js/ztree/zTreeStyle/zTreeStyle.css?v1" rel="stylesheet" />
    <script src="../js/ztree/jquery.ztree.core.js"></script>
    <script src="../js/ztree/jquery.ztree.excheck.js"></script>
    <script src="../js/ztree/jquery.ztree.exedit.js"></script>
    <script>
        var type = 1;
        $(function () {
            type = Number("<%=this.type%>");
        })
    </script>
    <script src="../js/Page/APPSetup/CheckRuleMgr.js?v=<%=base.getToken() %>"></script>
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
        <div data-options="region:'center',border:false" style="width: 260px;">
            <div class="easyui-layout" data-options="fit:true,border:false" id="main_container_form">
                <div class="searcharea" data-options="region:'north',border:false" style="height: 60px; font-size: 12px; padding: 10px 0px 0px 10px;">
                    <label>
                        关键字:                
                        <input class="easyui-searchbox" id="tdKeyword" type="text" data-options="prompt:'关键字搜索',searcher:SearchTT" />
                    </label>
                    <label>
                        <select id="tdCategoryType" class="easyui-combobox" style="width: 100px" data-options="editable:false">
                            <option value="">全部</option>
                            <option value="1">奖励</option>
                            <option value="2">惩罚</option>
                        </select>
                    </label>
                    <label class="searchlabel">
                        <a href="javascript:void(0)" onclick="SearchTT()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-search'">搜索</a>
                    </label>
                </div>
                <div data-options="region:'center',border:false">
                    <table id="tt_table"></table>
                    <div id="tt_mm">
                        <a href="javascript:void(0)" onclick="addRow()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-add'">新增</a>
                        <a href="javascript:void(0)" onclick="editRow()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-edit'">修改</a>
                        <a href="javascript:void(0)" onclick="removeRows()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-remove'">删除</a>
                    </div>
                </div>
            </div>
            <div class="easyui-layout" data-options="fit:true" id="dialog_container_form" style="display: none;">
                <div data-options="region:'center',border:false">
                    <iframe id="dialog_container_frame" src="" style="width: 100%; height: 0px; border: 0; position: absolute; top: 30px; left: 0; right: 0;"></iframe>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
