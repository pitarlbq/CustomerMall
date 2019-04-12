<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="ProductsChangeCategory.aspx.cs" Inherits="Web.Mall.ProductsChangeCategory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        var IDList = [], tdCategoryName;
        $(function () {
            tdCategoryName = $('#<%=this.tdCategoryName.ClientID%>');
            var rows = parent.$("#tt_table").datagrid("getSelections");
            if (rows.length == 0) {
                show_message("请至少选择一条数据进行此操作", "info");
                return;
            }
            $.each(rows, function (index, row) {
                IDList.push(row.ID);
            })
            get_select_category_params();
        })
        function init() {
            //去掉结点前面的文件及文件夹小图标
            $(".tree-icon,.tree-file").removeClass("tree-icon tree-file");
            $(".tree-icon,.tree-folder").removeClass("tree-icon tree-folder tree-folder-open tree-folder-closed");
        }
        function get_select_category_params() {
            var options = { visit: 'getmallproducteditcategorytreeparams' };
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/MallHandler.ashx',
                data: options,
                success: function (data) {
                    tdCategoryName.combotree({
                        multiple: true,
                        editable: false,
                        valueField: 'id',
                        textField: 'text',
                        data: data
                    });
                    init();
                }
            });
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
                    var CategoryIDList = tdCategoryName.combotree('getValues');
                    param.visit = 'savemallproductcategories';
                    param.ProductIDList = JSON.stringify(IDList);
                    param.CategoryIDList = JSON.stringify(CategoryIDList);
                },
                success: function (data) {
                    MaskUtil.unmask();
                    var dataObj = eval("(" + data + ")");
                    if (dataObj.status) {
                        show_message('保存成功', 'success', function () {
                            do_close();
                        });
                        return;
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
                    <td colspan="4" style="text-align: center;">
                        <input type="text" class="easyui-combotree" runat="server" id="tdCategoryName" data-options="required:true" /></td>
                </tr>
            </table>
        </div>
    </form>
</asp:Content>
