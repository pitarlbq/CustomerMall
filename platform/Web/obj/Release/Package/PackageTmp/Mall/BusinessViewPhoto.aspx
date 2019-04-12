<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="BusinessViewPhoto.aspx.cs" Inherits="Web.Mall.BusinessViewPhoto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        var ID;
        $(function () {
            ID = "<%=this.BusinessID%>";
            loadattachs();
        });
        function loadattachs() {
            if (ID <= 0) {
                return;
            }
            var options = { visit: 'getmallbusinesspic', ID: ID };
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/MallHandler.ashx',
                data: options,
                success: function (data) {
                    var $html = '';
                    $("#trExistFiles").hide();
                    $("#trExistFiles").html($html);
                    if (data.status && data.list.length > 0) {
                        $("#trExistFiles").show();
                        $html += '<td colspan="4" style="text-align:left;">';
                        $.each(data.list, function (index, item) {
                            $html += '<div class="image_box"><a href="' + item.LargePicPath + '" target="_blank" ><image src="' + item.IconPicPath + '"></a><br/>';
                            $html += '<a href="#" onclick="deleteAttach(' + item.ID + ')">删除</a></div>';
                        })
                        $html += '</td>';
                        $("#trExistFiles").append($html);
                    }
                }
            });
        }
        function deleteAttach(AttachID) {
            top.$.messager.confirm("提示", "是否删除选已上传的图片?", function (r) {
                if (r) {
                    var options = { visit: 'deletemallbusinesspic', ID: AttachID };
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
        function do_close() {
            parent.do_close_dialog(function () {
                parent.$('#tt_table').datagrid('reload');
            });
        }
    </script>
    <style>
        .image_box {
            min-width: 100px;
            display: inline-block;
            margin-right: 10px;
            text-align: center;
            margin: 10px;
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
            <div class="table_title">资料图片</div>
            <table class="info">
                <tr id="trExistFiles" style="display: none;">
                </tr>
            </table>
        </div>
    </form>
</asp:Content>
