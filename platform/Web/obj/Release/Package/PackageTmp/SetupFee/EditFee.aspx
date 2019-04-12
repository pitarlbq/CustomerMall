<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="EditFee.aspx.cs" Inherits="Web.SetupFee.EditFee" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../js/Page/Comm/GetTypeList.js?v=<%=base.getToken() %>"></script>
    <script type="text/javascript">
        var tdFeeType, tdCategory, tdCalculateAreaType, tdChargeType, tdChargeTypeCount, tdEndNumberType, tdIsReading, tdAllowImport, tdEndType, tdStartPriceRange, tdChargeFeeType, tdRelateCharges;
        $(function () {
            tdFeeType = $("#<%=this.tdFeeType.ClientID%>");
            tdCategory = $("#<%=this.tdCategory.ClientID%>");
            tdCalculateAreaType = $("#<%=this.tdCalculateAreaType.ClientID%>");
            tdChargeType = $("#<%=this.tdChargeType.ClientID%>");
            tdChargeTypeCount = $("#<%=this.tdChargeTypeCount.ClientID%>");
            tdEndNumberType = $("#<%=this.tdEndNumberType.ClientID%>");
            tdIsReading = $("#<%=this.tdIsReading.ClientID%>");
            tdAllowImport = $("#<%=this.tdAllowImport.ClientID%>");
            tdEndType = $("#<%=this.tdEndType.ClientID%>");
            tdStartPriceRange = $("#<%=this.StartPriceRange.ClientID%>");
            tdChargeFeeType = $("#<%=this.tdChargeFeeType.ClientID%>");
            tdRelateCharges = $("#<%=this.tdRelateCharges.ClientID%>");

            loadParams();
            initPanel();
            tdStartPriceRange.bind('click', function () {
                initPriceRange();
            })
            initPriceRange();
            tdIsReading.combobox({
                onSelect: function (rec) {
                    initChargeType();
                }
            });
            initChargeType();
            tdChargeTypeCount.textbox({
                onChange: function (ret) {
                    var ChargeTypeCount = tdChargeTypeCount.textbox("getValue");
                    if (ChargeTypeCount == 0) {
                        tdEndNumberType.combobox("setValue", 1);
                        $("#<%=this.tdAutoNextMonth.ClientID%>").prop("checked", true);
                    }
                }
            })
            var ChargeTypeCount = tdChargeTypeCount.textbox("getValue");
            ChargeTypeCount = ChargeTypeCount < 0 ? 0 : ChargeTypeCount;
            tdChargeTypeCount.textbox("setValue", ChargeTypeCount);
        });
        function initPriceRange() {
            if (tdStartPriceRange.prop('checked')) {
                $('.pricerange_css').show();
                $("#<%=this.tdUnitPrice.ClientID%>").textbox("setValue", "0")
                $("#<%=this.tdUnitPrice.ClientID%>").textbox({
                    disabled: true
                });
            }
            else {
                $('.pricerange_css').hide();
                $("#<%=this.tdUnitPrice.ClientID%>").textbox({
                    disabled: false
                });
            }
        }
        function initChargeType() {
            var selectedvalue = tdIsReading.combobox('getValue');
            if (selectedvalue == "1") {
                tdChargeType.combobox('setValue', 0);
                tdChargeType.combobox({
                    disabled: true
                })
            }
            else {
                tdChargeType.combobox({
                    disabled: false
                })
            }
        }

        function initPanel() {
            var feeType = tdFeeType.combobox("getValue");
            if (feeType == 1) {
                $("#panelZhouqi").panel({ closed: false });
                $("#panelLinshi").panel({ closed: true });
                $("#panelWeiyue").panel({ closed: true });
            }
            else if (feeType == 4) {
                $("#panelZhouqi").panel({ closed: true });
                $("#panelLinshi").panel({ closed: false });
                $("#panelWeiyue").panel({ closed: true });
            }
            else if (feeType == 8) {
                $("#panelZhouqi").panel({ closed: true });
                $("#panelLinshi").panel({ closed: true });
                $("#panelWeiyue").panel({ closed: false });
            }
        }
        function loadParams() {
            tdFeeType.combobox({
                data: getFeeTypeList(),
                valueField: 'ID',
                textField: 'Name',
                editable: false,
                onSelect: function (res) {
                    if (res.ID == 1) {
                        $("#panelZhouqi").panel({ closed: false });
                        $("#panelLinshi").panel({ closed: true });
                        $("#panelWeiyue").panel({ closed: true });
                    }
                    else if (res.ID == 4) {
                        $("#panelZhouqi").panel({ closed: true });
                        $("#panelLinshi").panel({ closed: false });
                        $("#panelWeiyue").panel({ closed: true });
                    }
                    else if (res.ID == 8) {
                        $("#panelZhouqi").panel({ closed: true });
                        $("#panelLinshi").panel({ closed: true });
                        $("#panelWeiyue").panel({ closed: false });
                    }
                }
            });

            tdChargeType.combobox({
                data: getChargeTypeList(),
                editable: false,
                valueField: 'ID',
                textField: 'Name'
            });

            tdEndType.combobox({
                data: getEndTypeList(),
                valueField: 'ID',
                textField: 'Name',
                editable: false,
                onSelect: function (rec) {
                    if (rec.ID == 3) {
                        $('#rulesetup').hide();
                    }
                    else {
                        $('#rulesetup').show();
                    }
                }
            });
            var EndTypeValue = tdEndType.combobox('getValue');
            if (EndTypeValue == 3) {
                $('#rulesetup').hide();
            }
            else {
                $('#rulesetup').show();
            }
            var options = { visit: 'getfeecategorylist' };
            $.post("../Handler/CommHandler.ashx", options, function (data) {
                tdCategory.combobox({
                    data: data,
                    valueField: 'ID',
                    textField: 'Name',
                    editable: false
                });
            }, "json");
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/AnalysisHandler.ashx?visit=gettochargesearch',
                success: function (data) {
                    tdRelateCharges.combobox({
                        editable: false,
                        data: data.summarys,
                        valueField: 'ID',
                        textField: 'Name',
                        multiple: true,
                    });
                }
            });
            var CalculateAreaTypeList = eval("(" + $('#<%=this.hdCalculateAreaType.ClientID%>').val() + ")");
            tdCalculateAreaType.combobox({
                data: CalculateAreaTypeList,
                valueField: 'ID',
                textField: 'Name',
                editable: false
            });

            tdChargeFeeType.combobox({
                data: getChargeFeeTypeList(),
                editable: false,
                valueField: 'ID',
                textField: 'Name'
            });
        }
        function do_save() {
            var isValid = $("#ff").form('enableValidation').form('validate');
            if (!isValid) {
                return;
            }
            var ChargeID = "<%=Request.QueryString["ID"]%>";
            var CompanyID = "<%=Web.WebUtil.GetCompanyID(this.Context)%>";
            var Name = $("#<%=this.tdName.ClientID%>").textbox("getValue");
            var FeeType = tdFeeType.combobox("getValue");
            var Category = tdCategory.combobox("getValue");
            //var StartTime = $("#<%=this.tdStartTime.ClientID%>").datebox("getValue");
            var StartTime = "";
            //var EndTime = $("#<%=this.tdEndTime.ClientID%>").datebox("getValue");
            var EndTime = "";
            var UnitPrice = $("#<%=this.tdUnitPrice.ClientID%>").textbox("getValue");
            var ChargeType = tdChargeType.combobox("getValue");
            var EndType = tdEndType.combobox("getValue");
            var ChargeTypeCount = tdChargeTypeCount.textbox("getValue");
            if (ChargeTypeCount == 0) {
                tdEndNumberType.combobox("setValue", 1);
                $("#<%=this.tdAutoNextMonth.ClientID%>").prop("checked", true);
            }
            var EndNumberCount = $("#<%=this.tdEndNumberCount.ClientID%>").combobox("getValue");
            var AllowImport = tdAllowImport.combobox("getValue");
            var Remark = $("#<%=this.tbRemark.ClientID%>").textbox("getValue");
            var Unit = $("#<%=this.tdUnit.ClientID%>").textbox("getValue");
            var IsReading = tdIsReading.combobox("getValue");
            var EndNumberType = tdEndNumberType.combobox("getValue");
            if (FeeType == 1 && parseFloat(ChargeTypeCount) < 0) {
                var shunyan_day = EndNumberType == 2 ? "天数" : "月份";
                show_message('周期费用顺延' + shunyan_day + '必须大于0', 'info');
                return;
            }
            var tdAutoNextMonth = document.getElementsByName("ctl00$content$tdAutoNextMonth");
            var AutoNextMonth = 0;
            for (var i = 0; i < tdAutoNextMonth.length; i++) {
                if (tdAutoNextMonth[i].checked) {
                    AutoNextMonth = 1;
                }
            }
            var BiaoCategory = $("#<%=this.tdBiaoCategory.ClientID%>").textbox("getValue");
            var ChargeBiaoIDs = $("#hdChargeBiaoID").val();
            if (BiaoCategory == "" && IsReading == 1) {
                show_message('表种类不能为空', 'info');
                return;
            }
            var TimeAuto = $("#<%=this.tdTimeAuto.ClientID%>").combobox("getValue");
            var SortOrder = $("#<%=this.tdSortOrder.ClientID%>").textbox("getValue");
            var IsOrderFeeOn = $("#<%=this.tdIsOrderFeeOn.ClientID%>").combobox("getValue");
            var WeiYuePercent = $("#<%=this.tdWeiYuePercent.ClientID%>").textbox("getValue");
            var RelateCharges = tdRelateCharges.combobox("getValues");
            var ChargeWeiYueType = $("#<%=this.tdChargeWeiYueType.ClientID%>").combobox("getValue");
            var DayGunLiCheck = document.getElementById('<%=this.tdDayGunLi.ClientID%>');
            var DayGunLi = 0;
            if (DayGunLiCheck.checked) {
                DayGunLi = 1;
            }
            var WeiYueStartDate = $("#<%=this.tdWeiYueStartDate.ClientID%>").combobox("getValue");
            var WeiYueBefore = $("#<%=this.tdWeiYueBefore.ClientID%>").combobox("getValue");
            var WeiYueDays = $("#<%=this.tdWeiYueDays.ClientID%>").textbox("getValue");
            var CalculateAreaType = tdCalculateAreaType.combobox("getValue");

            var WeiYueActiveStartDate = $("#<%=this.tdWeiYueActiveStartDate.ClientID%>").combobox("getValue");
            var WeiYueActiveBeforeAfter = $("#<%=this.tdWeiYueActiveBeforeAfter.ClientID%>").combobox("getValue");
            var WeiYueActiveCount = $("#<%=this.tdWeiYueActiveCount.ClientID%>").textbox("getValue");
            var WeiYueActiveDayMonth = $("#<%=this.tdWeiYueActiveDayMonth.ClientID%>").combobox("getValue");
            var WeiYueEndDate = $("#<%=this.tdWeiYueEndDate.ClientID%>").combobox("getValue");
            var StartPriceRange = 0;
            if (tdStartPriceRange.prop('checked')) {
                StartPriceRange = 1;
            }
            var PriceRangeStartTime = $("#<%=this.tdPriceRangeStartTime.ClientID%>").datebox("getValue");
            var DisableDefaultImportFee = $("#<%=this.tdDisableDefaultImportFee.ClientID%>").combobox("getValue");
            var ChargeFeeType = tdChargeFeeType.combobox('getValue');
            var options = { visit: "addchargeprice", ChargeID: ChargeID, Name: Name, Category: Category, StartTime: StartTime, EndTime: EndTime, UnitPrice: UnitPrice, ChargeType: ChargeType, EndType: EndType, ChargeTypeCount: ChargeTypeCount, EndNumberCount: EndNumberCount, AllowImport: AllowImport, Remark: Remark, CompanyID: CompanyID, FeeType: FeeType, Unit: Unit, IsReading: IsReading, EndNumberType: EndNumberType, AutoNextMonth: AutoNextMonth, BiaoCategory: BiaoCategory, TimeAuto: TimeAuto, SortOrder: SortOrder, IsOrderFeeOn: IsOrderFeeOn, ChargeBiaoIDs: ChargeBiaoIDs, WeiYuePercent: WeiYuePercent, RelateCharges: JSON.stringify(RelateCharges), ChargeWeiYueType: ChargeWeiYueType, DayGunLi: DayGunLi, WeiYueStartDate: WeiYueStartDate, WeiYueBefore: WeiYueBefore, WeiYueDays: WeiYueDays, CalculateAreaType: CalculateAreaType, WeiYueActiveStartDate: WeiYueActiveStartDate, WeiYueActiveBeforeAfter: WeiYueActiveBeforeAfter, WeiYueActiveCount: WeiYueActiveCount, WeiYueActiveDayMonth: WeiYueActiveDayMonth, WeiYueEndDate: WeiYueEndDate, StartPriceRange: StartPriceRange, DisableDefaultImportFee: DisableDefaultImportFee, PriceRangeStartTime: PriceRangeStartTime, ChargeFeeType: ChargeFeeType };
            MaskUtil.mask('body', '提交中');
            $.ajax({
                type: 'POST',
                dataType: 'json',
                data: options,
                url: '../Handler/FeeCenterHandler.ashx',
                success: function (data) {
                    MaskUtil.unmask();
                    if (data.status) {
                        show_message('保存成功', 'success', function () {
                            parent.chooseTitle = tdCategory.combobox('getText');
                            do_close();
                        });
                        return;
                    }
                    if (data.error) {
                        show_message(data.error, "info");
                        return;
                    }
                    show_message('系统错误', 'error');
                }
            });
        }
        function do_close() {
            parent.do_close_dialog(function () {
                parent.reload_tt();
            });
        }
        function editPriceRange() {
            var ChargeID = "<%=Request.QueryString["ID"]%>";
            if (ChargeID == null || ChargeID == '') {
                show_message('请先保存收费项目', 'info');
                return;
            }
            var iframe = "<iframe id='myFrame' scrolling='auto' frameborder='0' src='../SetupFee/EditPriceRange.aspx?ChargeID=" + ChargeID + "' style='width:100%;height:" + ($(window).height() - 40) + "px'></iframe>";
            $("<div id='winprice'></div>").appendTo("body").window({
                title: '阶梯单价',
                width: $(window).width() - 200,
                height: $(window).height(),
                top: 0,
                left: 100,
                modal: true,
                minimizable: false,
                maximizable: false,
                collapsible: false,
                content: iframe,
                onClose: function () {
                    $("#winprice").remove();
                }
            });
        }
        var pChargeBiaoIDs, pBiaoCategoryNames, pBiaoNames;
        function chooseBiao() {
            pChargeBiaoID = pBiaoCategoryName = pBiaoName = pBiaoGuiGe = '';
            var ChargeID = "<%=Request.QueryString["ID"]%>";
            if (ChargeID == null || ChargeID == '') {
                ChargeID = 0;
            }
            var iframe = "<iframe id='myFrame' scrolling='auto' frameborder='0' src='../SetupFee/ChooseBiao.aspx?ChargeID=" + ChargeID + "' style='width:100%;height:" + ($(window).height() - 40) + "px'></iframe>";
            $("<div id='winbiao'></div>").appendTo("body").window({
                title: '选择表种类',
                width: $(window).width() - 200,
                height: $(window).height(),
                top: 0,
                left: 100,
                modal: true,
                minimizable: false,
                maximizable: false,
                collapsible: false,
                content: iframe,
                onClose: function () {
                    $("#winbiao").remove();
                    if (pChargeBiaoIDs) {
                        $("#hdChargeBiaoID").val(pChargeBiaoIDs);
                        $("#<%=this.tdBiaoCategory.ClientID%>").textbox('setValue', pBiaoCategoryNames);
                    }
                }
            });
        }
    </script>
    <style type="text/css">
        .panel-body {
            background: #f0f0f0;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <form id="ff" method="post" runat="server">
        <div class="operation_box">
            <a href="javascript:void(0)" onclick="do_save()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-save'">保存</a>
            <a href="javascript:void(0)" onclick="do_close()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-close'">关闭</a>
        </div>
        <div class="table_container">
            <div class="easyui-panel" data-options="border:false,fit:false">
                <div class="table_title">主要信息</div>
                <table class="info">
                    <tr>
                        <td>排序序号
                        </td>
                        <td>
                            <input class="easyui-textbox" id="tdSortOrder" runat="server" />
                        </td>
                        <td>收费项目
                        </td>
                        <td>
                            <input id="tdName" class="easyui-textbox" data-options="required:true" runat="server" type="text" />
                        </td>
                    </tr>
                    <tr>
                        <td>收费性质
                        </td>
                        <td>
                            <input id="tdFeeType" class="easyui-combobox" data-options="required:true" runat="server" type="text" />
                        </td>
                        <td>分类
                        </td>
                        <td>
                            <input id="tdCategory" class="easyui-combobox" data-options="required:true" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td>默认单价
                        </td>
                        <td>
                            <input id="tdUnitPrice" class="easyui-textbox" type="text" runat="server" style="width: 100px;" />
                            阶梯单价
                            <input type="checkbox" runat="server" id="StartPriceRange" />
                            <a href="javascript:void(0)" onclick="editPriceRange()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-add'"></a>
                        </td>
                        <td>金额尾数
                        </td>
                        <td>
                            <select class="easyui-combobox" id="tdEndNumberCount" data-options="required:true,editable:false" runat="server">
                                <option value="0">元</option>
                                <option value="1">角</option>
                                <option value="2">分</option>
                                <option value="3">厘</option>
                            </select>
                        </td>
                    </tr>
                    <tr>
                        <td>默认计费面积/用量
                        </td>
                        <td>
                            <input class="easyui-combobox" id="tdCalculateAreaType" runat="server" />
                            <asp:HiddenField runat="server" ID="hdCalculateAreaType" />
                        </td>
                        <td>计费方式
                        </td>
                        <td>
                            <input id="tdChargeType" class="easyui-combobox" type="text" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td>启用收费序时
                        </td>
                        <td>
                            <select class="easyui-combobox" id="tdTimeAuto" runat="server" data-options="editable:false">
                                <option value="1">启用</option>
                                <option value="0" selected="selected">停用</option>
                            </select>
                        </td>
                        <td>启用交款审计
                        </td>
                        <td>
                            <select class="easyui-combobox" id="tdIsOrderFeeOn" data-options="editable:false" runat="server">
                                <option value="1">启用</option>
                                <option value="0" selected="selected">停用</option>
                            </select>
                        </td>
                    </tr>
                    <tr>
                        <td>项目类型
                        </td>
                        <td colspan="3">
                            <input type="text" class="easyui-combobox" id="tdChargeFeeType" runat="server" />
                        </td>
                    </tr>
                    <tr class="pricerange_css">
                        <td>阶梯单价执行时间
                        </td>
                        <td colspan="3">
                            <input type="text" class="easyui-datebox" id="tdPriceRangeStartTime" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td>备注
                        </td>
                        <td colspan="3">
                            <input class="easyui-textbox" data-options="multiline:true" id="tbRemark" runat="server" style="height: 50px; width: 80%;" />
                        </td>
                    </tr>
                </table>
            </div>
            <div class="easyui-panel" id="panelZhouqi" data-options="border:false,fit:false,closed:true" title="">
                <div class="table_title">费项参数(周期)</div>
                <table class="info">
                    <tr style="display: none;">
                        <td>计费开始日期
                        </td>
                        <td>
                            <input id="tdStartTime" type="text" class="easyui-datebox" runat="server" />
                        </td>
                        <td>计费结束日期
                        </td>
                        <td>
                            <input id="tdEndTime" type="text" class="easyui-datebox" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td>计费规则
                        </td>
                        <td colspan="3" style="width: 85%;">计算结束日期默认为&nbsp;&nbsp;
                        <input class="easyui-combobox" id="tdEndType" type="text" runat="server" />
                            <label id="rulesetup">
                                &nbsp;&nbsp;顺延&nbsp;&nbsp;
                        <input class="easyui-textbox" style="width: 30px;" id="tdChargeTypeCount" runat="server" />
                                <select class="easyui-combobox" data-options="editable:false" id="tdEndNumberType" runat="server" style="width: 60px;">
                                    <option value="1">月</option>
                                    <option value="2">日</option>
                                </select>
                                &nbsp;&nbsp;                       
                                <asp:CheckBox runat="server" ID="tdAutoNextMonth" Text="自动取整至月末" />
                            </label>
                        </td>
                    </tr>
                </table>
            </div>
            <div class="easyui-panel" id="panelLinshi" data-options="border:false,fit:false,closed:true">
                <div class="table_title">费项参数(临时)</div>
                <table class="info">
                    <tr>
                        <td>是否抄表
                        </td>
                        <td>
                            <select class="easyui-combobox" data-options="editable:false" id="tdIsReading" runat="server">
                                <option value="1">是</option>
                                <option value="0" selected="selected">否</option>
                            </select>
                        </td>
                        <td>批量账单处理
                        </td>
                        <td>
                            <select class="easyui-combobox" data-options="editable:false" id="tdAllowImport" runat="server">
                                <option value="1" selected="selected">是</option>
                                <option value="0">否</option>
                            </select>
                        </td>
                    </tr>
                    <tr>
                        <td>计量单位
                        </td>
                        <td>
                            <input class="easyui-textbox" id="tdUnit" runat="server" />
                        </td>
                        <td>表种类
                        </td>
                        <td>
                            <input class="easyui-textbox" id="tdBiaoCategory" data-options="readonly:true,multiline:true" runat="server" style="height: 50px;" />
                            <input type="hidden" id="hdChargeBiaoID" />
                            <a href="javascript:void(0)" onclick="chooseBiao()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-choose'">选择</a>
                        </td>
                    </tr>
                    <tr>
                        <td>启用默认账单
                        </td>
                        <td colspan="3">
                            <select class="easyui-combobox" data-options="editable:false" id="tdDisableDefaultImportFee" runat="server">
                                <option value="0">启用</option>
                                <option value="1">停用</option>
                            </select>
                        </td>
                    </tr>
                </table>
            </div>
            <div class="easyui-panel" id="panelWeiyue" data-options="border:false,fit:false,closed:true">
                <div class="table_title">费项参数(违约金)</div>
                <table class="info">
                    <tr>
                        <td>违约金比例
                        </td>
                        <td>
                            <input type="text" class="easyui-textbox" runat="server" id="tdWeiYuePercent" />
                        </td>
                        <td>关联项目</td>
                        <td>
                            <input type="text" class="easyui-combobox" runat="server" id="tdRelateCharges" />
                        </td>
                    </tr>
                    <tr>
                        <td>计费方式
                        </td>
                        <td>
                            <select class="easyui-combobox" id="tdChargeWeiYueType" data-options="editable:false" runat="server">
                                <option value="1">费用金额*天*违约金比例</option>
                            </select>
                        </td>
                        <td>按天复利滚动</td>
                        <td>
                            <input type="checkbox" runat="server" id="tdDayGunLi" />
                        </td>
                    </tr>
                    <tr>
                        <td>违约生效规则
                        </td>
                        <td colspan="3">
                            <select class="easyui-combobox" id="tdWeiYueActiveStartDate" type="text" runat="server" data-options="editable:false">
                                <option value="starttime">计费开始日期</option>
                                <option value="endtime">计算结束日期</option>
                            </select>
                            &nbsp;&nbsp;
                            <select class="easyui-combobox" id="tdWeiYueActiveBeforeAfter" type="text" runat="server" style="width: 60px;" data-options="editable:false">
                                <option value="before">早于</option>
                                <option value="after">晚于</option>
                            </select>
                            &nbsp;&nbsp;
                            当前自然日期
                            &nbsp;&nbsp;
                            <input class="easyui-textbox" style="width: 30px;" id="tdWeiYueActiveCount" runat="server" />
                            &nbsp;&nbsp;
                             <select class="easyui-combobox" id="tdWeiYueActiveDayMonth" type="text" runat="server" style="width: 60px;" data-options="editable:false">
                                 <option value="day">天</option>
                                 <option value="month">月</option>
                             </select>
                        </td>
                    </tr>
                    <tr>
                        <td>违约开始日期规则
                        </td>
                        <td colspan="3">默认为对应项目&nbsp;&nbsp;
                        <select class="easyui-combobox" id="tdWeiYueStartDate" type="text" runat="server" data-options="editable:false">
                            <option value="starttime">计费开始日期</option>
                            <option value="endtime">计算结束日期</option>
                        </select>
                            &nbsp;&nbsp;
                            <select class="easyui-combobox" id="tdWeiYueBefore" type="text" runat="server" style="width: 60px;" data-options="editable:false">
                                <option value="before">提前</option>
                                <option value="after">延后</option>
                            </select>&nbsp;&nbsp;<input class="easyui-textbox" style="width: 30px;" id="tdWeiYueDays" runat="server" />&nbsp;&nbsp;天
                        </td>
                    </tr>
                    <tr>
                        <td>违约截止日期规则
                        </td>
                        <td colspan="3">
                            <select class="easyui-combobox" id="tdWeiYueEndDate" type="text" runat="server" data-options="editable:false">
                                <option value="currentdate">当前自然日期</option>
                            </select>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </form>
</asp:Content>
