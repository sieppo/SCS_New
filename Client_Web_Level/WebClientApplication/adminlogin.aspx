<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="adminlogin.aspx.cs" MasterPageFile="~/sitemaster.Master" Inherits="WebClientApplication.login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="center container rounded shadow login relative object-to-animate">
        <h2 class="scs-red-pastel">Admin Login</h2>
        <asp:Login ID="Loginadmin" runat="server" TitleText="" CssClass="shadow" OnAuthenticate="Loginadmin_Authenticate" BorderPadding="0">
        </asp:Login>
    </div>
</asp:Content>