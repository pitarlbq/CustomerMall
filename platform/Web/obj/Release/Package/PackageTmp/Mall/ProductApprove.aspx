<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="ProductApprove.aspx.cs" Inherits="Web.Mall.ProductApprove" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" charset="utf-8" src="../js/ueditor/ueditor.config.js"></script>
    <script type="text/javascript" charset="utf-8" src="../js/ueditor/ueditor.all.js?v5"> </script>
    <script type="text/javascript" charset="utf-8" src="../js/ueditor/lang/zh-cn/zh-cn.js"></script>
    <script type="text/javascript">
        var ue, ID, type, filecount = 0, tdCategoryName, tdBusinessName, tdIsZiYing, tdTagName, hdTagName;
        $(function () {
            type = "<%=this.type%>";
            ID = "<%=this.ProductID%>";
            tdCategoryName = $('#<%=this.tdCategoryName.ClientID%>');
            tdBusinessName = $('#<%=this.tdBusinessName.ClientID%>');
            tdIsZiYing = $('#<%=this.tdIsZiYing.ClientID%>');
            tdTagName = $('#<%=this.tdTagName.ClientID%>');
            hdTagName = $('#<%=this.hdTagName.ClientID%>');
            tdShipRateID = $('#<%=this.tdShipRateID.ClientID%>');
            createEditor();
            setTimeout(function () {
                setContent();
            }, 1000);
            loadattachs();
            get_select_category_params();
            change_ziying_status();
            loadtagparams();
        });
        function loadtagparams() {
            var options = { visit: 'getmalltagparams' };
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/MallHandler.ashx',
                data: options,
                success: function (data) {
                    if (data.status) {
                        tdTagName.combobox({
                            editable: false,
                            data: data.list,
                            valueField: 'ID',
                            textField: 'Name',
                            multiple: true,
                            onSelect: function (rec) {
                                var values = tdTagName.combobox('getValues');
                                hdTagName.val(JSON.stringify(values));
                            },
                            onUnselect: function (rec) {
                                var values = tdTagName.combobox('getValues');
                                hdTagName.val(JSON.stringify(values));
                            }
                        });
                        return;
                    }
                }
            });
        }
        function change_ziying_status() {
            var ziying_value = tdIsZiYing.combobox('getValue');
            if (ziying_value == '1') {
                $('.no_ziying').hide();
            }
            else {
                $('.no_ziying').show();
            }
        }
        function init() {
            //去掉结点前面的文件及文件夹小图标
            $(".tree-icon,.tree-file").removeClass("tree-icon tree-file");
            $(".tree-icon,.tree-folder").removeClass("tree-icon tree-folder tree-folder-open tree-folder-closed");
        }
        function get_select_category_params() {
            var options = { visit: 'getmallproducteditcategorytreeparams' };
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/MallHandler.ashx',
                data: options,
                success: function (data) {
                    tdCategoryName.combotree({
                        multiple: true,
                        editable: false,
                        valueField: 'id',
                        textField: 'text',
                        data: data
                    });
                    init();
                }
            });
            get_select_business_params();
        }
        function get_select_business_params() {
            var options = { visit: 'getmallproducteditparams' };
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/MallHandler.ashx',
                data: options,
                success: function (data) {
                    if (data.status) {
                        tdBusinessName.combobox({
                            editable: false,
                            valueField: 'ID',
                            textField: 'Name',
                            data: data.businesses
                        });
                        tdShipRateID.combobox({
                            editable: false,
                            valueField: 'ID',
                            textField: 'Name',
                            data: data.shiprates
                        });
                    }
                }
            });
        }
        function setContent() {
            var content = $("#<%=this.hdDescription.ClientID%>").val();
            ue.setContent(content, false);
        }
        function createEditor() {
            window.SERVERAPPLICATION = "<%=Web.WebUtil.getApplicationPath()%>";
            ue = UE.getEditor('tdDescription', {
                toolbars: [["fullscreen", "source", "|", "undo", "redo", "|", "bold", "italic", "underline", "fontborder", "strikethrough", "superscript", "subscript", "removeformat", "formatmatch", "autotypeset", "blockquote", "pasteplain", "|", "forecolor", "backcolor", "insertorderedlist", "insertunorderedlist", "selectall", "cleardoc", "|", "rowspacingtop", "rowspacingbottom", "lineheight", "|", "customstyle", "paragraph", "fontfamily", "fontsize", "|", "directionalityltr", "directionalityrtl", "indent", "|", "justifyleft", "justifycenter", "justifyright", "justifyjustify", "|", "touppercase", "tolowercase", "|", "link", "unlink", "anchor", "|", "emotion", "|", "horizontal", "date", "time", "spechars", "|", "preview", 'simpleupload', "help"
                ]],
                autoHeightEnabled: true,
                autoFloatEnabled: true
            });
        }
        function loadattachs() {
            if (ID <= 0) {
                return;
            }
            var options = { visit: 'getmallproductpics', ID: ID };
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/MallHandler.ashx',
                data: options,
                success: function (data) {
                    var $html = '';
                    $("#trExistFiles").html($html);
                    if (!data.status) {
                        return;
                    }
                    if (data.list.length > 0) {
                        $("#trExistFiles").show();
                        $html += '<td>已上传图片</td>';
                        $html += '<td colspan="3">';
                        $.each(data.list, function (index, item) {
                            $html += '<div class="image_box"><a href="' + item.LargePicPath + '" target="_blank" ><image src="' + item.IconPicPath + '"></a><br/>';
                            $html += '</div>';
                        })
                        $html += '</td>';
                    }
                    $("#trExistFiles").append($html);
                }
            });
        }
        function do_save(status) {
            var isValid = $("#<%=this.ff.ClientID%>").form('enableValidation').form('validate');
            if (!isValid) {
                return;
            }
            MaskUtil.mask('body', '提交中');
            $('#ff').form('submit', {
                url: '../Handler/MallHandler.ashx',
                onSubmit: function (param) {
                    var CategoryIDList = tdCategoryName.combotree('getValues');
                    param.visit = 'approvemallproduct';
                    param.ID = ID;
                    param.status = status;
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
            if (type != 3 && type != 4) {
                variant_reset();
            }
        })
        function variant_reset() {
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
                        var options = { visit: 'getmallproductvariants', ProductID: ID };
                        $.ajax({
                            type: 'POST',
                            dataType: 'json',
                            url: '../Handler/MallHandler.ashx',
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
                    }
                }
            });
            content.getdata();
        }
    </script>
    <style>
        .image_box {
            min-width: 100px;
            display: inline-block;
            margin: 10px;
            text-align: center;
        }

        .panel-body {
            background: #f0f0f0;
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
                width: 25%;
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
            <%if (this.can_approve)
              { %>
            <a href="javascript:void(0)" onclick="do_save(10)" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-save'">审核通过</a>
            <a href="javascript:void(0)" onclick="do_save(4)" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-save'">审核不通过</a>
            <%} %>
            <a href="javascript:void(0)" onclick="do_close()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-close'">关闭</a>
        </div>
        <div class="table_container">
            <div class="table_title"><span id="tdProductType" runat="server"></span>基本信息</div>
            <table class="info">
                <tr>
                    <td>商品名称</td>
                    <td>
                        <input type="text" class="easyui-textbox" runat="server" id="tdProductName" data-options="readonly:true" /></td>
                    <td>所属分类</td>
                    <td>
                        <input type="text" class="easyui-combotree" runat="server" id="tdCategoryName" data-options="readonly:true" /></td>
                </tr>
                <tr>
                    <td>商品简介
                    </td>
                    <td colspan="3">
                        <input type="text" class="easyui-textbox" data-options="multiline:true,readonly:true" style="height: 60px; width: 85%;" runat="server" id="tdProductSummary" /></td>
                </tr>
                <tr>
                    <td>所属标签</td>
                    <td>
                        <input type="text" class="easyui-combobox" runat="server" id="tdTagName" data-options="readonly:true" />
                        <asp:HiddenField runat="server" ID="hdTagName" />
                    </td>
                    <td>状态</td>
                    <td>
                        <select runat="server" id="tdStatus" class="easyui-combobox" data-options="readonly:true">
                            <option value="10">出售中</option>
                            <option value="2">已下架</option>
                            <option value="3">待审核</option>
                        </select>
                    </td>
                </tr>
                <tr>
                    <td>库存</td>
                    <td>
                        <input type="text" class="easyui-textbox" runat="server" id="tdTotalCount" data-options="readonly:true" /></td>
                    <td>商品单价</td>
                    <td>
                        <input type="text" class="easyui-textbox" runat="server" id="tdSalePrice" data-options="readonly:true" />
                        <span runat="server" id="tdUnit"></span>
                    </td>
                </tr>
                <tr>
                    <td>计量单位</td>
                    <td>
                        <input type="text" class="easyui-textbox" runat="server" id="tdCountUnit" data-options="readonly:true" /></td>
                    <td>规格型号</td>
                    <td>
                        <input type="text" class="easyui-textbox" runat="server" id="tdModelNumber" data-options="readonly:true" />
                    </td>
                </tr>
                <tr>
                    <td>福顺优选</td>
                    <td>
                        <select runat="server" id="tdIsYouXuan" class="easyui-combobox" data-options="editable:false,readonly:true">
                            <option value="1">是</option>
                            <option value="0">否</option>
                        </select>
                    </td>
                    <td>首页显示</td>
                    <td>
                        <select runat="server" id="tdIsShowOnHome" class="easyui-combobox" data-options="editable:false,readonly:true">
                            <option value="1">是</option>
                            <option value="0">否</option>
                        </select>
                    </td>
                </tr>
                <tr>
                    <td>单次购买上限</td>
                    <td>
                        <input type="text" class="easyui-textbox" runat="server" id="tdQuantityLimit" data-options="readonly:true" /></td>
                    <td>自营商品</td>
                    <td>
                        <select runat="server" id="tdIsZiYing" class="easyui-combobox" data-options="readonly:true">
                            <option value="1">是</option>
                            <option value="0">否</option>
                        </select>
                    </td>
                </tr>
                <tr>
                    <td>运费</td>
                    <td>
                        <input type="text" class="easyui-combobox" id="tdShipRateID" runat="server" data-options="readonly:true" /></td>
                    <td class="no_ziying">所属商家</td>
                    <td class="no_ziying">
                        <input type="text" class="easyui-combobox" runat="server" id="tdBusinessName" data-options="readonly:true" /></td>
                </tr>
            </table>
            <%if (this.type != 3 && this.type != 4)
              { %>
            <div class="table_title">商品属性</div>
            <table class="info">
                <tr>
                    <td colspan="4" style="padding: 0;">
                        <div id="fieldcontent">
                            <table class="field">
                                <tr>
                                    <td>属性类别
                                    </td>
                                    <td>属性名称
                                    </td>
                                    <td>单价(元)
                                    </td>
                                </tr>
                                <tr v-for="(item, index) in list">
                                    <td>
                                        <input type="text" readonly="readonly" v-model="item.VariantTitle" />
                                    </td>
                                    <td>
                                        <input type="text" readonly="readonly" v-model="item.VariantName" />
                                    </td>
                                    <td>
                                        <input type="text" readonly="readonly" v-model="item.VariantPrice" />
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </td>
                </tr>
            </table>
            <%} %>
            <div class="table_title">商品图片</div>
            <table class="info">
                <tr id="trExistFiles" style="display: none;">
                </tr>
            </table>
            <%if (this.type == 3)
              { %>
            <div class="table_title">拼团信息</div>
            <table class="info">
                <tr>
                    <td>拼团价格
                    </td>
                    <td>
                        <input type="text" class="easyui-textbox" data-options="readonly:true" runat="server" id="tdPinSalePrice" />(元)</td>
                    <td>拼团人数
                    </td>
                    <td>
                        <input type="text" class="easyui-textbox" data-options="readonly:true" runat="server" id="tdPinPeopleCount" />(人)</td>
                </tr>
                <tr style="display: none;">
                    <td>拼团持续时间
                    </td>
                    <td colspan="3">
                        <input type="text" class="easyui-textbox" data-options="readonly:true" runat="server" id="tdActiveTimeRange" />(小时)(注: 从用户发起拼团时间开始计算)
                    </td>
                </tr>
                <tr>
                    <td>活动有效时间
                    </td>
                    <td colspan="3">
                        <input type="text" runat="server" data-options="readonly:true" id="tdPinStartTime" class="easyui-datetimebox" />
                        -
                    <input type="text" runat="server" data-options="readonly:true" id="tdPinEndTime" class="easyui-datetimebox" />
                        (注: 整体拼团活动的有效时间)
                    </td>
                </tr>
            </table>
            <%} %>
            <%if (this.type == 4)
              { %>
            <div class="table_title">秒杀信息</div>
            <table class="info">
                <tr>
                    <td>秒杀价格
                    </td>
                    <td colspan="3">
                        <input type="text" class="easyui-textbox" runat="server" id="tdXianShiSalePrice" data-options="readonly:true" />(元)</td>
                </tr>
                <tr>
                    <td>有效时间
                    </td>
                    <td colspan="3">
                        <input type="text" runat="server" id="tdXianShiStartTime" class="easyui-datetimebox" data-options="readonly:true" />
                        -
                    <input type="text" runat="server" id="tdXianShiEndTime" class="easyui-datetimebox" data-options="readonly:true" />
                        (注: 整体秒杀活动的有效时间)
                    </td>
                </tr>
                <%} %>
            </table>
            <div class="table_title">详细说明</div>
            <table class="info">
                <tr>
                    <td colspan="4">
                        <script id="tdDescription" type="text/plain" style="width: 100%; height: 300px;">
                        </script>
                        <asp:HiddenField runat="server" ID="hdDescription" />
                    </td>
                </tr>
                <tr>
                    <td colspan="4" class="header_title">审核说明</td>
                </tr>
                <tr>
                    <td>审核人</td>
                    <td>
                        <input type="text" class="easyui-textbox" runat="server" id="tdApproveMan" data-options="readonly:true" /></td>
                    <td>审核时间</td>
                    <td>
                        <input type="text" class="easyui-textbox" runat="server" id="tdApproveTime" data-options="readonly:true" /></td>
                </tr>
                <tr>
                    <td>审核备注</td>
                    <td colspan="3">
                        <input type="text" id="tdApproveRemark" runat="server" class="easyui-textbox" data-options="multiline:true" style="width: 85%; height: 50px;" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</asp:Content>
