<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="EditRentHome.aspx.cs" Inherits="Web.Wechat.EditRentHome" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../js/vue.js"></script>
    <script type="text/javascript">
        var HomeID, filecount = 0;
        $(function () {
            get_combobox_params();
            addFile();
            HomeID = "<%=this.HomeID%>";
            if (Number(HomeID) > 0) {
                loadattachs();
            }
            content = new Vue({
                el: '#fieldcontent',
                data: {
                    list: [],
                    count: 0
                },
                methods: {
                    getdata: function () {
                        var that = this;
                        if (HomeID <= 0) {
                            return;
                        }
                        var options = { visit: 'getrenthometype', ID: HomeID };
                        $.ajax({
                            type: 'POST',
                            dataType: 'json',
                            url: '../Handler/WechatHandler.ashx',
                            data: options,
                            success: function (data) {
                                if (data.status) {
                                    that.list = data.list;
                                    that.count = that.list.length;
                                    return;
                                }
                                show_message('系统错误', 'error');
                            }
                        });
                    },
                    add_line: function () {
                        var that = this;
                        that.count++;
                        var item = { ID: 0, TypeName: '', UnitPrice: 0, Unit: '月', TypeArea: 0, TypeTags: '', RentStatus: 0, count: that.count };
                        that.list.push(item);
                    },
                    remove_line: function (item) {
                        var that = this;
                        if (item.ID == 0) {
                            $.each(that.list, function (index, item2) {
                                if (item.count == item2.count) {
                                    that.list.splice(index, 1);
                                    return false;
                                }
                            });
                            return;
                        }
                        top.$.messager.confirm('提示', '确认删除?', function (r) {
                            if (r) {
                                var options = { visit: 'removerenthometype', ID: item.ID };
                                $.ajax({
                                    type: 'POST',
                                    dataType: 'json',
                                    url: '../Handler/WechatHandler.ashx',
                                    data: options,
                                    success: function (data) {
                                        if (data.status) {
                                            that.getdata();
                                            return;
                                        }
                                        show_message('系统错误', 'error');
                                    }
                                });
                            }
                        })
                    }
                }
            });
            content.getdata();
        });
        function do_save() {
            var isValid = $("#<%=this.ff.ClientID%>").form('enableValidation').form('validate');
            if (!isValid) {
                return;
            }
            MaskUtil.mask('body', '提交中');
            $('#ff').form('submit', {
                url: '../Handler/WechatHandler.ashx',
                onSubmit: function (param) {
                    param.visit = 'saverenthome';
                    param.HomeID = HomeID;
                    param.options = JSON.stringify(content.list);
                },
                success: function (data) {
                    MaskUtil.unmask();
                    var dataObj = eval("(" + data + ")");
                    if (dataObj.status) {
                        show_message('保存成功', 'success', function () {
                            do_close();
                        });
                    }
                    else {
                        show_message('系统错误', 'error');
                    }
                }
            });
        }

        function do_close() {
            parent.do_close_dialog(function () {
                parent.$('#tt_table').datagrid('reload');
            });
        }
        $(function () {
            $('.Subways_label label').bind('click', function () {
                var label_text = $.trim($(this).text());
                setTagValues($("#<%=this.tdSubways.ClientID%>"), label_text)
            })
            $('.SuperMarkets_label label').bind('click', function () {
                var label_text = $.trim($(this).text());
                setTagValues($("#<%=this.tdSuperMarkets.ClientID%>"), label_text)
            })
            $('.RoomOwners_label label').bind('click', function () {
                var label_text = $.trim($(this).text());
                setTagValues($("#<%=this.tdRoomOwners.ClientID%>"), label_text)
            })
            $('.PublicOwners_label label').bind('click', function () {
                var label_text = $.trim($(this).text());
                setTagValues($("#<%=this.tdPublicOwners.ClientID%>"), label_text)
            })
        })
        function setTagValues($ID, label_text) {
            var values = $ID.textbox('getValue');
            values = (values == "" ? label_text : values + ',' + label_text);
            $ID.textbox('setValue', values);
        }
        var LngLat = null;
        function open_map_location() {
            var iframe = "../Wechat/MapLocation.aspx";
            do_open_dialog('坐标定位', iframe);
        }
        function open_map_location_done() {
            if (LngLat != null) {
                $('#<%=this.tdMapLocation.ClientID%>').textbox('setValue', LngLat);
        }
    }
    var building_list = [];
    function get_combobox_params() {
        var options = { visit: 'geteditrenthomeparams' };
        $.ajax({
            type: 'POST',
            dataType: 'json',
            url: '../Handler/WechatHandler.ashx',
            data: options,
            success: function (data) {
                if (data.status) {
                    building_list = data.buildinglist;
                    $('#<%=this.tdRentArea.ClientID%>').combobox({
                        data: data.arealist,
                        textField: "Name",
                        valueField: "ID",
                        editable: false,
                        onSelect: function (ret) {
                            setBuildingCombobox(ret.ID, true);
                        }
                    })
                    var areaId = $('#<%=this.tdRentArea.ClientID%>').combobox('getValue');
                    if (areaId != '') {
                        setBuildingCombobox(areaId, false);
                    }
                    return;
                }
                show_message('系统错误', 'error');
            }
        });
    }
    function setBuildingCombobox(areaID, resetValue) {
        var my_buildings = [];
        $.each(building_list, function (index, building) {
            if (building.AreaID == areaID) {
                my_buildings.push(building);
            }
        })
        $('#<%=this.tdRentBuilding.ClientID%>').combobox({
            data: my_buildings,
            textField: "Name",
            valueField: "ID",
            editable: false
        })
        if (resetValue) {
            if (my_buildings.length > 0) {
                $('#<%=this.tdRentBuilding.ClientID%>').combobox('setValue', my_buildings[0].ID);
            }
            else {
                $('#<%=this.tdRentBuilding.ClientID%>').combobox('setValue', "");
            }
        }
        else {
            var buildingId = $('#<%=this.tdRentBuilding.ClientID%>').combobox('getValue');
            if (my_buildings.length > 0) {
                $('#<%=this.tdRentBuilding.ClientID%>').combobox('setValue', buildingId);
            }
            else {
                $('#<%=this.tdRentBuilding.ClientID%>').combobox('setValue', "");
            }
        }
    }
    function addFile() {
        $("#tdFile").find("a.fileadd").hide();
        $("#tdFile").find("a.fileremove").show();
        filecount++;
        var $html = "<div id=\"tdFile_" + filecount + "\">";
        $html += "<input class=\"easyui-filebox\" name=\"attachfile\" data-options=\"prompt:'请选择文件',buttonText: '选择文件'\" style=\"width: 60%\" />";
        $html += '<a href="javascript:void(0)" onclick="addFile()" class="easyui-linkbutton btnlinkbar fileadd" data-options="plain:true,iconCls:\'icon-search\'">添加</a>';
        $html += '<a href="javascript:void(0)" onclick="deleteFile(' + filecount + ')" class="easyui-linkbutton btnlinkbar fileremove" style="display:none;" data-options="plain:true,iconCls:\'icon-search\'">删除</a>';
        $html += "</div>";
        $("#tdFile").append($html);
        $.parser.parse("#tdFile_" + filecount);
    }
    function deleteFile(id) {
        $("#tdFile_" + id).html("");
    }
    function loadattachs() {
        var options = { visit: 'loadrenthomeattachs', ID: HomeID };
        $.ajax({
            type: 'POST',
            dataType: 'json',
            url: '../Handler/WechatHandler.ashx',
            data: options,
            success: function (data) {
                var $html = '';
                $("#trExistFiles").html($html);
                if (data.length > 0) {
                    $("#trExistFiles").show();
                    $html += '<td>已上传图片</td>';
                    $html += '<td colspan="3">';
                    $.each(data, function (index, item) {
                        $html += '<div>' + item.FileOriName + ' &nbsp;&nbsp;&nbsp;&nbsp;<a href="' + item.AttachedFilePath + '" target="_blank" >下载</a>&nbsp;&nbsp;&nbsp;&nbsp;';
                        $html += '<a href="#" onclick="deleteAttach(' + item.ID + ')">删除</a></div>';
                    })
                    $html += '</td>';
                }
                $("#trExistFiles").append($html);
            }
        });
    }
    function deleteAttach(AttachID) {
        top.$.messager.confirm("提示", "是否删除选已上传的图片?", function (r) {
            if (r) {
                var options = { visit: 'deleterenthomefile', ID: AttachID };
                $.ajax({
                    type: 'POST',
                    dataType: 'json',
                    url: '../Handler/WechatHandler.ashx',
                    data: options,
                    success: function (message) {
                        if (message.status) {
                            show_message('删除成功', 'success', function () {
                                loadattachs();
                            });
                            return;
                        }
                        show_message('系统错误', 'error');
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

        table.field {
            width: 90%;
            margin: 0 auto;
            border: solid 1px #ccc;
            border-spacing: 0;
            border-collapse: collapse;
            background: #fff;
        }

            table.field td {
                border: solid 1px #ccc;
                padding: 2px 5px;
            }


        .field input[type=text], .field select {
            width: 100px;
            height: 25px;
            border-radius: 5px !important;
        }

        table.info label {
            cursor: pointer;
            color: #2f80d1;
            margin: 0 5px;
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
                    <td>房间名称
                    </td>
                    <td colspan="3">
                        <input type="text" style="width: 70%;" class="easyui-textbox" id="tdHomeName" runat="server" data-options="required:true" />
                    </td>
                </tr>

                <tr>
                    <td>具体地址
                    </td>
                    <td colspan="3">
                        <input type="text" style="width: 70%;" class="easyui-textbox" id="tdHomeLocation" runat="server" data-options="required:true" />
                    </td>
                </tr>
                <tr>
                    <td>联系电话
                    </td>
                    <td>
                        <input type="text" class="easyui-textbox" id="tdPhoneNumber" runat="server" data-options="required:true" />
                    </td>
                    <td>户型
                    </td>
                    <td>
                        <select type="text" class="easyui-combobox" id="tdHomeType" runat="server" data-options="editable:false">
                            <option value="zhengzu">整租</option>
                            <option value="hezu">合租</option>
                            <option value="zhuwo">主卧</option>
                            <option value="ciwo">次卧</option>
                        </select>
                    </td>
                </tr>
                <tr>
                    <td>所属区域
                    </td>
                    <td>
                        <input type="text" class="easyui-combobox" id="tdRentArea" runat="server" data-options="required:true" />
                    </td>
                    <td>所属楼盘
                    </td>
                    <td>
                        <input type="text" class="easyui-combobox" id="tdRentBuilding" runat="server" data-options="required:true" />
                    </td>
                </tr>
                <tr>
                    <td>交通信息(地铁)
                    </td>
                    <td colspan="2">
                        <input type="text" style="width: 80%; height: 45px;" class="easyui-textbox" id="tdSubways" runat="server" data-options="multiline:true" />
                    </td>
                    <td class="Subways_label" style="text-align: left;">
                        <label>1号线</label>
                        <label>2号线</label>
                        <label>3号线</label>
                        <label>4号线</label>
                        <label>5号线</label>
                        <label>6号线</label>
                        <label>7号线</label>
                    </td>
                </tr>
                <tr>
                    <td>交通信息(公交)
                    </td>
                    <td colspan="3">
                        <input type="text" style="width: 80%; height: 45px;" class="easyui-textbox" id="tdTraffics" runat="server" data-options="multiline:true" />
                    </td>
                </tr>
                <tr>
                    <td>附近超市
                    </td>
                    <td colspan="2">
                        <input type="text" style="width: 80%; height: 45px;" class="easyui-textbox" id="tdSuperMarkets" runat="server" data-options="multiline:true" />
                    </td>
                    <td class="SuperMarkets_label" style="text-align: left;">
                        <label>伊藤洋华堂</label>
                        <label>红旗连锁</label>
                        <label>舞东风</label>
                        <label>家乐福</label>
                        <label>沃尔玛</label>
                        <label>万达</label>
                    </td>
                </tr>
            </table>
            <div class="table_title">房间管理</div>
            <div id="fieldcontent">
                <table class="field">
                    <tr>
                        <td colspan="7">
                            <a href="javascript:void(0)" v-on:click="add_line()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-add'">添加</a>
                        </td>
                    </tr>
                    <tr>
                        <td>名称
                        </td>
                        <td>面积
                        </td>
                        <td>单价
                        </td>
                        <td>单位
                        </td>
                        <td>状态
                        </td>
                        <td>补充
                        </td>
                        <td></td>
                    </tr>
                    <tr v-for="(item, index) in list">
                        <td>
                            <input type="text" v-model="item.TypeName" />
                        </td>
                        <td>
                            <input type="text" v-model="item.TypeArea" />
                        </td>
                        <td>
                            <input type="text" v-model="item.UnitPrice" />
                        </td>
                        <td>
                            <select v-model="item.Unit">
                                <option value="月">每月</option>
                                <option value="年">每年</option>
                                <option value="平方米">每平方米</option>
                            </select>
                        </td>
                        <td>
                            <select v-model="item.RentStatus">
                                <option value="0">未租出</option>
                                <option value="1">已租出</option>
                            </select>
                        </td>
                        <td>
                            <input type="text" v-model="item.TypeTags" placeholder="独卫,空调" />
                        </td>
                        <td>
                            <a href="javascript:void(0)" v-on:click="remove_line(item)" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-remove'">删除</a>
                        </td>
                    </tr>
                </table>
            </div>
            <table class="info" style="margin-top: 10px;">
                <tr>
                    <td>房间配置
                    </td>
                    <td colspan="2">
                        <input type="text" style="width: 80%; height: 45px;" class="easyui-textbox" id="tdRoomOwners" runat="server" data-options="multiline:true" />
                    </td>
                    <td class="RoomOwners_label" style="text-align: left;">
                        <label>床</label>
                        <label>书桌</label>
                        <label>衣柜</label>
                        <label>椅子</label>
                        <label>鞋架</label>
                        <label>台灯</label>
                        <label>空调</label>
                        <label>窗帘</label>
                        <label>床头柜</label>
                    </td>
                </tr>
                <tr>
                    <td>公共区域配置
                    </td>
                    <td colspan="2">
                        <input type="text" style="width: 80%; height: 45px;" class="easyui-textbox" id="tdPublicOwners" runat="server" data-options="multiline:true" />
                    </td>
                    <td class="PublicOwners_label" style="text-align: left;">
                        <label>冰箱</label>
                        <label>洗衣机</label>
                        <label>微波炉</label>
                        <label>餐椅</label>
                        <label>餐桌</label>
                        <label>热水器</label>
                        <label>浴霸</label>
                        <label>拖把</label>
                        <label>扫把</label>
                        <label>床头柜</label>
                    </td>
                </tr>
                <tr>
                    <td>详细说明
                    </td>
                    <td colspan="3">
                        <input type="text" style="width: 80%; height: 100px;" class="easyui-textbox" id="tdRoomDescription" runat="server" data-options="multiline:true" />
                    </td>
                </tr>
                <tr>
                    <td>地图位置
                    </td>
                    <td colspan="2">
                        <input type="text" style="width: 50%;" class="easyui-textbox" id="tdMapLocation" runat="server" />
                    </td>
                    <td style="text-align: left;"><a href="javascript:void(0)" onclick="open_map_location()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-detail'">标注</a></td>
                </tr>
                <tr id="trExistFiles" style="display: none;">
                </tr>
                <tr>
                    <td>图片</td>
                    <td colspan="3" id="tdFile"></td>
                </tr>
            </table>
        </div>
    </form>
</asp:Content>
