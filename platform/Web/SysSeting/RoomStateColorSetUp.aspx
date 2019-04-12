<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="RoomStateColorSetUp.aspx.cs" Inherits="Web.SysSeting.RoomStateColorSetUp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../styles/jquery.bigcolorpicker.css?v2" rel="stylesheet" />
    <script src="../js/vue.js"></script>
    <script src="../js/Page/Comm/GetTypeList.js?v=<%=base.getToken() %>"></script>
    <script src="../js/Page/Comm/jquery.bigcolorpicker.js?v1"></script>
    <script>
        var content;
        $(function () {
            content = new Vue({
                el: '#tablefiled',
                data: {
                    RoomStateList: []
                },
                methods: {
                    getdata: function () {
                        var that = this;
                        var options = { visit: 'getroomstate' };
                        $.ajax({
                            type: 'POST',
                            dataType: 'json',
                            url: '../Handler/RoomResourceHandler.ashx',
                            data: options,
                            success: function (result) {
                                if (result.status) {
                                    that.RoomStateList = result.list;
                                    setTimeout(function () {
                                        $("input[name='picker']").bigColorpicker(function (el, color) {
                                            $(el).val(color);
                                            $(el).css('color', color);
                                            var data_id = $(el).attr('data-id');
                                            $.each(that.RoomStateList, function (index, item) {
                                                if (item.ID == data_id) {
                                                    item.BackColor = color;
                                                    return false;
                                                }
                                            })
                                        });
                                    }, 1000);
                                    return;
                                }
                                show_message('系统错误', 'error');
                            }
                        });
                    },
                    savedata: function () {
                        var that = this;
                        var options = { visit: 'saveroomstate', roomstates: JSON.stringify(that.RoomStateList) };
                        $.ajax({
                            type: 'POST',
                            dataType: 'json',
                            url: '../Handler/RoomResourceHandler.ashx',
                            data: options,
                            success: function (result) {
                                if (result.status) {
                                    show_message('保存成功', 'success', function () {
                                        do_close();
                                    });
                                    return;
                                }
                                show_message('系统错误', 'error');
                            }
                        });
                    },
                    closewin: function () {
                        parent.$("#winadd").window("close");
                    }
                }
            });
            content.getdata();
        })
        function do_save() {
            content.savedata();
        }
        function do_close() {
            parent.do_close_dialog(function () {
                parent.content.getdata();
            });
        }
    </script>
    <style type="text/css">
        .panel-body {
            background: #f0f0f0;
        }

        table.add {
            width: 96%;
            margin: 0 auto;
            border-collapse: collapse;
            border-spacing: 0px;
            border: solid 1px #ccc;
            background: #fff;
        }

            table.add td {
                padding: 3px 5px;
                text-align: left;
                border: solid 1px #ccc;
            }

        input {
            width: 50%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <div class="operation_box">
        <a href="javascript:void(0)" onclick="do_save()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-save'">保存</a>
        <a href="javascript:void(0)" onclick="do_close()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-close'">关闭</a>
    </div>
    <div class="table_container">
        <div id="tablefiled">
            <table class="add">
                <tr v-for="item in RoomStateList">
                    <td style="width: 25%">{{item.Name}}</td>
                    <td style="width: 75%">
                        <input name="picker" v-bind:style="{ color: item.BackColor}" v-bind:data-id="item.ID" type="text" v-model="item.BackColor" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
