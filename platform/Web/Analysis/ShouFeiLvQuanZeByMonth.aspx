<%@ Page Title="" Language="C#" MasterPageFile="~/Master/NavContent4.Master" AutoEventWireup="true" CodeBehind="ShouFeiLvQuanZeByMonth.aspx.cs" Inherits="Web.Analysis.ShouFeiLvQuanZeByMonth" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>收入分析表</title>
    <script>
        var CompanyID, tdStartTime, tdEndTime, tdChargeSummary, hdChargeSummary, hdRoomType, hdProjectIDs, hdRoomIDs;
        $(function () {
            CompanyID = "<%=Web.WebUtil.GetCompanyID(this.Context)%>";
            tdStartTime = $('#<%=this.tdStartTime.ClientID%>');
            tdEndTime = $('#<%=this.tdEndTime.ClientID%>');
            tdChargeSummary = $('#<%=this.tdChargeSummary.ClientID%>');
            hdChargeSummary = $('#<%=this.hdChargeSummary.ClientID%>');
            hdRoomType = $('#<%=this.hdRoomType.ClientID%>');
            hdProjectIDs = $('#<%=this.hdProjectIDs.ClientID%>');
            hdRoomIDs = $('#<%=this.hdRoomIDs.ClientID%>');
        })
    </script>
    <script src="../js/Page/Analysis/ShouFeiLvQuanZeByMonth.js?t=<%=base.getToken() %>"></script>
    <style>
        .layout-panel-north label.radioLabel {
            padding-left: 16px;
        }

        .layout-panel-north label input[type=radio] {
            position: absolute;
            left: 0;
            top: 50%;
            margin: -7px 0 0 0;
            height: 15px;
            width: 15px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <form runat="server">
        <div id="layout" class="easyui-layout" fit="true">
            <div data-options="region:'north',hideCollapsedContent:false," title="" style="height: 60px; padding: 5px 10px;">
                <label>
                    日期: 
                    <input class="easyui-datebox" id="tdStartTime" runat="server" style="width: 120px; height: 28px;" />
                    -   
                    <input class="easyui-datebox" id="tdEndTime" runat="server" style="width: 120px; height: 28px;" />
                </label>
                <label>
                    收费项目:   
                    <input class="easyui-combobox" id="tdChargeSummary" runat="server" style="width: 120px; height: 28px;" />
                    <asp:HiddenField runat="server" ID="hdProjectIDs" />
                    <asp:HiddenField runat="server" ID="hdRoomIDs" />
                    <asp:HiddenField runat="server" ID="hdChargeSummary" />
                </label>
                <label>
                    <a href="#" onclick="SearchFee()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-search'">搜索</a>
                </label>
                <label class="radioLabel">
                    <input type="radio" name="tabletype" value="Room" checked="checked" />资源明细
                </label>
                <label class="radioLabel">
                    <input type="radio" name="tabletype" value="Project" checked="checked" />项目汇总
                </label>
                <label class="radioLabel">
                    <input type="radio" name="tabletype" value="ChargeType" />收款方式汇总
                </label>
                <asp:HiddenField runat="server" ID="hdRoomType" Value="Project" />
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
