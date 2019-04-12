<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="CorrectRoomFee.aspx.cs" Inherits="Web.test.CorrectRoomFee" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <form runat="server">
        <div>
            重新收费
        </div>
        <div>
            <asp:Button runat="server" ID="btnSubmit" Text="提交" OnClick="btnSubmit_Click" />
        </div>
    </form>
</asp:Content>
