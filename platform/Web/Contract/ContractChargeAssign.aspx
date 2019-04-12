<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="ContractChargeAssign.aspx.cs" Inherits="Web.Contract.ContractChargeAssign" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../js/Page/Contract/ContractChargeAssign.js?v=<%=base.getToken() %>"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <div id="cc" class="easyui-layout" fit="true">
        <div data-options="region:'center',border:false" style="width: 400px; border: 1px solid #d0d0d0; border-left: none;">
            <div class="easyui-panel" title="" style="width: 100%; height: 30%;" data-options="border:false">
                <table id="notr" class="easyui-datagrid" data-options="border:false" singleselect="true">
                    <thead>
                        <tr>
                            <th field="Name" width="100%" align="center">收费项目</th>
                        </tr>
                    </thead>
                </table>
                <label id="loadNoRoleFailed"></label>
            </div>
            <div class="easyui-panel" title="" style="width: 100%; height: 12%; border: 1px solid #d0d0d0; border-left: none; border-right: none;" data-options="border:false">
                <div align="center" style="line-height: 50px;">
                    <a href="javascript:void(0)" onclick="leftRole()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-add'">添加费项</a>
                    <a href="javascript:void(0)" onclick="rightRole()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-remove'">移除费项</a>
                </div>
            </div>
            <div class="easyui-panel" title="" style="width: 100%; height: 50%; border: none; border-bottom: 1px solid #d0d0d0;" data-options="border:false">
                <table id="inr" class="easyui-datagrid" singleselect="true" data-options="border:false,">
                    <thead>
                        <tr>
                            <th field="Name" width="100%" align="center">收费项目</th>
                        </tr>
                    </thead>
                </table>
                <label id="loadInRoleFailed"></label>
            </div>
        </div>
        <div data-options="region:'west',border:false" style="width: 70%; border: 1px solid #d0d0d0;">
            <div class="easyui-panel" title="" style="width: 100%; padding: 10px; height: 10%;" data-options="border:false">
                <label>
                    <input class="easyui-searchbox" id="tdKeywords" type="text" data-options="prompt:'合同名称',searcher:doSearchUser" />
                </label>
                <label>
                    <a href="javascript:void(0)" onclick="doSearchUser()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-search'">搜索</a>
                </label>
            </div>
            <div class="easyui-panel" title="" style="width: 100%; height: 90%;" data-options="border:false">
                <table id="dg">
                </table>
                <label id="loadUserFailed"></label>
            </div>
        </div>
    </div>
</asp:Content>
