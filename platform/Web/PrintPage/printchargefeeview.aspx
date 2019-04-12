<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="printchargefeeview.aspx.cs" Inherits="Web.PrintPage.printchargefeeview" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script src="../js/jquery-1.8.3.min.js"></script>
    <script src="../js/easyui/jquery.easyui.min.js"></script>
    <script src="../js/easyui/easyui-lang-zh_CN.js"></script>
    <link href="../js/easyui/gray/easyui.css" rel="stylesheet" />
    <script src="../js/Page/Comm/unit.js"></script>
    <script type="text/javascript">
        var ShowWeiShu;
        $(function () {
            var op = "<%=Request.QueryString["op"]%>" || "";
            if (op == 'view') {
                $('#innerTable').css('width', '80%');
                $('#innerTable').css('margin', '0 auto');
            }
            ShowWeiShu = Number("<%=this.ShowWeiShu?1:0%>");
            GenerateTable();
        })
        function GenerateTable() {
            var pageWidth = "<%=Request.QueryString["PageWidth"]%>";
            if (pageWidth == null || pageWidth == "" || Number(pageWidth) <= 0) {
                pageWidth = 210;
            }
            var pageHeigth = "<%=Request.QueryString["PageHeight"]%>";
            if (pageHeigth == null || pageHeigth == "") {
                pageHeigth = 99;
            }
            pageWidth = 210;
            pageWidth = pageWidth - 20;
            var PrintID = "<%=Request.QueryString["PrintID"]%>" || 0;
            var PrintIDList = [];
            try {
                PrintIDList = parent.GetSelectedPrintIDList();
            } catch (e) {
            }
            var CompanyName = "<%=Web.WebUtil.GetCompany(this.Context).CompanyName%>";
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
                        var topmagin = (data.PrintTopMargin > 0 ? data.PrintTopMargin : 0);
                        var bottommagin = (data.PrintBottomMargin > 0 ? data.PrintBottomMargin : 0);
                        var top_height = 5 - topmagin + bottommagin;
                        top_height = (top_height > 0 ? top_height : 0) + 'mm';
                        var pagecount = 0;
                        var totalcolumns = 4;
                        var pagecost = 0;
                        if (data.IsShowPrintCount) {
                            totalcolumns++;
                        }
                        if (data.IsShowPrintNote) {
                            totalcolumns++;
                        }
                        if (data.IsShowPrintCost) {
                            totalcolumns++;
                        }
                        if (data.IsShowPrintDiscount) {
                            totalcolumns++;
                        }
                        if (data.IsShowPrintRoomNo) {
                            totalcolumns++;
                        }
                        if (data.IsPrintTotalRealCost) {
                            totalcolumns++;
                        }
                        if (data.IsPrintRealCost) {
                            totalcolumns++;
                        }
                        if (data.IsPrintMonthCount) {
                            totalcolumns++;
                        }
                        if (data.IsPrintUnitPrice) {
                            totalcolumns++;
                        }
                        var pagetotalcount = parseInt(data.list.length / totallines);
                        if (data.list.length % totallines > 0) {
                            pagetotalcount = pagetotalcount + 1;
                        }
                        if (!data.PrintFont) {
                            data.PrintFont = '100%';
                        }
                        if (data.PrintFont == '') {
                            data.PrintFont = '100%';
                        }
                        pageHeight = data.pageHeight;
                        $.each(data.list, function (index, item) {
                            if (index % totallines == 0) {
                                $html += '<tr><td style="height:' + pageHeigth + 'mm;vertical-align:top;padding: ' + top_height + ' 0 0 0;">';
                                if (data.LogoPath && data.LogoPath != '' && data.LogoPath != null) {
                                    $html += '<div class="companylogo">';
                                    if (data.LogoWidth > 0 && data.LogoHeight > 0) {
                                        $html += ' <img src="<%=base.GetContextPath()%>' + data.LogoPath + '" style="width:' + data.LogoWidth + 'px;height:' + data.LogoHeight + 'px" />';
                                    } else {
                                        $html += ' <img src="<%=base.GetContextPath()%>' + data.LogoPath + '" />';
                                    }
                                    $html += '</div>';
                                }
                                pagecount++;
                                pagecost = 0;
                                $html += '<table class="sfxm" style="width:100%;">';
                                $html += '<tr>';
                                $html += '<th colspan="' + totalcolumns + '" class="skdh finalfont" style="font-size:' + data.PrintFont + ';">';
                                $html += '收款单号: <span class="finalfont" style="font-size:' + data.PrintFont + ';">' + data.printhistory.PrintNumber + '(' + pagecount + '/' + pagetotalcount + ')</span>';
                                $html += '</th>';
                                $html += '</tr>';
                                $html += '<tr>';
                                $html += '<th colspan="' + totalcolumns + '" class="systitle">';
                                $html += '<span class="finalfont" style="font-size:' + data.PrintFont + ';">' + data.CompanyName + '</span>';
                                $html += '</th>';
                                $html += '</tr>';
                                $html += '<tr>';
                                $html += '<th colspan="' + totalcolumns + '" class="sksj finalfont">';
                                $html += '<span class="finalfont" style="font-size:' + data.PrintFont + '">' + data.SubTitle + '</span>';
                                $html += '</th>';
                                $html += '</tr>';
                                $html += '<tr>';
                                $html += '<th colspan="' + totalcolumns + '" style="width: 100%; padding-bottom: 5px;">';
                                $html += '<table style=" width: 100%;border-collapse: collapse;border-spacing: 0;border: none;font-size: 12px;">';
                                $html += '<tr>';
                                $html += '<td style="width:65%;font-size:' + data.PrintFont + ';" class="fjdz finalfont">';
                                $html += '资源地址: ' + data.FullName;
                                $html += '</td>';
                                $html += '<td style="width:35%;font-size:' + data.PrintFont + ';" class="khxm finalfont">';
                                $html += '客户名称: ' + data.OwnerName;
                                $html += '</td>';
                                $html += '</tr>';
                                $html += '</table>';
                                $html += '</th>';
                                $html += '</tr>';
                                $html += '<tr class="haveborder finalfont" style="font-size:' + data.PrintFont + ';">';
                                if (data.IsShowPrintRoomNo) {
                                    $html += '<th>资源编号';
                                    $html += '</th>';
                                }
                                $html += '<th >收费项目';
                                $html += '</th>';
                                if (data.IsPrintUnitPrice) {
                                    $html += '<th >单价';
                                    $html += '</th>';
                                }
                                $html += '<th >面积/用量';
                                $html += '</th>';
                                if (data.IsShowPrintCost) {
                                    $html += '<th>应收金额';
                                    $html += '</th>';
                                }
                                if (data.IsShowPrintDiscount) {
                                    $html += '<th>减免金额';
                                    $html += '</th>';
                                }
                                if (data.IsPrintRealCost) {
                                    $html += '<th>实收金额';
                                    $html += '</th>';
                                }
                                if (data.IsPrintTotalRealCost) {
                                    $html += '<th>已收金额';
                                    $html += '</th>';
                                }
                                $html += '<th >计费开始日期';
                                $html += '</th>';
                                $html += '<th >计费结束日期';
                                $html += '</th>';
                                if (data.IsPrintMonthCount) {
                                    $html += '<th>月数';
                                    $html += '</th>';
                                }
                                if (data.IsShowPrintCount) {
                                    $html += '<th>上次/本次读数';
                                    $html += '</th>';
                                }
                                if (data.IsShowPrintNote) {
                                    $html += '<th>备注';
                                    $html += '</th>';
                                }
                                $html += '</tr>';
                            }
                            $html += '<tr class="haveborder finalfont" style="font-size:' + data.PrintFont + ';">';
                            if (data.IsShowPrintRoomNo) {
                                $html += '<td>' + item.RoomName + '</td>';
                            }
                            $html += '<td>' + item.ChargeName + '</td>';
                            if (data.IsPrintUnitPrice) {
                                $html += '<td>' + (Number(item.UnitPrice) < 0 ? 0 : toThousands(item.UnitPrice)) + '</td>';
                            }
                            $html += '<td>' + (Number(item.UseCount) < 0 ? 0 : item.UseCount) + '</td>';
                            if (data.IsShowPrintCost) {
                                $html += '<td>' + (Number(item.Cost) < 0 ? 0 : toThousands(item.Cost)) + '</td>';
                            }
                            if (data.IsShowPrintDiscount) {
                                $html += '<td>' + (Number(item.Discount) < 0 ? 0 : toThousands(item.Discount)) + '</td>';
                            }
                            if (data.IsPrintRealCost) {
                                $html += '<td>' + (Number(item.RealCost) < 0 ? 0 : toThousands(item.RealCost)) + '</td>';
                            }
                            if (data.IsPrintTotalRealCost) {
                                if (PrintID > 0) {
                                    var TotalRealCost = (parseFloat(item.TotalRealCost) < 0 ? 0 : item.TotalRealCost) -
                                        (parseFloat(item.RealCost) < 0 ? 0 : item.RealCost);
                                    TotalRealCost = (TotalRealCost < 0 ? 0 : TotalRealCost);
                                    if (TotalRealCost >= item.Cost) {
                                        TotalRealCost = 0;
                                    }
                                    $html += '<td>' + (TotalRealCost < 0 ? 0.00 : toThousands(TotalRealCost)) + '</td>';
                                }
                                else {
                                    $html += '<td>' + (parseFloat(item.TotalRealCost) < 0 ? 0 : toThousands(item.TotalRealCost)) + '</td>';
                                }
                            }
                            $html += '<td>' + formatTime(item.StartTime) + '</td>';
                            $html += '<td>' + formatTime(item.EndTime) + '</td>';
                            if (data.IsPrintMonthCount) {
                                $html += '<td>' + item.CalculateMonthCount + '</td>';
                            }
                            var beilv_remark = '';
                            if (data.IsShowPrintCount) {
                                $html += '<td>' + Number(item.FinalStartPoint) + "/" + Number(item.FinalEndPoint);
                                if (parseFloat(item.ProjectBiaoID) > 0 && parseFloat(item.ImportRate) > 0) {
                                    $html += '(倍率:' + parseFloat(item.ImportRate) + ')';
                                    if (item.ImportBiaoName != '')
                                        beilv_remark = '(表名称:' + item.ImportBiaoName + ")";
                                }
                                $html += '</td>';
                            }
                            if (data.IsShowPrintNote) {
                                $html += '<td>' + item.FinalRemark + beilv_remark + '</td>';
                            }
                            $html += '</tr>';
                            pagecost += (parseFloat(item.RealCost) < 0 ? 0 : parseFloat(item.RealCost));
                            if ((index + 1) % totallines == 0 || index == (data.list.length - 1)) {
                                $html += '<tr class="haveborder">';
                                $html += '<td colspan="' + totalcolumns + '" style="padding:0;">';
                                $html += '<table class="innertable finalfont" style="font-size:' + data.PrintFont + ';">';
                                $html += '<tr>';
                                //$html += '<td style="width:15%;border-left:none;">应收合计（大写）';
                                //$html += '</td>';
                                //$html += '<td style="width:20%">' + data.printhistory.CostCapital + '</td>';
                                $html += '<td style="width:25%;border-left:none;">应收合计';
                                $html += '</td>';
                                $html += '<td style="width:25%">￥' + (Number(data.printhistory.Cost) < 0 ? 0 : toThousands(data.printhistory.Cost)) + '</td>';
                                $html += '<td style="width:50%;border-right:none;text-align:left;">';
                                if (pagetotalcount > 1) {
                                    $html += '(本页小计：￥' + toThousands(pagecost) + ')&nbsp;&nbsp;&nbsp;&nbsp;';
                                }
                                $html += '实收合计 ￥' + toThousands(data.printhistory.RealCost) + '&nbsp;&nbsp;&nbsp;&nbsp;';
                                //$html += '预收 ￥' + data.printhistory.PreChargeMoney.toFixed(2) + '&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;';
                                //$html += '找零 ￥' + data.printhistory.ChargeBackMoney.toFixed(2);
                                if (ShowWeiShu == 1) {
                                    $html += '尾数余额 ￥' + data.totalbalance.toFixed(2);
                                }
                                $html += '</td>';
                                $html += '</tr>';
                                $html += '</table>';
                                $html += '</td>';
                                $html += '</tr>';
                                $html += '<tr>';
                                $html += '<th colspan="' + totalcolumns + '">';
                                $html += '<table class="skxx finalfont" style="font-size:' + data.PrintFont + ';">';
                                $html += '<tr>';
                                $html += '<td style="width: 80%">收款人: ';
                                $html += data.printhistory.ChargeMan;
                                $html += '&nbsp;&nbsp;&nbsp;&nbsp;收款日期: ';
                                $html += formatDateTime(data.printhistory.ChargeTime);
                                $html += '&nbsp;&nbsp;&nbsp;&nbsp收款方式: ';
                                $html += data.ChargeTypeName1 + ': ';
                                $html += '￥' + (Number(data.printhistory.RealMoneyCost1) < 0 ? 0.00 : toThousands(data.printhistory.RealMoneyCost1)) + '&nbsp;&nbsp;&nbsp;&nbsp;';
                                if (Number(data.printhistory.RealMoneyCost2) > 0 && data.PrintChargeTypeCount == 2) {
                                    $html += data.ChargeTypeName2 + ': ';
                                    $html += '￥' + (Number(data.printhistory.RealMoneyCost2) < 0 ? 0.00 : toThousands(data.printhistory.RealMoneyCost2)) + '&nbsp;&nbsp;&nbsp;&nbsp;';
                                }
                                if (Number(data.printhistory.DiscountMoney) > 0) {
                                    $html += '优惠: ';
                                    $html += '￥' + (Number(data.printhistory.DiscountMoney) < 0 ? 0.00 : toThousands(data.printhistory.DiscountMoney));
                                }
                                $html += '</td>';
                                $html += '<td style="width: 20%">';
                                if (data.show_sign) {
                                    $html += '客户签名:';
                                }
                                $html += '</td>';
                                $html += '</tr>';
                                $html += '</table>';
                                $html += '</th>';
                                $html += '</tr>';
                                $html += '<tr>';
                                $html += '<th class="shuoming finalfont" colspan="' + totalcolumns + '" style="font-size:' + data.PrintFont + ';">';
                                $html += '<table class="skxx finalfont" style="font-size:' + data.PrintFont + ';">';
                                $html += '<tr>';
                                if (data.show_sign && false) {
                                    $html += '<td style="width: 60%;word-wrap:break-word; word-break:break-all;">备注:';
                                    $html += data.printhistory.Remark;
                                    $html += '</td>';
                                    $html += '<td style="width: 40%;text-align:right;">';
                                    $html += '客户签名: <div style="border-bottom:solid 1px #000;width:100px;display:inline-block;height:15px;margin-right:10px;"></div>';
                                    $html += '</td>';
                                }
                                else {
                                    $html += '<td style="width: 100%;word-wrap:break-word; word-break:break-all;">备注:';
                                    $html += data.printhistory.Remark;
                                    $html += '</td>';
                                }
                                $html += '</tr>';
                                $html += '</table>';
                                $html += '</th>';
                                $html += '</tr>';
                                $html += '</table>';
                                $html += '</td></tr>';
                            }
                        })
                    })
                    $("#innerTable").html($html);
                    //if (data.PrintFont != '') {
                    //    $('.finalfont').css('font-size', data.PrintFont);
                    //}
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
            min-width: 100px;
        }

            .companylogo img {
                width: 60px;
                height: 60px;
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
            font-family: 'Microsoft YaHei';
            padding: 2px 0 0 2px;
            text-align: left;
        }

        input {
            border: none;
            border-bottom: solid 1px #000000;
            font-size: 12px;
            font-family: 'Microsoft YaHei';
        }

        table.sfxm tr td, table.sfxm tr th {
            border-spacing: 0;
            border-collapse: collapse;
            padding: 2px 0;
            font-weight: normal;
        }

        table.sfxm tr.haveborder td, table.sfxm tr.haveborder th {
            border: solid 1px #000000;
            text-align: center;
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
            font-size: 12px;
        }

        .khxm {
            text-align: right;
            font-weight: normal;
            font-size: 12px;
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

            table.skxx tr td {
                text-align: left;
                font-weight: normal;
                padding: 0;
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
