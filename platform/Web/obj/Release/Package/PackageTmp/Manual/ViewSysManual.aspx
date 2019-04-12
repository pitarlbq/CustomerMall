<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="ViewSysManual.aspx.cs" Inherits="Web.Manual.ViewSysManual" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>在线使用手册</title>
    <script src="../js/vue.js"></script>
    <script>
        var content;
        $(function () {
            content = new Vue({
                el: '#fieldcontent',
                data: {
                    categorylist: []
                },
                methods: {
                    getdata: function () {
                        var that = this;
                        var options = { visit: 'getsysmenucategorylist' };
                        $.ajax({
                            type: 'POST',
                            dataType: 'json',
                            url: '../Handler/SysSettingHandler.ashx',
                            data: options,
                            success: function (data) {
                                if (data.status) {
                                    that.categorylist = data.list;
                                    return;
                                }
                                show_message('系统错误', 'error');
                            }
                        });
                    },
                    viewdescription: function (item) {
                        var that = this;
                        var iframe = "<iframe id='myFrame' scrolling='auto' frameborder='0' src='../Manual/ViewSysManualPage.aspx?ManualID=" + item.ManualID + "' style='width:100%;height:" + ($(window).height() - 40) + "px'></iframe>";
                        $("<div id='winviewpage'></div>").appendTo("body").window({
                            title: '查看' + item.Title,
                            width: ($(window).width()) - 200,
                            height: $(window).height(),
                            top: 0,
                            left: 100,
                            modal: true,
                            minimizable: false,
                            maximizable: false,
                            collapsible: false,
                            content: iframe,
                            onClose: function () {
                                parent.$("#winviewpage").remove();
                            }
                        })
                    }
                }
            });
            content.getdata();
        });
    </script>
    <style>
        .mainbox {
            float: left;
            width: 30%;
            margin-left: 3%;
            margin-top: 10px;
            font-family: 'Microsoft YaHei';
        }

        .categorytitle {
            font-size: 13px;
            font-weight: bold;
            color: #0094ff;
            cursor: pointer;
            line-height: 20px;
            padding: 10px 0;
        }

        .manualtitle {
            font-size: 12px;
            color: #0094ff;
            cursor: pointer;
            line-height: 20px;
            padding-bottom: 5px;
        }

            .manualtitle:hover {
                text-decoration: underline;
            }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <div id="fieldcontent">
        <div class="mainbox" v-for="item in categorylist">
            <div class="categorytitle">{{item.CategoryName}}</div>
            <div v-on:click="viewdescription(item2)" class="manualtitle" v-for="item2 in item.mymanuals">{{item2.Title}}</div>
        </div>
    </div>
</asp:Content>
