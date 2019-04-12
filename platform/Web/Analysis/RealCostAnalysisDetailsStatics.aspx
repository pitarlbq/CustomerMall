<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="RealCostAnalysisDetailsStatics.aspx.cs" Inherits="Web.Analysis.RealCostAnalysisDetailsStatics" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        var CompanyID, hdIDs, StartTime, EndTime, op = '';
        $(function () {
            CompanyID = "<%=Web.WebUtil.GetCompanyID(this.Context)%>";
            hdIDs = $("#<%=this.hdIDs.ClientID%>");
            StartTime = "<%=this.StartTime%>";
            EndTime = "<%=this.EndTime%>";
            op = "<%=this.op%>";
            if (op == 'view') {
                setTimeout(function () {
                    $("#main_form_layout").layout('panel', 'north').panel("options").height = 80;
                    $("#main_form_layout").layout("resize");
                    $('.operation_box').show();
                }, 100);
            }
        })
        function do_close() {
            parent.do_close_dialog()
        }
    </script>
    <script src="../js/Lodop/LodopFuncs.js?t=<%=base.getToken() %>"></script>
    <script src="../js/Page/Analysis/RealCostAnalysisDetailsStatics.js?t=<%=base.getToken()%>"></script>
    <style>
        .operation_box {
            position: relative;
            text-align: right;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <form runat="server">
        <div id="main_form_layout" class="easyui-layout" fit="true">
            <div data-options="region:'north',split:true,hideCollapsedContent:false," title="" style="height: 50px; padding: 5px;">
                <div class="operation_box" style="display: none;">
                    <a href="javascript:void(0)" onclick="do_close()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-close'">关闭</a>
                </div>
                <label>
                    收款人:
                <input class="easyui-combobox" id="tdChargeMan" style="width: 150px;" />
                </label>
                <label>
                    收费项目:
                <input class="easyui-combobox" id="tdChargeSummary" style="width: 150px;" />
                </label>
                <label>
                    收款方式:
                <input class="easyui-combobox" id="tdChargeType" style="width: 150px;" />
                </label>
                <label>
                    费项分类:
                <input class="easyui-combobox" id="tdCategory" style="width: 150px;" />
                </label>
                <label class="searchlabel" style="margin-left: 10px;">
                    <a href="#" onclick="SearchHis()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-search'">搜索</a>
                </label>
            </div>
            <div data-options="region:'center'" title="">
                <table id="his_table">
                </table>
                <div id="tb">
                    <a href="#" onclick="do_export()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-export'">导出</a>
                    <asp:HiddenField ID="hdIDs" runat="server" />
                    <a href="#" onclick="openTableSetUp()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-setting'">配置</a>
                </div>
            </div>
        </div>
        <iframe name="myiframe" id="myframe" style="display: none;" src="" width="100%" height="100%"></iframe>
    </form>
</asp:Content>
