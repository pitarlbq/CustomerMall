<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="printchargepayservice.aspx.cs" Inherits="Web.PrintPage.printchargepayservice" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        var AddMan;
        var PrintID, PrintNumber, ChargeMan, ChargeTime, Remark, Cost, hdChargeMoneyType, FullName, MoneyDaXie, GUID, pageWidth, pageHeight, hdOrderNumberID, RoomFullName, RoomOwnerName, TempHistoryID, PayServiceID, tdFirstTitle;
        $(function () {
            AddMan = "<%=Web.WebUtil.GetUser(this.Context).RealName%>";
            PrintID = "<%=this.printRoomFeeHistory.ID%>";
            TempHistoryID = "<%=this.TempHistoryID%>";
            PayServiceID = "<%=this.PayServiceID%>";
            PrintNumber = $("#<%=this.tdPrintNumber.ClientID%>");
            ChargeMan = $("#<%=this.tdChargeMan.ClientID%>");
            ChargeTime = $("#<%=this.tdChargeTime.ClientID%>");
            Remark = $("#<%=this.tdRemark.ClientID%>");
            Cost = "<%=this.money %>";
            hdChargeMoneyType = $("#<%=this.hdChargeMoneyType.ClientID%>");
            FullName = "<%=this.FullName %>";
            MoneyDaXie = "<%=this.MoneyDaXie %>";
            GUID = "<%=Request.QueryString["guid"]%>";
            hdOrderNumberID = $("#<%=this.hdOrderNumberID.ClientID%>");
            RoomFullName = $("#tdRoomFullName");
            RoomOwnerName = $("#tdRoomOwnerName");
            tdFirstTitle = $("#<%=this.tdFirstTitle.ClientID%>");
            tdSubTitle = $("#<%=this.tdSubTitle.ClientID%>");
        })
    </script>
    <script src="../js/Page/Print/printchargepayservice.js?v=<%=base.getToken() %>"></script>
    <script src="../js/Lodop/LodopFuncs.js?t=<%=base.getToken() %>"></script>
    <script type="text/javascript">
        function printpage() {
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
            var iframe = document.getElementById("myframe");
            var url = "printchargepayserviceview.aspx?PrintID=" + PrintID + "&PageWidth=" + pageWidth + "&PageHeight=" + pageHeight;
            iframe.src = url;
            if (iframe.attachEvent) {
                iframe.attachEvent("onload", function () {
                    setTimeout(function () {
                        var strHtml = iframe.contentWindow.document.documentElement.innerHTML;
                        LODOPPrint(strHtml);
                    }, 1000);
                });
            } else {
                iframe.onload = function () {
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
                    LODOP.PRINT_INIT("打印单据_退款单");
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

        .content, .kskd {
            width: 96%;
            margin: 0 auto;
            font-size: 12px;
        }

        .kskd {
            width: 96%;
            margin: 0 auto;
            font-size: 12px;
            border-bottom: solid 1px #808080;
            padding: 10px 0;
        }

        .opeation {
            text-align: center;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <form id="form1" runat="server">
        <div>
            纸张宽度：<input type="text" id="tdWidth" runat="server" />mm
            纸张高度：<input type="text" id="tdHeight" runat="server" />mm
        </div>
        <div class="kskd">
            付款单
        </div>
        <div class="wrap" id="print_wrap">
            <div class="content" id="print_content">
                <style type="text/css">
                    input[type="text"] {
                        border: none;
                        border-bottom: solid 1px #ccc;
                        font-size: 12px;
                        border-radius: 0 !important;
                        box-shadow: none !important;
                        color: inherit;
                        font-family: inherit;
                        padding: 0;
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

                        table.sfxm tr td {
                            padding: 5px 0;
                        }

                        table.sfxm tr.haveborder td {
                            text-align: center;
                            border: solid #cccccc;
                            border-width: 1px;
                            font-weight: normal;
                        }

                        table.sfxm tr.haveborder th {
                            text-align: center;
                            border: solid #cccccc;
                            border-width: 1px 1px 0px 1px;
                            font-weight: normal;
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
                            width: 120px;
                            border-radius: 0 !important;
                            box-shadow: none !important;
                            color: inherit;
                            font-family: inherit;
                            font-size: inherit;
                            padding: 0;
                        }

                    .systitle {
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
                        padding-bottom: 5px;
                    }

                        .fjdz input {
                            border: none;
                            border-bottom: solid 1px #cccccc;
                            width: 80%;
                            border-radius: 0 !important;
                            box-shadow: none !important;
                            color: inherit;
                            font-family: inherit;
                            font-size: inherit;
                            padding: 0;
                        }

                    .khxm {
                        text-align: center;
                        padding-bottom: 5px;
                        font-weight: normal;
                    }

                        .khxm input {
                            border: none;
                            border-bottom: solid 1px #cccccc;
                            width: 50%;
                            border-radius: 0 !important;
                            box-shadow: none !important;
                            color: inherit;
                            font-family: inherit;
                            font-size: inherit;
                            padding: 0;
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
                            border: solid 1px #ccc;
                        }

                    table td, table th {
                        text-align: left;
                        font-weight: normal;
                        padding: 5px 0;
                    }

                    table.skxx td.skr {
                        width: 10%;
                    }

                    table.skx td.sk s, ta le.skx td.z ekou {
                        .skr input, . krq input,;

                    {
                        bor rtant;
                        t;
                        f .shuoming t tex -alig : font weig;
                    }

                    o text-align nter; a in-top 50;;
                    }
                </style>
                <table class="sfxm">
                    <thead>
                        <tr>
                            <th colspan="4" class="skdh">付款单号:
                <input type="text" id="tdPrintNumber" runat="server" />
                            </th>
                        </tr>
                        <tr>
                            <th colspan="4" class="systitle">
                                <label id="tdFirstTitle" runat="server"></label>
                            </th>
                        </tr>
                        <tr>
                            <th colspan="4" class="sksj">
                                <label id="tdSubTitle" runat="server"></label>
                            </th>
                        </tr>
                        <tr>
                            <th colspan="3" class="fjdz">资源地址: 
                <input value="<%=this.FullName %>" id="tdRoomFullName" type="text" />
                            </th>
                            <th class="khxm">客户名称: 
                <input value="<%=this.OwnerName %>" id="tdRoomOwnerName" type="text" />
                            </th>
                        </tr>
                        <tr class="haveborder">
                            <th style="width: 20%">应付年月
                            </th>
                            <th style="width: 20%">付款科目
                            </th>
                            <th style="width: 20%">实付金额
                            </th>
                            <th style="width: 40%">应付说明
                            </th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater runat="server" ID="rptProject">
                            <ItemTemplate>
                                <tr class="haveborder">
                                    <td id="chargetime_<%# Container.ItemIndex + 1%>"><%# ((DateTime)Eval("ChargeTime")) == DateTime.MinValue ? "" : Eval("ChargeTime", "{0:yyyy-MM}")%>
                                    </td>
                                    <td id="chargename_<%# Container.ItemIndex + 1%>"><%# Eval("ChargeName")%>
                                    </td>
                                    <td id="realcost_<%# Container.ItemIndex + 1%>">
                                        <%# Web.WebUtil.FormatMoney((decimal)Eval("RealCost"))%>
                                    </td>
                                    <td>
                                        <input type="text" id="backremark_<%# Container.ItemIndex + 1%>" data-id="<%#Eval("HistoryID") %>" data-index='<%# Container.ItemIndex + 1%>' class="backremark" value='<%# Eval("Remark")%>' style="width: 100%; text-align: center; border: 0px; border-bottom: solid 0px #000;" />
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </tbody>
                    <tfoot>
                        <tr>
                            <th colspan="4" style="padding: 0;">
                                <table class="skxx">
                                    <tr>
                                        <td style="width: 20%;">付款人                                           
                                            <input id="tdChargeMan" runat="server" type="text" style="width: 50%;" /></td>
                                        <td style="width: 30%;">付款时间
                                            <input style="width: 50%;" id="tdChargeTime" class="easyui-datetimebox" runat="server" type="text" /></td>
                                        <td style="width: 20%;">实付合计
                                        ￥<%=Web.WebUtil.FormatMoney(this.money) %></td>
                                        <td style="width: 30%;">付款方式: 
                                            <input class="easyui-combobox" id="tbChargeMoneyType" style="width: 50%; height: 25px;" />
                                        </td>
                                        <asp:HiddenField runat="server" ID="hdChargeMoneyType" />
                                    </tr>
                                </table>
                            </th>
                        </tr>
                        <tr>
                            <th colspan="4" style="padding: 0;">
                                <table class="skxx">
                                    <tr>
                                        <td style="width: 70%;">说明:<input style="width: 80%;" id="tdRemark" runat="server" type="text" /></td>
                                        <td style="width: 30%;">客户签字:<input style="width: 60%;" id="tdSign" runat="server" type="text" /></td>
                                    </tr>
                                </table>
                            </th>
                        </tr>
                    </tfoot>
                </table>
            </div>
            <div class="opeation">
                <asp:HiddenField ID="hdOrderNumberID" runat="server" />
                <a href="javascript:void(0)" onclick="saveprocess(false)" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-print'">打印</a>
                <a href="javascript:void(0)" onclick="closeWin()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-close'">关闭</a>
            </div>
        </div>
    </form>
    <iframe name="myiframe" id="myframe" style="display: none;" src="" width="100%" height="100%"></iframe>
</asp:Content>
