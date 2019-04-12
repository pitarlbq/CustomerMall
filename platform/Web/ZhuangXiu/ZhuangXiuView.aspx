<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="ZhuangXiuView.aspx.cs" Inherits="Web.ZhuangXiu.ZhuangXiuView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>任务登记</title>
    <script src="../js/Page/Comm/PinYin.js?t=<%=base.getToken() %>"></script>
    <script>
        var ID, ProjectID, tdChargeName;
        $(function () {
            ID = "<%=Request.QueryString["ID"]%>";
            ProjectID = "<%=this.zhuangxiu.RoomID%>";
            tdChargeName = $('#<%=this.tdChargeName.ClientID%>');
            loadattachs();
            $("#<%=this.tdApplicationMan.ClientID%>").combobox("setValue", $("#<%=this.hdApplicationMan.ClientID%>").val());
            $("#<%=this.tdApplicationMan.ClientID%>").combobox("setText", $("#<%=this.hdApplicationMan.ClientID%>").val());
            get_chargesummary();
        });
        function get_chargesummary() {
            var options = { visit: "getchargesummarylist", CategoryID: 3 };
            $.ajax({
                type: 'POST',
                data: options,
                dataType: 'json',
                url: '../Handler/FeeCenterHandler.ashx',
                success: function (data) {
                    tdChargeName.combobox({
                        editable: false,
                        data: data,
                        valueField: 'ID',
                        textField: 'Name'
                    });
                }
            });
        }
        function loadattachs() {
            var options = { visit: 'loadzhuangxiuattachs', ID: ID, FileType: "addzhuangxiu" };
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/ZhuangXiuHandler.ashx',
                data: options,
                success: function (data) {
                    var $html = '';
                    $("#trExistFiles").html($html);
                    if (data.length > 0) {
                        $("#trExistFiles").show();
                        $html += '<td>已上传附件</td>';
                        $html += '<td colspan="3">';
                        $.each(data, function (index, item) {
                            $html += '<div>' + item.FileOriName + ' &nbsp;&nbsp;&nbsp;&nbsp;<a href="' + item.AttachedFilePath + '" target="_blank" >下载</a>&nbsp;&nbsp;&nbsp;&nbsp;';
                            $html += '</div>';
                        })
                        $html += '</td>';
                    }
                    $("#trExistFiles").append($html);
                }
            });
        }
        function load_yanshou_attachs() {
            var options = { visit: 'loadzhuangxiuattachs', ID: ID, FileType: "addyanshou" };
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/ZhuangXiuHandler.ashx',
                data: options,
                success: function (data) {
                    var $html = '';
                    $("#trYanShouExistFiles").html($html);
                    if (data.length > 0) {
                        $("#trYanShouExistFiles").show();
                        $html += '<td>已上传附件</td>';
                        $html += '<td colspan="3">';
                        $.each(data, function (index, item) {
                            $html += '<div>' + item.FileOriName + ' &nbsp;&nbsp;&nbsp;&nbsp;<a href="' + item.AttachedFilePath + '" target="_blank" >下载</a>&nbsp;&nbsp;&nbsp;&nbsp;';
                            $html += '</div>';
                        })
                        $html += '</td>';
                    }
                    $("#trYanShouExistFiles").append($html);
                }
            });
        }
        function closeWin() {
            parent.$("#winadd").window("close");
        }
    </script>
    <style>
        table.info {
            width: 100%;
            border: solid 1px #ccc;
            border-spacing: 0;
            border-collapse: collapse;
        }

            table.info td {
                border: solid 1px #ccc;
                padding: 10px;
                text-align: left;
                width: 35%;
            }

                table.info td:nth-child(2n-1) {
                    text-align: right;
                    width: 15%;
                }

        input[type=text] {
            width: 200px;
        }

        table.info td.header_title {
            text-align: center;
            background-color: #0094ff;
            color: #fff;
            font-size: 14px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <form id="ff" runat="server" method="post" enctype="multipart/form-data">
        <table class="info">
            <tr>
                <td colspan="4" class="header_title">基本信息</td>
            </tr>
            <tr>
                <td>装修房号</td>
                <td>
                    <input type="text" runat="server" data-options="readonly:true" name="RoomName" class="easyui-textbox" id="tdRoomName" />
                </td>
                <td>申请人</td>
                <td>
                    <input type="text" runat="server" data-options="readonly:true" name="ApplicationMan" class="easyui-combobox" id="tdApplicationMan" />
                    <asp:HiddenField runat="server" ID="hdApplicationMan" />
                </td>
            </tr>
            <tr>
                <td>联系电话</td>
                <td>
                    <input type="text" runat="server" name="PhoneNumber" class="easyui-textbox" id="tdPhoneNumber" data-options="readonly:true" /></td>
                <td>押金项目</td>
                <td>
                    <input type="text" runat="server" name="ChargeName" class="easyui-combobox" id="tdChargeName" data-options="readonly:true" /></td>
            </tr>
            <tr>
                <td>押金</td>
                <td>
                    <input type="text" runat="server" name="DepositPrice" class="easyui-textbox" id="tdDepositPrice" data-options="readonly:true" />
                </td>
                <td>装修类型</td>
                <td>
                    <select type="text" runat="server" name="ZhuangXiuType" class="easyui-combobox" id="tdZhuangXiuType" data-options="readonly:true">
                        <option value="单体住宅楼">单体住宅楼</option>
                        <option value="别墅">别墅</option>
                        <option value="商务办公">商务办公</option>
                        <option value="公寓">公寓</option>
                        <option value="住宅">住宅</option>
                        <option value="写字楼">写字楼</option>
                    </select>
                </td>
            </tr>
            <tr>
                <td>类型描述</td>
                <td colspan="3">
                    <input type="text" runat="server" name="TypeDesc" class="easyui-textbox" id="tdTypeDesc" data-options="readonly:true" /></td>
            </tr>
            <tr id="trExistFiles" style="display: none;">
            </tr>
            <tr>
                <td colspan="4" class="header_title">装修验收</td>
            </tr>
            <tr>
                <td>装修时间</td>
                <td>
                    <input type="text" runat="server" data-options="readonly:true" name="ZhuangXiuTime" class="easyui-datebox" id="tdZhuangXiuTime" />
                </td>
                <td>验收日期</td>
                <td>
                    <input type="text" runat="server" data-options="readonly:true" name="YanShouTime" class="easyui-datebox" id="tdYanShouTime" />
                </td>
            </tr>
            <tr>
                <td>验收人</td>
                <td>
                    <input type="text" runat="server" data-options="readonly:true" name="YanShouMan" class="easyui-textbox" id="tdYanShouMan" />
                </td>
                <td>罚款合计</td>
                <td>
                    <input type="text" runat="server" data-options="readonly:true" name="TotalWeiGuiCost" class="easyui-textbox" id="tdTotalWeiGuiCost" style="width: 80%;" /></td>
            </tr>
            <tr id="trYanShouExistFiles" style="display: none;">
            </tr>
            <tr>
                <td>备注</td>
                <td colspan="3">
                    <input type="text" runat="server" name="YanShouRemark" data-options="multiline:true,readonly:true" class="easyui-textbox" id="tdYanShouRemark" style="width: 80%; height: 50px;" /></td>
            </tr>
            <tr>
                <td colspan="4" style="text-align: center;">
                    <a href="javascript:void(0)" onclick="closeWin()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-close'">关闭</a>
                </td>
            </tr>
        </table>
    </form>
</asp:Content>
