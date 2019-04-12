﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="DefineFieldSetUp.aspx.cs" Inherits="Web.SysSeting.DefineFieldSetUp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        var count = 0;
        var TableName = "";
        $(function () {
            TableName = "<%=Request.QueryString["TableName"]%>";
            getDefineFields();
        });
        function getDefineFields() {
            var options = { visit: 'getdefinefield', TableName: TableName };
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/SysSettingHandler.ashx',
                data: options,
                success: function (data) {
                    if (!data.status) {
                        show_message("获取列表失败", "info");
                        return;
                    }
                    if (data.list.length == 0) {
                        addRow();
                        return;
                    }
                    $.each(data.list, function (index, item) {
                        var html = '';
                        html += '<div class="field" id="field_' + item.ID + '">';
                        html += '<input type="text" data-id="' + item.ID + '" id="old_' + item.ID + '" value="' + item.FieldName + '">';
                        html += '<a href="javascript:void(0)" onclick="deleteField(\'old_' + item.ID + '\')" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:\'icon-remove\'">删除</a>';
                        html += '</div>';
                        $(html).appendTo('#tablefiled');
                        count = item.ID;
                        $.parser.parse('#tablefiled');
                    })
                }
            });
        }

        function do_save() {
            if ($("input[type='text']").length == 0) {
                show_message("请添加字段", "info");
                return;
            }
            var IDList = [];
            var List = [];
            $("input[type='text']").each(function () {
                var data_id = $(this).attr('data-id');
                var data_value = $(this).val();
                if (data_value == '') {
                    return true;
                }
                List.push({ id: data_id, value: data_value });
            });
            if (List.length == 0) {
                show_message("字段名称不能为空", "info");
                return;
            }
            var options = { visit: 'savedefinefield', list: JSON.stringify(List), TableName: TableName };
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/SysSettingHandler.ashx',
                data: options,
                success: function (message) {
                    if (message.status) {
                        show_message('保存成功', 'success');
                    }
                    else {
                        show_message('系统错误', 'error');
                    }
                }
            });
        }
        function closeWin() {
            parent.$("#winadd").window("close");
        }
        function do_add() {
            count++;
            var html = '';
            html += '<div class="field" id="field_' + count + '">';
            html += '<input type="text" data-id="0" data-count="' + count + '" id="new_' + count + '" value="">';
            html += '<a href="javascript:void(0)" onclick="deleteField(\'new_' + count + '\')" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:\'icon-remove\'">删除</a>';
            html += '</div>';
            $(html).appendTo('#tablefiled');
            $.parser.parse('#field_' + count);
        }
        function deleteField(id) {
            id = id.trim();
            var data_id = $("#" + id).attr('data-id');
            if (data_id > 0) {
                top.$.messager.confirm('提示', '确认删除', function (r) {
                    if (r) {
                        var options = { visit: 'removedefinefield', ID: data_id, TableName: TableName };
                        $.ajax({
                            type: 'POST',
                            dataType: 'json',
                            url: '../Handler/SysSettingHandler.ashx',
                            data: options,
                            success: function (message) {
                                if (message.status) {
                                    show_message('删除成功', 'success', function () {
                                        $('#field_' + data_id).remove();
                                    });
                                }
                                else if (message.msg) {
                                    show_message(message.msg, "warning");
                                } else {
                                    show_message('系统错误', 'error');
                                }
                            }
                        });
                    }
                })
                return;
            }
            var data_count = $("#" + id).attr('data-count');
            $('#field_' + data_count).remove();
        }
    </script>
    <style type="text/css">
        .panel-body {
            background: #f0f0f0;
        }

        .add, .exist {
            width: 96%;
            margin: 0 auto;
            margin-top: 10px;
            border-collapse: collapse;
            border-spacing: 0px;
            border: solid 0px #f0f0f0;
            background: #fff;
        }

        .field {
            padding: 3px 5px;
            text-align: left;
            border-right: solid 1px #f0f0f0;
            border-bottom: solid 1px #f0f0f0;
            width: 33%;
            display: inline-table;
        }

        .exist_field {
            padding: 3px 5px;
            text-align: left;
            border: solid 1px #ddd;
            width: 50%;
            display: inline-table;
        }

            .exist_field .exist_field_label {
                text-align: right;
                width: 30%;
                display: inline-table;
                padding-right: 10px;
            }

            .exist_field input {
                text-align: left;
                width: 70%;
                display: inline-table;
                padding-left: 10px;
                border: 0;
                border-left: 1px #ddd solid;
            }

        input[type=text] {
            height: 30px;
            border-radius: 5px !important;
            border: 1px #ddd solid;
        }

        .add .title, .exist .title {
            text-align: center;
            padding: 5px 0;
            color: #000;
            background-color: #ccc;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <form id="ff" runat="server">
        <div class="table_title">
            自定义参数
             <a href="javascript:void(0)" onclick="do_add()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-add'">新增</a>
            <a href="javascript:void(0)" onclick="do_save()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-save'">保存</a>
        </div>
        <div class="add" id="tablefiled">
        </div>
    </form>
</asp:Content>
