<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="FeeOrderSearchGrid.aspx.cs" Inherits="Web.Charge.FeeOrderSearchGrid" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../js/Page/Charge/FeeOrderSearchGrid.js?v=<%=base.getToken() %>"></script>
    <script>
        function do_close() {
            parent.do_close_dialog(function () {
                parent.SearchByHistoryIDs();
            });
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <div class="easyui-layout" fit="true">
        <div data-options="region:'north',border:false" style="height: 35px; font-size: 12px; padding: 5px;">
            <a href="javascript:void(0)" onclick="chooserows()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-choose'">选择</a>
            <a href="#" onclick="do_close()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-close'">关闭</a>
        </div>
        <div data-options="region:'center'" title="">
            <table id="his_table">
            </table>
            <div id="tt_mm">
            </div>
        </div>
    </div>
</asp:Content>
