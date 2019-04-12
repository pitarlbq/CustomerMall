<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="EditZhuangXiuCategoryCombobox.aspx.cs" Inherits="Web.SysSeting.EditZhuangXiuCategoryCombobox" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .panel-body {
            background: #f0f0f0;
        }

        input {
            width: 70%;
        }

        .add, .exist {
            width: 96%;
            margin: 0 auto;
            border-collapse: collapse;
            border-spacing: 0px;
            border: solid 1px #ccc;
            background-color: #fff;
        }

        .field, .exist_field {
            padding: 3px 5px;
            text-align: left;
            border: solid 1px #ccc;
            width: 49%;
            display: inline-table;
        }


            .field .exist_field_label, .exist_field .exist_field_label {
                text-align: right;
                width: 30%;
                display: inline-table;
            }

            .field input, .exist_field input {
                text-align: left;
                width: 60%;
                display: inline-table;
                padding-left: 10px;
                border: 0;
                border: 1px #ccc solid;
            }



        .add .title, .exist .title {
            text-align: center;
            padding: 5px 0;
            color: #000;
            background-color: #ccc;
        }
    </style>
    <script src="../js/Page/SysSetting/EditZhuangXiuCategoryCombobox.js?t=<%=base.getToken() %>"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <form id="ff" runat="server">
        <div class="operation_box">
            <a href="javascript:void(0)" onclick="addzhuangxiucategory()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-add'">新增</a>
            <a href="javascript:void(0)" onclick="savecolumns('zhuangxiucategory')" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-save'">保存</a>
            <a href="javascript:void(0)" onclick="do_close()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-close'">关闭</a>
        </div>
        <div class="table_container">
            <div class="table_title">项目类别</div>
            <div class="add" id="zhuangxiucategory_field">
            </div>
            <div style="text-align: center;">
            </div>
        </div>
    </form>
</asp:Content>
