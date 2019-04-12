<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="BusinessSortOrder.aspx.cs" Inherits="Web.Mall.BusinessSortOrder" %>

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
                        var options = { visit: 'getmallbusinesssortlist', type: type };
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
            var options = { visit: 'savemallbusinesssort', list: JSON.stringify(content.list), type: type };
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/MallHandler.ashx',
                data: options,
                success: function (data) {
                    if (data.status) {
                        show_message('保存成功', 'success', function () {
                            do_close();
                        })
                        return;
                    }
                    show_message('系统错误', 'error');
                }
            });
        }
        function do_close() {
            parent.do_close_dialog(function () {
                parent.$("#tt_table").datagrid("reload");
            }, true);
        }
    </script>
    <style>
        .panel-body {
            background: #f0f0f0;
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
                        <td>商家名称
                        </td>
                        <td>排序序号
                        </td>
                    </tr>
                    <tr v-for="(item, index) in list">
                        <td>{{item.title}}
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
