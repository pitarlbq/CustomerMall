<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="AddXunJian.aspx.cs" Inherits="Web.ZhuangXiu.AddXunJian" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>装修审批</title>
    <script>
        var ID, hdWeiGuiProject, tdWeiGuiProject;
        $(function () {
            ID = "<%=Request.QueryString["ID"]%>";
            hdWeiGuiProject = $("#<%=this.hdWeiGuiProject.ClientID%>");
            tdWeiGuiProject = $("#<%=this.tdWeiGuiProject.ClientID%>");
            $(".trNoField").hide();
            $("#<%=this.ZhengChang.ClientID%>").bind('click', function () {
                $(".trNoField").hide();
            })
            $("#<%=this.WeiGui.ClientID%>").bind('click', function () {
                $(".trNoField").show();
            })
            var list = eval("(" + hdWeiGuiProject.val() + ")");
            tdWeiGuiProject.combobox({
                multiple: true,
                editable: false,
                data: list,
                valueField: 'ID',
                textField: 'Name',
            });
            addFile();
            loadattachs();
        });
        function saveData() {
            var isValid = $("#<%=this.ff.ClientID%>").form('enableValidation').form('validate');
            if (!isValid) {
                return;
            }
            $('#ff').form('submit', {
                url: '../Handler/ZhuangXiuHandler.ashx',
                onSubmit: function (param) {
                    param.visit = 'savexunjian';
                    param.ID = ID;
                    param.AddMan = "<%=Web.WebUtil.GetUser(this.Context).RealName%>";
                    param.WeiGuiRuleIDs = JSON.stringify(tdWeiGuiProject.combobox('getValues'));
                    //param.WeiGuiRuleName = tdWeiGuiProject.combobox('getText');
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
        function closeWin() {
            parent.$("#winadd").window("close");
        }
        function loadattachs() {
            var options = { visit: 'loadzhuangxiuattachs', ID: ID, FileType: "addxunjian" };
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
            $html += '<a href="javascript:void(0)" onclick="addFile()" class="easyui-linkbutton btnlinkbar fileadd" data-options="plain:true,iconCls:\'icon-add\'">添加</a>';
            $html += '<a href="javascript:void(0)" onclick="deleteFile(' + filecount + ')" class="easyui-linkbutton btnlinkbar fileremove" style=\"display:none;\" data-options="plain:true,iconCls:\'icon-add\'">删除</a>';
            $html += "</div>";
            $("#tdFile").append($html);
            $.parser.parse("#tdFile_" + filecount);
        }
        function deleteFile(id) {
            $("#tdFile_" + id).html("");
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

        select, textarea {
            width: 80%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <form id="ff" runat="server" method="post" enctype="multipart/form-data">
        <table class="info">
            <tr>
                <td colspan="4" style="text-align: center; font-size: 15px; padding: 5px;">巡检</td>
            </tr>
            <tr>
                <td>巡检日期</td>
                <td>
                    <input type="text" runat="server" data-options="required:true" name="XunJianTime" class="easyui-datebox" id="tdXunJianTime" />
                </td>
                <td>巡检人</td>
                <td>
                    <input type="text" runat="server" data-options="required:true" name="XunJianMan" class="easyui-textbox" id="tdXunJianMan" />
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:RadioButton runat="server" ID="ZhengChang" Checked="true" GroupName="XunJianStatus" Text="正常巡检" /></td>
                <td colspan="2">
                    <asp:RadioButton runat="server" ID="WeiGui" GroupName="XunJianStatus" Text="违规登记" /></td>
            </tr>
            <tr class="trNoField">
                <td>巡检项目</td>
                <td colspan="3" style="width: 85%;">
                    <input runat="server" name="WeiGuiProject" class="easyui-combobox" id="tdWeiGuiProject" style="width: 350px; height: 50px;" data-options="multiline:true" />
                    <asp:HiddenField runat="server" ID="hdWeiGuiProject" />
                </td>
            </tr>
            <tr class="trNoField">
                <td>违规罚款</td>
                <td colspan="3">
                    <input type="text" runat="server" name="WeiGuiCost" class="easyui-textbox" id="tdWeiGuiCost" style="width: 80%;" /></td>
            </tr>
            <tr id="trExistFiles" style="display: none;">
            </tr>
            <tr>
                <td>附件</td>
                <td colspan="3" id="tdFile"></td>
            </tr>
            <tr>
                <td>备注</td>
                <td colspan="3">
                    <input type="text" runat="server" name="Remark" data-options="multiline:true" class="easyui-textbox" id="tdRemark" style="width: 80%; height: 50px;" /></td>
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
