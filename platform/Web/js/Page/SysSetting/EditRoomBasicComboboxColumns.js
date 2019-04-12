﻿var roomstate_count = 0;
var roomtype_count = 0;
var roomproperty_count = 0;
$(function () {
    getFields(true, true, true);
});
function getFields(getroomstate, getroomtype, getroomproperty) {
    MaskUtil.mask();
    var options = { visit: 'getroombasicparams' };
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: '../Handler/RoomResourceHandler.ashx',
        data: options,
        success: function (data) {
            MaskUtil.unmask();
            if (!data.status) {
                show_message("获取列表失败", "info");
                return;
            }
            if (getroomstate) {
                $('#roomstate_field').html('');
                if (data.roomstate_list.length == 0) {
                    addroomstate();
                    return;
                }
                $.each(data.roomstate_list, function (index, item) {
                    addColumnField('roomstate', roomstate_count, item.ID, item.Name);
                    roomstate_count = item.ID;
                })
            }
            if (getroomtype) {
                $('#roomtype_field').html('');
                if (data.roomtype_list.length == 0) {
                    addroomtype();
                    return;
                }
                $.each(data.roomtype_list, function (index, item) {
                    addColumnField('roomtype', roomtype_count, item.ID, item.Name);
                    roomtype_count = item.ID;
                })
            }
            if (getroomproperty) {
                $('#roomproperty_field').html('');
                if (data.roomproperty_list.length == 0) {
                    addroomproperty();
                    return;
                }
                $.each(data.roomproperty_list, function (index, item) {
                    addColumnField('roomproperty', roomproperty_count, item.ID, item.Name);
                    roomproperty_count = item.ID;
                })
            }
        }
    });
}
function addColumnField(name, count, ColumnID, ColumnName) {
    var html = '';
    var divid = '';
    var inputid = '';
    if (ColumnID > 0) {
        divid = name + 'column_' + ColumnID;
        inputid = 'input_' + name + 'column_' + ColumnID;
    }
    else {
        divid = name + 'column_' + count;
        inputid = 'input_' + name + 'column_' + count;
    }
    html += '<div class="field" id="' + divid + '">';
    html += '<input type="text" class="' + name + 'column" data-id="' + ColumnID + '" data-count="' + count + '" id="' + inputid + '" value="' + ColumnName + '">';
    html += "<a href=\"javascript:void(0)\" onclick=\"deletecolumns('" + inputid + "','" + name + "')\" class=\"easyui-linkbutton btnlinkbar\" data-options=\"plain:true,iconCls:'icon-remove'\">删除</a>";
    html += '</div>';
    $(html).appendTo('#' + name + '_field');
    $.parser.parse("#" + divid);
}
function addroomstate() {
    roomstate_count++;
    addColumnField('roomstate', roomstate_count, 0, "");
}
function deletecolumns(id, name) {
    id = id.trim();
    var data_id = Number($("#" + id).attr('data-id'));
    if (data_id > 0) {
        top.$.messager.confirm('提示', '确认删除', function (r) {
            if (r) {
                MaskUtil.mask('body', '提交中');
                var options = { visit: 'deletecombobox' + name, ID: data_id };
                $.ajax({
                    type: 'POST',
                    dataType: 'json',
                    url: '../Handler/RoomResourceHandler.ashx',
                    data: options,
                    success: function (message) {
                        MaskUtil.unmask();
                        if (message.status) {
                            show_message('删除成功', 'success', function () {
                                $('#' + name + 'column_' + data_id).remove();
                            });
                        }
                        else if (message.msg) {
                            show_message(message.msg, "warning");
                        } else {
                            show_message('系统错误', 'error');
                        }
                    }
                });
            }
        })
        return;
    }
    var data_count = $("#" + id).attr('data-count');
    $('#' + name + 'column_' + data_count).remove();
}
function savecolumns(name) {
    if ($('input.' + name + 'column').length == 0) {
        show_message("请添加字段", "info");
        return;
    }
    var IDList = [];
    var List = [];
    $('input.' + name + 'column').each(function () {
        var data_id = Number($(this).attr('data-id'));
        var data_value = $(this).val();
        if (data_value == '') {
            return true;
        }
        List.push({ id: data_id, value: data_value });
    });
    if (List.length == 0) {
        show_message("参数名称不能为空", "info");
        return;
    }
    MaskUtil.mask('body', '提交中');
    var options = { visit: 'savecombobox' + name, list: JSON.stringify(List) };
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: '../Handler/RoomResourceHandler.ashx',
        data: options,
        success: function (message) {
            MaskUtil.unmask();
            if (message.status) {
                show_message('保存成功', 'success');
                getFields(true, true, true);
            }
            else {
                show_message('系统错误', 'error');
            }
        }
    });
}

function addroomtype() {
    roomtype_count++;
    addColumnField('roomtype', roomtype_count, 0, "");
}
function addroomproperty() {
    roomproperty_count++;
    addColumnField('roomproperty', roomproperty_count, 0, "");
}
