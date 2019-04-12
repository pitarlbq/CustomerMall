var tt_CanLoad = false, isUpdate = false, content;
$(function () {
    content = new Vue({
        el: '#fieldcontent',
        data: {
            list: [],
            rulelist: [],
            form: {
                OrderIDList: []
            },
        },
        methods: {
            getdata: function () {
                var that = this;
                that.form.OrderIDList = parent.GetOrderIDList();
                if (that.form.OrderIDList.length == 0) {
                    show_message("请至少选择一条数据进行此操作", "info");
                    return;
                }
                var options = {
                    visit: 'getbalanceapplicationlist',
                    OrderIDList: JSON.stringify(that.form.OrderIDList)
                };
                MaskUtil.mask('body');
                $.ajax({
                    type: 'POST',
                    dataType: 'json',
                    url: '../Handler/MallHandler.ashx',
                    data: options,
                    success: function (data) {
                        MaskUtil.unmask();
                        if (data.status) {
                            that.list = data.list;
                            that.rulelist = data.rulelist;
                            that.reset_easyui();
                            return;
                        }
                        if (data.error) {
                            show_message(data.error, "info");
                            return;
                        }
                        show_message('系统错误', 'error');
                    }
                });
            },
            reset_easyui: function () {
                var that = this;
                setTimeout(function () {
                    for (var i = 0; i < that.list.length; i++) {
                        that.reset_easyui_box(that.list[i]);
                    }
                }, 200);
                return;
            },
            reset_easyui_box: function (item) {
                var that = this;
                var elem_account = $('#' + item.BusinessID + '_account');
                if (elem_account) {
                    elem_account.addClass('easyui-textbox');
                }
                var elem_rule = $('#' + item.BusinessID + '_rule');
                if (elem_rule) {
                    elem_rule.addClass('easyui-combobox');
                }
                var elem_balance = $('#' + item.BusinessID + '_balance');
                if (elem_balance) {
                    elem_balance.addClass('easyui-textbox');
                }
                $.parser.parse('#table_' + item.BusinessID);
                elem_account.textbox('setValue', item.BusinessBalanceAccount);
                elem_rule.combobox('setValue', item.BalanceRuleID);
                elem_balance.textbox('setValue', item.BalanceAmount);
                elem_rule.combobox({
                    editable: false,
                    data: that.rulelist,
                    valueField: 'ID',
                    textField: 'Title',
                    onSelect: function (res) {
                        that.calculate_balance(item, res.BackAmount, res.BackBalanceType);
                    }
                })
            },
            calculate_balance: function (item, BackAmount, BackBalanceType) {
                var that = this;
                var balance = BackAmount;
                if (BackBalanceType == 1) {
                    balance = ((item.TotalCost * BackAmount) / 100).toFixed(2);
                }
                item.BalanceAmount = balance;
                $('#' + item.BusinessID + '_balance').textbox('setValue', item.BalanceAmount);
            },
            set_list_value: function () {
                var that = this;
                $.each(that.list, function (index, item) {
                    item.BusinessBalanceAccount = $('#' + item.BusinessID + '_account').textbox('getValue');
                    item.BalanceRuleID = $('#' + item.BusinessID + '_rule').combobox('getValue');
                    item.BalanceAmount = $('#' + item.BusinessID + '_balance').textbox('getValue');
                });
            }
        }
    });
    content.getdata();
});
function do_save() {
    content.set_list_value();
    var options = {
        visit: 'savebalanceapplication',
        List: JSON.stringify(content.list)
    };
    MaskUtil.mask('body', "提交中");
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: '../Handler/MallHandler.ashx',
        data: options,
        success: function (data) {
            MaskUtil.unmask();
            if (data.status) {
                show_message('保存成功', "success", function () {
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
        parent.$('#tt_table').datagrid('reload');
    });
}
