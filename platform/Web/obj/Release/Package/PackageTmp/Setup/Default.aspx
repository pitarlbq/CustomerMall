<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Web.Setup.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>出/入库</title>
    <script src="../js/jquery-1.8.3.min.js"></script>
    <script src="../js/easyui/jquery.easyui.min.js"></script>
    <script src="../js/easyui/easyui-lang-zh_CN.js"></script>
    <link href="../js/easyui/gray/easyui.css" rel="stylesheet" />
    <link href="../js/easyui/icon.css" rel="stylesheet" />
    <link href="../styles/basic.css" rel="stylesheet" />
    <link href="../js/ztree/zTreeStyle/zTreeStyle.css" rel="stylesheet" />
    <script src="../js/ztree/jquery.ztree.core.js"></script>
    <script src="../js/Page/Comm/unit.js"></script>
    <script src="../js/Page/Comm/MaskUtil.js"></script>
    <script src="../js/Page/DKSetup/SetupDefault.js?v=<%=base.getToken() %>"></script>
    <style>
        .datagrid-mask {
            position: absolute;
            left: 0;
            top: 0;
            width: 100%;
            height: 100%;
            opacity: 0.3;
            filter: alpha(opacity=30);
            display: none;
        }

        .datagrid-mask-msg {
            position: absolute;
            top: 50%;
            margin-top: -10px;
            padding: 12px 5px 12px 30px;
            width: auto;
            height: 20px;
            border-width: 2px;
            border-style: solid;
            display: none;
        }
    </style>
    <script>
        $(function () {
            $(".opbtn").click(function () {
                var $this = $(this);
                var r = $(".opbtn");
                for (var i = 0; i < r.length; i++) {
                    $(r[i]).removeClass("clickBtn");
                }
                $this.addClass("clickBtn");
            })
        })
        function ViewInOrder() {
            $("#myFrame").attr("src", "../Setup/InMgr.aspx");
        }
        function ViewOutOrder() {
            $("#myFrame").attr("src", "../Setup/OutMgr.aspx");
        }
        function ViewBusinessBalance() {
            $("#myFrame").attr("src", "../Setup/BusinessBalanceMgr.aspx");
        }
        function ViewMoveBalance() {
            $("#myFrame").attr("src", "../Setup/CarrierBalanceMgr.aspx?");
        }
        function ViewInventory() {
            $("#myFrame").attr("src", "../Setup/InventoryMgr.aspx?");
        }
        function ViewSummary() {
            $("#myFrame").attr("src", "../Setup/ViewSummary.aspx?");
        }
        function addtree() {
            var Businesstitleidarry = GetSelectedTitleByType("Business", 0);
            var Producttitleidarry = GetSelectedTitleByType("Product", 0);
            var SpecInfotitleidarry = GetSelectedTitleByType("SpecInfo", 0);
            var InventoryInfotitleidarry = GetSelectedTitleByType("InventoryInfo", 0);
            var Carriertitleidarry = GetSelectedTitleByType("CarrierGroup", 0);
            var Carrieridarry = GetSelectedTitleByType("CarrierGroup", 5);
            if (Businesstitleidarry.length > 0) {
                $("#myFrame").attr("src", "../Setup/EditBusiness.aspx");
            }
            else if (Producttitleidarry.length > 0) {
                $("#myFrame").attr("src", "../Setup/EditProduct.aspx");
            }
            else if (SpecInfotitleidarry.length > 0) {
                $("#myFrame").attr("src", "../Setup/EditSpecInfo.aspx");
            }
            else if (InventoryInfotitleidarry.length > 0) {
                $("#myFrame").attr("src", "../Setup/EditInventoryInfo.aspx");
            }
            else if (Carriertitleidarry.length > 0) {
                $("#myFrame").attr("src", "../Setup/EditCarrierGroup.aspx");
            }
            else if (Carrieridarry.length > 0) {
                $("#myFrame").attr("src", "../Setup/EditCarrier.aspx?GroupID=" + Carrieridarry[0]);
            }
            else {
                show_message("请选择一个一级资源进行此操作", "info");
            }
        }
        function edittree() {
            var Businessidarry = GetSelectedByType("Business");
            var Productidarry = GetSelectedByType("Product");
            var SpecInfoidarry = GetSelectedByType("SpecInfo");
            var InventoryInfoidarry = GetSelectedByType("InventoryInfo");
            var Carriergroupidarry = GetSelectedTitleByType("CarrierGroup", 5);
            var Carrieridarry = GetSelectedByType("Carrier");
            if (Businessidarry.length > 0) {
                $("#myFrame").attr("src", "../Setup/EditBusiness.aspx?ID=" + Businessidarry[0]);
            }
            else if (Productidarry.length > 0) {
                $("#myFrame").attr("src", "../Setup/EditProduct.aspx?ID=" + Productidarry[0]);
            }
            else if (SpecInfoidarry.length > 0) {
                $("#myFrame").attr("src", "../Setup/EditSpecInfo.aspx?ID=" + SpecInfoidarry[0]);
            }
            else if (InventoryInfoidarry.length > 0) {
                $("#myFrame").attr("src", "../Setup/EditInventoryInfo.aspx?ID=" + InventoryInfoidarry[0]);
            }
            else if (Carriergroupidarry.length > 0) {
                $("#myFrame").attr("src", "../Setup/EditCarrierGroup.aspx?ID=" + Carriergroupidarry[0]);
            }
            else if (Carrieridarry.length > 0) {
                $("#myFrame").attr("src", "../Setup/EditCarrier.aspx?ID=" + Carrieridarry[0]);
            }
            else {
                show_message("请选择一个二级资源进行此操作", "info");
            }
        }
        function deleteree() {
            var Businessidarry = GetSelectedByType("Business");
            var Productidarry = GetSelectedByType("Product");
            var SpecInfoidarry = GetSelectedByType("SpecInfo");
            var InventoryInfoidarry = GetSelectedByType("InventoryInfo");
            var Carriergroupidarry = GetSelectedTitleByType("CarrierGroup", 5);
            var Carrieridarry = GetSelectedByType("Carrier");
            var param = "";
            if (Businessidarry.length > 0) {
                param = "?BusinessID=" + Businessidarry[0];
            }
            else if (Productidarry.length > 0) {
                param = "?ProductID=" + Productidarry[0];
            }
            else if (SpecInfoidarry.length > 0) {
                param = "?SpecInfoID=" + SpecInfoidarry[0];
            }
            else if (InventoryInfoidarry.length > 0) {
                param = "?InventoryInfoID=" + InventoryInfoidarry[0];
            }
            else if (Carriergroupidarry.length > 0) {
                param = "?CarrierGroupID=" + Carriergroupidarry[0];
            }
            else if (Carrieridarry.length > 0) {
                param = "?CarrierID=" + Carrieridarry[0];
            }
            else {
                show_message("请选择一个二级资源进行此操作", "info");
                return;
            }
            top.$.messager.confirm("提示", "是否删除选中的资源", function (r) {
                if (r) {
                    var options = { visit: "deletetree" };
                    $.ajax({
                        type: 'POST',
                        dataType: 'json',
                        url: '../Handler/CommHandler.ashx' + param,
                        data: options,
                        success: function (data) {
                            if (data.status == 1) {
                                show_message('删除成功', 'success', function () {
                                    doSearch();
                                });
                                return;
                            }
                            if (data.status == 0) {
                                show_message("选中资源包含入库信息,禁止删除", "info", function () {
                                    doSearch();
                                });
                            }
                            if (data.status == 2) {
                                show_message("系统错误", "info", function () {
                                    doSearch();
                                });
                            }
                        }
                    });
                }
            })
        }
    </script>
    <style>
        .op a {
            margin: 10px 0px 0px 20px;
        }

        a.clickBtn {
            color: blue;
            background: #e2e2e2 repeat;
        }
    </style>
</head>
<body class="easyui-layout" data-options="fit:true">
    <div data-options="region:'west',split:true,title:'菜单',border:false" style="width: 260px; padding: 10px; border: none;">
        <div>
            <a href="#" class="easyui-linkbutton" onclick="addtree()" data-options="iconCls:'icon-add'">新增</a>
            <a href="#" class="easyui-linkbutton" onclick="edittree()" data-options="iconCls:'icon-edit'">修改</a>
            <a href="#" class="easyui-linkbutton" onclick="deleteree()" data-options="iconCls:'icon-remove'">删除</a>
        </div>

        <input id="searchbox" class="easyui-searchbox" data-options="prompt:'',searcher:doSearch" style="width: 150px" />
        <ul id="tt" class="ztree"></ul>
    </div>

    <div data-options="region:'center',border:false">
        <div class="easyui-layout" data-options="fit:true">
            <div data-options="region:'north',split:false,title:'',border:false" style="width: 100%; height: 60px; padding: 5px; border: none;">
                <div class="op">
                    <%if (base.CheckAuthByModuleCode("1191034"))
                      {%>
                    <a href="#" class="easyui-linkbutton opbtn" onclick="ViewInOrder()" data-options="iconCls:'icon-add'">入库台账</a>
                    <%} %>
                    <%if (base.CheckAuthByModuleCode("1191035"))
                      {%>
                    <a href="#" class="easyui-linkbutton opbtn" onclick="ViewOutOrder()" data-options="iconCls:'icon-add'">出库台账</a>
                    <%} %>
                    <%if (base.CheckAuthByModuleCode("1191036"))
                      {%>
                    <a href="#" class="easyui-linkbutton opbtn" onclick="ViewBusinessBalance()" data-options="iconCls:'icon-edit'">商家结算</a>
                    <%} %>
                    <%if (base.CheckAuthByModuleCode("1191037"))
                      {%>
                    <a href="#" class="easyui-linkbutton opbtn" onclick="ViewMoveBalance()" data-options="iconCls:'icon-edit'">搬运结算</a>
                    <%} %>
                    <%if (base.CheckAuthByModuleCode("1191038"))
                      {%>
                    <a href="#" class="easyui-linkbutton opbtn" onclick="ViewInventory()" data-options="iconCls:'icon-edit'">库存查询</a>
                    <%} %>
                    <%if (base.CheckAuthByModuleCode("1191039"))
                      {%>
                    <a href="#" class="easyui-linkbutton opbtn" onclick="ViewSummary()" data-options="iconCls:'icon-edit'">综合台帐</a>
                    <%} %>
                </div>
            </div>
            <div data-options="region:'center',split:false,title:'',border:false" style="width: 100%; border: none;">
                <iframe id="myFrame" src="" style="width: 100%; height: 89%; border: none;"></iframe>
            </div>
        </div>
    </div>
</body>
</html>
