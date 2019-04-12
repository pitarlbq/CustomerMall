<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="ApproveContract.aspx.cs" Inherits="Web.Contract.ApproveContract" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>合同批准</title>
    <script src="../js/Page/Comm/PinYin.js?t=<%=base.getToken() %>"></script>
    <script>
        var ID, ContractID, ApproveID;
        $(function () {
            ID = 0;
            addFile();
            ContractID = "<%=Request.QueryString["ID"]%>";
            ApproveID = "<%=this.ApproveID%>";
            if (Number(ApproveID) > 0) {
                loadattachs();
            }
        });

        function do_save() {
            var isValid = $("#<%=this.ff.ClientID%>").form('enableValidation').form('validate');
            if (!isValid) {
                return;
            }
            $('#ff').form('submit', {
                url: '../Handler/ContractHandler.ashx',
                onSubmit: function (param) {
                    param.visit = 'saveapprove';
                    param.ID = ID;
                    param.ContractID = ContractID;
                    param.AddMan = "<%=Web.WebUtil.GetUser(this.Context).RealName%>";
                },
                success: function (data) {
                    var dataObj = eval("(" + data + ")");
                    if (dataObj.status) {
                        if (dataObj.ID > 0) {
                            createFee();
                            return;
                        }
                        show_message("审核记录不存在", "warning");
                    }
                    else {
                        show_message('系统错误', 'error');
                    }
                }
            });
        }
        function loadattachs() {
            var options = { visit: 'loadcontractattachs', ID: ApproveID, FileType: "approve" };
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/ContractHandler.ashx',
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
                        url: '../Handler/ContractHandler.ashx',
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
            $html += "<a href=\"javascript:void(0)\" onclick=\"addFile()\" class=\"easyui-linkbutton btnlinkbar fileadd\" data-options=\"plain:true,iconCls:'icon-add'\">添加</a>";
            $html += "<a href=\"javascript:void(0)\" onclick=\"deleteFile(" + filecount + ")\" class=\"easyui-linkbutton btnlinkbar fileremove\" style=\"display:none;\" data-options=\"plain:true,iconCls:'icon-remove'\">删除</a>";
            $html += "</div>";
            $("#tdFile").append($html);
            $.parser.parse("#tdFile_" + filecount);
        }
        function deleteFile(id) {
            $("#tdFile_" + id).html("");
        }
        function do_close() {
            parent.do_close_dialog(function () {
                parent.$('#tt_table').datagrid('reload');
            });
        }
        function createFee() {
            var IDList = [];
            MaskUtil.mask('body', '提交中');
            IDList.push(ContractID);
            var options = { visit: 'createcontractfee', IDList: JSON.stringify(IDList) };
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/ContractHandler.ashx',
                data: options,
                success: function (message) {
                    MaskUtil.unmask();
                    if (message.status) {
                        show_message("审核生效且费项生成成功", "success", function () {
                            do_close();
                        });
                        return;
                    }
                    show_message('系统错误', 'error');
                }
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
            <%if (approve != null && approve.ApproveStatus.Equals("审核通过"))
              { %>
            <%
              } %>
            <%else if (stop != null)
              { %>
            <%
              }%>
            <%else
              { %>
            <a href="javascript:void(0)" onclick="do_save()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-save'">保存</a>

            <%} %>
            <a href="javascript:void(0)" onclick="do_close()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-close'">关闭</a>
        </div>
        <div class="table_container">
            <table class="info">
                <tr>
                    <td colspan="4" style="text-align: center; font-size: 15px; padding: 5px;">审核生效</td>
                </tr>
                <tr>
                    <td>经手部门</td>
                    <td>
                        <input type="text" runat="server" name="JingShouTeam" class="easyui-textbox" id="tdJingShouTeam" /></td>
                    <td>经手人</td>
                    <td>
                        <input type="text" runat="server" name="JingShouPerson" class="easyui-textbox" id="tdJingShouPerson" /></td>
                </tr>
                <tr>
                    <td>共享角色</td>
                    <td>
                        <input type="text" runat="server" name="ShareRole" class="easyui-textbox" id="tdShareRole" /></td>
                    <td>审核时间</td>
                    <td>
                        <input type="text" runat="server" data-options="required:true" name="ApproveTime" class="easyui-datetimebox" id="tdApproveTime" />
                    </td>
                </tr>
                <tr>
                    <td>审核人</td>
                    <td>
                        <input type="text" runat="server" data-options="required:true" name="ApproveMan" class="easyui-textbox" id="tdApproveMan" /></td>
                    <td>运营模式</td>
                    <td>
                        <input type="text" runat="server" name="YunYingModel" class="easyui-textbox" id="tdYunYingModel" /></td>
                </tr>
                <tr>
                    <td>经营业态</td>
                    <td>
                        <input type="text" runat="server" name="BusinessYeTai" class="easyui-textbox" id="tdBusinessYeTai" />
                    </td>
                    <td>经营范围</td>
                    <td>
                        <input type="text" runat="server" name="BusinessRange" class="easyui-textbox" id="tdBusinessRange" />
                    </td>
                </tr>
                <tr>
                    <td>审核意见</td>
                    <td colspan="3">
                        <input type="text" runat="server" name="ApproveDesc" class="easyui-textbox" id="tdApproveDesc" data-options="multiline:true" style="width: 70%; height: 60px;" /></td>
                </tr>
                <tr id="trExistFiles" style="display: none;">
                </tr>
                <tr>
                    <td>附件</td>
                    <td colspan="3" id="tdFile"></td>
                </tr>
                <tr>

                    <td colspan="4" style="text-align: center;">
                        <%if (approve != null && approve.ApproveStatus.Equals("审核通过"))
                          { %>
                    已审核. 
                    <%if (approve.ApproveTime > DateTime.MinValue)
                      { %>
                    审核时间: <%=approve.ApproveTime.ToString("yyyy-MM-dd HH:mm:ss")%>
                        <%}
                          } %>
                        <%else if (stop != null)
                          { %>
                    已终止. 
                    <%if (stop.StopTime > DateTime.MinValue)
                      { %>
                    终止时间: <%=stop.StopTime.ToString("yyyy-MM-dd HH:mm:ss")%>
                        <%}
                          }%>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</asp:Content>
