var tt_CanLoad = false;
$(function () {
    getComboboxParams();
    loadTT();
});
function getComboboxParams() {
    var options = { visit: 'getservicemgrparams', pagecode: 'customerservice' };
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: '../Handler/ServiceHandler.ashx',
        data: options,
        success: function (message) {
            if (message.status) {
                $('#tdAccpetMan').combobox({
                    editable: false,
                    data: message.users,
                    valueField: 'UserID',
                    textField: 'RealName'
                })
                return;
            }
            show_message('系统错误', 'error');
        }
    });
}
function loadTT() {
    tt_CanLoad = false;
    var options = { visit: 'loadtablecolumn', pagecode: 'customerservice' };
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
                    url: '../Handler/ServiceHandler.ashx',
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
                    columns: finalcolumn,
                    pageSize: global_variable.pageSize,
                    pageList: global_variable.pageList,
                    showFooter: true,
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
                setTimeout(function () {
                    SearchTT()
                }, 100);
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
    var StartTime = $("#tdStartTime").datebox("getValue");
    var EndTime = $("#tdEndTime").datebox("getValue");
    if (StartTime != '' && EndTime != '') {
        if (stringToDate(StartTime).valueOf() > stringToDate(EndTime).valueOf()) {
            show_message('开始日期不能大于结束日期', 'warning');
            return null;
        }
    }
    var roomids = [];
    var projectids = [];
    var allprojectids = [];
    var publicprojectids = [];
    try {
        roomids = parent.GetSelectedRooms();
        projectids = parent.GetSelectedProjects();
        allprojectids = parent.GetALLSelectedProjects();
        publicprojectids = parent.GetSelectedPublicProjects();
    } catch (e) {

    }
    var ServiceAccpetManID = 0;
    try {
        ServiceAccpetManID = $('#tdAccpetMan').combobox('getValue');

    } catch (e) {
    }
    var ServiceRange = $('#tdServiceRange').combobox('getValue');
    var options = {
        "visit": "loadservicelist",
        "RoomIDs": JSON.stringify(roomids),
        "ProjectIDs": JSON.stringify(projectids),
        "ALLProjectIDs": JSON.stringify(allprojectids),
        "PublicProjectIDs": JSON.stringify(publicprojectids),
        "ServiceStatus": Status,
        "StartTime": StartTime,
        "EndTime": EndTime,
        "Keywords": $("#tdKeywords").searchbox("getValue"),
        "PayStatus": $("#tdPayStatus").combobox("getValue"),
        "OrderBy": $('#tdSortOrder').combobox('getValue'),
        "ServiceAccpetManID": ServiceAccpetManID,
        "ServiceRange": ServiceRange
    };
    if (Status == 101) {
        options.ChooseStatus = $('#tdServiceStatus').combobox('getValue');
    }
    return options;
}
function formatOper(value, row) {
    var $html = '<div>';
    if (row.ServiceStatus == 0) {
        $html += '<a onclick="editData(' + row.ID + ')" style="maring-right:10px;"><span style="color:red;">修改</span></a>';
        $html += ' <a onclick="sendData(' + row.ID + ')" style="maring-right:10px;"><span style="color:red;">处理</span></a>';
        $html += '<a onclick="completeData(' + row.ID + ')" style="maring-right:10px;"><span style="color:red;">办结</span></a>';

    }
    $html += '<a onclick="callData(' + row.ID + ')" style="maring-right:10px;"><span style="color:red;">回访</span></a>';
    $html += '<a onclick="viewData(' + row.ID + ')" style="maring-right:10px;"><span style="color:red;">详情</span></a>';
    $html += '<a onclick="printData(' + row.ID + ')"><span style="color:red;">打印</span></a>';
    $html += '</div>';
    return $html;
}
function formatNumber(value, row) {
    return (Number(value) > 0 ? value : "");
}
function printData(ID) {
    if (ID == 0) {
        var rows = $("#tt_table").datagrid("getSelections");
        if (rows.length == 0) {
            show_message("请先选择一个任务", "info");
            return;
        }
        if (rows.length > 1) {
            show_message("只能选择一个任务", "info");
            return;
        }
        ID = rows[0].ID;
    }
    try {
        var LODOP = getLodop();
        if ((LODOP != null) && (typeof (LODOP.VERSION) != "undefined")) {
            $("#myframe").attr("src", "../CustomerService/ServiceDetailSummary.aspx?ID=" + ID);
            setTimeout(function () {
                LODOP.PRINT_INIT("打印派工单");
                LODOP.SET_PRINT_PAGESIZE(0, 0, 0, "");
                var strHtml = document.getElementsByTagName("iframe")[0].contentWindow.document.documentElement.innerHTML;
                //alert(strHtml);
                LODOP.ADD_PRINT_HTM(0, '5%', "90%", "100%", strHtml);
                LODOP.PREVIEW();
                //LODOP.PRINT();
            }, 1000);
        }
        else {
            alert("Error:该浏览器不支持打印插件!");
        }
    } catch (err) {
        alert("Error:本机未安装或需要升级!");
    }
}
function sendData(ID) {
    if (ID == 0) {
        var rows = $("#tt_table").datagrid("getSelections");
        if (rows.length == 0) {
            show_message("请先选择一个任务", "info");
            return;
        }
        if (rows.length > 1) {
            show_message("只能选择一个任务", "info");
            return;
        }
        if (rows[0].ServiceStatus == 2) {
            show_message("选中的任务已销单", "info");
            return;
        }
        ID = rows[0].ID;
    }
    var iframe = "../CustomerService/ProcessService.aspx?ID=" + ID;
    parent.do_open_dialog('任务处理', iframe, true);
}
function viewProcessData() {
    var rows = $("#tt_table").datagrid("getSelections");
    if (rows.length == 0) {
        show_message("请先选择一个任务", "info");
        return;
    }
    if (rows.length > 1) {
        show_message("只能选择一个任务", "info");
        return;
    }
    ID = rows[0].ID;
    var iframe = "../CustomerService/ProcessService.aspx?ID=" + ID + "&op=view";
    parent.do_open_dialog('处理记录', iframe, true);
}
function callData(ID) {
    if (ID == 0) {
        var rows = $("#tt_table").datagrid("getSelections");
        if (rows.length == 0) {
            show_message("请先选择一个任务", "info");
            return;
        }
        if (rows.length > 1) {
            show_message("只能选择一个任务", "info");
            return;
        }
        if (rows[0].ServiceStatus == 2) {
            show_message("选中的任务已销单", "info");
            return;
        }
        ID = rows[0].ID;
    }
    var iframe = "../CustomerService/CallCustomer.aspx?ID=" + ID;
    parent.do_open_dialog('客户回访', iframe, true);
}
function completeData(ID) {
    if (ID == 0) {
        var rows = $("#tt_table").datagrid("getSelections");
        if (rows.length == 0) {
            show_message("请先选择一个任务", "info");
            return;
        }
        if (rows.length > 1) {
            show_message("只能选择一个任务", "info");
            return;
        }
        if (rows[0].ServiceStatus == 2) {
            show_message("选中的任务已销单", "info");
            return;
        }
        ID = rows[0].ID;
    }
    var iframe = "../CustomerService/CompleteService.aspx?ID=" + ID;
    parent.do_open_dialog('任务办结', iframe, true);
}
function editData(ID) {
    if (ID == 0) {
        var rows = $("#tt_table").datagrid("getSelections");
        if (rows.length == 0) {
            show_message("请先选择一个任务", "info");
            return;
        }
        if (rows.length > 1) {
            show_message("只能选择一个任务", "info");
            return;
        }
        if (rows[0].ServiceStatus == 2) {
            show_message("任务已销单，不允许修改", "info");
            return;
        }
        ID = rows[0].ID;
    }
    var iframe = "../CustomerService/EditService.aspx?ID=" + ID;
    parent.do_open_dialog('任务修改', iframe, true);
}
function completeRemoveData() {
    var rows = $("#tt_table").datagrid("getSelections");
    if (rows.length == 0) {
        show_message("请先选择一个任务", "info");
        return;
    }
    var IDList = [];
    $.each(rows, function (index, row) {
        IDList.push(row.ID);
    })
    top.$.messager.confirm("提示", "是否删除选中的任务", function (r) {
        if (r) {
            var options = { visit: 'removeservice', IDList: JSON.stringify(IDList) };
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/ServiceHandler.ashx',
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
function cancelData() {
    var rows = $("#tt_table").datagrid("getSelections");
    if (rows.length == 0) {
        show_message("请先选择一个任务", "info");
        return;
    }
    var IDList = [];
    var isvalid = false;
    $.each(rows, function (index, row) {
        if (row.ServiceStatus == 2) {
            isvalid = true;
            return false;
        }
        IDList.push(row.ID);
    })
    if (isvalid) {
        show_message("选中的任务已销单", "info");
        return;
    }
    top.$.messager.confirm("提示", "是否销单选中的任务", function (r) {
        if (r) {
            var options = { visit: 'cancelservice', IDList: JSON.stringify(IDList) };
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/ServiceHandler.ashx',
                data: options,
                success: function (message) {
                    if (message.status) {
                        show_message("销单成功", "success", function () {
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
function viewData(ID) {
    if (ID == 0) {
        var rows = $("#tt_table").datagrid("getSelections");
        if (rows.length == 0) {
            show_message("请先选择一个任务", "info");
            return;
        }
        if (rows.length > 1) {
            show_message("只能选择一个任务", "info");
            return;
        }
        ID = rows[0].ID;
    }
    var iframe = "../CustomerService/EditService.aspx?op=view&ID=" + ID;
    parent.do_open_dialog('任务详情', iframe, true);
}
//列设置
function openTableSetUp() {
    var iframe = "../SysSeting/TableSetUp.aspx?PageCode=customerservice";
    parent.do_open_dialog('任务列表设置', iframe, true);
}
function addRow() {
    var iframe = "../CustomerService/AddService.aspx";
    parent.do_open_dialog('任务登记', iframe, true);
}
function removeData() {
    var rows = $("#tt_table").datagrid("getSelections");
    if (rows.length == 0) {
        show_message("请先选择一个任务", "info");
        return;
    }
    var IDList = [];
    var candelete = true;
    $.each(rows, function (index, row) {
        if (row.ServiceStatus != 3) {
            candelete = false;
            return false;
        }
        IDList.push(row.ID);
    })
    if (!candelete) {
        show_message("只能删除待处理任务", "info");
        return;
    }
    top.$.messager.confirm("提示", "是否删除选中的任务", function (r) {
        if (r) {
            var options = { visit: 'removeservice', IDList: JSON.stringify(IDList) };
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/ServiceHandler.ashx',
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
        url: '../Handler/ServiceHandler.ashx',
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