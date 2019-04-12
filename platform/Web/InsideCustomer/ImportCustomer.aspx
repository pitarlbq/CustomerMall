<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="ImportCustomer.aspx.cs" Inherits="Web.InsideCustomer.ImportCustomer" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function do_export() {
            parent.do_export();
        }
        function do_save() {
            MaskUtil.mask('body', '导入中');
            $('#ff').form('submit', {
                url: "../Handler/ImportCustomerHandler.ashx?visit=import",
                onSubmit: function (param) {
                    param.CreatorID = "<%= Web.WebUtil.GetUser(this.Context).UserID %>",
                    param.AddMan = "<%= Web.WebUtil.GetUser(this.Context).RealName %>",
                    param.CompanyID = "<%= Web.WebUtil.GetCompanyID(this.Context) %>"
                },
                dataType: "html",
                success: function (data) {
                    MaskUtil.unmask();
                    data = data.replace(/&lt;/g, "<");
                    data = data.replace(/&gt;/g, ">");
                    $("#<%=this.errMsg.ClientID%>").html(data);
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

        .notifyMsg {
            text-align: center;
            color: #ff0000;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <form id="ff" method="post" runat="server" enctype="multipart/form-data">
        <div class="operation_box">
            <a href="javascript:void(0)" onclick="do_save()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-import'">导入</a>
            <a href="javascript:void(0)" onclick="do_close()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-close'">关闭</a>
        </div>
        <div class="table_container">
            <table class="info">
                <tr>
                    <td>模板</td>
                    <td>
                        <a href="javascript:void(0)" onclick="do_export()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-export'">下载</a>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <hr />
                    </td>
                </tr>
                <tr>
                    <td>文件</td>
                    <td>
                        <input class="easyui-filebox" name="attachfile" id="attached" data-options="prompt:'请选择文件',buttonText: '选择文件'" style="width: 60%" />
                    </td>
                </tr>
            </table>
            <div class="notifyMsg">
                <label runat="server" id="errMsg"></label>
            </div>
        </div>
    </form>
</asp:Content>
