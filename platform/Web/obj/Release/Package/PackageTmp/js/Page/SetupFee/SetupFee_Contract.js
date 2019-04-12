
var count = 0;
$(function () {
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
function loadcheckFees(RoomID, ChargeID, isContinue) {
    $(".feetable input[type='checkbox']").prop("checked", false);
    if (!isContinue) {
        return;
    }
    var options = { visit: "loadcheckfeeids", RoomID: RoomID, ChargeID: ChargeID };
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: '../Handler/FeeCenterHandler.ashx',
        data: options,
        success: function (data) {
            if (data.status) {
                $.each(data.list, function (index, item) {
                    $("#" + item.ChargeFeeID + "_check").prop("checked", true);
                    $("#" + item.ChargeFeeID + "_UnitPrice").html(item.UnitPrice);
                    var start = formatDate(item.StartTime);
                    $("#" + item.ChargeFeeID + "_StartTime").html(start);

                    var end = formatDate(item.EndTime);
                    $("#" + item.ChargeFeeID + "_EndTime").html(end);
                })
            }
            else {
            }
        }
    });
}
function initialcharge(obj) {
    var html = '';
    html += '<table class="yttable">';
    html += '<tr>';
    html += '<td>';
    html += "费用名称";
    html += '</td>';
    html += '<td>';
    html += '<input type="text" value="' + obj.summary.Name + '" id="' + obj.summary.ID + '_chargename" />';
    html += '</td>';
    html += '<td>';
    html += "计费方式";
    html += '</td>';
    html += '<td>';
    html += ListHTML(getChargeTypeList(), obj, "ChargeTypeList");
    html += '</td>';
    html += '<td>';
    html += "允许导入费用";
    html += '</td>';
    html += '<td>';
    html += ListHTML(null, obj, "AllowImportList");
    html += '</td>';
    html += '</tr>';
    html += '<tr>';
    html += '<td>';
    html += "小数位数";
    html += '</td>';
    html += '<td>';
    html += '<input type="text" value="' + (obj.summary.EndNumberCount < 0 ? 0 : obj.summary.EndNumberCount) + '" id="' + obj.summary.ID + '_EndNumberCount" />';
    html += '</td>';
    //html += '<td>';
    //html += "尾数";
    //html += '</td>';
    //html += '<td>';
    //html += ListHTML(getEndNumberList(), obj, "EndNumberList");
    //html += '</td>';
    html += '<td>';
    html += '<input type="button" class="savebutton buttonmin" onclick="saveSummary(' + obj.summary.ID + ')" value=""/>';
    html += '</td>';
    html += '<td>';
    html += '<input type="button" class="removebutton buttonmin" onclick="deleteSummary(' + obj.summary.ID + ')" value=""/>';
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
    html += '<td>';
    html += "计费周期";
    html += '</td>';
    html += '<td>';
    html += "备注";
    html += '</td>';
    html += '</tr>';
    $.each(obj.list, function (index, item) {
        html += '<tr>';
        html += '<td>';
        html += '<input type="checkbox" id="' + item.ID + '_check" name="' + obj.summary.ID + '_check"/>';
        html += '</td>';
        html += '<td id="' + item.ID + '_UnitPrice">';
        html += item.UnitPrice;
        html += '</td>';
        html += '<td id="' + item.ID + '_StartTime">';
        html += formatDate(item.StartTime);
        html += '</td>';
        html += '<td id="' + item.ID + '_EndTime">';
        html += formatDate(item.EndTime);
        html += '</td>';
        html += '<td>';
        html += formatEndType(item.EndTypeID);
        html += '</td>';
        html += '<td>';
        html += (item.ChargeTypeCount < 0 ? 0 : item.ChargeTypeCount);
        html += '</td>';
        html += '<td>';
        html += item.Remark;
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
    $.each(getEndTypeList(), function (index, value) {
        if (value.ID == endtype) {
            typedesc = value.Name;
            return false;
        }
    })
    return typedesc;
}
function ShowSummaryDetail(SummaryID) {
    var divD = document.getElementById(SummaryID + "_SummaryDetail");
    if (divD.style.display == "none") {
        divD.style.display = "block";
    }
    else {
        divD.style.display = "none";
    }
}
function initialyt(obj) {
    if (obj == null) {
        return;
    }
    var html = '';
    html += '<td class="yttd">';
    html += ' <div class="ytbox">';
    html += ' <div style="cursor: pointer;" onclick="ShowSummaryDetail(' + obj.summary.ID + ')" class="yttitle">';
    html += '<div class="ytnumber">序号:<input type="text" value="' + obj.summary.OrderBy + '" id="' + obj.summary.ID + '_number" /></div>';
    html += '<label class="summaryname">' + obj.summary.Name + '</label></div>';
    html += '<div style="display:none;" id="' + obj.summary.ID + '_SummaryDetail">';
    html += '<div id="' + obj.summary.ID + '_chargetable"></div>';
    html += '<div id="' + obj.summary.ID + '_feetable"></div>';
    html += ' <div class="yttitle">';
    html += '<input type="button" class="addbutton buttonmin" onclick="addFee(' + obj.summary.ID + ',\'' + obj.summary.Name + '\')" value=""/>';
    html += '<input type="button" onclick="startFee(' + obj.summary.ID + ')" value="启用"/>';
    html += '<input type="button" class="removebutton buttonmin" onclick="removeFee(' + obj.summary.ID + ')" value="删除"/>';
    html += '</div>';
    html += '</div>';
    html += '</div>';
    html += '</td>';
    var tdlength = $("table#projecttable tr.yttr:last td.yttd").length;
    if (tdlength < 1) {
        $("table#projecttable tr.yttr:last").append(html);
    }
    else {
        $("table#projecttable").append("<tr class=\"yttr\">" + html + "</tr>");
    }
    initialcharge(obj);
    initialfee(obj);
}
function ListHTML(list, obj, type) {
    var html = "";
    html += '<select class="' + type + '" id="' + obj.summary.ID + '_' + type + '">';
    if (type == "AllowImportList") {
        if (obj.summary.IsAllowImport) {
            html += '<option value="1" selected="selected">是</option>';
            html += '<option value="0">否</option>';
        }
        else {
            html += '<option value="1" >是</option>';
            html += '<option value="0" selected="selected">否</option>';
        }
    }
    else {
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
    }
    html += '</select>';
    return html;
}
function addFee(ID, Name) {
    var iframe = "<iframe id='myFrame' scrolling='auto' frameborder='0' src='../SetupFee/AddFee.aspx?ID=" + ID + "' style='width:100%;height:" + ($(window).height() - 40) + "px'></iframe>";
    parent.$("<div id='winadd'></div>").appendTo("body").window({
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
            parent.$("#winadd").remove();
            loadChargeFees(ID, 0);
        }
    });
}
function startFee(ID) {
    var idarry = parent.GetSelectRoomCheck();
    var ProjectID = parent.GetSelectRadio();
    if (idarry.length == 0 && ProjectID == "") {
        show_message("请同时选中收费标准和对应资源", "warning");
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
        show_message("请同时选中收费标准和对应资源", "warning");
        return;
    }
    MaskUtil.mask('body', '提交中');
    var options = { visit: "savecontractroomfee", feeids: JSON.stringify(feeidarry), RoomIDs: JSON.stringify(idarry), ProjectID: ProjectID };
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
        show_message("请选择收费标准", "info");
        return;
    }
    var options = { visit: "checkdeletechargesummary", FeeID: JSON.stringify(feeidarry) };
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: '../Handler/CheckStatusHandler.ashx',
        data: options,
        success: function (data) {
            if (!data.status) {
                show_message("收费标准包含未删除的费项档案,删除取消", "info");
                return;
            }
            top.$.messager.confirm("提示", "确认删除该收费项目?", function (r) {
                if (r) {
                    MaskUtil.mask('body', '提交中');
                    options = { visit: "removeroomfee", FeeID: feeidarry[0] };
                    $.ajax({
                        type: 'POST',
                        dataType: 'json',
                        url: '../Handler/FeeCenterHandler.ashx',
                        data: options,
                        success: function (data) {
                            MaskUtil.unmask();
                            if (data.status) {
                                show_message('删除成功', 'success');
                                loadChargeFees(ID, 0)
                            }
                            else {
                                show_message('系统错误', 'error');
                            }
                        }
                    });
                }
            });
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
            loadChargeFees(ID, 0);
        }
    });
}
function stopFee(ID) {
    var idarry = parent.GetSelectRoomCheck();
    if (idarry.length == 0) {
        var radioid = parent.GetSelectRadio();
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

function viewByRoom() {
    var roomidarry = [];
    roomidarry = parent.GetSelectRoomCheck();
    var projectid = parent.GetSelectRadio();
    if (roomidarry.length == 0 && (projectid == "" || projectid == null)) {
        show_message("请选择一个房间", "info");
        return;
    }
    var iframeurl = "<iframe id='myFrame' scrolling='auto' frameborder='0' src='../SetupFee/ViewRoomFeeList.aspx?RoomIDs=" + JSON.stringify(roomidarry) + "&ProjectID=" + projectid + "' style='width:100%;height:" + ($(window).height() - 40) + "px'></iframe>";
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
    parent.$("<div id='winremove'></div>").appendTo("body").window({
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
            parent.$("#winremove").remove();
            loadChargeFees(ID, 0);
        }
    });

}
function addChargeSummary() {
    var iframeurl = "<iframe id='myFrame' scrolling='auto' frameborder='0' src='../SetupFee/AddNormalSummaryFee.aspx?FeeType=5' style='width:100%;height:" + ($(window).height() - 40) + "px'></iframe>";
    parent.$("<div id='winadd'></div>").appendTo("body").window({
        title: '新增合同费用',
        width: $(window).width() - 100,
        height: $(window).height(),
        top: 0,
        left: 50,
        modal: true,
        iconCls: 'icon-add',
        minimizable: false,
        maximizable: false,
        resizable: true,
        collapsible: false,
        content: iframeurl,
        onClose: function () {
            parent.$("#winadd").remove();
            $("table#projecttable").empty();
            $("table#projecttable").append("<tr class=\"yttr\"></tr>");
            loadChargeFees(0, 0);
        }
    });
}
function saveSummary(ID) {
    var OrderBy = $("#" + ID + "_number").val();
    var Name = $("#" + ID + "_chargename").val();
    var TypeID = $("#" + ID + "_ChargeTypeList").val();
    var CategoryID = 1;
    //var EndNumber = $("#" + ID + "_EndNumberList").val();
    var EndNumber = 3;
    var EndNumberCount = $("#" + ID + "_EndNumberCount").val();
    var IsAllowImport = $("#" + ID + "_AllowImportList").val();
    var options = { visit: "savechargesummary", ID: ID, Name: Name, TypeID: TypeID, CategoryID: CategoryID, EndNumber: EndNumber, OrderBy: OrderBy, EndNumberCount: EndNumberCount, IsAllowImport: IsAllowImport };
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: '../Handler/FeeCenterHandler.ashx',
        data: options,
        success: function (data) {
            if (data.status) {
                show_message('保存成功', 'success');
                $("table#projecttable").empty();
                $("table#projecttable").append("<tr class=\"yttr\"></tr>");
                loadChargeFees(0, 0);
            }
        }
    });
}
function deleteSummary(ID) {
    var RoomIDs = parent.GetSelectRoomCheck();
    var ProjectID = parent.GetSelectRadio();
    var options = { visit: "checkexistsummary", ID: ID };
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: '../Handler/FeeCenterHandler.ashx',
        data: options,
        success: function (data) {
            if (!data.status) {
                show_message("收费项目包含已启用的收费标准,删除取消", "info");
                return;
            }
            top.$.messager.confirm("提示", "确认删除该收费项目?", function (r) {
                if (r) {
                    options = { visit: "deletechargesummary", ID: ID, RoomIDs: RoomIDs, ProjectID: ProjectID };
                    $.ajax({
                        type: 'POST',
                        dataType: 'json',
                        url: '../Handler/FeeCenterHandler.ashx',
                        data: options,
                        success: function (data) {
                            if (data.status) {
                                show_message('删除成功', 'success');
                                $("table#projecttable").empty();
                                $("table#projecttable").append("<tr class=\"yttr\"></tr>");
                                loadChargeFees(0, 0);
                            }
                        }
                    });
                }
            })
        }
    });
}

