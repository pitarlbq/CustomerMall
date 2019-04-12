<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="EditInsideCustomer.aspx.cs" Inherits="Web.InsideCustomer.EditInsideCustomer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../js/toast/jquery.toast.js"></script>
    <link href="../js/toast/jquery.toast.css" rel="stylesheet" />
    <script type="text/javascript">
        var IndustryNameList = [], CategoryNameList = [], InterestingList = [], GroupInvitationList = [], RegionList = [], BusinessStageList = [], DealProbablyList = [];
        var ID = 0;
        $(function () {
            getDataList();
            ID = '<%=Request.QueryString["ID"]%>';
            addFile();
            loadattachs();
        })
        function getDataList() {
            CategoryNameList.push({ ID: "共同资源", Name: "共同资源" });
            CategoryNameList.push({ ID: "有效客户", Name: "有效客户" });
            CategoryNameList.push({ ID: "无效客户", Name: "无效客户" });
            CategoryNameList.push({ ID: "线索客户", Name: "线索客户" });
            CategoryNameList.push({ ID: "商机客户", Name: "商机客户" });
            CategoryNameList.push({ ID: "成交客户", Name: "成交客户" });
            CategoryNameList.push({ ID: "流失客户", Name: "流失客户" });
            $('#<%=this.tdCategoryName.ClientID%>').combobox({
                data: CategoryNameList,
                valueField: 'ID',
                textField: 'Name'
            })

            InterestingList.push({ ID: "使用软件", Name: "使用软件" });
            InterestingList.push({ ID: "竞品代理", Name: "竞品代理" });
            InterestingList.push({ ID: "有意了解", Name: "有意了解" });
            InterestingList.push({ ID: "意向不明", Name: "意向不明" });
            InterestingList.push({ ID: "不愿沟通", Name: "不愿沟通" });
            $('#<%=this.tdInteresting.ClientID%>').combobox({
                data: InterestingList,
                valueField: 'ID',
                textField: 'Name'
            })

            GroupInvitationList.push({ ID: "在", Name: "在" });
            GroupInvitationList.push({ ID: "不在", Name: "不在" });
            $('#<%=this.tdQQGroupInvitation.ClientID%>').combobox({
                data: GroupInvitationList,
                valueField: 'ID',
                textField: 'Name'
            })
            $('#<%=this.tdWechaGroupInvitation.ClientID%>').combobox({
                data: GroupInvitationList,
                valueField: 'ID',
                textField: 'Name'
            })

            BusinessStageList.push({ ID: "演示", Name: "演示" });
            BusinessStageList.push({ ID: "报价", Name: "报价" });
            BusinessStageList.push({ ID: "合同", Name: "合同" });
            $('#<%=this.tdBusinessStage.ClientID%>').combobox({
                data: BusinessStageList,
                valueField: 'ID',
                textField: 'Name'
            })

            DealProbablyList.push({ ID: "可能成交", Name: "可能成交" });
            DealProbablyList.push({ ID: "意向明确", Name: "意向明确" });
            $('#<%=this.tdDealProbably.ClientID%>').combobox({
                data: DealProbablyList,
                valueField: 'ID',
                textField: 'Name'
            })

        }
        function do_save(showpop) {
            var isValid = $("#ff").form('enableValidation').form('validate');
            if (!isValid) {
                return;
            }
            var row = {};
            row.ID = ID;
            row.CustomerName = $('#<%=this.tdCustomerName.ClientID%>').textbox('getValue');
            row.CategoryName = $('#<%=this.tdCategoryName.ClientID%>').combobox('getValue');
            row.Interesting = $('#<%=this.tdInteresting.ClientID%>').combobox('getValue');
            row.ContactMan = $('#<%=this.tdContactMan.ClientID%>').textbox('getValue');
            row.ContactPhone = $('#<%=this.tdContactPhone.ClientID%>').textbox('getValue');
            row.QQNo = $('#<%=this.tdQQNo.ClientID%>').textbox('getValue');
            row.QQGroupInvitation = $('#<%=this.tdQQGroupInvitation.ClientID%>').combobox('getValue');
            row.WechatNo = $('#<%=this.tdWechatNo.ClientID%>').textbox('getValue');
            row.WechaGroupInvitation = $('#<%=this.tdWechaGroupInvitation.ClientID%>').combobox('getValue');
            row.OtherContactMan = $('#<%=this.tdOtherContactMan.ClientID%>').textbox('getValue');
            row.NewFollowup = $('#<%=this.tdNewFollowup.ClientID%>').textbox('getValue');
            row.BusinessStage = $('#<%=this.tdBusinessStage.ClientID%>').combobox('getValue');
            row.Cost = $('#<%=this.tdCost.ClientID%>').textbox('getValue');
            row.DealProbably = $('#<%=this.tdDealProbably.ClientID%>').combobox('getValue');
            row.Remark = $('#<%=this.tdRemark.ClientID%>').textbox('getValue');
            MaskUtil.mask('body', '提交中');
            $('#ff').form('submit', {
                url: '../Handler/CommHandler.ashx',
                onSubmit: function (param) {
                    param.visit = 'genjininsidecustomer';
                    param.List = JSON.stringify(row);
                },
                success: function (data) {
                    MaskUtil.unmask();
                    var message = eval("(" + data + ")");
                    if (showpop) {
                        if (message.status == 1) {
                            show_message('操作成功', 'success');
                            loadattachs();
                            return;
                        }
                        else {
                            show_message('系统错误', 'error');
                        }
                    }
                    else {
                        goNextItem();
                    }
                }
            });
        }
        function goNextItem() {
            var options = { visit: 'getnextinsidecustomer', ID: ID };
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/CommHandler.ashx',
                data: options,
                success: function (data) {
                    if (data.status) {
                        if (data.ID > 0) {
                            window.location.href = '../InsideCustomer/EditInsideCustomer.aspx?ID=' + data.ID;
                        }
                        else {
                            $.toast({
                                text: "已到最后一条",
                                icon: 'info',
                                hideAfter: 2000,
                                position: 'mid-center'
                            });
                        }
                        return;
                    }
                    else {
                        show_message('系统错误', 'error');
                    }
                }
            });
        }
        function loadattachs() {
            var options = { visit: 'loadincustomerattachs', ID: ID };
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/CommHandler.ashx',
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
                    var options = { visit: 'deleteinsidecustomerfile', ID: AttachID };
                    $.ajax({
                        type: 'POST',
                        dataType: 'json',
                        url: '../Handler/CommHandler.ashx',
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
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <style type="text/css">
        .panel-body {
            background: #f0f0f0;
        }
    </style>
    <form id="ff" method="post" runat="server" enctype="multipart/form-data">
        <div class="operation_box">
            <a href="javascript:void(0)" onclick="do_save(true)" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-save'">保存</a>
            <a href="javascript:void(0)" onclick="do_close()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-close'">关闭</a>
            <a href="javascript:void(0)" onclick="do_save(false)" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-edit'">下一条</a>
        </div>
        <div class="table_container">
            <table class="info">
                <tr>
                    <td>客户名称
                    </td>
                    <td>
                        <input id="tdCustomerName" class="easyui-textbox" runat="server" type="text" data-options="required:true" />
                    </td>
                    <td>分类
                    </td>
                    <td>
                        <input class="easyui-combobox" id="tdCategoryName" runat="server" type="text" />
                    </td>
                </tr>
                <tr>

                    <td>意向分析
                    </td>
                    <td>
                        <input class="easyui-combobox" id="tdInteresting" runat="server" type="text" />
                    </td>
                    <td>联系人
                    </td>
                    <td>
                        <input class="easyui-textbox" id="tdContactMan" runat="server" type="text" />
                    </td>

                </tr>
                <tr>
                    <td>联系方式
                    </td>
                    <td>
                        <input class="easyui-textbox" id="tdContactPhone" runat="server" type="text" />
                    </td>
                    <td>QQ
                    </td>
                    <td>
                        <input class="easyui-textbox" id="tdQQNo" runat="server" type="text" />
                    </td>
                </tr>
                <tr>
                    <td>QQ群邀约
                    </td>
                    <td>
                        <input class="easyui-combobox" id="tdQQGroupInvitation" runat="server" type="text" />
                    </td>
                    <td>微信
                    </td>
                    <td>
                        <input class="easyui-textbox" id="tdWechatNo" runat="server" type="text" />
                    </td>
                </tr>
                <tr>
                    <td>微信群邀约
                    </td>
                    <td>
                        <input class="easyui-combobox" id="tdWechaGroupInvitation" runat="server" type="text" />
                    </td>
                    <td>其他联系人
                    </td>
                    <td>
                        <input class="easyui-textbox" id="tdOtherContactMan" runat="server" type="text" />
                    </td>
                </tr>
                <tr>
                    <td>当前跟进
                    </td>
                    <td colspan="3">
                        <input class="easyui-textbox" data-options="multiline:true" style="width: 80%; height: 60px;" id="tdNewFollowup" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>跟进记录
                    </td>
                    <td colspan="3">
                        <input class="easyui-textbox" data-options="multiline:true" style="width: 80%; height: 60px;" id="tdHistoryNewFollowup" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>商务阶段
                    </td>
                    <td>
                        <input class="easyui-combobox" id="tdBusinessStage" runat="server" />
                    </td>
                    <td>报价
                    </td>
                    <td>
                        <input class="easyui-textbox" id="tdCost" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>成交可能性
                    </td>
                    <td>
                        <input class="easyui-combobox" id="tdDealProbably" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>备注
                    </td>
                    <td colspan="3">
                        <input class="easyui-textbox" data-options="multiline:true" id="tdRemark" style="width: 80%; height: 60px;" runat="server" />
                    </td>
                </tr>
                <tr id="trExistFiles" style="display: none;">
                </tr>
                <tr>
                    <td>附件</td>
                    <td colspan="3" id="tdFile"></td>
                </tr>
            </table>
        </div>
    </form>
</asp:Content>
