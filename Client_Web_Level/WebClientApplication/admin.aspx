<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="admin.aspx.cs" MasterPageFile="~/admin.Master" Inherits="AdminSite.admin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  <div class="content-body">
    <div class="trim padding-general">

      <!-- main menu -->
      <div runat="server" id="menu" class="container rounded">
        <div id="button_edit_stock">
          <asp:LinkButton  ID="Button_Menu_Design" runat="server" Text="Edit Design" OnCommand="Menu_Design_Command" CssClass="button">Edit Design</asp:LinkButton>
        </div>
      </div>

      <!-- design add and list -->
      <div runat="server" id ="design_addandlist" class="container rounded">
        <h2>Add Design</h2>
        <asp:LinkButton ID="Back_Design_Add" CommandName="Back_Design_Add" CommandArgument="" runat="server" OnCommand="Back_Run" CssClass="button">Back</asp:LinkButton>
        <div id="designadd">
        <asp:Label ID="Label_Info" runat="server" Text=""></asp:Label>
          <asp:TextBox ID="TextBox_New_Design_Ref" runat="server"></asp:TextBox>
             <asp:TextBox ID="TextBox_New_Design_Name" runat="server"></asp:TextBox>
          <asp:LinkButton  ID="LinkButton_Add_Design" runat="server" Text="Add Design" OnCommand="Add_New_Design" CssClass="button">Add Design</asp:LinkButton>
        </div>
        <div id="designlist">
          <asp:DataList ID="design_list" runat="server" RepeatColumns="1" RepeatDirection="Horizontal">
            <ItemTemplate>
              <%# DataBinder.Eval(Container.DataItem, "Design_Id")%>
              <%# DataBinder.Eval(Container.DataItem, "Design_Ref")%>
              <%# DataBinder.Eval(Container.DataItem, "Design_Name")%>
              <asp:LinkButton ID="LinkButton_Design_Edit" CommandName = '<%# DataBinder.Eval(Container.DataItem, "Design_Id")%>' CommandArgument = '<%# DataBinder.Eval(Container.DataItem,"Design_Name") %>'  runat="server" OnCommand="Edit_Design">Edit Design</asp:LinkButton>
            </ItemTemplate>
          </asp:DataList>
        </div>
      </div>

      <!-- design edit and add stock with list -->
      <div id="design_edit" runat="server" class="container rounded">
        <asp:LinkButton ID="Back_Dessign_Edit" CommandName="Back_Dessign_Edit" CommandArgument="" runat="server" CssClass="button" OnCommand="Back_Run">Back</asp:LinkButton>
      
      <div class="container rounded">
        <h2>Edit Design</h2>
        <div class="edit-design">
            <asp:Label ID="Label_DesignName" runat="server"></asp:Label>
          <p><asp:Label ID="Label_design_error" runat="server" Text=""></asp:Label></p>  
          <asp:TextBox ID="TextBox_Edit_Design_Name" runat="server"></asp:TextBox>
          <asp:LinkButton ID="LinkButton_Design_Update" CommandName= "" runat="server" OnCommand="Design_Update" CssClass="button">Update</asp:LinkButton>
        </div>
      </div>
     </div>
      <!-- Stock Add + List -->
      <div id="addnewstock" runat ="server" class="container rounded">
      <h2>Add New Stock</h2>
          <p>
              <asp:Label ID="Label_AddstockStatus" runat="server"></asp:Label>
          </p>
        <asp:TextBox ID="TextBox_New_Stock" runat="server"></asp:TextBox>
        <asp:LinkButton  ID="LinkButton_Add_Stock" runat="server" Text="Add Stock" CommandName ="" CommandArgument ="" OnCommand="Add_New_Stock" CssClass="button">Add</asp:LinkButton>
      
      <div class="container rounded">
        <h2>
            <asp:Label ID="Label_stockstatus" runat="server"></asp:Label>
            Stock List</h2>
        <div id="stocklist">
          <asp:DataList ID="stock_list" runat="server" RepeatColumns="1" RepeatDirection="Horizontal">
            <ItemTemplate>
              <%# DataBinder.Eval(Container.DataItem, "Product_Id")%>
              <%# DataBinder.Eval(Container.DataItem, "Product_Name")%>
              <%# DataBinder.Eval(Container.DataItem, "Product_Colour")%>
              <asp:LinkButton ID="LinkButton_Stock_Edit" CommandName = '<%# DataBinder.Eval(Container.DataItem,"Product_Id") %>' runat="server" OnCommand="Edit_Stock">Edit Stock</asp:LinkButton>
            </ItemTemplate>
          </asp:DataList>
        </div>
      </div>
    </div>
      <!-- Edit Stock -->
      <div id="edit_stock" runat="server" class="container rounded">
        <h2>Edit Stock</h2>
        <asp:LinkButton ID="Back_Stock_Edit" CommandName="Back_Stock_Edit" CommandArgument="" runat="server" OnCommand="Back_Run" CssClass="button">Back</asp:LinkButton>
          <asp:Label ID="Label_updateproduct" runat="server"></asp:Label>
        <asp:Label ID="Label_Design_Name" runat="server" Text=""></asp:Label>
        <asp:Label ID="Label_Product_ID" runat="server" Text=""></asp:Label>
        <asp:TextBox ID="TextBox_Product_Edit_Name" runat="server"></asp:TextBox><asp:CheckBox ID="CheckBox_edit_Name" runat="server" OnCheckedChanged="CheckBox_edit_Name_CheckedChanged" AutoPostBack="True" />
        <asp:TextBox ID="TextBox_Product_Edit_Colour" runat="server"></asp:TextBox>
        <asp:TextBox ID="TextBox_Product_Description" runat="server"></asp:TextBox>
        <asp:TextBox ID="TextBox_Product_Edit_4M_Ref" runat="server"></asp:TextBox>
        <asp:TextBox ID="TextBox_Product_Edit_5M_Ref" runat="server"></asp:TextBox>
        <asp:TextBox ID="TextBox_Product_Edit_Width_Descrip" runat="server"></asp:TextBox>
        <asp:TextBox ID="TextBox_Product_Edit_Construction" runat="server"></asp:TextBox>
        <asp:TextBox ID="TextBox_Product_Edit_Material" runat="server"></asp:TextBox>
        <asp:CheckBox ID="CheckBox_Show_Product" runat="server" />
        <asp:LinkButton ID="Product_Save_Update" CommandName="" CommandArgument="" runat="server" OnCommand="Save_Update_Stock" CssClass="button">Update</asp:LinkButton>
       <asp:LinkButton ID="Button_Remove_Image" runat="server" OnCommand="Remove_Image" CommandName ="" CommandArgument =""  Text="Remove Image" CssClass="button">Remove Image</asp:LinkButton>
         <asp:FileUpload ID="fileupload1" runat="server" />
        <asp:LinkButton ID="Button_Save_Image" runat="server" OnCommand="Save_Image" CommandName ="" CommandArgument ="" Text="Upload Image" CssClass="button">Upload Image</asp:LinkButton>
        <asp:LinkButton ID="Product_Delete" CommandName="" CommandArgument="" runat="server" OnCommand="Product_Delete_Command" CssClass="button red">Delete</asp:LinkButton>
          <asp:Image ID="Product_Image" runat="server" />
      </div>
    </div>
  </div>
 </asp:Content>