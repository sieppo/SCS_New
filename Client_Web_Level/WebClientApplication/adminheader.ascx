<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="adminheader.ascx.cs" Inherits="WebClientApplication.adminheader" %>
<header class="relative">
  <div class="trim">
    <div class="logo left"></div>
    <div runat="server" id="theDiv">
      <div class="header-right right relative">
        <asp:LinkButton ID="LinkButton_Out" runat="server" CommandArgument = ""  OnCommand="Logout">
          <div class="logout">
            Logout <i class="fa fa-sign-out"></i>
          </div>
        </asp:LinkButton>

      </div>
    </div>
  </div>
</header>