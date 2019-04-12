<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="ProductViewPinDetail.aspx.cs" Inherits="Web.Mall.ProductViewPinDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../js/vue.js"></script>
    <script type="text/javascript">
        var ProductID, content;
        $(function () {
            ProductID = "<%=this.ProductID%>";
            content = new Vue({
                el: '#fieldcontent',
                data: {
                    list: [],
                },
                methods: {
                    getdata: function () {
                        if (ProductID <= 0) {
                            return;
                        }
                        var that = this;
                        var options = { visit: 'getmallproductpinuserlist', ProductID: ProductID };
                        $.ajax({
                            type: 'POST',
                            dataType: 'json',
                            url: '../Handler/MallHandler.ashx',
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
                    do_all_checked: function (item) {
                        var that = this;
                        item.ischecked = !item.ischecked;
                        $.each(item.list, function (index, current) {
                            current.ischecked = item.ischecked;
                        })
                    },
                    do_checked: function (item, parentitem) {
                        var that = this;
                        item.ischecked = !item.ischecked;
                        var all_check = true;
                        $.each(parentitem.list, function (index, current) {
                            if (!current.ischecked) {
                                all_check = false;
                                return false;
                            }
                        })
                        parentitem.ischecked = all_check;
                    },
                    do_close: function (item) {
                        var that = this;
                        var list = [];
                        var is_closed = false;
                        $.each(item.list, function (index, current) {
                            if (current.Status == 4) {
                                is_closed = true;
                                return false;
                            }
                            if (current.ischecked) {
                                list.push(current);
                            }
                        })
                        if (is_closed) {
                            show_message('选中的买家已关闭', 'info');
                            return;
                        }
                        if (list.length == 0) {
                            show_message('请先选择需要关闭的买家', 'info');
                            return;
                        }
                        top.$.messager.confirm('提示', '确认关闭?', function (r) {
                            if (r) {
                                var options = { visit: 'closemallpinuser', ID: item.ID, list: JSON.stringify(list) };
                                $.ajax({
                                    type: 'POST',
                                    dataType: 'json',
                                    url: '../Handler/MallHandler.ashx',
                                    data: options,
                                    success: function (data) {
                                        if (data.status) {
                                            that.getdata();
                                            return;
                                        }
                                        if (data.error) {
                                            show_message(data.error, "info");
                                            return;
                                        }
                                        show_message('系统错误', 'error');
                                    }
                                });
                            }
                        })
                    },
                    do_createorder: function (item) {
                        var that = this;
                        var that = this;
                        var list = [];
                        $.each(item.list, function (index, current) {
                            if (current.ischecked) {
                                list.push(current);
                            }
                        })
                        if (item.Status == 4) {
                            show_message('该拼团已关闭', 'info');
                            return;
                        }
                        if (item.Status == 4) {
                            show_message('该拼团已关闭', 'info');
                            return;
                        }
                        top.$.messager.confirm('提示', '确认生成订单?', function (r) {
                            if (r) {
                                var options = { visit: 'createmallpinorder', ProductID: ProductID, ID: item.ID };
                                $.ajax({
                                    type: 'POST',
                                    dataType: 'json',
                                    url: '../Handler/MallHandler.ashx',
                                    data: options,
                                    success: function (data) {
                                        if (data.status) {
                                            show_message("订单生成成功", "info");
                                            that.getdata();
                                            return;
                                        }
                                        if (data.error) {
                                            show_message(data.error, "info");
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
        })
        function do_close() {
            parent.do_close_dialog(function () {
                parent.$('#tt_table').datagrid('reload');
            });
        }
    </script>
    <style>
        table.field td.header_title {
            text-align: left;
            background-color: #0094ff;
            color: #fff;
            font-size: 14px;
        }

        .header_title label {
            margin-right: 10px;
        }

        table.field {
            width: 100%;
            border: solid 1px #ccc;
            border-spacing: 0;
            border-collapse: collapse;
        }

            table.field td {
                border: solid 1px #ccc;
                padding: 10px;
                text-align: left;
            }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <form id="ff" runat="server" method="post" enctype="multipart/form-data">
        <div class="operation_box">
            <a href="javascript:void(0)" onclick="do_close()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-close'">关闭</a>
        </div>
        <div class="table_container">
            <div id="fieldcontent">
                <table class="field" v-for="item in list">
                    <tr>
                        <td colspan="7" class="header_title">
                            <label>{{item.AddTime}}</label>
                            <label>状态: {{item.StatusDesc}}</label>
                            <label>已参团 {{item.JoinCount}}人</label>
                            <label>还差 {{item.LeftCount}}人拼成</label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="7" style="padding: 0;">
                            <label v-on:click="do_close(item)">
                                <a href="javascript:void(0)" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-guanbi_2'">提前关闭</a>
                            </label>
                            <label v-on:click="do_createorder(item)">
                                <a href="javascript:void(0)" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-add'">生成订单</a>
                            </label>
                        </td>
                    </tr>
                    <tr>
                        <td v-on:click="do_all_checked(item)">
                            <input type="checkbox" v-bind:checked="item.ischecked" /></td>
                        <td>买家昵称
                        </td>
                        <td>买家电话
                        </td>
                        <td>参与时间
                        </td>
                        <td>购买数量
                        </td>
                        <td>规格属性
                        </td>
                        <td>状态
                        </td>
                    </tr>
                    <tr v-for="item2 in item.list">
                        <td v-on:click="do_checked(item2,item)">
                            <input type="checkbox" v-bind:checked="item2.ischecked" /></td>
                        <td>{{item2.NickName}}
                        </td>
                        <td>{{item2.PhoneNumber}}
                        </td>
                        <td>{{item2.AddTime}}
                        </td>
                        <td>{{item2.Quantity}}
                        </td>
                        <td>{{item2.VariantName}}
                        </td>
                        <td>{{item2.StatusDesc}}
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </form>
</asp:Content>
