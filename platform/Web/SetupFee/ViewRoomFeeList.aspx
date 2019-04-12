<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="ViewRoomFeeList.aspx.cs" Inherits="Web.SetupFee.ViewRoomFeeList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        var KeywordsObj, CompanyID, ChargeIDObj;
        $(function () {
            KeywordsObj = $("#<%=this.tdKeywords.ClientID%>");
            CompanyID = "<%=Web.WebUtil.GetCompanyID(this.Context)%>";
            ChargeIDObj = $("#<%=this.tdChargeName.ClientID%>");
        })
        function DoExport() {
            var roomids = [];
            var projectid = '';
            try {
                roomids = parent.GetSelectRoomCheck();
                projectid = parent.GetSelectRadio();
            } catch (e) {

            }
            if (roomids.length == 0 && (projectid == null || projectid == "")) {
                return;
            }
            var projectids = [];
            if (projectid != null && projectid != "") {
                projectids.push(projectid);
            }
            tt_CanLoad = true;
            var keywords = KeywordsObj.searchbox("getValue");
            var ChargeSummarys = [];
            try {
                var ChargeID = ChargeIDObj.combobox("getValue");
                if (ChargeID != 0 && ChargeID != '') {
                    ChargeSummarys.push(ChargeID);
                }
            } catch (e) {

            }
            var RoomProperty = $("#tdRoomProperty").combobox("getValue");
            var RoomPropertyList = [];
            if (RoomProperty != "") {
                RoomPropertyList.push(RoomProperty);
            }
            var options = {
                visit: "exportroomfeelist",
                RoomID: JSON.stringify(roomids),
                ProjectID: JSON.stringify(projectids),
                IsToCharge: false,
                ChargeSummarys: JSON.stringify(ChargeSummarys),
                RoomPropertyList: JSON.stringify(RoomPropertyList),
                keywords: keywords,
                StartTimeState: $('#tdStartTimeState').combobox('getValue')
            };
            MaskUtil.mask('body', '导出中');
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/ExportHandler.ashx',
                data: options,
                success: function (data) {
                    MaskUtil.unmask();
                    if (data.status) {
                        window.location.href = data.downloadurl
                        //window.open(data.downloadurl);
                        return;
                    }
                    if (data.error) {
                        show_message(data.error, 'info');
                        return;
                    }
                    show_message('系统异常', 'error');
                }
            });
        }
    </script>
    <script src="../js/Page/SetupFee/ViewRoomFeeList.js?t=<%=base.getToken()%>"></script>
    <style>
        .searcharea label {
            float: left;
            margin: 0 5px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <form runat="server">
        <div class="easyui-layout" fit="true">
            <div data-options="region:'north'" class="searcharea" style="height: 60px; padding: 10px;">
                <%if (base.CheckAuthByModuleCode("1191084"))
                  {%>
                <label>
                    收费项目：
                    <input type="text" style="width: 120px;" class="easyui-combobox" runat="server" id="tdChargeName" placeholder="收费项目" />
                </label>
                <label>
                    关键字：
                    <input class="easyui-searchbox" runat="server" id="tdKeywords" type="text" data-options="prompt:'关键字搜索',searcher:SearchTT" style="width: 200px" />
                </label>
                <label>
                    房源属性:                
                    <input class="easyui-combobox" id="tdRoomProperty" style="width: 80px;" data-options="editable:false" />
                </label>
                <label>
                    房间状态:                
                    <input class="easyui-combobox" id="tdRoomState" style="width: 80px;" data-options="editable:false" />
                </label>
                <label>
                    计费开始日期:                
                    <select class="easyui-combobox" id="tdStartTimeState" style="width: 80px;" data-options="editable:false">
                        <option value="">全部</option>
                        <option value="1">为空</option>
                        <option value="2">不为空</option>
                    </select>
                </label>
                <label>
                    <a href="javascript:void(0)" onclick="SearchTT()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-search'">查询</a>
                </label>
                <%} %>
            </div>
            <div data-options="region:'center'" title="">
                <table id="tt_table">
                    <thead>
                        <tr>
                            <th data-options="field:'ck',checkbox:true"></th>
                            <th data-options="field:'FullName'" width="200">资源位置</th>
                            <th data-options="field:'RoomName'" width="60">资源编号</th>
                            <th data-options="field:'DefaultChargeManName',formatter: formatDefaultChargeManName" width="100">收费对象</th>
                            <th data-options="field:'Name'" width="80">收费项目</th>
                            <th data-options="field:'CalculateUnitPrice',formatter: formatUnitPrice" width="100">单价(月度)</th>
                            <th data-options="field:'CalculateStartTime',formatter: formatTime" width="100">计费开始日期</th>
                            <th data-options="field:'CalculateEndTime',formatter: formatTime" width="100">计费结束日期</th>
                            <th data-options="field:'NewEndTime',formatter: formatTime" width="100">计费停用日期</th>
                            <th data-options="field:'ChargeTypeDesc'" width="80">计费规则</th>
                            <th data-options="field:'Remark'" width="100">备注</th>
                        </tr>
                    </thead>
                </table>
                <div id="tb">
                    <%if (base.CheckAuthByModuleCode("1191085"))
                      {%>
                    <a href="javascript:void(0)" onclick="EditFee()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-edit'">修改</a>
                    <%} %>
                    <%if (base.CheckAuthByModuleCode("1191086"))
                      {%>
                    <a href="javascript:void(0)" onclick="RemoveFee()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-remove'">删除</a>
                    <%} %>
                    <%if (base.CheckAuthByModuleCode("1191087"))
                      {%>
                    <a href="javascript:void(0)" onclick="DoExport()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-export'">导出</a>
                    <a href="javascript:void(0)" onclick="ImportRoomFeeTime()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-import'">导入</a>
                    <%} %>
                    <%if (base.CheckAuthByModuleCode("1191088"))
                      {%>
                    <a href="javascript:void(0)" onclick="stopFee()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-tingyong'">停用</a>
                    <%} %>
                    <%if (base.CheckAuthByModuleCode("1191089"))
                      {%>
                    <%--<a href="javascript:void(0)" onclick="deleteAll()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-remove'">全部删除</a>--%>
                    <%} %>
                    <%if (base.CheckAuthByModuleCode("1191090"))
                      {%>
                    <a href="javascript:void(0)" onclick="batchEdit()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-chuli'">批处理</a>
                    <%} %>
                </div>
            </div>
        </div>
    </form>
</asp:Content>
