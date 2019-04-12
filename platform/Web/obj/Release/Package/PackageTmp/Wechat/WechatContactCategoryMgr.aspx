<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="WechatContactCategoryMgr.aspx.cs" Inherits="Web.Wechat.WechatContactCategoryMgr" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        function do_close() {
            parent.do_close_dialog(function () {
                parent.set_combobox();
            });
        }
    </script>
    <script src="../js/Page/Wechat/WechatContactCategoryMgr.js?t=<%=base.getToken() %>"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <form id="ff">
        <div class="easyui-panel" style="width: 100%; height: 200px; padding: 10px; background: #fafafa; margin: 10px 0;">
            <div class="operation_box">
                <a href="javascript:void(0)" onclick="do_close()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-close'">关闭</a>
            </div>
            <div class="table_container">
                <table style="width: 100%;">
                    <tr>
                        <td>名称
                        </td>
                        <td>
                            <input type="hidden" id="tdID" />
                            <input type="text" id="tdName" class="easyui-textbox" data-options="required:true" />
                        </td>
                        <td>排序</td>
                        <td>
                            <input type="text" id="tdSortOrder" class="easyui-textbox" /></td>
                    </tr>
                    <tr>
                        <td colspan="4" style="text-align: center;">
                            <a href="javascript:void(0)" onclick="savetype()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-save'">保存</a>
                            <a href="javascript:void(0)" onclick="canceltype()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-close'">撤销</a>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
        <div id="tb">
            <a href="javascript:void(0)" onclick="edittype()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-edit'">修改</a>
            <a href="javascript:void(0)" onclick="deletetype()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-remove'">删除</a>
        </div>
        <table id="tt_table">
            <thead>
                <tr>
                    <th data-options="field:'ck',checkbox:true"></th>
                    <th data-options="field:'Name'" width="260">名称</th>
                    <th data-options="field:'SortOrder', formatter: formatSortOrder" width="80">排列顺序</th>
                </tr>
            </thead>
        </table>
    </form>
</asp:Content>
