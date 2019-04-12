<%@ Page Title="" Language="C#" MasterPageFile="~/Master/ChequeContent.Master" AutoEventWireup="true" CodeBehind="ChequeCheckMgr.aspx.cs" Inherits="Web.Cheque.ChequeCheckMgr" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../js/Page/Cheque/ChequeCheckMgr.js?t=<%=getToken() %>"></script>
    <script>
        function doExport() {
            var sellerlist = [];
            var productlist = [];
            var departmentlist = [];
            var projectlist = [];
            var keywords = $("#tdKeyword").searchbox("getValue");
            var TakeStatus = $("#tdTakeStatus").combobox("getValue");
            var ApproveStatus = $("#tdApproveStatus").combobox("getValue");
            var TransferStatus = $("#tdTransferStatus").combobox("getValue");
            try {
                sellerlist = GetSelectSeller();
                productlist = GetSelectProduct();
                departmentlist = GetSelectDepartment();
                projectlist = GetSelectProject();
            } catch (e) {

            }
            $("<%=this.hdSellerList.ClientID%>").val(JSON.stringify(sellerlist));
            $("<%=this.hdDepartmentList.ClientID%>").val(JSON.stringify(departmentlist));
            $("<%=this.hdProductList.ClientID%>").val(JSON.stringify(productlist));
            $("<%=this.hdProjectList.ClientID%>").val(JSON.stringify(projectlist));
            $("<%=this.hdKeywords.ClientID%>").val(keywords);
            $("<%=this.hdTakeStatus.ClientID%>").val(TakeStatus);
            $("<%=this.hdApproveStatus.ClientID%>").val(ApproveStatus);
            $("<%=this.hdTransferStatus.ClientID%>").val(TransferStatus);
            $("#<%=this.btnExport.ClientID%>").click();
        }
    </script>
    <style>
        label select {
            width: 150px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <form runat="server">
        <div class="easyui-layout" data-options="fit:true,border:false">
            <div data-options="region:'north',border:false" style="height: 50px; font-size: 12px; padding: 10px;">
                <label>
                    关键字:
                <input class="easyui-searchbox" id="tdKeyword" type="text" data-options="prompt:'关键字搜索',searcher:SearchTT" />
                </label>
                <label>
                    接管状态:
                     <select class="easyui-combobox" id="tdTakeStatus">
                         <option value="">全部</option>
                         <option value="0">未接管</option>
                         <option value="1">已接管</option>
                     </select>
                </label>
                <label>
                    认证状态:
                     <select class="easyui-combobox" id="tdApproveStatus">
                         <option value="">全部</option>
                         <option value="0">未认证</option>
                         <option value="1">已认证</option>
                     </select>
                </label>
                <label>
                    转出状态:
                     <select class="easyui-combobox" id="tdTransferStatus">
                         <option value="">全部</option>
                         <option value="0">未转出</option>
                         <option value="1">已转出</option>
                     </select>
                </label>
                <label class="searchlabel">
                    <a href="javascript:void(0)" onclick="SearchTT()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-search'">搜索</a>
                </label>
            </div>
            <div data-options="region:'center',border:false">
                <table id="tt_table"></table>
                <div id="tt_mm">
                    <a href="javascript:void(0)" onclick="doTakeRow()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-save'">接管</a>
                    <a href="javascript:void(0)" onclick="doApproveRow()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-shenhe'">认证</a>
                    <a href="javascript:void(0)" onclick="doTransferRow()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-paidan'">转出</a>
                    <a href="javascript:void(0)" onclick="openTableSetUp()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-setting'">配置</a>
                    <a href="javascript:void(0)" onclick="doExport()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-export'">导出</a>
                    <asp:HiddenField runat="server" ID="hdSellerList" />
                    <asp:HiddenField runat="server" ID="hdDepartmentList" />
                    <asp:HiddenField runat="server" ID="hdProductList" />
                    <asp:HiddenField runat="server" ID="hdProjectList" />
                    <asp:HiddenField runat="server" ID="hdKeywords" />
                    <asp:HiddenField runat="server" ID="hdTakeStatus" />
                    <asp:HiddenField runat="server" ID="hdApproveStatus" />
                    <asp:HiddenField runat="server" ID="hdTransferStatus" />
                    <asp:Button runat="server" ID="btnExport" Style="display: none" OnClick="btnExport_Click" />
                    <a href="javascript:void(0)" onclick="doImport()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-import'">导入</a>
                </div>
            </div>
        </div>
    </form>
</asp:Content>
