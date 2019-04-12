$(function () {
    tabCloseEven();
});

function addTab(subtitle, url, icon) {
    $('#left_menu').hide();
    if (!$('#tabs').tabs('exists', subtitle)) {
        $('#tabs').tabs('add', {
            title: subtitle,
            content: createFrame(url, subtitle),
            closable: true,
            icon: icon
        });
    } else {
        $('#tabs').tabs('select', subtitle);
        if (subtitle == '收费中心' && icon == 'newsfzx') {
            var tab = $('#tabs').tabs('getSelected');
            $('#tabs').tabs('update', {
                tab: tab,
                options: {
                    title: subtitle,
                    content: createFrame(url, subtitle),
                }
            });
        }
    }
    tabClose();
}
function addnewTab(subtitle, url, icon) {
    try {
        $('#left_menu').show();
    } catch (e) {
    }
    if (!$('#tabs').tabs('exists', subtitle)) {
        $('#tabs').tabs('add', {
            title: subtitle,
            content: createFrame(url),
            closable: false,
            icon: icon
        });
    } else {
        $('#tabs').tabs('select', subtitle);
        var tab = $('#tabs').tabs('getSelected');
        $('#tabs').tabs('update', {
            tab: tab,
            options: {
                title: subtitle,
                content: createFrame(url),
            }
        });
    }
    $('#tabs').tabs({
        onSelect: function (title, index) {
            top.TopTitle = title;
            top.TopIndex = index;
            if (title == '资源管理' || title == '收费标准') {
                top.treeType = 1;
            } else {
                top.treeType = 4;
            }
            top.openTreeContent();
        },
        onBeforeClose: function (title, index) {
        }
    })
    tabClose();
}
var realcostamalysisdetails_loaddata, tochargeanalysis_loaddata;
function createFrame(url, title) {
    var width = document.body.clientWidth;
    var id = 'top_main_frame';
    if (title && title == '收费中心') {
        id = 'top_chargefee_frame';
    }
    if (title && title == '任务看板') {
        id = 'top_service_frame';
    }
    if (title && title == '支出登记列表') {
        id = 'top_payservice_frame';
    }
    if (title && title == '单据格式') {
        id = 'top_printformat_frame';
    }
    if (title && title == '参数设置') {
        id = 'top_paramset_frame';
    }
    var frameWidth = width - 211;
    //var s = '<iframe name="mainFrame" scrolling="auto" frameborder="0"  src="' + url + '" style="width:100%;height:' + ($height - 45) + 'px;border:0;"></iframe>';
    var s = '<iframe name="mainFrame" class="mainFrame" id="' + id + '" scrolling="auto" frameborder="0"  src="' + url + '" style="width:95%;height:90%; border: solid 5px #f0f0f0;" onload="dynsiteFramesize()"></iframe>';
    return s;
}
window.onresize = dynsiteFramesize;
function dynsiteFramesize() {
    var $width = $('.rightBox .tabs-panels').width();
    var $height = $('.rightBox .tabs-panels').height();
    $(".mainFrame").css("width", ($width - 10) + "px");
    $(".mainFrame").css("height", ($height - 15) + "px");
}
function tabClose() {
    $(".tabs-inner").dblclick(function () {
        var subtitle = $(this).children(".tabs-closable").text();
        $('#tabs').tabs('close', subtitle);
    });
    $(".tabs-inner").bind('contextmenu', function (e) {
        $('#mm').menu('show', {
            left: e.pageX,
            top: e.pageY
        });
        var subtitle = $(this).children(".tabs-closable").text();
        $('#tabs').tabs('select', subtitle);
        return false;
    });
}
function tabCloseEven() {
    $("#mm-tabclose").click(function () {
        var title = $("#tabs").tabs("getSelected").panel("options").title;
        if (title == "初始桌面")
            return;
        $("#tabs").tabs("close", title);
    });
}