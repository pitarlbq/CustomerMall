<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="BalanceApproveMgr.aspx.cs" Inherits="Web.Mall.BalanceApproveMgr" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        var BalanceStatus = 0;
        $(function () {
            BalanceStatus = "<%=this.BalanceStatus%>";
        })
    </script>
    <script src="../js/Page/Mall/Balance/BalanceApproveMgr.js?v=<%=base.getToken() %>"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <div class="easyui-layout" data-options="fit:true,border:false">
        <div data-options="region:'north',border:false" style="height: 50px; font-size: 12px; padding: 5px 10px;">
            <label>
                关键字: 
                <input class="easyui-searchbox" style="width: 200px;" id="tdKeyword" type="text" data-options="prompt:'商家名称',searcher:SearchTT" />
            </label>

            <label>
                申请日期:  
                <input class="easyui-datebox" style="width: 120px;" id="tdStartTime" type="text" />
                -
                <input class="easyui-datebox" style="width: 120px;" id="tdEndTime" type="text" />
            </label>
            <%if (this.BalanceStatus == 23)
              { %>
            <label>
                结算状态:  
                <select class="easyui-combobox" id="tdBalanceStatus" data-options="editable:false" style="width: 100px">
                    <option value="">全部</option>
                    <option value="2">已结算</option>
                    <option value="3">审核未通过</option>
                </select>
            </label>
            <%} %>
            <label class="searchlabel">
                <a href="javascript:void(0)" onclick="SearchTT()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-search'">搜索</a>
            </label>
        </div>
        <div data-options="region:'center',border:false">
            <table id="tt_table"></table>
            <div id="tt_mm">
                <%if (this.BalanceStatus == 1)
                  { %>
                <a href="javascript:void(0)" onclick="do_approve()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-shenhe'">结算审核</a>
                <%} %>
                <%-- <a href="javascript:void(0)" onclick="do_export()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-export'">导出结算单</a>--%>
            </div>
        </div>
    </div>
</asp:Content>
