<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="SysMenuMgr.aspx.cs" Inherits="Web.SysSeting.SysMenuMgr" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../js/ztree/zTreeStyle/zTreeStyle.css?v1" rel="stylesheet" />
    <script src="../js/ztree/jquery.ztree.core.js"></script>
    <script src="../js/Page/SysSetting/SysMenuMgr.js?token=<%=base.getToken() %>"></script>
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

        table.info {
            width: 100%;
            border-spacing: 0;
            border-collapse: collapse;
            border: solid 1px #ccc;
        }

            table.info td {
                text-align: left;
                width: 35%;
                border: solid 1px #ccc;
                padding: 5px 10px;
            }

                table.info td:nth-child(2n-1) {
                    width: 15%;
                    text-align: right;
                }

            table.info input[type=text], table.info select {
                width: 300px;
            }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <div class="easyui-layout" data-options="fit:true">
        <div data-options="region:'west',split:true,title:'项目菜单',border:false" style="width: 260px; padding: 10px; border: none;">
            <div class="easyui-panel" style="max-height: 30px;" data-options="fit:true">
                <a href="javascript:void(0)" onclick="do_add()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-add'">新增</a>
                <a href="javascript:void(0)" onclick="do_remove()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-remove'">删除</a>
                 <a href="javascript:void(0)" onclick="doSearch()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-search'">搜索</a>
            </div>
            <div class="easyui-panel" style="max-height: 90%;" data-options="fit:true">
                <ul id="tt" class="ztree"></ul>
            </div>
        </div>
        <div data-options="region:'center',border:false">
            <form id="ff" method="post" enctype="multipart/form-data">
                <table class="info">
                    <tr>
                        <td>菜单名称</td>
                        <td>
                            <input type="hidden" id="hdID" />
                            <input type="hidden" id="hdGroupName" />
                            <input type="text" class="easyui-textbox" id="tdName" /></td>
                        <td>父级菜单</td>
                        <td>
                            <input type="text" class="easyui-textbox" data-options="readonly:true" id="tdParentName" />
                            <input type="hidden" id="hdParentID" />
                            <a href="javascript:void(0)" onclick="do_choose()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-choose'">选择</a>
                        </td>
                    </tr>
                    <tr>
                        <td>类型</td>
                        <td>
                            <select class="easyui-combobox" id="tdMenuType" data-options="editable:false">
                                <option value="1">菜单链接</option>
                                <option value="2">操作按钮</option>
                                <option value="3">下属菜单链接</option>
                            </select>
                        </td>
                        <td>链接地址</td>
                        <td>
                            <input type="text" class="easyui-textbox" id="tdUrl" style="width: 100%;" />
                        </td>
                    </tr>
                    <tr>
                        <td>图标</td>
                        <td>
                            <div id="existicon"></div>
                            <input id="tdIconPath" runat="server" class="easyui-filebox" type="text" name="IconPath" style="width: 70%;" data-options="prompt:'请选择文件',buttonText: '选择文件'" />
                        </td>
                        <td>排序</td>
                        <td>
                            <input type="text" class="easyui-textbox" id="tdSortOrder" /></td>
                    </tr>
                    <tr>
                        <td>显示图片</td>
                        <td>
                            <select class="easyui-combobox" id="tdUsingImgURL" data-options="editable:false">
                                <option value="0">否</option>
                                <option value="1">是</option>
                            </select>
                        </td>
                        <td>图片地址
                        </td>
                        <td>
                            <div id="existimage"></div>
                            <input id="tdImgUrl" runat="server" class="easyui-filebox" type="text" name="ImgUrl" style="width: 70%;" data-options="prompt:'请选择文件',buttonText: '选择文件'" />
                        </td>
                    </tr>
                    <tr>
                        <td>描述</td>
                        <td colspan="3">
                            <input type="text" class="easyui-textbox" data-options="multiline:true" style="width: 80%; height: 50px;" id="tdDescription" /></td>
                    </tr>
                    <tr>
                        <td>模块编码</td>
                        <td colspan="3"><label id="label_ModuleCode"></label></td>
                    </tr>
                    <tr>
                        <td colspan="4" style="text-align: center">
                            <a href="javascript:void(0)" onclick="do_save()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-save'">保存</a>
                        </td>
                    </tr>
                </table>
            </form>
        </div>
    </div>
</asp:Content>
