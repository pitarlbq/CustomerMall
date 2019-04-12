<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="ChooseCoupon.aspx.cs" Inherits="Web.Mall.ChooseCoupon" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        var singleselect, from;
        $(function () {
            singleselect = "<%=this.singleselect%>";
            from = "<%=this.from%>";
        })
    </script>
    <script src="../js/Page/Mall/CouponCode/ChooseCoupon.js?v=<%=base.getToken()%>"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <div class="easyui-layout" data-options="fit:true,border:false">
        <div data-options="region:'north',border:false" style="height: 50px; font-size: 12px; padding: 5px 10px;">
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
            <div id="tt_mm">
                <a href="javascript:void(0)" onclick="do_choose()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-choose'">选择</a>
            </div>
        </div>
    </div>
</asp:Content>
