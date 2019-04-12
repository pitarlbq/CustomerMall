<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="printchargefee.aspx.cs" Inherits="Web.PrintPage.printchargefee" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        var PrintID, PrintNumber, RealCost, PreChargeMoney, ChargeBackMoney, ChargeMan, ChargeTime, RealMoneyCost1, ChargeMoneyType1, RealMoneyCost2, ChargeMoneyType2, DiscountMoney, Remark, AddMan, Cost, WeiShu, hdWeiShu, TempHistoryIDs, money, MoneyDaXie, pageWidth, pageHeight, hdOrderNumberID, RoomFullName, RoomOwnerName, tdWeiShu, TotalCost, LogoWidth, LogoHeight, tdFirstTitle, tdSubTitle, RoomID, DefaultRelationID, ContractID, PrintChargeTypeCount;
        $(function () {
            RoomID = "<%=this.RoomID%>";
            DefaultRelationID = "<%=this.DefaultRelationID%>";
            ContractID = "<%=this.ContractID%>";
            PrintID = "<%=this.PrintID%>";
            tdFirstTitle = $("#<%=this.tdFirstTitle.ClientID%>");
            tdSubTitle = $("#<%=this.tdSubTitle.ClientID%>");
            PrintNumber = $("#<%=this.tdPrintNumber.ClientID%>");
            tdRealCost = $("#<%=this.tdRealCost.ClientID%>");
            PreChargeMoney = $("#<%=this.tdPreChargeMoney.ClientID%>");
            ChargeBackMoney = $("#<%=this.tdChargeBackMoney.ClientID%>");
            ChargeMan = $("#<%=this.tdChargeMan.ClientID%>");
            ChargeTime = $("#<%=this.tdChargeTime.ClientID%>");
            RealMoneyCost1 = $("#<%=this.tdRealMoneyCost1.ClientID%>");
            ChargeMoneyType1 = $("#<%=this.tdChargeMoneyType1.ClientID%>");
            RealMoneyCost2 = $("#<%=this.tdRealMoneyCost2.ClientID%>");
            ChargeMoneyType2 = $("#<%=this.tdChargeMoneyType2.ClientID%>");
            DiscountMoney = $("#<%=this.tdDiscountMoney.ClientID%>");
            Remark = $("#<%=this.tdRemark.ClientID%>");
            AddMan = "<%=Web.WebUtil.GetUser(this.Context).RealName%>";
            RealCost = "<%=this.RealCost%>";
            TotalCost = "<%=this.TotalCost%>";
            WeiShu = $("#<%=this.tdWeiShu.ClientID%>");
            hdWeiShu = $("#<%=this.hdWeiShu.ClientID%>");
            TempHistoryIDs = "<%=Request.QueryString["IDs"]%>";
            money = "<%=this.money%>";
            MoneyDaXie = "<%=this.MoneyDaXie%>";
            hdOrderNumberID = $("#<%=this.hdOrderNumberID.ClientID%>");
            RoomFullName = $("#tdRoomFullName");
            RoomOwnerName = $("#tdRoomOwnerName");
            tdWeiShu = $("#<%=this.tdWeiShu.ClientID%>");
            if (Remark.val().indexOf('\n') == -1) {
                $('.shuoming textarea').css('height', '30px');
                $('.shuoming textarea').css('line-height', '30px');
                $('.shuoming label').css('line-height', '30px');
            }
            else {
                $('.shuoming textarea').css('height', '45px');
                $('.shuoming label').css('line-height', '45px');
            }
            LogoWidth = "<%=this.LogoWidth%>";
            LogoHeight = "<%=this.LogoHeight%>";
            if (LogoWidth > 0 && LogoHeight > 0) {
                $('.companylogo img').css('width', LogoWidth + 'px');
                $('.companylogo img').css('height', LogoHeight + 'px');
            }
            PrintChargeTypeCount = "<%=this.PrintChargeTypeCount%>";
            if (Number(PrintChargeTypeCount) == 1) {
                $('.chargeType2').hide();
            }
        })
    </script>
    <script src="../js/Page/Print/printchargefee.js?v=<%=base.getToken()%>"></script>
    <script src="../js/Lodop/LodopFuncs.js?t=<%=base.getToken() %>"></script>
    <script type="text/javascript">
        $(function () {
            var printfont = "<%=this.PrintFont%>";
            if (printfont != '') {
                //$('.finalfont').css('font-size', printfont);
            }
        })
        function startPrint() {
            pageWidth = $("#<%=this.tdWidth.ClientID%>").val();
            pageHeight = $("#<%=this.tdHeight.ClientID%>").val();
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
            var url = "printchargefeeview.aspx?PrintID=" + PrintID + "&PageWidth=" + pageWidth + "&PageHeight=" + pageHeight;
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
    </script>
    <style type="text/css">
        body {
            background: #fff;
        }

        .content {
            width: 96%;
            margin: 0 auto;
            font-size: 12px;
            position: relative;
        }

            .content .companylogo {
                position: absolute;
                top: 5px;
                left: 5px;
                min-width: 100px;
            }

                .content .companylogo img {
                    width: 60px;
                    height: 60px;
                }

        .kskd {
            width: 96%;
            margin: 0 auto;
            font-size: 12px;
            border-bottom: solid 1px #808080;
            padding: 10px 0;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <form id="form1" runat="server">
        <div class="easyui-layout" data-options="fit:true" id="main_layout_content">
            <div data-options="region:'center',border:false">
                <div id="main_form" style="height: 100%;">
                    <div class="operation_box">
                        <%if (this.CanPrintCheque)
                          { %>
                        <a href="javascript:void(0)" onclick="printcheque()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-print'">打印发票</a>
                        <%} %>
                        <a href="javascript:void(0)" onclick="printpage()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-print'">保存并打印</a>
                        <a href="javascript:void(0)" onclick="savedata()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-save'">保存</a>
                        <a href="javascript:void(0)" onclick="cancelFee()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-close'">关闭</a>
                        <asp:HiddenField ID="hdOrderNumberID" runat="server" />
                    </div>
                    <div class="table_container">
                        <div>
                            纸张宽度：<input type="text" id="tdWidth" runat="server" />mm
            纸张高度：<input type="text" id="tdHeight" runat="server" />mm
                        </div>
                        <div class="kskd">
                            开收款单
                        </div>
                        <div class="wrap" id="print_wrap">
                            <div class="content" id="print_content">
                                <style type="text/css">
                                    td > label, th > label {
                                        font-size: 12px;
                                    }

                                    input[type="text"], textarea {
                                        border: none;
                                        border-bottom: solid 1px #ccc;
                                        font-size: 12px;
                                        font-family: 'Microsoft YaHei';
                                    }

                                    table.sfxm {
                                        margin-top: 5px;
                                        width: 100%;
                                        border-collapse: collapse;
                                        border-spacing: 0;
                                        font-size: 12px;
                                        font-family: 'Microsoft YaHei';
                                        font-weight: normal;
                                    }

                                        table.sfxm thead, table.sfxm tbody, table.sfxm tfoot {
                                            padding: 0;
                                        }


                                        table.sfxm tr.haveborder td, table.sfxm tr.haveborder th {
                                            text-align: center;
                                            border: solid #cccccc;
                                            border-width: 1px;
                                            padding: 0;
                                            font-weight: normal;
                                        }

                                        table.sfxm tr.haveborder th {
                                            text-align: center;
                                            border: solid #cccccc;
                                            border-width: 1px 1px 0px 1px;
                                            padding: 0;
                                        }

                                        table.sfxm tfoot tr.haveborder th.lefttd {
                                            text-align: left;
                                        }



                                    .skdh {
                                        margin: 20px 0 0 0;
                                        text-align: right;
                                        font-weight: normal;
                                    }

                                        .skdh input {
                                            border: none;
                                            border-bottom: solid 1px #cccccc;
                                            background-color: inherit;
                                            border-radius: 0 !important;
                                            box-shadow: none !important;
                                            color: inherit;
                                            font-family: inherit;
                                            font-size: inherit;
                                            padding: 0;
                                        }

                                    .systitle, .systitle input {
                                        font-size: 20px;
                                        text-align: center;
                                        font-weight: normal;
                                    }

                                        .systitle label {
                                            font-size: 20px;
                                        }

                                    .sksj {
                                        font-size: 14px;
                                        text-align: center;
                                        font-weight: normal;
                                    }

                                    .fjdz {
                                        text-align: left;
                                        font-weight: normal;
                                        display: inline-table;
                                        width: 60%;
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
                                        display: inline-table;
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

                                    .clear {
                                        clear: both;
                                    }



                                    input.shoudao {
                                        width: 50px;
                                        border: none;
                                        border-bottom: solid 1px #ccc;
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
                                            border: solid 1px #ccc;
                                        }

                                    table.skxx td {
                                        text-align: left;
                                        font-weight: normal;
                                    }

                                        table.skxx td.skr {
                                            width: 10%;
                                        }

                                        table.skxx td.skfs, table.skxx td.zhekou {
                                            width: 10%;
                                        }

                                    .skr .textbox, .skdh .textbox {
                                        border: 0px;
                                        border-radius: 0px;
                                        border-bottom: 1px solid #ccc;
                                    }

                                    .skr input, .skrq input, .skfs input, .zhekou input {
                                        width: 70%;
                                        background-color: inherit;
                                        border-radius: 0 !important;
                                        box-shadow: none !important;
                                        color: inherit;
                                        font-family: inherit;
                                        font-size: inherit;
                                        padding: 0;
                                        border: 0px;
                                    }

                                    .shuoming {
                                        width: 100%;
                                        text-align: left;
                                        font-weight: normal;
                                    }

                                        .shuoming textarea {
                                            width: 95%;
                                            padding: 0;
                                        }

                                    .opeation {
                                        text-align: center;
                                        margin-top: 50px;
                                    }
                                </style>
                                <%if (!string.IsNullOrEmpty(this.LogoPath))
                                  { %>
                                <div class="companylogo">
                                    <img src="<%=base.GetContextPath() + this.LogoPath%>" />
                                </div>
                                <%} %>
                                <table class="sfxm finalfont">
                                    <thead>
                                        <tr>
                                            <th colspan="<%=this.ColumnCount%>" class="skdh finalfont">收款单号:
                <input type="text" id="tdPrintNumber" class="textbox finalfont" runat="server" />
                                                <%if (!base.CheckAuthByModuleCode("1191146"))
                                                  { %>
                                                <script>
                                                    $(function () {
                                                        $('#<%=this.tdPrintNumber.ClientID%>').textbox({
                                                            readonly: true
                                                        });
                                                    })
                                                </script>
                                                <%} %>
                                            </th>
                                        </tr>
                                        <tr>
                                            <th colspan="<%=this.ColumnCount%>" class="systitle">
                                                <input type="text" id="tdFirstTitle" runat="server" class="finalfont" />
                                                <%--<div id="" class="finalfont" runat="server"></div>--%>
                                            </th>
                                        </tr>
                                        <tr>
                                            <th colspan="<%=this.ColumnCount%>" class="sksj finalfont">
                                                <div id="tdSubTitle" class="finalfont" runat="server"></div>
                                            </th>
                                        </tr>
                                        <tr>
                                            <th colspan="<%=this.ColumnCount%>" style="width: 100%; padding-bottom: 5px;">
                                                <div class="fjdz finalfont">
                                                    资源地址: 
                <input value="<%=this.FullName%>" id="tdRoomFullName" type="text" />
                                                </div>
                                                <div class="khxm finalfont">
                                                    客户名称: 
                <input value="<%=this.OwnerName%>" id="tdRoomOwnerName" type="text" />
                                                </div>
                                            </th>
                                        </tr>
                                        <tr class="haveborder">
                                            <%if (IsPrintRoomNo)
                                              { %>
                                            <th>资源编号
                                            </th>
                                            <%}
                                            %>
                                            <th>收费项目
                                            </th>
                                            <%if (IsPrintUnitPrice)
                                              { %>
                                            <th>单价
                                            </th>
                                            <%}
                                            %>
                                            <th>面积/用量
                                            </th>
                                            <%if (IsPrintCost)
                                              { %>
                                            <th>应收金额
                                            </th>
                                            <%}
                                            %>
                                            <%if (IsPrintDiscount)
                                              { %>
                                            <th>减免金额
                                            </th>
                                            <%}
                                            %>
                                            <%if (IsPrintRealCost)
                                              { %>
                                            <th>实收金额
                                            </th>
                                            <%}
                                            %>
                                            <%if (IsPrintTotalRealCost)
                                              { %>
                                            <th>已收金额
                                            </th>
                                            <%}
                                            %>
                                            <th>计费开始日期
                                            </th>
                                            <th>计费结束日期
                                            </th>
                                            <%if (IsPrintMonthCount)
                                              { %>
                                            <th>月数
                                            </th>
                                            <%}%>
                                            <%if (IsPrintCount)
                                              { %>
                                            <th>上次/本次读数
                                            </th>
                                            <%}
                                            %>
                                            <%if (this.IsPrintNote)
                                              { %>
                                            <th>备注
                                            </th>
                                            <%}
                                            %>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <asp:Repeater runat="server" ID="rptProject" OnItemDataBound="rptProject_ItemDataBound">
                                            <ItemTemplate>
                                                <tr class="haveborder">
                                                    <%if (IsPrintRoomNo)
                                                      { %>
                                                    <td><%#Eval("RoomName")%>
                                                    </td>
                                                    <%}
                                                    %>
                                                    <td><%#Eval("ChargeName")%>
                                                    </td>
                                                    <%if (IsPrintUnitPrice)
                                                      { %>
                                                    <td><%#Convert.ToDecimal(Eval("UnitPrice")) < 0 ? "0.00" : Web.WebUtil.FormatMoney((decimal)Eval("UnitPrice"), 4)%>
                                                    </td>
                                                    <%}
                                                    %>
                                                    <td><%#Convert.ToDecimal(Eval("UseCount")) < 0 ? "0.00" : Eval("UseCount")%>
                                                    </td>
                                                    <%if (IsPrintCost)
                                                      { %>
                                                    <td><%#Convert.ToDecimal(Eval("Cost")) < 0 ? "0.00" : Web.WebUtil.FormatMoney((decimal)Eval("Cost"))%>
                                                    </td>
                                                    <%}
                                                    %>
                                                    <%if (IsPrintDiscount)
                                                      { %>
                                                    <td><%#Convert.ToDecimal(Eval("Discount")) < 0 ? "0.00" : Eval("Discount")%>
                                                    </td>
                                                    <%}
                                                    %>
                                                    <%if (IsPrintRealCost)
                                                      { %>
                                                    <td><%#Convert.ToDecimal(Eval("RealCost")) < 0 ? "0.00" : Web.WebUtil.FormatMoney((decimal)Eval("RealCost"))%>
                                                    </td>
                                                    <%}
                                                    %>
                                                    <%if (IsPrintTotalRealCost)
                                                      { %>
                                                    <td><%#Convert.ToDecimal(Eval("TotalRealCost")) < 0 ? "0.00" : Web.WebUtil.FormatMoney((decimal)Eval("TotalRealCost"))%>
                                                    </td>
                                                    <%} %>
                                                    <td><%# ((DateTime)Eval("StartTime")) == DateTime.MinValue ? "" : Eval("StartTime", "{0:yyyy-MM-dd}")%>
                                                    </td>
                                                    <td><%# ((DateTime)Eval("EndTime")) == DateTime.MinValue ? "" : Eval("EndTime", "{0:yyyy-MM-dd}")%>
                                                    </td>
                                                    <%if (IsPrintMonthCount)
                                                      { %>
                                                    <td>
                                                        <%#Convert.ToDecimal(Eval("CalculateMonthCount"))%>
                                                    </td>
                                                    <%}%>
                                                    <%if (IsPrintCount)
                                                      { %>
                                                    <td><%#(decimal)Eval("FinalStartPoint") + "/" + (decimal)Eval("FinalEndPoint")%><%#((int)Eval("ProjectBiaoID") > 0 && (decimal)Eval("ImportRate") > 0) ? "(倍率:" + ((decimal)Eval("ImportRate")).ToString("g0") + ")" : ""%>
                                                    </td>
                                                    <%}
                                                      if (IsPrintNote)
                                                      { %>
                                                    <td><%#Eval("Remark")%><%#((int)Eval("ProjectBiaoID") > 0 && (decimal)Eval("ImportRate") > 0) ? "(表名称:" + ((string)Eval("ImportBiaoName")) + ")" : ""%>
                                                    </td>
                                                    <%}
                                                    %>
                                                </tr>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                        <tr class="haveborder">
                                            <%--<td class="lefttd" colspan="2">应收合计（大写）
                            </td>
                            <td class="lefttd" colspan="2"><%=this.MoneyDaXie %></td>--%>
                                            <td class="lefttd">应收合计
                                            </td>
                                            <td class="lefttd" colspan="2">￥<%=Web.WebUtil.FormatMoney(this.TotalCost)%></td>
                                            <td class="lefttd" colspan="<%=this.ColumnCount - 3%>">实收合计 ￥<label id="formatRealCost" runat="server" type="text" class="shoudao"></label>&nbsp;&nbsp;&nbsp;&nbsp;
                                <label id="tdRealCost" runat="server" style="display: none;"></label>
                                                <label style="display: none;">
                                                    预收
                                    <input type="text" value="0.00" class="shoudao" runat="server" id="tdPreChargeMoney" />
                                                    找零
                                    <input type="text" value="0.00" class="shoudao" runat="server" id="tdChargeBackMoney" />
                                                </label>
                                                <%if (this.ShowWeiShu)
                                                  { %>
                                    尾数余额 ￥<label type="text" class="shoudao" runat="server" id="tdWeiShu"></label>
                                                <asp:HiddenField ID="hdWeiShu" runat="server" />
                                                <%} %>
                                            </td>
                                        </tr>
                                    </tbody>
                                    <tfoot>
                                        <tr>
                                            <th colspan="<%=this.ColumnCount%>">
                                                <table class="skxx finalfont">
                                                    <tr>
                                                        <td>收款人: </td>
                                                        <td class="skr">
                                                            <input id="tdChargeMan" style="width: 100px;" class="textbox" runat="server" type="text" />
                                                            <%if (!base.CheckAuthByModuleCode("1191144"))
                                                              { %>
                                                            <script>
                                                                $(function () {
                                                                    $('#<%=this.tdChargeMan.ClientID%>').textbox({
                                                                        readonly: true
                                                                    });
                                                                })
                                                            </script>
                                                            <%} %>
                                                        </td>
                                                        <td>收款日期: </td>
                                                        <td class="skrq">
                                                            <input style="width: 150px;" id="tdChargeTime" class="easyui-datetimebox" runat="server" type="text" />
                                                            <%if (!base.CheckAuthByModuleCode("1191145"))
                                                              { %>
                                                            <script>
                                                                $(function () {
                                                                    $('#<%=this.tdChargeTime.ClientID%>').datetimebox({
                                                                        readonly: true
                                                                    });
                                                                })
                                                            </script>
                                                            <%} %>
                                                        </td>
                                                        <td>收款方式: </td>
                                                        <td>
                                                            <input class="easyui-combobox" id="tdChargeMoneyType1" runat="server" style="width: 100px; height: 25px;" />
                                                        </td>
                                                        <td class="skfs">&nbsp;&nbsp;￥<input id="tdRealMoneyCost1" runat="server" class="xjje" /></td>
                                                        <td class="chargeType2">
                                                            <input class="easyui-combobox" runat="server" id="tdChargeMoneyType2" style="width: 100px; height: 25px;" />
                                                        </td>
                                                        <td class="skfs chargeType2">&nbsp;&nbsp;￥<input id="tdRealMoneyCost2" runat="server" class="xjje" /></td>
                                                        <td style="width: 30px; display: none;">优惠: </td>
                                                        <td class="zhekou" style="display: none;">&nbsp;&nbsp;￥<input id="tdDiscountMoney" runat="server" type="text" value="0.00" /></td>
                                                    </tr>
                                                </table>
                                            </th>
                                        </tr>
                                        <tr>
                                            <th class="shuoming" colspan="<%=this.ColumnCount%>">
                                                <label style="vertical-align: top;">说明: </label>
                                                <textarea id="tdRemark" runat="server" type="text"></textarea>
                                            </th>
                                        </tr>
                                    </tfoot>
                                </table>
                            </div>
                        </div>
                    </div>
                </div>
                <div id="dialog_form" style="display: none;">
                    <div id="dialog_title1" class="dialogtitle"></div>
                    <a href="javascript:void(0)" onclick="do_close_dialog()" class="easyui-linkbutton btntoolbar btn_dialog_close" data-options="plain:true,iconCls:'icon-close'">关闭</a>
                    <iframe id="dialog_frame1" src="" style="width: 100%; height: 0px; border: 0; position: absolute; top: 30px; left: 0; right: 0;"></iframe>
                </div>
            </div>
        </div>
    </form>
    <iframe name="myiframe" id="myframe" style="display: none;" src="" width="100%" height="100%"></iframe>
</asp:Content>
