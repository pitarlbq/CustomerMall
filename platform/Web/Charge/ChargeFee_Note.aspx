<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="ChargeFee_Note.aspx.cs" Inherits="Web.Charge.ChargeFee_Note" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../js/Page/Comm/GetTypeList.js?v=<%=base.getToken() %>"></script>
    <script type="text/javascript">
        var companyID, AddMan, hdPriceRangeList, hdChargeDiscount;
        $(function () {
            companyID = "<%=Web.WebUtil.GetCompanyID(this.Context)%>";
            AddMan = "<%=Web.WebUtil.GetUser(this.Context).RealName%>";
        })
    </script>
    <script src="../js/Page/Comm/ChargeFeeComm.js?v=<%=base.getToken() %>" type="text/javascript"></script>
    <script src="../js/Page/Charge/ChargeFee_Note.js?v=<%=base.getToken() %>" type="text/javascript"></script>
    <style>
        .noteTitle {
            background: #cccccc;
            border-top-left-radius: 3px;
            border-top-right-radius: 3px;
            line-height: 30px;
            padding: 0px 10px;
        }

        .noteDesc {
            padding: 10px;
            border: solid 1px #ccc;
            border-top: 0px;
            margin-bottom: 10px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <form id="ff" runat="server" method="post" enctype="multipart/form-data">
        <div class="easyui-layout" fit="true">
            <div data-options="region:'center'" title="">
                <div style="width: 96%; margin: 0 0 0 2%;">
                    <a href="javascript:void(0)" onclick="saveNote()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-save'">保存</a>
                    <a href="javascript:void(0)" onclick="deleteNotes()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-remove'">删除</a>
                </div>
                <div style="width: 96%; margin: 0 0 0 2%;">
                    <input type="text" class="easyui-textbox" data-options="prompt:'请输入备忘内容',multiline:true,required:true" style="height: 60px; width: 500px;" id="noteDesc" />
                    <br />
                    <input class="easyui-filebox" id="attachfile" name="attachfile" data-options="prompt:'请选择文件',buttonText: '选择文件'" style="width: 500px;" />
                </div>
                <div id="noteContent" style="width: 96%; margin: 0 0 0 2%;"></div>
            </div>
        </div>
    </form>
</asp:Content>
