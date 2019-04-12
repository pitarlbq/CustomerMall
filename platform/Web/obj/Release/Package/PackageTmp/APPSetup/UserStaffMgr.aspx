<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="UserStaffMgr.aspx.cs" Inherits="Web.APPSetup.UserStaffMgr" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        var CanViewCoupon = 0;
        $(function () {
            CanViewCoupon = Number("<%=this.CanViewCoupon%>");
        })
    </script>
    <script src="../js/Page/APPSetup/UserStaffMgr.js?v=<%=base.getToken() %>"></script>
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
                    <label class="searchlabel">
                         <a href="javascript:void(0)" onclick="SearchTT()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-search'">搜索</a>
                    </label>
                </div>
                <div data-options="region:'center',border:false">
                    <table id="tt_table"></table>
                    <div id="tt_mm">
                        <%if (base.CheckAuthByModuleCode("1101379"))
                          { %>
                        <a href="javascript:void(0)" onclick="addUser()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-add'">新增</a>
                        <%} %>
                        <%if (base.CheckAuthByModuleCode("1101380"))
                          { %>
                        <a href="javascript:void(0)" onclick="editUser()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-edit'">修改</a>
                        <%} %>
                        <%if (base.CheckAuthByModuleCode("1101381"))
                          { %>
                        <a href="javascript:void(0)" onclick="removeUser()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-remove'">删除</a>
                        <%} %>
                        <%if (base.CheckAuthByModuleCode("1101382"))
                          { %>
                        <a href="javascript:void(0)" onclick="view_check()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-detail'">考评记录</a>
                        <%} %>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
