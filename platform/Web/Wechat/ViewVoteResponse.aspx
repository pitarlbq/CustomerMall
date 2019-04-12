<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="ViewVoteResponse.aspx.cs" Inherits="Web.Wechat.ViewVoteResponse" %>

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
                    TotalCount: 0,
                    TotalPeopleCount: 0
                },
                methods: {
                    getdata: function () {
                        var that = this;
                        that.SurveyID = "<%=this.SurveyID%>";
                        var options = { visit: 'getsurveyvoteresponse', ID: that.SurveyID };
                        MaskUtil.mask();
                        $.ajax({
                            type: 'POST',
                            dataType: 'json',
                            url: '../Handler/WechatHandler.ashx',
                            data: options,
                            success: function (data) {
                                MaskUtil.unmask();
                                if (data.status) {
                                    that.questions = data.list;
                                    that.TotalCount = data.TotalCount;
                                    that.TotalPeopleCount = data.TotalPeopleCount;
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
            width: 100%;
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

            .survey_title span {
                margin-right: 10px;
            }

        .content_box {
            float: left;
            width: 200px;
            margin: 10px;
            text-align: center;
        }

            .content_box .content_item {
                text-align: center;
            }

                .content_box .content_item.question_title {
                    background-color: #00bcd4;
                    color: #fff;
                    height: 25px;
                    line-height: 25px;
                    padding: 0 10px;
                }

                .content_box .content_item.question_img img {
                    width: 200px;
                    height: 200px;
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
                <span>投票总人数: {{TotalPeopleCount}}</span>
                投票总次数: {{TotalCount}}
            </div>
            <div v-for="item in questions" class="content_box">
                <div class="content_item question_img">
                    <img v-bind:src="item.imageurl" />
                </div>
                <div class="content_item question_title">{{item.title}}</div>
                <div class="content_item question_count">{{item.votecountdesc}}</div>
            </div>
        </div>
    </div>
</asp:Content>
