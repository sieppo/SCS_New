<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="products.aspx.cs" MasterPageFile="~/sitemaster.Master" Inherits="WebClientApplication.products" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
     <div runat ="server" id ="listview">
   <div class="content-body">
    <div class="trim">
      <div class="breadcrumbs">
      </div>
      <h1 class="scs-red-pastel">Select Range</h1>
      <div class="results ranges">
        <table>
          <tbody>
            <tr>
              <td>
                <asp:DataList CssClass = "product-datalist" id="scslistproducts" RepeatColumns="3" RepeatDirection="Horizontal" runat="server">
                  <ItemTemplate>
                   <div class = "sr2">
                    <asp:LinkButton ID="scsproducts" CommandArgument = '<%# DataBinder.Eval(Container.DataItem,"Design_Ref") %>' CommandName = '<%# DataBinder.Eval(Container.DataItem,"Design_Name") %>' runat="server" OnCommand="results"><h3><%# DataBinder.Eval(Container.DataItem, "Design_Name")%></h3></asp:LinkButton>
                   </div>
                  </ItemTemplate>
                </asp:DataList>
              </td>
            </tr>
          </tbody>
        </table>
      </div>
    </div>
  </div>
 </div>

<div runat ="server" id ="blockview">
<div class="content-body">
    <div class="trim">
      <div class="breadcrumbs">
          <div><asp:LinkButton ID="LinkButton_MainBack" runat="server" OnCommand="MainGoBack"><h2>BACK BUTTON</h2></asp:LinkButton></div>
       <%-- <a href="#">Ranges</a> &rsaquo; Barrington 4m Range--%>
      </div>
      <h1 class="scs-red-pastel"><asp:Label ID="Label_results" runat="server" Text=""></asp:Label></h1>
        <asp:Label ID="Label_ourDesign" runat="server" Text=""></asp:Label>
        
      <div class="results products">
        <table>
          <tbody>
            <tr>
              <td>
              
                  <asp:DataList CssClass = "" id="scsblocklist" RepeatColumns="5" RepeatDirection="Horizontal" runat="server">
                   <ItemTemplate>
                    <div class="product">
                     <div class = "title"><%# DataBinder.Eval(Container.DataItem,"Product_Colour") %></div>
                       <asp:LinkButton ID="LinkButton_Block_Image" CommandName = '<%# DataBinder.Eval(Container.DataItem,"Product_4M_Status") + ", " + DataBinder.Eval(Container.DataItem,"Product_5M_Status") %>' CommandArgument = '<%# DataBinder.Eval(Container.DataItem,"Product_Id") %>' runat="server" OnCommand="Detail_Info">
                        <div class = "block_images"><img src = "images/thumbs/<%# DataBinder.Eval(Container.DataItem, "Product_Name").ToString().Trim() %>.jpg" /></div></asp:LinkButton>
                       <div class="stock-levels" runat="server">
                          <div class ='<%# GetName((string)DataBinder.Eval(Container.DataItem,"Product_4M_Status").ToString().Trim()) %>'>4M</div>
                           <div class ='<%# GetName((string)DataBinder.Eval(Container.DataItem,"Product_5M_Status").ToString().Trim()) %>'>5M</div>
                       </div>  
                      </div>
                   </ItemTemplate>
                 </asp:DataList>
              
              </td>
            </tr>
          </tbody>
        </table>
      </div>
    </div>
  </div>
 </div>
 <div runat ="server" id ="detailview">
      <div class="content-body">
    <div class="trim">
      <div class="breadcrumbs">
          <div><asp:LinkButton ID="LinkButton_Back" runat="server" OnCommand="GoBack"><h2>BACK BUTTON</h2></asp:LinkButton></div>
  <%--      <a href="#">Ranges</a> &rsaquo; <a href="#">Barrington 4m Range</a> &rsaquo; Barrington Herati Black--%>
      </div>
      <h1 class="scs-red-pastel"><asp:Label ID="Label_Name" runat="server" Text=""></asp:Label></h1>
      <div class="product-full">
        <div class="product-image left">
          <asp:image runat="server" ID="bigimage"  />
         </div>
        <div class="product-information left">
             <div class="stock-levels clear">
            <label class="clear">Stock Level</label>

   <div style = "display:none"></div>
     <div>
       <asp:LinkButton ID="LinkButton_4M" runat="server" CommandArgument = ""  OnCommand="change4m"><div id ="M4Meter" runat="server"></div></asp:LinkButton>
       
      </div>
         <div>
             <asp:LinkButton ID="LinkButton_5M" runat="server" CommandArgument = ""  OnCommand="change5m"><div id ="M5Meter" runat="server"></div></asp:LinkButton>
                
           </div>
          </div>
          <div class="product-stockcode">
            <label>Available Pieces</label>
            <div><asp:Label ID="Label_Code" runat="server" Text=""></asp:Label>
<div id="fourm" runat="server">
     
        <table>
          <tbody>
            <tr>
           <td><td>
               <td><label>Piece No</label></td><td>&nbsp-&nbsp</td>
               <td><label>Width</label></td><td>&nbsp-&nbsp</td><td><label>Size</label></td><td>&nbsp-&nbsp</td><td><label>DyeNo</label></td><td>&nbsp-&nbsp</td><td><label>Roll ID</label></td>
                  </td>
                  <asp:DataList CssClass = "" id="DataList4M" RepeatColumns="1" RepeatDirection="Horizontal" runat="server">
                   <ItemTemplate>
                       
                    <div>
                      <td><%# DataBinder.Eval(Container.DataItem,"sp_pieceno") %></td><td>&nbsp-&nbsp</td>
                       <td><%# DataBinder.Eval(Container.DataItem,"sp_width") %></td><td>&nbsp-&nbsp</td>
                        <td><%# DataBinder.Eval(Container.DataItem,"sp_remain") %></td><td>&nbsp-&nbsp</td>
                       <td><%# DataBinder.Eval(Container.DataItem,"sp_dyeno") %></td><td>&nbsp-&nbsp</td>
                       <td><%# DataBinder.Eval(Container.DataItem,"sp_manrollid") %></td>
                      </div>
                   </ItemTemplate>
                 </asp:DataList>
                </td>
              </tr>
          </tbody>
        </table>
       </div>
            </div><div>&nbsp</div>
               <div><asp:Label ID="Label_Code2" runat="server" Text=""></asp:Label>
<div id="fivem" runat="server">
                    <table>
                      <tbody>
                         <tr>
           <td><td>
               <td><label>Piece No</label></td><td>&nbsp-&nbsp</td>
               <td><label>Width</label></td><td>&nbsp-&nbsp</td><td><label>Size</label></td><td>&nbsp-&nbsp</td><td><label>DyeNo</label></td><td>&nbsp-&nbsp</td><td><label>Roll ID</label></td>
                  </td>
                              <asp:DataList CssClass = "" id="DataList5M" RepeatColumns="1" RepeatDirection="Horizontal" runat="server">
                               <ItemTemplate>
                                   
                                <div>
                                    <td><%# DataBinder.Eval(Container.DataItem,"sp_pieceno") %></td><td>&nbsp-&nbsp</td>
                                    <td><%# DataBinder.Eval(Container.DataItem,"sp_width") %></td><td>&nbsp-&nbsp</td>
                                    <td><%# DataBinder.Eval(Container.DataItem,"sp_remain") %></td><td>&nbsp-&nbsp</td>
                                    <td><%# DataBinder.Eval(Container.DataItem,"sp_dyeno") %></td><td>&nbsp-&nbsp</td>
                                    <td><%# DataBinder.Eval(Container.DataItem,"sp_manrollid") %></td>
                                  </div>
                               </ItemTemplate>
                             </asp:DataList>
                          </td>
                        </tr>
                      </tbody>
                    </table>
                </div>
               </div>
          </div>
         
          <div class="product-construction clear">
            <div class="material-container left">
              <label>Material</label>
              <div class="material scs-red-pastel">
                <asp:Label ID="Label_Material" runat="server" Text=""></asp:Label>
              </div>
            </div>
            <div class="construction-container left">
              <label>Construction</label>
              <div class="construction scs-red-pastel">
                <asp:Label ID="Label_Construction" runat="server" Text=""></asp:Label>
              </div>
            </div>
          </div>
          <div class="product-summary">
            <asp:Label ID="Label_Summary" runat="server" Text=""></asp:Label>
          </div>
            
        </div>
      </div>

  </div>
</div>

 </div>

 </asp:Content>
