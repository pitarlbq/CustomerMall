<%@ Page Title="" Language="C#" MasterPageFile="~/Master/NavContent4.Master" AutoEventWireup="true" CodeBehind="DoorDeviceMgr.aspx.cs" Inherits="Web.APPSetup.DoorDeviceMgr" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        var CanRemoteOpen = 0;
        $(function () {
            CanRemoteOpen = Number("<%=this.CanRemoteOpen%>");
        })
    </script>
    <script src="../js/Page/APPSetup/DoorDeviceMgr.js?v=<%=base.getToken() %>"></script>
    <style>
        .searcharea label {
            padding: 0px 5px;
        }

        .device_status {
            display: inline-block;
            padding: 2px 4px;
            font-size: 12px;
            font-weight: bold;
            line-height: 14px;
            color: #fff;
            vertical-align: middle;
            border-radius: 3px;
            margin-bottom: 0;
        }

            .device_status.online {
                background-color: #5eb95e;
            }

            .device_status.offline {
                background-color: #ddd;
            }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <div class="easyui-layout" data-options="fit:true,border:false">
        <div class="searcharea" data-options="region:'north',border:false" style="height: 50px; font-size: 12px; padding: 10px 0px 0px 10px;">
            <label>
                关键字:
                <input class="easyui-searchbox" id="tdKeyword" type="text" data-options="prompt:'关键字搜索',searcher:SearchTT" />
            </label>
            <label class="searchlabel">
                <a href="javascript:void(0)" onclick="SearchTT()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-search'">搜索</a>
            </label>
        </div>
        <div data-options="region:'center',border:false">
            <table id="tt_table"></table>
            <div id="tt_mm">
                <%if (base.CheckAuthByModuleCode("1101392"))
                  { %>
                <a href="javascript:void(0)" onclick="do_add()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-add'">新增</a>
                <%} %>
                <%if (base.CheckAuthByModuleCode("1101393"))
                  { %>
                <a href="javascript:void(0)" onclick="do_edit()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-edit'">修改</a>
                <%} %>
                <%if (base.CheckAuthByModuleCode("1101394"))
                  { %>
                <a href="javascript:void(0)" onclick="do_remove()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-remove'">删除</a>
                <%} %>
            </div>
        </div>
    </div>
</asp:Content>
