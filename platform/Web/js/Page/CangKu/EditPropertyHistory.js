var tt_CanLoad = false;
$(function () {
    setTimeout(function () {
        loadtt();
    }, 500);
});
function loadtt() {
    $('#tt_table').datagrid({
        url: '../Handler/CKHandler.ashx',
        loadMsg: '正在加载',
        border: true,
        remoteSort: false,
        pagination: true,
        rownumbers: true,
        fit: true,
        fitColumns: false,
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
        columns: [[
        { field: 'ck', checkbox: true },
        { field: 'PropertyNo', title: '资产编号', width: 100 },
        { field: 'PropertyName', title: '资产名称', width: 100 },
        { field: 'PropertyCategoryName', title: '资产类别', width: 100 },
        { field: 'PropertyModelNo', title: '规格型号', width: 100 },
        { field: 'PropertyUnit', title: '单位', width: 100 },
        { field: 'PropertyCount', formatter: formatDecimal, title: '数量', width: 100 },
        { field: 'PropertyUnitPrice', formatter: formatDecimal, title: '单价', width: 100 },
        { field: 'PropertyCost', formatter: formatDecimal, title: '购入金额', width: 100 },
        { field: 'PropertyPurchaseDate', formatter: formatTime, title: '购入时间', width: 100 },
        { field: 'PropertyUseYear', formatter: formatDecimal, title: '预计使用年限', width: 100 },
        { field: 'PropertyRealCost', formatter: formatDecimal, title: '净值', width: 100 },
        { field: 'PropertyDiscountCost', formatter: formatDecimal, title: '折旧金额', width: 100 },
        { field: 'PropertyChangeType', title: '变动方式', width: 100 },
        { field: 'PropertyStateDesc', title: '状态', width: 100 },
        { field: 'PropertyDepartmentName', title: '使用部门', width: 100 },
        { field: 'PropertyLocation', title: '存放地点', width: 100 },
        { field: 'PropertyUseMan', title: '使用人员', width: 100 },
        { field: 'PropertyContractName', title: '供应商', width: 100 },
        { field: 'PropertyContactPhone', title: '联系方式', width: 100 },
        { field: 'PropertyRemark', formatter: formatPropertyRemark, title: '备注', width: 200 },
        { field: 'ModifyMan', title: '变更人', width: 100 },
        { field: 'ModifyTime', formatter: formatDateTime, title: '变更时间', width: 150 },
        ]],
        toolbar: '#tt_mm'
    });
    SearchTT();
}
function SearchTT() {
    tt_CanLoad = true;
    $("#tt_table").datagrid("load", {
        "visit": "loadckpropertytempgrid",
        "keywords": tdKeyword.searchbox('getValue'),
        "StartTime": tdStartTime.datebox('getValue'),
        "EndTime": tdEndTime.datebox('getValue'),
        "PropertyID": PropertyID
    });
}
function formatDecimal(value, row) {
    if (parseFloat(value) > 0) {
        return value;
    }
    return 0;
}
function formatPropertyRemark(value, row) {
    if (value && value.length > 10) {
        return value.substring(0, 10) + "...";
    }
    return value;
}
