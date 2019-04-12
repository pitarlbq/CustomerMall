<%@ Page Title="" Language="C#" MasterPageFile="~/Master/NavContent.Master" AutoEventWireup="true" CodeBehind="RelateRoom.aspx.cs" Inherits="Web.Wechat.RelateRoom" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        var ID;
        $(function () {
            ID = "<%=this.ID%>";
        })
        function do_close() {
            parent.do_close_dialog();
        }
    </script>
    <script src="../js/page/Wechat/RelateRoom.js?token=<%=base.getToken() %>"></script>
    <style type="text/css">
        .radioBtn {
            height: 16px;
            vertical-align: middle;
        }

        .checkboxBtn {
            vertical-align: middle;
            margin-right: 2px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <form runat="server" id="form1">
        <div class="easyui-layout" fit="true">
            <div class="op" data-options="region:'north'" style="height: 80px; padding: 40px 5px 5px 5px;">
                <div class="operation_box">
                    <a href="javascript:void(0)" onclick="do_close()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-close'">关闭</a>
                </div>
                <label>
                    关键字:                
                        <input class="easyui-searchbox" id="tdKeyword" runat="server" type="text" data-options="prompt:'关键字搜索          ',searcher:SearchTT" style="width: 200px" />
                </label>
                <label>
                    关联状态:
                <select class="easyui-combobox" id="tdRoomStatus">
                    <option value="1">已关联</option>
                    <option value="0">未关联</option>
                    <option value="">全部</option>
                </select>
                </label>
                <label>
                    <a href="javascript:void(0)" onclick="SearchTT()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-search'">查询</a>
                </label>
            </div>
            <div data-options="region:'center'" title="">
                <table id="tt_table">
                </table>
                <div id="tb">
                    <a href="javascript:void(0)" onclick="connetctRoom()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-add'">关联</a>
                    <a href="javascript:void(0)" onclick="disconnetctRoom()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-remove'">取消关联</a>
                    <a href="javascript:void(0)" onclick="viewQrCode()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-detail'">查看二维码</a>
                </div>
            </div>
        </div>
    </form>
</asp:Content>
