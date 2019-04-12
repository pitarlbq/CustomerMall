<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="EditSurveyQuestion.aspx.cs" Inherits="Web.Wechat.EditSurveyQuestion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../js/vue.js"></script>
    <script type="text/javascript">
        var SurveyID, QuestionID, content;
        $(function () {
            SurveyID = "<%=this.SurveyID%>";
            QuestionID = "<%=this.QuestionID%>";
            content = new Vue({
                el: '#fieldcontent',
                data: {
                    list: [],
                    count: 0
                },
                methods: {
                    getdata: function () {
                        var that = this;
                        if (QuestionID <= 0) {
                            return;
                        }
                        var options = { visit: 'getsurveyquestionoptions', QuestionID: QuestionID };
                        $.ajax({
                            type: 'POST',
                            dataType: 'json',
                            url: '../Handler/WechatHandler.ashx',
                            data: options,
                            success: function (data) {
                                if (data.status) {
                                    that.list = data.list;
                                    that.count = that.list.length;
                                    return;
                                }
                                show_message('系统错误', 'error');
                            }
                        });
                    },
                    add_line: function () {
                        var that = this;
                        that.count++;
                        var item = { ID: 0, OptionContent: '', SortOrder: 0, count: that.count };
                        that.list.push(item);
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
                                var options = { visit: 'removesurveyquestionoption', ID: item.ID };
                                $.ajax({
                                    type: 'POST',
                                    dataType: 'json',
                                    url: '../Handler/WechatHandler.ashx',
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
        });
        function do_save() {
            var isValid = $("#<%=this.ff.ClientID%>").form('enableValidation').form('validate');
            if (!isValid) {
                return;
            }
            MaskUtil.mask('body', '提交中');
            $('#ff').form('submit', {
                url: '../Handler/WechatHandler.ashx',
                onSubmit: function (param) {
                    param.visit = 'savewechatsurveyquestion';
                    param.QuestionID = QuestionID;
                    param.SurveyID = SurveyID;
                    param.options = JSON.stringify(content.list);
                },
                success: function (data) {
                    MaskUtil.unmask();
                    var dataObj = eval("(" + data + ")");
                    if (dataObj.status) {
                        show_message('保存成功', 'success', function () {
                            do_close();
                        });
                    }
                    else {
                        show_message('系统错误', 'error');
                    }
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

        table.field {
            width: 96%;
            margin: 0 auto;
            border: solid 1px #ccc;
            border-spacing: 0;
            border-collapse: collapse;
            background: #fff;
        }

            table.field td {
                border: solid 1px #ccc;
                padding: 2px 5px;
            }

                table.field td input {
                    height: 25px;
                    border-radius: 5px !important;
                }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <form id="ff" runat="server" method="post" enctype="multipart/form-data">
        <div class="operation_box">
            <a href="javascript:void(0)" onclick="do_save()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-save'">保存</a>
            <a href="javascript:void(0)" onclick="do_close()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-close'">关闭</a>
        </div>
        <div class="table_container">
            <table class="info">
                <tr>
                    <td>标题
                    </td>
                    <td colspan="3">
                        <input type="text" style="width: 70%;" class="easyui-textbox" id="tdQuestionContent" runat="server" data-options="required:true" />
                    </td>
                </tr>
                <tr class="detail">
                    <td>类型
                    </td>
                    <td>
                        <select type="text" class="easyui-combobox" id="tdQuestionType" runat="server">
                            <option value="1">单选</option>
                            <option value="2">多选</option>
                        </select>
                    </td>
                </tr>
                <tr>
                    <td>排序
                    </td>
                    <td colspan="3">
                        <input type="text" style="width: 70%;" class="easyui-textbox" id="tdSortOrder" runat="server" data-options="required:true" />
                    </td>
                </tr>
            </table>
            <div class="table_title">选项</div>
            <div id="fieldcontent">
                <table class="field">
                    <tr>
                        <td colspan="3">
                            <a href="javascript:void(0)" v-on:click="add_line()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-add'">添加</a>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 50%;">内容
                        </td>
                        <td>排序
                        </td>
                        <td></td>
                    </tr>
                    <tr v-for="(item, index) in list">
                        <td>
                            <input type="text" v-model="item.OptionContent" />
                        </td>
                        <td>
                            <input type="text" v-model="item.SortOrder" />
                        </td>
                        <td>
                            <a href="javascript:void(0)" v-on:click="remove_line(item)" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-remove'">删除</a>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </form>
</asp:Content>
