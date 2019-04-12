<%@ Page Title="" Language="C#" MasterPageFile="~/Master/NavContent4.Master" AutoEventWireup="true" CodeBehind="CreateFeeOrder.aspx.cs" Inherits="Web.Charge.CreateFeeOrder" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>生成交款单</title>
    <script>
        var hdHistoryIDList;
        $(function () {
            hdHistoryIDList = $('#<%=this.hdHistoryIDList.ClientID%>');
        })
        function doExport() {
            if (top_historyidlist.length == 0) {
                show_message("请选择历史单据", "warning");
                return;
            }
            hdHistoryIDList.val(JSON.stringify(top_historyidlist));
            $('#<%=this.btnExport.ClientID%>').click();
        }
    </script>
    <script src="../js/Page/Charge/CreateFeeOrder.js?t=1<%=base.getToken() %>"></script>
    <style>
        table.info, table.basic, table.result1, table.result2 {
            width: 100%;
            border-spacing: 0;
            border-collapse: collapse;
            border: solid 1px #ccc;
            margin: 0 auto;
            margin-top: 10px;
        }

            table.info td, table.basic td {
                padding: 5px 10px;
                border: solid 1px #ccc;
                text-align: left;
                width: 20%;
            }

                table.info td:nth-child(2n-1) {
                    text-align: right;
                    width: 10%;
                }

        input[type=text] {
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
    <script>
        function closeWin() {
            window.location.reload();
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <form runat="server">
        <div style="width: 90%; margin: 0 auto;">
            <table class="info">
                <tr>
                    <td colspan="6" style="text-align: center; padding: 5px 10px; font-size: 18px; color: #fff; background-color: #2f80d1">生成交款单
                    </td>
                </tr>
                <tr>
                    <td colspan="6" style="text-align: center;">
                        <label>
                            收费时间                    
                            <input type="text" class="easyui-datetimebox" id="tdStartTime" value="<%=this.StartTime %>" style="width: 150px;" />
                            -
                <input type="text" class="easyui-datetimebox" id="tdEndTime" value="<%=DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") %>" style="width: 150px;" />
                        </label>
                        <label style="padding-left: 20px;">
                            单据类型                    
                            <input class="easyui-combobox" id="tdChargeState" style="width: 80px;" />
                        </label>
                        <label style="padding-left: 20px;">
                            操作员                    
                            <input type="text" class="easyui-combobox" id="tdOperator" style="width: 100px;" />
                        </label>
                        <label style="padding-left: 20px;">
                            收款方式                   
                            <input type="text" class="easyui-combobox" id="tdChargeType" style="width: 100px;" />
                        </label>
                    </td>
                </tr>
                <tr>
                    <td colspan="6" style="text-align: center;">
                        <a href="javascript:void(0)" onclick="Search()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-search'">查询单据</a>
                        <span id="spanSave" style="display: none;">
                            <a href="javascript:void(0)" onclick="saveData()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-save'">保存</a>
                            <a href="javascript:void(0)" onclick="cancelData()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-zuofei'">取消</a>
                            <a href="javascript:void(0)" onclick="doExport()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-export'">导出</a>
                            <asp:Button runat="server" ID="btnExport" Style="display: none" OnClick="btnExport_Click" />
                            <asp:HiddenField runat="server" ID="hdHistoryIDList" />
                        </span>
                    </td>
                </tr>
            </table>
            <table class="basic">
                <tr>
                    <%--<td>项目名称</td>
                <td>
                    <input type="text" class="easyui-combobox" id="tdProjectName" /></td>--%>
                    <td>交款人</td>
                    <td>
                        <input type="text" class="easyui-textbox" data-options="readonly:true" id="tdAddMan" value="<%=Web.WebUtil.GetUser(this.Context).RealName %>" />
                        <input type="hidden" id="hdAddManID" value="<%=Web.WebUtil.GetUser(this.Context).UserID %>" />
                    </td>
                    <td>交款日期</td>
                    <td>
                        <input type="text" class="easyui-datetimebox" id="tdOrderTime" value="<%=DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") %>" /></td>
                </tr>
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
                <div style="text-align: center;">
                    <a href="javascript:void(0)" onclick="saveData()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-save'">保存</a>
                    <a href="javascript:void(0)" onclick="cancelData()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-zuofei'">取消</a>
                </div>
            </div>
        </div>
    </form>
</asp:Content>
