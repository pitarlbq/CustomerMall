<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="printmallorderview.aspx.cs" Inherits="Web.PrintPage.printmallorderview" %>

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
        var OrderID;
        $(function () {
            OrderID = "<%=this.OrderID%>" || 0;
            GenerateTable();
        })
        function GenerateTable() {
            var pageWidth = 210;
            var pageHeigth = 99;
            pageWidth = pageWidth - 20;
            var CompanyName = "<%=Web.WebUtil.GetCompany(this.Context).CompanyName%>";
            var OrderIDList = [];
            OrderIDList.push(OrderID);
            var options = { visit: "loadmallorderprint", OrderIDList: JSON.stringify(OrderIDList) };
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
                        var totallines = 6;
                        var totalcolumns = 5;
                        $.each(data.list, function (index, item) {
                            if (index % totallines == 0) {
                                $html += '<tr><td style="height:' + pageHeigth + 'mm;vertical-align:top;padding: 0 0 0 0;">';
                                $html += '<table class="sfxm" style="width:100%;">';
                                $html += '<tr>';
                                $html += '<th colspan="' + totalcolumns + '" style="width: 100%; padding-bottom: 5px;">';
                                $html += '<table style=" width: 100%;border-collapse: collapse;border-spacing: 0;border: none;font-size: 12px;">';
                                $html += '<tr>'
                                $html += '<td colspan="2" style="width: 100%; padding-bottom: 5px;">';
                                $html += '买家信息：';
                                $html += '</td>';
                                $html += '</tr>';
                                $html += '<tr>';
                                $html += '<td style="width:40%;padding-bottom: 10px;" class="fjdz finalfont">';
                                $html += '收件人：' + data.BuyerName + "&nbsp;&nbsp;&nbsp;&nbsp;";
                                $html += '电话：' + data.BuyerPhone + "&nbsp;&nbsp;&nbsp;&nbsp;";
                                $html += '</td>';
                                $html += '<td style="width:60%;padding-bottom: 10px;" class="fjdz finalfont">';
                                $html += '收货地址：' + data.FullAddressInfo;
                                $html += '</td>';
                                $html += '</tr>';
                                //$html += '<tr>';
                                //$html += '<td style="width:50%;padding-bottom: 10px;" class="fjdz finalfont">';
                                //$html += data.BuyerPhone + "(" + data.BuyerName + ")";
                                //$html += '</td>';
                                //$html += '<td style="width:50%;padding-bottom: 10px;" class="fjdz finalfont">';
                                //$html += data.FullAddressInfo;
                                //$html += '</td>';
                                $html += '</tr>';
                                $html += '<tr>'
                                $html += '<td colspan="2" style="width: 100%; padding-bottom: 5px; padding-top:10px; border-top:solid 1px #808080;">';
                                $html += '订单信息：';
                                $html += '</td>';
                                $html += '</tr>';
                                $html += '<tr>'
                                $html += '<td style="width:50%;" class="fjdz finalfont">';
                                $html += '订单编号：' + data.OrderNumber;
                                $html += '</td>';
                                $html += '<td style="width:50%;" class="fjdz finalfont">';
                                $html += '订单时间：' + data.OrderTime;
                                $html += '</td>';
                                $html += '</tr>';
                                $html += '<tr>'
                                $html += '<td style="width:50%;" class="fjdz finalfont">';
                                $html += '订单状态：' + data.StatusDesc;
                                $html += '</td>';
                                $html += '<td style="width:50%;" class="fjdz finalfont">';
                                $html += '订单类型：' + data.OrderType;
                                $html += '</td>';
                                $html += '</tr>';
                                $html += '</table>';
                                $html += '</th>';
                                $html += '</tr>';
                                $html += '<tr class="haveborder finalfont">';
                                $html += '<th >商品名称';
                                $html += '</th>';
                                $html += '<th >商品规格';
                                $html += '</th>';
                                $html += '<th >数量';
                                $html += '</th>';
                                $html += '<th >单价(元)';
                                $html += '</th>';
                                $html += '<th >金额';
                                $html += '</th>';
                                $html += '</tr>';
                            }
                            $html += '<tr class="haveborder finalfont">';
                            $html += '<td>' + item.ProductName + '</td>';
                            $html += '<td>' + item.ProductModel + '</td>';
                            $html += '<td>' + item.Quantity + '</td>';
                            $html += '<td>' + item.UnitPrice + '</td>';
                            $html += '<td>' + item.Cost + '</td>';
                            $html += '</tr>';
                            if ((index + 1) % totallines == 0 || index == (data.list.length - 1)) {
                                $html += '<tr class="haveborder">';
                                $html += '<td colspan="' + totalcolumns + '" style="padding:0;text-align:right;">';
                                $html += '福顺卷抵扣：' + data.CouponCost;
                                $html += '</td>';
                                $html += '</tr>';
                                $html += '<tr class="haveborder">';
                                $html += '<td colspan="' + totalcolumns + '" style="padding:0;text-align:right;">';
                                $html += '订单合计：' + data.TotalCost;
                                $html += '</td>';
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
            padding: 5px 0;
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
