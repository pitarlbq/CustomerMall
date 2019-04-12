<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="SysmsgList.aspx.cs" Inherits="Web.SysSeting.SysmsgList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../styles/aui.css" rel="stylesheet" />
    <style>
        .aui-timeline .aui-timeline-item-header {
            font-size: 14px;
        }

        .aui-timeline .aui-timeline-item-inner {
            margin-left: 5rem;
        }

        .aui-timeline .aui-timeline-item-label {
            width: 4rem;
            font-size: 13px;
            color: #fff;
        }

        .aui-card-list-header {
            font-size: 13px;
            padding-top: 0;
            padding-bottom: 0.2rem;
        }

        .aui-content {
            padding-top: 20px;
        }
    </style>
    <script>
        var GetContextPath;
        $(function () {
            GetContextPath = "<%=base.GetContextPath() %>";
        })
    </script>
    <script src="../js/vue.js"></script>
    <script>
        var content;
        $(function () {
            content = new Vue({
                el: '#fieldcontent',
                data: {
                    list: [],
                },
                methods: {
                    getdata: function () {
                        var that = this;
                        MaskUtil.mask();
                        var options = { visit: 'getmysysmsglist' };
                        $.ajax({
                            type: 'POST',
                            dataType: 'json',
                            url: '../Handler/SettingHandler.ashx',
                            data: options,
                            success: function (data) {
                                MaskUtil.unmask();
                                if (data.status) {
                                    that.list = data.list;
                                    return;
                                }
                                show_message('系统错误', 'error');
                            }
                        });
                    },
                    do_show: function (item) {
                        var that = this;
                        if (item.IsReading) {
                            if (item.showsummary) {
                                item.showsummary = false;
                                item.showtext = '查看';
                            }
                            else {
                                item.showsummary = true;
                                item.showtext = '隐藏';
                            }
                            return;
                        }
                        var options = { visit: 'savemsgreadstatus', ID: item.ID };
                        $.ajax({
                            type: 'POST',
                            dataType: 'json',
                            url: '../Handler/SettingHandler.ashx',
                            data: options,
                            success: function (data) {
                                item.IsReading = true;
                                parent.parent.CheckSystemStatus();
                                if (item.showsummary) {
                                    item.showsummary = false;
                                    item.showtext = '查看';
                                }
                                else {
                                    item.showsummary = true;
                                    item.showtext = '隐藏';
                                }
                            }
                        });
                    }
                }
            });
            content.getdata();
        })
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <div id="fieldcontent">
        <section class="aui-content" v-if="list.length>0">
            <div class="aui-timeline">
                <%--<div class="aui-timeline-item-header">2017年1月8日</div>--%>
                <div class="aui-timeline-item" v-for="item in list">
                    <div class="aui-timeline-item-label aui-bg-info text-light">{{item.AddTime}}</div>
                    <div class="aui-timeline-item-inner">
                        <div class="aui-card-list">
                            <div class="aui-card-list-header aui-border-b" style="cursor: pointer;" v-on:click="do_show(item)">
                                <div>
                                    {{item.Title}}
                                    <img v-if="!item.IsReading" id="note_img" src="../styles/images/point.png" style="width: 10px; position: absolute; top: 15px; left: 5px;" />
                                </div>
                                <label>{{item.showtext}}</label>
                            </div>
                            <div class="aui-card-list-content-padded" v-if="item.showsummary">
                                <label v-html="item.ContentSummary"></label>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </section>
        <div v-if="list.length==0" style="text-align: center; margin-top: 50px;">暂无系统消息</div>
    </div>
</asp:Content>
