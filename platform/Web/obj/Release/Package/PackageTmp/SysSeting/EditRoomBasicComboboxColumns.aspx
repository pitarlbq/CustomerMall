<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="EditRoomBasicComboboxColumns.aspx.cs" Inherits="Web.SysSeting.EditRoomBasicComboboxColumns" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .panel-body {
            background: #f0f0f0;
        }

        .add, .exist {
            width: 96%;
            margin: 0 auto;
            margin-top: 10px;
            border-collapse: collapse;
            border-spacing: 0px;
            border: solid 1px #f0f0f0;
            background: #fff;
        }

        .field {
            padding: 3px 5px;
            text-align: left;
            border-right: solid 1px #f0f0f0;
            border-bottom: solid 1px #f0f0f0;
            width: 33%;
            display: inline-table;
        }

        .exist_field {
            padding: 3px 5px;
            text-align: left;
            border-right: solid 1px #f0f0f0;
            border-bottom: solid 1px #f0f0f0;
            width: 50%;
            display: inline-table;
        }

            .exist_field .exist_field_label {
                text-align: right;
                width: 30%;
                display: inline-table;
                padding-right: 10px;
            }

            .exist_field input {
                text-align: left;
                width: 70%;
                display: inline-table;
                padding-left: 10px;
                border: 0;
                border-left: 1px #ddd solid;
            }

        input[type=text] {
            width: 70%;
            height: 30px;
            border-radius: 5px !important;
            border: solid 1px #ddd;
        }

        .add .title, .exist .title {
            text-align: center;
            padding: 5px 0;
            color: #000;
            background-color: #f0f0f0;
        }
    </style>
    <script src="../js/Page/SysSetting/EditRoomBasicComboboxColumns.js?t=<%=base.getToken() %>"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <form id="ff" runat="server">
        <div class="table_title">
            房间状态<a href="javascript:void(0)" onclick="addroomstate()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-add'">新增</a>
            <a href="javascript:void(0)" onclick="savecolumns('roomstate')" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-save'">保存</a>
        </div>
        <div class="add" id="roomstate_field">
        </div>
        <div class="table_title">
            房源属性<a href="javascript:void(0)" onclick="addroomproperty()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-add'">新增</a>
            <a href="javascript:void(0)" onclick="savecolumns('roomproperty')" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-save'">保存</a>
        </div>
        <div class="add" id="roomproperty_field">
        </div>
        <div class="table_title">
            房源类型<a href="javascript:void(0)" onclick="addroomtype()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-add'">新增</a>
            <a href="javascript:void(0)" onclick="savecolumns('roomtype')" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-save'">保存</a>
        </div>
        <div class="add" id="roomtype_field">
        </div>
    </form>
</asp:Content>
