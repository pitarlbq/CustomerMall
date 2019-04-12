$(function () {
    if (ContractID > 0) {
        loadattachs();
    }
    if (canRent == 0) {
        $('.trRent').hide();
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
    tdIsContractDivideOn.bind('click', function () {
        isDivideOn();
    })
    isDivideOn();
    setTimeout(function () {
        addFile();
    }, 100);
});
function isDivideOn() {
    if (tdIsContractDivideOn.prop('checked')) {
        $('.divideInfo').show();
    } else {
        $('.divideInfo').hide();
    }
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
var filecount = 0;
function addFile() {
    $("#tdFile").find("a.fileadd").hide();
    $("#tdFile").find("a.fileremove").show();
    filecount++;
    var $html = "<div id=\"tdFile_" + filecount + "\">";
    $html += "<input class=\"easyui-filebox\" name=\"attachfile\" data-options=\"prompt:'请选择文件',buttonText: '选择文件'\" style=\"width: 60%;height:28px;\" />";
    $html += "<a href=\"javascript:void(0)\" onclick=\"addFile()\" class=\"easyui-linkbutton btnlinkbar fileadd\" data-options=\"plain:true,iconCls:'icon-add'\">添加</a>";
    $html += "<a href=\"javascript:void(0)\" onclick=\"deleteFile(" + filecount + ")\" class=\"easyui-linkbutton btnlinkbar fileremove\" style=\"display:none;\" data-options=\"plain:true,iconCls:'icon-remove'\">删除</a>";
    $html += "</div>";
    $("#tdFile").append($html);
    $.parser.parse("#tdFile_" + filecount);
}
function deleteFile(id) {
    $("#tdFile_" + id).html("");
}
function loadattachs() {
    getContractID();
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
function getContractID() {
    if (parent.ContractID > 0 && ContractID <= 0) {
        ContractID = parent.ContractID;
    }
}
function do_save() {
    var isValid = ffObj.form('enableValidation').form('validate');
    if (!isValid) {
        return;
    }
    var freelist = parent.getContractFeeRentList();
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
    var customerList = parent.getContractPartyList();
    getContractID();
    var IsContractDivideOn = 0;
    if (tdIsContractDivideOn.prop('checked')) {
        IsContractDivideOn = 1;
    }
    parent.MaskUtil.mask('body', '提交中');
    $('#ff').form('submit', {
        url: '../Handler/ContractHandler.ashx',
        onSubmit: function (param) {
            param.visit = 'savecontractbasicinfo';
            param.ContractID = ContractID;
            param.TopContractID = TopContractID;
            param.canNewRent = canNewRent;
            param.canChangeRent = canChangeRent;
            param.guid = guid;
            param.canedit = canSaveLog;
            param.freelist = JSON.stringify(freelist);
            param.customerList = JSON.stringify(customerList);
            param.IsContractDivideOn = IsContractDivideOn;
        },
        success: function (data) {
            parent.MaskUtil.unmask();
            var dataObj = eval("(" + data + ")");
            if (dataObj.status) {
                if (dataObj.ID > 0) {
                    ContractID = dataObj.ID;
                    parent.ContractID = ContractID;
                    show_message('保存成功', 'success', function () {
                        loadattachs();
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
