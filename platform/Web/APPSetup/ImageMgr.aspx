<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="ImageMgr.aspx.cs" Inherits="Web.APPSetup.ImageMgr" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        var filecount = 0;
        $(function () {
            addFile('homeimage', 'td_HomeFile');
            loadattachs('APPUserHomeImg', 'homeimage', 'tr_HomeExistFiles');

            addFile('businessimg', 'td_BusinessFile');
            loadattachs('APPUserBusinessImg', 'businessimg', 'tr_BusinessExistFiles');

            addFile('bbsimg', 'td_BBSFile');
            loadattachs('APPUserBBSImg', 'bbsimg', 'tr_BBSExistFiles');

            addFile('myselfimg', 'td_MyselfFile', true);
            loadattachs('APPUserMySelfImg', 'myselfimg', 'tr_MyselfExistFiles');
        });
        function addFile(tablecss, id, onlyone) {
            var elem = $('.' + tablecss + ' #' + id);
            elem.find("a.fileadd").hide();
            elem.find("a.fileremove").show();
            filecount++;
            var sub_id = id + "_" + filecount;
            var $html = "<div id=\"" + sub_id + "\">";
            $html += "<input class=\"easyui-filebox\" name=\"attachfile\" data-options=\"prompt:'请选择图片',buttonText: '选择图片'\" style=\"width: 60%\" />";
            if (!onlyone) {
                $html += "<a href=\"javascript:void(0)\" onclick=\"addFile('" + tablecss + "','" + id + "')\" class=\"easyui-linkbutton btnlinkbar fileadd\" data-options=\"plain:true,iconCls:'icon-add'\">添加</a>";
            }
            $html += "<a href=\"javascript:void(0)\" onclick=\"deleteFile('" + sub_id + "')\" class=\"easyui-linkbutton btnlinkbar fileremove\" data-options=\"plain:true,iconCls:'icon-remove'\" style=\"display:none;\">删除</a>";
            $html += "</div>";
            elem.append($html);
            $.parser.parse("#" + sub_id);
        }
        function deleteFile(id) {
            $("#" + id).html("");
        }
        function loadattachs(name, tablecss, id) {
            var elem = $('.' + tablecss + ' #' + id);
            var options = { visit: 'getmallapprotatingimage', name: name };
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/MallHandler.ashx',
                data: options,
                success: function (data) {
                    var $html = '';
                    elem.html($html);
                    if (!data.status) {
                        return;
                    }
                    if (data.list.length > 0) {
                        elem.show();
                        $html += '<td>已上传图片</td>';
                        $html += '<td colspan="3">';
                        $.each(data.list, function (index, item) {
                            $html += '<div class="image_box"><a href="' + item.PicPath + '" target="_blank" ><image src="' + item.PicPath + '"></a><br/>';
                            $html += '<a href="#" onclick="deleteAttach(' + item.ID + ')">删除</a></div>';
                        })
                        $html += '</td>';
                    }
                    elem.append($html);
                }
            });
        }
        function deleteAttach(AttachID) {
            top.$.messager.confirm("提示", "是否删除选已上传的图片?", function (r) {
                if (r) {
                    var options = { visit: 'deletemallapprotatingimg', ID: AttachID };
                    $.ajax({
                        type: 'POST',
                        dataType: 'json',
                        url: '../Handler/MallHandler.ashx',
                        data: options,
                        success: function (message) {
                            if (message.status) {
                                show_message('操作成功', 'success', function () {
                                    window.location.reload();
                                });
                                return;
                            }
                            show_message('系统错误', 'error');
                        }
                    });
                }
            })
        }
        function do_save_home() {
            var isValid = $("#ff1").form('enableValidation').form('validate');
            if (!isValid) {
                return;
            }
            MaskUtil.mask('body', '提交中');
            $('#ff1').form('submit', {
                url: '../Handler/MallHandler.ashx',
                onSubmit: function (param) {
                    param.visit = 'savemallapprotatingimg';
                    param.name = 'APPUserHomeImg';
                },
                success: function (data) {
                    MaskUtil.unmask();
                    var dataObj = eval("(" + data + ")");
                    if (dataObj.status) {
                        window.location.reload();
                        return;
                    }
                    show_message('系统错误', 'error');
                }
            });
        }
        function do_save_business() {
            var isValid = $("#ff2").form('enableValidation').form('validate');
            if (!isValid) {
                return;
            }
            MaskUtil.mask('body', '提交中');
            $('#ff2').form('submit', {
                url: '../Handler/MallHandler.ashx',
                onSubmit: function (param) {
                    param.visit = 'savemallapprotatingimg';
                    param.name = 'APPUserBusinessImg';
                },
                success: function (data) {
                    MaskUtil.unmask();
                    var dataObj = eval("(" + data + ")");
                    if (dataObj.status) {
                        window.location.reload();
                        return;
                    }
                    show_message('系统错误', 'error');
                }
            });
        }
        function do_save_bbs() {
            var isValid = $("#ff3").form('enableValidation').form('validate');
            if (!isValid) {
                return;
            }
            MaskUtil.mask('body', '提交中');
            $('#ff3').form('submit', {
                url: '../Handler/MallHandler.ashx',
                onSubmit: function (param) {
                    param.visit = 'savemallapprotatingimg';
                    param.name = 'APPUserBBSImg';
                },
                success: function (data) {
                    MaskUtil.unmask();
                    var dataObj = eval("(" + data + ")");
                    if (dataObj.status) {
                        window.location.reload();
                        return;
                    }
                    show_message('系统错误', 'error');
                }
            });
        }
        function do_save_myself() {
            var isValid = $("#ff4").form('enableValidation').form('validate');
            if (!isValid) {
                return;
            }
            MaskUtil.mask('body', '提交中');
            $('#ff4').form('submit', {
                url: '../Handler/MallHandler.ashx',
                onSubmit: function (param) {
                    param.visit = 'savemallapprotatingimg';
                    param.name = 'APPUserMySelfImg';
                },
                success: function (data) {
                    MaskUtil.unmask();
                    var dataObj = eval("(" + data + ")");
                    if (dataObj.status) {
                        window.location.reload();
                        return;
                    }
                    show_message('系统错误', 'error');
                }
            });
        }
    </script>
    <style>
        form {
            height: auto;
        }

        .image_box {
            min-width: 100px;
            display: inline-block;
            margin: 10px;
            text-align: center;
        }

            .image_box img {
                height: 100px;
            }

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

                table.info td.header_title {
                    text-align: center;
                    background-color: #0094ff;
                    color: #fff;
                    font-size: 14px;
                }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <form id="ff1" method="post" enctype="multipart/form-data">
        <table class="info homeimage">
            <tr>
                <td colspan="4" class="header_title">APP首页图片</td>
            </tr>
            <tr id="tr_HomeExistFiles" style="display: none;">
            </tr>
            <tr>
                <td>上传图片</td>
                <td colspan="3" id="td_HomeFile"></td>
            </tr>
            <tr>
                <td colspan="4" style="text-align: center;">
                    <a href="javascript:void(0)" onclick="do_save_home()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-save'">保存</a>
                </td>
            </tr>
        </table>
    </form>
    <form id="ff2" method="post" enctype="multipart/form-data">
        <table class="info businessimg">
            <tr>
                <td colspan="4" class="header_title">APP商城首页图片</td>
            </tr>
            <tr id="tr_BusinessExistFiles" style="display: none;">
            </tr>
            <tr>
                <td>上传图片</td>
                <td colspan="3" id="td_BusinessFile"></td>
            </tr>
            <tr>
                <td colspan="4" style="text-align: center;">
                    <a href="javascript:void(0)" onclick="do_save_business()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-save'">保存</a>
                </td>
            </tr>
        </table>
    </form>
    <form id="ff3" method="post" enctype="multipart/form-data">
        <table class="info bbsimg">
            <tr>
                <td colspan="4" class="header_title">APP社区首页图片</td>
            </tr>
            <tr id="tr_BBSExistFiles" style="display: none;">
            </tr>
            <tr>
                <td>上传图片</td>
                <td colspan="3" id="td_BBSFile"></td>
            </tr>
            <tr>
                <td colspan="4" style="text-align: center;">
                    <a href="javascript:void(0)" onclick="do_save_bbs()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-save'">保存</a>
                </td>
            </tr>
        </table>
    </form>
    <form id="ff4" method="post" enctype="multipart/form-data">
        <table class="info myselfimg">
            <tr>
                <td colspan="4" class="header_title">APP个人中心图片</td>
            </tr>
            <tr id="tr_MyselfExistFiles" style="display: none;">
            </tr>
            <tr>
                <td>上传图片</td>
                <td colspan="3" id="td_MyselfFile"></td>
            </tr>
            <tr>
                <td colspan="4" style="text-align: center;">
                    <a href="javascript:void(0)" onclick="do_save_myself()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-save'">保存</a>
                </td>
            </tr>
        </table>
    </form>
</asp:Content>
