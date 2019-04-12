<%@ Page Title="" Language="C#" MasterPageFile="~/Master/ChequeContent.Master" AutoEventWireup="true" CodeBehind="ChequeInOutAnalysis.aspx.cs" Inherits="Web.Cheque.ChequeInOutAnalysis" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../js/Page/Cheque/ChequeInOutAnalysis.js?t=<%=getToken() %>"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <form runat="server">
        <div class="easyui-layout" data-options="fit:true,border:false">
            <div data-options="region:'north',border:false" style="height: 50px; font-size: 12px; padding: 10px;">
                <label>
                    发票日期:
               <input class="easyui-datebox" type="text" id="tdStartTime" />
                    -
                            <input class="easyui-datebox" type="text" id="tdEndTime" />
                </label>
                <label>
                    发票类型:
                    <select class="easyui-combobox" id="tdType">
                        <option value="1">按部门</option>
                        <option value="2">按项目</option>
                    </select>
                </label>
                <label class="searchlabel">
                    <a href="javascript:void(0)" onclick="SearchTT()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-search'">搜索</a>
                </label>
            </div>
            <div data-options="region:'center',border:false">
                <table id="tt_table"></table>
            </div>
        </div>
    </form>
</asp:Content>
