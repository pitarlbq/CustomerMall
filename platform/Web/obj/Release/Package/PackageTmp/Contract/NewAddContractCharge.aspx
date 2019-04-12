<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="NewAddContractCharge.aspx.cs" Inherits="Web.Contract.NewAddContractCharge" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        var ContractID, guid, startstamp, endstamp, StartTime, EndTime, ffObj, canedit, RentToTime, canrent, renttostamp, tdCalculateTypeOn;
        $(function () {
            guid = "<%=Request.QueryString["guid"]%>";
            ContractID = "<%=Request.QueryString["ContractID"]%>";
            startstamp = "<%=Request.QueryString["startstamp"]%>";
            endstamp = "<%=Request.QueryString["endstamp"]%>";
            StartTime = stampToDate(startstamp);
            EndTime = stampToDate(endstamp);
            ffObj = $("#<%=this.ff.ClientID%>");
            tdCalculateTypeOn = $("#<%=this.tdCalculateTypeOn.ClientID%>");
            canedit = "<%=Request.QueryString["canedit"]%>" || 0;
            canrent = "<%=Request.QueryString["canrent"]%>" || 0;
            renttostamp = "<%=Request.QueryString["renttostamp"]%>";
            if (renttostamp != '') {
                RentToTime = stampToDate(renttostamp);
            }
            $('#tdFirstReadyChargeDay').textbox({
                onChange: function () {
                    var dayNumber = $('#tdFirstReadyChargeDay').textbox('getValue');
                    if (dayNumber != '') {
                        var endTime = addDay(-dayNumber, StartTime);
                        $('#tdFirstReadyChargeTime').datebox('setValue', endTime);
                    }
                }
            })
        });
        function addDay(dayNumber, date) {
            if (!date) {
                return '';
            }
            date = stringToDate(date);
            var ms = dayNumber * (1000 * 60 * 60 * 24)
            var newDate = new Date(date.getTime() + ms);
            var y = newDate.getFullYear(), M = newDate.getMonth() + 1, d = newDate.getDate();
            return [y, M < 10 ? "0" + M : M, d < 10 ? "0" + d : d].join("-");
        }
    </script>
    <script src="../js/vue.js"></script>
    <script src="../js/Page/Contract/NewAddContractCharge.js?t=<%=getToken() %>"></script>
    <style>
        .panel-body {
            background: #f0f0f0;
        }

        table.info td label {
            display: inline-block;
            position: relative;
            padding-left: 16px;
            line-height: 28px;
        }

        table.info td input[type=checkbox] {
            position: absolute;
            left: 0;
            top: 50%;
            margin: -7px 0 0 0;
            height: 15px;
            width: 15px;
        }

        .table_box {
            margin: 10px 2.5% 0 2.5%;
        }

        table.field {
            width: 100%;
            border-spacing: 0;
            border-collapse: collapse;
            margin: 0 auto;
            background: #fff;
            border-radius: 5px;
        }

            table.field td {
                padding: 5px;
            }

            table.field input.textBox {
                width: 100px;
                border: solid 1px #ddd;
                height: 28px;
                line-height: 28px;
                border-radius: 5px !important;
                padding: 0 5px;
            }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <form runat="server" id="ff">
        <div class="operation_box">
            <a href="javascript:void(0)" id="btnTempPrice" onclick="saveData()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-shengcheng'">生成账单</a>
            <a href="javascript:void(0)" onclick="saveData()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-save'">保存</a>
            <a href="javascript:void(0)" onclick="closeWin()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-close'">关闭</a>
        </div>
        <div class="table_container">
            <table class="info">
                <tr>
                    <td>房间</td>
                    <td>
                        <input type="text" name="RoomID" class="easyui-combobox" data-options="required:true" id="tdRoomID" style="height: 28px;" /></td>
                    <td>收费项目</td>
                    <td>
                        <input type="text" name="ChargeID" class="easyui-combobox" data-options="required:true" id="tdChargeID" style="height: 28px;" /></td>
                </tr>
                <tr>
                    <td>收费日期提前天数</td>
                    <td>
                        <input type="text" class="easyui-textbox" id="tdFirstReadyChargeDay" />
                    </td>
                    <td>首次收费日期</td>
                    <td>
                        <input type="text" name="FirstReadyChargeTime" class="easyui-datebox" id="tdFirstReadyChargeTime" />
                    </td>
                </tr>
                <tr>
                    <td>单价</td>
                    <td>
                        <input type="text" name="RoomUnitPrice" class="easyui-textbox" id="tdRoomUnitPrice" /></td>
                    <td class="AutoChangePrice">首次缴费至</td>
                    <td class="AutoChangePrice">
                        <input type="text" class="easyui-datebox" id="tdFirstStartTime" />
                    </td>
                </tr>
                <tr class="AutoChangePrice">
                    <td>收费周期</td>
                    <td>
                        <input type="text" name="CalculateMonth" class="easyui-textbox" id="tdCalculateMonth" />（月）
                    </td>
                    <td>调价方式</td>
                    <td>
                        <label class="radioLabel">
                            <input type="checkbox" name="tabletype" value="1" runat="server" id="tdCalculateTypeOn" />启用
                        </label>
                    </td>
                </tr>
            </table>
            <div class="table_box" id="calculateBox">
                <div id="fieldcontent">
                    <table class="field">
                        <tr>
                            <td colspan="6">
                                <a href="javascript:void(0)" v-on:click="add_line()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-add'">添加</a>
                            </td>
                        </tr>
                        <tr>
                            <td>调价方式
                            </td>
                            <td>调价周期
                            </td>
                            <td>调价开始日期
                            </td>
                            <td>调价结束日期
                            </td>
                            <td>调价比例/金额
                            </td>
                            <td></td>
                        </tr>
                        <tr v-for="(item, index) in list" v-bind:id="'tr_'+item.count">
                            <td>
                                <select v-model="item.CalculateType" data-options="editable:false" v-bind:id="item.count+'_CalculateType'" style="height: 28px; width: 100px;">
                                    <option value="percent">按比例</option>
                                    <option value="amount">按金额</option>
                                </select>
                            </td>
                            <td>
                                <input type="text" v-bind:id="item.count+'_CalcualtePriceMonth'" class="textBox" v-model="item.CalcualtePriceMonth" />
                                <select v-model="item.CalculateMonthType" data-options="editable:false" v-bind:id="item.count+'_CalculateMonthType'" style="height: 28px; width: 100px;">
                                    <option value="1">月</option>
                                    <option value="2">天</option>
                                </select>
                            </td>
                            <td>
                                <input type="text" v-bind:id="item.count+'_FirstReadyChargePriceTime'" style="height: 28px; width: 120px;" v-model="item.FirstReadyChargePriceTime" />
                            </td>
                            <td>
                                <input type="text" v-bind:id="item.count+'_LastReadyChargePriceTime'" style="height: 28px; width: 120px;" v-model="item.LastReadyChargePriceTime" />
                            </td>
                            <td>
                                <input type="text" v-bind:id="item.count+'_CalculateValue'" class="textBox" v-model="item.CalculateValue" />（{{item.valueunit}}）
                            </td>
                            <td>
                                <a href="javascript:void(0)" v-on:click="remove_line(item)">删除</a>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
            <div id="pricetable" style="display: none; margin: 10px 2.5%;">
                <table id="tt_table"></table>
                <div id="tb">
                    <%--<a href="javascript:void(0)" onclick="doAddRow()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-add'">新增</a>
                    <a href="javascript:void(0)" onclick="doEditRow()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-edit'">修改</a>--%>
                    <a href="javascript:void(0)" onclick="doRemoveRow()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-remove'">删除</a>
                </div>
            </div>
        </div>
    </form>
</asp:Content>
