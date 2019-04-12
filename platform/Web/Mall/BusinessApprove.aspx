<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="BusinessApprove.aspx.cs" Inherits="Web.Mall.BusinessApprove" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        var ID, filecount = 0;
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
                    $("#trExistCoverFiles").hide();
                    $("#trExistCoverFiles").html($html);
                    if (data.status) {
                        if (data.list.length > 0) {
                            $("#trExistFiles").show();
                            $html += '<td>已上传图片</td>';
                            $html += '<td colspan="3">';
                            $.each(data.list, function (index, item) {
                                $html += '<div class="image_box"><a href="' + item.LargePicPath + '" target="_blank" ><image src="' + item.IconPicPath + '"></a></div>';
                            })
                            $html += '</td>';
                            $("#trExistFiles").append($html);
                        }
                        if (data.CoverImage != '') {
                            $("#trExistCoverFiles").show();
                            $html = '<td>已上传图片</td>';
                            $html += '<td colspan="3">';
                            $html += '<div class="image_box"><a href="' + data.CoverImage + '" target="_blank" ><image src="' + data.CoverImage + '"></a></div>';
                            $html += '</td>';
                            $("#trExistCoverFiles").append($html);
                        }
                    }
                }
            });
        }
        function do_save(status) {
            var isValid = $("#<%=this.ff.ClientID%>").form('enableValidation').form('validate');
            if (!isValid) {
                return;
            }
            MaskUtil.mask('body', '提交中');
            $('#ff').form('submit', {
                url: '../Handler/MallHandler.ashx',
                onSubmit: function (param) {
                    param.visit = 'approvemallbusiness';
                    param.ID = ID;
                    param.Status = status;
                },
                success: function (data) {
                    MaskUtil.unmask();
                    var dataObj = eval("(" + data + ")");
                    if (dataObj.status) {
                        show_message('操作成功', 'success', function () {
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
                parent.$("#tt_table").datagrid("reload");
            }, true);
        }
    </script>
    <style>
        .image_box {
            width: 100px;
            display: inline-block;
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
            <%if (this.Status != 1)
              { %>
            <a href="javascript:void(0)" onclick="do_save(1)" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-save'">审核通过</a>
            <a href="javascript:void(0)" onclick="do_save(2)" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-save'">审核不通过</a>
            <%} %>
            <a href="javascript:void(0)" onclick="do_close()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-close'">关闭</a>
        </div>
        <div class="table_container">
            <div class="table_title">基本信息</div>
            <table class="info">
                <tr>
                    <td>门店名称</td>
                    <td>
                        <input type="text" class="easyui-textbox" runat="server" id="tdBusinessName" data-options="readonly:true" /></td>
                    <td>门店地址</td>
                    <td>
                        <input type="text" class="easyui-textbox" runat="server" id="tdBusinessAddress" data-options="readonly:true" /></td>
                </tr>
                <tr>
                    <td>联系人</td>
                    <td>
                        <input type="text" class="easyui-textbox" runat="server" id="tdContactName" data-options="readonly:true" /></td>
                    <td>联系电话</td>
                    <td>
                        <input type="text" class="easyui-textbox" runat="server" id="tdContactPhone" data-options="readonly:true" /></td>
                </tr>
                <tr>
                    <td>营业执照号</td>
                    <td colspan="3">
                        <input type="text" class="easyui-textbox" runat="server" id="tdLicenseNumber" data-options="readonly:true" /></td>
                </tr>
                <tr id="trExistCoverFiles" style="display: none;">
                </tr>
            </table>
            <div class="table_title">资料图片</div>
            <table class="info">
                <tr id="trExistFiles" style="display: none;">
                </tr>
            </table>
            <div class="table_title">资料审核</div>
            <table class="info">
                <tr>
                    <td>审核人</td>
                    <td>
                        <input type="text" class="easyui-textbox" runat="server" id="tdApproveMan" data-options="readonly:true" /></td>
                    <td>审核时间</td>
                    <td>
                        <input type="text" class="easyui-textbox" runat="server" id="tdApproveTime" data-options="readonly:true" /></td>
                </tr>
                <tr>
                    <td>审核备注</td>
                    <td colspan="3">
                        <input type="text" id="tdApproveRemark" runat="server" class="easyui-textbox" data-options="multiline:true" style="width: 85%; height: 50px;" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</asp:Content>
