<%@ Page Title="" Language="C#" MasterPageFile="~/Master/NavContent6.Master" AutoEventWireup="true" CodeBehind="EditPayService.aspx.cs" Inherits="Web.PayService.EditPayService" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>支出登记</title>
    <script src="../js/Page/Comm/PinYin.js?t=<%=base.getToken() %>"></script>
    <script>
        var ID, ProjectID, tdPaySummary;
        $(function () {
            ID = "<%=this.ID%>";
            loadPaySummary();
            loadPayType();
            ProjectID = $('#<%=this.hdProjectID.ClientID%>').val();
            tdPaySummary = $('#<%=this.tdPaySummary.ClientID%>');
        });
        function pageLoad(RoomID, isNotRoom) {
            if (ID > 0) {
                return;
            }
            $('#<%=this.hdProjectID.ClientID%>').val(RoomID)
            ProjectID = RoomID;
            $("#<%=this.tdProjectName.ClientID%>").textbox("setValue", "");
            $("#<%=this.tdRoomName.ClientID%>").textbox("setValue", "");
            var options = { visit: "getroominfo", ProjectID: ProjectID, IsNotRoom: isNotRoom };
            $.ajax({
                type: 'POST',
                data: options,
                dataType: 'json',
                url: '../Handler/ServiceHandler.ashx',
                success: function (data) {
                    if (!isNotRoom) {
                        $("#<%=this.tdProjectName.ClientID%>").textbox("setValue", data.room.FullName);
                        $("#<%=this.tdRoomName.ClientID%>").textbox("setValue", data.room.Name);
                    }
                    else {
                        $("#<%=this.tdProjectName.ClientID%>").textbox("setValue", data.room.FullName);
                    }
                }
            });
        }
        function savedata(type) {
            var isValid = $("#<%=this.ff.ClientID%>").form('enableValidation').form('validate');
            if (!isValid) {
                return;
            }
            MaskUtil.mask('body', '提交中');
            $('#ff').form('submit', {
                url: '../Handler/ServiceHandler.ashx',
                onSubmit: function (param) {
                    param.visit = 'savepayservice';
                    param.ID = ID;
                    param.ProjectID = ProjectID;
                    param.type = type;
                },
                success: function (data) {
                    MaskUtil.unmask();
                    var dataObj = eval("(" + data + ")");
                    if (dataObj.status) {
                        if (dataObj.ID > 0) {
                            ID = dataObj.ID;
                            if (dataObj.PrintID) {
                                startPrint(0, dataObj.PrintID)
                                return;
                            }
                            if (type == 1 && dataObj.TempID) {
                                startPrint(dataObj.TempID, 0)
                                return;
                            }
                            show_message('保存成功', 'success', function () {
                                do_close();
                            });
                            return;
                        }
                        show_message("支出记录不存在", "info");
                    }
                    else {
                        show_message('系统错误', 'error');
                    }
                }
            });
        }
        function startPrint(TempID, PrintID) {
            var iframe = "";
            if (PrintID > 0) {
                iframe = "<iframe id='myFrame' scrolling='auto' frameborder='0' src='../PrintPage/printchargepayservice.aspx?TempID=" + TempID + "&PayServiceID=" + ID + "&&PrintID=" + PrintID + "' style='width:100%;height:" + ($(window).height() - 40) + "px'></iframe>";
            }
            else {
                iframe = "<iframe id='myFrame' scrolling='auto' frameborder='0' src='../PrintPage/printchargepayservice.aspx?TempID=" + TempID + "&PayServiceID=" + ID + "&&PrintID=" + PrintID + "' style='width:100%;height:" + ($(window).height() - 40) + "px'></iframe>";
            }
            $("<div id='winprint'></div>").appendTo("body").window({
                title: '打印付款单据',
                width: $(window).width() - 100,
                height: $(window).height(),
                top: 0,
                left: 50,
                inline: true,
                content: iframe,
                collapsible: false,
                minimizable: false,
                maximizable: false,
                onClose: function () {
                    $("#winprint").remove();
                }
            });
        }
        function loadPaySummary() {
            var options = { visit: 'loadpaysummary' };
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/ServiceHandler.ashx',
                data: options,
                success: function (data) {
                    tdPaySummary.combobox({
                        editable: false,
                        data: data,
                        valueField: 'ID',
                        textField: 'PayName',
                        filter: function (q, row) {
                            var opts = $(this).combobox('options');
                            return __pinyin.getFirstLetter(row[opts.textField]).indexOf(q.toLowerCase()) != -1 || row[opts.textField].indexOf(q) != -1;
                        },
                        onSelect: function (rec) {
                            $("#<%=this.hdPaySummary.ClientID%>").val(rec.PayName);
                        }
                    });
                    var paySummaryID = tdPaySummary.combobox('getValue');
                    if (paySummaryID == '') {
                        tdPaySummary.combobox('setValue', data[0].ID);
                        $("#<%=this.hdPaySummary.ClientID%>").val(data[0].PayName);
                    }
                }
            });
        }
        function loadPayType() {
            var options = { visit: "getpaytype" };
            $.ajax({
                type: 'POST',
                data: options,
                dataType: 'json',
                url: '../Handler/ServiceHandler.ashx',
                success: function (data) {
                    $("#<%=this.tdPayType.ClientID%>").combobox({
                        editable: true,
                        data: data,
                        valueField: 'ChargeTypeID',
                        textField: 'ChargeTypeName',
                        onSelect: function (rec) {
                            $("#<%=this.hdPayType.ClientID%>").val(rec.ChargeTypeName);
                        }
                    });
                    $("#<%=this.tdPayType.ClientID%>").combobox('setValue', data[0].ChargeTypeID);
                    $("#<%=this.hdPayType.ClientID%>").val(data[0].ChargeTypeName);
                }
            });
        }
        function do_close() {
            parent.do_close_dialog(function () {
                parent.$("#tt_table").datagrid("reload");
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
            <%if (service != null && service.PrintID > 0 && this.can_edit)
              { %>
            <a href="javascript:void(0)" onclick="savedata(1)" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-print'">打印</a>
            <%} %>
            <%else if (this.can_edit)
              { %>
            <a href="javascript:void(0)" onclick="savedata(1)" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-print'">保存并打印</a>
            <a href="javascript:void(0)" onclick="savedata(0)" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-save'">保存</a>
            <%} %>
            <a href="javascript:void(0)" onclick="do_close()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-close'">关闭</a>

        </div>
        <div class="table_container">
            <table class="info">
                <tr>
                    <td colspan="4" style="text-align: center; font-size: 15px; padding: 5px;">支出登记单</td>
                </tr>
                <tr>
                    <td>资源位置</td>
                    <td style="width: 500px" colspan="3">
                        <input type="text" runat="server" data-options="required:true,readonly:true" name="ProjectName" class="easyui-textbox" id="tdProjectName" style="width: 100%" /></td>
                </tr>
                <tr>
                    <td>所属房间</td>
                    <td>
                        <input type="text" runat="server" name="RoomName" data-options="readonly:true" class="easyui-textbox" id="tdRoomName" />
                        <input type="hidden" runat="server" id="hdProjectID" />
                    </td>
                    <td>项目名称</td>
                    <td>
                        <input type="text" runat="server" data-options="required:true" name="PaySummaryID" class="easyui-combobox" id="tdPaySummary" />
                        <input type="hidden" runat="server" id="hdPaySummary" />
                    </td>
                </tr>
                <tr>
                    <td>金额</td>
                    <td>
                        <input type="text" runat="server" data-options="required:true" name="PayMoney" class="easyui-textbox" id="tdPayMoney" /></td>
                    <td>支付方式</td>
                    <td>
                        <input type="text" runat="server" data-options="required:true" name="PayType" class="easyui-combobox" id="tdPayType" />
                        <input type="hidden" runat="server" id="hdPayType" />
                    </td>
                </tr>
                <tr>
                    <td>操作人</td>
                    <td>
                        <input type="text" runat="server" data-options="required:true,readonly:true" name="AddMan" class="easyui-textbox" id="tdAddMan" /></td>
                    <td>支出时间</td>
                    <td>
                        <input type="text" runat="server" data-options="required:true" name="PayTime" class="easyui-datetimebox" id="tdPayTime" /></td>
                </tr>
                <tr>
                    <td>记账操作</td>
                    <td colspan="3">
                        <select runat="server" data-options="required:true" name="AccountType" class="easyui-combobox" id="tdAccountType">
                            <option value="支出">支出</option>
                        </select>
                    </td>
                </tr>
                <tr>
                    <td>备注</td>
                    <td colspan="3">
                        <input class="easyui-textbox" id="tdRemark" name="Remark" data-options="multiline:true" runat="server" style="height: 60px; width: 70%;" />
                    </td>
                </tr>
            </table>
            <iframe name="myiframe" id="myframe" style="display: none;" src="" width="100%" height="100%"></iframe>
        </div>
    </form>
</asp:Content>
