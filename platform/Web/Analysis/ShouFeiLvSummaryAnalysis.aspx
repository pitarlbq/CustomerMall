<%@ Page Title="" Language="C#" MasterPageFile="~/Master/NavContent4.Master" AutoEventWireup="true" CodeBehind="ShouFeiLvSummaryAnalysis.aspx.cs" Inherits="Web.Analysis.ShouFeiLvSummaryAnalysis" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>收款情况表</title>
    <script>
        var CompanyID, tdStartTime, tdEndTime, hdProjectIDs, hdRoomIDs, hdRoomType;
        $(function () {
            CompanyID = "<%=Web.WebUtil.GetCompanyID(this.Context)%>";
            tdStartTime = $("#<%=this.tdStartTime.ClientID%>");
            tdEndTime = $("#<%=this.tdEndTime.ClientID%>");
            tdFeeStartTime = $("#<%=this.tdFeeStartTime.ClientID%>");
            tdFeeEndTime = $("#<%=this.tdFeeEndTime.ClientID%>");
            hdRoomType = $("#<%=this.hdRoomType.ClientID%>");
            hdRoomIDs = $("#<%=this.hdRoomIDs.ClientID%>");
            hdProjectIDs = $("#<%=this.hdProjectIDs.ClientID%>");
        })
    </script>
    <script src="../js/Page/Analysis/ShouFeiLvSummaryAnalysis.js?t=<%=base.getToken() %>"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <form runat="server" id="ff">
        <div id="layout" class="easyui-layout" fit="true">
            <div data-options="region:'north',split:false,hideCollapsedContent:false," title="" style="height: 50px; padding: 5px 10px;">
                <label>
                    费用日期:
                    <input class="easyui-datebox" id="tdStartTime" runat="server" style="width: 120px; height: 25px;" />
                    -
                    <input class="easyui-datebox" id="tdEndTime" runat="server" style="width: 120px; height: 25px;" />
                </label>
                <label style="display: none;">
                    收款日期:
                    <input class="easyui-datebox" id="tdFeeStartTime" runat="server" style="width: 120px; height: 25px;" />
                    -
                    <input class="easyui-datebox" id="tdFeeEndTime" runat="server" style="width: 120px; height: 25px;" />
                </label>
                <label>
                    <a href="#" onclick="SearchFee()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-search'">搜索</a>
                </label>
                <%-- <label style="margin: 0 10px; line-height: 25px;">
                    <input type="radio" name="tabletype" value="Room" />资源明细
                </label>
                <label style="margin-right: 10px;">
                    <input type="radio" name="tabletype" value="Project" checked="checked" />项目汇总
                </label>--%>
            </div>
            <div data-options="region:'center'" title="">
                <table id="fee_table"></table>
                <div id="tbfee">
                    <a href="#" onclick="openSetting()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-setting'">配置</a>
                    <a href="#" onclick="do_export()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-export'">导出</a>
                    <asp:HiddenField runat="server" ID="hdRoomIDs" />
                    <asp:HiddenField runat="server" ID="hdProjectIDs" />
                    <asp:HiddenField runat="server" ID="hdRoomType" />
                </div>
            </div>
        </div>
    </form>
</asp:Content>
