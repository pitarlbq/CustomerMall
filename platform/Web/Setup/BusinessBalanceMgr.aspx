<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="BusinessBalanceMgr.aspx.cs" Inherits="Web.Setup.BusinessBalanceMgr" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        var AddMan = "<%=Web.WebUtil.GetUser(this.Context).RealName%>";
    </script>
    <script src="../js/Page/DKSetup/BusinessBalanceMgr.js?v=<%=base.getToken() %>"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <div class="easyui-layout" data-options="fit:true,border:false">
        <div data-options="region:'north',border:false" style="height: 50px; font-size: 12px;">
            <label>
                结算时间:
                <input class="easyui-datebox" id="tdStartTime" />
                -
                <input class="easyui-datebox" id="tdEndTime" />
            </label>
            <label style="">
                计算状态:
                <select class="easyui-combobox" id="tdBusinessChargeStatus" style="width: 50px;">
                    <option value="0">欠费</option>
                    <option value="1">结算</option>
                    <option value="-1">全部</option>
                </select>

            </label>
            <label class="searchlabel">
                <a href="#" class="easyui-linkbutton" onclick="SearchTT()" data-options="iconCls:'icon-search'">查询</a>
            </label>
        </div>
        <div data-options="region:'south',border:false" style="height: 50px; padding: 10px;">
            <label class="searchlabel">
                合计收款金额: <span id="tdtotalrealcost"></span>
            </label>
            <label class="searchlabel">
                收款方式: 
                <select id="tdPayType" class="easyui-combobox" name="dept" style="width: 150px;">
                    <option value="0">现金</option>
                    <option value="1">刷卡</option>
                    <option value="2">转账</option>
                    <option value="3">赠送</option>
                    <option value="4">减免</option>
                    <option value="5">微信支付</option>
                </select>
            </label>
            <label>
                收款人:
                <input class="easyui-textbox" id="tdChargeMan" />
            </label>
            <label>
                收款日期:
                <input style="width: 150px;" class="easyui-datetimebox" id="tdChargeTime" value="<%=DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") %>" />
            </label>
        </div>
        <div data-options="region:'center',border:false">
            <table id="tt_table"></table>
            <div id="tt_mm">
                <a href="#" class="easyui-linkbutton" onclick="ChargeBalance()" data-options="iconCls:'icon-add',plain:true">结算</a>
                <a href="#" class="easyui-linkbutton" onclick="PrintTable()" data-options="iconCls:'icon-print',plain:true">打印</a>
            </div>
        </div>
    </div>
</asp:Content>
