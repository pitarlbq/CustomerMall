<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="ProductMgr.aspx.cs" Inherits="Web.Mall.ProductMgr" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        var status, type;
        $(function () {
            status = "<%=this.status%>";
            type = "<%=this.type%>";
        })
    </script>
    <script src="../js/Page/Mall/Product/ProductMgr.js?v=<%=base.getToken() %>"></script>
    <style>
        .datagrid-td-rownumber {
            height: 50px;
        }

        .input_checkbox {
            margin-left: 20px;
        }

            .input_checkbox label {
                margin-right: 10px;
                height: 25px;
                line-height: 25px;
                position: relative;
                padding-right: 20px;
            }

            .input_checkbox input {
                width: 15px;
                height: 15px;
                position: absolute;
                top: 50%;
                right: 0;
                margin-top: -7px;
            }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <div class="easyui-layout" data-options="fit:true,border:false">
        <div data-options="region:'north',border:false" style="height: 50px; font-size: 12px; padding: 5px 10px;">
            <label>
                关键字: 
                <input class="easyui-searchbox" style="width: 200px;" id="tdKeyword" type="text" data-options="prompt:'商品名称',searcher:SearchTT" />
            </label>
            <label>
                排序:  
                <select class="easyui-combobox" id="tdSortOrder" style="width: 100px;">
                    <option value="1">创建时间</option>
                    <option value="2">库存</option>
                    <option value="3">销量</option>
                    <option value="4">排序序号</option>
                </select>
            </label>
            <label>
                是否自营:  
                <select class="easyui-combobox" id="tdIsZiYing" style="width: 100px;">
                    <option value="">全部</option>
                    <option value="1">是</option>
                    <option value="2">否</option>
                </select>
            </label>
            <label class="input_checkbox">
                商品类型: 
                <label>普通商品<input type="checkbox" id="tdIsAllowProductBuy" /></label>
                <label>积分商品<input type="checkbox" id="tdIsAllowPointBuy" /></label>
                <label>合伙人商品<input type="checkbox" id="tdIsAllowVIPBuy" /></label>
            </label>
            <label class="searchlabel">
                <a href="javascript:void(0)" onclick="SearchTT()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-search'">搜索</a>
            </label>
        </div>
        <div data-options="region:'center',border:false">
            <table id="tt_table"></table>
            <div id="tt_mm">
                <%if (this.CanView == 1)
                  { %>
                <a href="javascript:void(0)" onclick="do_view()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-detail'">详情</a>
                <%} %>
                <%if (this.status != 3 && this.status != 4)
                  {%>
                <%if (this.status != 2)
                  {%>
                <%if (this.CanAdd == 1)
                  { %>
                <a href="javascript:void(0)" onclick="do_add()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-add'">新增</a>
                <%} %>
                <%} %>
                <%if (this.CanEdit == 1)
                  { %>
                <a href="javascript:void(0)" onclick="do_edit()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-edit'">修改</a>
                <%} %>
                <%if (this.CanRemove == 1)
                  { %>
                <a href="javascript:void(0)" onclick="do_remove()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-remove'">删除</a>
                <%} %>
                <%if (this.status != 2)
                  {%>
                <%if (this.CanChangeCategory == 1)
                  { %>
                <a href="javascript:void(0)" onclick="do_change_category()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-edit'">批量分类</a>
                <%} %>
                <%if (this.CanChangePrice == 1)
                  { %>
                <a href="javascript:void(0)" onclick="do_change_price()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-edit'">批量改价</a>
                <%} %>
                <%if (this.CanOffLine == 1)
                  { %>
                <a href="javascript:void(0)" onclick="do_offline()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-edit'">批量下架</a>
                <%} %>
                <%if (this.CanChangeTag == 1)
                  { %>
                <a href="javascript:void(0)" onclick="do_change_tag()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-edit'">批量标签</a>
                <%} %>
                <%} %>
                <%} %>
                <%if (this.status == 3 || this.status == 4 || this.status == 0)
                  {%>
                <%if (this.CanApprove == 1)
                  { %>
                <a href="javascript:void(0)" onclick="do_approve()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-shenhe'">审核</a>
                <%} %>
                <%} %>
                <%if (this.type == 3 && this.status != 3 && this.status != 4)
                  {%>
                <%if (this.CanViewPinQiang == 1)
                  { %>
                <a href="javascript:void(0)" onclick="do_view_pintuan()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-detail'">查看拼团</a>
                <%} %>
                <%} %>
                <%if (this.status != 2)
                  {%>
                <%if (this.CanSortYouXuan == 1)
                  { %>
                <a href="javascript:void(0)" onclick="do_change_youxuan_sort()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-edit'">福顺优选排序</a>
                <%} %>
                <%if (this.CanSortPinQiang == 1)
                  { %>
                <a href="javascript:void(0)" onclick="do_change_pintuan_sort()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-edit'">拼团抢购排序</a>
                <%} %>
                <%} %>
            </div>
        </div>
    </div>
</asp:Content>
