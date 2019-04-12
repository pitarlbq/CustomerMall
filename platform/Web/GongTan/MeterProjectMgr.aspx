<%@ Page Title="" Language="C#" MasterPageFile="~/Master/NavContent4.Master" AutoEventWireup="true" CodeBehind="MeterProjectMgr.aspx.cs" Inherits="Web.GongTan.MeterProjectMgr" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        var hdChargeIDList;
        $(function () {
            hdChargeIDList = $('#<%=this.hdChargeIDList.ClientID%>');
        })
    </script>
    <script src="../js/Page/GongTan/MeterProjectMgr.js?v=<%=base.getToken() %>" type="text/javascript"></script>
    <style>
        .tdsearch label {
            margin-right: 10px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <form runat="server">
        <div class="easyui-layout" fit="true">
            <div data-options="region:'north'" style="height: 60px; padding: 10px;">
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
                    <label style="display: none;">
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
                <div id="tb">
                    <a href="javascript:void(0)" onclick="check_start_status(0)" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-chaobiao'">开始抄表</a>
                    <a href="javascript:void(0)" onclick="do_finish_write()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-chaobiao'">完成抄表</a>
                    <a href="javascript:void(0)" onclick="do_start_write(1)" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-qiyong'">启动APP抄表</a>
                    <a href="javascript:void(0)" onclick="do_stop_app_write()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-tingyong'">停止APP抄表</a>
                    <a href="javascript:void(0)" onclick="do_create_fee()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-save'">生成账单</a>
                    <a href="javascript:void(0)" onclick="do_export()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-export'">导出</a>
                    <a href="javascript:void(0)" onclick="do_import()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-import'">导入</a>
                </div>
            </div>
        </div>
    </form>
</asp:Content>
