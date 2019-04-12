<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="ChargeFeePreChargeAllHistory.aspx.cs" Inherits="Web.Charge.ChargeFeePreChargeAllHistory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        var CompanyID, tdStartTime, tdEndTime, tdChargeSummary;
        $(function () {
            CompanyID = "<%=Web.WebUtil.GetCompanyID(this.Context)%>";
            tdStartTime = $('#<%=this.tdStartTime.ClientID%>');
            tdEndTime = $('#<%=this.tdEndTime.ClientID%>');
            tdChargeSummary = $('#<%=this.tdChargeSummary.ClientID%>');
            tdChargeStatus = $('#<%=this.tdChargeStatus.ClientID%>');
        })
    </script>
    <script src="../js/Lodop/LodopFuncs.js?t=<%=base.getToken() %>"></script>
    <script src="../js/Page/Charge/ChargeFeePreChargeAllHistory.js?t=<%=base.getToken() %>"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <form runat="server" id="ff">
        <div id="layout" class="easyui-layout" fit="true">
            <div data-options="region:'north',split:false,hideCollapsedContent:false," title="" style="height: 50px; padding: 5px 10px;">
                <label>
                    冲抵时间:                
                    <input class="easyui-datebox" id="tdStartTime" runat="server" />
                    -                
                    <input class="easyui-datebox" id="tdEndTime" runat="server" />
                </label>
                <label>
                    收费项目:    
                    <input class="easyui-combobox" runat="server" id="tdChargeSummary" style="width: 150px;" />
                    <asp:HiddenField ID="hdChargeSummary" runat="server" />
                </label>
                <label>
                    单据类型:               
                    <select class="easyui-combobox" runat="server" id="tdChargeStatus" style="width: 150px;">
                        <option value="2">冲抵单据</option>
                        <option value="4">作废单据</option>
                    </select>
                </label>
                <label class="searchlabel">
                    <a href="#" onclick="SearchHis()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-search'">搜索</a>
                </label>
            </div>
            <div data-options="region:'center'" title="">
                <table id="his_table">
                </table>
                <div id="tb">
                    <a href="javascript:void(0)" onclick="printHistoryChargeFee()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-print'">补打单据</a>
                    <a href="javascript:void(0)" onclick="cancelHistoryChargeFee()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-zuofei'">作废单据</a>
                </div>
            </div>
        </div>
        <iframe name="myiframe" id="myframe" style="display: none;" src="" width="100%" height="100%"></iframe>
    </form>
</asp:Content>
