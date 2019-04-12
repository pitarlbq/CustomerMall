<%@ Page Title="" Language="C#" MasterPageFile="~/Master/NavContent4.Master" AutoEventWireup="true" CodeBehind="ClearRealCostHistory.aspx.cs" Inherits="Web.SysSeting.ClearRealCostHistory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        var CompanyID;
        $(function () {
            CompanyID = "<%=Web.WebUtil.GetCompanyID(this.Context)%>";
        })
    </script>
    <script src="../js/Page/SysSetting/ClearRealCostHistory.js?t=<%=base.getToken() %>"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <form runat="server">
        <div id="layout" class="easyui-layout" fit="true">
            <div data-options="region:'north',split:false,hideCollapsedContent:false," title="" style="height: 90px; padding: 5px 10px;">
                <label>
                    收款时间:
                <input class="easyui-datebox" id="tdStartTime" />
                    -
                <input class="easyui-datebox" id="tdEndTime" />
                </label>
                <label>
                    收款人:
                <input class="easyui-combobox" id="tdChargeMan" style="width: 150px;" />
                </label>
                <label>
                    收费项目:
                <input class="easyui-combobox" id="tdChargeSummary" style="width: 150px;" />
                </label>
                <label>
                    收款方式:
                <input class="easyui-combobox" id="tdChargeType" style="width: 150px;" />
                </label>
                <label>
                    费项分类:
                <input class="easyui-combobox" id="tdCategory" style="width: 150px;" />
                </label>
                <%if (base.CheckAuthByModuleCode("1191494"))
                  { %>
                <label>
                    单据状态:
                    <select class="easyui-combobox" id="tdChargeStatus" style="width: 150px;">
                        <option value="1">收费单据</option>
                        <option value="3">付款单据</option>
                        <option value="4">冲抵单据</option>
                        <option value="2">作废单据</option>
                    </select>
                </label>
                <%} %>
                <label class="searchlabel" style="margin-left: 10px;">
                    <a href="javascript:void(0)" onclick="SearchHis()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-search'">搜索</a>
                </label>
            </div>
            <div data-options="region:'center'" title="">
                <table id="his_table">
                </table>
                <div id="tb">
                    <a href="#" onclick="doRemoveAll()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-remove'">彻底删除</a>
                    <a href="#" onclick="openTableSetUp()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-setting'">配置</a>
                </div>
            </div>
        </div>
    </form>
</asp:Content>
