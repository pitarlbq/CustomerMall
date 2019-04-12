<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="MeterProjectPointMgr.aspx.cs" Inherits="Web.GongTan.MeterProjectPointMgr" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        var hdChargeIDList;
        $(function () {
            hdChargeIDList = $('#<%=this.hdChargeIDList.ClientID%>');
        })
        function do_close() {
            parent.do_close_dialog();
        }
    </script>
    <script src="../js/Page/GongTan/MeterProjectPointMgr.js?v=<%=base.getToken() %>" type="text/javascript"></script>
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
            <div data-options="region:'north'" style="height: 90px; padding: 40px 10px 10px 10px;">
                <div class="operation_box">
                    <a href="javascript:void(0)" onclick="do_close()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-close'">关闭</a>
                </div>
                <div class="tdsearch">
                    <label>
                        关键字:                
                        <input class="easyui-searchbox" id="tdKeyword" type="text" data-options="prompt:'仪表名称,仪表编号',searcher:SearchTT" style="width: 200px" />
                    </label>
                    <label>
                        仪表种类:   
                        <select class="easyui-combobox" data-options="editable:false" id="tdMeterCategoryID" style="width: 150px; height: 25px;">
                            <option value="">全部</option>
                            <option value="1">水表</option>
                            <option value="2">电表</option>
                            <option value="3">气表</option>
                        </select>
                    </label>
                    <label>
                        仪表类型:
                        <select class="easyui-combobox" data-options="editable:false" id="tdMeterType" style="width: 150px; height: 25px;">
                            <option value="">全部</option>
                            <option value="2">公共</option>
                            <option value="1">住户</option>
                        </select>
                    </label>
                    <label>
                        收费项目:
                        <input class="easyui-combobox" id="tdChargeName" style="width: 150px; height: 25px;" />
                        <asp:HiddenField runat="server" ID="hdChargeIDList" />
                    </label>
                    <label>
                        <a href="javascript:void(0)" onclick="SearchTT()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-search'">搜索</a>
                    </label>
                </div>
            </div>
            <div data-options="region:'center'" title="">
                <table id="tt_table">
                </table>
            </div>
        </div>
    </form>
</asp:Content>
