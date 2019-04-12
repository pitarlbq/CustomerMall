var dgCanLoad = false;
$(document).ready(function () {
    loadUsers();
    //loadnoRoles(0);
});
function loadnoRoles(ContractID) {
    $('#notr').datagrid({
        url: '../Handler/ContractHandler.ashx?visit=loadnocontract&ContractID=' + ContractID,
        onLoadError: function () {
            $("#loadNoRoleFailed").html("<span> 重新加载 </span><a href='javascript:loadnoRoles('" + ContractID + "')'>点击</a>");
        },
        onLoadSuccess: function (data) {
            $("#loadNoRoleFailed").html("");
        }
    });
}
function loadinRoles(ContractID) {
    $('#inr').datagrid({
        url: '../Handler/ContractHandler.ashx?visit=loadincontract&ContractID=' + ContractID,
        onLoadError: function () {
            $("#loadInRoleFailed").html("<span> 重新加载 </span><a href='javascript:loadinRoles('" + ContractID + "')'>点击</a>");
        },
        onLoadSuccess: function (data) {
            $("#loadInRoleFailed").html("");
        }
    });
}
function loadUsers() {
    $('#dg').datagrid({
        url: '../Handler/ContractHandler.ashx',
        onClickRow: UserOnClickRow,
        loadMsg: '正在加载',
        border: false,
        remoteSort: false,
        pagination: true,
        rownumbers: true,
        fit: true,
        fitColumns: false,
        singleSelect: true,
        striped: true,
        pageSize: global_variable.pageSize,
        pageList: global_variable.pageList,
        columns: [[
       { field: 'ContractNo', title: '合同编号', width: 100 },
       { field: 'ContractName', title: '合同名称', width: 100 },
       { field: 'RoomLocation', title: '所租铺位', width: 300 },
       { field: 'RentName', title: '租户姓名', width: 100 },
       { field: 'TimeLimit', title: '合同期限', width: 100 },
       { field: 'RentStartTime', formatter: formatTime, title: '开始日期', width: 100 },
       { field: 'RentEndTime', formatter: formatTime, title: '结束日期', width: 100 },
       { field: 'ContractStatusDesc', title: '合同状态', width: 150 }
        ]],
        onBeforeLoad: function (data) {
            if (!dgCanLoad) {
                $('#dg').datagrid("loadData", {
                    total: 0,
                    rows: []
                });
            }
            return dgCanLoad;
        },
        onLoadError: function () {
            $("#loadUserFailed").html("<span> 重新加载 </span><a href='javascript:loadUsers()'>点击</a>");
        },
        onLoadSuccess: function (data) {
            $("#loadUserFailed").html("");
        }
    });
    doSearchUser();
}
function doSearchUser() {
    dgCanLoad = true;
    $("#dg").datagrid("load", {
        "visit": "loadcontractgrid",
        "Keywords": $("#tdKeywords").searchbox("getValue"),
        "ContractStatus": "tongguo"
    });
}
function formatRestDays(value, row) {
    if (value == 0) {
        return value;
    }
    if (row.ContractStatus != "tongguo") {
        return value;
    }
    if (ContractWarningOjb == null || ContractWarningOjb == "") {
        return value;
    }
    if (row.ContractStatus == "tongguo") {
        if (Number(ContractWarningOjb) < Number(value)) {
            return value;
        }
        return '<span style="color:red;">' + value + '</span>';
    }
}
function UserOnClickRow() {
    var ContractID = 0;
    var row = $("#dg").datagrid('getSelected');
    if (row) {
        ContractID = row.ID;
    }
    loadnoRoles(ContractID);
    loadinRoles(ContractID);
}
//赋予角色
function leftRole() {
    var row = $("#dg").datagrid('getSelected');
    var row1 = $("#notr").datagrid('getSelected');
    if (row1 && row) {
        $.post('../Handler/ContractHandler.ashx?visit=addcharge', { ContractID: row.ID, ChargeID: row1.ID }, function (result) {
            $('#inr').datagrid('reload');
            $('#notr').datagrid('reload');
        }, 'json');
    }
}
//移除角色
function rightRole() {
    var row = $("#dg").datagrid('getSelected');
    var row1 = $("#inr").datagrid('getSelected');
    if (row1 && row) {
        $.post('../Handler/ContractHandler.ashx?visit=removecharge', { ContractID: row.ID, ChargeID: row1.ID }, function (result) {
            $('#inr').datagrid('reload');
            $('#notr').datagrid('reload');
        }, 'json');
    }
}
