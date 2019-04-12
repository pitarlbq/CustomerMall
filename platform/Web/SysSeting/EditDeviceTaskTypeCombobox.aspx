<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="EditDeviceTaskTypeCombobox.aspx.cs" Inherits="Web.SysSeting.EditDeviceTaskTypeCombobox" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .add, .exist {
            width: 96%;
            margin: 0 auto;
            margin-top: 10px;
            border-collapse: collapse;
            border-spacing: 0px;
            border: solid 1px #ccc;
        }

        .field {
            padding: 3px 5px;
            text-align: left;
            border-right: solid 1px #ccc;
            border-bottom: solid 1px #ccc;
            width: 33%;
            display: inline-table;
        }

        .exist_field {
            padding: 3px 5px;
            text-align: left;
            border: solid 1px #ccc;
            width: 50%;
            display: inline-table;
        }

            .exist_field .exist_field_label {
                text-align: right;
                width: 30%;
                display: inline-table;
            }

            .exist_field input {
                text-align: left;
                width: 70%;
                display: inline-table;
                padding-left: 10px;
                border: 0;
                border-left: 1px #ccc solid;
            }

        input {
            width: 70%;
        }

        .add .title, .exist .title {
            text-align: center;
            padding: 5px 0;
            color: #000;
            background-color: #ccc;
        }
    </style>
    <script src="../js/Page/SysSetting/EditDeviceTaskTypeCombobox.js?t=<%=base.getToken() %>"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <form id="ff" runat="server">
        <div class="operation_box">
            <a href="javascript:void(0)" onclick="addcolumn()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-add'">新增</a>
            <a href="javascript:void(0)" onclick="savecolumns()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-save'">保存</a>
            <a href="javascript:void(0)" onclick="do_close()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-close'">关闭</a>
        </div>
        <div class="table_container">
            <div class="table_title">
                维保类型
            </div>
            <div class="add" id="tasktype_field">
            </div>
        </div>
    </form>
</asp:Content>
