<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="RotatingImageEdit.aspx.cs" Inherits="Web.APPSetup.RotatingImageEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        var ID, hdProducts, tdURLLinkType, ImagePath, tdURLLinkNames, tdType;
        $(function () {
            ID = "<%=this.ID%>";
            hdProducts = $("#<%=this.hdProducts.ClientID%>");
            tdURLLinkNames = $("#<%=this.tdURLLinkNames.ClientID%>");
            ImagePath = "<%=this.ImagePath%>";
            tdURLLinkType = $("#<%=this.tdURLLinkType.ClientID%>");
            tdType = $("#<%=this.tdType.ClientID%>");
            var hdTypeValue = $("#<%=this.hdTypeValue.ClientID%>");
            var list = eval("(" + hdTypeValue.val() + ")");
            tdType.combobox({
                editable: false,
                data: list,
                valueField: 'id',
                textField: 'name',
                onSelect: function () {
                    type_change();
                }
            })
            type_change();
        })
        function type_change() {
            var value = tdType.combobox('getValue');
            if (value == 7) {
                $('.tr_waitsecond').show();
            } else {
                $('.tr_waitsecond').hide();
            }
        }
        function do_save() {
            var isValid = $("#<%=this.ff.ClientID%>").form('enableValidation').form('validate');
            if (!isValid) {
                return;
            }
            if ($('#tdImagePath').filebox('getValue') == '' && ImagePath == '') {
                show_message('请上传图片', 'warning');
                return;
            }
            MaskUtil.mask('body', '提交中');
            $('#ff').form('submit', {
                url: '../Handler/MallHandler.ashx',
                onSubmit: function (param) {
                    param.visit = 'saverotatingimage';
                    param.ID = ID;
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
                    else {
                        show_message('系统错误', 'error');
                    }
                }
            });
        }
        function do_choose() {
            var LinkType = tdURLLinkType.combobox('getValue');
            var iframe = "";
            var title = "";
            if (LinkType == 1) {
                iframe = "../Mall/ChooseProduct.aspx?singleselect=1&from=RotatingImageEdit";
                title = "选择商品";
            }
            if (LinkType == 2) {
                iframe = "../Mall/ChooseBusiness.aspx?singleselect=1&from=RotatingImageEdit";
                title = "选择店铺";
            }
            if (LinkType == 3) {
                iframe = "../Mall/ChooseWechatMsg.aspx?singleselect=1&type=2&msgtypeid=1&from=RotatingImageEdit";
                title = "选择物业公告";
            }
            if (LinkType == 4) {
                iframe = "../Mall/ChooseWechatMsg.aspx?singleselect=1&type=2&msgtypeid=3&from=RotatingImageEdit";
                title = "选择小区新闻";
            }
            if (LinkType == 5) {
                iframe = "../Mall/ChooseHouseService.aspx?singleselect=1&from=RotatingImageEdit&type=2";
                title = "选择生活服务";
            }
            choosedata(iframe, title);
        }
        var isupdate = false;
        function choosedata(iframe, title) {
            isupdate = false;
            do_open_dialog(title, iframe);
        }
        function do_close() {
            parent.do_close_dialog(function () {
                parent.$('#tt_table').datagrid('reload');
            });
        }
        function delete_image() {
            top.$.messager.confirm('提示', '确认删除选中的图片?', function (r) {
                if (r) {
                    var options = { visit: 'removerotatingimageurl', ID: ID };
                    $.ajax({
                        type: 'POST',
                        dataType: 'json',
                        data: options,
                        url: "../Handler/MallHandler.ashx",
                        success: function (data) {
                            if (data.status) {
                                window.location.reload();
                            } else {
                                show_message('系统错误', 'error');
                            }
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

        .image_box {
            width: 100px;
            text-align: center;
        }

            .image_box a image {
                width: 100%;
            }

            .image_box a {
                margin: 0 auto;
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
                    <td>图片类型
                    </td>
                    <td>
                        <input class="easyui-combobox" id="tdType" runat="server" data-options="editable:false,required:true" style="width: 200px;" />
                        <asp:HiddenField runat="server" ID="hdTypeValue" />
                    </td>
                    <td>排序序号
                    </td>
                    <td>
                        <input type="text" class="easyui-textbox" id="tdSortOrder" runat="server" data-options="required:true" />
                    </td>
                </tr>
                <tr class="tr_waitsecond">
                    <td>等待时间</td>
                    <td colspan="3">
                        <input type="text" class="easyui-numberbox" id="tdWaitSecond" runat="server" /></td>
                </tr>
                <tr>
                    <td>是否启用</td>
                    <td colspan="3">
                        <select type="text" class="easyui-combobox" id="tdIsActive" runat="server" data-options="editable:false,required:true" style="width: 200px;">
                            <option value="1">是</option>
                            <option value="0">否</option>
                        </select>
                    </td>
                </tr>
                <tr>
                    <td>上传图片
                    </td>
                    <td colspan="3">
                        <%if (!string.IsNullOrEmpty(this.ImagePath))
                          { %>
                        <div class="image_box">
                            <a href="<%=this.ImagePath %>" target="_blank">
                                <img src="<%=this.ImagePath %>" style="width: 100px;" /></a><br />
                            <a href="javascript:delete_image()">删除</a>
                        </div>
                        <%} %>
                        <input class="easyui-filebox" id="tdImagePath" name="attachfile" data-options="prompt:'请选择图片',buttonText: '选择图片'" style="width: 60%" />
                    </td>
                </tr>
                <tr>
                    <td>链接类型</td>
                    <td colspan="3">
                        <select class="easyui-combobox" id="tdURLLinkType" runat="server" data-options="editable:false,required:true" style="width: 200px;">
                            <option value="1">商品</option>
                            <option value="2">店铺</option>
                            <option value="3">物业公告</option>
                            <option value="4">小区新闻</option>
                            <option value="5">生活服务</option>
                        </select>
                    </td>
                </tr>
                <tr>
                    <td>链接地址
                    </td>
                    <td colspan="3">
                        <input type="text" class="easyui-textbox" id="tdURLLinkNames" runat="server" />
                        <asp:HiddenField runat="server" ID="hdProducts" />
                        <a href="javascript:void(0)" onclick="do_choose()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-choose'">选择</a>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</asp:Content>
