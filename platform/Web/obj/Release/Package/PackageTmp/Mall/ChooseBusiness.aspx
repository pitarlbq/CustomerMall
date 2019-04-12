<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="ChooseBusiness.aspx.cs" Inherits="Web.Mall.ChooseBusiness" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        var singleselect, usetype, from;
        $(function () {
            singleselect = "<%=this.singleselect%>";
            usetype = "<%=this.usetype%>";
            from = "<%=this.from%>";
        })
    </script>
    <script src="../js/Page/Mall/Business/ChooseBusiness.js?v=<%=base.getToken()%>"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <div class="easyui-layout" data-options="fit:true,border:false">
        <div data-options="region:'north',border:false" style="height: 80px; font-size: 12px; padding: 40px 10px 5px 5px;">
            <div class="operation_box">
                <a href="javascript:void(0)" onclick="do_choose()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-save'">选择</a>
                <a href="javascript:void(0)" onclick="do_close()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-close'">关闭</a>
            </div>
            <label>
                关键字: 
                <input class="easyui-searchbox" style="width: 200px;" id="tdKeyword" type="text" data-options="prompt:'门店名称',searcher:SearchTT" />
            </label>
            <label class="searchlabel">
                <a href="javascript:void(0)" onclick="SearchTT()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-search'">搜索</a>
            </label>
        </div>
        <div data-options="region:'center',border:false">
            <table id="tt_table"></table>
        </div>
    </div>
</asp:Content>
