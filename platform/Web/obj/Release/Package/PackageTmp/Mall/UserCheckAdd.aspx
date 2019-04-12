<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="UserCheckAdd.aspx.cs" Inherits="Web.Mall.UserCheckAdd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        var ID, filecount = 0, tdUserName, hdUserIDs, op, RequestType;
        $(function () {
            ID = "<%=this.CheckID%>";
            RequestType = "<%=this.RequestType%>";
            tdUserName = $('#<%=this.tdUserName.ClientID%>');
            hdUserIDs = $('#<%=this.hdUserIDs.ClientID%>');
            op = '<%=this.op%>';
            loadattachs();
            addFile();
        });
        function addFile() {
            $("#tdFile").find("a.fileadd").hide();
            $("#tdFile").find("a.fileremove").show();
            filecount++;
            var $html = "<div id=\"tdFile_" + filecount + "\">";
            $html += "<input class=\"easyui-filebox\" name=\"attachfile\" data-options=\"prompt:'请选择图片',buttonText: '选择图片'\" style=\"width: 60%\" />";
            $html += "<a href=\"javascript:void(0)\" onclick=\"addFile()\" class=\"easyui-linkbutton btnlinkbar fileadd\" data-options=\"plain:true,iconCls:'icon-add'\">添加</a>";
            $html += "<a href=\"javascript:void(0)\" onclick=\"deleteFile(" + filecount + ")\" class=\"easyui-linkbutton btnlinkbar fileremove\" style=\"display:none;\" data-options=\"plain:true,iconCls:'icon-remove'\">删除</a>";
            $html += "</div>";
            $("#tdFile").append($html);
            $.parser.parse("#tdFile_" + filecount);
        }
        function deleteFile(id) {
            $("#tdFile_" + id).html("");
        }
        function loadattachs() {
            if (ID <= 0) {
                return;
            }
            var options = { visit: 'getmallcheckrequestattachs', ID: ID };
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/MallHandler.ashx',
                data: options,
                success: function (data) {
                    var $html = '';
                    $("#trExistFiles").hide();
                    $("#trExistFiles").html($html);
                    if (data.status) {
                        if (data.list.length > 0) {
                            $("#trExistFiles").show();
                            $html += '<td>已上传图片</td>';
                            $html += '<td colspan="3">';
                            $.each(data.list, function (index, item) {
                                $html += '<div class="image_box"><a href="' + item.ImagePath + '" target="_blank" ><image src="' + item.ImagePath + '"></a><br/>';
                                $html += '<a href="#" onclick="deleteAttach(' + item.index + ')">删除</a></div>';
                            })
                            $html += '</td>';
                            $("#trExistFiles").append($html);
                        }
                    }
                }
            });
        }
        function deleteAttach(index) {
            top.$.messager.confirm("提示", "是否删除选已上传的图片?", function (r) {
                if (r) {
                    var options = { visit: 'deletemallcheckrequestattach', index: index, ID: ID };
                    $.ajax({
                        type: 'POST',
                        dataType: 'json',
                        url: '../Handler/MallHandler.ashx',
                        data: options,
                        success: function (message) {
                            if (message.status) {
                                show_message('操作成功', 'success', function () {
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
        function do_save() {
            var isValid = $("#<%=this.ff.ClientID%>").form('enableValidation').form('validate');
            if (!isValid) {
                return;
            }
            var can_save = true;
            $.each(content.list, function (index, item) {
                if (RequestType == 1) {
                    if (item.StartPoint > item.PointValue || item.EndPoint < item.PointValue) {
                        can_save = false;
                        return false;
                    }
                }
            })
            if (!can_save) {
                show_message("奖扣分值没有在预设区间内", "info");
                return;
            }
            MaskUtil.mask('body', '提交中');
            $('#ff').form('submit', {
                url: '../Handler/MallHandler.ashx',
                onSubmit: function (param) {
                    param.visit = 'savemallusercheck';
                    param.ID = ID;
                    param.UserIDList = hdUserIDs.val();
                    param.RuleList = JSON.stringify(content.list);
                },
                success: function (data) {
                    MaskUtil.unmask();
                    var dataObj = eval("(" + data + ")");
                    if (dataObj.status) {
                        show_message('保存成功', 'success', function () {
                            do_close();
                        });
                        return;
                    }
                    if (dataObj.error) {
                        show_message(dataObj.error, 'warning');
                        return;
                    }
                    show_message('系统错误', 'error');
                }
            });
        }
        function chooseuser() {
            var title = '选择员工';
            var iframe = "../Mall/ChooseStaffUser.aspx?from=UserCheckAdd";
            do_open_dialog(title, iframe);
        }
        function do_close() {
            parent.do_close_dialog(function () {
                parent.$('#tt_table').datagrid('reload');
            });
        }
    </script>
    <script src="../js/vue.js"></script>
    <script>
        var content;
        $(function () {
            vue_reset();
        })
        function vue_reset() {
            content = new Vue({
                el: '#fieldcontent',
                data: {
                    list: [],
                    count: 0,
                    isshown: true
                },
                methods: {
                    getdata: function () {
                        var that = this;
                        if (ID <= 0) {
                            return;
                        }
                        var options = { visit: 'getmallcheckrequestrulelist', RequestID: ID };
                        $.ajax({
                            type: 'POST',
                            dataType: 'json',
                            url: '../Handler/MallHandler.ashx',
                            data: options,
                            success: function (data) {
                                if (data.status) {
                                    that.list = data.list;
                                    that.count = data.list.length;
                                }
                            }
                        });
                    },
                    add_line: function () {
                        var that = this;
                        var iframe = "<iframe id='myFrame' scrolling='auto' frameborder='0' src='../Mall/CheckRuleChoose.aspx' style='width:100%;height:" + ($(parent.window).height() - 40) + "px'></iframe>";
                        $("<div id='winchoose'></div>").appendTo("body").window({
                            title: '选择考核标准',
                            width: ($(parent.window).width() - 200),
                            height: $(parent.window).height(),
                            top: 0,
                            left: 100,
                            modal: true,
                            minimizable: false,
                            maximizable: false,
                            collapsible: false,
                            content: iframe,
                            onClose: function () {
                                if (that.form != null) {
                                    that.list.push(that.form);
                                }
                                $('#winchoose').remove();
                            }
                        });
                    },
                    remove_line: function (item) {
                        var that = this;
                        if (item.ID == 0) {
                            $.each(that.list, function (index, item2) {
                                if (item.count == item2.count) {
                                    that.list.splice(index, 1);
                                    return false;
                                }
                            });
                            return;
                        }
                        top.$.messager.confirm('提示', '确认删除?', function (r) {
                            if (r) {
                                var options = { visit: 'removemallcheckrequestrule', ID: item.ID };
                                $.ajax({
                                    type: 'POST',
                                    dataType: 'json',
                                    url: '../Handler/MallHandler.ashx',
                                    data: options,
                                    success: function (data) {
                                        if (data.status) {
                                            that.getdata();
                                            return;
                                        }
                                        show_message('系统错误', 'error');
                                    }
                                });
                            }
                        })
                    }
                }
            });
            content.getdata();
            if (RequestType == 2) {
                content.isshown = false;
            }
        }
    </script>
    <style>
        .panel-body {
            background: #f0f0f0;
        }

        .image_box {
            min-width: 100px;
            display: inline-block;
            margin-right: 10px;
            text-align: center;
        }

            .image_box img {
                height: 100px;
            }


        table.info table.field {
            width: 100%;
            border: solid 1px #ccc;
            border-spacing: 0;
            border-collapse: collapse;
        }

            table.info table.field td {
                border: solid 1px #ccc;
                padding: 10px;
                text-align: left;
                width: 15%;
            }

                table.info table.field td input[type=text] {
                    width: 100px;
                }

            table.info table.field input[type=text] {
                padding: 2px 8px;
                border: solid 1px #ddd;
                border-radius: 5px !important;
            }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <form id="ff" runat="server" method="post" enctype="multipart/form-data">
        <div class="operation_box">
            <%if (!op.Equals("view"))
              {%>
            <a href="javascript:void(0)" onclick="do_save()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-save'">保存</a>
            <%} %>
            <a href="javascript:void(0)" onclick="do_close()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-close'">关闭</a>
        </div>
        <div class="table_container">
            <table class="info">
                <tr>
                    <td colspan="4" style="padding: 0;">
                        <div id="fieldcontent">
                            <table class="field">
                                <%if (!op.Equals("view"))
                                  {%>
                                <tr v-if="isshown">
                                    <td colspan="6">
                                        <a href="javascript:void(0)" v-on:click="add_line()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-add'">添加考评标准</a>
                                    </td>
                                </tr>
                                <%} %>
                                <tr>
                                    <td>项目类别
                                    </td>
                                    <td>项目名称
                                    </td>
                                    <td>标准名称
                                    </td>
                                    <td>分值范围
                                    </td>
                                    <td>奖扣分值
                                    </td>
                                    <td></td>
                                </tr>
                                <tr v-for="(item, index) in list">
                                    <td>{{item.CategoryTypeDesc}}
                                    </td>
                                    <td>{{item.CategoryName}}
                                    </td>
                                    <td>{{item.CheckName}}
                                    </td>
                                    <td>{{item.PointRange}}
                                    </td>
                                    <td>
                                        <input type="text" v-model="item.PointValue" />
                                    </td>
                                    <td>
                                        <%if (!op.Equals("view"))
                                          {%>
                                        <a v-if="isshown" href="javascript:void(0)" v-on:click="remove_line(item)" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-remove'">删除</a>
                                        <%} %>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>考评员工
                    </td>
                    <td colspan="3">
                        <input type="text" class="easyui-textbox" runat="server" id="tdUserName" data-options="required:true,readonly:true,multiline:true" style="height: 60px; width: 80%" />
                        <asp:HiddenField runat="server" ID="hdUserIDs" />
                        <%if (!op.Equals("view"))
                          {%>
                        <label>
                            <a v-if="isshown" href="javascript:void(0)" onclick="chooseuser()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-choose'">选择</a>
                        </label>
                        <%} %>
                    </td>
                </tr>
                <tr id="trExistFiles" style="display: none;">
                </tr>
                <%if (!op.Equals("view"))
                  {%>
                <tr>
                    <td>上传图片</td>
                    <td colspan="3" id="tdFile"></td>
                </tr>
                <%} %>
                <tr>
                    <td>考核说明</td>
                    <td colspan="3">
                        <input type="text" id="tdRemark" runat="server" data-options="multiline:true" style="width: 80%; height: 60px" class="easyui-textbox" />
                    </td>
                </tr>
                <tr>
                    <td colspan="4" style="text-align: center;"></td>
                </tr>
            </table>
        </div>
    </form>
</asp:Content>
