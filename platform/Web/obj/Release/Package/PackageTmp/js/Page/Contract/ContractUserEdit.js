var content;
$(function () {
    setTimeout(function () {
        load_vue();
    }, 500);
});
function load_vue() {
    content = new Vue({
        el: '#fieldcontent',
        data: {
            list: [],
            count: 0,
            currentitem: null
        },
        methods: {
            getdata: function () {
                var that = this;
                if (ID <= 0) {
                    return;
                }
                var options = { visit: 'getuserfamilylist', ID: ID };
                $.ajax({
                    type: 'POST',
                    dataType: 'json',
                    url: '../Handler/RoomResourceHandler.ashx',
                    data: options,
                    success: function (data) {
                        if (data.status) {
                            that.list = data.list;
                            that.count = that.list.length;
                            return;
                        }
                        show_message('系统错误', 'error');
                    }
                });
            },
            add_line: function () {
                var that = this;
                that.count++;
                var item = { ID: 0, CustomerName: '', PhoneNumber: '', RelationDesc: '', count: that.count };
                that.list.push(item);
            },
            remove_line: function (item) {
                var that = this;
                if (item.ID == 0) {
                    $.each(that.list, function (index, item2) {
                        if (item.count == item2.count) {
                            that.list.splice(index, 1);
                            return false;
                        }
                    });
                    return;
                }
                top.$.messager.confirm('提示', '确认删除?', function (r) {
                    if (r) {
                        var options = { visit: 'removeuserfalimydata', ID: item.ID };
                        $.ajax({
                            type: 'POST',
                            dataType: 'json',
                            url: '../Handler/ContractHandler.ashx',
                            data: options,
                            success: function (data) {
                                if (data.status) {
                                    $.each(that.list, function (index, item2) {
                                        if (item.count == item2.count) {
                                            that.list.splice(index, 1);
                                            return false;
                                        }
                                    });
                                    that.set_box_value();
                                    return;
                                }
                                show_message('系统错误', 'error');
                            }
                        });
                    }
                })
            }
        }
    });
    content.getdata();
}