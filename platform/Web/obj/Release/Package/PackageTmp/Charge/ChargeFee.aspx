<%@ Page Title="" Language="C#" MasterPageFile="~/Master/NavContent2.Master" AutoEventWireup="true" CodeBehind="ChargeFee.aspx.cs" Inherits="Web.Charge.ChargeFee" %>
<%--业态不可选 房间单选--%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../js/Page/Comm/GetTypeList.js?v=<%=base.getToken() %>"></script>
    <script type="text/javascript">
        var companyID, AddMan, RoomID;
        $(function () {
            companyID = "<%=Web.WebUtil.GetCompanyID(this.Context)%>";
            AddMan = "<%=Web.WebUtil.GetUser(this.Context).RealName%>";
            RoomID = "<%=Request.QueryString["RoomID"]%>" || 0;
        })
    </script>
    <script src="../js/Page/Charge/ChargeFee.js?v=<%=base.getToken() %>" type="text/javascript"></script>
    <style>
        .roomtable {
            width: 100%;
        }

            .roomtable td {
                text-align: center;
            }

        .hidden {
            display: none;
        }

        .inputbox {
            width: 100px;
        }

        .tdfield .l-btn.btn-white {
            border: 1px solid #cccccc !important;
        }

        .l-btn.btn-blue {
            background-color: #ccc !important;
            border: solid 1px #cccccc;
            color: #0088cc !important;
            text-shadow: none !important;
            padding: 6px 12px !important;
            line-height: 30px !important;
        }

        btn.clickBtn {
            background-color: #ccc;
            color: red;
        }

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
    <script>
        $(function () {
            $(".opbtn").click(function () {
                var $this = $(this);
                var r = $(".opbtn");
                for (var i = 0; i < r.length; i++) {
                    if (!$(r[i]).hasClass("btn-white")) {
                        $(r[i]).addClass("btn-white");
                    }
                    $(r[i]).removeClass("btn-blue");
                }
                $this.removeClass("btn-white");
                $this.addClass("btn-blue");
            })
        })
    </script>
    <style>
        table.noteitem {
            width: 96%;
            margin-top: 10px;
        }

        table.notecontent td {
            text-align: left;
            padding: 10px 0;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <div class="easyui-layout" fit="true">
        <div data-options="region:'north'" style="height: 80px; padding: 5px 10px;">
            <table class="roomtable">
                <tr>
                    <td>编号:
                    </td>
                    <td>
                        <input class="easyui-textbox inputbox" type="text" id="tbRoomName" />
                    </td>
                    <td>
                        <label id="tdOwnerTitle">住户：</label>
                    </td>
                    <td>
                        <input class="easyui-combobox inputbox" type="text" id="tbRoomOwner" />
                    </td>
                    <td>电话:</td>
                    <td>
                        <input class="easyui-textbox inputbox" type="text" id="tbOwnerPhone" />
                    </td>
                    <td>计费面积:</td>
                    <td>
                        <input class="easyui-textbox inputbox" type="text" id="tbBuildingArea" />
                    </td>
                    <td>房间状态:</td>
                    <td>
                        <input class="easyui-combobox inputbox" type="text" id="tbRoomStateDesc" />
                    </td>
                    <td>
                        <%if (base.CheckAuthByModuleCode("1191472"))
                          {%>
                        <a href="#" onclick="EditSource()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-edit'">修改</a>
                        <%} %>
                         <%if (base.CheckAuthByModuleCode("1191473"))
                          {%>
                        <a href="#" onclick="saveRoomSource()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-save'">保存</a>
                        <%} %>
                    </td>
                </tr>
                <tr>
                    <td colspan="11" style="text-align: left;" class="tdfield">
                        <%if (base.CheckAuthByModuleCode("1101057"))
                          {%>
                        <a id="opbtn" href="javascript:void(0)" onclick="viewRoomFeeList()" class="opbtn easyui-linkbutton btntoolbar linebar" data-options="plain:true,iconCls:'icon-mingxi'">账单明细</a>
                        <%} %>
                        <span id="contractfeelable"></span>
                        <%if (base.CheckAuthByModuleCode("1101058"))
                          {%>
                        <a href="javascript:void(0)" onclick="viewRoomFeeHistoryList()" class="opbtn easyui-linkbutton btntoolbar linebar" data-options="plain:true,iconCls:'icon-lishi'">历史账单</a>
                        <%} %>
                        <a style="display: none;" href="javascript:void(0)" onclick="viewshaobiaoFeeList()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-import'">导入记录</a>
                        <%if (base.CheckAuthByModuleCode("1101059"))
                          {%>
                        <span id="prefeelable"></span>
                        <%} %>
                        <%if (base.CheckAuthByModuleCode("1101060"))
                          {%>
                        <a href="javascript:void(0)" onclick="viewGuaranteeFeeList()" class="opbtn easyui-linkbutton btntoolbar linebar" data-options="plain:true,iconCls:'icon-baozhengjin'">保证金</a>
                        <%} %>
                        <span style="position: relative;">
                            <a href="javascript:void(0)" onclick="viewRoomFeeNote()" class="opbtn easyui-linkbutton btntoolbar linebar" data-options="plain:true,iconCls:'icon-beiwanglu'">备忘录</a>
                            <img id="note_img" src="../styles/images/point.png" style="width: 10px; position: absolute; top: -5px; right: 0px; display: none;" />
                        </span>
                    </td>
                </tr>
            </table>
        </div>
        <div data-options="region:'center'" title="">
            <div class="easyui-panel" style="border: none;" data-options="fit:true">
                <input type="hidden" value="../Charge/ChargeFee_Bill.aspx" />
                <iframe id="ChargeFrame" name="ChargeFrame" style="position: absolute; top: 0; left: 0; right: 0; bottom: 0; width: 100%; height: 100%; border: none;" src=""></iframe>
            </div>
        </div>
    </div>
</asp:Content>
