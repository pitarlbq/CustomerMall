<%@ Page Title="" Language="C#" MasterPageFile="~/Master/NavContent4.Master" AutoEventWireup="true" CodeBehind="RealCostMingXiAnalysis.aspx.cs" Inherits="Web.Analysis.RealCostMingXiAnalysis" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        var CompanyID, tdStartTime, tdEndTime, hdProjectIDs, hdRoomIDs, hdRoomType, tdFeeStartTime, tdFeeEndTime;
        $(function () {
            CompanyID = "<%=Web.WebUtil.GetCompanyID(this.Context)%>";
            tdFeeStartTime = $("#<%=this.tdFeeStartTime.ClientID%>");
            tdFeeEndTime = $("#<%=this.tdFeeEndTime.ClientID%>");
            hdRoomType = $("#<%=this.hdRoomType.ClientID%>");
            hdRoomIDs = $("#<%=this.hdRoomIDs.ClientID%>");
            hdProjectIDs = $("#<%=this.hdProjectIDs.ClientID%>");
        })
        function doExport() {
            var RoomIDs = GetSelectedRooms();
            var ProjectIDs = GetSelectedProjects();
            hdRoomIDs.val(JSON.stringify(RoomIDs));
            hdProjectIDs.val(JSON.stringify(ProjectIDs));
            $('#<%=this.btnExport.ClientID%>').click();
        }
    </script>
    <script src="../js/Page/Analysis/RealCostMingXiAnalysis.js?t=<%=base.getToken() %>"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <form runat="server" id="ff">
        <div id="layout" class="easyui-layout" fit="true">
            <div data-options="region:'north',split:false,hideCollapsedContent:false," title="" style="height: 50px; padding: 5px 10px;">
                <label>
                    收款日期:
                    <input class="easyui-datebox" id="tdFeeStartTime" runat="server" style="width: 120px; height: 25px;" />
                    -
                    <input class="easyui-datebox" id="tdFeeEndTime" runat="server" style="width: 120px; height: 25px;" />
                </label>
                <label>
                    <a href="#" onclick="SearchFee()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-search'">搜索</a>
                </label>
            </div>
            <div data-options="region:'center'" title="">
                <table id="fee_table"></table>
                <div id="tbfee">
                    <a href="#" onclick="openSetting()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-setting'">配置</a>
                    <a href="#" onclick="doExport()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-export'">导出</a>
                    <asp:Button runat="server" ID="btnExport" Style="display: none;" OnClick="btnExport_Click" />
                    <asp:HiddenField runat="server" ID="hdRoomIDs" />
                    <asp:HiddenField runat="server" ID="hdProjectIDs" />
                    <asp:HiddenField runat="server" ID="hdRoomType" />
                </div>
            </div>
        </div>
    </form>
</asp:Content>
