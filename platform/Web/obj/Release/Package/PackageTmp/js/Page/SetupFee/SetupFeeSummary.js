
var chooseTitle;
$(function () {
    chooseTitle = $("#hdSelectedTitle").val();
    loadIframe();
    $('#ChargeSummaryAccording').tabs({
        onSelect: function (title, index) {
            chooseTitle = title;
            loadIframe();
        }
    });
});
function loadIframe() {
    var curTab = $('#ChargeSummaryAccording').tabs('getSelected');
    if (curTab.find("iframe:first").attr("src") == "") {
        var iframesrc = curTab.find("input[type=hidden]:first").val();
        curTab.find("iframe:first").attr("src", iframesrc);
        //curTab.find("iframe:first").css("height", "300px");
    }
}
function SearchTT() {
    var rows = document.getElementById('iframe_' + chooseTitle).contentWindow.SearchTT();
    return;
    var myframes = document.getElementsByName('feeframe');
    $.each(myframes, function (index, myframe) {
        myframe.contentWindow.SearchTT();
    })
}
function addFee() {
    var iframe = "../SetupFee/EditFee.aspx";
    do_open_dialog('新增收费项目', iframe);
}
function reload_tt() {
    document.getElementById('iframe_' + chooseTitle).contentWindow.reLoadTT();
}
function getSelectRows() {
    var rows = document.getElementById('iframe_' + chooseTitle).contentWindow.getRows();
    return rows;
}
function editFee() {
    var rows = getSelectRows();
    if (rows.length == 0) {
        show_message("请至少选择一个收费项目", "info");
        return;
    }
    if (rows.length > 1) {
        show_message("请选择单个收费项目进行编辑", "info");
        return;
    }
    var iframe = "../SetupFee/EditFee.aspx?ID=" + rows[0].ID;
    do_open_dialog('修改收费项目', iframe);
}
function deleteFee() {
    var list = [];
    var rows = getSelectRows();
    if (rows.length == 0) {
        show_message('请选择一条数据，操作取消', 'warning');
        return;
    }
    $.each(rows, function (index, row) {
        list.push(row.ID);
    });
    var options = { visit: "checkdeletechargesummary", ChargeIDs: JSON.stringify(list) };
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: '../Handler/CheckStatusHandler.ashx',
        data: options,
        success: function (data) {
            if (!data.status) {
                if (data.error) {
                    show_message(data.error, "warning");
                    return;
                }
                show_message("系统异常", "info");
                return;
            }
            top.$.messager.confirm("提示", "确认删除选中的收费项目?", function (r) {
                if (r) {
                    deletesummaryfee(list)
                }
            });
        }
    });
}
function deletesummaryfee(list) {
    var options = { visit: 'deletesummaryfee', list: JSON.stringify(list) };
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: '../Handler/FeeCenterHandler.ashx',
        data: options,
        success: function (message) {
            if (message.status) {
                show_message('删除成功', 'success');
                document.getElementById('iframe_' + chooseTitle).contentWindow.reLoadTT();
            }
            else {
                show_message('系统错误', 'error');
            }
        }
    });
}
function do_start() {
    var list = [];
    var rows = getSelectRows();
    if (rows.length == 0) {
        show_message('请选择一条数据，操作取消', 'warning');
        return;
    }
    var notzhouqi = false;
    $.each(rows, function (index, row) {
        if (row.FeeType != 1) {
            notzhouqi = true;
            return false;
        }
        list.push(row.ID);
    });
    if (notzhouqi) {
        show_message("请选择周期费用", "warning");
        return;
    }
    var roomidlist = [];
    var projectidlist = [];
    var projectid = null;
    try {
        roomidlist = parent.GetSelectRoomCheck();
        projectid = parent.GetSelectRadio();
    } catch (e) {

    }
    if (roomidlist.length == 0 && (projectid == null || projectid == "")) {
        show_message("请同时选中收费标准和对应资源", "warning");
        return;
    }
    if (projectid != null && projectid != "") {
        projectidlist.push(projectid);
    }
    var options = { visit: "checkroomfeesummary", summaryids: JSON.stringify(list), projectids: JSON.stringify(projectidlist), roomids: JSON.stringify(roomidlist), CompanyID: CompanyID };
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: '../Handler/FeeCenterHandler.ashx',
        data: options,
        success: function (data) {
            if (data.status) {
                if (data.hasfee) {
                    top.$.messager.confirm("提示", "当前选中的资源已启用该收费项目，是否重复启用", function (r) {
                        if (r) {
                            startFeeProcess(list, projectidlist, roomidlist);
                        }
                    })
                    return;
                }
                startFeeProcess(list, projectidlist, roomidlist);
            }
        }
    });
}
function startFeeProcess(summaryidlist, projectidlist, roomidlist) {
    MaskUtil.mask('body', '提交中');
    var options = { visit: "saveroomfee", summaryids: JSON.stringify(summaryidlist), projectids: JSON.stringify(projectidlist), roomids: JSON.stringify(roomidlist), CompanyID: CompanyID };
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: '../Handler/FeeCenterHandler.ashx',
        data: options,
        success: function (data) {
            MaskUtil.unmask();
            if (data.status) {
                show_message("启用成功", "success");
            }
            else if (data.error) {
                show_message(data.error, "warning");
            }
            else {
                show_message('系统错误', 'error');
            }
        },
        error: function (jqXHR, textStatus, errorThrown) {
            if (textStatus == "timeout") {
                show_message("启用成功", "success");
            } else {
                alert(textStatus);
            }
        }
    });
}
