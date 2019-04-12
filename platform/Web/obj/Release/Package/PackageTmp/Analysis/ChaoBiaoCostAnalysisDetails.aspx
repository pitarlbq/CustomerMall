<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="ChaoBiaoCostAnalysisDetails.aspx.cs" Inherits="Web.Analysis.ChaoBiaoCostAnalysisDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        var tbChargeID, CompanyID, tbChargeStatus, StartWriteDate, EndWriteDate, ChargeSummaryList, hdProjectID, hdRoomIDs, tdKeyword, hdIDs, BiaoCategory;
        $(function () {
            tbChargeID = $("#<%=this.tbChargeID.ClientID%>");
            tbChargeStatus = $("#<%=this.tbChargeStatus.ClientID%>");
            StartWriteDate = $("#<%=this.tdStartWriteDate.ClientID%>");
            EndWriteDate = $("#<%=this.tdEndWriteDate.ClientID%>");
            CompanyID = "<%=Web.WebUtil.GetCompanyID(this.Context)%>";
            hdProjectID = $("#<%=this.hdProjectID.ClientID%>");
            hdRoomIDs = $("#<%=this.hdRoomIDs.ClientID%>");
            tdKeyword = $("#<%=this.tdKeyword.ClientID%>");
            hdIDs = $("#<%=this.hdIDs.ClientID%>");
            BiaoCategory = $("#<%=this.tdBiaoCategory.ClientID%>");
        });
    </script>
    <script src="../js/Page/Analysis/ChaoBiaoCostAnalysisDetails.js?v=<%=base.getToken() %>" type="text/javascript"></script>
    <style>
        .tdsearch label {
            margin-right: 10px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <form runat="server">
        <div class="easyui-layout" fit="true">
            <div data-options="region:'north'" style="height: 80px; padding: 10px;">
                <div class="tdsearch">
                    <label>
                        关键字:                
                        <input class="easyui-searchbox" id="tdKeyword" runat="server" type="text" data-options="prompt:'关键字搜索',searcher:SearchTT" style="width: 200px" />
                    </label>
                    <label>
                        收费项目:   
                        <input class="easyui-combobox" runat="server" id="tbChargeID" style="width: 150px; height: 25px;" />
                    </label>
                    <label>
                        收费状态：
                <select class="easyui-combobox" runat="server" id="tbChargeStatus" style="width: 100px; height: 25px;">
                    <option value="99">全部</option>
                    <%--<option value="2">草稿</option>--%>
                    <option value="0">未收</option>
                    <option value="1">已收</option>
                </select>
                    </label>
                    <label>
                        账单日期：
               <input class="easyui-datebox" runat="server" id="tdStartWriteDate" style="width: 100px; height: 25px;" />
                        -
                    <input class="easyui-datebox" runat="server" id="tdEndWriteDate" style="width: 100px; height: 25px;" />
                    </label>
                    <label>
                        表种类：
               <input class="easyui-searchbox" id="tdBiaoCategory" runat="server" type="text" data-options="prompt:'表种类          ',searcher:SearchTT" style="width: 200px" />
                    </label>
                    <label>
                        <a href="#" onclick="SearchTT()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-search'">搜索</a>
                    </label>
                </div>
            </div>
            <div data-options="region:'center'" title="">
                <table id="tt_table">
                </table>
                <div id="tb">
                    <a href="#" onclick="do_export()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-export'">导出</a>
                    <asp:HiddenField ID="hdProjectID" runat="server" />
                    <asp:HiddenField ID="hdRoomIDs" runat="server" />
                    <asp:HiddenField ID="hdIDs" runat="server" />
                </div>
            </div>
        </div>
    </form>
</asp:Content>

