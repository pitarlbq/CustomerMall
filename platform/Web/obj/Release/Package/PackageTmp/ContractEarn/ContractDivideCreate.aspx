<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="ContractDivideCreate.aspx.cs" Inherits="Web.ContractEarn.ContractDivideCreate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../js/vue.js"></script>
    <script>
        var content, tdRentName, ContractID, tdSellCost, tdDivideType, hdChargeSummary, tdChargeSummary;
        $(function () {
            ContractID = '<%=this.ContractID%>';
            tdSellCost = $('#<%=this.tdSellCost.ClientID%>');
            tdDivideType = $('#<%=this.tdDivideType.ClientID%>');
            hdChargeSummary = $('#<%=this.hdChargeSummary.ClientID%>');
            tdChargeSummary = $('#<%=this.tdChargeSummary.ClientID%>');
            loadVue();
            tdDivideType.combobox({
                onSelect: function (ret) {
                    change_dividetype();
                }
            });
            if (hdChargeSummary.val() != '') {
                var chargeList = eval('(' + hdChargeSummary.val() + ')');
                tdChargeSummary.combobox({
                    editable: false,
                    textField: 'Name',
                    valueField: 'ID',
                    data: chargeList
                })
            }
        });
        function loadVue() {
            content = new Vue({
                el: '#fieldcontent',
                data: {
                    list: [],
                    count: 0,
                    show_type: false,
                },
                methods: {
                    add_line: function () {
                        var that = this;
                        if (tdSellCost.textbox('getValue') == '') {
                            show_message("销售额不能为空", "warning");
                            return;
                        }
                        var sellcost = parseFloat(tdSellCost.textbox('getValue'));
                        if (sellcost <= 0) {
                            show_message("销售额不能为0", "warning");
                            return;
                        }
                        that.count++;
                        var startcost = 0;
                        if (that.list.length > 0) {
                            startcost = that.list[that.list.length - 1].DivideEndCost;
                        }
                        if (startcost >= sellcost) {
                            show_message("分成金额区间已达销售额上限", "warning");
                            return;
                        }
                        var item = { ID: 0, DivideStartCost: startcost, DivideEndCost: sellcost, Divide_Percent: 0, count: that.count };
                        that.list.push(item);
                    },
                    remove_line: function (item) {
                        var that = this;
                        that.set_value();
                        if (item.ID == 0) {
                            $.each(that.list, function (index, item2) {
                                if (item.count == item2.count) {
                                    that.list.splice(index, 1);
                                    return false;
                                }
                            });
                        }
                    }
                }
            });
        }
        function change_dividetype() {
            var value = tdDivideType.combobox('getValue');
            if (value == 'fixedpercent') {
                $('.fixpercent').show();
                content.show_type = false;
            }
            else {
                $('.fixpercent').hide();
                content.show_type = true;
            }
        }
        function do_close() {
            parent.do_close_dialog(function () {
                parent.$('#tt_table').datagrid('reload');
            });
        }
        function do_save() {
            var isValid = $("#<%=this.ff.ClientID%>").form('enableValidation').form('validate');
            if (!isValid) {
                return;
            }
            var rows = parent.$("#tt_table").datagrid("getSelections");
            if (rows.length == 0) {
                show_message("请先选择一个扣点合同", "info");
                return;
            }
            var IDList = [];
            $.each(rows, function (index, row) {
                IDList.push(row.ID);
            })
            var type_list = [];
            if (content.show_type) {
                $.each(content.list, function (index, item) {
                    if (item.DivideStartCost >= 0 && item.DivideEndCost > 0 && item.Divide_Percent > 0) {
                        type_list.push(item);
                    }
                })
                if (type_list.length == 0) {
                    show_message("请填写阶梯分成", "warning");
                    return;
                }
            }

            MaskUtil.mask('body', '提交中');
            $('#ff').form('submit', {
                url: '../Handler/ContractHandler.ashx',
                onSubmit: function (param) {
                    param.visit = 'savecontractdiviecreate';
                    param.type_list = JSON.stringify(type_list);
                    param.IDList = JSON.stringify(IDList);
                },
                success: function (data) {
                    MaskUtil.unmask();
                    var dataObj = eval("(" + data + ")");
                    if (dataObj.status) {
                        show_message("账单生成成功", "success", function () {
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
    </script>
    <style>
        .panel-body {
            background: #f0f0f0;
        }

        table.field {
            margin: 0 auto;
            width: 95%;
            border-collapse: collapse;
            border-spacing: 0;
            border: solid 1px #ccc;
            background: #fff;
            border-radius: 5px;
        }

            table.field td {
                padding: 5px 10px;
                text-align: left;
                vertical-align: middle;
                border: solid 1px #ccc;
                text-align: left;
                width: 35%;
            }

            table.field input[type='text'] {
                width: 200px;
                height: 25px;
                line-height: 25px;
                border-radius: 5px !important;
                border: solid 1px #ddd;
            }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <form id="ff" runat="server" method="post" enctype="multipart/form-data">
        <div class="operation_box">
            <a href="javascript:void(0)" onclick="do_save()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-shengcheng'">生成</a>
            <a href="javascript:void(0)" onclick="do_close()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-close'">关闭</a>
        </div>
        <div class="table_container">
            <div class="table_title">
                基本信息
            </div>
            <table class="info">
                <%if (ContractID > 0)
                  { %>
                <tr>
                    <td style="width: 100px;">合同编号：
                    </td>
                    <td>
                        <input id="tdContractNo" runat="server" type="text" class="easyui-textbox" data-options="disabled:true" />
                    </td>
                    <td>销售额：
                    </td>
                    <td>
                        <input id="tdSellCost" runat="server" type="text" class="easyui-textbox" data-options="disabled:true" />
                    </td>
                </tr>
                <tr>
                    <td style="width: 100px;">分成方式：
                    </td>
                    <td>
                        <select id="tdDivideType" runat="server" class="easyui-combobox" data-options="required:true,disabled:true">
                            <option value="fixedpercent">固定比例</option>
                            <option value="jietipercent">阶梯比例</option>
                        </select>
                    </td>
                    <td class="fixpercent">分成比例
                    </td>
                    <td class="fixpercent">
                        <input id="tdFixedPercent" runat="server" type="text" class="easyui-textbox" data-options="disabled:true" />%
                    </td>
                </tr>
                <%} %>
                <tr>
                    <td>账单日期：
                    </td>
                    <td>
                        <input id="tdWirteDate" runat="server" type="text" class="easyui-datebox" data-options="required:true" />
                    </td>
                    <td>收费项目：
                    </td>
                    <td>
                        <input id="tdChargeSummary" runat="server" type="text" class="easyui-combobox" data-options="required:true" />
                        <asp:HiddenField runat="server" ID="hdChargeSummary" />
                    </td>
                </tr>
                <tr>
                    <td>计费开始日期：
                    </td>
                    <td>
                        <input id="tdStartTime" runat="server" type="text" class="easyui-datebox" />
                    </td>
                    <td>计费结束日期：
                    </td>
                    <td>
                        <input id="tdEndTime" runat="server" type="text" class="easyui-datebox" />
                    </td>
                </tr>
                <tr>
                    <td style="width: 100px;">备注：
                    </td>
                    <td colspan="3">
                        <input id="tdRemark" type="text" runat="server" class="easyui-textbox" data-options="multiline:true" style="width: 80%; height: 50px;" />
                    </td>
                </tr>
            </table>
            <div id="fieldcontent">
                <div class="table_title" v-if="show_type">
                    阶梯分成
                </div>
                <table class="field" v-if="show_type">
                    <tr>
                        <td colspan="3">
                            <a href="javascript:void(0)" v-on:click="add_line()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-add'">添加</a>
                        </td>
                    </tr>
                    <tr>
                        <td>费用区间
                        </td>
                        <td>分成比例
                        </td>
                        <td></td>
                    </tr>
                    <tr v-for="(item, index) in list">
                        <td style="width: 50%;">
                            <input type="text" v-model="item.DivideStartCost" />
                            -
                        <input type="text" v-model="item.DivideEndCost" />
                        </td>
                        <td style="width: 30%;">
                            <input type="text" v-model="item.Divide_Percent" />%
                        </td>
                        <td>
                            <a href="javascript:void(0)" v-on:click="remove_line(item)" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-remove'">删除</a>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </form>
</asp:Content>
