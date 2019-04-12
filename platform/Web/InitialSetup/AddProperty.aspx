﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="AddProperty.aspx.cs" Inherits="Web.InitialSetup.AddProperty" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $(function () {
            parent.returnvalue = "";
        })
        function insert() {
            var totallines = $("#yttable tr").length;
            $("table#yttable tr:last label:first").html("");
            $("table#yttable tr:last label:last").html("");
            var tablehtml = '<tr id="tr_' + (totallines + 1) + '">';
            tablehtml += '<td>';
            tablehtml += (totallines + 1) + '级名称:';
            tablehtml += '</td>';
            tablehtml += '<td>';
            tablehtml += '<input name="gradename" id="' + (totallines + 1) + '_grade" class="easyui-textbox" type="text" style="width: 80%" />';
            tablehtml += '</td>';
            tablehtml += '<td>';
            tablehtml += '<label name="labremove"><a href="javascript:void(0)" onclick="remove()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:\'icon-remove\'">移除</a></label>';
            tablehtml += '</td>';
            tablehtml += '<td>';
            tablehtml += '<label name="labinsert"><a href="javascript:void(0)" onclick="insert()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:\'icon-add\'">添加</a></label>';
            tablehtml += '</td>';
            tablehtml += '</tr>';
            $("table#yttable").append(tablehtml);
            $.parser.parse();
        }
        function remove() {
            var totallines = $("#yttable tr").length;
            if (totallines == 1) {
                return;
            }
            $("table#yttable tr:last").remove();
            if (totallines == 2) {
                $("table#yttable tr:last label:first").html('');
            }
            else {
                $("table#yttable tr:last label:first").html('<a href="javascript:void(0)" onclick="remove()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:\'icon-remove\'">移除</a>');
            }
            $("table#yttable tr:last label:last").html('<a href="javascript:void(0)" onclick="insert()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:\'icon-add\'">添加</a>');
            $.parser.parse();
        }
        function do_save() {
            $('#ff').form('submit', {
                onSubmit: function () {
                    var bool = $(this).form('enableValidation').form('validate');
                    if (!bool) {
                        return $(this).form('enableValidation').form('validate');
                    }
                    setreturnvalue();
                    show_message('添加成功', 'success', function () {
                        do_close();
                    });
                }
            });

        }
        function do_close() {
            parent.$("#win_pro").window("close");
        }
        function setreturnvalue() {
            parent.returnvalue = "";
            var arry = [];
            var poststr = []
            var title = "";
            var inputs = document.getElementsByName("gradename");
            $.each(inputs, function (i, id) {
                var value = $(id).val();
                if (value == "") {
                    return true;
                }
                if (i == 0) {
                    title = value;
                }
                arry.push({ Name: value });
                poststr.push(value);
            });
            if (poststr.length > 0) {
                var options = { visit: 'addproperty', ProjectID: "<%=Request.QueryString["ProjectID"]%>", strjson: JSON.stringify(poststr) };
                $.ajax({
                    type: 'POST',
                    dataType: 'html',
                    url: '../Handler/ProjectPropertyHandler.ashx',
                    data: options,
                    success: function (message) {

                    }
                });
                var final = { title: title, list: arry };
                parent.returnvalue = JSON.stringify(final);
            }
            return;
        }
    </script>
    <style type="text/css">
        form {
            margin: 0 auto;
        }

        .panel-body {
            background: #f0f0f0;
        }

        table.yttable {
            margin: 0 auto;
            width: 100%;
            border-collapse: collapse;
            text-align: center;
        }

            table.yttable td {
                border: solid 1px #ccc;
                padding: 5px 0 5px 5px;
                text-align: left;
            }

        .savebox {
            margin: 0 auto;
            width: 400px;
            text-align: right;
            padding: 10px 0;
        }

            .savebox a {
                margin-left: 10px;
            }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <form id="ff" class="easyui-form" method="post" data-options="novalidate:true">
        <div class="operation_box">
            <a href="javascript:void(0)" onclick="do_save()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-save'">保存</a>
            <a href="javascript:void(0)" onclick="do_close()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-close'">关闭</a>
        </div>
        <div class="table_container">
            <table id="yttable" class="info firsttab">
                <tr>
                    <td style="width: 10%;">1级名称:</td>
                    <td style="width: 50%;">
                        <input id="1_grade" class="easyui-textbox" type="text" name="gradename" data-options="required:true" style="width: 80%" /></td>
                    <td style="width: 15%;">
                        <label></label>
                    </td>
                    <td style="width: 15%;">
                        <label>
                            <a href="javascript:void(0)" onclick="insert()" class="easyui-linkbutton btlinkbar" data-options="plain:true,iconCls:'icon-add'">添加</a>
                        </label>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</asp:Content>
