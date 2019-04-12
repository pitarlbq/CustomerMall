<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="CategoryEdit.aspx.cs" Inherits="Web.Mall.CategoryEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        var ID, ParentID, type, tdTagName, hdTagName;
        $(function () {
            ID = "<%=this.CategoryID%>";
            ParentID = "<%=this.ParentID%>";
            type = "<%=this.type%>";
            tdTagName = $('#<%=this.tdTagName.ClientID%>');
            hdTagName = $('#<%=this.hdTagName.ClientID%>');
            loadattachs();
            loadtagparams();
            if (type == 1) {
                $('.tr_parent_category').show();
            } else {
                $('.tr_parent_category').hide();
            }
        });
        function loadtagparams() {
            var options = { visit: 'getmalltagparams' };
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/MallHandler.ashx',
                data: options,
                success: function (data) {
                    if (data.status) {
                        tdTagName.combobox({
                            editable: false,
                            data: data.list,
                            valueField: 'ID',
                            textField: 'Name',
                            multiple: true,
                            onSelect: function (rec) {
                                var values = tdTagName.combobox('getValues');
                                hdTagName.val(JSON.stringify(values));
                            },
                            onUnselect: function (rec) {
                                var values = tdTagName.combobox('getValues');
                                hdTagName.val(JSON.stringify(values));
                            }
                        });
                        return;
                    }
                }
            });
        }
        function loadattachs() {
            if (ID <= 0) {
                return;
            }
            var options = { visit: 'getmallcategorypic', ID: ID };
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/MallHandler.ashx',
                data: options,
                success: function (data) {
                    var $html = '';
                    $("#trExistFiles").hide();
                    $("#trExistFiles").html($html);
                    if (data.status) {
                        $("#trExistFiles").show();
                        $html += '<td>已上传图片</td>';
                        $html += '<td colspan="3">';
                        $html += '<div class="image_box"><a href="' + data.PicPath + '" target="_blank" ><img src="' + data.PicPath + '"/></a><br/>';
                        $html += '<a href="#" onclick="deleteAttach()">删除</a></div>';
                        $html += '</td>';
                        $("#trExistFiles").append($html);
                    }
                }
            });
        }
        function deleteAttach() {
            top.$.messager.confirm("提示", "是否删除选已上传的图片?", function (r) {
                if (r) {
                    var options = { visit: 'deletemallcategorypic', ID: ID };
                    $.ajax({
                        type: 'POST',
                        dataType: 'json',
                        url: '../Handler/MallHandler.ashx',
                        data: options,
                        success: function (message) {
                            if (message.status) {
                                show_message('操作成功', 'success', function () {
                                    loadattachs();
                                });
                                return;
                            }
                            show_message('系统错误', 'error');
                        }
                    });
                }
            })
        }
        function do_save() {
            var isValid = $("#<%=this.ff.ClientID%>").form('enableValidation').form('validate');
            if (!isValid) {
                return;
            }
            MaskUtil.mask('body', '提交中');
            $('#ff').form('submit', {
                url: '../Handler/MallHandler.ashx',
                onSubmit: function (param) {
                    param.visit = 'savemallcategory';
                    param.ID = ID;
                    param.ParentID = ParentID;
                    param.type = type;
                    param.TagName = hdTagName.val();
                },
                success: function (data) {
                    MaskUtil.unmask();
                    var dataObj = eval("(" + data + ")");
                    if (dataObj.status) {
                        if (dataObj.ID > 0) {
                            ID = dataObj.ID;
                            show_message('保存成功', 'success', function () {
                                do_close();
                            });
                            return;
                        }
                        show_message('数据不存在或已删除', 'warning');
                    }
                    if (dataObj.error) {
                        show_message(dataObj.error, 'warning');
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
        .image_box {
            width: 100px;
            display: inline-flexbox;
            margin-right: 10px;
            text-align: center;
        }

            .image_box img {
                width: 100%;
            }

        .panel-body {
            background: #f0f0f0;
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
            <table class="info">
                <tr>
                    <td>分类名称</td>
                    <td>
                        <input type="text" class="easyui-textbox" runat="server" id="tdCategoryName" data-options="required:true" /></td>
                    <td>排序</td>
                    <td>
                        <input type="text" class="easyui-textbox" runat="server" id="tdSortOrder" data-options="required:true" /></td>
                </tr>
                <tr class="tr_parent_category" style="display: none;">
                    <td>父级分类
                    </td>
                    <td colspan="3">
                        <label runat="server" id="tdParentCategoryName"></label>
                    </td>
                </tr>
                <tr>
                    <td>所属标签</td>
                    <td>
                        <input type="text" class="easyui-combobox" runat="server" id="tdTagName" />
                        <asp:HiddenField runat="server" ID="hdTagName" />
                    </td>
                    <td>是否禁用</td>
                    <td>
                        <select type="text" class="easyui-combobox" runat="server" id="tdIsDisabled" data-options="editable:false">
                            <option value="0">否</option>
                            <option value="1">是</option>
                        </select>
                    </td>
                </tr>
                <tr>
                    <td>商圈显示</td>
                    <td colspan="3">
                        <select type="text" class="easyui-combobox" runat="server" id="tdIsShowOnMallYouXuan" data-options="editable:false">
                            <option value="0">否</option>
                            <option value="1">是</option>
                        </select>
                    </td>
                </tr>
                <tr id="trExistFiles" style="display: none;">
                </tr>
                <tr>
                    <td>上传图片</td>
                    <td colspan="3" id="tdFile">
                        <input class="easyui-filebox" name="attachfile" data-options="prompt:'请选择图片',buttonText: '选择图片'" style="width: 85%" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</asp:Content>
