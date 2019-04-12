<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="UserMgr.aspx.cs" Inherits="Web.APPSetup.UserMgr" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        var CanEdit = 0, IsFuShunJu = 0;
        $(function () {
            CanEdit = Number("<%=this.CanEdit%>");
            IsFuShunJu = Number("<%=this.IsFuShunJu%>");
        })
    </script>
    <script src="../js/Page/APPSetup/UserMgr.js?v=<%=base.getToken() %>"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <div class="easyui-layout" data-options="fit:true,border:false">
        <div data-options="region:'center',border:false">
            <div class="easyui-layout" data-options="fit:true,border:false">
                <div data-options="region:'north',border:false" style="height: 50px; font-size: 12px; padding: 10px;">
                    <label>
                        关键字:               
                        <input class="easyui-searchbox" id="tdKeyword" type="text" data-options="prompt:'关键字搜索',searcher:SearchTT" />
                    </label>
                    <label>
                        用户类型:
                        <select class="easyui-combobox" id="tdUserRoomType" data-options="editable:false">
                            <option value="">全部</option>
                            <option value="1">注册业主</option>
                            <option value="2">游客注册</option>
                        </select>
                    </label>
                    <label class="searchlabel">
                        <a href="javascript:void(0)" onclick="SearchTT()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-search'">搜索</a>
                    </label>
                </div>
                <div data-options="region:'center',border:false">
                    <table id="tt_table"></table>
                    <div id="tt_mm">
                        <%if (base.CheckAuthByModuleCode("1101375"))
                          { %>
                        <a href="javascript:void(0)" onclick="addUser()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-add'">新增</a>
                        <%} %>
                        <%if (base.CheckAuthByModuleCode("1101376"))
                          { %>
                        <a href="javascript:void(0)" onclick="editUser()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-edit'">修改</a>
                        <%} %>
                        <%if (base.CheckAuthByModuleCode("1101377"))
                          { %>
                        <a href="javascript:void(0)" onclick="removeUser()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-remove'">删除</a>
                        <%} %>
                        <%if (base.CheckAuthByModuleCode("1101378"))
                          { %>
                        <a href="javascript:void(0)" onclick="view_family()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-detail'">家庭成员</a>
                        <a href="javascript:void(0)" onclick="do_export()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-export'">导出</a>
                        <%} %>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
