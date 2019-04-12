<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MapLocation.aspx.cs" Inherits="Web.Wechat.MapLocation" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="../js/easyui/gray/easyui.css" rel="stylesheet" />
    <link href="../styles/basic.css?v=41" rel="stylesheet" />
    <link href="../styles/buttons.css?v=41" rel="stylesheet" />
    <style type="text/css">
        #containermap {
            width: 100%;
            height: 500px;
            overflow: hidden;
            margin: 0;
            font-family: "微软雅黑";
        }
    </style>
</head>
<body>
    <div class="easyui-layout" data-options="fit:true,border:false">
        <div data-options="region:'north',border:false" style="height: 40px; font-size: 12px; padding: 5px;">
            <div class="operation_box">
                <input type="text" class="easyui-textbox" style="width: 100px" id="city" />
                <a href="javascript:void(0)" onclick="do_change_city()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-save'">城市定位</a>
                <input type="text" class="easyui-textbox" id="tdkeywords" style="width: 200px" placeholder="小区搜索" />
                <a href="javascript:void(0)" onclick="do_search()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-search'">搜索</a>
                <a href="javascript:void(0)" onclick="save_city(true)" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-save'">保存</a>
                <a href="javascript:void(0)" onclick="do_close()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-close'">关闭</a>
            </div>
        </div>
        <div data-options="region:'center',border:false">
            <div style="margin-bottom: 10px; text-align: center;">
            </div>
            <div id="containermap"></div>
        </div>
    </div>
</body>
<script src="../js/jquery-1.8.3.min.js"></script>
<script src="../js/easyui/jquery.easyui.min.js"></script>
<script src="../js/easyui/easyui-lang-zh_CN.js"></script>
<script src="../js/Page/Comm/MaskUtil.js"></script>
<script src="../js/Page/Comm/unit.js?t=<%=getToken()%>"></script>

<script type="text/javascript" src="http://api.map.baidu.com/api?v=2.0&ak=<%= this.BaiduAK %>"></script>
<script type="text/javascript">
    var map = null;
    var myInfoWindow = {};
    var LngLat = null;
    $(function () {
        if (typeof BMap == "undefined") {
            $("#container").html('<h2>加载百度地图失败</h2>');
        } else {
            get_city();
        }
    })
    function get_city() {
        var options = { visit: 'getconfigcity' };
        $.ajax({
            type: 'POST',
            dataType: 'json',
            url: '../Handler/MallHandler.ashx',
            data: options,
            success: function (message) {
                if (message.status && message.city != '') {
                    $('#city').textbox('setValue', message.city);
                }
                else {
                    $('#city').textbox('setValue', '成都');
                }
                do_change_city();
            }
        });
    }
    function save_city(is_save) {
        var city = $('#city').textbox('getValue');
        var options = { visit: 'saveconfigcity', city: city };
        $.ajax({
            type: 'POST',
            dataType: 'json',
            url: '../Handler/MallHandler.ashx',
            data: options,
            success: function (message) {
                if (is_save) {
                    do_save();
                }
            }
        });
    }
    function do_change_city() {
        save_city(false);
        var city_value = $('#city').textbox('getValue');
        map = new BMap.Map("containermap");          // 创建地图实例  
        map.centerAndZoom(city_value, 15);
        map.enableScrollWheelZoom(true);
        map.addEventListener("click", function (e) {
            LngLat = e.point.lng + "," + e.point.lat;
            get_address_detail(e.point);
            add_overlay(e.point);
        });
    }
    function do_save() {
        if (LngLat != "" && LngLat != null) {
            parent.LngLat = LngLat;
        }
        do_close();
    }
    function do_close() {
        parent.do_close_dialog(function () {
            parent.open_map_location_done();
        });
    }
    function get_address_detail(point) {
        var geoc = new BMap.Geocoder();
        geoc.getLocation(point, function (rs) {
            var addComp = rs.addressComponents;
            var address = addComp.province + addComp.city + addComp.district + addComp.street + addComp.streetNumber;
            try {
                parent.MapAddress = address;
            } catch (e) {
            }
        });
    }
    function do_search() {
        var keywords = $('#tdkeywords').textbox('getValue');
        if (keywords == '') {
            return;
        }
        var local = new BMap.LocalSearch(map, {
            renderOptions: { map: map }
        });
        local.search(keywords);
    }
    function add_overlay(point) {
        map.clearOverlays();
        var marker = new BMap.Marker(point);
        map.addOverlay(marker);
    }
</script>
</html>
