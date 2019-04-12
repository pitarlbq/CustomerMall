<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="MemberAmountRuleEdit.aspx.cs" Inherits="Web.Mall.MemberAmountRuleEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        var ID, tdStartAmount, tdEndAmount, tdBackAmountType, tdBackPointType, tdAmountType, tdCoupons, hdCoupons, tdRuleType, tdIsSendNow, tdRoomID, tdIsUseForALLProject, hdIsUseForALLProduct, hdProducts, tdProducts, hdIsUseForALLService, hdServices;
        $(function () {
            ID = "<%=this.RuleID%>";
            tdStartAmount = $("#<%=this.tdStartAmount.ClientID%>");
            tdEndAmount = $("#<%=this.tdEndAmount.ClientID%>");
            tdBackAmountType = $("#<%=this.tdBackAmountType.ClientID%>");
            tdBackPointType = $("#<%=this.tdBackPointType.ClientID%>");
            tdAmountType = $("#<%=this.tdAmountType.ClientID%>");
            tdCoupons = $("#<%=this.tdCoupons.ClientID%>");
            hdCoupons = $("#<%=this.hdCoupons.ClientID%>");
            tdRuleType = $("#<%=this.tdRuleType.ClientID%>");
            tdIsSendNow = $("#<%=this.tdIsSendNow.ClientID%>");
            tdRoomID = $("#<%=this.tdRoomID.ClientID%>");
            hdRoomID = $("#<%=this.hdRoomID.ClientID%>");
            tdIsUseForALLProject = $("#<%=this.tdIsUseForALLProject.ClientID%>");
            hdIsUseForALLProduct = $("#<%=this.hdIsUseForALLProduct.ClientID%>");
            hdIsUseForALLService = $("#<%=this.hdIsUseForALLService.ClientID%>");
            hdServices = $("#<%=this.hdServices.ClientID%>");
            hdProducts = $("#<%=this.hdProducts.ClientID%>");
            tdProducts = $("#<%=this.tdProducts.ClientID%>");

            tdIsSendNow.bind('click', function () {
                check_type_status();
            })
            tdIsUseForALLProject.bind('click', function () {
                check_type_status();
            })
            tdBackAmountType.combobox({
                editable: false,
                onSelect: function () {
                    check_type_status();
                }
            })
            tdBackPointType.combobox({
                editable: false,
                onSelect: function () {
                    check_type_status();
                }
            })
            tdAmountType.combobox({
                editable: false,
                onSelect: function () {
                    check_type_status();
                }
            })
            tdRuleType.combobox({
                editable: false,
                onSelect: function () {
                    check_type_status();
                }
            })
            check_type_status();
        });
        function check_type_status() {
            if (tdIsUseForALLProject.prop('checked')) {
                $('.choose_project').hide();
            } else {
                $('.choose_project').show();
            }
            if (tdIsSendNow.prop('checked')) {
                $('.tr_sendtime').hide();
            } else {
                $('.tr_sendtime').show();
            }
            var amount_type = tdBackAmountType.combobox('getValue');
            if (amount_type == 1) {
                $('#label_amounttype').html('%');
            } else {
                $('#label_amounttype').html('元');
            }
            var point_type = tdBackPointType.combobox('getValue');
            if (point_type == 1) {
                $('#label_pointtype').html('%');
            } else {
                $('#label_pointtype').html('个');
            }
            var amount_type = tdAmountType.combobox('getValue');
            if (amount_type == 1) {
                $('.is_incoming').show();
                $('.tr_isuseforproduct').hide();
            } else {
                $('.is_incoming').hide();
                $('.tr_isuseforproduct').show();
            }
            var RuleType = tdRuleType.combobox('getValue');
            if (RuleType == 1) {
                $('.tr_point').show();
                $('.tr_amount').hide();
                $('.tr_coupon').hide();
                $('.tr_sendcount').hide();
            } else if (RuleType == 2) {
                $('.tr_point').hide();
                $('.tr_amount').show();
                $('.tr_coupon').hide();
                $('.tr_sendcount').hide();
            } else if (RuleType == 3) {
                $('.tr_point').hide();
                $('.tr_amount').hide();
                $('.tr_coupon').show();
                $('.tr_sendcount').show();
            }
        }
        function do_save() {
            var isValid = $("#<%=this.ff.ClientID%>").form('enableValidation').form('validate');
            if (!isValid) {
                return;
            }
            var start_value = tdStartAmount.textbox('getValue');
            var end_value = tdEndAmount.textbox('getValue');
            if (parseFloat(start_value) > parseFloat(end_value)) {
                show_message('金额区间开始金额不能大于结束金额', 'warning');
                return;
            }
            MaskUtil.mask('body', '提交中');
            $('#ff').form('submit', {
                url: '../Handler/MallHandler.ashx',
                onSubmit: function (param) {
                    param.visit = 'savemallamountrule';
                    param.ID = ID;
                    param.servicelist = hdCoupons.val();
                    param.ProjectIDList = hdRoomID.val();
                    param.ProductIDList = hdProducts.val();
                    param.ServiceIDList = hdServices.val();
                },
                success: function (data) {
                    MaskUtil.unmask();
                    var dataObj = eval("(" + data + ")");
                    if (dataObj.status) {
                        show_message('保存成功', 'success', function () {
                            do_close();
                        });
                        return;
                    }
                    if (dataObj.error) {
                        show_message(dataObj.error, 'warning');
                        return;
                    }
                    show_message('系统错误', 'error');
                }
            });
        }
        function choosecoupon() {
            isupdate = false;
            var iframe = "<iframe id='myFrame' scrolling='auto' frameborder='0' src='../Mall/ChooseCoupon.aspx' style='width:100%;height:" + ($(window).height() - 40) + "px'></iframe>";
            $("<div id='winchoose'></div>").appendTo("body").window({
                title: '选择卡券',
                width: ($(window).width() - 200),
                height: $(window).height(),
                top: 0,
                left: 100,
                modal: true,
                minimizable: false,
                maximizable: false,
                collapsible: false,
                content: iframe,
                onClose: function () {
                    $("#winchoose").remove();
                }
            });
        }
        function chooseproject() {
            isupdate = false;
            var iframe = "<iframe id='myFrame' scrolling='auto' frameborder='0' src='../APPSetup/ChooseMultipleProject.aspx' style='width:100%;height:" + ($(window).height() - 40) + "px'></iframe>";
            $("<div id='winchoose'></div>").appendTo("body").window({
                title: '选择范围',
                width: ($(window).width() - 200),
                height: $(window).height(),
                top: 0,
                left: 100,
                modal: true,
                minimizable: false,
                maximizable: false,
                collapsible: false,
                content: iframe,
                onClose: function () {
                    $("#winchoose").remove();
                }
            });
        }
        function chooseproduct() {
            isupdate = false;
            var title = '选择商品';
            var iframe = "../Mall/ChooseProduct.aspx?from=CouponCodeEdit";
            do_open_dialog(title, iframe);
        }
        function chooseservice() {
            isupdate = false;
            var title = '选择服务';
            var iframe = "../Mall/ChooseHouseService.aspx?from=CouponCodeEdit";
            do_open_dialog(title, iframe);
        }
        function do_close() {
            parent.do_close_dialog(function () {
                parent.$('#tt_table').datagrid('reload');
            });
        }
    </script>
    <style>
        .panel-body {
            background: #f0f0f0;
        }

        table.addtional_service {
            width: 100%;
            border: solid 1px #ccc;
            border-spacing: 0;
            border-collapse: collapse;
        }

            table.addtional_service td {
                border: solid 1px #ccc;
                padding: 10px;
                text-align: left;
            }

                table.addtional_service td:nth-child(2n-1) {
                    text-align: left;
                }

                table.addtional_service td input {
                    height: 25px;
                    line-height: 25px;
                    border-radius: 5px !important;
                }

        .sendtype label {
            margin-right: 10px;
            height: 25px;
            line-height: 25px;
            position: relative;
            padding-right: 25px;
        }

        .sendtype input {
            width: 15px;
            height: 15px;
            position: absolute;
            top: 50%;
            right: 0;
            margin-top: -7px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <form id="ff" runat="server" method="post" enctype="multipart/form-data">
        <div class="operation_box">
            <a href="javascript:void(0)" onclick="do_save()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-save'">保存</a>
            <a href="javascript:void(0)" onclick="do_close()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-close'">关闭</a>
        </div>
        <div class="table_container">
            <table class="info">
                <tr>
                    <td>规则名称</td>
                    <td>
                        <input type="text" class="easyui-textbox" runat="server" id="tdTitle" data-options="required:true" /></td>
                    <td>规则类型</td>
                    <td>
                        <select type="text" class="easyui-combobox" runat="server" id="tdAmountType" data-options="required:true">
                            <option value="1">充值</option>
                            <option value="2">消费</option>
                        </select></td>
                </tr>
                <tr>
                    <td>赠送类型</td>
                    <td>
                        <select id="tdRuleType" class="easyui-combobox" runat="server" style="width: 100px" data-options="editable:false,required:true">
                            <option value="1">积分</option>
                            <option value="2">余额</option>
                            <option value="3">福顺券</option>
                        </select>
                    </td>
                    <td>是否启动</td>
                    <td>
                        <select type="text" class="easyui-combobox" runat="server" id="tdIsActive" data-options="required:true">
                            <option value="1">是</option>
                            <option value="0">否</option>
                        </select></td>
                </tr>
                <tr>
                    <td>金额区间</td>
                    <td>
                        <input type="text" class="easyui-textbox" style="width: 100px;" runat="server" id="tdStartAmount" data-options="required:true" />(含)
                    -
                    <input type="text" class="easyui-textbox" style="width: 100px;" runat="server" id="tdEndAmount" data-options="required:true" />
                    </td>
                    <td>立即发放</td>
                    <td class="sendtype">
                        <label>
                            <input type="checkbox" runat="server" id="tdIsSendNow" value="1" /></label>
                    </td>
                </tr>
                <tr>
                    <td class="tr_sendtime">发放时间
                    </td>
                    <td class="tr_sendtime">
                        <input type="text" class="easyui-datebox" runat="server" id="tdIsReadySendTime" />
                    </td>
                    <td class="tr_sendcount">发放数量
                    </td>
                    <td class="tr_sendcount">
                        <input type="text" class="easyui-textbox" runat="server" id="tdSendCouponCount" />
                    </td>
                </tr>
                <tr>
                    <td>发放范围</td>
                    <td class="sendtype">
                        <label>
                            所有小区
                        <input type="checkbox" runat="server" id="tdIsUseForALLProject" value="1" />
                        </label>
                    </td>
                    <td class="choose_project">选择资源</td>
                    <td class="choose_project">
                        <input type="text" class="easyui-textbox" id="tdRoomID" runat="server" data-options="readonly:true,multiline:true" style="width: 200px; height: 50px;" />
                        <asp:HiddenField runat="server" ID="hdRoomID" />
                        <a href="javascript:void(0)" onclick="chooseproject()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-choose'">选择</a>
                    </td>
                </tr>
                <tr class="tr_isuseforproduct">
                    <td>购买商品返还
                    </td>
                    <td>
                        <select runat="server" id="tdIsUseForALLProduct" class="easyui-combobox" data-options="editable:false">
                            <option value="1">所有商品</option>
                            <option value="0">指定商品</option>
                        </select>
                        <asp:HiddenField runat="server" ID="hdIsUseForALLProduct" />
                    </td>
                    <td class="choose_product">
                        <a href="javascript:void(0)" onclick="chooseproduct()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-choose'">选择商品</a></td>
                    <td class="choose_product">
                        <input type="text" class="easyui-textbox" id="tdProducts" runat="server" data-options="multiline:true,readonly:true" style="height: 50px;" />
                        <asp:HiddenField runat="server" ID="hdProducts" />
                    </td>
                </tr>
                <tr class="tr_isuseforproduct">
                    <td>购买服务返还
                    </td>
                    <td>
                        <select runat="server" id="tdIsUseForALLService" class="easyui-combobox" data-options="editable:false">
                            <option value="1">所有服务</option>
                            <option value="0">指定服务</option>
                        </select>
                        <asp:HiddenField runat="server" ID="hdIsUseForALLService" />
                    </td>
                    <td class="choose_service">
                        <a href="javascript:void(0)" onclick="chooseservice()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-choose'">选择服务</a>
                    </td>
                    <td class="choose_service">
                        <input type="text" class="easyui-textbox" id="tdServices" runat="server" data-options="multiline:true,readonly:true" style="height: 50px;" />
                        <asp:HiddenField runat="server" ID="hdServices" />
                    </td>
                </tr>
                <tr class="tr_amount">
                    <td>返还金额</td>
                    <td colspan="3">
                        <select type="text" class="easyui-combobox" runat="server" id="tdBackAmountType" data-options="required:true">
                            <option value="1">按比例</option>
                            <option value="2">固定金额</option>
                        </select>&nbsp;&nbsp;返还
                    <input type="text" class="easyui-textbox" runat="server" id="tdBackAmount" /><label id="label_amounttype"></label></td>
                </tr>
                <tr class="tr_point">
                    <td>返还积分</td>
                    <td colspan="3">
                        <select type="text" class="easyui-combobox" runat="server" id="tdBackPointType" data-options="required:true">
                            <option value="1">按比例</option>
                            <option value="2">固定积分</option>
                        </select>&nbsp;&nbsp;返还
                    <input type="text" class="easyui-textbox" runat="server" id="tdBackPoint" />(<label id="label_pointtype"></label>)</td>
                </tr>
                <tr class="tr_coupon">
                    <td>选择卡券</td>
                    <td colspan="3">
                        <input type="text" class="easyui-textbox" id="tdCoupons" runat="server" data-options="multiline:true,readonly:true" style="height: 50px;" />
                        <asp:HiddenField runat="server" ID="hdCoupons" />
                        <label>
                            <a href="javascript:void(0)" onclick="choosecoupon()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-choose'">选择</a>
                        </label>
                    </td>
                </tr>
                <tr>
                    <td>通知规则
                    </td>
                    <td colspan="3">每<input type="text" class="easyui-textbox" id="tdPopupUnTakeDay" runat="server" style="width: 80px;" />天打开app时弹出<br />
                        据卡券到期时间<input type="text" class="easyui-textbox" id="tdPopupBeforeExpireDay" runat="server" style="width: 80px;" />天打开app时弹出
                    </td>
                </tr>
                <tr>
                    <td>备注</td>
                    <td colspan="3">
                        <input type="text" class="easyui-textbox" runat="server" id="tdRemark" data-options="multiline:true" style="height: 50px; width: 80%;" /></td>
                </tr>
                <tr>
                    <td colspan="4" style="text-align: center;">
                        <a href="javascript:void(0)" onclick="do_save()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-save'">保存</a>
                        <a href="javascript:void(0)" onclick="do_close()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-close'">关闭</a>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</asp:Content>
