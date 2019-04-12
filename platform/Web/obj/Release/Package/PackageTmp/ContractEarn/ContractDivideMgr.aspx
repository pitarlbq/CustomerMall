<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="ContractDivideMgr.aspx.cs" Inherits="Web.ContractEarn.ContractDivideMgr" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        var ContractID;
        $(function () {
            ContractID = '<%=this.ContractID%>';
        });
    </script>
    <script src="../js/Page/ContractEarn/ContractDivideMgr.js?v=<%=base.getToken() %>" type="text/javascript"></script>
    <style>
        .tdsearch label {
            margin-right: 10px;
        }

        .btn.btn-link {
            padding: 4px !important;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <div class="easyui-layout" fit="true">
        <div data-options="region:'north'" style="height: 60px; padding: 5px 10px;">
            <div class="tdsearch">
                <label>
                    关键字:            
                        <input type="text" class="easyui-searchbox" id="tdKeywords" style="width: 150px;" data-options="prompt:'模糊搜索',searcher:SearchTT" />
                </label>
                <label>
                    账单日期:               
                        <input class="easyui-datebox" id="tdStartTime" style="width: 120px; height: 25px;" />
                    -                    
                        <input class="easyui-datebox" id="tdEndTime" style="width: 120px; height: 25px;" />
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
                <a href="javascript:void(0)" onclick="do_remove()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-remove'">删除</a>
                <a href="javascript:void(0)" onclick="do_active()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-qiyong'">账单生效</a>
            </div>
        </div>
    </div>
</asp:Content>

