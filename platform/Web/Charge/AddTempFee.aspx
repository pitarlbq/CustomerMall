<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="AddTempFee.aspx.cs" Inherits="Web.Charge.AddTempFee" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        var CompanyID, RoomIDs, AddMan, hdChargeDiscount, ContractID, hdPriceRangeList;
        $(function () {
            CompanyID = "<%=Web.WebUtil.GetCompanyID(this.Context)%>";
            RoomIDs = "<%=Request.QueryString["RoomIDs"]%>";
            AddMan = "<%=Web.WebUtil.GetUser(this.Context).RealName%>";
            hdChargeDiscount = $("#<%=this.hdChargeDiscount.ClientID%>");
            ContractID = "<%=Request.QueryString["ContractID"]%>";
            hdPriceRangeList = $("#<%=this.hdPriceRangeList.ClientID%>");
        })
    </script>
    <script src="../js/Page/Charge/AddTempFee.js?v=<%=base.getToken() %>_v1"></script>
    <style>
        .sfdd {
            width: 51px;
            height: 32px;
            background: url("../styles/images/buttons/print.png") no-repeat center center;
            display: block;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <input type="hidden" runat="server" id="hdPriceRangeList" />
    <input type="hidden" runat="server" id="hdChargeDiscount" />
    <div class="easyui-layout" data-options="fit:true,border:false">
        <div data-options="region:'north',border:false" style="height: 35px; font-size: 12px; padding: 5px;">
            <a href="#" onclick="printTempFee()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-print'">收款打印</a>
            <a href="#" onclick="do_close()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-close'">关闭</a>
        </div>
        <div data-options="region:'center'" title="">
            <table id="tt_table">
            </table>
        </div>
    </div>
</asp:Content>
