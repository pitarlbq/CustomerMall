<%@ Page Title="" Language="C#" MasterPageFile="~/Master/ChequeContent.Master" AutoEventWireup="true" CodeBehind="ChequeInMgr.aspx.cs" Inherits="Web.Cheque.ChequeInMgr" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../js/Page/Cheque/ChequeInMgr.js?t=<%=getToken() %>"></script>
    <script>
        function doExport() {
            var sellerlist = [];
            var productlist = [];
            var departmentlist = [];
            var projectlist = [];
            var keywords = $("#tdKeyword").searchbox("getValue");
            try {
                sellerlist = GetSelectSeller();
                productlist = GetSelectProduct();
                departmentlist = GetSelectDepartment();
                projectlist = GetSelectProject();
            } catch (e) {

            }
            var StartTime = $('#tdStartTime').datebox('getValue');
            var EndTime = $('#tdEndTime').datebox('getValue');
            var ChequeNo = $('#tdChequeNo').textbox('getValue');
            $("<%=this.hdSellerList.ClientID%>").val(JSON.stringify(sellerlist));
            $("<%=this.hdDepartmentList.ClientID%>").val(JSON.stringify(departmentlist));
            $("<%=this.hdProductList.ClientID%>").val(JSON.stringify(productlist));
            $("<%=this.hdProjectList.ClientID%>").val(JSON.stringify(projectlist));
            $("<%=this.hdKeywords.ClientID%>").val(keywords);
            $("<%=this.hdStartTime.ClientID%>").val(StartTime);
            $("<%=this.hdEndTime.ClientID%>").val(EndTime);
            $("<%=this.hdChequeCode.ClientID%>").val(ChequeNo);
            $("#<%=this.btnExport.ClientID%>").click();
        }
        function openSearchbox() {
            $('#win_Search').window({
                collapsible: false,
                minimizable: false,
                maximizable: false
            });
            $('#win_Search').window('open');
        }
        function closeSearchwin() {
            $('#win_Search').window('close');
        };
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <form runat="server">
        <div class="easyui-layout" data-options="fit:true,border:false">
            <div data-options="region:'north',border:false" style="height: 50px; font-size: 12px; padding: 10px;">
                <label>
                    关键字:
                <input class="easyui-searchbox" id="tdKeyword" type="text" data-options="prompt:'关键字搜索',searcher:SearchTT" />
                </label>
                <label class="searchlabel">
                    <a href="javascript:void(0)" onclick="SearchTT()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-search'">搜索</a>
                </label>
                <label style="padding-left: 15px;">
                    <a href="javascript:void(0)" onclick="openSearchbox()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-search'">筛选条件</a>
                </label>
            </div>
            <div id="win_Search" class="easyui-window" data-options="title:'选择筛选条件',closed:true" style="width: 600px; height: 300px; padding: 10px">
                <table style="width: 100%; border-collapse: collapse; border-spacing: 0;">
                    <tr>
                        <td style="width: 15%; text-align: right; padding: 5px 10px;">开票时间</td>
                        <td style="width: 85%; text-align: left; padding: 5px 10px;" colspan="3">
                            <input class="easyui-datebox" type="text" id="tdStartTime" />
                            -
                            <input class="easyui-datebox" type="text" id="tdEndTime" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 15%; text-align: right; padding: 5px 10px;">发票代码</td>
                        <td style="width: 85%; text-align: left; padding: 5px 10px;" colspan="3">
                            <input class="easyui-textbox" type="text" id="tdChequeNo" /></td>
                    </tr>
                    <tr>
                        <td colspan="4" style="text-align: center;">
                            <a href="javascript:void(0)" onclick="SearchTT()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-search'">查询</a>
                        </td>
                    </tr>
                </table>
            </div>
            <div data-options="region:'center',border:false">
                <table id="tt_table"></table>
                <div id="tt_mm">
                    <a href="javascript:void(0)" onclick="addRow()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-add'">登记</a>
                    <a href="javascript:void(0)" onclick="doSign()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-save'">签收</a>
                    <a href="javascript:void(0)" onclick="doApprove()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-shenhe'">审核</a>
                    <a href="javascript:void(0)" onclick="editRow()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-edit'">修改</a>
                    <a href="javascript:void(0)" onclick="removeRows()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-remove'">删除</a>
                    <a href="javascript:void(0)" onclick="openTableSetUp()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-setting'">配置</a>
                    <a href="javascript:void(0)" onclick="doExport()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-export'">导出</a>
                    <a href="javascript:void(0)" onclick="doImport()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-import'">导入</a>
                    <asp:HiddenField runat="server" ID="hdSellerList" />
                    <asp:HiddenField runat="server" ID="hdDepartmentList" />
                    <asp:HiddenField runat="server" ID="hdProductList" />
                    <asp:HiddenField runat="server" ID="hdProjectList" />
                    <asp:HiddenField runat="server" ID="hdKeywords" />
                    <asp:HiddenField runat="server" ID="hdStartTime" />
                    <asp:HiddenField runat="server" ID="hdEndTime" />
                    <asp:HiddenField runat="server" ID="hdChequeCode" />
                    <asp:Button runat="server" ID="btnExport" Style="display: none" OnClick="btnExport_Click" />
                </div>
            </div>
        </div>
    </form>
</asp:Content>
