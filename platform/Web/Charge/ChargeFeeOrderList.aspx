<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="ChargeFeeOrderList.aspx.cs" Inherits="Web.Charge.ChargeFeeOrderList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../js/Page/Charge/ChargeFeeOrderList.js?v=<%=base.getToken() %>_v1.1"></script>
    <script src="../js/Lodop/LodopFuncs.js?t=<%=base.getToken() %>"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <div class="easyui-layout" data-options="fit:true,border:false">
        <div data-options="region:'north',border:false" style="height: 50px; font-size: 12px; padding: 5px 10px;">
            <label>
                交款日期:
                <input class="easyui-datetimebox" id="tdStartTime" type="text" />
                -
                <input class="easyui-datetimebox" id="tdEndTime" type="text" />
            </label>
            <label>
                交款人
                <input class="easyui-combobox" id="tdAddMan" type="text" />
            </label>
            <label>
                审核状态
                <select class="easyui-combobox" id="tdApproveStatus">
                    <option value="">全部</option>
                    <option value="0">待审核</option>
                    <option value="1">审核通过</option>
                    <option value="2">审核未通过</option>
                    <option value="3">已作废</option>
                </select>
            </label>
            <label>
                审核人
                <input class="easyui-combobox" id="tdApproveMan" type="text" />
            </label>
            <label class="searchlabel">
                <a href="javascript:void(0)" onclick="SearchTT()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-search'">搜索</a>
            </label>
        </div>
        <div data-options="region:'center',border:false">
            <table id="tt_table"></table>
            <div id="tt_mm">
                <%if (base.CheckAuthByModuleCode("1191491"))
                  { %>
                <a href="javascript:void(0)" onclick="ApproveData()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-shenhe'">审核</a>
                <%} %>
                <%if (base.CheckAuthByModuleCode("1191492"))
                  { %>
                <a href="javascript:void(0)" onclick="do_cancel()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-cancel'">作废</a>
                <%} %>
                <%if (base.CheckAuthByModuleCode("1191493"))
                  { %>
                <a href="javascript:void(0)" onclick="DeleteData()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-remove'">删除</a>
                <%} %>
            </div>
        </div>
    </div>
</asp:Content>
