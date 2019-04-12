<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="printoffsetchargefee.aspx.cs" Inherits="Web.PrintPage.printoffsetchargefee" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        var PrintID, PrintNumber, ChargeMan, ChargeTime, Remark, AddMan, Cost, hdOrderNumberID, money, MoneyDaXie, pageWidth, pageHeight, TempHistoryIDs, RoomFullName, RoomOwnerName, ChargeForSummary, ChargeMethods, tdFirstTitle, tdFirstTitle;
        $(function () {
            PrintID = "<%=this.printRoomFeeHistory.ID%>";
            PrintNumber = $("#<%=this.tdPrintNumber.ClientID%>");
            ChargeMan = $("#<%=this.tdChargeMan.ClientID%>");
            ChargeTime = $("#<%=this.tdChargeTime.ClientID%>");
            Remark = $("#<%=this.tdRemark.ClientID%>");
            AddMan = "<%=Web.WebUtil.GetUser(this.Context).RealName%>";
            Cost = "<%=this.TotalCost %>";
            hdOrderNumberID = $("#<%=this.hdOrderNumberID.ClientID%>");
            money = "<%=this.money%>";
            MoneyDaXie = "<%=this.MoneyDaXie%>";
            TempHistoryIDs = "<%=Request.QueryString["IDs"]%>";
            RoomFullName = $("#tdRoomFullName");
            RoomOwnerName = $("#tdRoomOwnerName");
            ChargeForSummary = $("#<%=this.tdChargeForSummary.ClientID%>");
            ChargeMethods = $("#<%=this.tdChargeMethods.ClientID%>");
            tdFirstTitle = $("#<%=this.tdFirstTitle.ClientID%>");
            tdSubTitle = $("#<%=this.tdSubTitle.ClientID%>");
        })
    </script>
    <script src="../js/Page/Print/printoffsetchargefee.js?v=<%=base.getToken() %>"></script>
    <script src="../js/Lodop/LodopFuncs.js?t=<%=base.getToken() %>"></script>
    <script type="text/javascript">
        var pageWidth, pageHeight;
        function printpage() {
            saveprocess(false);
        };
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
            var url = "printoffsetchargefeeview.aspx?PrintID=" + PrintID + "&PageWidth=" + pageWidth + "&PageHeight=" + pageHeight;
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
                    LODOP.PRINT_INIT("打印单据_冲抵单");
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
            <a href="javascript:void(0)" onclick="cancelFee()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-close'">关闭</a>
            <asp:HiddenField runat="server" ID="hdOrderNumberID" />
        </div>
        <div class="table_container">
            <div>
                纸张宽度：<input type="text" id="tdWidth" runat="server" />mm
            纸张高度：<input type="text" id="tdHeight" runat="server" />mm
            </div>
            <div class="kskd">
                开冲抵单
            </div>
            <div class="wrap" id="print_wrap">
                <div class="content" id="print_content">
                    <style type="text/css">
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
                        }

                            table.sfxm thead, table.sfxm tbody, table.sfxm tfoot {
                                padding: 0;
                            }


                            table.sfxm tr.haveborder td, table.sfxm tr.haveborder th {
                                text-align: center;
                                border: solid #cccccc;
                                border-width: 1px;
                                padding: 0;
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
                        }

                            .skdh input {
                                border: none;
                                border-bottom: solid 1px #cccccc;
                                width: 120px;
                            }

                        .systitle, .systitle input {
                            font-size: 20px;
                            text-align: center;
                            font-weight: bold;
                        }

                            .systitle label {
                                font-size: 20px;
                            }

                        .sksj, .sksj label {
                            font-size: 14px;
                            text-align: center;
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
                        }

                            table.skxx td.skr {
                                width: 60px;
                            }

                            table.skxx td.skfs, table.skxx td.zhekou {
                                width: 5%;
                            }

                        .skr input, .skrq input, .skfs input, .zhekou input {
                            width: 100%;
                        }

                        .shuoming {
                            width: 100%;
                            text-align: left;
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
                                <th colspan="7" class="skdh">冲抵单号:
                <input type="text" id="tdPrintNumber" runat="server" />
                                </th>
                            </tr>
                            <tr>
                                <th colspan="7" class="systitle">
                                    <input type="text" id="tdFirstTitle" runat="server" />
                                    <%--<label id="tdFirstTitle" runat="server"></label>--%>
                                </th>
                            </tr>
                            <tr>
                                <th colspan="7" class="sksj">
                                    <label id="tdSubTitle" runat="server">冲抵单据</label>
                                </th>
                            </tr>
                            <tr>
                                <th colspan="7" style="width: 100%; padding-bottom: 5px;">
                                    <div class="fjdz finalfont">
                                        资源地址:                
                                    <input value="<%=this.FullName %>" id="tdRoomFullName" type="text" />
                                    </div>
                                    <div class="khxm finalfont">
                                        客户名称:                
                                    <input value="<%=this.OwnerName %>" id="tdRoomOwnerName" type="text" />
                                    </div>

                                </th>
                            </tr>
                            <tr class="haveborder">
                                <th style="width: 15%">收费项目
                                </th>
                                <th style="width: 15%">计费开始日期
                                </th>
                                <th style="width: 15%">计费结束日期
                                </th>
                                <th style="width: 15%">单价
                                </th>
                                <th style="width: 10%">冲销金额
                                </th>
                                <th style="width: 15%">上次/本次尾数
                                </th>
                                <th style="width: 25%">备注
                                </th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater runat="server" ID="rptProject" OnItemDataBound="rptProject_ItemDataBound">
                                <ItemTemplate>
                                    <tr class="haveborder">
                                        <td><%#Eval("ChargeName") %>
                                        </td>
                                        <td><%# ((DateTime)Eval("StartTime")) == DateTime.MinValue ? "" : Eval("StartTime", "{0:yyyy-MM-dd}")%>
                                        </td>
                                        <td><%# ((DateTime)Eval("EndTime")) == DateTime.MinValue ? "" : Eval("EndTime", "{0:yyyy-MM-dd}")%>
                                        </td>
                                        <td><%#Web.WebUtil.FormatMoney((decimal)Eval("UnitPrice"),4) %>
                                        </td>
                                        <td><%#Web.WebUtil.FormatMoney((decimal)Eval("ChargeFee")) %>
                                        </td>
                                        <td><%#(decimal)Eval("FinalStartPoint")+"/"+(decimal)Eval("FinalEndPoint") %>
                                        </td>
                                        <td><%#Eval("Remark") %>
                                        </td>
                                    </tr>
                                </ItemTemplate>

                            </asp:Repeater>
                            <tr class="haveborder">
                                <%-- <td class="lefttd">应收合计（大写）
                            </td>
                            <td class="lefttd" colspan="2"><%=this.MoneyDaXie %></td>--%>
                                <td class="lefttd" colspan="3">应收合计: ￥<%=Web.WebUtil.FormatMoney(this.TotalCost) %>
                                </td>
                                <td class="lefttd" colspan="4">实收合计: ￥<%=Web.WebUtil.FormatMoney(this.money) %></td>
                            </tr>
                        </tbody>
                        <tfoot>
                            <tr>
                                <th colspan="7">
                                    <table class="skxx">
                                        <tr>
                                            <td style="width: 45px;">冲抵人: </td>
                                            <td class="skr" style="width: 60px;">
                                                <input id="tdChargeMan" runat="server" type="text" /></td>
                                            <td style="width: 65px;">冲抵时间: </td>
                                            <td class="skrq" style="width: 200px">
                                                <input style="width: 150px;" id="tdChargeTime" class="easyui-datetimebox" runat="server" type="text" /></td>
                                            <td style="width: 55px;">冲销项目: </td>
                                            <td class="skrq" style="width: 150px">
                                                <select style="width: 100px;" class="easyui-combobox" runat="server" id="tdChargeForSummary">
                                                    <option value="预收款">预收款</option>
                                                </select></td>
                                            <td style="width: 55px;">冲销方式: </td>
                                            <td class="skrq" style="width: 150px">
                                                <select style="width: 100px;" class="easyui-combobox" runat="server" id="tdChargeMethods">
                                                    <option value="手工指定">手工指定</option>
                                                    <option value="手工指定">手工指定</option>
                                                </select></td>
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
