var tt_CanLoad;
var summary_CanLoad;
var summary_other_CanLoad;
var content;
$(function () {
    addFile();
    loadTT();
    setTimeout(function () {
        loadsuammryTT();
    }, 100);
    if (ContractID > 0) {
        loadattachs();
    }
    RentStartTimeObj.datebox({
        onSelect: function (ret) {
            calculateTimeLimit();
        }
    })
    RentEndTimeObj.datebox({
        onSelect: function (ret) {
            calculateTimeLimit();
        }
    })
    if (canrent == 0) {
        load_vue();
    }
    setRentStatus();
});
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
                var elem_freetype = $('#' + index + '_freetype');
                if (elem_freetype) {
                    elem_freetype.addClass('easyui-combobox');
                }
                $.parser.parse('#tr_' + index);
                elem_starttime.datebox({
                    onSelect: function () {
                        that.set_list_value();
                    }
                })
                elem_endtime.datebox({
                    onSelect: function () {
                        that.set_list_value();
                    }
                })
                elem_freetype.combobox({
                    onSelect: function () {
                        that.set_list_value();
                    }
                })
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
                        $('#' + item.count + '_freetype').combobox('setValue', item.FreeType);
                    });
                    that.set_list_value();
                }, 500);
            },
            add_line: function () {
                var that = this;
                that.count++;
                var item = { ID: 0, StartTime: '', EndTime: '', FreeType: 1, FreeChargeNames: '', FreeChargeIDs: '', count: that.count };
                that.list.push(item);
                that.reset_easyui();
            },
            set_list_value: function () {
                var that = this;
                var totaldays = 0;
                $.each(that.list, function (index, item) {
                    item.StartTime = $('#' + item.count + '_starttime').datebox('getValue');
                    item.EndTime = $('#' + item.count + '_endtime').datebox('getValue');
                    item.FreeType = $('#' + item.count + '_freetype').combobox('getValue');
                    totaldays += calculate_day(item.StartTime, item.EndTime);
                });
                tdFreeDays.textbox('setValue', totaldays);
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
                var iframe = "../Contract/ChooseChargeSummary.aspx";
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
function setRentStatus() {
    setTimeout(function () {
        if (canadd != 1) {
            $('#room_show').show();
            $('#room_icon_show').attr('data-value', '0');
            $('#room_icon_show label img').attr('src', '../styles/icons/double_up_arrow.png');
            $('#fieldcontent').show();
            $('#zuqi_icon_show').attr('data-value', '0');
            $('#zuqi_icon_show label img').attr('src', '../styles/icons/double_up_arrow.png');
            $('#charge_show').show();
            $('#charge_icon_show').attr('data-value', '0');
            $('#charge_icon_show label img').attr('src', '../styles/icons/double_up_arrow.png');
            $('#table_other').show();
            $('#other_icon_show').attr('data-value', '0');
            $('#other_icon_show label img').attr('src', '../styles/icons/double_up_arrow.png');
        }
        else {
            $('#room_show').hide();
            $('#fieldcontent').hide();
            $('#charge_show').hide();
            $('#table_other').hide();
        }
    }, 300)
    $('#room_icon_show').bind('click', function () {
        var value = $(this).attr('data-value');
        if (value == '1') {
            $('#room_show').show();
            $(this).attr('data-value', '0');
            $('#room_icon_show label img').attr('src', '../styles/icons/double_up_arrow.png');
        }
        else {
            $('#room_show').hide();
            $(this).attr('data-value', '1');
            $('#room_icon_show label img').attr('src', '../styles/icons/double_down_arrow.png');
        }
    });
    $('#zuqi_icon_show').bind('click', function () {
        var value = $(this).attr('data-value');
        if (value == '1') {
            $('#fieldcontent').show();
            $(this).attr('data-value', '0');
            $('#zuqi_icon_show label img').attr('src', '../styles/icons/double_up_arrow.png');
        }
        else {
            $('#fieldcontent').hide();
            $(this).attr('data-value', '1');
            $('#zuqi_icon_show label img').attr('src', '../styles/icons/double_down_arrow.png');
        }
    })
    $('#charge_icon_show').bind('click', function () {
        var value = $(this).attr('data-value');
        if (value == '1') {
            $('#charge_show').show();
            $(this).attr('data-value', '0');
            $('#charge_icon_show label img').attr('src', '../styles/icons/double_up_arrow.png');
        }
        else {
            $('#charge_show').hide();
            $(this).attr('data-value', '1');
            $('#charge_icon_show label img').attr('src', '../styles/icons/double_down_arrow.png');
            setTimeout(function () {
                $('#tt_chargesummary').datagrid('options').fitColumns = false;
            }, 500)
        }
    })
    $('#other_icon_show').bind('click', function () {
        var value = $(this).attr('data-value');
        if (value == '1') {
            $('#table_other').show();
            $(this).attr('data-value', '0');
            $('#other_icon_show label img').attr('src', '../styles/icons/double_up_arrow.png');
        }
        else {
            $('#table_other').hide();
            $(this).attr('data-value', '1');
            $('#other_icon_show label img').attr('src', '../styles/icons/double_down_arrow.png');
        }
    })
    if (canrent == 0) {
        return;
    }
    $("input[data-name='rent_content']").each(function (index, item) {
        $(item).textbox('disable');
    });
}
function calculateTimeLimit() {
    var StartValue = RentStartTimeObj.datebox('getValue');
    var EndValue = RentEndTimeObj.datebox('getValue');
    if (StartValue == "" || EndValue == "") {
        tdTimeLimit.textbox('setValue', 0);
        return;
    }
    var startTime = new Date(StartValue.replace(/-/g, "/").replace("T", " "));
    var endTime = new Date(EndValue.replace(/-/g, "/").replace("T", " "));
    if (startTime >= endTime) {
        tdTimeLimit.textbox('setValue', 0);
        return;
    }
    var month_count = calculate_month(StartValue, EndValue);
    tdTimeLimit.textbox('setValue', month_count);
}
function loadTT() {
    tt_CanLoad = false;
    $('#tt_room').datagrid({
        url: '../Handler/ContractHandler.ashx',
        loadMsg: '正在加载',
        border: false,
        remoteSort: false,
        pagination: true,
        rownumbers: true,
        fit: false,
        fitColumns: true,
        singleSelect: false,
        selectOnCheck: true,
        checkOnSelect: true,
        striped: true,
        columns: [[
        { field: 'ck', checkbox: true },
        { field: 'FullName', title: '资源位置', width: 260 },
        { field: 'Name', title: '资源编号', width: 80 },
        { field: 'RoomType', title: '房间类型', width: 80 },
        { field: 'ContractArea', formatter: formatNumber, title: '合同面积', width: 80 }
        ]],
        pageSize: global_variable.pageSize,
        pageList: global_variable.pageList,
        onBeforeLoad: function (data) {
            if (!tt_CanLoad) {
                $('#tt_room').datagrid("loadData", {
                    total: 0,
                    rows: []
                });
            }
            return tt_CanLoad;
        },
        onLoadError: function (data) {
            //alert("有错");
            $('#tt_room').datagrid("loadData", {
                total: 0,
                rows: []
            });
        },
        toolbar: '#tb'
    });
    SearchTT();
}
function SearchTT() {
    tt_CanLoad = true;
    $("#tt_room").datagrid("load", {
        "visit": "loadcontractroomlist",
        "guid": guid,
        "ContractID": ContractID
    });
}

function loadsuammryTT() {
    summary_CanLoad = false;
    $('#tt_chargesummary').datagrid({
        url: '../Handler/ContractHandler.ashx',
        loadMsg: '正在加载',
        border: true,
        remoteSort: false,
        pagination: true,
        rownumbers: true,
        fit: false,
        fitColumns: false,
        singleSelect: false,
        selectOnCheck: true,
        checkOnSelect: true,
        striped: true,
        pageSize: global_variable.pageSize,
        pageList: global_variable.pageList,
        columns: [[
        { field: 'ck', checkbox: true },
        { field: 'FullName', formatter: formatFullName, title: '房源位置', width: 260 },
        { field: 'Name', title: '房号', width: 80 },
        { field: 'ChargeName', title: '收费项目', width: 80 },
        { field: 'CalculateUnitPrice', title: '单价', width: 80 },
        { field: 'CalculateUseCount', title: '面积', width: 80 },
        { field: 'CalculateStartTime', formatter: formatTime, title: '计费开始日期', width: 120 },
        { field: 'CalculateEndTime', formatter: formatTime, title: '计费结束日期', width: 120 },
        { field: 'CalculateNewEndTime', formatter: formatTime, title: '计费停用日期', width: 120 },
        { field: 'ReadyChargeTime', formatter: formatTime, title: '收费日期', width: 120 },
        { field: 'CalcualteTotalCost', title: '应收金额', width: 80 },
        { field: 'CalcualtePayCost', title: '已收金额', width: 80 },
        { field: 'CalcualteRestCost', title: '未收金额', width: 80 },
        { field: 'CalcualteDiscount', title: '减免金额', width: 80 },
        { field: 'ChargeTypeDesc', title: '计费规则', width: 80 },
        { field: 'Remark', title: '备注', width: 80 }
        ]],
        onBeforeLoad: function (data) {
            if (!summary_CanLoad) {
                $('#tt_chargesummary').datagrid("loadData", {
                    total: 0,
                    rows: []
                });
            }
            return summary_CanLoad;
        },
        onLoadError: function (data) {
            //alert("有错");
            $('#tt_chargesummary').datagrid("loadData", {
                total: 0,
                rows: []
            });
        },
        onLoadSuccess: onLoadSuccess,
        toolbar: '#tb_summary'
    });
    SearchSummaryTT();
}
function onLoadSuccess(data) {
    var total = 0;
    $.each(data.rows, function (index, row) {
        if (row.CategoryID == 3 && row.CalcualteTotalCost > 0) {
            total += row.CalcualteTotalCost;
        }
    })
    tdContractDeposit.textbox('setValue', total);
}
function SearchSummaryTT() {
    var StartTime = RentStartTimeObj.datebox('getValue');
    var EndTime = RentEndTimeObj.datebox('getValue');
    summary_CanLoad = true;
    $("#tt_chargesummary").datagrid("load", {
        "visit": "loadcontractchargelist",
        "guid": guid,
        "ContractID": ContractID,
        "StartTime": StartTime,
        "EndTime": EndTime,
        "canrent": canrent
    });
}
function AddCharge() {
    var StartTime = RentStartTimeObj.datebox('getValue');
    var EndTime = RentEndTimeObj.datebox('getValue');
    if (StartTime == "" || EndTime == "") {
        show_message("请填写合同开始结束日期", "info");
        return;
    }
    var startstamp = timeToStamp(StartTime);
    var endstamp = timeToStamp(EndTime);
    var renttostamp = ''
    if (canrent == 1) {
        var RentToTime = tdRentToTime.datebox('getValue');
        if (RentToTime == '') {
            show_message("请填写续租日期", "info");
            return;
        }
        if ((stringToDate(EndTime).valueOf() + (1000 * 60 * 60 * 24)) > stringToDate(RentToTime).valueOf()) {
            show_message("结束日期不能大于续租日期", "info");
            return;
        }
        renttostamp = timeToStamp(RentToTime);
    }
    var iframe = "../Contract/NewAddContractCharge.aspx?guid=" + guid + "&ContractID=" + ContractID + "&startstamp=" + startstamp + "&endstamp=" + endstamp + "&canedit=" + cansavelog + "&renttostamp=" + renttostamp + "&canrent=" + canrent;
    do_open_dialog('添加收费标准', iframe);
}
function AddCharge_Done() {
    var options = { visit: 'removecontracttemppricebyguid', guid: guid };
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: '../Handler/ContractHandler.ashx',
        data: options,
        success: function (message) {
        }
    });
    SearchSummaryTT();
}
function RemoveCharge() {
    var rows = $("#tt_chargesummary").datagrid("getSelections");
    if (rows.length == 0) {
        show_message("请选择一个收费标准", "info");
        return;
    }
    var IDList = [];
    $.each(rows, function (index, row) {
        IDList.push(row.ID);
    })
    top.$.messager.confirm("提示", "是否删除选中的收费标准", function (r) {
        if (r) {
            MaskUtil.mask('body', '提交中');
            var options = { visit: 'removecontractcharge', IDList: JSON.stringify(IDList), canedit: cansavelog };
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/ContractHandler.ashx',
                data: options,
                success: function (message) {
                    MaskUtil.unmask();
                    if (message.status) {
                        show_message('删除成功', 'success', function () {
                            SearchSummaryTT();
                        });
                        return;
                    }
                    else if (message.msg) {
                        show_message(message.msg, "warning");
                        return;
                    }
                    show_message('系统错误', 'error');
                }
            });
        }
    })
}
function formatNumber(value, row) {
    return (Number(value) < 0 ? 0 : value);
}
function formatFullName(value, row) {
    if (row.FullName == '') {
        row.FullName = '所有房间';
    }
    return row.FullName;
}
function AddRoom() {
    var iframe = "../Contract/AddContractRoom.aspx?guid=" + guid + "&ContractID=" + ContractID + "&canedit=" + cansavelog;
    do_open_dialog('添加房间', iframe);
}
function RemoveRoom() {
    var rows = $("#tt_room").datagrid("getSelections");
    if (rows.length == 0) {
        show_message("请选择一个房间", "info");
        return;
    }
    var IDList = [];
    $.each(rows, function (index, row) {
        IDList.push(row.ID);
    })
    top.$.messager.confirm("提示", "是否删除选中的房间", function (r) {
        if (r) {
            var options = { visit: 'removecontractroom', IDList: JSON.stringify(IDList), canedit: cansavelog };
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/ContractHandler.ashx',
                data: options,
                success: function (message) {
                    if (message.status) {
                        show_message('删除成功', 'success', function () {
                            $("#tt_room").datagrid("reload");
                        });
                        return;
                    }
                    show_message('系统错误', 'error');
                }
            });
        }
    })
}
function saveData() {
    var isValid = ffObj.form('enableValidation').form('validate');
    if (!isValid) {
        return;
    }
    content.set_list_value();
    var freelist = [];
    $.each(content.list, function (index, item) {
        if (item.StartTime == '' || item.EndTime == '') {
            return true;
        }
        freelist.push(item);
    })
    var freetimeerror = false;
    $.each(freelist, function (index, item) {
        if (item.FreeChargeIDs == '') {
            return true;
        }
        var free_starttime = stringToDate(item.StartTime);
        var free_endtime = stringToDate(item.EndTime);
        var item_chargeidlist = eval('(' + item.FreeChargeIDs + ')');
        var chargeidlist = [];
        $.each(freelist, function (index2, item2) {
            if (item2.FreeChargeIDs == '') {
                return true;
            }
            if (item.ID == item2.ID && item.ID > 0) {
                return true;
            }
            if (item.count == item2.count) {
                return true;
            }
            var free_starttime_2 = stringToDate(item2.StartTime);
            var free_endtime_2 = stringToDate(item2.EndTime);
            if (free_starttime_2.valueOf() >= free_endtime.valueOf() || free_endtime_2.valueOf() <= free_starttime.valueOf()) {
                return true;
            }
            var item2_chargeidlist = eval('(' + item2.FreeChargeIDs + ')');
            $.each(item2_chargeidlist, function (index3, item2_chargeid) {
                if ($.inArray(item2_chargeid, item_chargeidlist) > -1) {
                    freetimeerror = true;
                    return false;
                }
            })
            if (freetimeerror) {
                return false;
            }
        })
    })
    if (freetimeerror) {
        show_message("当前免租期包含相同费项", "info");
        return;
    }
    if (parent.ContractID > 0 && ContractID <= 0) {
        ContractID = parent.ContractID;
    }
    MaskUtil.mask('body', '提交中');
    $('#ff').form('submit', {
        url: '../Handler/ContractHandler.ashx',
        onSubmit: function (param) {
            param.visit = 'savecontractbasicinfo';
            param.ContractID = ContractID;
            param.TopContractID = TopContractID;
            param.guid = guid;
            param.canedit = cansavelog;
            param.freelist = JSON.stringify(freelist);
        },
        success: function (data) {
            MaskUtil.unmask();
            var dataObj = eval("(" + data + ")");
            if (dataObj.status) {
                if (dataObj.ID > 0) {
                    ContractID = dataObj.ID;
                    parent.ContractID = ContractID;
                    show_message('保存成功', 'success', function () {
                        loadattachs();
                        $("#tt_chargesummary").datagrid('reload');
                        content.getdata();
                        closeWin();
                    });
                    return;
                }
                show_message("合同记录不存在", "info");
            }
            else if (dataObj.msg) {
                show_message(dataObj.msg, "info");
            }
            else {
                show_message('系统错误', 'error');
            }
        }
    });
}
var filecount = 0;
function addFile() {
    $("#tdFile").find("a.fileadd").hide();
    $("#tdFile").find("a.fileremove").show();
    filecount++;
    var $html = "<div id=\"tdFile_" + filecount + "\">";
    $html += "<input class=\"easyui-filebox\" name=\"attachfile\" data-options=\"prompt:'请选择文件',buttonText: '选择文件'\" style=\"width: 60%\" />";
    $html += "<a href=\"javascript:void(0)\" onclick=\"addFile()\" class=\"easyui-linkbutton btnlinkbar fileadd\" data-options=\"plain:true,iconCls:'icon-add'\">添加</a>";
    $html += "<a href=\"javascript:void(0)\" onclick=\"deleteFile(" + filecount + ")\" class=\"easyui-linkbutton btnlinkbar fileremove\" style=\"display:none;\" data-options=\"plain:true,iconCls:'icon-remove'\">删除</a>";
    $html += "</div>";
    $("#tdFile").append($html);
    $.parser.parse("#tdFile_" + filecount);
}
function deleteFile(id) {
    $("#tdFile_" + id).html("");
}
function closeWin() {
    parent.parent.$("#winadd").window("close");
}
function EditCharge() {
    var rows = $('#tt_chargesummary').datagrid("getSelections");
    if (rows.length == 0) {
        show_message("请选择一个收费标准", "info");
        return;
    }
    if (rows.length > 1) {
        show_message("只能选择一个收费标准进行修改", "info");
        return;
    }
    var Name = rows[0].Name;
    var iframe = "../Contract/EditContractCharge.aspx?ID=" + rows[0].ID + "&canedit=" + cansavelog;
    do_open_dialog('修改' + Name + "费项标准", iframe);
}
function loadothersuammryTT() {
    summary_other_CanLoad = false;
    $('#tt_otherchargesummary').datagrid({
        url: '../Handler/ContractHandler.ashx',
        loadMsg: '正在加载',
        border: true,
        remoteSort: false,
        pagination: true,
        rownumbers: true,
        fit: false,
        fitColumns: false,
        singleSelect: false,
        selectOnCheck: true,
        checkOnSelect: true,
        striped: true,
        pageSize: global_variable.pageSize,
        pageList: global_variable.pageList,
        columns: [[
        { field: 'ck', checkbox: true },
        { field: 'FullName', title: '房源位置', width: 260 },
        { field: 'Name', title: '房号', width: 80 },
        { field: 'ChargeName', title: '收费项目', width: 80 },
        { field: 'CalculateUnitPrice', title: '单价', width: 80 },
        { field: 'CalculateUseCount', title: '合同面积', width: 80 },
        { field: 'CalculateStartTime', formatter: formatTime, title: '计费开始日期', width: 120 },
        { field: 'CalculateEndTime', formatter: formatTime, title: '计费结束日期', width: 120 },
        { field: 'CalcualteTotalCost', title: '应收金额', width: 80 },
        { field: 'CalcualtePayCost', title: '已收金额', width: 80 },
        { field: 'CalcualteRestCost', title: '未收金额', width: 80 },
        { field: 'Remark', title: '备注', width: 80 }
        ]],
        onBeforeLoad: function (data) {
            if (!summary_CanLoad) {
                $('#tt_otherchargesummary').datagrid("loadData", {
                    total: 0,
                    rows: []
                });
            }
            return summary_CanLoad;
        },
        onLoadError: function (data) {
            //alert("有错");
            $('#tt_otherchargesummary').datagrid("loadData", {
                total: 0,
                rows: []
            });
        },
        toolbar: '#tb_othersummary'
    });
    SearchOtherSummaryTT();
}
function SearchOtherSummaryTT() {
    var StartTime = RentStartTimeObj.datebox('getValue');
    var EndTime = RentEndTimeObj.datebox('getValue');
    summary_other_CanLoad = true;
    $("#tt_otherchargesummary").datagrid("load", {
        "visit": "loadcontractchargelist",
        "guid": guid,
        "ContractID": ContractID,
        "StartTime": StartTime,
        "EndTime": EndTime,
        "IsLinShi": true
    });
}
function loadattachs() {
    var options = { visit: 'loadcontractattachs', ID: ContractID, FileType: "addcontract" };
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: '../Handler/ContractHandler.ashx',
        data: options,
        success: function (data) {
            var $html = '';
            $("#trExistFiles").html($html);
            if (data.length > 0) {
                $("#trExistFiles").show();
                $html += '<td>已上传附件</td>';
                $html += '<td colspan="3">';
                $.each(data, function (index, item) {
                    $html += '<div>' + item.FileOriName + ' &nbsp;&nbsp;&nbsp;&nbsp;<a href="' + item.AttachedFilePath + '" target="_blank" >下载</a>&nbsp;&nbsp;&nbsp;&nbsp;';
                    if (canedit == 1) {
                        $html += '<a href="#" onclick="deleteAttach(' + item.ID + ')">删除</a></div>';
                    }
                    $html += '</div>';
                })
                $html += '</td>';
            }
            $("#trExistFiles").append($html);
        }
    });
}
function deleteAttach(AttachID) {
    top.$.messager.confirm("提示", "是否删除选已上传的文件?", function (r) {
        if (r) {
            var options = { visit: 'deletefile', ID: AttachID };
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/ContractHandler.ashx',
                data: options,
                success: function (message) {
                    if (message.status) {
                        show_message('删除成功', 'success', function () {
                            loadattachs();
                        });
                        return;
                    }
                    show_message('系统错误', 'error');
                }
            });
        }
    })
}
function printData() {
    var iframe = "../Contract/ContractTemplateSelect.aspx?ID=" + ContractID + "&canedit=" + cansavelog;
    do_open_dialog('选择模板', iframe);
}

