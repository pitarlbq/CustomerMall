<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="NewEditContract.aspx.cs" Inherits="Web.Contract.NewEditContract" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        var guid = '', op = '', ContractID = 0, TopContractID = 0, canAdd = 0, canEdit = 0, canSaveLog = 0, canPrint = 0, canRent = 0, canView = 0, canNewRent = 0, tabIndex = 0;
        $(function () {
            guid = "<%=this.guid%>";
            op = "<%=this.op%>";
            ContractID = Number("<%=this.ContractID%>");
            TopContractID = Number("<%=this.TopContractID%>");
            canAdd = "<%=this.canAdd?1:0%>";
            canEdit = "<%=this.canEdit?1:0%>";
            canSaveLog = "<%=this.canSaveLog?1:0%>";
            canPrint = "<%=this.canPrint?1:0%>";
            canRent = "<%=this.canRent?1:0%>";
            canView = "<%=this.canView?1:0%>";
            canNewRent = "<%=this.canNewRent?1:0%>";
            $('#ContractTab').tabs({
                onSelect: function (title, index) {
                    tabIndex = index;
                    loadIframe(title);
                }
            });
            setTimeout(function () {
                loadIframe();
            }, 100);
        })
        function loadIframe(title) {
            var curTab = $('#ContractTab').tabs('getSelected');
            if (curTab.find("iframe:first").attr("src") == "") {
                var iframesrc = curTab.find("input[type=hidden]:first").val();
                curTab.find("iframe:first").attr("src", iframesrc);
                var $height = $('body').height();
                curTab.find("iframe:first").css("height", "99%");
            }
            else if (title == '收费标准') {
                setPartyNames();
            }
        }
        function do_close() {
            if (ContractID <= 0) {
                top.$.messager.confirm('提示', '当前合同未保存，是否关闭?', function (r) {
                    if (r) {
                        parent.do_close_dialog(function () {
                            parent.$('#tt_table').datagrid('reload');
                        });
                    }
                })
                return;
            }
            parent.do_close_dialog(function () {
                parent.$('#tt_table').datagrid('reload');
            });
        }
        function getStartTime() {
            try {
                var StartTime = document.getElementById('ContractBasic').contentWindow.RentStartTimeObj.datebox('getValue');
                return StartTime;
            } catch (e) {
            }
        }
        function getEndTime() {
            try {
                var EndTime = document.getElementById('ContractBasic').contentWindow.RentEndTimeObj.datebox('getValue');
                return EndTime;
            } catch (e) {
            }
            return '';
        }
        function getRentToTime() {
            try {
                var RentToTime = document.getElementById('ContractBasic').contentWindow.tdRentToTime.datebox('getValue');
                return RentToTime;
            } catch (e) {
            }
            return '';
        }
        function getRooms() {
            try {
                var roomRows = document.getElementById('ContractRoomCharge').contentWindow.$("#tt_room").datagrid('getRows');
                return roomRows;
            } catch (e) {

            }
            return [];
        }
        function getPartyNames() {
            try {
                var list = document.getElementById('ContractParty').contentWindow.getPartyNameList();
                return list;
            } catch (e) {
            }
            return [];
        }
        function setPartyNames() {
            try {
                var elemObj = document.getElementById('ContractRoomCharge').contentWindow;
                elemObj.partyList = getPartyNames();
                elemObj.loadColumns();
            } catch (e) {
            }
        }
        function getContractPartyList() {
            try {
                var list = document.getElementById('ContractParty').contentWindow.getContractPartyList();
                return list;
            } catch (e) {
            }
            return [];
        }
        function getContractFeeRentList() {
            try {
                var list = document.getElementById('ContractRoomCharge').contentWindow.getContractFeeRentList();
                return list;
            } catch (e) {
            }
            return [];
        }
        function do_save() {
            var frameName = 'ContractBasic';
            if (tabIndex == 3) {
                document.getElementById('ContractMore').contentWindow.saveData();
            } else {
                document.getElementById('ContractBasic').contentWindow.do_save();
            }
        }
    </script>
    <style>
        .tabs-panels-right {
            border: 0px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <div id="main_form_layout" class="easyui-layout" data-options="fit:true,border:false">
        <div data-options="region:'north',border:false" style="height: 30px;">
            <div class="operation_box">
                <%if (this.canPrint)
                  { %>
                <a href="javascript:void(0)" onclick="printData()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-print'">打印</a>
                <%}
                  if (this.canEdit)
                  { %>
                <a href="javascript:void(0)" onclick="do_save()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-save'">保存</a>
                <%
                  } %>
                <a href="javascript:void(0)" onclick="do_close()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-close'">关闭</a>
            </div>
        </div>
        <div data-options="region:'center',border:false">
            <div class="easyui-tabs" id="ContractTab" data-options="fit:true,tabPosition:'left',headerWidth:100,tabHeight:35" style="width: 100%; height: 99%; border: none;">
                <div title="基本信息" style="padding-top: 5px; background-color: #f0f0f0;">
                    <input type="hidden" value="NewAddContract_Basic.aspx?ID=<%=this.ContractID%>&op=<%=this.op%>" />
                    <iframe src="" id="ContractBasic" style="width: 100%; height: 99%; border: 0"></iframe>
                </div>
                <div title="收款/承租方" style="padding: 0;">
                    <input type="hidden" value="NewAddContract_Part.aspx?ID=<%=this.ContractID%>&op=<%=this.op%>" />
                    <iframe src="" id="ContractParty" style="width: 100%; height: 99%; border: 0"></iframe>
                </div>
                <div title="收费标准" style="padding: 0px">
                    <input type="hidden" value="NewAddContract_RoomCharge.aspx?ID=<%=this.ContractID%>&op=<%=this.op%>" />
                    <iframe src="" id="ContractRoomCharge" style="width: 100%; height: 99%; border: 0"></iframe>
                </div>
                <div title="辅助信息" style="padding-top: 5px; background-color: #f0f0f0;">
                    <input type="hidden" value="NewAddContract_More.aspx?ID=<%=this.ContractID%>&op=<%=this.op%>" />
                    <iframe src="" id="ContractMore" style="width: 100%; height: 99%; border: 0"></iframe>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

