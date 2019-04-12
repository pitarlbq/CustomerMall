<%@ Page Title="" Language="C#" MasterPageFile="~/Master/NavContent4.Master" AutoEventWireup="true" CodeBehind="ContractEarnMgr.aspx.cs" Inherits="Web.ContractEarn.ContractEarnMgr" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <script>
         var GetContextPath;
         $(function () {
             GetContextPath = "<%=base.GetContextPath() %>";
        })
    </script>
    <script src="../js/Page/ContractEarn/ContractEarnMgr.js?v=<%=base.getToken() %>" type="text/javascript"></script>
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
                    关键字
                        <input type="text" class="easyui-searchbox" id="tdKeywords" style="width: 150px;" data-options="prompt:'模糊搜索',searcher:SearchTT" />
                </label>
                <label>
                    签约日期               
                    <input class="easyui-datebox" id="tdStartTime" style="width: 100px; height: 25px;" />
                    -
                    <input class="easyui-datebox" id="tdEndTime" style="width: 100px; height: 25px;" />
                </label>
                <label>
                    结束日期               
                    <input class="easyui-datebox" id="tdRentStartTime" style="width: 100px; height: 25px;" />
                    -
                    <input class="easyui-datebox" id="tdRentEndTime" style="width: 100px; height: 25px;" />
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
                <a href="javascript:void(0)" onclick="do_create()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-add'">生成应收账单</a>
                <a href="javascript:void(0)" onclick="do_process()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-edit'">批处理</a>
                <a href="javascript:void(0)" onclick="do_view()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-detail'">查看应收账单</a>
            </div>
        </div>
    </div>
</asp:Content>
