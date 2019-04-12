<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="ContractUserEdit.aspx.cs" Inherits="Web.RoomResource.ContractUserEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        var tdRelationProperty, ID;
        $(function () {
            ID = "<%=this.ID%>";
            tdRelationProperty = $("#<%=this.tdRelationProperty.ClientID%>");
            tdRelationProperty.combobox({
                onSelect: function (ret) {
                    checkRelationProperty();
                }
            })
            checkRelationProperty();
        })
        function checkRelationProperty() {
            var relationProperty = tdRelationProperty.combobox('getValue');
            if (relationProperty == 'geren') {
                $('.customerBox').show();
                $('.companyBox').hide();
            } else {
                $('.customerBox').hide();
                $('.companyBox').show();
            }
        }
        function do_save() {
            var isValid = ffObj.form('enableValidation').form('validate');
            if (!isValid) {
                return;
            }
            if (freetimeerror) {
                show_message("当前免租期包含相同费项", "info");
                return;
            }
            parent.MaskUtil.mask('body', '提交中');
            $('#ff').form('submit', {
                url: '../Handler/ContractHandler.ashx',
                onSubmit: function (param) {
                    param.visit = 'savecontractuserinfo';
                    param.familyList = JSON.stringify(content.list);
                },
                success: function (data) {
                    parent.MaskUtil.unmask();
                    var dataObj = eval("(" + data + ")");
                    if (dataObj.status) {
                        show_message('保存成功', 'success', function () {
                        });
                    }
                    else if (dataObj.msg) {
                        show_message(dataObj.msg, "info");
                    }
                    else {
                        show_message('系统错误', 'error');
                    }
                }
            });
        }
        function do_close() {
            parent.do_close_dialog(function () {
                parent.$("#tt_table").datagrid("reload");
            });
        }
    </script>
    <script src="../js/vue.js"></script>
    <%--<script src="../js/Page/Contract/ContractUserEdit.js?v=<%=base.getToken()%>"></script>--%>
    <style type="text/css">
        .panel-body {
            background: #f0f0f0;
        }

        table.info {
            width: 100%;
        }

            table.info td:nth-child(2n) {
                padding: 10px 0;
                width: 20%;
            }

            table.info td:nth-child(2n-1) {
                width: 13%;
            }

            table.info td input[type=text], table.info td select, table.info td input[type=password] {
                width: 15%;
            }

            table.info td span.red {
                color: red;
                font-size: 20px;
                vertical-align: middle;
            }

        .table_box {
            margin: 0 2%;
        }

        table.field {
            width: 100%;
            border: solid 1px #ccc;
            border-spacing: 0;
            border-collapse: collapse;
            margin: 0 auto;
            background: #fff;
        }

            table.field td {
                border: solid 1px #ccc;
                padding: 5px;
            }

            table.field input[type=text] {
                width: 200px;
                border: solid 1px #ddd;
                line-height: 28px;
                height: 28px;
                border-radius: 5px !important;
            }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <form id="ff" runat="server" method="post" enctype="multipart/form-data">
        <div class="operation_box">
            <%if (this.canEdit)
                { %>
            <a href="javascript:void(0)" onclick="do_save()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-save'">保存</a>
            <%} %>
            <a href="javascript:void(0)" onclick="do_close()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-close'">关闭</a>
        </div>
        <div class="table_container">
            <div class="table_title">基本信息</div>
            <div class="table_box">
                <table class="info">
                    <tr>
                        <td>租户类型<span class="red">*</span></td>
                        <td>
                            <select runat="server" class="easyui-combobox" id="tdRelationProperty" data-options="required:true,editable:false">
                                <option value="geren">个人</option>
                                <option value="gongsi">公司</option>
                            </select></td>
                    </tr>
                    <tr>
                        <td>租户名称<span class="red">*</span></td>
                        <td>
                            <input type="text" runat="server" name="RentName" class="easyui-textbox" id="tdRentName" data-options="required:true" />
                        </td>
                        <td class="companyBox">联系人</td>
                        <td class="companyBox">
                            <input type="text" runat="server" data-name="rent_content" class="easyui-textbox" id="tdCustomerName" /></td>
                        <td>联系电话</td>
                        <td>
                            <input type="text" runat="server" name="ContractPhone" class="easyui-textbox" id="tdContractPhone" /></td>
                    </tr>
                    <tr>
                        <td>证件类别</td>
                        <td>
                            <select class="easyui-combobox" id="tdIDCardType" runat="server" data-options="editable:false">
                                <option value="1">身份证</option>
                                <option value="2">护照</option>
                                <option value="3">军人证</option>
                                <option value="4">驾驶证</option>
                                <option value="5">其他</option>
                            </select></td>
                        <td>证件号码</td>
                        <td>
                            <input type="text" runat="server" name="IDCardNo" class="easyui-textbox" id="tdIDCardNo" /></td>
                        <td>身份证地址</td>
                        <td>
                            <input type="text" runat="server" name="IDCardAddress" class="easyui-textbox" id="tdIDCardAddress" /></td>
                    </tr>
                    <tr class="companyBox">
                        <td>法人代表</td>
                        <td>
                            <input type="text" runat="server" name="InChargeMan" class="easyui-textbox" id="tdInChargeMan" /></td>
                        <td>营业执照</td>
                        <td>
                            <input type="text" runat="server" name="BusinessLicense" class="easyui-textbox" id="tdBusinessLicense" /></td>
                        <td>经营品类</td>
                        <td>
                            <input type="text" runat="server" name="SellerProduct" class="easyui-textbox" id="tdSellerProduct" /></td>
                    </tr>
                </table>
            </div>
            <div class="table_title" style="display: none;">成员</div>
            <div class="table_box" style="display: none;">
                <div id="fieldcontent">
                    <table class="field">
                        <tr>
                            <td colspan="4">
                                <a href="javascript:void(0)" v-on:click="add_line()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-add'">添加</a>
                            </td>
                        </tr>
                        <tr>
                            <td>姓名
                            </td>
                            <td>电话
                            </td>
                            <td>成员关系
                            </td>
                            <td></td>
                        </tr>
                        <tr v-for="(item, index) in list">
                            <td>
                                <input type="text" style="height: 28px; width: 120px;" v-model="item.CustomerName" />
                            </td>
                            <td>
                                <input type="text" style="height: 28px; width: 120px;" v-model="item.PhoneNumber" />
                            </td>
                            <td>
                                <input type="text" style="height: 28px; width: 120px;" v-model="item.RelationDesc" />
                            </td>
                            <td>
                                <a href="javascript:void(0)" v-on:click="remove_line(item)">删除</a>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>
    </form>
</asp:Content>
