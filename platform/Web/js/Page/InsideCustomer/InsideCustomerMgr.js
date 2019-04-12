var tt_CanLoad = false;
var IndustryNameList = [], CategoryNameList = [], InterestingList = [], GroupInvitationList = [], RegionList = [], BusinessStageList = [], DealProbablyList = [];


$(function () {
    $(document).click(function (e) {
        var target = $(e.target);
        if (target.closest(".datagrid-btable,.calendar-noborder,.datagrid-toolbar").length == 0) {
            endTTEditing();
        }
    });
    getDataList();
    loadTT();
});
function getDataList() {
    IndustryNameList.push({ ID: "物业公司", Name: "物业公司" });
    IndustryNameList.push({ ID: "软件代理", Name: "软件代理" });
    IndustryNameList.push({ ID: "其他客户", Name: "其他客户" });

    var NewIndustryNameList = IndustryNameList.concat();
    NewIndustryNameList.unshift({ ID: "", Name: "全部" });
    tdIndustryName.combobox({
        data: NewIndustryNameList,
        valueField: 'ID',
        textField: 'Name'
    })

    CategoryNameList.push({ ID: "共同资源", Name: "共同资源" });
    CategoryNameList.push({ ID: "有效客户", Name: "有效客户" });
    CategoryNameList.push({ ID: "无效客户", Name: "无效客户" });
    CategoryNameList.push({ ID: "线索客户", Name: "线索客户" });
    CategoryNameList.push({ ID: "商机客户", Name: "商机客户" });
    CategoryNameList.push({ ID: "成交客户", Name: "成交客户" });
    CategoryNameList.push({ ID: "流失客户", Name: "流失客户" });

    var NewCategoryNameList = CategoryNameList.concat();
    NewCategoryNameList.unshift({ ID: "", Name: "全部" });
    tdCategory.combobox({
        data: NewCategoryNameList,
        valueField: 'ID',
        textField: 'Name'
    })

    InterestingList.push({ ID: "使用软件", Name: "使用软件" });
    InterestingList.push({ ID: "竞品代理", Name: "竞品代理" });
    InterestingList.push({ ID: "有意了解", Name: "有意了解" });
    InterestingList.push({ ID: "意向不明", Name: "意向不明" });
    InterestingList.push({ ID: "不愿沟通", Name: "不愿沟通" });

    var NewInterestingList = InterestingList.concat();
    NewInterestingList.unshift({ ID: "", Name: "全部" });
    tdInteresting.combobox({
        data: NewInterestingList,
        valueField: 'ID',
        textField: 'Name'
    })

    GroupInvitationList.push({ ID: "在", Name: "在" });
    GroupInvitationList.push({ ID: "不在", Name: "不在" });

    RegionList.push({ ID: "西南", Name: "西南" });
    RegionList.push({ ID: "中西", Name: "中西" });
    RegionList.push({ ID: "北部", Name: "北部" });
    RegionList.push({ ID: "东南", Name: "东南" });
    RegionList.push({ ID: "南部", Name: "南部" });
    var NewRegionList = RegionList.concat();
    NewRegionList.unshift({ ID: "", Name: "全部" });
    tdRegion.combobox({
        data: NewRegionList,
        valueField: 'ID',
        textField: 'Name'
    })

    BusinessStageList.push({ ID: "演示", Name: "演示" });
    BusinessStageList.push({ ID: "报价", Name: "报价" });
    BusinessStageList.push({ ID: "合同", Name: "合同" });

    DealProbablyList.push({ ID: "可能成交", Name: "可能成交" });
    DealProbablyList.push({ ID: "意向明确", Name: "意向明确" });
}
function loadTT() {
    tt_CanLoad = false;
    var options = { visit: 'loadtablecolumn', pagecode: 'insidecustomersource' };
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: '../Handler/RoomResourceHandler.ashx',
        data: options,
        success: function (message) {
            if (message.status) {
                var finalcolumn = [];
                finalcolumn = eval(message.columns);
                //加载
                $('#tt_table').datagrid({
                    url: '../Handler/CommHandler.ashx',
                    loadMsg: '正在加载',
                    border: false,
                    remoteSort: false,
                    pagination: true,
                    rownumbers: true,
                    fit: true,
                    fitColumns: false,
                    singleSelect: false,
                    selectOnCheck: true,
                    checkOnSelect: true,
                    striped: true,
                    //onClickCell: onClickCell,
                    //onClickRow: onClickTTRow,
                    onDblClickRow: onDblClickTTRow,
                    columns: finalcolumn,
                    pageSize: global_variable.pageSize,
                    pageList: global_variable.pageList,
                    onBeforeLoad: function (data) {
                        if (!tt_CanLoad) {
                            $('#tt_table').datagrid("loadData", {
                                total: 0,
                                rows: []
                            });
                        }
                        return tt_CanLoad;
                    },
                    onLoadError: function (data) {
                        //alert("有错");
                        $('#tt_table').datagrid("loadData", {
                            total: 0,
                            rows: []
                        });
                    },
                    toolbar: '#tb'
                });
                SearchTT();
                return;
            }
            show_message('系统错误', 'error');
        }
    });
}
function SearchTT() {
    var options = get_options();
    tt_CanLoad = true;
    $("#tt_table").datagrid("load", options);
}
function get_options() {
    var options = {
        "visit": "loadinsidecustomergrid",
        "CustomerBelonger": tdCustomerBelonger.searchbox('getValue'),
        "StartTime": tdStartTime.datebox('getValue'),
        "EndTime": tdEndTime.datebox('getValue'),
        "Region": tdRegion.combobox('getValue'),
        "Province": tdProvince.searchbox('getValue'),
        "City": tdCity.searchbox('getValue'),
        "CustomerName": tdCustomerName.searchbox('getValue'),
        "IndustryName": tdIndustryName.combobox('getValue'),
        "CategoryName": tdCategory.combobox('getValue'),
        "Interesting": tdInteresting.combobox('getValue')
    };
    return options;
}
function do_export() {
    var options = get_options();
    if (options == null) {
        return;
    }
    options.canexport = true;
    options.page = 1;
    options.rows = 10;
    MaskUtil.mask('body', '导出中');
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: '../Handler/CommHandler.ashx',
        data: options,
        success: function (data) {
            MaskUtil.unmask();
            if (data.downloadurl) {
                window.location.href = data.downloadurl;
                return;
            }
            if (data.error) {
                show_message(data.error, 'warning');
                return;
            }
            show_message('系统异常', 'error');
        }
    });
}
var tt_editIndex = undefined;
function endTTEditing() {
    if (tt_editIndex == undefined) {
        return true;
    }
    var rows = $('#tt_table').datagrid("getSelections");
    if (rows.length == 0) {
        return true;
    }
    $.each(rows, function (index, row) {
        var rowIndex = $('#tt_table').datagrid('getRowIndex', row);
        $('#tt_table').datagrid('endEdit', rowIndex);
    });
    saveFee();
    tt_editIndex = undefined;
    return true;
}
function onDblClickTTRow(index, row) {
    editTTRoomFee(row);
    tt_editIndex = index;
}
function onClickTTRow(index, row) {
    if (tt_editIndex != undefined) {
        endTTEditing();
        return;
    }
    setTimeout(function () {
        $('#tt_table').datagrid('selectRow', index);
    }, 100);
}
function editTTRoomFee(row) {
    var iframe = "../InsideCustomer/EditInsideCustomer.aspx?ID=" + row.ID;
    do_open_dialog('客户跟进', iframe);
}
function openImport() {
    var iframe = "../InsideCustomer/ImportCustomer.aspx";
    do_open_dialog('导入客户', iframe);
}
function editFee() {
    var rows = $('#tt_table').datagrid("getSelections");
    if (rows.length != 1) {
        show_message("请选中单行进行操作", "info");
        return;
    }
    var rowIndex = $('#tt_table').datagrid('getRowIndex', rows[0]);

    setTimeout(function () {
        tt_editIndex = rowIndex;
    }, 1000);
    editTTRoomFee(rows[0]);
}
function saveFeeAsync() {
    var List = [];
    var CostIsNull = false;
    var CalculateCostError = false;
    var rows = $('#tt_table').datagrid("getSelections");
    $.each(rows, function (index, row) {
        List.push(row);
    });
    if (List.length == 0) {
        return;
    }
    SaveImportFee(List);
}
function saveFee() {
    var List = [];
    var CostIsNull = false;
    var CalculateCostError = false;
    var rows = $('#tt_table').datagrid("getSelections");
    $.each(rows, function (index, row) {
        alert(row.NewFollowupDate);
        if (!row.NewFollowupDate) {
            row.NewFollowupDate = '';
        }
        List.push(row);
    });
    if (List.length == 0) {
        return;
    }
    SaveImportFee(List);
}
function SaveImportFee(List) {
    var options = { visit: 'saveinsidecustomer', List: JSON.stringify(List) };
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: '../Handler/CommHandler.ashx',
        data: options,
        success: function (message) {
            if (message.status == 1) {
                show_message("修改成功", "success");
                $('#tt_table').datagrid("reload");
                return;
            }
            else {
                show_message('系统错误', 'error');
            }
        }
    });
}
function removeFee() {
    var rows = $('#tt_table').datagrid("getSelections");
    if (rows.length == 0) {
        show_message("请至少选中一个客户记录", "提示");
        return;
    }
    var IDList = [];
    var candelete = true;
    $.each(rows, function (index, row) {
        if (row.CategoryName != '无效客户') {
            candelete = false;
            return false;
        }
        IDList.push(row.ID);
    });
    if (!candelete) {
        show_message("只能删除无效客户", "提示");
        return;
    }
    top.$.messager.confirm("提示", "确认删除?", function (r) {
        if (r) {
            var options = { visit: 'deleteinsidecustomer', IDList: JSON.stringify(IDList) };
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/CommHandler.ashx',
                data: options,
                success: function (message) {
                    if (message.status) {
                        show_message('删除成功', 'success');
                        $('#tt_table').datagrid("reload");
                    }
                    else {
                        show_message('系统错误', 'error');
                    }
                }
            });
        }
    });
}
function openTableSetUp() {
    var iframe = "../SysSeting/TableSetUp.aspx?PageCode=insidecustomersource";
    do_open_dialog('客户列表设置', iframe);
}
function formatAttached(value, row) {
    return '<a href="javascript:uploadAttachedFile(' + row.ID + ')">上传</a>';

}
function uploadAttachedFile(ID) {
    var iframe = "../InsideCustomer/UploadCustomer.aspx?ID=" + ID;
    do_open_dialog('附件上传', iframe);
}
function doEdit() {
    var rows = $('#tt_table').datagrid("getSelections");
    if (rows.length == 0) {
        return;
    }
    editTTRoomFee(rows[0]);
    return;
    $.each(rows, function (index, row) {
        setTimeout(function () {
            editTTRoomFee(row);
        }, 500 * index);
    });
}

function doMoreEdit() {
    var rows = $('#tt_table').datagrid("getSelections");
    if (rows.length == 0) {
        return;
    }
    var iframe = "<iframe id='myFrame' scrolling='auto' frameborder='0' src='../InsideCustomer/EditMoreCustomer.aspx' style='width:100%;height:" + ($(window).height() - 40) + "px'></iframe>";
    $("<div id='winadd'></div>").appendTo("body").window({
        title: '批处理',
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
            $("#winadd").remove();
            loadTT();
        }
    });
}