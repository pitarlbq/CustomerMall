
var content;
$(function () {
    var options = { visit: 'getroomstate' };
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: '../Handler/RoomResourceHandler.ashx',
        data: options,
        success: function (result) {
            if (result.status) {
                content.RoomStateList = result.list;
                var RoomStateList = result.list;
                RoomStateList.splice(0, 0, { ID: "", Name: "全部" });
                $("#tdRoomState").combobox({
                    data: RoomStateList,
                    valueField: 'ID',
                    textField: 'Name'
                });
            }
        }
    });
    content = new Vue({
        el: '#fieldcontent',
        data: {
            roomlist: [],
            canedit: false,
            RoomStateList: []
        },
        methods: {
            getdata: function () {
                var that = this;
                var StartTime = $('#tdStartTime').datebox("getValue");
                var EndTime = $('#tdEndTime').datebox("getValue");
                if (StartTime != '' && EndTime != '') {
                    if (stringToDate(StartTime).valueOf() > stringToDate(EndTime).valueOf()) {
                        show_message('开始日期不能大于结束日期', 'warning');
                        return;
                    }
                }
                var roomids = [];
                var projectids = []
                try {
                    roomids = GetSelectedRooms();
                    projectids = GetSelectedProjects();
                } catch (e) {

                }
                if (roomids.length == 0 && projectids.length == 0) {
                    //show_message("请选择资源项目", "info");
                    return;
                }
                var keywords = $('#tdKeyword').searchbox("getValue");
                var RoomStateID = $('#tdRoomState').combobox("getValue");
                var RoomFeeState = $('#tdRoomFeeState').combobox("getValue");

                var options = { visit: 'getzuzhonglist', roomids: JSON.stringify(roomids), projectids: JSON.stringify(projectids), keywords: keywords, RoomStateID: RoomStateID, RoomFeeState: RoomFeeState, StartTime: StartTime, EndTime: EndTime };
                MaskUtil.mask();
                $.ajax({
                    type: 'POST',
                    dataType: 'json',
                    url: '../Handler/ContractHandler.ashx',
                    data: options,
                    success: function (data) {
                        MaskUtil.unmask();
                        if (data.status) {
                            that.roomlist = data.list;
                            return;
                        }
                        show_message('系统错误', 'error');
                    }
                });
            },
            createdata: function () {
                var that = this;
                var roomids = [];
                var projectids = []
                try {
                    roomids = GetSelectedRooms();
                    projectids = GetSelectedProjects();
                } catch (e) {

                }
                if (roomids.length == 0 && projectids.length == 0) {
                    show_message('请选择需要生成的资源树', 'info');
                    return;
                }
                MaskUtil.mask('body', '提交中');
                var options = { visit: 'createzuzhong', RoomIDs: JSON.stringify(roomids), ProjectIDs: JSON.stringify(projectids) };
                $.ajax({
                    type: 'POST',
                    dataType: 'json',
                    url: '../Handler/ContractHandler.ashx',
                    data: options,
                    success: function (data) {
                        MaskUtil.unmask();
                        if (data.status) {
                            show_message("生成成功", "success", function () {
                                that.getdata();
                            });
                            return;
                        }
                        show_message('系统错误', 'error');
                    }
                });
            },
            doedit: function (data) {
                var that = this;
                var iframe;
                iframe = "../RoomResource/EditRoomResource.aspx?RoomID=" + data.RoomID;
                do_open_dialog('修改' + data.RoomName + '信息', iframe);
            },
            doremove: function (data) {
                var that = this;
                var ids = [];
                $.each(that.roomlist, function (index, item) {
                    if (item.ischecked) {
                        ids.push(item.ID);
                    }
                })
                if (ids.length == 0) {
                    show_message('请选择需要删除的对象', 'info');
                    return;
                }
                top.$.messager.confirm('提示', '确认删除', function (r) {
                    if (r) {
                        MaskUtil.mask('body', '提交中');
                        var options = { visit: 'removezukong', ids: JSON.stringify(ids) };
                        $.ajax({
                            type: 'POST',
                            dataType: 'json',
                            url: '../Handler/ContractHandler.ashx',
                            data: options,
                            success: function (result) {
                                MaskUtil.unmask();
                                if (result.status) {
                                    show_message('删除成功', 'success', function () {
                                        that.getdata();
                                        //$.each(that.roomlist, function (index, item) {
                                        //    if (item.ID == data.ID) {
                                        //        that.roomlist.splice(index, 1);
                                        //        return false;
                                        //    }
                                        //})
                                    });
                                    return;
                                }
                                show_message('系统错误', 'error');
                            }
                        });
                    }
                })
            },
            dosave: function (data) {
                var that = this;
                var options = { visit: 'savezukong', ID: data.ID, RoomName: data.RoomName, RoomState: data.RoomState, RoomOwner: data.RoomOwner };
                MaskUtil.mask('body', '提交中');
                $.ajax({
                    type: 'POST',
                    dataType: 'json',
                    url: '../Handler/ContractHandler.ashx',
                    data: options,
                    success: function (result) {
                        MaskUtil.unmask();
                        data.canedit = false;
                        if (result.status) {
                            show_message('保存成功', 'success');
                            that.getdata();
                            return;
                        }
                        show_message('系统错误', 'error');
                    }
                });
            },
            viewroomfee: function (item) {
                var that = this;
                top.addTab('收费中心', GetContextPath + '/main/subpage.aspx?ID=11&roomid=' + item.RoomID, 'newsfzx')
            }
        }
    });
    content.getdata();
})
function SearchTT() {
    content.getdata();
}
function CreateZuKong() {
    content.createdata();
}
function SetUp() {
    var iframe = "../SysSeting/RoomStateColorSetUp.aspx";
    do_open_dialog('属性设置', iframe);
}
function doRemove() {
    content.doremove();
}