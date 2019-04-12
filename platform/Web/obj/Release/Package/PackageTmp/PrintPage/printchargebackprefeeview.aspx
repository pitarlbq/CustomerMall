<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="printchargebackprefeeview.aspx.cs" Inherits="Web.PrintPage.printchargebackprefeeview" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script src="../js/jquery-1.8.3.min.js"></script>
    <script src="../js/easyui/jquery.easyui.min.js"></script>
    <script src="../js/easyui/easyui-lang-zh_CN.js"></script>
    <script src="../js/Page/Comm/unit.js?v2"></script>
    <link href="../js/easyui/gray/easyui.css" rel="stylesheet" />
    <script type="text/javascript">
        $(function () {
            var op = "<%=Request.QueryString["op"]%>" || "";
            if (op == 'view') {
                $('#innerTable').css('width', '80%');
                $('#innerTable').css('margin', '0 auto');
            }
            GenerateTable();
        })
        function GenerateTable() {
            var pageWidth = "<%=Request.QueryString["PageWidth"]%>";
            if (pageWidth == null || pageWidth == "" || Number(pageWidth) <= 0) {
                pageWidth = 210;
            }
            var pageHeigth = "<%=Request.QueryString["PageHeight"]%>";
            if (pageHeigth == null || pageHeigth == "" || Number(pageHeigth) <= 0) {
                pageHeigth = 99;
            }
            pageWidth = pageWidth - 20;
            var options = { visit: "loadprintchargefee", PrintID: "<%=Request.QueryString["PrintID"]%>", type: "payback" };
            $.ajax({
                type: 'POST',
                dataType: 'json',
                async: false,
                url: '../Handler/PrintHandler.ashx',
                data: options,
                success: function (message) {
                    if (!message.status) {
                        return;
                    }
                    var $html = '';
                    $.each(message.list, function (index2, data) {
                        pageHeigth = data.PageHeight || pageHeigth;
                        var totallines = (data.PrintTotalLines > 0 ? data.PrintTotalLines : 6);
                        var topmagin = (data.PrintTopMargin > 0 ? data.PrintTopMargin : 0);
                        var bottommagin = (data.PrintBottomMargin > 0 ? data.PrintBottomMargin : 0);
                        var top_height = 5 - topmagin + bottommagin;
                        top_height = (top_height > 0 ? top_height : 0) + 'mm';
                        var count = 0;
                        var totalcolumns = 5;
                        $.each(data.list, function (index, item) {
                            if (index % totallines == 0) {
                                $html += '<tr><td style="height:' + pageHeigth + 'mm;vertical-align:top;padding: ' + top_height + ' 0 0 0;">';
                                $html += '<table class="sfxm" style="width:100%;">';
                                $html += '<tr>';
                                $html += '<th colspan="' + totalcolumns + '" class="skdh">';
                                $html += '付款单号: ' + data.printhistory.PrintNumber;
                                $html += '</th>';
                                $html += '</tr>';
                                $html += '<tr>';
                                $html += '<th colspan="' + totalcolumns + '" class="systitle">';
                                $html += data.CompanyName;
                                $html += '</th>';
                                $html += '</tr>';
                                $html += '<tr>';
                                $html += '<th colspan="' + totalcolumns + '" class="sksj">';
                                $html += data.SubTitle;
                                $html += '</th>';
                                $html += '</tr>';
                                $html += '<tr>';
                                $html += '<th colspan="' + totalcolumns + '" style="width: 100%; padding-bottom: 5px;">';
                                $html += '<table style=" width: 100%;border-collapse: collapse;border-spacing: 0;border: none;font-size: 12px;">';
                                $html += '<tr>';
                                $html += '<td style="width:65%;" class="fjdz finalfont">';
                                $html += '资源地址: ' + data.FullName;
                                $html += '</td>';
                                $html += '<td style="width:35%;" class="khxm finalfont">';
                                $html += '客户名称: ' + data.OwnerName;
                                $html += '</td>';
                                $html += '</tr>';
                                $html += '</table>';
                                $html += '</th>';
                                $html += '</tr>';
                                $html += '<tr class="haveborder">';
                                $html += '<th style="width: 20%">付款项目';
                                $html += '</th>';
                                $html += '<th style="width: 20%">当前金额';
                                $html += '</th>';
                                $html += '<th style="width: 20%">付款金额';
                                $html += '</th>';
                                $html += '<th style="width: 20%">账户余额';
                                $html += '</th>';
                                $html += '<th style="width: 20%">扣款说明';
                                $html += '</th>';
                                $html += '</tr>';
                            }
                            $html += '<tr class="haveborder">';
                            $html += '<td>' + item.ChargeFeeSummaryName + '</td>';
                            $html += '<td>' + toThousands(item.ChargeFeeCurrentBalance) + '</td>';
                            $html += '<td>' + toThousands(item.RealCost) + '</td>';
                            $html += '<td>' + toThousands((item.ChargeFeeCurrentBalance - item.RealCost)) + '</td>';
                            $html += '<td>' + item.Remark + '</td>';
                            $html += '</tr>';
                            if ((index + 1) % totallines == 0 || index == (data.list.length - 1)) {
                                $html += '<tr>';
                                $html += '<th colspan="' + totalcolumns + '">';
                                $html += '<table class="skxx">';
                                $html += '<tr>';
                                $html += '<td style="width: 20%">付款人: ';
                                $html += data.printhistory.ChargeMan + '</td>';
                                $html += '<td style="width: 30%;">付款时间: ';
                                $html += formatDateTime(data.printhistory.ChargeTime) + '</td>';
                                $html += '<td style="width: 20%">实付合计: ￥';
                                $html += toThousands(data.printhistory.RealCost) + '</td>';
                                $html += '<td style="width: 50%;">付款方式: ';
                                $html += data.ChargeTypeName1;
                                $html += '</td>';
                                $html += '</tr>';
                                $html += '</table>';
                                $html += '</th>';
                                $html += '</tr>';
                                $html += '<tr>';
                                $html += '<th class="shuoming" colspan="' + totalcolumns + '">备注:' + data.printhistory.Remark;
                                $html += '</th>';
                                $html += '</tr>';
                                $html += '</table>';
                                $html += '</td></tr>';
                            }
                        })
                    })
                    $("#innerTable").html($html);
                }
            });
        }
        function formatTime(value) {
            if (value == undefined || value == null || value == '0001-01-01T00:00:00.0000000' || value == '0001-01-01T00:00:00' || value == '1900-01-01T00:00:00.0000000' || value == '1900-01-01T00:00:00') {
                return "--";
            }
            return value.substring(0, 16).split("T")[0];
        }
        function formatDateTime(value) {
            if (value == undefined || value == null || value == '0001-01-01T00:00:00.0000000' || value == '0001-01-01T00:00:00' || value == '1900-01-01T00:00:00.0000000' || value == '1900-01-01T00:00:00') {
                return "--";
            }
            var result = value.substring(0, 19).split("T");
            return result[0] + ' ' + result[1];
        }
        function formatMonthTime(value) {
            if (value == undefined || value == null || value == '0001-01-01T00:00:00.0000000' || value == '0001-01-01T00:00:00' || value == '1900-01-01T00:00:00.0000000' || value == '1900-01-01T00:00:00') {
                return "--";
            }
            return value.substring(0, 7);
        }
    </script>
</head>
<body>
    <style type="text/css">
        table#innertable {
            width: 100%;
            border-collapse: collapse;
            border-spacing: 0;
            border: none;
            font-size: 12px;
            font-family: 'Microsoft YaHei';
        }

        table.sfxm {
            width: 100%;
            border-collapse: collapse;
            border-spacing: 0;
            font-size: 12px;
            font-family: 'Microsoft YaHei';
            font-weight: normal;
            margin: 0px;
        }

            table.sfxm tr.haveborder td {
                text-align: center;
                border: solid #000000;
                border-width: 1px;
                padding: 0;
                font-weight: normal;
            }

            table.sfxm tr.haveborder th {
                text-align: center;
                border: solid #000000;
                border-width: 1px 1px 0px 1px;
                padding: 0;
            }

        .skdh {
            margin: 20px 0 0 0;
            text-align: right;
            font-weight: normal;
        }

        .systitle {
            font-size: 20px;
            text-align: center;
            font-weight: normal;
        }

        .sksj {
            font-size: 14px;
            text-align: center;
            font-weight: normal;
        }

        .fjdz {
            text-align: left;
            font-weight: normal;
        }

        .khxm {
            text-align: center;
            font-weight: normal;
        }

        .clear {
            clear: both;
        }

        table.skxx {
            width: 100%;
            border-collapse: collapse;
            border-spacing: 0;
            font-size: 12px;
        }

        table.heji {
            border-collapse: collapse;
            border-spacing: 0;
            width: 100%;
        }

            table.heji td {
                text-align: left;
                padding: 5px 0;
                border: solid 1px #000000;
            }

        table.skxx td {
            text-align: left;
            font-weight: normal;
        }

        .shuoming {
            width: 100%;
            text-align: left;
            font-weight: normal;
        }
    </style>
    <table id="innerTable">
    </table>
</body>
</html>
