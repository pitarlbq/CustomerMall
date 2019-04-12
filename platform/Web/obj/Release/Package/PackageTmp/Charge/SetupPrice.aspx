<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="SetupPrice.aspx.cs" Inherits="Web.Charge.SetupPrice" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <table id="tt_table">
        <thead>
            <tr>
                <th data-options="field:'ck',checkbox:true"></th>
                <th data-options="field:'UnitPrice'" width="60">单价</th>
                <th data-options="field:'ChargeName'" width="100">开始日期</th>
                <th data-options="field:'UnitPrice',editor:{type:'numberbox',options:{precision:2}}" width="50">单价</th>
                <th data-options="field:'UseCount',editor:{type:'numberbox',options:{precision:2}}" width="80">面积/用量</th>
                <th data-options="field:'StartTime',editor:'datebox',formatter: formatTime" width="100">计费开始日期</th>
                <th data-options="field:'EndTime',editor:'datebox',formatter: formatTime" width="100">计费结束日期</th>
                <th data-options="field:'Cost',formatter: formatCost" width="60">应收金额</th>
                <th data-options="field:'Balance',editor:{type:'numberbox',options:{precision:2}}" width="60">减免金额</th>
                <th data-options="field:'RealCost',formatter: formatRealCost" width="60">实收金额</th>
                <th data-options="field:'OutDays',formatter: formatOutDays" width="80">逾期</th>
                <th data-options="field:'Remark',editor:'textbox',formatter: formatRemark" width="100">备注信息</th>
            </tr>
        </thead>
    </table>
</asp:Content>
