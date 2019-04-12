<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="SetupFeeList.aspx.cs" Inherits="Web.SetupFee.SetupFeeList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        var CategoryID, CompanyID, canStart;
        $(function () {
            canStart = ('<%=base.CheckAuthByModuleCode("1191094")?1:0%>');
            CompanyID = "<%=Web.WebUtil.GetCompanyID(this.Context)%>";
            CategoryID = "<%=this.CategoryID%>";
        })
    </script>
    <script src="../js/Page/SetupFee/SetupFeeList.js?v=1_<%=base.getToken() %>"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <table id="tt_table" class="fee_table">
        <thead>
            <tr>
                <th data-options="field:'ck',checkbox:true"></th>
                <th data-options="field:'FeeTypeDesc'" width="100">收费性质</th>
                <th data-options="field:'Name'" width="100">收费项目</th>
                <th data-options="field:'CategoryDesc'" width="100">分类</th>
                <th data-options="field:'FinalUnitPrice'" width="100">默认单价</th>
                <%--<th data-options="field:'FinalStartTime'" width="100">计费开始日期</th>--%>
                <%--<th data-options="field:'FinalEndTime'" width="100">计费结束日期</th>--%>
                <th data-options="field:'ChargeTypeDesc'" width="100">计费方式</th>
                <th data-options="field:'FinalCalculateRule'" width="150">计费规则</th>
                <th data-options="field:'FinalEndNumberCountDesc'" width="100">金额尾数</th>
                <th data-options="field:'TimeAutoDesc'" width="100">启用收费序时</th>
                <th data-options="field:'IsOrderFeeOnDesc'" width="100">启用交款审计</th>
                <th data-options="field:'IsAllowImportDesc'" width="100">批量账单处理</th>
                <th data-options="field:'DisableDefaultImportFeeDesc'" width="100">启用默认账单</th>
                <%--<th data-options="field:'Operation',formatter:formatOper" width="100">操作</th>--%>
            </tr>
        </thead>
    </table>
</asp:Content>
