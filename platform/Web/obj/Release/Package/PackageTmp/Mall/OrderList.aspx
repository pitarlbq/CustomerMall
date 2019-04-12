<%@ Page Title="" Language="C#" MasterPageFile="~/Master/NavContent4.Master" AutoEventWireup="true" CodeBehind="OrderList.aspx.cs" Inherits="Web.Mall.OrderList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>订单管理</title>
    <script>
        var north_height = 70;
        $(function () {
            getparams();
        })
        function open_sub(ele, title, pageurl) {
            var $this = $(ele);
            var r = $(".act-item");
            for (var i = 0; i < r.length; i++) {
                $(r[i]).removeClass("active");
            }
            $this.addClass("active");
            var currentiframe = $('#ProductFrame');
            currentiframe.attr("src", pageurl);
            var $height = $(window).height();
            currentiframe.css("height", ($height - north_height) + "px");
        }
        var ProductName, PayStartTime, PayEndTime, BuyerNickName, OrderStatus, RateStatus, OrderNumber, ShipCompany, OrderType, BusinessName, BuyerPhoneNumber, ProjectID;
        function SearchTT() {
            ProductName = $('#tdProductName').textbox('getValue');
            PayStartTime = $('#tdPayStartTime').datebox('getValue');
            PayEndTime = $('#tdPayEndTime').datebox('getValue');
            BuyerNickName = $('#tdBuyerNickName').textbox('getValue');
            OrderStatus = $('#tdOrderStatus').combobox('getValue');
            RateStatus = $('#tdRateStatus').combobox('getValue');
            OrderNumber = $('#tdOrderNumber').textbox('getValue');
            ShipCompany = $('#tdShipCompany').combobox('getText');
            if ($('#tdShipCompany').combobox('getValue') == 0) {
                ShipCompany = '';
            }
            OrderType = $('#tdOrderType').combobox('getValue');
            BusinessName = $('#tdBusinessName').textbox('getValue');
            BuyerPhoneNumber = $('#tdBuyerPhoneNumber').textbox('getValue');
            ProjectID = $('#tdProjectID').combobox('getValue');
            var li_list = $("ul.top-bar").find("li");
            $.each(li_list, function (index, elem) {
                $(elem).removeClass('active');
            })
            if (OrderStatus != '') {
                $('#li_' + OrderStatus).addClass('active');
            }
            else {
                $('#li_0').addClass('active');
            }
            document.getElementById('ProductFrame').contentWindow.SearchTT();
        }
        function DoReset() {
            $('#tdProductName').textbox('setValue', '');
            $('#tdPayStartTime').datebox('setValue', '');
            $('#tdPayEndTime').datebox('setValue', '');
            $('#tdBuyerNickName').textbox('setValue', '');
            $('#tdOrderStatus').combobox('setValue', '');
            $('#tdRateStatus').combobox('setValue', '');
            $('#tdOrderNumber').textbox('setValue', '');
            $('#tdShipCompany').combobox('setValue', '');
            $('#tdOrderType').combobox('setValue', '');
            $('#tdBusinessName').textbox('setValue', '');
            $('#tdProjectID').combobox('setValue', '');
        }
        function onNorthCollapse() {
            var currentiframe = $('#ProductFrame');
            var $height = $(window).height();
            north_height = 70;
            currentiframe.css("height", ($height - north_height) + "px");
        }
        function onNorthonExpand() {
            var currentiframe = $('#ProductFrame');
            var $height = $(window).height();
            north_height = 230;
            currentiframe.css("height", ($height - north_height) + "px");
        }
        function getparams() {
            var options = { visit: 'getmallorderlistparams' };
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/MallHandler.ashx',
                data: options,
                success: function (message) {
                    if (message.status) {
                        $('#tdShipCompany').combobox({
                            editable: false,
                            valueField: 'ID',
                            textField: 'Name',
                            data: message.ship_list
                        });
                        $('#tdProjectID').combobox({
                            editable: false,
                            valueField: 'ID',
                            textField: 'Name',
                            data: message.project_list
                        });
                        return;
                    }
                    if (message.error) {
                        show_message(message.error, 'warning');
                        return;
                    }
                    show_message('系统错误', 'error');
                }
            });
        }
        function show_more() {
            $('.more').css('display', 'block');
            $('#a_more').hide();
            $('#a_hide').show();
            setHeight(160);
        }
        function hide_more() {
            $('.more').css('display', 'none');
            $('#a_more').show();
            $('#a_hide').hide();
            setHeight(80);
        }
        function setHeight(num) {
            var c = $("#easyui_layout");
            var p = c.layout('panel', 'north');  //get the north panel
            var oldHeight = p.panel('panel').outerHeight(); //获得north panel 的原高度
            p.panel('resize', { height: num }); //设置north panel 新高度
            var newHeight = p.panel('panel').outerHeight();
            c.layout('resize', { height: c.height() + newHeight - oldHeight });  //重新设置整个布局的高度
        }
    </script>
    <link href="../styles/maintab.css?t=<%=base.getToken() %>" rel="stylesheet" />
    <style>
        .search_box {
            width: 100%;
        }

            .search_box div {
                padding: 5px 0;
                min-width: 100px;
                margin: 5px 20px 0 0;
                float: left;
            }

                .search_box div input, .search_box div select {
                    width: 200px;
                }

        .more {
            display: none;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <form runat="server">
        <div id="easyui_layout" class="easyui-layout" fit="true">
            <div data-options="region:'north',onCollapse:onNorthCollapse,onExpand:onNorthonExpand" title="" style="height: 80px; padding: 5px 10px;">
                <div class="search_box">
                    <div class="first">
                        订单编号
                            <input type="text" class="easyui-textbox" id="tdOrderNumber" style="width: 150px; height:28px;" />
                    </div>
                    <div>
                        订单状态
                            <select class="easyui-combobox" id="tdOrderStatus" data-options="editable:false" style="width: 100px; height:28px;">
                                <option value="">全部</option>
                                <option value="1">等待买家付款</option>
                                <option value="5">等待发货</option>
                                <option value="2">已发货</option>
                                <option value="6">退款中</option>
                                <option value="11">需要评价</option>
                                <option value="3">成功的订单</option>
                                <option value="4">关闭的订单</option>
                            </select>
                    </div>
                    <div>
                        订单类型
                            <select class="easyui-combobox" id="tdOrderType" data-options="editable:false" style="width: 100px; height:28px;">
                                <option value="">全部</option>
                                <option value="1">购买商品</option>
                                <option value="3">拼团</option>
                                <option value="4">抢购</option>
                                <option value="2">积分兑换</option>
                                <option value="10">物业缴费</option>
                                <option value="11">分享订单</option>
                            </select>
                    </div>
                    <div>
                        评价状态
                            <select class="easyui-combobox" id="tdRateStatus" data-options="editable:false" style="width: 100px; height:28px;">
                                <option value="">全部</option>
                                <option value="1">已评价</option>
                                <option value="2">未评价</option>
                            </select>
                    </div>
                    <div class="more">
                        商品名称
                            <input type="text" class="easyui-textbox" id="tdProductName" />
                    </div>
                    <div class="more">
                        商家名称
                            <input type="text" class="easyui-textbox" id="tdBusinessName" />
                    </div>
                    <div class="more">
                        买家昵称
                            <input type="text" class="easyui-textbox" id="tdBuyerNickName" />
                    </div>
                    <div class="more">
                        买家电话
                            <input type="text" class="easyui-textbox" id="tdBuyerPhoneNumber" />
                    </div>
                    <div class="more">
                        物流服务
                            <input type="text" class="easyui-combobox" id="tdShipCompany" />
                    </div>
                    <div class="more" style="width: 600px;">
                        成交时间
                            <input type="text" class="easyui-datebox" id="tdPayStartTime" />
                        -
                            <input type="text" class="easyui-datebox" id="tdPayEndTime" />
                    </div>
                    <div class="more">
                        所属小区
                            <input type="text" class="easyui-combobox" id="tdProjectID" data-options="editable:false" />
                    </div>
                </div>
                <div style="clear: both"></div>
                <div style="text-align: center;">
                    <a href="javascript:void(0)" id="a_more" onclick="show_more()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-more'">更多条件</a>
                    <a href="javascript:void(0)" id="a_hide" style="display: none;" onclick="hide_more()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-more'">隐藏条件</a>
                    <a href="javascript:void(0)" onclick="SearchTT()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-search'">搜索</a>
                    <a href="javascript:void(0)" onclick="DoReset()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-reset'">重置</a>
                </div>
            </div>
            <div data-options="region:'center'" title="">
                <div class="easyui-layout" fit="true">
                    <div data-options="region:'north'" style="height: 40px; padding: 0;">
                        <ul class="top-bar">
                            <li id="li_0" class="act-item active" onclick="open_sub(this,'近三个月订单', 'OrderMgr.aspx?status=0')">
                                <a href="javascript:void(0);">近三个月订单</a></li>
                            <li id="li_1" class="act-item" onclick="open_sub(this,'等待买家付款', 'OrderMgr.aspx?status=1')">
                                <a href="javascript:void(0);">等待买家付款</a></li>
                            <li id="li_5" class="act-item" onclick="open_sub(this,'等待发货', 'OrderMgr.aspx?status=5')">
                                <a href="javascript:void(0);">等待发货</a></li>
                            <li id="li_2" class="act-item" onclick="open_sub(this,'已发货', 'OrderMgr.aspx?status=2')">
                                <a href="javascript:void(0);">已发货</a></li>
                            <li id="li_7" class="act-item" onclick="open_sub(this,'退款中', 'OrderMgr.aspx?status=6')">
                                <a href="javascript:void(0);">退款中</a></li>
                            <li id="li_7" class="act-item" onclick="open_sub(this,'需要评价', 'OrderMgr.aspx?status=11')">
                                <a href="javascript:void(0);">需要评价</a></li>
                            <li id="li_3" class="act-item" onclick="open_sub(this,'成功的订单', 'OrderMgr.aspx?status=3')">
                                <a href="javascript:void(0);">成功的订单</a></li>
                            <li id="li_4" class="act-item" onclick="open_sub(this,'关闭的订单', 'OrderMgr.aspx?status=4')">
                                <a href="javascript:void(0);">关闭的订单</a></li>
                            <li id="li_4" class="act-item" onclick="open_sub(this,'三个月前的订单', 'OrderMgr.aspx?status=12')">
                                <a href="javascript:void(0);">三个月前的订单</a></li>
                            <%--<li id="li_7" class="act-item" onclick="open_sub(this,'已退款', 'OrderMgr.aspx?status=7')">
                        <a href="javascript:void(0);">已退款</a></li>--%>
                        </ul>
                    </div>
                    <div data-options="region:'center'">
                        <iframe id="ProductFrame" name="ProductFrame" style="position: absolute; top: 0; left: 0; right: 0; bottom: 0; width: 100%; height: 100%; border: none;" src="OrderMgr.aspx?status=0"></iframe>
                    </div>
                </div>
            </div>
        </div>
    </form>
</asp:Content>
