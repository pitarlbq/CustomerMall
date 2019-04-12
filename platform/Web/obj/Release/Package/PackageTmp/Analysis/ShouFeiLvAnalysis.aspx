<%@ Page Title="" Language="C#" MasterPageFile="~/Master/NavContent4.Master" AutoEventWireup="true" CodeBehind="ShouFeiLvAnalysis.aspx.cs" Inherits="Web.Analysis.ShouFeiLvAnalysis" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>收付制</title>
    <script>
        var CompanyID, tdStartTime, tdEndTime, tbChargeSummary, hdChargeSummary, hdProjectIDs, hdRoomIDs, hdRoomType, tdShowType;
        $(function () {
            CompanyID = "<%=Web.WebUtil.GetCompanyID(this.Context)%>";
            tdStartTime = $("#<%=this.tdStartTime.ClientID%>");
            tdEndTime = $("#<%=this.tdEndTime.ClientID%>");
            tbChargeSummary = $("#<%=this.tbChargeSummary.ClientID%>");
            hdChargeSummary = $("#<%=this.hdChargeSummary.ClientID%>");
            tdStartTime = $("#<%=this.tdStartTime.ClientID%>");
            hdProjectIDs = $("#<%=this.hdProjectIDs.ClientID%>");
            hdRoomIDs = $("#<%=this.hdRoomIDs.ClientID%>");
            hdRoomType = $("#<%=this.hdRoomType.ClientID%>");
            tdShowType = $("#<%=this.tdShowType.ClientID%>");
        })
    </script>
    <script src="../js/Page/Analysis/ShouFeiLvAnalysis.js?t=<%=base.getToken() %>"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <form runat="server" id="ff">
        <div id="layout" class="easyui-layout" fit="true">
            <div data-options="region:'north',split:false,hideCollapsedContent:false," title="" style="height: 50px; padding: 5px 10px;">
                <label>
                    计费周期:
                    <input class="easyui-datebox" id="tdStartTime" runat="server" style="width: 120px; height: 25px;" />
                    -
                    <input class="easyui-datebox" id="tdEndTime" runat="server" style="width: 120px; height: 25px;" />
                </label>
                <label>
                    收费项目:   
                        <input class="easyui-combobox" id="tbChargeSummary" style="width: 120px; height: 25px;" runat="server" />
                    <asp:HiddenField runat="server" ID="hdChargeSummary" />
                    <asp:HiddenField runat="server" ID="hdProjectIDs" />
                    <asp:HiddenField runat="server" ID="hdRoomIDs" />
                    <asp:HiddenField runat="server" ID="hdRoomType" />
                </label>
                <label>
                    <select class="easyui-combobox" id="tdShowType" style="width: 100px; height: 25px;" runat="server">
                        <option value="0">显示欠费</option>
                        <option value="1">显示全部</option>
                    </select>
                </label>
                <label>
                    <a href="#" onclick="SearchFee()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-search'">搜索</a>
                </label>
                <label style="margin-right: 10px; line-height: 25px;">
                    <input type="radio" name="tabletype" value="Room" />资源明细
                </label>
                <label style="margin-right: 10px;">
                    <input type="radio" name="tabletype" value="Project" checked="checked" />项目汇总
                </label>
                <label>
                    <input type="radio" name="tabletype" value="ChargeSummary" />费项明细
                </label>
            </div>
            <div data-options="region:'center'" title="">
                <table id="fee_table"></table>
                <div id="tbfee">
                    <a href="#" onclick="do_export()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-export'">导出</a>
                </div>
            </div>
        </div>
    </form>
</asp:Content>
