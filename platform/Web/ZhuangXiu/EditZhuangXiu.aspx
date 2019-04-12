<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="EditZhuangXiu.aspx.cs" Inherits="Web.ZhuangXiu.EditZhuangXiu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>任务登记</title>
    <script src="../js/Page/Comm/PinYin.js?t=<%=base.getToken() %>"></script>
    <script>
        var ID, ProjectID, tdChargeName;
        $(function () {
            ID = "<%=Request.QueryString["ID"]%>";
            ProjectID = "<%=this.zhuangxiu.RoomID%>";
            tdChargeName = $('#<%=this.tdChargeName.ClientID%>');
            addFile();
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
                        show_message("装修记录不存在", "info");
                    }
                    else {
                        show_message('系统错误', 'error');
                    }
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
                            $html += '<a href="#" onclick="deleteAttach(' + item.ID + ')">删除</a></div>';
                        })
                        $html += '</td>';
                    }
                    $("#trExistFiles").append($html);
                }
            });
        }
        function deleteAttach(AttachID) {
            top.$.messager.confirm("提示", "是否删除选已上传的文件?", function (r) {
                if (r) {
                    var options = { visit: 'deletefile', ID: AttachID };
                    $.ajax({
                        type: 'POST',
                        dataType: 'json',
                        url: '../Handler/ZhuangXiuHandler.ashx',
                        data: options,
                        success: function (message) {
                            if (message.status) {
                                show_message('删除成功', 'success', function () {
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
                <td colspan="4" style="text-align: center; font-size: 15px; padding: 5px;">修改装修申请</td>
            </tr>
            <tr>
                <td>装修房号</td>
                <td>
                    <input type="text" runat="server" data-options="required:true,readonly:true" name="RoomName" class="easyui-textbox" id="tdRoomName" />
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
            <tr id="trExistFiles" style="display: none;">
            </tr>
            <tr>
                <td>附件</td>
                <td colspan="3" id="tdFile"></td>
            </tr>
            <tr>
                <td colspan="4" style="text-align: center;">
                    <%if (approve == null || approve.ApproveStatus.Equals("不通过"))
                      { %>
                    <a href="javascript:void(0)" onclick="saveData()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-save'">保存</a>
                    <a href="javascript:void(0)" onclick="()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-save'">关闭</a>
                    <%} %>
                    <%else
                      { %>
                     已审批. 
                    <%if (approve.AddTime > DateTime.MinValue)
                      { %>
                    审批时间: <%=approve.AddTime.ToString("yyyy-MM-dd HH:mm:ss")%>
                    <%}
                      } %>
                </td>
            </tr>
        </table>
    </form>
</asp:Content>
