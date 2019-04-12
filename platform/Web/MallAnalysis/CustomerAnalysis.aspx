<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="CustomerAnalysis.aspx.cs" Inherits="Web.MallAnalysis.CustomerAnalysis" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .search_item {
            display: inline-table;
            margin-right: 20px;
            line-height: 50px;
        }

            .search_item label {
                border: solid 1px #ddd;
                background: #fff;
                padding: 5px 20px;
                border-radius: 10px;
                margin-left: 10px;
                cursor: pointer;
                font-size: 12px;
                line-height: 30px;
            }

                .search_item label.active {
                    background: #b7b7b7;
                }

        .customer_container, .customer_grid {
            background: #fff;
            width: 96%;
            margin: 0 auto;
            border-radius: 5px;
            margin-top: 20px;
        }

        .customer_item {
            display: inline-table;
            width: 33%;
            text-align: center;
            padding: 30px 0;
        }

            .customer_item .title {
                line-height: 30px;
                font-size: 25px;
            }

            .customer_item .count {
                margin-top: 10px;
                line-height: 30px;
                font-size: 20px;
            }

        .customer_list_item {
            margin: 30px 0;
            display: inline-table;
            width: 33%;
            min-height: 50px;
        }

        .list_img {
            display: inline-block;
            vertical-align: middle;
            margin: 0 30px;
        }

        .list_text {
            display: inline-table;
            vertical-align: middle;
            font-size: 18px;
        }

            .list_text span {
                color: #ff0000;
            }

        .l-btn-left {
            margin-top: 10px;
        }

        [v-cloak] {
            display: none;
        }

        .highchat_box {
            margin: 0 auto;
            width: 96%;
            margin-top: 30px;
            border-radius: 5px;
            background: #fff;
        }
    </style>
    <script src="../js/vue.js"></script>
    <script src="../js/highchart/highcharts.js"></script>
    <script src="../js/highchart/modules/series-label.js"></script>
    <script src="../js/highchart/modules/exporting.js"></script>
    <script src="../js/highchart/modules/export-data.js"></script>
    <script>
        var timeValue = 1, content;
        $(function () {
            set_time_value();
            load_vue();
            search_bar_click();
            load_highchart();
        })
        function search_bar_click() {
            var elems = $('.search_item label');
            $('.search_item label').bind('click', function () {
                var that = this;
                timeValue = $(that).attr('data-value');
                $.each(elems, function (index, elem) {
                    var my_value = $(elem).attr('data-value');
                    if (my_value == timeValue) {
                        $(elem).addClass('active');
                    }
                    else {
                        $(elem).removeClass('active');
                    }
                })
                set_time_value();
                do_search();
            })
        }
        function set_time_value() {
            var start = '';
            var end = '';
            var mydate = new Date();
            //获取今天
            var nowDate = new Date(); //当天日期
            //今天是本周的第几天
            var nowDayOfWeek = nowDate.getDay();
            //当前日
            var nowDay = nowDate.getDate();
            //当前月
            var nowMonth = nowDate.getMonth();
            //当前年
            var nowYear = nowDate.getFullYear();
            if (timeValue == 1) {
                start = end = setdatebox(mydate);
            }
            else if (timeValue == 2) {
                var getWeekStartDate = new Date(nowYear, nowMonth, nowDay - nowDayOfWeek + 1);
                start = setdatebox(getWeekStartDate);
                //获得本周的结束日期
                var getWeekEndDate = new Date(nowYear, nowMonth, nowDay + (7 - nowDayOfWeek));
                end = setdatebox(getWeekEndDate);
            }
            else if (timeValue == 3) {
                //获得本月的开始日期
                var getMonthStartDate = new Date(nowYear, nowMonth, 1);
                start = setdatebox(getMonthStartDate);
                //获得本月的结束日期
                var getMonthEndDate = new Date(nowYear, (nowMonth + 1), 1);
                getMonthEndDate.setTime(getMonthEndDate.getTime() - 24 * 60 * 60 * 1000);
                end = setdatebox(getMonthEndDate);
            }
            $('#tdStartTime').datebox('setValue', start);
            $('#tdEndTime').datebox('setValue', end);
        }
        function setdatebox(mydate) {
            var str = "" + mydate.getFullYear() + "-";
            str += (mydate.getMonth() + 1) + "-";
            str += mydate.getDate();
            return str;
        }
        function do_search() {
            setTimeout(function () {
                content.getdata();
            }, 200);
        }
        function load_vue() {
            content = new Vue({
                el: '#fieldcontent',
                data: {
                    form: {
                        customer_total_count: '0人',
                        customer_return_percent: '0.00%',
                        customer_unitprice: '￥0.00',
                        customer_maybe_count: '0人',
                        customer_new_count: '0人',
                        customer_return_count: '0人',
                    },
                    x_array: [],
                    y_array: []
                },
                methods: {
                    getdata: function (item) {
                        var that = this;
                        var StartTime = $('#tdStartTime').datebox('getValue');
                        var EndTime = $('#tdEndTime').datebox('getValue');
                        var options = { visit: 'getmallcustomeranalysis', StartTime: StartTime, EndTime: EndTime };
                        MaskUtil.mask();
                        $.ajax({
                            type: 'POST',
                            dataType: 'json',
                            url: '../Handler/AnalysisHandler.ashx',
                            data: options,
                            success: function (data) {
                                MaskUtil.unmask();
                                if (data.status) {
                                    that.form = data.form;
                                    that.x_array = data.x_array;
                                    that.y_array = data.y_array;
                                    load_highchart();
                                }
                            }
                        });
                    }
                }
            });
            do_search();
        }
        function load_highchart() {
            Highcharts.chart('container', {
                title: {
                    text: '注册客户总数'
                },
                chart: {
                    type: 'column'
                },
                yAxis: {
                    title: {
                        text: '数量(个)'
                    }
                },
                plotOptions: {
                    column: {
                        dataLabels: {
                            enabled: true,
                            allowOverlap: true // 允许数据标签重叠
                        }
                    }
                },
                xAxis: {
                    categories: content.x_array
                },
                series: [{
                    name: '注册客户总数',
                    data: content.y_array
                }],

                responsive: {
                    rules: [{
                        condition: {
                            maxWidth: 500
                        },
                        chartOptions: {
                            legend: {
                                layout: 'horizontal',
                                align: 'center',
                                verticalAlign: 'bottom'
                            }
                        }
                    }]
                }
            });
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <div class="easyui-layout" id="my_layout" fit="true">
        <div data-options="region:'north'" style="border: none; height: 50px;">
            <div class="search_item">
                <label class="active" data-value="1">当天</label>
                <label data-value="2">本周</label>
                <label data-value="3">本月</label>
            </div>
            <div class="search_item">
                <input class="easyui-datebox" id="tdStartTime" />
            </div>
            <div class="search_item">
                -
            </div>
            <div class="search_item">
                <input class="easyui-datebox" id="tdEndTime" />
            </div>
            <div class="search_item">
                <a href="javascript:void(0)" onclick="do_search()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-search'">查询</a>
            </div>
        </div>
        <div data-options="region:'center'" title="" style="border: none; background-color: #f3f2f2;">
            <div v-cloak id="fieldcontent">
                <div class="customer_container">
                    <div class="customer_item">
                        <div class="title">客户总数</div>
                        <div class="count">{{form.customer_total_count}}</div>
                    </div>
                    <div class="customer_item">
                        <div class="title">回头率</div>
                        <div class="count">{{form.customer_return_percent}}</div>
                    </div>
                    <div class="customer_item">
                        <div class="title">客单价</div>
                        <div class="count">{{form.customer_unitprice}}</div>
                    </div>
                </div>
                <div class="customer_grid">
                    <div class="customer_list_item">
                        <div class="list_img">
                            <img src="../styles/images/rengou_count_icon.jpg" />
                        </div>
                        <div class="list_text">潜在客户<span>{{form.customer_maybe_count}}</span></div>
                    </div>
                    <div class="customer_list_item">
                        <div class="list_img">
                            <img src="../styles/images/rengou_count_icon.jpg" />
                        </div>
                        <div class="list_text">新增客户<span>{{form.customer_new_count}}</span></div>
                    </div>
                    <div class="customer_list_item">
                        <div class="list_img">
                            <img src="../styles/images/rengou_count_icon.jpg" />
                        </div>
                        <div class="list_text">回头客<span>{{form.customer_return_count}}</span></div>
                    </div>
                </div>
            </div>
            <div class="highchat_box">
                <div id="container"></div>
            </div>
        </div>
    </div>
</asp:Content>
