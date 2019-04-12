var tt_CanLoad;
var summary_CanLoad;
var summary_other_CanLoad;
var content;
$(function () {
    setTimeout(function () {
        load_vue();
    }, 500);
});
function getContractID() {
    if (parent.ContractID > 0 && ContractID <= 0) {
        ContractID = parent.ContractID;
    }
}
function load_vue() {
    content = new Vue({
        el: '#fieldcontent',
        data: {
            list: [],
            count: 0,
            choose_chargenames: [],
            choose_chargeids: [],
            currentitem: null
        },
        methods: {
            getdata: function () {
                var that = this;
                getContractID();
                if (ContractID <= 0) {
                    return;
                }
                var options = { visit: 'getcontractfreetime', ContractID: ContractID };
                $.ajax({
                    type: 'POST',
                    dataType: 'json',
                    url: '../Handler/ContractHandler.ashx',
                    data: options,
                    success: function (data) {
                        if (data.status) {
                            that.list = data.list;
                            that.count = that.list.length;
                            that.reset_easyui(true);
                            return;
                        }
                        show_message('系统错误', 'error');
                    }
                });
            },
            reset_easyui_box: function (index) {
                var that = this;
                var elem_starttime = $('#' + index + '_starttime');
                if (elem_starttime) {
                    elem_starttime.addClass('easyui-datebox');
                }
                var elem_endtime = $('#' + index + '_endtime');
                if (elem_endtime) {
                    elem_endtime.addClass('easyui-datebox');
                }
                var elem_freecount = $('#' + index + '_freecount');
                if (elem_freecount) {
                    elem_freecount.addClass('easyui-textbox');
                }
                var elem_freetype = $('#' + index + '_freetype');
                if (elem_freetype) {
                    elem_freetype.addClass('easyui-combobox');
                }
                var elem_roomid = $('#' + index + '_roomid');
                if (elem_roomid) {
                    elem_roomid.addClass('easyui-combobox');
                }
                $.parser.parse('#tr_' + index);
                elem_starttime.datebox({
                    onChange: function () {
                        that.set_list_value();
                    }
                })
                elem_endtime.datebox({
                    onChange: function () {
                        that.set_list_value();
                    }
                })
                elem_freecount.textbox({
                    onChange: function () {
                        that.calculate_endtime();
                    }
                })
                elem_freetype.combobox({
                    onSelect: function () {
                        that.set_list_value();
                    }
                })
                elem_roomid.combobox({
                    data: that.getRoomList(),
                    valueField: 'ID',
                    textField: 'Name',
                    multiple: true,
                    editable: false,
                    onSelect: function () {
                        that.set_list_value();
                    },
                    onUnselect: function () {
                        that.set_list_value();
                    }
                })
            },
            getRoomList: function () {
                var that = this;
                var rows = parent.getRooms();
                var list = [];
                $.each(rows, function (index, row) {
                    list.push({ ID: row.RoomID, Name: row.Name });
                })
                return list;
            },
            reset_easyui: function (alllist) {
                var that = this;
                that.set_box_value();
                if (alllist) {
                    setTimeout(function () {
                        for (var i = 0; i < that.list.length; i++) {
                            var index = that.list[i].count;
                            that.reset_easyui_box(index);
                        }
                    }, 200);
                    return;
                }
                setTimeout(function () {
                    var index = that.count;
                    that.reset_easyui_box(index);
                }, 200);
            },
            set_box_value: function () {
                var that = this;
                setTimeout(function () {
                    $.each(that.list, function (index, item) {
                        $('#' + item.count + '_starttime').datebox('setValue', item.StartTime);
                        $('#' + item.count + '_endtime').datebox('setValue', item.EndTime);
                        //$('#' + item.count + '_freecount').textbox('setValue', item.FreeCount);
                        $('#' + item.count + '_freetype').combobox('setValue', item.FreeType);
                        $('#' + item.count + '_roomid').combobox('setValues', item.RoomIDs);
                    });
                    that.set_list_value();
                }, 500);
            },
            add_line: function () {
                var that = this;
                that.count++;
                var item = { ID: 0, StartTime: '', EndTime: '', FreeCount: '', FreeType: 1, FreeChargeNames: '', FreeChargeIDs: '', count: that.count, RoomIDs: [] };
                that.list.push(item);
                that.reset_easyui();
            },
            set_list_value: function () {
                var that = this;
                var totaldays = 0;
                $.each(that.list, function (index, item) {
                    item.StartTime = $('#' + item.count + '_starttime').datebox('getValue');
                    item.EndTime = $('#' + item.count + '_endtime').datebox('getValue');
                    //item.FreeCount = $('#' + item.count + '_freecount').textbox('getValue');
                    item.FreeType = $('#' + item.count + '_freetype').combobox('getValue');
                    item.RoomIDs = $('#' + item.count + '_roomid').combobox('getValues');
                    totaldays = calculate_day(item.StartTime, item.EndTime);
                    item.FreeCount = totaldays;
                    $('#' + item.count + '_freecount').textbox('setValue', item.FreeCount);
                });
            },
            calculate_endtime: function () {
                var that = this;
                $.each(that.list, function (index, item) {
                    item.FreeCount = $('#' + item.count + '_freecount').textbox('getValue');
                    if (item.FreeCount != '') {
                        item.EndTime = that.addDay(item.FreeCount - 1, item.StartTime);
                        $('#' + item.count + '_endtime').datebox('setValue', item.EndTime);
                    }
                });
            },
            addDay: function (dayNumber, date) {
                var that = this;
                if (!date) {
                    return '';
                }
                date = stringToDate(date);
                var ms = dayNumber * (1000 * 60 * 60 * 24)
                var newDate = new Date(date.getTime() + ms);
                var y = newDate.getFullYear(), M = newDate.getMonth() + 1, d = newDate.getDate();
                return [y, M < 10 ? "0" + M : M, d < 10 ? "0" + d : d].join("-");
            },
            remove_line: function (item) {
                var that = this;
                if (item.ID == 0) {
                    $.each(that.list, function (index, item2) {
                        if (item.count == item2.count) {
                            that.list.splice(index, 1);
                            return false;
                        }
                    });
                    that.set_box_value();
                    return;
                }
                top.$.messager.confirm('提示', '确认删除?', function (r) {
                    if (r) {
                        var options = { visit: 'removecontractfreetime', ID: item.ID };
                        $.ajax({
                            type: 'POST',
                            dataType: 'json',
                            url: '../Handler/ContractHandler.ashx',
                            data: options,
                            success: function (data) {
                                if (data.status) {
                                    $.each(that.list, function (index, item2) {
                                        if (item.count == item2.count) {
                                            that.list.splice(index, 1);
                                            return false;
                                        }
                                    });
                                    that.set_box_value();
                                    return;
                                }
                                show_message('系统错误', 'error');
                            }
                        });
                    }
                })
            },
            do_choose_charge: function (item) {
                var that = this;
                that.currentitem = item;
                var iframe = "../Contract/ChooseChargeSummary.aspx?source=freerent";
                do_open_dialog('选择收费项目', iframe);
            }
        }
    });
    content.getdata();
}
function do_choose_charge_done() {
    if (content.choose_chargenames.length > 0) {
        $.each(content.choose_chargenames, function (index, item2) {
            if (index == 0) {
                content.currentitem.FreeChargeNames = item2;
            }
            else {
                content.currentitem.FreeChargeNames += ',' + item2;
            }
        })
    }
    if (content.choose_chargeids.length > 0) {
        content.currentitem.FreeChargeIDs = JSON.stringify(content.choose_chargeids);
    }
}
function getContractFeeRentList() {
    var list = [];
    content.set_list_value();
    $.each(content.list, function (index, item) {
        if (item.StartTime == '' || item.EndTime == '') {
            return true;
        }
        list.push(item);
    })
    return list;
}