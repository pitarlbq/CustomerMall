<%@ Page Title="" Language="C#" MasterPageFile="~/Master/CKContent.Master" AutoEventWireup="true" CodeBehind="MaterialLingYongAnalysis.aspx.cs" Inherits="Web.CangKu.MaterialLingYongAnalysis" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../js/Page/CangKu/CKMaterialLingYongAnalysis.js?v=<%=base.getToken() %>"></script>
    <script>
        var tdStartTime, tdEndTime, tdKeyword, hdTreeID;
        $(function () {
            tdStartTime = $('#<%=this.tdStartTime.ClientID%>');
            tdEndTime = $('#<%=this.tdEndTime.ClientID%>');
            tdKeyword = $('#<%=this.tdKeyword.ClientID%>');
            hdTreeID = $('#<%=this.hdTreeID.ClientID%>');
        })
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <form runat="server">
        <div class="easyui-layout" data-options="fit:true,border:false">
            <div data-options="region:'north',border:false" style="height: 50px; font-size: 12px; padding: 5px 10px;">
                <label>
                    关键字:               
                    <input class="easyui-searchbox" runat="server" id="tdKeyword" type="text" data-options="prompt:'关键字搜索',searcher:SearchTT" />
                </label>
                <label>
                    日期:
                     <input class="easyui-datebox" runat="server" id="tdStartTime" type="text" style="width: 120px;" />
                    -
                     <input class="easyui-datebox" runat="server" id="tdEndTime" type="text" style="width: 120px;" />
                </label>
                <label class="searchlabel">
                    <a href="javascript:void(0)" onclick="SearchTT()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-search'">搜索</a>
                </label>
            </div>
            <div data-options="region:'center',border:false">
                <table id="tt_table">
                </table>
                <div id="tb">
                    <a href="javascript:void(0)" onclick="do_export()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-export'">导出</a>
                    <asp:HiddenField ID="hdTreeID" runat="server" />
                </div>
            </div>
        </div>
    </form>
</asp:Content>
