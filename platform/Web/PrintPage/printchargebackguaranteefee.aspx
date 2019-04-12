<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="printchargebackguaranteefee.aspx.cs" Inherits="Web.PrintPage.printchargebackguaranteefee" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        var AddMan;
        var PrintID, PrintNumber, ChargeMan, ChargeTime, Remark, Cost, hdChargeMoneyType, FullName, MoneyDaXie, GUID, pageWidth, pageHeight, hdOrderNumberID, RoomFullName, RoomOwnerName;
        $(function () {
            AddMan = "<%=Web.WebUtil.GetUser(this.Context).RealName%>";
            PrintID = "<%=this.printRoomFeeHistory.ID%>";
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
        })
    </script>
    <script src="../js/Page/Print/printchargebackguaranteefee.js?v=<%=base.getToken() %>"></script>
    <script src="../js/Lodop/LodopFuncs.js?t=<%=base.getToken() %>"></script>
    <script type="text/javascript">
        function printpage() {
            saveprocess(false);
        }
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
            var iframe = document.getElementById("myframe");
            var url = "printchargebackguaranteefeeview.aspx?PrintID=" + PrintID + "&PageWidth=" + pageWidth + "&PageHeight=" + pageHeight;
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
                    LODOP.PRINT_INIT("打印单据_付款单");
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
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <form id="form1" runat="server">
        <div class="operation_box">
            <a href="javascript:void(0)" onclick="printpage()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-print'">打印</a>
            <a href="javascript:void(0)" onclick="savedata()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-save'">保存</a>
            <asp:HiddenField ID="hdOrderNumberID" runat="server" />
            <a href="javascript:void(0)" onclick="cancelFee()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-close'">关闭</a>
        </div>
        <div class="table_container">
            <div>
                纸张宽度：<input type="text" id="tdWidth" runat="server" />mm
            纸张高度：<input type="text" id="tdHeight" runat="server" />mm
            </div>
            <div class="kskd">
                退保证金
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


                            table.sfxm tr.haveborder td {
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
                                width: 5%;
                            }

                        .skr input, .skrq input, .skfs input, .zhekou input {
                            width: 100%;
                            border-radius: 0 !important;
                            box-shadow: none !important;
                            color: inherit;
                            font-family: inherit;
                            font-size: inherit;
                            padding: 0;
                        }

                        .shuoming {
                            width: 100%;
                            text-align: left;
                            font-weight: normal;
                        }

                            .shuoming input {
                                width: 95%;
                            }

                        .opeation {
                            text-align: center;
                            margin-top: 50px;
                        }
                    </style>
                    <table class="sfxm">
                        <thead>
                            <tr>
                                <th colspan="5" class="skdh">付款单号:
                <input type="text" id="tdPrintNumber" runat="server" />
                                </th>
                            </tr>
                            <tr>
                                <th colspan="7" class="systitle">
                                    <label id="tdFirstTitle" runat="server"></label>
                                </th>
                            </tr>
                            <tr>
                                <th colspan="7" class="sksj">
                                    <label id="tdSubTitle" runat="server"></label>
                                </th>
                            </tr>
                            <tr>
                                <th colspan="4" class="fjdz">资源地址:                
                                <input value="<%=this.FullName %>" id="tdRoomFullName" type="text" />
                                </th>
                                <th colspan="3" class="khxm">客户名称:                
                                <input value="<%=this.OwnerName %>" id="tdRoomOwnerName" type="text" />
                                </th>
                            </tr>
                            <tr class="haveborder">
                                <th style="width: 15%">应付年月
                                </th>
                                <th style="width: 15%">付款科目
                                </th>
                                <th style="width: 10%">实付金额
                                </th>
                                <th colspan="3" style="width: 45%">应付说明
                                </th>
                                <th style="width: 15%">扣款说明
                                </th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater runat="server" ID="rptProject">
                                <ItemTemplate>
                                    <tr class="haveborder">
                                        <td id="chargetime_<%# Container.ItemIndex + 1%>"><%# ((DateTime)Eval("ChargeTime")) == DateTime.MinValue ? "" : Eval("ChargeTime", "{0:yyyy-MM}")%>
                                        </td>
                                        <td id="chargename_<%# Container.ItemIndex + 1%>">退<%# Eval("ChargeName")%>
                                        </td>
                                        <td>
                                            <input type="text" data-id="<%#Eval("HistoryID") %>" data-index="<%# Container.ItemIndex + 1%>" class="realcost realcost_<%# Container.ItemIndex + 1%>" value='<%# (decimal)Eval("RealCost")%>' style="width: 100%; text-align: center; border: 0px; border-bottom: solid 1px #000;" />
                                        </td>
                                        <td colspan="3">
                                            <input type="text" id="backremark_<%# Container.ItemIndex + 1%>" style="width: 100%; text-align: center; border: 0px;" value=' <%# ((DateTime)Eval("ChargeTime")) == DateTime.MinValue ? "" : Eval("ChargeTime", "{0:yyyy-MM-dd}")%> 收 <%# Eval("ChargeName")%> 收款单号 <%# Eval("PrintNumber")%> 收款人 <%# Eval("ChargeMan")%>' />
                                        </td>
                                        <td>
                                            <input type="text" id="remark_<%# Container.ItemIndex + 1%>" style="width: 100%; text-align: center; border: 0px;" value='<%# Eval("Remark")%>' />
                                        </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </tbody>
                        <tfoot>
                            <tr>
                                <th colspan="7">
                                    <table class="skxx">
                                        <tr>
                                            <td style="width: 20%;">付款人                                           
                                            <input id="tdChargeMan" runat="server" type="text" /></td>
                                            <td style="width: 25%;">付款时间
                                            <input style="width: 150px;" id="tdChargeTime" class="easyui-datetimebox" runat="server" type="text" /></td>
                                            <td style="width: 25%;">实付合计
                                            <span id="tdRealPayCost">￥<%= Web.WebUtil.FormatMoney(this.money) %></span>
                                            </td>
                                            <td style="width: 30%;">付款方式: 
                                            <input class="easyui-combobox" id="tbChargeMoneyType" style="width: 100px; height: 25px;" />
                                            </td>
                                            <asp:HiddenField runat="server" ID="hdChargeMoneyType" />
                                        </tr>
                                    </table>
                                </th>
                            </tr>
                            <tr>
                                <th class="shuoming" colspan="7">说明:<input id="tdRemark" runat="server" type="text" />
                                </th>
                            </tr>
                        </tfoot>
                    </table>
                </div>
            </div>
        </div>
    </form>
    <iframe name="myiframe" id="myframe" style="display: none;" src="" width="100%" height="100%"></iframe>
</asp:Content>
