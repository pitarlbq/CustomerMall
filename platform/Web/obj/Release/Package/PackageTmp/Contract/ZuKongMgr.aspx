<%@ Page Title="" Language="C#" MasterPageFile="~/Master/NavContent4.Master" AutoEventWireup="true" CodeBehind="ZuKongMgr.aspx.cs" Inherits="Web.Contract.ZuKongMgr" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .add {
            width: 100%;
            margin: 0 auto;
            margin-top: 10px;
            border-collapse: collapse;
            border-spacing: 0px;
        }

        .field {
            background: #ddd;
            width: 120px;
            min-height: 120px;
            margin: 10px;
            display: inline-table;
        }

            .field .line {
                padding: 5px 0 5px 10px;
            }

                .field .line input[type='text'], .field .line select {
                    display: inline-table;
                    width: 70% !important;
                    height: 20px;
                    line-height: 20px;
                    padding: 0px;
                }

                .field .line input[type='checkbox'] {
                    width: 20px;
                    height: 20px;
                }
    </style>
    <script>
        var GetContextPath;
        $(function () {
            GetContextPath = "<%=base.GetContextPath() %>";
        })
    </script>
    <script src="../js/vue.js"></script>
    <script src="../js/Page/Comm/GetTypeList.js?v=<%=base.getToken() %>"></script>
    <script src="../js/Page/Contract/ContractZuKongMgr.js?token=<%=base.getToken() %>"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <div class="easyui-layout" fit="true">
        <div class="op" data-options="region:'north'" style="height: 100px; padding: 10px;">
            <div style="display: inline-table; width: 100%;">
                <div style="width: 100%;">
                    <label>
                        关键字:                
                        <input class="easyui-searchbox" id="tdKeyword" type="text" data-options="prompt:'房号          ',searcher:SearchTT" style="width: 200px" />
                    </label>
                    <label>
                        房间状态:                
                        <input class="easyui-combobox" id="tdRoomState" type="text" style="width: 100px" />
                    </label>
                    <label>
                        收费状态:                
                        <select class="easyui-combobox" id="tdRoomFeeState" style="width: 100px">
                            <option value="">全部</option>
                            <option value="1">欠费</option>
                            <option value="2">未欠费</option>
                        </select>
                    </label>
                    <label>
                        欠费时间:                
                        <input class="easyui-datebox" id="tdStartTime" style="width: 100px" />
                        -
                        <input class="easyui-datebox" id="tdEndTime" style="width: 100px" />
                    </label>
                    <label>
                        <a href="javascript:void(0)" onclick="SearchTT()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-search'">查询</a>
                    </label>
                </div>
            </div>
            <div style="display: inline-table; width: 100%;">
                <div style="width: 100%;">
                    <a href="javascript:void(0)" onclick="CreateZuKong()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-add'">批量生成</a>
                    <a href="javascript:void(0)" onclick="SetUp()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-setting'">属性配置</a>
                    <a href="javascript:void(0)" onclick="doRemove()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-remove'">删除</a>
                </div>
            </div>
        </div>
        <div data-options="region:'center'" title="">
            <div id="fieldcontent">
                <div class="add">
                    <div class="easyui-resizable field" v-for="item in roomlist" v-bind:style="{ background: item.BackColor}">
                        <div v-if="!item.canedit">
                            <div class="line">
                                <input type="checkbox" v-model="item.ischecked" />
                            </div>
                            <div class="line">编号: {{item.RoomName}}</div>
                            <div class="line">房态: {{item.RoomState}}</div>
                            <div class="line">客户: {{item.RoomOwner}}</div>
                            <div class="line">欠费: {{item.RoomFee}}</div>
                            <div style="text-align: center"><a href="javascript:void(0)" v-on:click="doedit(item)" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-detail'">资源详情</a><a href="javascript:void(0)" v-on:click="viewroomfee(item)" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-shoufei'">收费中心</a></div>
                        </div>
                        <div v-if="item.canedit">
                            <div class="line">
                                编号:
                                <input type="text" v-model="item.RoomName" />
                            </div>
                            <div class="line">
                                房态:
                                <select v-model="item.RoomState">
                                    <option v-bind:value="option.ID" v-for="option in RoomStateList">{{option.Name}}</option>
                                </select>
                            </div>
                            <div class="line">
                                业主:
                                <input type="text" v-model="item.RoomOwner" />
                            </div>
                            <div style="text-align: center"><a href="javascript:void(0)" v-on:click="dosave(item)" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-save'">保存</a></div>
                        </div>
                    </div>
                </div>
                <div v-if="roomlist.length==0" style="text-align: center;">暂无数据</div>
            </div>
        </div>
    </div>
</asp:Content>
