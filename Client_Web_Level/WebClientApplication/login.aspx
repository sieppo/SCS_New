<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" MasterPageFile="~/sitemaster.Master" Inherits="WebClientApplication.login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="center container rounded shadow login relative object-to-animate">
        <h2 class="scs-red-pastel">Store Login</h2>
        <asp:Login ID="Login1" runat="server" TitleText="" CssClass="shadow" OnAuthenticate="Login1_Authenticate" BorderPadding="0">
        </asp:Login>
    </div>
</asp:Content>