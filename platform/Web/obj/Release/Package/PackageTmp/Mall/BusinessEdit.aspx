<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="BusinessEdit.aspx.cs" Inherits="Web.Mall.BusinessEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        var ID, filecount = 0, tdCategoryName;
        $(function () {
            ID = "<%=this.BusinessID%>";
            tdCategoryName = $("#<%=this.tdCategoryName.ClientID%>");
            loadattachs();
            addFile();
            get_select_category_params();
        });
        function get_select_category_params() {
            var options = { visit: 'getmallbusinesseditparams' };
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
        }
        function init() {
            //去掉结点前面的文件及文件夹小图标
            $(".tree-icon,.tree-file").removeClass("tree-icon tree-file");
            $(".tree-icon,.tree-folder").removeClass("tree-icon tree-folder tree-folder-open tree-folder-closed");
        }
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
            var options = { visit: 'getmallbusinesspic', ID: ID };
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/MallHandler.ashx',
                data: options,
                success: function (data) {
                    var $html = '';
                    $("#trExistFiles").hide();
                    $("#trExistFiles").html($html);
                    $("#trExistCoverFiles").hide();
                    $("#trExistCoverFiles").html($html);
                    if (data.status) {
                        if (data.list.length > 0) {
                            $("#trExistFiles").show();
                            $html += '<td>已上传图片</td>';
                            $html += '<td colspan="3">';
                            $.each(data.list, function (index, item) {
                                $html += '<div class="image_box"><a href="' + item.LargePicPath + '" target="_blank" ><image src="' + item.IconPicPath + '"></a><br/>';
                                $html += '<a href="#" onclick="deleteAttach(' + item.ID + ')">删除</a></div>';
                            })
                            $html += '</td>';
                            $("#trExistFiles").append($html);
                        }
                        if (data.CoverImage != '') {
                            $("#trExistCoverFiles").show();
                            $html = '<td>已上传图片</td>';
                            $html += '<td colspan="3">';
                            $html += '<div class="image_box"><a href="' + data.CoverImage + '" target="_blank" ><image src="' + data.CoverImage + '"></a><br/>';
                            $html += '<a href="#" onclick="deleteCoverImg()">删除</a></div>';
                            $html += '</td>';
                            $("#trExistCoverFiles").append($html);
                        }
                    }
                }
            });
        }
        function deleteCoverImg() {
            top.$.messager.confirm("提示", "是否删封面图片?", function (r) {
                if (r) {
                    var options = { visit: 'deletemallbusinesscoverimg', ID: ID };
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
        function deleteAttach(AttachID) {
            top.$.messager.confirm("提示", "是否删除选已上传的图片?", function (r) {
                if (r) {
                    var options = { visit: 'deletemallbusinesspic', ID: AttachID };
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
            MaskUtil.mask('body', '提交中');
            $('#ff').form('submit', {
                url: '../Handler/MallHandler.ashx',
                onSubmit: function (param) {
                    var CategoryIDList = tdCategoryName.combotree('getValues');
                    param.visit = 'savemallbusiness';
                    param.ID = ID;
                    param.CategoryIDs = JSON.stringify(CategoryIDList);
                },
                success: function (data) {
                    MaskUtil.unmask();
                    var dataObj = eval("(" + data + ")");
                    if (dataObj.status) {
                        if (dataObj.ID > 0) {
                            ID = dataObj.ID;
                            show_message('保存成功', 'success', function () {
                                do_close();
                            });
                            return;
                        }
                        show_message('数据不存在或已删除', 'warning');
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
        var LngLat = null;
        var MapAddress = null;
        function open_map_location() {
            LngLat = null;
            var iframe = "../Wechat/MapLocation.aspx";
            do_open_dialog('坐标定位', iframe);
        }
        function open_map_location_done() {
            if (LngLat != null) {
                $('#<%=this.tdMapLocation.ClientID%>').textbox('setValue', LngLat);
            }
            if (MapAddress != null) {
                $('#<%=this.tdBusinessAddress.ClientID%>').textbox('setValue', MapAddress);
            }
        }
        function do_close() {
            parent.do_close_dialog(function () {
                parent.$("#tt_table").datagrid("reload");
            }, true);
        }
    </script>
    <style>
        .image_box {
            min-width: 100px;
            display: inline-block;
            margin-right: 10px;
            text-align: center;
        }

            .image_box img {
                height: 100px;
            }

        .panel-body {
            background: #f0f0f0;
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
                    <td>门店名称</td>
                    <td>
                        <input type="text" class="easyui-textbox" runat="server" id="tdBusinessName" data-options="required:true" /></td>
                    <td>排序序号
                    </td>
                    <td>
                        <input type="text" class="easyui-textbox" runat="server" id="tdSortOrder" /></td>

                </tr>
                <tr>
                    <td>门店地址</td>
                    <td>
                        <input type="text" class="easyui-textbox" runat="server" id="tdBusinessAddress" data-options="required:true" /></td>
                    <td>地址简称</td>
                    <td>
                        <input type="text" class="easyui-textbox" runat="server" id="tdShortAddress" data-options="required:true" />
                        (比如:四川 成都)
                    </td>
                </tr>
                <tr>
                    <td>联系人</td>
                    <td>
                        <input type="text" class="easyui-textbox" runat="server" id="tdContactName" /></td>
                    <td>联系电话</td>
                    <td>
                        <input type="text" class="easyui-textbox" runat="server" id="tdContactPhone" /></td>
                </tr>
                <tr>
                    <td>商家简介
                    </td>
                    <td colspan="3">
                        <input type="text" class="easyui-textbox" data-options="multiline:true" style="height: 60px; width: 80%;" runat="server" id="tdRemark" /></td>
                </tr>
                <tr>
                    <td>经营类别</td>
                    <td>
                        <input type="text" class="easyui-combotree" runat="server" id="tdCategoryName" data-options="required:true" /></td>
                    <td>营业执照号</td>
                    <td>
                        <input type="text" class="easyui-textbox" runat="server" id="tdLicenseNumber" /></td>
                </tr>
                <tr>
                    <td>推荐商家</td>
                    <td>
                        <select runat="server" id="tdIsSuggestion" class="easyui-combobox" data-options="editable:false">
                            <option value="1">是</option>
                            <option value="0">否</option>
                        </select>
                    </td>
                    <td>是否置顶</td>
                    <td>
                        <select runat="server" id="tdIsTopShow" class="easyui-combobox" data-options="editable:false">
                            <option value="1">是</option>
                            <option value="0">否</option>
                        </select>
                    </td>
                </tr>
                <%if (this.IsMallBusinessOn)
                  { %>
                <tr>
                    <td>首页显示</td>
                    <td>
                        <select runat="server" id="tdIsShowOnHome" class="easyui-combobox" data-options="editable:false">
                            <option value="1">是</option>
                            <option value="0">否</option>
                        </select>
                    </td>
                </tr>
                <%} %>
                <tr>
                    <td>地图位置
                    </td>
                    <td colspan="2">
                        <input type="text" style="width: 50%;" class="easyui-textbox" id="tdMapLocation" runat="server" />
                    </td>
                    <td style="text-align: left;"><a href="javascript:void(0)" onclick="open_map_location()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-detail'">标注</a></td>
                </tr>
                <tr id="trExistCoverFiles" style="display: none;">
                </tr>
                <tr>
                    <td>封面图片</td>
                    <td colspan="3">
                        <input class="easyui-filebox" name="attachfile" data-options="prompt:'请选择图片',buttonText: '选择图片'" style="width: 85%" />
                    </td>
                </tr>
            </table>
            <div class="table_title">资料图片</div>
            <table class="info">
                <tr>
                    <td colspan="4" style="text-align: center; background-color: #0094ff; color: #fff; font-size: 14px;"></td>
                </tr>
                <tr id="trExistFiles" style="display: none;">
                </tr>
                <tr>
                    <td>商家资料</td>
                    <td colspan="3" id="tdFile"></td>
                </tr>
            </table>
        </div>
    </form>
</asp:Content>
