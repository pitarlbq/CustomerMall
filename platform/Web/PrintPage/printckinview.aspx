<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="printckinview.aspx.cs" Inherits="Web.PrintPage.printckinview" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script src="../js/jquery-1.8.3.min.js"></script>
    <script src="../js/Page/Comm/unit.js"></script>
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
                pageHeigth = 93;
            }
            //$('body').css('width', pageWidth + "mm");
            pageWidth = pageWidth - 20;
            var CompanyName = "<%=Web.WebUtil.GetCompany(this.Context).CompanyName%>";
            var IDList = [];
            var IDs = "<%=this.Request.QueryString["IDList"]%>";
            if (IDs) {
                IDList = eval('(' + IDs + ')');
            }
            else {
                var rows = parent.$("#tt_table").datagrid("getSelections");
                if (rows.length == 0) {
                    show_message("请至少选择一个入库信息进行此操作", "info");
                    return;
                }
                $.each(rows, function () {
                    if ($.inArray(this.InSummaryID, IDList) == -1) {
                        IDList.push(this.InSummaryID);
                    }
                });
            }
            var options = { visit: "loadprintckin", IDs: JSON.stringify(IDList) };
            $.ajax({
                type: 'POST',
                dataType: 'json',
                async: false,
                url: '../Handler/PrintHandler.ashx',
                data: options,
                success: function (data) {
                    var $html = '';
                    var totallines = 6;
                    var totalcolumns = 8;
                    var totalcount_perpage = 0;
                    var totalcount = 0;
                    var totalcost = 0;
                    var totalcost_perpage = 0;
                    $.each(data, function (first, firstitem) {
                        totallines = firstitem.PrintLineCount || 6;
                        totalcount = 0;
                        totalcost = 0;
                        $.each(firstitem.list, function (index, item) {
                            totalcount += item.InTotalCount;
                            totalcost += item.InTotalPrice;
                        })
                        $.each(firstitem.list, function (index, item) {
                            if (index % totallines == 0) {
                                totalcount_perpage = 0;
                                totalcost_perpage = 0;
                                $html += '<tr><td style="height:' + pageHeigth + 'mm;vertical-align:top;padding: 5mm 0 0 0;">';
                                $html += '<table class="sfxm" style="width:100%;">';
                                $html += '<tr>';
                                $html += '<th colspan="' + totalcolumns + '" class="systitle">';
                                $html += '<span class="finalfont">物品入库单</span>';
                                $html += '</th>';
                                $html += '</tr>';
                                $html += '<tr>';
                                $html += '<th colspan="' + totalcolumns + '" class="sksj finalfont">';
                                $html += '<span class="finalfont">' + firstitem.summary.ContractUserName + '</span>';
                                $html += '</th>';
                                $html += '</tr>';
                                $html += '<tr>';
                                $html += '<th colspan="' + totalcolumns + '" style="width: 100%; padding-bottom: 5px;">';
                                $html += '<table style=" width: 100%;border-collapse: collapse;border-spacing: 0;border: none;font-size: 12px;">';
                                $html += '<tr>';
                                $html += '<td style="width:50%;" class="fjdz finalfont">';
                                $html += '入库单号: ' + firstitem.summary.OrderNumber;
                                $html += '</td>';
                                $html += '<td style="width:50%;" class="khxm finalfont">';
                                $html += '制单日期: ' + formatTime(firstitem.summary.InTime);
                                $html += '</td>';
                                $html += '</tr>';
                                $html += '</table>';
                                $html += '</th>';
                                $html += '</tr>';
                                $html += '<tr class="haveborder finalfont">';
                                $html += '<th >序号</th>';
                                $html += '<th >物品名称</th>';
                                $html += '<th >规格型号</th>';
                                $html += '<th >单位</th>';
                                $html += '<th>入库单价</th>';
                                $html += '<th>入库数量</th>';
                                $html += '<th >金额</th>';
                                $html += '<th >备注</th>';
                            }
                            totalcount_perpage += item.InTotalCount;
                            totalcost_perpage += item.InTotalPrice;
                            $html += '</tr>';
                            $html += '<tr class="haveborder finalfont">';
                            $html += '<td>' + (index + 1) + '</td>';
                            $html += '<td>' + item.ProductName + '</td>';
                            $html += '<td>' + item.ModelNumber + '</td>';
                            $html += '<td>' + item.Unit + '</td>';
                            $html += '<td>' + toThousands(item.UnitPrice) + '</td>';
                            $html += '<td>' + item.InTotalCount + '</td>';
                            $html += '<td>' + toThousands(item.InTotalPrice) + '</td>';
                            $html += '<td></td>';
                            $html += '</tr>';
                            if ((index + 1) % totallines == 0 || index == (firstitem.list.length - 1)) {
                                $html += '<tr>';
                                $html += '<th class="shuoming finalfont" colspan="' + totalcolumns + '">';
                                $html += '<table style=" width: 100%;border-collapse: collapse;border-spacing: 0;border: none;font-size: 12px;">';
                                $html += '<tr>';
                                $html += '<td style="width:20%;" class="fjdz finalfont">';
                                $html += '仓管员: ' + firstitem.summary.AddUserName;
                                $html += '</td>';
                                $html += '<td style="width:40%;" class="fjdz finalfont">';
                                $html += '合计数量: ' + totalcount_perpage + '(' + totalcount + ')';
                                $html += '&nbsp;&nbsp;合计金额: ￥' + toThousands(totalcost_perpage) + '(￥' + toThousands(totalcost) + ')';
                                $html += '</td>';
                                $html += '<td style="width:20%;" class="fjdz finalfont">';
                                $html += '经办人: ' + firstitem.summary.AddMan;
                                $html += '</td>';
                                $html += '<td style="width:20%;" class="fjdz finalfont">';
                                $html += '审核人: ' + firstitem.summary.ApproveMan;
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
