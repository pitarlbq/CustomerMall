<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="UpgradeWebSite.aspx.cs" Inherits="Web.SysSeting.UpgradeWebSite" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $(function () {
            getCombobox();
            $('#tdVersionType').combobox({
                onSelect: function () {
                    do_select_type();
                }
            })
            do_select_type();
        })
        function do_select_type() {
            var type = $('#tdVersionType').combobox('getValue');
            if (type == 'platform') {
                $('#trPlatform').show();
                $('#trWeiXin').hide();
            }
            else {
                $('#trPlatform').hide();
                $('#trWeiXin').show();
            }
        }
        function getCombobox() {
            var options = { visit: 'getupgradesiteparams' };
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/SysSettingHandler.ashx',
                data: options,
                success: function (data) {
                    if (data.status) {
                        $('#tdVersionCode').combobox({
                            editable: false,
                            data: data.versions,
                            valueField: 'ID',
                            textField: 'Name',
                        })
                        return;
                    }
                    show_message('系统错误', 'error');
                }
            });
        }
        function do_save() {
            var isValid = $("#<%=this.ff.ClientID%>").form('enableValidation').form('validate');
            if (!isValid) {
                return;
            }
            var rows = parent.$("#tt_table").datagrid("getSelections");
            if (rows.length == 0) {
                show_message("请至少选择一个公司进行此操作", "info");
                return;
            }
            var IDList = [];
            $.each(rows, function (index, row) {
                IDList.push(row.CompanyID);
            })
            var VersionID = $("#tdVersionCode").combobox("getValue");
            var VersionType = $("#tdVersionType").combobox("getValue");
            MaskUtil.mask('body', '提交中');
            var options = {};
            $('#ff').form('submit', {
                url: '../CommHandler.ashx',
                onSubmit: function (options) {
                    options.visit = "upgradecompany";
                    options.VersionID = VersionID;
                    options.VersionType = VersionType;
                    options.IDList = JSON.stringify(IDList);
                },
                success: function (data) {
                    MaskUtil.unmask();
                    var message = eval("(" + data + ")");
                    if (message.status) {
                        show_message("升级成功", "info", function () {
                            do_close();
                        });
                        return;
                    }
                    if (message.error) {
                        show_message(message.error, 'warning');
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
    <style type="text/css">
        .panel-body {
            background: #f0f0f0;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <form runat="server" id="ff" method="post" enctype="multipart/form-data">
        <div class="operation_box">
            <a href="javascript:void(0)" onclick="do_save()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-save'">升级</a>
            <a href="javascript:void(0)" onclick="do_close()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-close'">关闭</a>
        </div>
        <div class="table_container">
            <table class="info">
                <tr>
                    <td style="width: 15%;">选择升级类型
                    </td>
                    <td colspan="3">
                        <select class="easyui-combobox" id="tdVersionType" data-options="required:true,editable:false">
                            <option value="platform">后台</option>
                            <option value="weixin">微信</option>
                        </select>
                    </td>
                </tr>
                <tr id="trPlatform">
                    <td style="width: 15%;">选择版本号
                    </td>
                    <td colspan="3">
                        <input class="easyui-combobox" id="tdVersionCode" type="text" data-options="editable:false" />
                    </td>
                </tr>
                <tr id="trWeiXin">
                    <td>上传文件
                    </td>
                    <td colspan="3">
                        <input id="Text1" runat="server" class="easyui-filebox" type="text" name="FilePath" style="width: 50%;" data-options="prompt:'请选择文件',buttonText: '选择文件'" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</asp:Content>
