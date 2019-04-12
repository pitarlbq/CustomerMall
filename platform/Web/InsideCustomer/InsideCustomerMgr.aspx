<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="InsideCustomerMgr.aspx.cs" Inherits="Web.InsideCustomer.InsideCustomerMgr" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        var hdIDs, tdCustomerBelonger, tdStartTime, tdEndTime, tdRegion, tdProvince, tdCity, tdCustomerName, tdIndustryName, tdCategory, tdInteresting;
        $(function () {
            hdIDs = $("#<%=this.hdIDs.ClientID%>");
            tdCustomerBelonger = $("#<%=this.tdCustomerBelonger.ClientID%>");
            tdStartTime = $("#<%=this.tdStartTime.ClientID%>");
            tdEndTime = $("#<%=this.tdEndTime.ClientID%>");
            tdRegion = $("#<%=this.tdRegion.ClientID%>");
            tdProvince = $("#<%=this.tdProvince.ClientID%>");
            tdCity = $("#<%=this.tdCity.ClientID%>");
            tdCustomerName = $("#<%=this.tdCustomerName.ClientID%>");
            tdIndustryName = $("#<%=this.tdIndustryName.ClientID%>");
            tdCategory = $("#<%=this.tdCategory.ClientID%>");
            tdInteresting = $("#<%=this.tdInteresting.ClientID%>");
        });
    </script>
    <script src="../js/Page/InsideCustomer/InsideCustomerMgr.js?v=<%=base.getToken() %>" type="text/javascript"></script>
    <style>
        .tdsearch label {
            margin-right: 10px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <form runat="server">
        <input type="hidden" runat="server" id="hdPriceRangeList" />
        <div class="easyui-layout" fit="true">
            <div data-options="region:'north'" style="height: 80px; padding: 10px;">
                <div class="tdsearch">
                    <label>
                        客户所有者:
                        <input class="easyui-searchbox" id="tdCustomerBelonger" runat="server" type="text" data-options="prompt:'客户所有者',searcher:loadTT" style="width: 150px" />
                    </label>
                    <label>
                        跟进日期:
                        <input class="easyui-datebox" id="tdStartTime" runat="server" type="text" style="width: 150px" />
                        -
                        <input class="easyui-datebox" id="tdEndTime" runat="server" type="text" style="width: 150px" />
                    </label>
                    <label>
                        区域:
                        <input class="easyui-combobox" id="tdRegion" runat="server" type="text" data-options="prompt:'区域'" style="width: 150px" />
                    </label>
                    <label>
                        省区:
                        <input class="easyui-searchbox" id="tdProvince" runat="server" type="text" data-options="prompt:'省区',searcher:loadTT" style="width: 150px" />
                    </label>
                    <label>
                        城市:
                        <input class="easyui-searchbox" id="tdCity" runat="server" type="text" data-options="prompt:'城市',searcher:loadTT" style="width: 150px" />
                    </label>
                    <label>
                        客户名称:
                        <input class="easyui-searchbox" id="tdCustomerName" runat="server" type="text" data-options="prompt:'客户名称',searcher:loadTT" style="width: 150px" />
                    </label>
                    <label>
                        行业:
                        <input class="easyui-combobox" id="tdIndustryName" runat="server" type="text" style="width: 150px" />
                    </label>
                    <label>
                        分类:
                        <input class="easyui-combobox" id="tdCategory" runat="server" type="text" data-options="prompt:'分类'" style="width: 150px" />
                    </label>
                    <label>
                        意向分析:
                        <input class="easyui-combobox" id="tdInteresting" runat="server" type="text" data-options="prompt:'意向分析'" style="width: 150px" />
                    </label>
                    <label>
                        <a href="javascript:void(0)" onclick="SearchTT()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-search'">查询</a>
                    </label>
                </div>
            </div>
            <div data-options="region:'center'" title="">
                <table id="tt_table">
                </table>
                <div id="tb">
                    <a href="javascript:void(0)" onclick="doEdit()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-edit'">跟进</a>
                    <a href="javascript:void(0)" onclick="doMoreEdit()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-edit'">批处理</a>
                    <a href="javascript:void(0)" onclick="openImport()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-import'">导入</a>
                    <a href="javascript:void(0)" onclick="do_export()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-export'">导出</a>
                    <asp:HiddenField ID="hdIDs" runat="server" />
                    <a href="javascript:void(0)" onclick="openTableSetUp()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-setting'">配置</a>
                    <a href="javascript:void(0)" onclick="removeFee()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-remove'">删除</a>
                </div>
            </div>
        </div>
    </form>
</asp:Content>
