var returnvalue = "";
var ytnamevalue = [];
var trycount = 0;
var vueMenu = null;
$(function () {
    loadVueMenu();
    addnewTab('初始桌面', 'InitialSetup/Default.aspx?ID=0', '');
    $('#notify_img').hide();
    get_data();
    $("#time").hover(function () {
        $("#time .floatBox").show();
    }, function () {
        $("#time .floatBox").hide();
    });
    $("#user_center").click(function (e) {
        var target = $(e.target);
        if (target.closest("#user_center").length == 0) {
            if ($("#user_center").hasClass('open')) {
                $("#user_center").removeClass('open');
            }
        }
        else {
            if ($("#user_center").hasClass('open')) {
                $("#user_center").removeClass('open');
            }
            else {
                $("#user_center").addClass('open');
            }
            $("#btnwarning").removeClass('open');
        }
    });
    $("#btnwarning").click(function (e) {
        var target = $(e.target);
        if (target.closest("#btnwarning").length == 0) {
            if ($("#btnwarning").hasClass('open')) {
                $("#btnwarning").removeClass('open');
            }
        }
        else {
            if ($("#btnwarning").hasClass('open')) {
                $("#btnwarning").removeClass('open');
            }
            else {
                $("#btnwarning").addClass('open');
            }
            $("#user_center").removeClass('open');
        }
    });
    setTimeout(function () {
        $('#tabs .tabs-header').bind('click', function () {
            hide_popup();
        })
    }, 1000);
    $('#notifymsg').bind('click', function () {
        addTab('系统消息', 'Main/subpage.aspx?pageurl=../sysseting/sysmsglist.aspx&title=系统通知');
    })
    $('#left_menu .menubox').bind('click', function () {
        if ($(this).hasClass('active')) {
            return;
        }
        $('#left_menu .menubox').removeClass('active');
        $(this).addClass('active');
        var id = $(this).attr('data-id');
        addnewTab('初始桌面', 'InitialSetup/Default.aspx?ID=0&groupname=' + id, '');
    })
    $('#sub_shoufei').bind('click', function () {
        addTab('租金收取', 'Main/subpage.aspx?pageurl=../Contract/ContractFeeSummaryAnalysis.aspx&title=租金收取');
    })
    $('#sub_daoqi').bind('click', function () {
        addTab('合同到期', 'Main/subpage.aspx?pageurl=../Contract/ContractSummary.aspx&expired=1&title=合同到期');
    })
    $('#sub_baoxiu').bind('click', function () {
        do_view_baoshi();
    })
});
function loadVueMenu() {
    vueMenu = new Vue({
        el: '#menuVue',
        data: {
            list: [],
            menulist: [],
        },
        methods: {
            get_all_menu: function () {
                var that = this;
                var options = { visit: "getallmymenus" }
                $.ajax({
                    type: 'POST',
                    dataType: 'json',
                    url: 'Handler/SysSettingHandler.ashx',
                    data: options,
                    success: function (data) {
                        if (data.status) {
                            that.list = data.list;
                            that.get_my_menus('wynk');
                        }
                    }
                });
            },
            get_my_menus: function (groupname) {
                var that = this;
                that.menulist = [];
                $.each(that.list, function (index, menu) {
                    if (menu.GroupName == groupname) {
                        that.menulist.push(menu);
                    }
                })
                totalLiCount = that.menulist.length;
                setTimeout(function () {
                    yyui_menu('.yyui_menu1');
                }, 200)
            },
            do_open_menu: function (item) {
                if (item.URL == '') {
                    return;
                }
                addTab(item.Title, item.URL);
            }
        }
    });
    vueMenu.get_all_menu();
}
function LoginSocketInit() {
    if (trycount > 3) {
        return;
    }
    var options = { visit: "socketinit" }
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: 'Handler/CommHandler.ashx',
        data: options,
        success: function (data) {
            try {
                var obj = {
                    loginname: data.loginname,
                    guid: data.guid,
                    url: url,
                    socketserver: "ws://" + socketserverurl,
                    action: 'login'
                };
                LoginConnect.init(obj);
                LoginConnect.submit();
            } catch (e) {
                trycount++;
                LoginSocketInit();
            }
        }
    });
}
function get_data() {
    var options = { visit: "gethomedatasource" }
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: 'Handler/CommHandler.ashx',
        data: options,
        success: function (data) {
            if (!data.status) {
                return;
            }
            try {
                if (data.msgcount && data.msgcount > 0) {
                    $('#notify_img').show();
                    $('#notify_img').html(data.msgcount + '+');
                }
                else {
                    $('#notify_img').hide();
                }
            } catch (e) {
            }
            try {
                if (data.total_count && data.total_count > 0) {
                    $('#warning_point').show();
                    $('#warning_point').html(data.total_count);
                }
                else {
                    $('#warning_point').hide();
                }
            } catch (e) {
            }
            try {
                if (data.daoqi_contractcount && data.daoqi_contractcount > 0) {
                    $('#daoqi_count').html(data.daoqi_contractcount);
                }
                else {
                    $('#shoufei_count').html('0');
                }
            } catch (e) {
            }
            try {
                if (data.shoufei_contractcount && data.shoufei_contractcount > 0) {
                    $('#shoufei_count').html(data.shoufei_contractcount);
                }
                else {
                    $('#shoufei_count').html('0');
                }
            } catch (e) {
            }
            try {
                if (data.service_count && data.service_count > 0) {
                    $('#service_count').html(data.service_count);
                }
                else {
                    $('#service_count').html('0');
                }
            } catch (e) {
            }
        }
    });
}
function get_notify_alert() {
    var options = { visit: "getsysmessage" }
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: 'Handler/CommHandler.ashx',
        data: options,
        success: function (data) {
            if (!data.status) {
                return;
            }
        }
    });
}
function do_grab_chat(ID) {
    var options = { visit: "grabwechatchat", ID: ID }
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: 'Handler/CommHandler.ashx',
        data: options,
        success: function (data) {
            if (data.status) {
                show_message('请打开微信在线客服页面开始聊天', 'success', function () {
                    window.open('https://mpkf.weixin.qq.com/');
                });
                return;
            }
            if (data.error) {
                show_message(data.error, 'warning');
                return;
            }
            show_message('系统异常', 'error');
        }
    });
    close_message();
}

function do_view_baoshi() {
    addTab('报事报修', 'Main/subpage.aspx?pageurl=../CustomerService/ServiceMgr.aspx?status=100&title=报事报修');
    close_message();
}
function do_view_mallorder(status) {
    addTab('订单管理', 'Main/subpage.aspx?pageurl=../Mall/OrderMgr.aspx?status=' + status + '&title=订单管理');
    close_message();
}
function do_view_suggestion() {
    addTab('投诉建议', 'Main/subpage.aspx?pageurl=../CustomerService/ServiceSuggestionMgr.aspx&title=投诉建议');
    close_message();
}
function hide_popup() {
    if ($("#user_center,#btnwarning").hasClass('open')) {
        $("#user_center,#btnwarning").removeClass('open');
    }
}
function viewPersonal() {
    addChildWin('个人中心', 'UserInfo/PersionalInfo.aspx?op=detail', $(window).width() - 400, $(window).height() - 50, 50, 200, 'winadd', function () {
        $("#winadd").remove();
    });
}
function addChildWin(title, url, width, height, top, left, id, OnClose) {
    var frame = '<iframe name="mainFrame" scrolling="auto" frameborder="0"  src="' + url + '" style="width:100%;height:99%;min-height:' + (height - 40) + 'px;border:0;"></iframe>'
    $("<div id='" + id + "'></div>").appendTo("body").window({
        title: title,
        width: width,
        height: height,
        top: top,
        left: left,
        modal: true,
        minimizable: false,
        maximizable: false,
        collapsible: false,
        content: frame,
        onClose: OnClose
    });
}
function checkWaringContract() {
    var options = { visit: "checkwarningcontract" }
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: 'Handler/CommHandler.ashx',
        data: options,
        success: function (data) {
            if (data.status && data.totalcount > 0) {
                var messages = '您有' + data.totalcount + '个合同即将到期，<a href="javascript:viewContract(' + data.totalcount + ')">查看详情</a>'
                alertNotify(messages);
                return;
            }
        }
    });
}
function alertNotify(messages) {
    if (!messages) {
        return;
    }
    $('#message_ring')[0].play();
    $.messager.show({
        title: '温馨提示',
        msg: messages,
        showSpeed: 1000,
        timeout: 0,     //手动关闭
        showType: 'slide',
        width: 260,
        height: 160
    });
}
function viewContract(totalCount) {
    addTab('租赁到期', 'Contract/Setup.aspx?total=' + totalCount, '');
}
function poplogin() {
    var options = { visit: "forcelogout" }
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: 'Handler/CommHandler.ashx',
        data: options,
        success: function (data) {
            $.messager.alert('提示', '帐号已在别处登录，你将被强迫下线（请保管好自己的用户密码）！', 'info', function () {
                var frame = '<iframe name="mainFrame" scrolling="auto" frameborder="0"  src="MinLogin.aspx" style="width:100%;height:260px;border:0;"></iframe>';
                var pagewidth = $(top.window).width()
                top.$("<div id='winlogin'></div>").appendTo("body").window({
                    title: '登录',
                    width: 400,
                    height: 300,
                    top: 50,
                    left: 300,
                    modal: true,
                    minimizable: false,
                    maximizable: false,
                    collapsible: false,
                    closable: false,
                    draggable: false,
                    resizable: false,
                    content: frame,
                    onClose: function () {
                        top.$('#winlogin').remove();
                        LoginSocketInit();
                    }
                })
                top.$('#winlogin').window('center');
            })
        }
    });
}
function clearcache() {
    var options = { visit: "clearcache" }
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: 'Handler/CommHandler.ashx',
        data: options,
        success: function (data) {
        }
    });
}
function close_message() {
    //$.messager.close();
    $(".messager-body").window('close');
}
function socket_notify(obj) {
    if (obj.type == 'notifychat' && HasWechatServiceAuth) {
        var messages = '微信在线聊天申请，<a href="javascript:do_grab_chat(' + obj.ID + ')">开始聊天</a>'
        alertNotify(messages);
        return;
    }
    if (obj.type == 'notifyclearcache') {
        clearcache();
        return;
    }
    if (obj.type == 'notifysuggestion') {
        var messages = '您有一条新的投诉建议，<a href="javascript:do_view_suggestion()">点击查看</a>'
        alertNotify(messages);
        return;
    }
    if (obj.type == 'notifyservice') {
        var messages = '您有一条新的报事报修单，<a href="javascript:do_view_baoshi()">查看详情</a>'
        alertNotify(messages);
        return;
    }
    if (obj.type == 'notifyorderpaied') {
        var messages = '您有一条新订单来了，<a href="javascript:do_view_mallorder(5)">查看详情</a>'
        alertNotify(messages);
        return;
    }
    if (obj.type == 'notifyorderrefundrequest') {
        var messages = '您有一条订单退款通知，<a href="javascript:do_view_mallorder(6)">查看详情</a>'
        alertNotify(messages);
        return;
    }
}