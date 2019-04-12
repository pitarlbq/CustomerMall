<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="EditRoomBasicAreaColumns.aspx.cs" Inherits="Web.SysSeting.EditRoomBasicAreaColumns" %>

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
                    $.each(data.exist_list, function (index, item) {
                        var html = '';
                        html += '<div class="exist_field" id="field_' + item.ID + '">';
                        html += '<label class="exist_field_label">';
                        html += item.OriFieldName + ":";
                        html += '</label>';
                        html += '<input type="text" data-id="' + item.ID + '" id="old_' + item.ID + '" value="' + item.FieldName + '">';
                        html += '</div>';
                        $(html).appendTo('#oldfiled');
                        count = item.ID;
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
                        show_message('保存成功', 'success', function () {
                            parent.$("#winadd").window('close');
                        });
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
            background-color: #fff;
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
            border: solid 1px #f0f0f0;
            width: 49%;
            display: inline-table;
        }

            .exist_field .exist_field_label {
                text-align: right;
                width: 30%;
                display: inline-table;
                margin-right:10px;
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
            width: 50%;
            height: 30px;
            border-radius: 5px !important;
            border: 1px #ddd solid;
        }

        .add .title, .exist .title {
            text-align: center;
            padding: 5px 0;
            color: #000;
            background-color: #f0f0f0;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <form id="ff" runat="server">
        <div class="table_title">
            <a href="javascript:void(0)" onclick="do_save()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-save'">保存</a>
        </div>
        <div class="exist" id="oldfiled">
        </div>
    </form>
</asp:Content>
