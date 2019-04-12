<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="printcuifei.aspx.cs" Inherits="Web.PrintPage.printcuifei" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../js/Lodop/LodopFuncs.js?t=<%=base.getToken() %>"></script>
    <script type="text/javascript">
        var IDs;
        $(function () {
            IDs = "<%=Request.QueryString["IDs"]%>";
        })
        function printpage() {
            var pageWidth = $("#<%=this.tdWidth.ClientID%>").val();
            var pageHeight = $("#<%=this.tdHeight.ClientID%>").val();
            if (pageWidth == "") {
                alert("纸张宽度不能为空");
                return;
            }
            if (pageHeight == "") {
                alert("纸张高度不能为空");
                return;
            }
            var iframe = document.getElementById("myframe");
            var url = "printcuifeiview.aspx?IDs=" + IDs + "&PageWidth=" + pageWidth + "&PageHeight=" + pageHeight;
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
                    LODOP.PRINT_INIT("打印单据_催款单");
                    LODOP.SET_PRINT_PAGESIZE(1, '210mm', '99mm', '')
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

                    input[type="text"] {
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
                            width: 120px;
                            background-color: inherit;
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
                        display: inline-table;
                        width: 60%;
                    }

                        .fjdz input {
                            border: none;
                            border-bottom: solid 1px #cccccc;
                            width: 70%;
                            border-radius: 0 !important;
                            box-shadow: none !important;
                            color: inherit;
                            font-family: inherit;
                            font-size: inherit;
                            padding: 0;
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
                            width: 70%;
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
                            width: 15%;
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
                        border: none;
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
                            <th colspan="<%=this.ColumnCount %>" class="systitle">
                                <label id="tdFirstTitle" runat="server"></label>
                            </th>
                        </tr>
                        <tr>
                            <th colspan="<%=this.ColumnCount %>" class="sksj">缴费通知单
                            </th>
                        </tr>
                        <tr>
                            <th colspan="<%=this.ColumnCount %>" style="width: 100%; padding-bottom: 5px;">资源地址: 
                            <div class="fjdz finalfont">
                                资源地址: 
                <input value="<%=this.FullName %>" type="text" />
                            </div>
                                <div class="khxm finalfont">
                                    客户名称: 
                <input value="<%=this.OwnerName %>" type="text" />
                                </div>
                            </th>
                        </tr>
                        <tr class="haveborder">
                            <th>收费项目
                            </th>
                            <%if (this.IsPrintUnitPrice)
                              { %>
                            <th>单价
                            </th>
                            <%} %>
                            <th>面积/用量
                            </th>
                            <th>应收金额
                            </th>
                            <th>计费开始日期
                            </th>
                            <th>计费结束日期
                            </th>
                            <th>上次/本次读数
                            </th>
                            <th>备注
                            </th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater runat="server" ID="rptProject" OnItemDataBound="rptProject_ItemDataBound">
                            <ItemTemplate>
                                <tr class="haveborder">
                                    <td><%#Eval("Name") %>
                                    </td>
                                    <%if (IsPrintUnitPrice)
                                      { %>
                                    <td><%#Web.WebUtil.FormatMoney((decimal)Eval("CalculateUnitPrice"),4) %>
                                    </td>
                                    <%} %>
                                    <td><%#Eval("CalculateUseCount") %>
                                    </td>
                                    <td><%#Web.WebUtil.FormatMoney((decimal)Eval("TotalFinalCost")) %>
                                    </td>
                                    <td><%# ((DateTime)Eval("CalculateStartTime")) == DateTime.MinValue ? "" : Eval("CalculateStartTime", "{0:yyyy-MM-dd}")%>
                                    </td>
                                    <td><%# ((DateTime)Eval("CalculateEndTime")) == DateTime.MinValue ? "" : Eval("CalculateEndTime", "{0:yyyy-MM-dd}")%>
                                    </td>

                                    <td><%#(decimal)Eval("FinalStartPoint")+"/"+(decimal)Eval("FinalEndPoint") %><%#((int)Eval("ProjectBiaoID")>0&&(decimal)Eval("ImportRate")>0)?"(倍率:"+((decimal)Eval("ImportRate")).ToString("g0")+")":"" %>
                                    </td>
                                    <td><%#Eval("RemarkNote") %>
                                    </td>
                                </tr>
                            </ItemTemplate>

                        </asp:Repeater>
                        <tr class="haveborder">
                            <td class="lefttd" colspan="3">应收合计
                            </td>
                            <td class="lefttd" colspan="5">￥<%=Web.WebUtil.FormatMoney(this.money) %></td>
                        </tr>
                    </tbody>
                    <tfoot>
                        <tr>
                            <th colspan="<%=this.ColumnCount %>">
                                <table class="skxx">
                                    <tr>
                                        <td style="width: 45px;">打印人: </td>
                                        <td class="skr">
                                            <input id="tdChargeMan" runat="server" type="text" /></td>
                                        <td style="width: 55px;">打印日期: </td>
                                        <td class="skrq">
                                            <input style="width: 150px;" id="tdChargeTime" class="easyui-datetimebox" runat="server" type="text" /></td>
                                        <td style="width: 55px;">客户签收: </td>
                                        <td class="skfs">&nbsp;&nbsp;<input id="tdRealMoneyCost1" runat="server" class="xjje" /></td>
                                        <td style="width: 55px;">签收日期: </td>
                                        <td class="zhekou">&nbsp;&nbsp;<input id="tdDiscountMoney" runat="server" type="text" value="" /></td>
                                    </tr>
                                </table>
                            </th>
                        </tr>
                        <tr>
                            <th class="shuoming" colspan="<%=this.ColumnCount %>">说明:<input id="tdRemark" runat="server" type="text" />
                            </th>
                        </tr>
                    </tfoot>
                </table>
            </div>
            <div class="opeation">
                <a href="javascript:void(0)" onclick="printpage()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-print'">打印</a>
                <asp:HiddenField ID="hdOrderNumberID" runat="server" />
            </div>
        </div>
    </form>
    <iframe name="myiframe" id="myframe" style="display: none;" src="" width="100%" height="100%"></iframe>
</asp:Content>
