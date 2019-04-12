<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="EditHouseService.aspx.cs" Inherits="Web.Wechat.EditHouseService" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../js/vue.js"></script>
    <script type="text/javascript" charset="utf-8" src="../js/ueditor/ueditor.config.js"></script>
    <script type="text/javascript" charset="utf-8" src="../js/ueditor/ueditor.all.js?v5"> </script>
    <script type="text/javascript" charset="utf-8" src="../js/ueditor/lang/zh-cn/zh-cn.js"></script>
    <script type="text/javascript">
        var ID, filecount = 0, type, tdUseOutLink, hdServiceIncude, hdServiceStandard, hdAppointNotify, ueServiceIncude, ueServiceStandard, ueAppointNotify;
        $(function () {
            type = "<%=this.type%>";
            tdUseOutLink = $('#<%=this.tdUseOutLink.ClientID%>');
            tdOutLinkURL = $('#<%=this.tdOutLinkURL.ClientID%>');
            hdServiceIncude = $('#<%=this.hdServiceIncude.ClientID%>');
            hdServiceStandard = $('#<%=this.hdServiceStandard.ClientID%>');
            hdAppointNotify = $('#<%=this.hdAppointNotify.ClientID%>');
            tdUseOutLink.combobox({
                onSelect: function (ret) {
                    check_outlink_status();
                }
            })
            ueServiceIncude = createEditor('tdServiceIncude', hdServiceIncude.val());
            ueServiceStandard = createEditor('tdServiceStandard', hdServiceStandard.val());
            ueAppointNotify = createEditor('tdAppointNotify', hdAppointNotify.val());
            check_outlink_status();
            get_combobox_params();
            addFile();
            ID = "<%=this.ID%>";
            if (Number(ID) > 0) {
                loadattachs();
            }
            loadVue();
        });
        function check_outlink_status() {
            var UseOutLink = tdUseOutLink.combobox('getValue');
            if (UseOutLink == 1) {
                $('.UseInLink').hide();
                $('.UseOutLink').show();
                $('#td_useoutlink').attr('colspan', '1');
            }
            else {
                $('.UseInLink').show();
                $('.UseOutLink').hide();
                $('#td_useoutlink').attr('colspan', '3');
            }
        }
        function createEditor(elemId, content) {
            window.SERVERAPPLICATION = "<%=Web.WebUtil.getApplicationPath()%>";
            var ue = UE.getEditor(elemId, {
                toolbars: [["fullscreen", "source", "|", "undo", "redo", "|", "bold", "italic", "underline", "fontborder", "strikethrough", "superscript", "subscript", "removeformat", "formatmatch", "autotypeset", "blockquote", "pasteplain", "|", "forecolor", "backcolor", "insertorderedlist", "insertunorderedlist", "selectall", "cleardoc", "|", "rowspacingtop", "rowspacingbottom", "lineheight", "|", "customstyle", "paragraph", "fontfamily", "fontsize", "|", "directionalityltr", "directionalityrtl", "indent", "|", "justifyleft", "justifycenter", "justifyright", "justifyjustify", "|", "touppercase", "tolowercase", "|", "link", "unlink", "anchor", "|", "emotion", "|", "horizontal", "date", "time", "spechars", "|", "preview", 'simpleupload', "help"
                ]],
                autoHeightEnabled: true,
                autoFloatEnabled: false,
                initialFrameHeight: 150
            });
            setTimeout(function () {
                ue.setContent(content, false);
            }, 1000);
            return ue;
        }
        function loadVue() {
            content = new Vue({
                el: '#fieldcontent',
                data: {
                    list: [],
                    count: 0
                },
                methods: {
                    getdata: function () {
                        var that = this;
                        if (ID <= 0) {
                            return;
                        }
                        var options = { visit: 'gethouseservicetype', ID: ID };
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
                        var item = { ID: 0, TypeName: '', BasicPrice: 0, UnitPrice: 0, Unit: '小时', Remark: '', count: that.count };
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
                                var options = { visit: 'removehouseservicetype', ID: item.ID };
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
        }

        function do_save() {
            var isValid = $("#<%=this.ff.ClientID%>").form('enableValidation').form('validate');
            if (!isValid) {
                return;
            }
            var IsWechatSend = 0;
            var IsUserAPPSend = 0;
            var IsCustomerAPPSend = 0;
            if ($('#<%=this.tdIsWechatSend.ClientID%>').prop('checked')) {
                IsWechatSend = 1;
            }
            if ($('#<%=this.tdIsCustomerAPPSend.ClientID%>').prop('checked')) {
                IsCustomerAPPSend = 1;
            }
            if ($('#<%=this.tdIsUserAPPSend.ClientID%>').prop('checked')) {
                IsUserAPPSend = 1;
            }
            if (IsWechatSend == 0 && IsCustomerAPPSend == 0 && IsUserAPPSend == 0) {
                show_message('请至少选择一项发布对象');
                return;
            }
            MaskUtil.mask('body', '提交中');
            $('#ff').form('submit', {
                url: '../Handler/WechatHandler.ashx',
                onSubmit: function (param) {
                    param.visit = 'savehouseservice';
                    param.ID = ID;
                    param.options = JSON.stringify(content.list);
                    param.type = type;
                    param.IsWechatSend = IsWechatSend;
                    param.IsCustomerAPPSend = IsCustomerAPPSend;
                    param.IsUserAPPSend = IsUserAPPSend;
                    param.ServiceIncude = ueServiceIncude.getContent();
                    param.ServiceStandard = ueServiceStandard.getContent();
                    param.AppointNotify = ueAppointNotify.getContent();
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
        function get_combobox_params() {
            var options = { visit: 'getedithouseserviceparams', type: type };
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/WechatHandler.ashx',
                data: options,
                success: function (data) {
                    if (data.status) {
                        $('#<%=this.tdCategory.ClientID%>').combobox({
                            data: data.categorylist,
                            textField: "Name",
                            valueField: "ID",
                            editable: false
                        })
                        return;
                    }
                    show_message('系统错误', 'error');
                }
            });
        }
        function addFile() {
            $("#tdFile").find("a.fileadd").hide();
            $("#tdFile").find("a.fileremove").show();
            filecount++;
            var $html = "<div id=\"tdFile_" + filecount + "\">";
            $html += "<input class=\"easyui-filebox\" name=\"attachfile\" data-options=\"prompt:'请选择文件',buttonText: '选择文件'\" style=\"width: 60%\" />";
            $html += '<a href="javascript:void(0)" onclick="addFile()" class="easyui-linkbutton btnlinkbar fileadd" data-options="plain:true,iconCls:\'icon-add\'">添加</a>';
            $html += '<a href="javascript:void(0)" onclick="deleteFile(' + filecount + ')" class="easyui-linkbutton btnlinkbar fileremove" style="display:none;" data-options="plain:true,iconCls:\'icon-remove\'">删除</a>';
            $html += "</div>";
            $("#tdFile").append($html);
            $.parser.parse("#tdFile_" + filecount);
        }
        function deleteFile(id) {
            $("#tdFile_" + id).html("");
        }
        function loadattachs() {
            var options = { visit: 'loadhouseserviceattachs', ID: ID };
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/WechatHandler.ashx',
                data: options,
                success: function (data) {
                    var $html = '';
                    $("#trExistFiles").html($html);
                    if (data.length > 0) {
                        $("#trExistFiles").show();
                        $html += '<td style="width:15%;">已上传图片</td>';
                        $html += '<td colspan="3" style="width:85%;">';
                        $.each(data, function (index, item) {
                            $html += '<div class="image_box">';
                            $html += '<a href="' + item.AttachedFilePath + '" target="_blank">';
                            $html += '<img src="' + item.AttachedFilePath + '" />';
                            $html += '</a>';
                            $html += '<br />';
                            $html += '<a href="#" onclick="deleteAttach(' + item.ID + ')">删除</a>';
                            $html += '</div>';
                        })
                        $html += '</td>';
                    }
                    $("#trExistFiles").append($html);
                }
            });
        }
        function deleteAttach(AttachID) {
            top.$.messager.confirm("提示", "是否删除选已上传的图片?", function (r) {
                if (r) {
                    var options = { visit: 'deletehouseservicefile', ID: AttachID };
                    $.ajax({
                        type: 'POST',
                        dataType: 'json',
                        url: '../Handler/WechatHandler.ashx',
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
        function deleteCover() {
            top.$.messager.confirm("提示", "是否删除选已上传的封面?", function (r) {
                if (r) {
                    var options = { visit: 'deletehouseservicecorver', ID: data_id };
                    $.ajax({
                        type: 'POST',
                        dataType: 'json',
                        url: '../Handler/WechatHandler.ashx',
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
    </script>
    <style type="text/css">
        .panel-body {
            background: #f0f0f0;
        }

        table.field {
            width: 90%;
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

        .field input[type=text], .field select {
            width: 100px;
            height: 25px;
            border-radius: 5px !important;
            border: solid 1px #ddd;
            line-height: 25px;
            padding: 0 5px;
        }

        table.info label {
            cursor: pointer;
            color: #2f80d1;
            margin: 0 5px;
        }

        table.info .sendtype label {
            margin-right: 10px;
            height: 25px;
            line-height: 25px;
            position: relative;
            padding-right: 25px;
            color: #000;
        }

        .sendtype input {
            width: 20px;
            height: 20px;
            position: absolute;
            top: 50%;
            right: 0;
            margin-top: -10px;
        }

        .image_box {
            min-width: 100px;
            display: inline-block;
            margin: 10px;
            text-align: center;
        }

            .image_box img {
                width: 100px;
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
            <div class="table_title">基本信息</div>
            <table class="info">
                </tr>
                <tr>
                    <td>使用外部链接
                    </td>
                    <td id="td_useoutlink" colspan="3">
                        <select data-options="editable:false" class="easyui-combobox" id="tdUseOutLink" runat="server">
                            <option value="0">否</option>
                            <option value="1">是</option>
                        </select>
                    </td>
                    <td class="UseOutLink" style="display: none;">外部链接地址
                    </td>
                    <td class="UseOutLink" style="display: none;">
                        <input type="text" class="easyui-textbox" id="tdOutLinkURL" runat="server" style="width: 300px;" />
                    </td>
                </tr>
                <tr>
                    <td>服务名称
                    </td>
                    <td>
                        <input type="text" class="easyui-textbox" id="tdTitle" runat="server" />
                    </td>
                    <td>联系电话
                    </td>
                    <td>
                        <input type="text" class="easyui-textbox" id="tdContactPhone" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>服务类别
                    </td>
                    <td>
                        <input type="text" class="easyui-combobox" id="tdCategory" runat="server" />
                    </td>
                    <td>状态
                    </td>
                    <td>
                        <select type="text" class="easyui-combobox" id="tdPublishStatus" runat="server" data-options="editable:false">
                            <option value="1">发布</option>
                            <option value="0">不发布</option>
                        </select>
                    </td>
                </tr>
                <tr>
                    <td>发布对象</td>
                    <td colspan="3" class="sendtype">
                        <label>微信端<input type="checkbox" runat="server" id="tdIsWechatSend" /></label>
                        <label>业主APP端<input type="checkbox" runat="server" id="tdIsCustomerAPPSend" /></label>
                        <label>员工APP端<input type="checkbox" runat="server" id="tdIsUserAPPSend" /></label>
                    </td>
                </tr>
                <tr>
                    <td>排序</td>
                    <td colspan="3">
                        <input type="text" class="easyui-textbox" id="tdSortOrder" runat="server" /></td>
                </tr>
                <tr>
                    <td>封面图片</td>
                    <td colspan="3">
                        <%if (!string.IsNullOrEmpty(this.IconPath))
                          { %>
                        <div class="image_box">
                            <a href="<%=this.IconPath%>" target="_blank">
                                <img src="<%=this.IconPath%>" />
                            </a>
                            <br />
                            <a href="#" onclick="deleteCover()">删除</a>
                        </div>
                        <%} %>
                        <input class="easyui-filebox" name="attachfile" data-options="prompt:'请选择文件',buttonText: '选择文件'" style="width: 80%" />
                    </td>
                </tr>
            </table>
            <div class="table_title">服务项目</div>
            <div id="fieldcontent" class="UseInLink">
                <table class="field">
                    <tr>
                        <td colspan="6">
                            <a href="javascript:void(0)" v-on:click="add_line()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-add'">添加</a>
                        </td>
                    </tr>
                    <tr>
                        <td>名称
                        </td>
                        <td>成本价
                        </td>
                        <td>单价
                        </td>
                        <td>单位
                        </td>
                        <td>备注
                        </td>
                        <td></td>
                    </tr>
                    <tr v-for="(item, index) in list">
                        <td>
                            <input type="text" v-model="item.TypeName" />
                        </td>
                        <td>
                            <input type="text" v-model="item.BasicPrice" />
                        </td>
                        <td>
                            <input type="text" v-model="item.UnitPrice" />
                        </td>
                        <td>
                            <input type="text" v-model="item.Unit" />
                        </td>
                        <td>
                            <input type="text" v-model="item.Remark" />
                        </td>
                        <td>
                            <a href="javascript:void(0)" v-on:click="remove_line(item)" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-remove'">删除</a>
                        </td>
                    </tr>
                </table>
            </div>
            <div class="table_title">服务范围</div>
            <table class="info UseInLink">
                <tr>
                    <td colspan="4" style="width: 100%;">
                        <script id="tdServiceIncude" type="text/plain" style="width: 100%;">
                        </script>
                        <asp:HiddenField runat="server" ID="hdServiceIncude" />
                    </td>
                </tr>
            </table>
            <div class="table_title">服务标准</div>
            <table class="info UseInLink">
                <tr>
                    <td colspan="4" style="width: 100%;">
                        <script id="tdServiceStandard" type="text/plain" style="width: 100%;">
                        </script>
                        <asp:HiddenField runat="server" ID="hdServiceStandard" />
                    </td>
                </tr>
            </table>
            <div class="table_title">预约须知</div>
            <table class="info UseInLink">
                <tr>
                    <td colspan="4" style="width: 100%;">
                        <script id="tdAppointNotify" type="text/plain" style="width: 100%;">
                        </script>
                        <asp:HiddenField runat="server" ID="hdAppointNotify" />
                    </td>
                </tr>
            </table>
            <div class="table_title">展示相册</div>
            <table class="info UseInLink">
                <tr id="trExistFiles" style="display: none;">
                </tr>
                <tr>
                    <td style="width:15%;">服务相册</td>
                    <td colspan="3" style="width:85%;" id="tdFile"></td>
                </tr>
            </table>
        </div>
    </form>
</asp:Content>
