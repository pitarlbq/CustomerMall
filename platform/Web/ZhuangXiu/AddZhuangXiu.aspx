<%@ Page Title="" Language="C#" MasterPageFile="~/Master/NavContent6.Master" AutoEventWireup="true" CodeBehind="AddZhuangXiu.aspx.cs" Inherits="Web.ZhuangXiu.AddZhuangXiu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>任务登记</title>
    <script src="../js/Page/Comm/PinYin.js?t=<%=base.getToken() %>"></script>
    <script>
        var ID, ProjectID, tdChargeName;
        $(function () {
            ID = 0;
            tdChargeName = $("#<%=this.tdChargeName.ClientID%>");
            addFile();
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
        function pageLoad(RoomID, isNotRoom) {
            if (isNotRoom) {
                return;
            }
            ID = 0;
            ProjectID = RoomID;
            $("#<%=this.tdRoomName.ClientID%>").textbox("setValue", "");
            var manList = [];
            $("#<%=this.tdApplicationMan.ClientID%>").combobox({
                    editable: false,
                    data: manList,
                    valueField: 'ID',
                    textField: 'RelationName'
                });
                var options = { visit: "getroominfo", ProjectID: ProjectID, IsNotRoom: isNotRoom };
                $.ajax({
                    type: 'POST',
                    data: options,
                    dataType: 'json',
                    url: '../Handler/ServiceHandler.ashx',
                    success: function (data) {
                        $("#<%=this.tdRoomName.ClientID%>").textbox("setValue", data.room.Name);
                    manList = data.roomrelation;
                    $("#<%=this.tdApplicationMan.ClientID%>").combobox({
                        editable: false,
                        data: manList,
                        valueField: 'RelationName',
                        textField: 'RelationName'
                    });
                    if (manList.length > 0) {
                        $("#<%=this.tdApplicationMan.ClientID%>").combobox("setValue", manList[0].RelationName);
                        $("#<%=this.tdApplicationMan.ClientID%>").combobox("setText", manList[0].RelationName);
                    }
                }
            });
        }
        function saveData() {
            var isValid = $("#<%=this.ff.ClientID%>").form('enableValidation').form('validate');
            if (!isValid) {
                return;
            }
            $('#ff').form('submit', {
                url: '../Handler/ZhuangXiuHandler.ashx',
                onSubmit: function (param) {
                    param.visit = 'savezhuangxiu';
                    param.ProjectID = ProjectID;
                    param.ID = ID;
                    param.AddMan = "<%=Web.WebUtil.GetUser(this.Context).RealName%>";
                },
                success: function (data) {
                    var dataObj = eval("(" + data + ")");
                    if (dataObj.status) {
                        if (dataObj.ID > 0) {
                            ID = dataObj.ID;
                            show_message('保存成功', 'success', function () {
                                closeWin();
                            });
                            return;
                        }
                        show_message("合同记录不存在", "info");
                    }
                    else {
                        show_message('系统错误', 'error');
                    }
                }
            });
        }
        var filecount = 0;
        function addFile() {
            $("#tdFile").find("a.fileadd").hide();
            $("#tdFile").find("a.fileremove").show();
            filecount++;
            var $html = "<div id=\"tdFile_" + filecount + "\">";
            $html += "<input class=\"easyui-filebox\" name=\"attachfile\" data-options=\"prompt:'请选择文件',buttonText: '选择文件'\" style=\"width: 60%\" />";
            $html += '<a href="javascript:void(0)" onclick="addFile()" class="easyui-linkbutton btnlinkbar fileadd" data-options="plain:true,iconCls:\'icon-search\'">添加</a>';
            $html += '<a href="javascript:void(0)" onclick="deleteFile(' + filecount + ')" class="easyui-linkbutton btnlinkbar fileremove" style="display:none;" data-options="plain:true,iconCls:\'icon-search\'">删除</a>';
            $html += "</div>";
            $("#tdFile").append($html);
            $.parser.parse("#tdFile_" + filecount);
        }
        function deleteFile(id) {
            $("#tdFile_" + id).html("");
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
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <form id="ff" runat="server" method="post" enctype="multipart/form-data">
        <table class="info">
            <tr>
                <td colspan="4" style="text-align: center; font-size: 15px; padding: 5px;">新增装修申请</td>
            </tr>
            <tr>
                <td>装修房号</td>
                <td>
                    <input type="text" runat="server" data-options="required:true" name="RoomName" class="easyui-textbox" id="tdRoomName" />
                </td>
                <td>申请人</td>
                <td>
                    <input type="text" runat="server" name="ApplicationMan" class="easyui-combobox" id="tdApplicationMan" /></td>
            </tr>
            <tr>
                <td>联系电话</td>
                <td>
                    <input type="text" runat="server" name="PhoneNumber" class="easyui-textbox" id="tdPhoneNumber" /></td>
                <td>押金项目</td>
                <td>
                    <input type="text" runat="server" name="ChargeName" class="easyui-combobox" id="tdChargeName" /></td>
            </tr>
            <tr>
                <td>押金</td>
                <td>
                    <input type="text" runat="server" name="DepositPrice" class="easyui-textbox" id="tdDepositPrice" />
                </td>
                <td>装修类型</td>
                <td>
                    <select type="text" runat="server" name="ZhuangXiuType" class="easyui-combobox" id="tdZhuangXiuType">
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
                    <input type="text" runat="server" name="TypeDesc" class="easyui-textbox" id="tdTypeDesc" /></td>
            </tr>
            <tr>
                <td>附件</td>
                <td colspan="3" id="tdFile"></td>
            </tr>
            <tr>
                <td colspan="4" style="text-align: center;">
                    <a href="javascript:void(0)" onclick="saveData()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-save'">保存</a>
                    <a href="javascript:void(0)" onclick="closeWin()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-save'">关闭</a>
                </td>
            </tr>
        </table>
    </form>
</asp:Content>
