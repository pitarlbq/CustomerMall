<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="printoffsetchargefeeview.aspx.cs" Inherits="Web.PrintPage.printoffsetchargefeeview" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script src="../js/jquery-1.8.3.min.js"></script>
    <script src="../js/easyui/jquery.easyui.min.js"></script>
    <script src="../js/easyui/easyui-lang-zh_CN.js"></script>
    <link href="../js/easyui/gray/easyui.css" rel="stylesheet" />
    <script src="../js/Page/Comm/MaskUtil.js"></script>
    <script src="../js/Page/Comm/unit.js"></script>
    <script type="text/javascript">
        $(function () {
            var op = "<%=Request.QueryString["op"]%>" || "";
            if (op == 'view') {
                $('#innerTable').css('width', '80%');
                $('#innerTable').css('margin', '0 auto');
            }
            GenerateTable();
        });
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
            var CompanyName = "<%=Web.WebUtil.GetCompany(this.Context).CompanyName%>";
            var PrintID = "<%=this.PrintID%>";
            var PrintIDList = [];
            try {
                PrintIDList = parent.PrintIDList;
            } catch (e) {

            }
            var options = { visit: "loadprintchargefee", PrintID: PrintID, PrintIDList: JSON.stringify(PrintIDList) };
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
                        var topmagin = (data.PrintTopMargin > 0 ? data.PrintTopMargin + "mm" : "30px");
                        var bottommagin = (data.PrintBottomMargin > 0 ? data.PrintBottomMargin + "mm" : "0px");
                        var count = 0;
                        var totalcolumns = 7;
                        $.each(data.list, function (index, item) {
                            if (index % totallines == 0) {
                                $html += '<tr><td style="height:' + pageHeigth + 'mm;vertical-align:top;padding: ' + topmagin + ' 0 ' + bottommagin + ' 0;">';
                                if (data.LogoPath && data.LogoPath != '' && data.LogoPath != null) {
                                    $html += '<div class="companylogo">';
                                    if (data.LogoWidth > 0 && data.LogoHeight > 0) {
                                        $html += ' <img src="<%=base.GetContextPath()%>' + data.LogoPath + '" style="width:' + data.LogoWidth + 'px;height:' + data.LogoHeight + 'px" />';
                                    } else {
                                        $html += ' <img src="<%=base.GetContextPath()%>' + data.LogoPath + '" />';
                                    }
                                    $html += '</div>';
                                }
                                $html += '<table class="sfxm" style="width:100%;">';
                                $html += '<tr>';
                                $html += '<th colspan="' + totalcolumns + '" class="skdh">';
                                $html += '冲抵单号: ' + data.printhistory.PrintNumber;
                                $html += '</th>';
                                $html += '</tr>';
                                $html += '<tr>';
                                $html += '<th colspan="' + totalcolumns + '" class="systitle">';
                                $html += data.CompanyName;
                                $html += '</th>';
                                $html += '</tr>';
                                $html += '<tr>';
                                $html += '<th colspan="' + totalcolumns + '" class="sksj">';
                                $html += '冲抵单据';
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
                                $html += '<th style="width: 15%">收费项目';
                                $html += '</th>';
                                $html += '<th style="width: 15%">计费开始日期';
                                $html += '</th>';
                                $html += '<th style="width: 15%">计费结束日期';
                                $html += '</th>';
                                $html += '<th style="width: 10%">单价';
                                $html += '</th>';
                                $html += '<th style="width: 10%">冲销金额';
                                $html += '</th>';
                                $html += '<th style="width: 20%">上次/本次读数';
                                $html += '</th>';
                                $html += '<th style="width: 15%;">备注';
                                $html += '</th>';
                                $html += '</tr>';
                            }
                            $html += '<tr class="haveborder">';
                            $html += '<td>' + item.ChargeName + '</td>';
                            $html += '<td>' + formatTime(item.StartTime) + '</td>';
                            $html += '<td>' + formatTime(item.EndTime) + '</td>';
                            $html += '<td>' + toThousands(item.UnitPrice) + '</td>';
                            $html += '<td>' + toThousands(item.ChargeFee) + '</td>';
                            $html += '<td>' + Number(item.FinalStartPoint) + "/" + Number(item.FinalEndPoint) + '</td>';
                            $html += '<td>' + item.Remark + '</td>';
                            $html += '</tr>';
                            if ((index + 1) % totallines == 0 || index == (data.list.length - 1)) {
                                $html += '<tr class="haveborder">';
                                $html += '<td colspan="' + totalcolumns + '">';
                                $html += '<table class="innertable">';
                                $html += '<tr>';
                                //$html += '<td style="width:15%;border-left:none;">应收合计（大写）';
                                //$html += '</td>';
                                //$html += '<td style="width:45%">' + data.printhistory.CostCapital + '</td>';
                                $html += '<td style="width:50%;border-left:none;">应收合计: ￥' + (Number(data.printhistory.Cost) < 0 ? 0.00 : toThousands(data.printhistory.Cost));
                                $html += '</td>';
                                $html += '<td style="width:50%">实收合计: ￥' + (Number(data.printhistory.RealCost) < 0 ? 0.00 : toThousands(data.printhistory.RealCost)) + '</td>';
                                $html += '</td>';
                                $html += '</tr>';
                                $html += '</table>';
                                $html += '</td>';
                                $html += '</tr>';
                                $html += '<tr>';
                                $html += '<th colspan="' + totalcolumns + '">';
                                $html += '<table class="skxx">';
                                $html += '<tr>';
                                $html += '<td style="width: 20%">冲抵人: ';
                                $html += data.printhistory.ChargeMan + '</td>';
                                $html += '<td style="width: 30%;">冲抵时间: ';
                                $html += formatDateTime(data.printhistory.ChargeTime) + '</td>';
                                $html += '<td style="width: 25%;">冲销项目: ';
                                $html += data.printhistory.ChargeForSummary + '</td>';
                                $html += '<td style="width: 25%;">冲销方式: ';
                                $html += data.printhistory.ChargeMethods + '</td>';
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
        };
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
    </script>
    <style>
        body, html {
            margin: 0 !important;
            padding: 0;
        }
    </style>
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

        .companylogo {
            position: absolute;
            top: 5px;
            left: 5px;
            width: 100px;
        }

            .companylogo img {
                width: 60px;
                height: 60px;
            }

        table.innertable {
            width: 100%;
            border-collapse: collapse;
            border-spacing: 0;
            border: none;
            font-size: 12px;
            font-family: 'Microsoft YaHei';
        }

        table.sfxm tr.haveborder td table.innertable td {
            width: 100%;
            border-collapse: collapse;
            border-spacing: 0;
            border-top: none;
            border-bottom: none;
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

            table.sfxm tr.haveborder td, table.sfxm tr.haveborder th {
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
