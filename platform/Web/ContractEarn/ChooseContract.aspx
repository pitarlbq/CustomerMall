<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="ChooseContract.aspx.cs" Inherits="Web.ContractEarn.ChooseContract" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../js/Page/ContractEarn/ChooseContract.js?v=<%=base.getToken() %>" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <form runat="server">
        <div class="easyui-layout" fit="true">
            <asp:HiddenField runat="server" ID="hdContractWarning" />
            <div data-options="region:'north',border:false" style="height: 80px; font-size: 12px; padding: 40px 10px 5px 5px;">
                <div class="operation_box">
                    <a href="javascript:void(0)" onclick="do_choose()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-save'">选择</a>
                    <a href="javascript:void(0)" onclick="do_close()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-close'">关闭</a>
                </div>
                <label>
                    模糊搜索：
                        <input type="text" class="easyui-searchbox" id="tdKeywords" style="width: 150px;" data-options="prompt:'模糊搜索',searcher:SearchTT" />
                </label>
                <label>
                    签约日期：
               <input class="easyui-datebox" id="tdStartTime" style="width: 100px; height: 25px;" />
                    -
                    <input class="easyui-datebox" id="tdEndTime" style="width: 100px; height: 25px;" />
                </label>
                <label>
                    结束日期：
               <input class="easyui-datebox" id="tdRentStartTime" style="width: 100px; height: 25px;" />
                    -
                    <input class="easyui-datebox" id="tdRentEndTime" style="width: 100px; height: 25px;" />
                    <asp:HiddenField runat="server" ID="hdRentEndTime" />
                </label>
                <label>
                    <a href="javascript:void(0)" onclick="SearchTT()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-search'">搜索</a>
                </label>
            </div>
            <div data-options="region:'center'" title="">
                <table id="tt_table">
                </table>
            </div>
        </div>
    </form>
</asp:Content>
