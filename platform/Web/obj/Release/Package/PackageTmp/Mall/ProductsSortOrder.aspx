<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="ProductsSortOrder.aspx.cs" Inherits="Web.Mall.ProductsSortOrder" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../js/vue.js"></script>
    <script>
        var content = null, type = 0;
        $(function () {
            type = "<%=this.type%>";
            content_reset();
        })
        function content_reset() {
            content = new Vue({
                el: '#fieldcontent',
                data: {
                    list: [],
                },
                methods: {
                    getdata: function () {
                        var that = this;
                        var options = { visit: 'getmallproductyouxuanlist', type: type };
                        $.ajax({
                            type: 'POST',
                            dataType: 'json',
                            url: '../Handler/MallHandler.ashx',
                            data: options,
                            success: function (data) {
                                if (data.status) {
                                    that.list = data.list;
                                    return;
                                }
                                show_message('系统错误', 'error');
                            }
                        });
                    }
                }
            });
            content.getdata();
        }
        function do_save() {
            var options = { visit: 'savemallproductyouxuan', list: JSON.stringify(content.list), type: type };
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/MallHandler.ashx',
                data: options,
                success: function (data) {
                    if (data.status) {
                        show_message('保存成功', 'success', function () {
                            parent.$('#winadd').window('close');
                        })
                        return;
                    }
                    show_message('系统错误', 'error');
                }
            });
        }
        function do_close() {
            parent.do_close_dialog(function () {
                parent.$('#tt_table').datagrid('reload');
            });
        }
    </script>
    <style>
        .panel-body {
            background: #f0f0f0;
        }

        table.info {
            width: 96%;
            border: solid 1px #ccc;
            border-spacing: 0;
            border-collapse: collapse;
            margin: 0 auto;
            background: #fff;
        }

            table.info td {
                border: solid 1px #ccc;
                padding: 10px;
                text-align: center;
            }

        input[type=text] {
            width: 100px;
            border-radius: 5px !important;
            height: 25px;
            line-height: 25px;
            text-align: center;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <form id="ff" runat="server" method="post" enctype="multipart/form-data">
        <div class="operation_box">
            <a href="javascript:void(0)" onclick="do_save()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-save'">保存</a>
            <a href="javascript:void(0)" onclick="do_close()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-close'">关闭</a>
        </div>
        <div class="table_container">
            <div id="fieldcontent">
                <table class="info">
                    <tr>
                        <td>商品名称
                        </td>
                        <td>商品单价
                        </td>
                        <td>排序序号
                        </td>
                    </tr>
                    <tr v-for="(item, index) in list">
                        <td>{{item.title}}
                        </td>
                        <td>{{item.price}}
                        </td>
                        <td>
                            <input type="text" v-model="item.sortorder" />
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </form>
</asp:Content>
