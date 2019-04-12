var column_count = 0;
var column_name = 'tasktype'
$(function () {
    getFields(true);
});
function getFields(gettask) {
    MaskUtil.mask();
    var options = { visit: 'getdevicetasktypeparams' };
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: '../Handler/DeviceHandler.ashx',
        data: options,
        success: function (data) {
            MaskUtil.unmask();
            if (!data.status) {
                show_message("获取列表失败", "info");
                return;
            }
            if (gettask) {
                $('#' + column_name + '_field').html('');
                if (data.list.length == 0) {
                    addcolumn();
                    return;
                }
                $.each(data.list, function (index, item) {
                    addColumnField(column_count, item.ID, item.Name);
                    column_count = item.ID;
                })
            }
        }
    });
}
function addColumnField(count, ColumnID, ColumnName) {
    var html = '';
    var divid = '';
    var inputid = '';
    if (ColumnID > 0) {
        divid = column_name + 'column_' + ColumnID;
        inputid = 'input_' + column_name + 'column_' + ColumnID;
    }
    else {
        divid = column_name + 'column_' + count;
        inputid = 'input_' + column_name + 'column_' + count;
    }
    html += '<div class="field" id="' + divid + '">';
    html += '<input type="text" class="' + column_name + 'column" data-id="' + ColumnID + '" data-count="' + count + '" id="' + inputid + '" value="' + ColumnName + '">';
    $html += "<a href=\"javascript:void(0)\" onclick=\"deletecolumns('" + inputid + "')\" class=\"easyui-linkbutton btnlinkbar\" data-options=\"plain:true,iconCls:'icon-remove'\">删除</a>";
    html += '</div>';
    $(html).appendTo('#' + column_name + '_field');
    $.parser.parse("#" + divid);
}
function addcolumn() {
    column_count++;
    addColumnField(column_count, 0, "");
}
function deletecolumns(id) {
    id = id.trim();
    var data_id = Number($("#" + id).attr('data-id'));
    if (data_id > 0) {
        top.$.messager.confirm('提示', '确认删除', function (r) {
            if (r) {
                MaskUtil.mask('body', '提交中');
                var options = { visit: 'deletecombobox' + column_name, ID: data_id };
                $.ajax({
                    type: 'POST',
                    dataType: 'json',
                    url: '../Handler/DeviceHandler.ashx',
                    data: options,
                    success: function (message) {
                        MaskUtil.unmask();
                        if (message.status) {
                            show_message('删除成功', 'success', function () {
                                $('#' + column_name + 'column_' + data_id).remove();
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
    $('#' + column_name + 'column_' + data_count).remove();
}
function savecolumns() {
    if ($('input.' + column_name + 'column').length == 0) {
        show_message("请添加字段", "info");
        return;
    }
    var IDList = [];
    var List = [];
    $('input.' + column_name + 'column').each(function () {
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
    var options = { visit: 'savecombobox' + column_name, list: JSON.stringify(List) };
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: '../Handler/DeviceHandler.ashx',
        data: options,
        success: function (message) {
            MaskUtil.unmask();
            if (message.status) {
                show_message('保存成功', 'success', function () {
                    do_close();
                });
            }
            else {
                show_message('系统错误', 'error');
            }
        }
    });
}
function do_close() {
    parent.do_close_dialog();
}