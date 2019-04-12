<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="ChargeFee_View.aspx.cs" Inherits="Web.Charge.ChargeFee_View" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $(function () {
            getTableField();
        })
        function getTableField() {
            parent.ischargeview = 0;
            var rows = parent.$('#tt_table').datagrid("getSelections");
            if (rows.length == 0) {
                return;
            }
            var all_CalculateUseCount = 0;
            var all_BuildOutArea = 0;
            var all_TotalCost = 0;
            var all_Discount = 0;
            var all_PayCost = 0;
            var all_TotalRealCost = 0;
            var html = '';
            $.each(rows, function (index, row) {
                html = '<tr>';
                html += '<td>';
                html += row.Name;
                html += '</td>';

                html += '<td>';
                var CalculateUseCount = parent.formatUseCount(row.CalculateUseCount, row);
                html += (parseFloat(CalculateUseCount)).toFixed(2);
                html += '</td>';
                all_CalculateUseCount += parseFloat(CalculateUseCount);

                html += '<td>';
                var BuildOutArea = parent.formatDecimal(row.BuildOutArea, row);
                html += (parseFloat(BuildOutArea)).toFixed(2);
                html += '</td>';
                all_BuildOutArea += parseFloat(BuildOutArea);

                html += '<td>';
                var TotalCost = parent.formatCost(row.TotalCost, row);
                html += (parseFloat(TotalCost)).toFixed(2);
                html += '</td>';
                all_TotalCost += parseFloat(TotalCost);

                html += '<td>';
                var Discount = parent.formatDiscount(row.Discount, row);
                html += (parseFloat(Discount)).toFixed(2);
                html += '</td>';
                all_Discount += parseFloat(Discount);

                html += '<td>';
                var PayCost = parent.formatPayCost(row.PayCost, row);
                html += parseFloat(PayCost).toFixed(2);
                html += '</td>';
                all_PayCost += parseFloat(PayCost);

                html += '<td>';
                var TotalRealCost = parent.formatTotalRealCost(row.TotalRealCost, row);
                html += parseFloat(TotalRealCost).toFixed(2);
                html += '</td>';
                all_TotalRealCost += parseFloat(TotalRealCost);

                html += '</tr>';

                $(html).appendTo('#viewfield');
            })
            html = '<tr>';
            html += '<td>';
            html += '合计';
            html += '</td>';
            html += '<td>';
            html += all_CalculateUseCount.toFixed(2);
            html += '</td>';
            html += '<td>';
            html += all_BuildOutArea.toFixed(2);
            html += '</td>';
            html += '<td>';
            html += all_TotalCost.toFixed(2);
            html += '</td>';
            html += '<td>';
            html += all_Discount.toFixed(2);
            html += '</td>';
            html += '<td>';
            html += all_PayCost.toFixed(2);
            html += '</td>';
            html += '<td>';
            html += all_TotalRealCost.toFixed(2);
            html += '</td>';
            html += '</tr>';
            $(html).appendTo('#viewfield');
        }
        function closeWin(value) {
            parent.do_close_dialog(function () {
                parent.ischargeview = value;
                if (value == 1) {
                    parent.chargeroomfee();
                }
            });
        }
    </script>
    <style>
        .panel-body {
            background: #f0f0f0;
        }

        table.field {
            width: 96%;
            margin: 0 auto;
            border-spacing: 0;
            border-collapse: collapse;
            background: #fff;
            border-radius: 5px;
            border: 0px;
        }

            table.field td {
                width: 15%;
                padding: 5px 10px;
            }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <div class="easyui-layout" fit="true">
        <div data-options="region:'center'" title="">
            <div class="operation_box">
                <a href="#" onclick="closeWin(1)" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-print'">预览</a>

                <a href="#" onclick="closeWin(0)" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-close'">放弃</a>
            </div>
            <div class="table_container">
                <table id="viewfield" class="field">
                    <tr>
                        <td>收费项目</td>
                        <td>面积/用量</td>
                        <td>建筑面积</td>
                        <td>应收</td>
                        <td>减免金额</td>
                        <td>实收</td>
                        <td>已收</td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
</asp:Content>
