var tt_CanLoad = false;
var IncludDepartment = false;
var HideInventory = false;
$(function () {
    loadSearchCombobox();
    setTimeout(function () {
        loadtt();
    }, 100);
    btnIncludDepartmentObj.bind('click', function () {
        if ($(this).prop('checked')) {
            IncludDepartment = true;
            hdIncludDepartmentObj.val("1");
        }
        else {
            IncludDepartment = false;
            hdIncludDepartmentObj.val("0");
        }
    })
    btnShowInventory.bind('click', function () {
        if ($(this).prop('checked')) {
            HideInventory = true;
            hdHideInventory.val("1");
        }
        else {
            HideInventory = false;
            hdHideInventory.val("0");
        }
    })
});
function loadSearchCombobox() {
    var options = { visit: 'getckinmgrcombobox' };
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: '../Handler/CKHandler.ashx',
        data: options,
        success: function (message) {
            if (message.status) {
                tdProductCategory.combobox({
                    editable: false,
                    data: message.ProductCategoryList,
                    valueField: 'ID',
                    textField: 'Name'
                });
            }
        }
    });
}
function loadtt() {
    var options = { visit: 'loadtablecolumn', pagecode: 'ckinventorygrid' };
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
                    url: '../Handler/CKHandler.ashx',
                    loadMsg: '正在加载',
                    border: true,
                    remoteSort: false,
                    pagination: true,
                    rownumbers: true,
                    fit: true,
                    fitColumns: true,
                    singleSelect: false,
                    selectOnCheck: true,
                    checkOnSelect: true,
                    striped: true,
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
                    columns: finalcolumn,
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
    if (options == null) {
        return;
    }
    tt_CanLoad = true;
    $("#tt_table").datagrid("load", options);
}
function get_options() {
    var StartTime = tdStartTimeObj.datebox('getValue');
    var EndTime = tdEndTimeObj.datebox('getValue');
    if (StartTime != '' && EndTime != '') {
        if (stringToDate(StartTime).valueOf() > stringToDate(EndTime).valueOf()) {
            show_message('开始日期不能大于结束日期', 'warning');
            return null;
        }
    }
    var keywords = tdKeywordObj.searchbox("getValue");
    var CategoryIDList = [];
    var DepartmentIDList = 0;
    var ProductID = 0;
    try {
        CategoryIDList = GetSelectedIDs("category");
        DepartmentIDList = GetSelectedIDs("department");
        hdDepartmentIDObj.val(JSON.stringify(DepartmentIDList));
        hdCategoryIDObj.val(JSON.stringify(CategoryIDList));
    } catch (e) {
    }
    var ProductCategoryID = tdProductCategory.combobox("getValue");
    var options = {
        "visit": "loadinventorygrid",
        "keywords": keywords,
        "CategoryIDs": hdCategoryIDObj.val(),
        "DepartmentIDs": hdDepartmentIDObj.val(),
        "StartTime": StartTime,
        "EndTime": EndTime,
        "IncludDepartment": IncludDepartment,
        "ProductCategoryID": ProductCategoryID,
        "HideInventory": HideInventory,
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
        url: '../Handler/CKHandler.ashx',
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
function formatCount(value, row) {
    if (Number(value) < 0) {
        return 0;
    }
    return value;
}
//列设置
function openTableSetUp() {
    var iframe = "../SysSeting/TableSetUp.aspx?PageCode=ckinventorygrid";
    do_open_dialog('账单列表设置', iframe);
}