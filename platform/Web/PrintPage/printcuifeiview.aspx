<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="printcuifeiview.aspx.cs" Inherits="Web.PrintPage.printcuifeiview" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script src="../js/jquery-1.8.3.min.js"></script>
    <script src="../js/easyui/jquery.easyui.min.js"></script>
    <script src="../js/easyui/easyui-lang-zh_CN.js"></script>
    <script src="../js/Page/Comm/unit.js"></script>
    <link href="../js/easyui/gray/easyui.css" rel="stylesheet" />
    <script type="text/javascript">
        $(function () {
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
            var CompanyName = "<%=Web.WebUtil.GetCompany(this.Context).CompanyName%>";
            var AddMan = "<%=Web.WebUtil.GetUser(this.Context).RealName%>";
            var NowDate = "<%=DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")%>";
            var ids = parent.$('#ids').val();
            var options = { visit: "loadprintcuifei", IDs: ids, StartTime: parent.tdStartTime.datebox('getValue'), EndTime: parent.tdEndTime.datebox('getValue') };
            $.ajax({
                type: 'POST',
                dataType: 'json',
                async: false,
                url: '../Handler/PrintHandler.ashx',
                data: options,
                success: function (data) {
                    var $html = '';
                    var count = 0;
                    var totalcolumns = 8;
                    var pagecount = 0;
                    var pagecost = 0;
                    $.each(data.list, function (newindex, dataitem) {
                        pageHeigth = dataitem.pageHeight || pageHeigth;
                        var totallines = (dataitem.PrintTotalLines > 0 ? dataitem.PrintTotalLines : 6);
                        var topmagin = (dataitem.PrintTopMargin > 0 ? dataitem.PrintTopMargin : 0);
                        var bottommagin = (dataitem.PrintBottomMargin > 0 ? dataitem.PrintBottomMargin : 0);
                        var top_height = 5 - topmagin + bottommagin;
                        top_height = (top_height > 0 ? top_height : 0) + 'mm';
                        var pagetotalcount = parseInt(dataitem.list.length / totallines);
                        if (dataitem.list.length % totallines > 0) {
                            pagetotalcount = pagetotalcount + 1;
                        }
                        pagecount = 0;
                        pagecost = 0;
                        $.each(dataitem.list, function (index, item) {
                            if (index % totallines == 0) {
                                $html += '<tr><td style="height:' + pageHeigth + 'mm;vertical-align:top;padding: ' + top_height + ' 0 0 0;">';
                                pagecount++;
                                pagecost = 0;
                                $html += '<table class="sfxm" style="width:100%;">';
                                $html += '<tr>';
                                $html += '<th colspan="' + totalcolumns + '" class="skdh finalfont" style="font-size:' + data.PrintFont + ';">';
                                $html += '<span class="finalfont" style="font-size:' + data.PrintFont + ';">(' + pagecount + '/' + pagetotalcount + ')</span>';
                                $html += '</th>';
                                $html += '</tr>';
                                $html += '<tr>';
                                $html += '<th colspan="' + totalcolumns + '" class="systitle">';
                                $html += '<span class="finalfont">' + dataitem.PrintTitle + '</span>';
                                $html += '</th>';
                                $html += '</tr>';
                                $html += '<tr>';
                                $html += '<th colspan="' + totalcolumns + '" class="sksj finalfont">';
                                $html += '<span class="finalfont">' + dataitem.PrintSubTitle + '</span>';
                                $html += '</th>';
                                $html += '</tr>';
                                $html += '<tr>';
                                $html += '<th colspan="4" class="fjdz finalfont">';
                                $html += '资源地址: ' + dataitem.FullName;
                                $html += '</th>';
                                $html += '<th colspan="4" class="khxm finalfont">';
                                $html += '客户名称: ' + dataitem.OwnerName;
                                $html += '</th>';
                                $html += '</tr>';
                                $html += '<tr class="haveborder finalfont">';
                                $html += '<th>收费项目';
                                $html += '</th>';
                                if (dataitem.IsPrintUnitPrice) {
                                    $html += '<th>单价';
                                    $html += '</th>';
                                }
                                $html += '<th>面积/用量';
                                $html += '</th>';
                                $html += '<th>应收金额';
                                $html += '</th>';
                                $html += '<th>计费开始日期';
                                $html += '</th>';
                                $html += '<th>计费结束日期';
                                $html += '</th>';
                                $html += '<th>上次/本次读数';
                                $html += '</th>';
                                $html += '<th>备注';
                                $html += '</th>';
                                $html += '</tr>';
                            }
                            $html += '<tr class="haveborder finalfont">';
                            $html += '<td>' + item.Name + '</td>';
                            if (dataitem.IsPrintUnitPrice) {
                                $html += '<td>' + toThousands(item.CalculateUnitPrice) + '</td>';
                            }
                            $html += '<td>' + item.CalculateUseCount + '</td>';
                            $html += '<td>' + (Number(item.TotalFinalCost) < 0 ? 0.00 : toThousands(item.TotalFinalCost)) + '</td>';
                            $html += '<td>' + formatTime(item.CalculateStartTime) + '</td>';
                            $html += '<td>' + formatTime(item.CalculateEndTime) + '</td>';
                            $html += '<td>' + Number(item.FinalStartPoint) + "/" + Number(item.FinalEndPoint);
                            var beilv_remark = '';
                            if (parseFloat(item.ProjectBiaoID) > 0 && parseFloat(item.ImportRate) > 0) {
                                $html += '(倍率:' + parseFloat(item.ImportRate) + ')';
                                if (item.ImportBiaoName != '')
                                    beilv_remark = '(表名称:' + item.ImportBiaoName + ")";
                            }
                            $html += '</td>';
                            $html += '<td>' + item.PrintRemark + beilv_remark + '</td>';
                            $html += '</tr>';
                            pagecost += (parseFloat(item.TotalFinalCost) < 0 ? 0 : parseFloat(item.TotalFinalCost));
                            if ((index + 1) % totallines == 0 || index == (dataitem.list.length - 1)) {
                                $html += '<tr class="haveborder">';
                                $html += '<td colspan="' + totalcolumns + '">';
                                $html += '<table class="innertable finalfont">';
                                $html += '<tr>';
                                //$html += '<td style="width:15%;border-left:none;">应收合计（大写）';
                                //$html += '</td>';
                                //$html += '<td style="width:20%">' + data.printhistory.CostCapital + '</td>';

                                $html += '<td style="width:100%;border-left:none;border-right:none;text-align:left;padding-left:5px;" class="finalfont">';
                                if (pagetotalcount >= 1) {
                                    $html += '(本页小计:￥' + toThousands(pagecost) + ')&nbsp;&nbsp;&nbsp;&nbsp;';
                                }
                                $html += '应收合计:';
                                $html += '￥' + (Number(dataitem.TotalCost) < 0.00 ? 0 : toThousands(dataitem.TotalCost)) + '</td>';
                                $html += '</tr>';
                                $html += '</table>';
                                $html += '</td>';
                                $html += '</tr>';
                                $html += '<tr>';
                                $html += '<th colspan="' + totalcolumns + '">';
                                $html += '<table class="skxx finalfont">';
                                $html += '<tr>';
                                $html += '<td style="width: 20%">打印人: ';
                                $html += AddMan + '</td>';
                                $html += '<td style="width: 30%;">打印日期: ';
                                $html += NowDate + '</td>';
                                $html += '<td style="width: 25%;">客户签收: ';
                                $html += '</td>';
                                $html += '<td style="width: 25%;">签收日期: ';
                                $html += '</td>';
                                $html += '</tr>';
                                $html += '</table>';
                                $html += '</th>';
                                $html += '</tr>';
                                $html += '<tr>';
                                $html += '<th colspan="' + totalcolumns + '">';
                                $html += '<table class="skxx finalfont">';
                                $html += '<tr>';
                                $html += '<td style="width: 30px;vertical-align:top;text-align:left;">备注: </td>';
                                $html += '<td style="vertical-align:top;text-align:left;">';
                                if (dataitem.Remark && dataitem.Remark != '') {
                                    $html += dataitem.Remark;
                                }
                                $html += '</td>';
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
                    if (data.PrintFont != '') {
                        $('.finalfont').css('font-size', data.PrintFont);
                    }
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

            table.sfxm tr.haveborder td, table.sfxm tr.haveborder th {
                text-align: center;
                border: solid #000;
                border-width: 1px;
                padding: 0;
                font-weight: normal;
            }

            table.sfxm tr.haveborder th {
                text-align: center;
                border: solid #000;
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
            text-align: right;
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
                border: solid 1px #000;
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
