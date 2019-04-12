<%@ Page Title="" Language="C#" MasterPageFile="~/Master/NavContent4.Master" AutoEventWireup="true" CodeBehind="TotalAnalysis.aspx.cs" Inherits="Web.Analysis.TotalAnalysis" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../js/easyui/datagrid-detailview.js"></script>
    <script>
        var CompanyID, UserID, showSFXM;
        $(function () {
            CompanyID = "<%=Web.WebUtil.GetCompanyID(this.Context)%>";
            UserID = "<%=Web.WebUtil.GetUser(this.Context).UserID%>";
            showSFXM = "<%=this.ShowSFXM%>";
        })
    </script>
    <script src="../js/Page/Analysis/TotalAnalysis.js?t=<%=base.getToken() %>"></script>
    <script src="../js/highcharts/highcharts.js"></script>
    <script src="../js/highcharts/modules/exporting.js"></script>
    <style>
        table.shoukuansummary {
            width: 100%;
            border-spacing: 0;
            border-collapse: collapse;
        }

            table.shoukuansummary td {
                text-align: center;
                padding: 0 30px;
                font-size: 15px;
                width: 25%;
            }

        .inlinebox {
            height: 30px;
            line-height: 30px;
            font-size: 18px;
            color: #1EBD1A;
        }

        .searcharea label {
            padding: 5px 10px;
        }

        .mainpanel .panel-header {
            background: #f2f1f1;
        }

        .mainpanel .panel-title {
            color: #000;
            font-size: 14px;
            height: 20px;
            line-height: 20px;
        }

        #tdfirst, #tdsecond, #tdthrid, #tdfourth {
            padding: 10px;
        }

        .mainbox {
            background: #f2f1f1;
            border-radius: 5px;
            color: #000;
            padding: 15px 0;
        }

            .mainbox:hover, .mainbox label:hover {
                cursor: pointer;
            }

        .easyui-panel.border_box {
            border: solid 0px #ccc;
            padding: 10px 5px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <div class="easyui-layout" data-options="fit:true">
        <div data-options="region:'center',border:false">
            <div class="mainpanel" id="mainpanel0" style="float: left; width: 100%; margin-top: 10px;">
                <div class="easyui-panel border_box" title="提醒预警">
                    <table class="shoukuansummary">
                        <tr>
                            <td id="tdfirst0">
                                <div class="mainbox">
                                    <div class="inlinebox first">0</div>
                                    <label class="firsttitle">合同到期</label>
                                </div>
                            </td>
                            <td id="tdsecond0">
                                <div class="mainbox">
                                    <div class="inlinebox second">￥0.00</div>
                                    <label class="secondtitle">合同收费</label>
                                </div>
                            </td>
                            <td id="tdthrid0">
                                <div class="mainbox">
                                    <div class="inlinebox thrid">0</div>
                                    <label class="thridtitle">报事报修</label>
                                </div>
                            </td>
                            <td id="tdfourth0">
                                <div class="mainbox">
                                    <div class="inlinebox fourth">0</div>
                                    <label class="fourthtitle">延期任务</label>
                                </div>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
            <div class="mainpanel" id="mainpanel1" style="float: left; width: 100%; margin-top: 10px;">
                <div class="easyui-panel border_box" title="整体概况">
                    <table class="shoukuansummary">
                        <tr>
                            <td id="tdfirst">
                                <div class="mainbox">
                                    <div class="inlinebox first">￥0.00</div>
                                    <label class="firsttitle"></label>
                                </div>
                            </td>
                            <td id="tdsecond">
                                <div class="mainbox">
                                    <div class="inlinebox second">￥0.00</div>
                                    <label class="secondtitle"></label>
                                </div>
                            </td>
                            <td id="tdthrid">
                                <div class="mainbox">
                                    <div class="inlinebox thrid">0.00%</div>
                                    <label class="thridtitle"></label>
                                </div>
                            </td>
                            <td id="tdfourth">
                                <div class="mainbox">
                                    <div class="inlinebox fourth">0.00%</div>
                                    <label class="fourthtitle"></label>
                                </div>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
            <div class="mainpanel" style="float: left; width: 100%; margin: 10px 0px; padding: 5px 0px;">
                <div class="searcharea" style="display: none;">
                    <label>
                        时间:<select id="tdShouKuanTimeRange" class="easyui-combobox" style="width: 100px;">
                            <option value="1">今日</option>
                            <option value="2">昨日</option>
                            <option value="3">本周</option>
                            <option value="4">本月</option>
                            <option value="5">本季度</option>
                            <option value="6">本年度</option>
                        </select>
                        或者
                    <input class="easyui-datebox" id="tdShouKuanStartTime" />
                        -
                    <input class="easyui-datebox" id="tdShouKuanEndTime" />
                    </label>
                    <label style="display: none;">
                        收款方式:<input id="tdShouKuanChargeType" class="easyui-combobox" style="width: 100px;" />
                    </label>
                    <label style="display: none;">
                        收费项目:<input id="tdShouKuanChargeSummary" class="easyui-combobox" style="width: 100px;" />
                    </label>
                    <label>
                        <a href="#" onclick="loadsfkb()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-search'">搜索</a>
                    </label>
                </div>
                <div class="mainpanel" id="mainpanel2" style="float: left; width: 49%;">
                    <div class="easyui-panel border_box" title="收款看板" style="height: 400px;">
                        <%if (this.ShowSFXM.Equals("skkb_sfxm"))
                          {%>
                        <div id="summary_container" style="min-width: 350px; height: 350px; text-align: center;"></div>
                        <%}
                          else
                          { %>
                        <div id="type_container" style="min-width: 350px; height: 350px; text-align: center;"></div>
                        <%} %>
                    </div>
                </div>
                <div class="mainpanel" id="mainpanel3" style="float: right; width: 49%;">
                    <div class="easyui-panel border_box" title="欠费看板" style="height: 400px;">
                        <div id="qianfei_container" style="min-width: 350px; height: 350px; text-align: center;"></div>
                    </div>
                </div>
            </div>
            <div class="mainpanel" id="mainpanel4" style="float: left; width: 100%; margin: 10px 0px; padding: 5px 0px;">
                <div class="easyui-panel border_box" title="支出看板" style="height: 400px;">
                    <div id="zhichu_container" style="min-width: 350px; height: 350px; text-align: center;"></div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
