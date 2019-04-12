<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="printchargefeenew.aspx.cs" Inherits="Web.PrintPage.printchargefeenew" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../js/Lodop/LodopFuncs.js?t=<%=base.getToken() %>"></script>
    <script type="text/javascript">
        var ShowWeiShu, CompanyName, context_path, TempHistoryIDs, dataList, PrintIDList, tdWidth, tdHeight;
        $(function () {
            PrintIDList = [];
            tdWidth = $("#<%=this.tdWidth.ClientID%>")
            tdHeight = $("#<%=this.tdHeight.ClientID%>")
            $('#innerTable').css('width', '90%');
            $('#innerTable').css('margin', '0 auto');
            CompanyName = "<%=Web.WebUtil.GetCompany(this.Context).CompanyName%>";
            TempHistoryIDs = "<%=this.IDs%>";
            context_path = '<%=base.GetContextPath()%>';
            GenerateTable();
            $('.realMoneyCost1Css').bind('input propertychange', function () {
                var index = $(this).attr('data-index');
                var realCost = $(this).attr('data-cost');
                var realCost1 = $(this).val();
                var realCost2 = realCost - realCost1;
                $('#' + index + '_tdRealMoneyCost2').val(realCost2);
            });
            $('.realMoneyCost2Css').bind('input propertychange', function () {
                var index = $(this).attr('data-index');
                var realCost = $(this).attr('data-cost');
                var realCost2 = $(this).val();
                var realCost1 = realCost - realCost2;
                $('#' + index + '_tdRealMoneyCost1').val(realCost1);
            });
        })
        function GenerateTable() {
            var options = { visit: "loadtempprintchargefee", IDs: TempHistoryIDs, RoomID: "<%=this.RoomID%>" };
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
                    dataList = message.list;
                    var $html = '';
                    $.each(dataList, function (index2, data) {
                        var pageWidth = data.pageWidth || 210;
                        var pageHeigth = data.pageHeight || 99;
                        tdWidth.val(pageWidth);
                        tdHeight.val(pageHeigth);
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
                        totallines = 1000;
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
                        $html += '<tr><td style="height:' + pageHeigth + 'mm;vertical-align:top;padding: ' + top_height + ' 0 0 0;">';
                        if (data.LogoPath && data.LogoPath != '' && data.LogoPath != null) {
                            $html += '<div class="companylogo">';
                            if (data.LogoWidth > 0 && data.LogoHeight > 0) {
                                $html += ' <img src="' + context_path + data.LogoPath + '" style="width:' + data.LogoWidth + 'px;height:' + data.LogoHeight + 'px" />';
                            } else {
                                $html += ' <img src="' + context_path + data.LogoPath + '" />';
                            }
                            $html += '</div>';
                        }
                        $html += '<table class="sfxm" style="width:100%;">';
                        $html += '<tr>';
                        $html += '<th colspan="' + totalcolumns + '" class="skdh finalfont" style="font-size:' + data.PrintFont + ';">';
                        $html += '收款单号: ';
                        $html += '<input type="text" id="' + index2 + '_tdPrintNumber" class="textbox finalfont" value="' + data.PrintNumber + '" />';
                        $html += '</th>';
                        $html += '</tr>';
                        $html += '<tr>';
                        $html += '<th colspan="' + totalcolumns + '" class="systitle">';
                        $html += '<input type="text" id="' + index2 + 'tdFirstTitle" class="finalfont" value="' + data.CompanyName + '" />';
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
                        $html += '资源地址: ';
                        $html += '<input type="text" id="' + index2 + '_tdRoomFullName" value="' + data.FullName + '" />';
                        $html += '</td>';
                        $html += '<td style="width:35%;font-size:' + data.PrintFont + ';" class="khxm finalfont">';
                        $html += '客户名称: ';
                        $html += '<input type="text" id="' + index2 + '_tdRoomOwnerName" value="' + data.OwnerName + '" />';
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
                        $.each(data.list, function (index, item) {
                            if (index % totallines == 0) {
                                pagecount++;
                                pagecost = 0;
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

                                $html += '<td>' + (parseFloat(item.TotalRealCost) < 0 ? 0 : toThousands(item.TotalRealCost)) + '</td>';
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
                                $html += '<td>' + item.Remark + beilv_remark + '</td>';
                            }
                            $html += '</tr>';
                            pagecost += (parseFloat(item.RealCost) < 0 ? 0 : parseFloat(item.RealCost));
                        })
                        $html += '<tr class="haveborder">';
                        $html += '<td colspan="' + totalcolumns + '" style="padding:0;">';
                        $html += '<table class="innertable finalfont" style="font-size:' + data.PrintFont + ';">';
                        $html += '<tr>';
                        //$html += '<td style="width:15%;border-left:none;">应收合计（大写）';
                        //$html += '</td>';
                        //$html += '<td style="width:20%">' + data.printhistory.CostCapital + '</td>';
                        $html += '<td style="width:40%;border-left:none;">应收合计 ';
                        $html += '￥' + (Number(data.Cost) < 0 ? 0 : toThousands(data.Cost)) + '</td>';
                        $html += '<td style="width:50%;border-right:none;text-align:left;">';
                        $html += '实收合计 ￥' + toThousands(data.RealCost) + '&nbsp;&nbsp;&nbsp;&nbsp;';
                        //$html += '预收 ￥' + data.printhistory.PreChargeMoney.toFixed(2) + '&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;';
                        //$html += '找零 ￥' + data.printhistory.ChargeBackMoney.toFixed(2);
                        if (data.ShowWeiShu) {
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
                        if (data.EnableChargeMan) {
                            $html += '<input style="width:80px;" type="text" id="' + index2 + '_tdChargeMan" value="' + data.ChargeMan + '" />';
                        }
                        else {
                            $html += data.ChargeMan;
                        }
                        $html += '&nbsp;&nbsp;&nbsp;&nbsp;收款日期: ';
                        if (data.EnableChargeTime) {
                            $html += '<input style="width:150px;height:25px;line-height:25px;" type="text" class="easyui-datetimebox" id="' + index2 + '_tdChargeTime" value="' + data.ChargeTime + '" />';
                        }
                        else {
                            $html += data.ChargeTime;
                        }
                        $html += '&nbsp;&nbsp;&nbsp;&nbsp收款方式: ';
                        $html += '<input style="width:100px;height:25px;line-height:25px;" type="text" class="easyui-combobox ChargeMoneyType" id="' + index2 + '_tdChargeMoneyType1" />';
                        if (data.PrintChargeTypeCount >= 2) {
                            $html += '￥<input style="width:100px;" type="text" id="' + index2 + '_tdRealMoneyCost1" value="' + (Number(data.RealCost) < 0 ? 0.00 : data.RealCost) + '" data-index="' + index2 + '" data-cost="' + data.RealCost + '" class="realMoneyCost1Css" />';
                            $html += '&nbsp;&nbsp;&nbsp;&nbsp;';
                            $html += '<input style="width:100px;height:25px;line-height:25px;" type="text" class="easyui-combobox ChargeMoneyType" id="' + index2 + '_tdChargeMoneyType2" />';
                            $html += '￥<input style="width:100px;" type="text" id="' + index2 + '_tdRealMoneyCost2" value="0.00" data-index="' + index2 + '" data-cost="' + data.RealCost + '" class="realMoneyCost2Css" />';
                        } else {
                            $html += '￥' + (Number(data.RealCost) < 0 ? 0.00 : toThousands(data.RealCost));
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
                        $html += '<td style="width: 100%;word-wrap:break-word; word-break:break-all;">备注:';
                        $html += '<textarea id="' + index2 + '_tdRemark" type="text" style="height: 30px; line-height: 20px;width:90%;" value="' + data.Remark + '"></textarea>';
                        $html += '</td>';
                        $html += '</tr>';
                        $html += '</table>';
                        $html += '</th>';
                        $html += '</tr>';
                        $html += '</table>';
                        $html += '</td></tr>';
                    })
                    $("#innerTable").html($html);
                    $.parser.parse('#innerTable');
                    $('.ChargeMoneyType').combobox({
                        editable: false,
                        data: message.ChargeItems,
                        valueField: "ID",
                        textField: "Name"
                    })

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
        function startPrint() {
            pageWidth = tdWidth.val();
            pageHeight = tdHeight.val();
            if (pageWidth == "") {
                alert("纸张宽度不能为空");
                return;
            }
            if (pageHeight == "") {
                alert("纸张高度不能为空");
                return;
            }
            MaskUtil.mask('body', '打印中');
            var iframe = document.getElementById("myframe");
            var url = "printchargefeeview.aspx?PrintID=" + PrintIDList[0] + "&PageWidth=" + pageWidth + "&PageHeight=" + pageHeight;
            iframe.src = url;
            if (iframe.attachEvent) {
                iframe.attachEvent("onload", function () {
                    MaskUtil.unmask();
                    setTimeout(function () {
                        var strHtml = iframe.contentWindow.document.documentElement.innerHTML;
                        LODOPPrint(strHtml);
                    }, 1000);
                });
            } else {
                iframe.onload = function () {
                    MaskUtil.unmask();
                    setTimeout(function () {
                        var strHtml = iframe.contentWindow.document.documentElement.innerHTML;
                        LODOPPrint(strHtml);
                    }, 1000);
                };
            }
        }
        function LODOPPrint(strHtml) {
            var LODOP = null;
            try {
                LODOP = getLodop();
                if ((LODOP != null) && (typeof (LODOP.VERSION) != "undefined")) {
                    LODOP.PRINT_INIT("打印单据_收款单");
                    LODOP.SET_PRINT_PAGESIZE(1, pageWidth + 'mm', pageHeight + 'mm', '')
                    LODOP.ADD_PRINT_TABLE(0, '3%', '94%', '100%', strHtml);
                    LODOP.PREVIEW();
                }
                else {
                    alert("Error:该浏览器不支持打印插件!");
                }
            } catch (err) {
                alert("Error:本机未安装或需要升级!");
            }
        }
        function GetSelectedPrintIDList() {
            return PrintIDList;
        }
    </script>
    <script src="../js/Page/Print/printchargefeenew.js?v=<%=base.getToken()%>"></script>
    <style>
        .kskd {
            width: 96%;
            margin: 0 auto;
            font-size: 12px;
            border-bottom: solid 1px #808080;
            padding: 10px 0;
        }

        input[type="text"], textarea {
            border: none;
            border-bottom: solid 1px #ccc;
            font-size: 12px;
            font-family: 'Microsoft YaHei';
        }

        .systitle, .systitle input {
            font-size: 20px;
            text-align: center;
            font-weight: normal;
        }

        .fjdz input {
            border: none;
            border-bottom: solid 1px #cccccc;
            border-radius: 0 !important;
            box-shadow: none !important;
            color: inherit;
            font-family: inherit;
            font-size: inherit;
            padding: 0;
            width: 70%;
        }

        .khxm {
            text-align: right;
            font-weight: normal;
            width: 35%;
        }

            .khxm input {
                border: none;
                border-bottom: solid 1px #cccccc;
                border-radius: 0 !important;
                box-shadow: none !important;
                color: inherit;
                font-family: inherit;
                font-size: inherit;
                padding: 0;
                width: 70%;
            }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
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
    <div class="operation_box">
        <%if (this.CanPrintCheque)
          { %>
        <a href="javascript:void(0)" onclick="printcheque()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-print'">打印发票</a>
        <%} %>
        <a href="javascript:void(0)" onclick="printpage()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-print'">保存并打印</a>
        <a href="javascript:void(0)" onclick="savedata()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-save'">保存</a>
        <a href="javascript:void(0)" onclick="cancelFee()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-close'">关闭</a>
    </div>
    <div class="table_container">
        <div>
            纸张宽度：<input type="text" id="tdWidth" runat="server" />mm
            纸张高度：<input type="text" id="tdHeight" runat="server" />mm
        </div>
        <div class="kskd">
            开收款单
        </div>
        <table id="innerTable">
        </table>
    </div>
    <iframe name="myiframe" id="myframe" style="display: none;" src="" width="100%" height="100%"></iframe>
</asp:Content>
