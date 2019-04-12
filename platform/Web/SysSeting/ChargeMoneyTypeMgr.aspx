<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="ChargeMoneyTypeMgr.aspx.cs" Inherits="Web.SysSeting.ChargeMoneyTypeMgr" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../js/Page/SysSetting/ChargeMoneyTypeMgr.js?t=<%=base.getToken() %>"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <form id="ff">
        <%if (base.CheckAuthByModuleCode("1191095"))
          { %>
        <div class="easyui-panel" style="width: 100%; height: 80px; padding: 10px; background: #fafafa; margin: 10px 0;">
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
        <%} %>
        <table id="tt_table">
            <thead>
                <tr>
                    <th data-options="field:'ck',checkbox:true"></th>
                    <th data-options="field:'ChargeTypeName'" width="260">名称</th>
                    <th data-options="field:'SortOrder', formatter: formatSortOrder" width="80">排列顺序</th>
                </tr>
            </thead>
        </table>
        <div id="tb">
            <%if (base.CheckAuthByModuleCode("1191096"))
              { %>
            <a href="javascript:void(0)" onclick="edittype()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-edit'">修改</a>
            <%} %>
            <%if (base.CheckAuthByModuleCode("1191097"))
              { %>
            <a href="javascript:void(0)" onclick="deletetype()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-close'">删除</a>
            <%} %>
        </div>
    </form>
</asp:Content>
