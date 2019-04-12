<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="ViewSurveyResponse.aspx.cs" Inherits="Web.Wechat.ViewSurveyResponse" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../js/vue.js"></script>
    <script type="text/javascript">
        var content;
        $(function () {
            content = new Vue({
                el: '#fieldcontent',
                data: {
                    questions: [],
                    SurveyID: 0,
                    RoomStateList: [],
                    TotalCount: 0
                },
                methods: {
                    getdata: function () {
                        var that = this;
                        that.SurveyID = "<%=this.SurveyID%>";
                        var options = { visit: 'getsurveyresponse', ID: that.SurveyID };
                        MaskUtil.mask();
                        $.ajax({
                            type: 'POST',
                            dataType: 'json',
                            url: '../Handler/WechatHandler.ashx',
                            data: options,
                            success: function (data) {
                                MaskUtil.unmask();
                                if (data.status) {
                                    that.questions = data.questions;
                                    that.TotalCount = data.TotalCount;
                                    return;
                                }
                                if (data.error) {
                                    show_message(data.error, "info");
                                    return;
                                }
                                show_message('系统错误', 'error');
                            }
                        });
                    },
                    closeWin: function () {
                        parent.$("#winadd").window("close");
                    }
                }
            });
            content.getdata();
        })
        function do_close() {
            parent.do_close_dialog();
        }
    </script>
    <style>
        .main_content {
            width: 90%;
            margin: 0 auto;
        }

        .survey_title {
            margin: 10px 0;
            width: 100%;
            padding: 10px;
            font-size: 14px;
            background-color: #0094ff;
            color: #fff;
            border-radius: 3px;
            text-align: center;
        }

        .question_title {
            width: 100%;
            padding: 10px;
            font-size: 13px;
            background-color: #ccc;
            color: #fff;
            border-radius: 3px;
        }

        .option_content {
            width: 50%;
            padding: 10px;
            font-size: 12px;
            display: inline-table;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <div class="operation_box">
        <a href="javascript:void(0)" onclick="do_close()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-close'">关闭</a>
    </div>
    <div class="table_container">
        <div id="fieldcontent" class="main_content">
            <div class="survey_title">
                共{{TotalCount}}人参与投票
            </div>
            <div v-for="item in questions">
                <div class="question_title">{{item.Title}}</div>
                <div class="option_content" v-for="item2 in item.options">{{item2.Content}}({{item2.TotalCount}}人)</div>
            </div>
        </div>
    </div>
</asp:Content>
