<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="ApproveFeeOrder.aspx.cs" Inherits="Web.Charge.ApproveFeeOrder" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>生成交款单</title>
    <script>
        var RoomFeeOrderID, tdApproveTime, tdApproveMan, hdApproveUserID, tdApproveStatus, tdApproveRemark;
        $(function () {
            RoomFeeOrderID = "<%=Request.QueryString["ID"]%>";
            tdApproveTime = $("#<%=this.tdApproveTime.ClientID%>");
            tdApproveMan = $("#<%=this.tdApproveMan.ClientID%>");
            hdApproveUserID = $("#<%=this.hdApproveUserID.ClientID%>");
            tdApproveStatus = $("#<%=this.tdApproveStatus.ClientID%>");
            tdApproveRemark = $("#<%=this.tdApproveRemark.ClientID%>");
            $('#<%=this.hdRoomFeeOrderID.ClientID%>').val(RoomFeeOrderID);
        })
        function doExport() {
            $('#<%=this.btnExport.ClientID%>').click();
        }
    </script>
    <script src="../js/Page/Charge/ApproveFeeOrder.js?t=<%=base.getToken() %>"></script>
    <style>
        .panel-body {
            background: #f0f0f0;
        }

        table.common, table.basic, table.result1, table.result2 {
            width: 96%;
            border-spacing: 0;
            border-collapse: collapse;
            border: solid 1px #ccc;
            margin: 0 auto;
            margin-top: 10px;
            background: #fff;
        }

            table.common td, table.basic td {
                padding: 5px 10px;
                border: solid 1px #ccc;
                text-align: left;
                width: 20%;
            }

                table.common td:nth-child(2n-1) {
                    text-align: right;
                    width: 10%;
                }

            table.common input[type=text] {
                width: 200px;
            }

            table.result1 td, table.result2 td {
                padding: 5px 10px;
                border: solid 1px #ccc;
                text-align: left;
                width: 15%;
            }

                table.result1 td:nth-child(2n-1), table.result2 td:nth-child(2n-1) {
                    text-align: right;
                    width: 10%;
                }

        table.result2 {
            border-top: 0px;
            margin-top: 0px;
        }

            table.result2 td {
                border-top: 0px;
            }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <form runat="server">
        <div class="operation_box">
            <%if (this.roomfeeOrder.ApproveStatus == 0)
              { %>
            <a href="#" onclick="DoApprove()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-shenhe'">审核</a>
            <%} %>
            <a href="#" onclick="closeWin()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-close'">关闭</a>
            <a href="#" onclick="doExport()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-export'">导出</a>
            <asp:Button runat="server" ID="btnExport" Style="display: none" OnClick="btnExport_Click" />
            <asp:HiddenField runat="server" ID="hdRoomFeeOrderID" />
        </div>
        <div class="table_container">
            <div class="table_title">交款单审核</div>
            <table class="common">
                <tr>
                    <td>审核时间</td>
                    <td>
                        <input type="text" class="easyui-datetimebox" runat="server" id="tdApproveTime" /></td>
                    <td>审核人</td>
                    <td>
                        <input type="text" class="easyui-textbox" runat="server" data-options="readonly:true" id="tdApproveMan" />
                        <input type="hidden" id="hdApproveUserID" runat="server" />
                    </td>
                    <td>审核状态</td>
                    <td>
                        <select class="easyui-combobox" id="tdApproveStatus" runat="server">
                            <option value="1">审核通过</option>
                            <option value="2">审核未通过</option>
                        </select></td>
                </tr>
                <tr>
                    <td>详细说明</td>
                    <td colspan="5">
                        <input type="text" class="easyui-textbox" data-options="multiline:true" style="width: 100%; height: 60px;" id="tdApproveRemark" runat="server" /></td>
                </tr>
            </table>
            <div class="table_title">交款单申请明细</div>
            <table class="common" style="margin-top: 10px;">
                <tr>
                    <td>项目名称</td>
                    <td colspan="5">
                        <span runat="server" id="tdProjectName"></span></td>
                </tr>
                <tr>
                    <td>交款人</td>
                    <td colspan="2">
                        <input type="text" class="easyui-textbox" runat="server" id="tdAddMan" />
                    </td>
                    <td>交款日期</td>
                    <td colspan="2">
                        <input type="text" class="easyui-datetimebox" id="tdOrderTime" runat="server" /></td>
                </tr>
                <tr>
                    <td>收费时间</td>
                    <td colspan="3">
                        <input type="text" class="easyui-datetimebox" id="tdStartTime" runat="server" />
                        -
                <input type="text" class="easyui-datetimebox" id="tdEndTime" runat="server" />
                    </td>
                    <td>操作员</td>
                    <td>
                        <input type="text" class="easyui-textbox" id="tdOperator" runat="server" /></td>
                </tr>
            </table>
            <table class="basic">
                <tr>
                    <td>单据共:&nbsp;&nbsp;
                <span id="totalCount">0</span>
                        张
                    </td>
                    <td>收款单:&nbsp;&nbsp;
                <span id="totalPayCount">0</span>
                        张
                    </td>
                    <td>退款单:&nbsp;&nbsp;
                <span id="totalPayBackCount">0</span>
                        张
                    </td>
                    <td>作废单:&nbsp;&nbsp;
                <span id="totalCancelCount">0</span>
                        张
                    </td>
                </tr>
            </table>
            <table class="result1">
                <tr>
                    <td colspan="4" style="width: 50%; text-align: center;">收款情况
                    </td>
                    <td colspan="4" style="width: 50%; text-align: center;">付款情况</td>
                </tr>
                <tr>
                    <td>收款单号</td>
                    <td colspan="3" style="width: 40%">
                        <div style="display: inline-table; width: 50%;">
                            起始 <span id="startShouOrderNumber"></span>
                        </div>
                        <div style="display: inline-table;">
                            终止  <span id="endShouOrderNumber"></span>
                        </div>
                    </td>
                    <td>付款单号</td>
                    <td colspan="3" style="width: 40%">
                        <div style="display: inline-table; width: 50%;">
                            起始 <span id="startFuOrderNumber"></span>
                        </div>
                        <div style="display: inline-table;">
                            终止  <span id="endFuOrderNumber"></span>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>收款总金额</td>
                    <td colspan="3" style="width: 40%">￥<span id="shouTotalCost">0.00</span>
                    </td>
                    <td>付款总金额</td>
                    <td style="width: 15%">￥<span id="fuTotalCost">0.00</span>
                    </td>
                    <td>尾数差额</td>
                    <td style="width: 15%">￥<span id="weishuTotalCost">0.00</span>
                    </td>
                </tr>
            </table>
            <div class="finalDetail" style="display: none;">
                <table class="result2" id="tableDetails">
                </table>
                <div id="ChargeSummaryAccording" class="easyui-accordion" style="width: 100%; height: 500px; margin: 0 auto; margin-top: 5px;">
                    <div title="收款单明细" style="overflow: auto; padding: 10px;">
                        <table id="shou_table"></table>
                    </div>
                    <div title="付款单明细" style="overflow: auto; padding: 10px;">
                        <table id="fu_table"></table>
                    </div>
                </div>
            </div>
        </div>
    </form>
</asp:Content>
