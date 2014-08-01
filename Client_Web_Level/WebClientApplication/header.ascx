<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="header.ascx.cs" Inherits="WebClientApplication.header" %>
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
                <div class="search relative">
                    <input type="text" class="shadow" placeholder="Search">
                    <button type="submit" class="search-submit">
                        <i class="fa fa-search"></i>
                    </button>
                </div>
                <div><asp:Label ID="Label_Store" runat="server" Text=""></asp:Label></div>
            </div>
        </div>
    </div>
</header>