<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="UserCouponMgr.aspx.cs" Inherits="Web.APPSetup.UserCouponMgr" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        var UserID = 0;
        $(function () {
            UserID = "<%=this.UserID%>";
        })
    </script>
    <script src="../js/Page/APPSetup/UserCouponMgr.js?v=<%=base.getToken() %>"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <div class="easyui-layout" data-options="fit:true,border:false">
        <div data-options="region:'north',border:false" style="height: 80px; font-size: 12px; padding: 40px 10px 5px 5px;">
            <div class="operation_box">
                <a href="javascript:void(0)" onclick="do_close()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-close'">关闭</a>
            </div>
            <label>
                用户名:
                <input class="easyui-searchbox" id="tdKeyword" type="text" data-options="prompt:'关键字搜索',searcher:SearchTT" />
            </label>
            <label>
                福顺券类型:
                <select id="tdCouponType" style="width: 100px" class="easyui-combobox" data-options="editable:false">
                    <option value="">全部</option>
                    <option value="1">单品券</option>
                    <option value="2">店铺券</option>
                    <option value="3">全场通用劵</option>
                    <option value="4">品类优惠券</option>
                    <option value="5">物业缴费优惠券</option>
                    <option value="6">生日券</option>
                </select>
            </label>
            <label>
                使用状态:
                <select id="tdIsUsed" style="width: 100px" class="easyui-combobox" data-options="editable:false">
                    <option value="-1">全部</option>
                    <option value="1">已使用</option>
                    <option value="0">未使用</option>
                </select>
            </label>
            <label>
                卡券状态:
                <select id="tdIsActive" style="width: 100px" class="easyui-combobox" data-options="editable:false">
                    <option value="-1">全部</option>
                    <option value="1">有效</option>
                    <option value="0">失效</option>
                </select>
            </label>
            <label class="searchlabel">
                <a href="javascript:void(0)" onclick="SearchTT()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-search'">搜索</a>
            </label>
        </div>
        <div data-options="region:'center',border:false">
            <table id="tt_table"></table>
            <div id="tt_mm">
                <%if (base.CheckAuthByModuleCode("1101387"))
                  { %>
                <a href="javascript:void(0)" onclick="do_edit()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-edit'">修改</a>
                <%} %>
                <%if (base.CheckAuthByModuleCode("1101388"))
                  { %>
                <a href="javascript:void(0)" onclick="do_remove()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-remove'">删除</a>
                <%} %>
                <%if (base.CheckAuthByModuleCode("1101389"))
                  { %>
                <a href="javascript:void(0)" onclick="do_active(1)" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-remove'">批量失效</a>
                <%} %>
                <%if (base.CheckAuthByModuleCode("1101390"))
                  { %>
                <a href="javascript:void(0)" onclick="do_active(0)" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-edit'">批量生效</a>
                <%} %>
                <%if (base.CheckAuthByModuleCode("1101391"))
                  { %>
                <a href="javascript:void(0)" onclick="do_all_edit()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-edit'">批量修改有效期</a>
                <%} %>
            </div>
        </div>
    </div>
</asp:Content>
