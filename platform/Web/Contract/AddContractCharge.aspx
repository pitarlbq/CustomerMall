<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="AddContractCharge.aspx.cs" Inherits="Web.Contract.AddContractCharge" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        var ContractID, guid, startstamp, endstamp, StartTime, EndTime, ffObj, canedit, RentToTime, canrent, renttostamp;
        $(function () {
            guid = "<%=Request.QueryString["guid"]%>";
            ContractID = "<%=Request.QueryString["ContractID"]%>";
            startstamp = "<%=Request.QueryString["startstamp"]%>";
            endstamp = "<%=Request.QueryString["endstamp"]%>";
            StartTime = stampToDate(startstamp);
            EndTime = stampToDate(endstamp);
            ffObj = $("#<%=this.ff.ClientID%>");
            canedit = "<%=Request.QueryString["canedit"]%>" || 0;
            canrent = "<%=Request.QueryString["canrent"]%>" || 0;
            renttostamp = "<%=Request.QueryString["renttostamp"]%>";
            if (renttostamp != '') {
                RentToTime = stampToDate(renttostamp);
            }
        });
    </script>
    <script src="../js/Page/Contract/ContractChargeAdd.js?t=<%=getToken() %>"></script>
    <style>
        .panel-body {
            background: #f0f0f0;
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
                        <input type="text" name="RoomID" class="easyui-combobox" data-options="required:true" id="tdRoomID" /></td>
                    <td>收费项目</td>
                    <td>
                        <input type="text" name="ChargeID" class="easyui-combobox" data-options="required:true" id="tdChargeID" /></td>
                </tr>
                <tr>
                    <td>单价</td>
                    <td>
                        <input type="text" name="RoomUnitPrice" class="easyui-textbox" id="tdRoomUnitPrice" /></td>
                    <td>首次收费日期</td>
                    <td>
                        <input type="text" name="FirstReadyChargeTime" class="easyui-datebox" id="tdFirstReadyChargeTime" />
                    </td>
                </tr>
                <tr style="display: none;">
                    <td>自动调价</td>
                    <td colspan="3">
                        <input type="checkbox" id="tdAutoChagePrice" checked="checked" />
                    </td>
                </tr>
                <tr class="AutoChangePrice" id="tr_CalculateMonth">
                    <td>收费周期</td>
                    <td>
                        <input type="text" name="CalculateMonth" class="easyui-textbox" id="tdCalculateMonth" />（月）
                    </td>
                    <td>调价方式</td>
                    <td>
                        <select id="tdCalculateType" class="easyui-combobox" data-options="editable:false">
                            <option value="">无</option>
                            <option value="percent">按比例</option>
                            <option value="amount">按金额</option>
                        </select>
                    </td>
                </tr>
                <tr class="tr_CalcualtePriceMonth">
                    <td>调价周期</td>
                    <td>
                        <input type="text" name="CalcualtePriceMonth" class="easyui-textbox" id="tdCalcualtePriceMonth" />（月）
                    </td>
                    <td>调价开始日期</td>
                    <td>
                        <input type="text" name="FirstReadyChargePrice" class="easyui-datebox" id="tdFirstReadyChargePriceTime" />
                    </td>
                </tr>
                <tr class="AutoChangePrice">
                    <td class="tiaojia_percent">调价比例</td>
                    <td class="tiaojia_percent">
                        <input type="text" name="CalculatePercent" class="easyui-textbox" id="tdCalculatePercent" />（%）
                    </td>
                    <td class="tiaojia_amount">调价金额</td>
                    <td class="tiaojia_amount">
                        <input type="text" name="CalculateAmount" class="easyui-textbox" id="tdCalculateAmount" />（元）
                    </td>
                </tr>
            </table>
            <div id="pricetable" style="display: none; margin: 10px 2.5%;">
                <table id="tt_table"></table>
                <div id="tb">
                    <a href="javascript:void(0)" onclick="doAddRow()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-add'">新增</a>
                    <a href="javascript:void(0)" onclick="doEditRow()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-edit'">修改</a>
                    <a href="javascript:void(0)" onclick="doRemoveRow()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-remove'">删除</a>
                </div>
            </div>
        </div>
    </form>
</asp:Content>
