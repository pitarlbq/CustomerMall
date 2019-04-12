var category_count = 0;
$(function () {
    getFields(true);
});
function getFields(getcategory) {
    MaskUtil.mask();
    var options = { visit: 'getzhuangxiucategoryparams' };
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: '../Handler/ZhuangXiuHandler.ashx',
        data: options,
        success: function (data) {
            MaskUtil.unmask();
            if (!data.status) {
                show_message("获取列表失败", "info");
                return;
            }
            if (getcategory) {
                $('#zhuangxiucategory_field').html('<div class="title">项目类别</div>');
                if (data.category_list.length == 0) {
                    addzhuangxiucategory();
                    return;
                }
                $.each(data.category_list, function (index, item) {
                    addColumnField('zhuangxiucategory', category_count, item.ID, item.Name);
                    category_count = item.ID;
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
    $html += "<a href=\"javascript:void(0)\" onclick=\"dochoose('" + inputid + "','" + name + "')\" class=\"easyui-linkbutton btnlinkbar\" data-options=\"plain:true,iconCls:'icon-choose'\">选择</a>";
    $html += "<a href=\"javascript:void(0)\" onclick=\"deletecolumns('" + inputid + "','" + name + "')\" class=\"easyui-linkbutton btnlinkbar\" data-options=\"plain:true,iconCls:'icon-remove'\">删除</a>";
    html += '</div>';
    $(html).appendTo('#' + name + '_field');
    $.parser.parse("#" + divid);
}
function dochoose(id, name) {
    id = id.trim();
    var data_id = Number($("#" + id).attr('data-id'));
    if (data_id == 0) {
        show_message('请先保存', 'info');
        return;
    }
    parent.ChosenInCategoryID = data_id;
    do_close();
}
function addzhuangxiucategory() {
    category_count++;
    addColumnField('zhuangxiucategory', category_count, 0, "");
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
                    url: '../Handler/ZhuangXiuHandler.ashx',
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
        url: '../Handler/ZhuangXiuHandler.ashx',
        data: options,
        success: function (message) {
            MaskUtil.unmask();
            if (message.status) {
                show_message('保存成功', 'success', function () {
                    getFields(true);
                });
            }
            else {
                show_message('系统错误', 'error');
            }
        }
    });
}

function do_close() {
    parent.do_close_dialog(function () {
        parent.loadComboboxParams(true);
    });
}
