<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="ImportStartTime.aspx.cs" Inherits="Web.SetupFee.ImportStartTime" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function do_save() {
            MaskUtil.mask('body', '导入中');
            $('#ff').form('submit', {
                url: "../Handler/ImportSourceHandler.ashx",
                onSubmit: function (param) {
                    param.visit = "importstarttime",
                    param.CreatorID = "<%= Web.WebUtil.GetUser(this.Context).UserID %>",
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
        $(function () {
            loadFeeType();
        });
        function loadFeeType() {
            var CompanyID = "<%=Web.WebUtil.GetCompanyID(this.Context)%>";
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/FeeCenterHandler.ashx?visit=getchargesummarylist&CompanyID=' + CompanyID,
                success: function (data) {
                    $('#<%=this.tbChargeSummary.ClientID%>').combobox({
                        editable: false,
                        data: data,
                        valueField: 'ID',
                        textField: 'Name',
                    });
                    $('#<%=this.tbChargeSummary.ClientID%>').combobox("setValue", data[0].ID);
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
        table.info {
            margin: 0 auto;
            margin-top: 0px;
            width: 90%;
            border-collapse: collapse;
            border-spacing: 0;
            border: solid 1px #ccc;
        }

            table.info td {
                padding: 5px 10px;
                text-align: left;
                vertical-align: middle;
                border: solid 1px #ccc;
                text-align: left;
                width: 35%;
            }

                table.info td:nth-child(2n-1) {
                    text-align: right;
                    width: 15%;
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
            <a href="javascript:void(0)" onclick="do_save()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-save'">导入</a>
            <a href="javascript:void(0)" onclick="do_close()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-close'">关闭</a>
        </div>
        <div class="table_container">
            <table class="info">
                <tr style="display: none;">
                    <td>选择收费项目
                    </td>
                    <td>
                        <input class="easyui-combobox" runat="server" id="tbChargeSummary" style="width: 200px; height: 25px;" />
                    </td>
                </tr>
                <tr>
                    <td>文件</td>
                    <td>
                        <%--<asp:FileUpload ID="ExcelUpload" runat="server" Height="22px" Width="142px" />--%>
                        <input class="easyui-filebox" name="attachfile" data-options="prompt:'请选择文件',buttonText: '选择文件'" style="width: 60%" />
                    </td>
                </tr>
            </table>
            <div class="notifyMsg">
                <label runat="server" id="errMsg"></label>
            </div>
        </div>
    </form>
</asp:Content>
