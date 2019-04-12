<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="EditRoomName.aspx.cs" Inherits="Web.RoomResource.EditRoomName" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        var ProjectID, tdAddressProvice, tdAddressCity, tdAddressDistrict, show_address;
        $(function () {
            ProjectID = "<%=Request.QueryString["ID"]%>";
            tdAddressProvice = $('#<%=this.tdAddressProvice.ClientID%>');
            tdAddressCity = $('#<%=this.tdAddressCity.ClientID%>');
            tdAddressDistrict = $('#<%=this.tdAddressDistrict.ClientID%>');
            show_address = Number("<%=this.show_address%>");
            if (show_address) {
                $('.address').show();
                var provinceID = $('#<%=this.hdAddressProvice.ClientID%>').val();
                var cityName = $('#<%=this.hdAddressCity.ClientID%>').val();
                var districtName = $('#<%=this.hdAddressDistrict.ClientID%>').val();
                if (provinceID != '' && cityName != '' && districtName != '') {
                    get_provice(provinceID, cityName, districtName);
                }
                else {
                    get_provice();
                }
            }
            else {
                $('.address').hide();
            }
        })
        function get_provice(provinceID, cityName, districtName) {
            $.ajax({
                type: 'GET',
                dataType: 'json',
                url: '../js/json/province.txt',
                success: function (data) {
                    tdAddressProvice.combobox({
                        editable: false,
                        valueField: 'provinceID',
                        textField: 'provinceName',
                        data: data,
                        onSelect: function (ret) {
                            get_city(ret.provinceID);
                        }
                    })
                    if (provinceID) {
                        tdAddressProvice.combobox('setValue', provinceID);
                        get_city(provinceID, cityName, districtName);
                    }
                }
            });
        }
        function get_city(provinceID, cityName, districtName) {
            $.ajax({
                type: 'GET',
                dataType: 'json',
                url: '../js/json/city.txt',
                success: function (data) {
                    var list = [];
                    $.each(data, function (index, item) {
                        if (item.provinceID == provinceID) {
                            list.push(item);
                        }
                    })
                    tdAddressCity.combobox({
                        editable: false,
                        valueField: 'cityName',
                        textField: 'cityName',
                        data: list,
                        onSelect: function (ret) {
                            get_district(ret.cityID)
                        }
                    })
                    var cityID = 0;
                    if (cityName && cityName != '') {
                        tdAddressCity.combobox('setValue', cityName);
                        $.each(data, function (index, item) {
                            if (item.cityName == cityName) {
                                cityID = item.cityID
                            }
                        })
                        if (cityID > 0) {
                            get_district(cityID, districtName);
                        }
                    }
                }
            });
        }
        function get_district(cityID, districtName) {
            $.ajax({
                type: 'GET',
                dataType: 'json',
                url: '../js/json/district.txt',
                success: function (data) {
                    var list = [];
                    $.each(data, function (index, item) {
                        if (item.cityID == cityID) {
                            list.push(item);
                        }
                    })
                    tdAddressDistrict.combobox({
                        editable: false,
                        valueField: 'districtName',
                        textField: 'districtName',
                        data: list
                    })
                    if (districtName && districtName != '') {
                        tdAddressDistrict.combobox('setValue', districtName);
                    }
                }
            });
        }
        function do_save() {
            var ProjectName = $("#<%=this.tdProjectName.ClientID%>").textbox("getValue");
            if (ProjectName == "") {
                show_message("资源名称不能为空");
                return;
            }
            var OrderBy = $("#<%=this.tdOrderBy.ClientID%>").textbox("getValue");
            var provinceID = tdAddressProvice.combobox('getValue');
            var provinceName = tdAddressProvice.combobox('getText');
            var cityName = tdAddressCity.combobox('getValue');
            var districtName = tdAddressDistrict.combobox('getValue');

            var isValid = $("#<%=this.ff.ClientID%>").form('enableValidation').form('validate');
            if (!isValid) {
                return;
            }
            MaskUtil.mask('body', '提交中');
            $('#ff').form('submit', {
                url: '../Handler/ProjectHandler.ashx',
                onSubmit: function (param) {
                    param.visit = 'saveprojectname';
                    param.ProjectID = ProjectID;
                    param.ProjectName = ProjectName;
                    param.OrderBy = OrderBy;
                    param.provinceID = provinceID;
                    param.provinceName = provinceName;
                    param.cityName = cityName;
                    param.districtName = districtName;
                },
                success: function (message) {
                    MaskUtil.unmask();
                    var data = eval('(' + message + ')');
                    if (data.status) {
                        show_message("保存成功", "success", function () {
                            parent.isUpdate = true;
                            do_close();
                        });
                        return;
                    }
                    if (data.error) {
                        show_message(data.error, 'warning');
                        return;
                    }
                    show_message("保存失败", "error");
                }
            });
        }
        function do_close() {
            parent.do_close_dialog(function () {
                parent.$("#tt_table").datagrid("reload");
                parent.doSearch();
            });
        }
        function doNewSort() {
            var SortOrder = $("#<%=this.tdOrderBy.ClientID%>").textbox("getValue");
            if (SortOrder == "") {
                return;
            }
            MaskUtil.mask('body', '提交中...<br/>时间可能会比较长,请耐心等待');
            $('.datagrid-mask-msg').css('height', '70px');
            $('#ff').form('submit', {
                url: '../Handler/ProjectHandler.ashx',
                onSubmit: function (param) {
                    param.visit = 'saveprojectneworder';
                    param.ProjectID = ProjectID;
                    param.SortOrder = SortOrder;
                },
                success: function (message) {
                    MaskUtil.unmask();
                    var data = eval("(" + message + ")");
                    if (data.status) {
                        show_message("保存成功", "success");
                        return;
                    }
                    if (data.error) {
                        show_message(data.error, "warning");
                        return;
                    }
                    show_message("保存失败", "error");
                }
            });
        }
    </script>
    <style>
        .panel-body {
            background: #f0f0f0;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <form runat="server" id="ff" method="post" enctype="multipart/form-data">
        <div class="operation_box">
            <a href="javascript:void(0)" onclick="do_save()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-save'">保存</a>
            <a href="javascript:void(0)" onclick="do_close()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-close'">关闭</a>
        </div>
        <div class="table_container">
            <table class="info">
                <tr>
                    <td class="first">资源名称</td>
                    <td class="second">
                        <input id="tdProjectName" runat="server" class="easyui-textbox" type="text" name="ProjectName" />
                    </td>
                    <td class="first">排序序号</td>
                    <td class="second">
                        <input id="tdOrderBy" runat="server" class="easyui-textbox" type="text" name="OrderBy" style="width: 50%;" />
                        <a href="javascript:void(0)" onclick="doNewSort()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-paixu'">重新排序</a>
                    </td>
                </tr>
                <tr class="address">
                    <td class="first">所在省</td>
                    <td class="second">
                        <input id="tdAddressProvice" runat="server" class="easyui-combobox" name="AddressProvice" />
                        <asp:HiddenField runat="server" ID="hdAddressProvice" />
                    </td>
                    <td class="first">所在市</td>
                    <td class="second">
                        <input id="tdAddressCity" runat="server" class="easyui-combobox" name="AddressCity" />
                        <asp:HiddenField runat="server" ID="hdAddressCity" />
                    </td>
                </tr>
                <tr class="address">
                    <td class="first">所在区</td>
                    <td class="second">
                        <input id="tdAddressDistrict" runat="server" class="easyui-combobox" name="AddressDistrict" />
                        <asp:HiddenField runat="server" ID="hdAddressDistrict" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</asp:Content>
