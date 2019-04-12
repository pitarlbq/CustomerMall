<%@ Page Title="" Language="C#" MasterPageFile="~/Master/NavContent4.Master" AutoEventWireup="true" CodeBehind="MeterProjectFeeMgr.aspx.cs" Inherits="Web.GongTan.MeterProjectFeeMgr" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        var hdChargeIDList;
        $(function () {
            hdChargeIDList = $('#<%=this.hdChargeIDList.ClientID%>');
        })
    </script>
    <script src="../js/Page/GongTan/MeterProjectFeeMgr.js?v=<%=base.getToken() %>" type="text/javascript"></script>
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
            <div data-options="region:'north'" style="height: 90px; padding: 10px;">
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
                        收费状态:
                        <select class="easyui-combobox" data-options="editable:false" id="tdChargeState" style="width: 150px; height: 25px;">
                            <option value="">全部</option>
                            <option value="1">已收</option>
                            <option value="2">未收</option>
                            <option value="3">已作废</option>
                            <option value="4">催收中</option>
                        </select>
                    </label>
                    <label>
                        <a href="javascript:void(0)" onclick="SearchTT()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-search'">搜索</a>
                    </label>
                </div>
            </div>
            <div data-options="region:'center'" title="">
                <table id="tt_table">
                </table>
                <div id="tb">
                    <a href="javascript:void(0)" onclick="batchEditTime()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-chuli'">批处理</a>
                    <a href="javascript:void(0)" onclick="do_remove()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-chaobiao'">删除</a>
                </div>
            </div>
        </div>
    </form>
</asp:Content>
