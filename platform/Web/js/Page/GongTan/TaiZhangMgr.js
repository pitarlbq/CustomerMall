var tt_CanLoad = false;
$(function () {
    loadBiao();
    setTimeout(function () {
        loadtt();
    }, 500);
});
function loadBiao() {
    var biaoData = hdBiaoCategory.val();
    var biaoarray = [];
    if (biaoData != "") {
        biaoarray = eval("(" + biaoData + ")");
    }
    var biaolist = [];
    biaolist.push({ ID: 0, Name: '全部' });
    $.each(biaoarray, function () {
        biaolist.push({ ID: this.ID, Name: this.BiaoCategory });
    })
    $("#tdBiaoCategory").combobox({
        editable: false,
        data: biaolist,
        valueField: 'ID',
        textField: 'Name'
    });
    $("#tdBiaoCategory").combobox('setValue', 0);
}
function loadtt() {
    $('#tt_table').datagrid({
        url: '../Handler/ImportFeeHandler.ashx',
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
        { field: 'FullName', formatter: formatFullName, title: '项目/房间名称', width: 300 },
        //{ field: 'ChargeName', title: '收费项目', width: 100 },
        { field: 'FinalBiaoName', title: '表名称', editor: 'textbox', width: 100 },
        { field: 'FinalBiaoCategory', title: '表种类', width: 100 },
        { field: 'BiaoGuiGe', title: '表规格', width: 100 },
        { field: 'ChargeRoomNo', title: '缴费户号', width: 100 },
        { field: 'Rate', formatter: formatDecimal, editor: { type: 'numberbox', options: { precision: 4 } }, title: '倍率', width: 100 },
        { field: 'ImportWriteDate', formatter: formatTime, editor: { type: 'datebox' }, title: '抄表日期', width: 100 },
        { field: 'FinalStartPoint', formatter: formatDecimal, editor: { type: 'numberbox', options: { precision: 2 } }, title: '上次读数', width: 100 },
        { field: 'FinalEndPoint', formatter: formatDecimal, editor: { type: 'numberbox', options: { precision: 2 } }, title: '本次读数', width: 100 },
        { field: 'FinalTotalPoint', formatter: formatDecimal, title: '本次用量', width: 100 },
        { field: 'FinalReducePoint', formatter: formatDecimal, editor: { type: 'numberbox', options: { precision: 2 } }, title: '扣减用量', width: 100 },
        { field: 'FinalCoefficient', formatter: formatDecimal, editor: { type: 'numberbox', options: { precision: 4 } }, title: '系数', width: 100 },
        { field: 'Relation', formatter: formatRelation, title: '扣减关联表', width: 100 },
        { field: 'FinalUnitPrice', formatter: formatDecimal, editor: { type: 'numberbox', options: { precision: 2 } }, title: '单价', width: 100 },
        //{ field: 'FinalTotalPrice', formatter: formatDecimal, title: '金额', width: 100 },
        { field: 'Remark', title: '备注', width: 100 },
        { field: 'IsActiveDesc', title: '作废状态', width: 100 }
        ]],
        toolbar: '#tb'
    });
    setTimeout(function () {
        SearchTT();
    }, 500)
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
    var roomids = [];
    var projectids = [];
    try {
        roomids = parent.GetSelectedRooms();
        projectids = parent.GetSelectedProjects();
    } catch (e) {

    }
    var keywords = $("#tdKeyword").searchbox("getValue");
    var BiaoCategory = $('#tdBiaoCategory').combobox('getValue');
    var ActiveStatus = $('#tdActiveStatus').combobox('getValue');
    var options = {
        "visit": "loadtaizhanggrid",
        "keywords": keywords,
        "BiaoCategory": BiaoCategory,
        "ActiveStatus": ActiveStatus,
        "RoomIDList": JSON.stringify(roomids),
        "ProjectIDList": JSON.stringify(projectids)
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
        url: '../Handler/ImportFeeHandler.ashx',
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
function xround(x, num) {
    if (x <= 0) {
        return x;
    }
    return Math.round(x * Math.pow(10, num)) / Math.pow(10, num);
}
function formatFullName(value, row) {
    if (row.Name != '') {
        return value + '-' + row.Name;
    }
    return value;
}
function formatDecimal(value, row) {
    if (Number(value) < 0) {
        return 0;
    }
    return value;
}
function formatReducePoint(value, row) {
    if (parseFloat(row.CalculateReducePoint) > 0) {
        return row.CalculateReducePoint;
    }
    if (parseFloat(row.ReducePoint) > 0) {
        return row.ReducePoint;
    }
    return 0; ReducePoint
}
function formatCost(value, row) {
    var unitprice = parseFloat(row.SummaryUnitPrice) > 0 ? parseFloat(row.SummaryUnitPrice) : 0;
    var coefficient = parseFloat(row.Coefficient) > 0 ? parseFloat(row.Coefficient) : 0;
    var totalpoint = calculateTotalPoint(row);
    var totalcost = totalpoint * unitprice * coefficient;
    return xround(totalcost, row.EndNumberCount);
}
function formatTotalPoint(value, row) {
    return calculateTotalPoint(row);
}
function calculateTotalPoint(row) {
    var startpoint = parseFloat(row.StartPoint) > 0 ? parseFloat(row.StartPoint) : 0;
    var endpoint = parseFloat(row.EndPoint) > 0 ? parseFloat(row.EndPoint) : 0;
    var rate = parseFloat(row.Rate) > 0 ? parseFloat(row.Rate) : 0;
    var reducepoint = parseFloat(row.ReducePoint) > 0 ? parseFloat(row.ReducePoint) : 0;
    var totalpoint = ((endpoint - startpoint) * rate) - reducepoint;
    return (totalpoint > 0 ? totalpoint : 0);
}
function formatUnitPrice(value, row) {
    if (parseFloat(row.UnitPrice) > 0) {
        return row.UnitPrice;
    }
    if (parseFloat(row.SummaryUnitPrice) > 0) {
        return row.SummaryUnitPrice;
    }
    return 0;
}
function formatRelation(value, row) {
    if (row.BiaoGuiGe == "总表") {
        return "<a href='javascript:openRelation(" + row.ID + ")'>关联</a>";
    }
    return "";
}
function openRelation(ID) {
    var iframe = "../GongTan/BiaoRelation.aspx?ID=" + ID;
    do_open_dialog('关联', iframe);
}
function activeRows() {
    var rows = $("#tt_table").datagrid("getSelections");
    if (rows.length == 0) {
        show_message("请至少选择一条数据进行此操作", "info");
        return;
    }
    var IDList = [];
    $.each(rows, function () {
        IDList.push({ ProjectID: this.ProjectID, BiaoID: this.BiaoID, IsActive: true });
    })
    top.$.messager.confirm("提示", "是否使选中的数据生效?", function (r) {
        if (r) {
            var options = { visit: 'changeprojectbiaostatus', IDList: JSON.stringify(IDList) };
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/ImportFeeHandler.ashx',
                data: options,
                success: function (message) {
                    if (message.status) {
                        show_message("生效成功", "success", function () {
                            $("#tt_table").datagrid("reload");
                        });
                        return;
                    }
                    show_message('系统错误', 'error');
                }
            });
        }
    })
}
function cancelRows() {
    var rows = $("#tt_table").datagrid("getSelections");
    if (rows.length == 0) {
        show_message("请至少选择一条数据进行此操作", "info");
        return;
    }
    var IDList = [];
    $.each(rows, function () {
        IDList.push({ ProjectID: this.ProjectID, BiaoID: this.BiaoID, IsActive: false });
    })
    top.$.messager.confirm("提示", "是否使选中的数据作废?", function (r) {
        if (r) {
            var options = { visit: 'changeprojectbiaostatus', IDList: JSON.stringify(IDList) };
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/ImportFeeHandler.ashx',
                data: options,
                success: function (message) {
                    if (message.status) {
                        show_message("作废成功", "success", function () {
                            $("#tt_table").datagrid("reload");
                        });
                        return;
                    }
                    show_message('系统错误', 'error');
                }
            });
        }
    })
}
function addRow() {
    var iframe = "../GongTan/AddTaiZhang.aspx";
    do_open_dialog('新增台帐', iframe);
}
function removeRows() {
    var rows = $("#tt_table").datagrid("getSelections");
    if (rows.length == 0) {
        show_message("请至少选择一条数据进行此操作", "info");
        return;
    }
    var IDList = [];
    $.each(rows, function () {
        IDList.push(this.ID);
    })
    top.$.messager.confirm("提示", "是否删除选中的数据?", function (r) {
        if (r) {
            var options = { visit: 'deleteprojectbiao', IDList: JSON.stringify(IDList) };
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/ImportFeeHandler.ashx',
                data: options,
                success: function (message) {
                    if (message.status) {
                        show_message('删除成功', 'success', function () {
                            $("#tt_table").datagrid("reload");
                        });
                        return;
                    }
                    show_message('系统错误', 'error');
                }
            });
        }
    })
}
function openImport() {
    var iframe = "../GongTan/ImportTaiZhang.aspx";
    do_open_dialog('导入三表账单', iframe);
}
function saveImportFee() {
    var rows = $('#tt_table').datagrid('getSelections');
    if (rows.length == 0) {
        show_message("请选择需要生成的账单", "info");
        return;
    }
    var cancontinue = true;
    $.each(rows, function (index, row) {
        var WriteDate = formatTime(row.WriteDate, row);
        WriteDate = WriteDate == "--" ? "" : WriteDate;
        if (WriteDate == "") {
            cancontinue = false;
            return false;
        }
    })
    if (!cancontinue) {
        show_message("账单日期不能为空", "info");
        return;
    }
    var iframe = "../GongTan/CreateTaiZhangFee.aspx";
    do_open_dialog('账单生成', iframe);
}
function editRows() {
    var rows = $('#tt_table').datagrid('getSelections');
    if (rows.length == 0) {
        show_message("请选择数据", "info");
        return;
    }
    $.each(rows, function (index, row) {
        setTimeout(function () {
            var rowIndex = $('#tt_table').datagrid('getRowIndex', row);
            $('#tt_table').datagrid('selectRow', rowIndex).datagrid('beginEdit', rowIndex);
            var $Rate = $('#tt_table').datagrid('getEditor', { index: rowIndex, field: 'Rate' });
            var rate = formatDecimal(row.Rate, row);
            $Rate.target.numberbox("setValue", rate);

            var $WriteDate = $('#tt_table').datagrid('getEditor', { index: rowIndex, field: 'WriteDate' });
            var writedate = formatTime(row.WriteDate, row);
            writedate = writedate == "--" ? "" : writedate;
            $WriteDate.target.datebox("setValue", writedate);

            var $FinalStartPoint = $('#tt_table').datagrid('getEditor', { index: rowIndex, field: 'FinalStartPoint' });
            var endpoint = formatDecimal(row.FinalEndPoint, row);
            $FinalStartPoint.target.numberbox("setValue", endpoint);
            if (row.BiaoGuiGe == '总表') {
                var $FinalReducePoint = $('#tt_table').datagrid('getEditor', { index: rowIndex, field: 'FinalReducePoint' });
                $FinalReducePoint.target.numberbox('disable', true);
            }
        }, 200 * index);
    })
}
function saveRows() {
    var rows = $('#tt_table').datagrid('getSelections');
    if (rows.length == 0) {
        show_message("请选择数据", "info");
        return;
    }
    $.each(rows, function (index, row) {
        var rowIndex = $('#tt_table').datagrid('getRowIndex', row);
        $('#tt_table').datagrid('endEdit', rowIndex);
    })
    var list = [];
    var cancontinue = true;
    $.each(rows, function (index, row) {
        var WriteDate = formatTime(row.WriteDate, row);
        WriteDate = WriteDate == "--" ? "" : WriteDate;
        if (WriteDate == "") {
            cancontinue = false;
            return false;
        }
        list.push({ ID: row.ID, FinalBiaoName: row.FinalBiaoName, Rate: formatDecimal(row.Rate, row), WriteDate: WriteDate, FinalStartPoint: row.FinalStartPoint, FinalEndPoint: row.FinalEndPoint, FinalReducePoint: row.FinalReducePoint, FinalUnitPrice: row.FinalUnitPrice, BiaoGuiGe: row.BiaoGuiGe, FinalCoefficient: row.FinalCoefficient })
    })
    if (!cancontinue) {
        show_message("账单日期不能为空", "info");
        return;
    }
    var options = { visit: 'savetaizhang', rows: JSON.stringify(list) };
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: '../Handler/ImportFeeHandler.ashx',
        data: options,
        success: function (message) {
            if (message.status) {
                show_message("登记成功", "success", function () {
                    $("#tt_table").datagrid("reload");
                });
                return;
            }
            show_message('系统错误', 'error');
        }
    });
}
//批处理
function batchEditTime() {
    var rows = $('#tt_table').datagrid("getSelections");
    if (rows.length == 0) {
        show_message("请至少选中一个导入记录", "warning");
        return;
    }
    var tostop = false;
    var iframe = "../GongTan/BatchEditTaiZhangTime.aspx";
    do_open_dialog('批处理', iframe);
}
function do_edit() {
    var rows = $('#tt_table').datagrid("getSelections");
    if (rows.length == 0) {
        show_message("请至少选中一个导入记录", "warning");
        return;
    }
    var tostop = false;
    var iframe = "../GongTan/EditTaiZhang.aspx?ID=" + rows[0].ID;
    do_open_dialog('修改台帐', iframe);
}
