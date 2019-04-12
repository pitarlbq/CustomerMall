
var count = 0;
var ChargeTypeList = [];
var CategoryList = [];
var EndTypeList = [];
var EndNumberList = [];
$(function () {
    getChargeTypeList();
    getCategoryList();
    getEndTypeList();
    getEndNumberList();
    loadChargeFees(0, 0);

})
function loadChargeFees(ID, RoomID) {
    var options = { visit: "loadsetfeelist", ID: ID, CompanyID: CompanyID, RoomID: RoomID, FeeType: 5 };
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: '../Handler/FeeCenterHandler.ashx',
        data: options,
        success: function (data) {
            if (data.status) {
                $.each(data.ChargeList, function (index, item) {
                    if (ID == 0) {
                        initialyt(item);
                    }
                    else {
                        initialfee(item)
                    }
                })
            }
            else {
            }
        }
    });
}
function loadcheckFees(RoomID, CheckID, isContinue) {
    $(".feetable input[type='checkbox']").prop("checked", false);
    if (!isContinue) {
        return;
    }
    var options = { visit: "loadcheckfeeids", RoomID: RoomID, CheckID: CheckID };
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: '../Handler/FeeCenterHandler.ashx',
        data: options,
        success: function (data) {
            if (data.status) {
                $.each(data.list, function (index, FeeID) {
                    $("#" + FeeID + "_check").prop("checked", true);
                })
            }
            else {
            }
        }
    });
}

function getChargeTypeList() {
    ChargeTypeList.push({ ID: 1, Name: "按面积" });
    ChargeTypeList.push({ ID: 2, Name: "按户" });
    ChargeTypeList.push({ ID: 3, Name: "按用量" });
    ChargeTypeList.push({ ID: 4, Name: "引用算法" });
    ChargeTypeList.push({ ID: 5, Name: "按车位" });
}
function getRuleList() {
    CategoryList.push({ ID: 1, Name: "预收" });
    CategoryList.push({ ID: 2, Name: "实收" });
    CategoryList.push({ ID: 3, Name: "临时收取" });
}
function getCategoryList() {
    CategoryList.push({ ID: 1, Name: "收入" });
    CategoryList.push({ ID: 2, Name: "代收" });
    CategoryList.push({ ID: 3, Name: "押金" });
    CategoryList.push({ ID: 4, Name: "预收" });
}
function getEndTypeList() {
    EndTypeList.push({ ID: 1, Name: "月末" });
    EndTypeList.push({ ID: 2, Name: "季末" });
    EndTypeList.push({ ID: 3, Name: "年末" });
}
function getEndNumberList() {
    EndNumberList.push({ ID: 1, Name: "整数" });
    EndNumberList.push({ ID: 2, Name: "凑整" });
    EndNumberList.push({ ID: 3, Name: "四舍五入" });
}
function initialcharge(obj) {
    var html = '';
    html += '<table class="yttable">';
    html += '<tr>';
    html += '<td>';
    html += "计费方式";
    html += '</td>';
    html += '<td>';
    html += ListHTML(ChargeTypeList, obj, "ChargeTypeList");
    html += '</td>';
    html += '<td>';
    html += "科目类别";
    html += '</td>';
    html += '<td>';
    html += ListHTML(CategoryList, obj, "CategoryList");
    html += '</td>';
    html += '</tr>';
    html += '<tr>';
    html += '<td>';
    html += "尾数";
    html += '</td>';
    html += '<td>';
    html += ListHTML(EndNumberList, obj, "EndNumberList");
    html += '</td>';
    html += '<td>';
    html += '</td>';
    html += '</tr>';
    html += '</table>';
    $("#" + obj.summary.ID + "_chargetable").html(html);
}
function initialfee(obj) {
    var html = '';
    html += '<table class="feetable">';
    html += '<tr>';
    html += '<td>';
    html += '';
    html += '</td>';
    html += '<td>';
    html += '单价';
    html += '</td>';
    html += '<td>';
    html += "计算开始日期";
    html += '</td>';
    html += '<td>';
    html += "计算结束日期";
    html += '</td>';
    html += '<td>';
    html += "计费规则";
    html += '</td>';
    html += '</tr>';
    $.each(obj.list, function (index, item) {
        html += '<tr>';
        html += '<td>';
        html += '<input type="checkbox" id="' + item.ID + '_check" name="' + obj.summary.ID + '_check"/>';
        html += '</td>';
        html += '<td>';
        html += item.UnitPrice;
        html += '</td>';
        html += '<td>';
        html += formatDate(item.StartTime);
        html += '</td>';
        html += '<td>';
        html += formatDate(item.EndTime);
        html += '</td>';
        html += '<td>';
        html += formatEndType(item.EndTypeID);
        html += '</td>';
        html += '</tr>';
    })
    html += '</table>';
    $("#" + obj.summary.ID + "_feetable").html(html);
    var checkid = obj.summary.ID + "_check";
    $("input[name='" + checkid + "']").click(function () {
        if ($(this).is(':checked')) {
            $("input[name='" + checkid + "']").prop("checked", false);
            $(this).prop("checked", true);
        }
        else {
            $(this).prop("checked", false);
        }
    });
}
function formatDate(value) {
    if (value == undefined || value == null || value == '0001-01-01T00:00:00.0000000' || value == '0001-01-01T00:00:00' || value == '1900-01-01T00:00:00.0000000' || value == '1900-01-01T00:00:00') {
        return "--";
    }
    return value.substring(0, 16).split("T")[0];
}
function formatEndType(endtype) {
    var typedesc = "--";
    $.each(EndTypeList, function (index, value) {
        if (value.ID == endtype) {
            typedesc = value.Name;
            return false;
        }
    })
    return typedesc;
}
function initialyt(obj) {
    if (obj == null) {
        return;
    }
    var html = '';
    html += '<td class="yttd">';
    html += '<div class="ytmain">';
    html += ' <div class="ytbox">';
    html += ' <div class="yttitle">';
    html += '<div class="ytnumber">序号:<input type="text" value="' + obj.summary.OrderBy + '" id="' + count + '_number" /></div>';
    html += '<label class="summaryname">' + obj.summary.Name + '</label></div>';
    html += '<div id="' + obj.summary.ID + '_chargetable"></div>';
   
    html += ' </div>';
    html += '<div id="' + obj.summary.ID + '_feetable"></div>';
    html += ' </div>';
    html += ' </div>';
    html += '</td>';
    var tdlength = $("table#projecttable tr.yttr:last td.yttd").length;
    if (tdlength < 2) {
        $("table#projecttable tr.yttr:last").append(html);
    }
    else {
        $("table#projecttable").append("<tr class=\"yttr\">" + html + "</tr>");
    }
    initialcharge(obj);
    //initialfee(obj);
}
function ListHTML(list, obj, type) {
    var html = "";
    html += '<select id="' + count + '_TypeSelect">';
    $.each(list, function (index, value) {
        if (value.ID == obj.summary.TypeID && type == "ChargeTypeList") {
            html += '<option value="' + value.ID + '" selected="selected">' + value.Name + '</option>';
        }
        else if (value.ID == obj.summary.CategoryID && type == "CategoryList") {
            html += '<option value="' + value.ID + '" selected="selected">' + value.Name + '</option>';
        }
        else if (value.ID == obj.summary.EndTypeID && type == "EndTypeList") {
            html += '<option value="' + value.ID + '" selected="selected">' + value.Name + '</option>';
        }
        else if (value.ID == obj.summary.EndNumber && type == "EndNumberList") {
            html += '<option value="' + value.ID + '" selected="selected">' + value.Name + '</option>';
        }
        else {
            html += '<option value="' + value.ID + '">' + value.Name + '</option>';
        }
    })
    html += '</select>';
    return html;
}
function addFee(ID, Name) {
    var iframe = "<iframe id='myFrame' scrolling='auto' frameborder='0' src='../Charge/AddFee.aspx?ID=" + ID + "' style='width:100%;height:" + ($(window).height() - 40) + "px'></iframe>";
    $("<div id='winadd'></div>").appendTo("body").window({
        title: '新增' + Name + "收费标准",
        width: $(window).width() - 100,
        height: $(window).height(),
        top: 0,
        left: 50,
        modal: true,
        minimizable: false,
        maximizable: false,
        collapsible: false,
        content: iframe,
        onClose: function () {
            $("#winadd").remove();
            loadChargeFees(ID)
        }
    });
}
function startFee(ID) {
    var idarry = GetSelectRoomCheck();
    if (idarry.length == 0) {
        var radioid = GetSelectRadio();
        if (radioid != null && radioid != "") {
            idarry.push(Number(radioid));
        }
    }
    if (idarry.length == 0) {
        show_message("请选择一个项目", "warning");
        return;
    }
    var checkobj = document.getElementsByName(ID + '_check');
    var feeidarry = [];
    $.each(checkobj, function (index, item) {
        if ($(item).is(':checked')) {
            var feeid = Number($(item).attr("id").replace('_check', ''));
            feeidarry.push(feeid);
        }
    })
    if (feeidarry.length == 0) {
        show_message("请选择一个收费标准", "warning");
        return;
    }
    MaskUtil.mask('body', '提交中');
    var options = { visit: "saveroomfee", feeids: JSON.stringify(feeidarry), projectids: JSON.stringify(idarry) };
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: '../Handler/FeeCenterHandler.ashx',
        data: options,
        success: function (data) {
            MaskUtil.unmask();
            if (data.status) {
                if (data.errornames.length == 0) {
                    show_message("启用成功", "success");
                }
                else {
                    show_message("启用成功,以下房间已启用该收费标准:" + JSON.stringify(data.errornames), "success");
                }
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
function removeFee(ID) {
    var checkobj = document.getElementsByName(ID + '_check');
    var feeidarry = [];
    $.each(checkobj, function (index, item) {
        if ($(item).is(':checked')) {
            var feeid = Number($(item).attr("id").replace('_check', ''));
            feeidarry.push(feeid);
        }
    })
    if (feeidarry.length == 0) {
        show_message("请选择一个收费标准", "info");
        return;
    }
    MaskUtil.mask('body', '提交中');
    var options = { visit: "removeroomfee", FeeID: feeidarry[0] };
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: '../Handler/FeeCenterHandler.ashx',
        data: options,
        success: function (data) {
            MaskUtil.unmask();
            if (data.status) {
                show_message('删除成功', 'success');
                loadChargeFees(ID)
            }
            else {
                show_message('系统错误', 'error');
            }
        }
    });
}
function editFee(ID) {
    var checkobj = document.getElementsByName(ID + '_check');
    var feeidarry = [];
    $.each(checkobj, function (index, item) {
        if ($(item).is(':checked')) {
            var feeid = Number($(item).attr("id").replace('_check', ''));
            feeidarry.push(feeid);
        }
    })
    if (feeidarry.length == 0) {
        show_message("请选择一个收费标准", "info");
        return;
    }
    var iframeurl = "<iframe id='myFrame' scrolling='auto' frameborder='0' src='../Charge/EditChargeFee.aspx?FeeID=" + feeidarry[0] + "' style='width:100%;height:" + ($(window).height() - 40) + "px'></iframe>";

    parent.$("<div id='winadd'></div>").appendTo("body").window({
        title: '调整收费标准',
        width: $(window).width() - 100,
        height: $(window).height(),
        top: 0,
        left: 50,
        modal: true,
        iconCls: 'icon-search',
        minimizable: false,
        maximizable: false,
        resizable: true,
        collapsible: false,
        content: iframeurl,
        onClose: function () {
            parent.$("#winadd").remove();
            loadChargeFees(ID);
        }
    });
}
function stopFee(ID) {
    var idarry = GetSelectRoomCheck();
    if (idarry.length == 0) {
        var radioid = GetSelectRadio();
        if (radioid != null && radioid != "") {
            idarry.push(Number(radioid));
        }
    }
    if (idarry.length == 0) {
        show_message("请选择一个项目", "warning");
        return;
    }
    var checkobj = document.getElementsByName(ID + '_check');
    var feeidarry = [];
    $.each(checkobj, function (index, item) {
        if ($(item).is(':checked')) {
            var feeid = Number($(item).attr("id").replace('_check', ''));
            feeidarry.push(feeid);
        }
    })
    if (feeidarry.length == 0) {
        show_message("请选择一个收费标准", "warning");
        return;
    }
    MaskUtil.mask('body', '提交中');
    var options = { visit: "cancelroomfee", feeids: JSON.stringify(feeidarry), projectids: JSON.stringify(idarry) };
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: '../Handler/FeeCenterHandler.ashx',
        data: options,
        success: function (data) {
            MaskUtil.unmask();
            if (data.status == 1) {
                show_message("停用成功", "success");
            }
            else if (data.status == 0) {
                show_message("当前收费标准不在选中项目中", "info");
            }
            else if (data.status == 2) {
                show_message("当前收费标准尚未启用", "info");
            }
            else {
                show_message('系统错误', 'error');
            }
        }
    });
}
function viewByFee(ID) {
    var checkobj = document.getElementsByName(ID + '_check');
    var feeidarry = [];
    $.each(checkobj, function (index, item) {
        if ($(item).is(':checked')) {
            var feeid = Number($(item).attr("id").replace('_check', ''));
            feeidarry.push(feeid);
        }
    })
    if (feeidarry.length == 0) {
        show_message("请选择一个收费标准", "info");
        return;
    }
    var iframeurl = "<iframe id='myFrame' scrolling='auto' frameborder='0' src='../Charge/ViewRoomFeeList.aspx?FeeID=" + feeidarry[0] + "' style='width:100%;height:" + ($(window).height() - 40) + "px'></iframe>";
    OpenViewFeeList(iframeurl);

}
function viewByRoom() {
    var roomidarry = [];
    roomidarry = parent.GetSelectRoomCheck();
    if (roomidarry.length == 0) {
        var radioid = parent.GetSelectRadio();
        if (radioid != "") {
            roomidarry.push(Number(radioid));
        }
    }
    if (roomidarry.length == 0) {
        show_message("请选择一个房间", "info");
        return;
    }
    var iframeurl = "<iframe id='myFrame' scrolling='auto' frameborder='0' src='../Charge/ViewRoomFeeList.aspx?RoomID=" + JSON.stringify(roomidarry) + "' style='width:100%;height:" + ($(window).height() - 40) + "px'></iframe>";
    OpenViewFeeList(iframeurl);
}
function OpenViewFeeList(iframeurl) {
    parent.$("<div id='winadd'></div>").appendTo("body").window({
        title: '查看收费列表',
        width: $(window).width() - 100,
        height: $(window).height(),
        top: 0,
        left: 50,
        modal: true,
        iconCls: 'icon-search',
        minimizable: false,
        maximizable: false,
        resizable: true,
        collapsible: false,
        content: iframeurl,
        onClose: function () {
            parent.$("#winadd").remove();
        }
    });
}
function stopFee(ID, Name) {
    var checkobj = document.getElementsByName(ID + '_check');
    var feeidarry = [];
    $.each(checkobj, function (index, item) {
        if ($(item).is(':checked')) {
            var feeid = Number($(item).attr("id").replace('_check', ''));
            feeidarry.push(feeid);
        }
    })
    if (feeidarry.length == 0) {
        show_message("请选择一个收费标准", "info");
        return;
    }
    var iframe = "<iframe id='myFrame' scrolling='auto' frameborder='0' src='../Charge/StopFee.aspx?FeeID=" + feeidarry[0] + "' style='width:100%;height:" + ($(window).height() - 40) + "px'></iframe>";
    $("<div id='winremove'></div>").appendTo("body").window({
        title: '停用' + Name + "收费标准",
        width: $(window).width() - 100,
        height: $(window).height(),
        top: 0,
        left: 50,
        modal: true,
        minimizable: false,
        maximizable: false,
        collapsible: false,
        content: iframe,
        onClose: function () {
            $("#winremove").remove();
            loadChargeFees(ID);
        }
    });

}
