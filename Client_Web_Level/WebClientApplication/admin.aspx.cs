using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Web.Security;
using SCS_Requests;
using System.Threading.Tasks;
using Data_Functions;
using System.Data;
using System.IO;

namespace AdminSite
{
    public partial class admin : System.Web.UI.Page
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {
            

            if (!Page.IsPostBack)
            {
                if (!this.Page.User.Identity.IsAuthenticated)
                {
                    FormsAuthentication.RedirectToLoginPage();
                 
                }
                else
                {
                    design_addandlist.Visible = false;
                    design_edit.Visible = false;
                    addnewstock.Visible = false;
                    edit_stock.Visible = false;
                }
            }
        }
        //}
        //private void testingw()
        //{
        //      Requests newrequesr = new Requests();

        //    newrequesr.requestforstocklive();
        //}
        private void image_upload(string imagename)
        {
            fileupload1.SaveAs(Server.MapPath("images/tempImage/" + fileupload1.FileName));
            System.Drawing.Image image = System.Drawing.Image.FromFile(Server.MapPath("images/tempImage/" + fileupload1.FileName));
            int newwidthimg = 130;
            int newHeight = 100;
           
            float AspectRatio = (float)image.Size.Width / (float)image.Size.Height;
            Bitmap bitMAP1 = new Bitmap(newwidthimg, newHeight);
            Graphics imgGraph = Graphics.FromImage(bitMAP1);
            imgGraph.CompositingQuality = CompositingQuality.HighQuality;
            imgGraph.SmoothingMode = SmoothingMode.HighQuality;
            imgGraph.InterpolationMode = InterpolationMode.HighQualityBicubic;
            var imgDimesions = new Rectangle(0, 0, newwidthimg, newHeight);
            imgGraph.DrawImage(image, imgDimesions);
            bitMAP1.Save(Server.MapPath("images/thumbs/" + imagename + ".jpg"), ImageFormat.Jpeg);

            int newwidthimg2 = 800;
            int newHeight2 = 600;
            Bitmap bitMAP2 = new Bitmap(newwidthimg2, newHeight2);
            Graphics imgGraph2 = Graphics.FromImage(bitMAP2);
            imgGraph2.CompositingQuality = CompositingQuality.HighQuality;
            imgGraph2.SmoothingMode = SmoothingMode.HighQuality;
            imgGraph2.InterpolationMode = InterpolationMode.HighQualityBicubic;
            var imgDimesions2 = new Rectangle(0, 0, newwidthimg2, newHeight2);
            imgGraph2.DrawImage(image, imgDimesions2);
            bitMAP2.Save(Server.MapPath("images/fullImage/" + imagename + ".jpg"), ImageFormat.Jpeg);
           
            imgGraph.Dispose();
            bitMAP1.Dispose();
            image.Dispose();
            imgGraph2.Dispose();
            bitMAP2.Dispose();
           

            if (File.Exists(Server.MapPath("images/tempImage/" + fileupload1.FileName)))
            {
                File.Delete(Server.MapPath("images/tempImage/" + fileupload1.FileName));
            }

        }

        protected void Save_Image(object sender, CommandEventArgs e)
        {
            if (fileupload1.HasFile == true)
            {
                image_upload(e.CommandName.ToString().Trim());
                editthestock(Convert.ToInt32(e.CommandArgument.ToString().Trim()));
            }
           
        }

        protected void Menu_Design_Command(object sender, CommandEventArgs e)
        {
            design_addandlist.Visible = true;
            design_edit.Visible = false;
            addnewstock.Visible = false;
            edit_stock.Visible = false;
            Label_Info.Text = "";
            listdata();

        }
        protected void listdata()
        {
           
            DataTransferFunction getlist = new DataTransferFunction();
            DataView dv = new DataView(getlist.getmeprolist());
            this.design_list.DataSource = dv;
            this.design_list.DataBind();

        }
        protected void Edit_Design(object sender, CommandEventArgs e)
        {
            design_addandlist.Visible = false;
            design_edit.Visible = true;
            addnewstock.Visible = true;
            edit_stock.Visible = false;
            LinkButton_Add_Stock.CommandArgument = e.CommandArgument.ToString();
            LinkButton_Add_Stock.CommandName = e.CommandName.ToString();
            listproductdata(e.CommandName.ToString());
             

        }

        protected void listproductdata(string designid)
        {

            DataTransferFunction getlist = new DataTransferFunction();
            DataTable designinfo = getlist.getdesignbyid(Convert.ToInt32(designid));
            Label_DesignName.Text = designinfo.Rows[0].ItemArray[1].ToString().Trim();
            LinkButton_Design_Update.CommandName = designid;
            TextBox_Edit_Design_Name.Text = designinfo.Rows[0].ItemArray[2].ToString().Trim();
            DataView dv = new DataView(getlist.getmeblocklist2(Convert.ToInt32(designid)));
            this.stock_list.Visible = false;
            Label_stockstatus.Text = "";
            if (dv.Count > 0)
            {
                this.stock_list.Visible = true;
                this.stock_list.DataSource = dv;
                this.stock_list.DataBind();

            }
            else
            {
                Label_stockstatus.Text = "No Stock Relating to this Design";
            }

        }

        protected void Design_Update(object sender, CommandEventArgs e)
        {
            Label_design_error.Text = "";
            //update the design name
            if (TextBox_Edit_Design_Name.Text.Trim() != "")
            {
                DataTransferFunction getlist = new DataTransferFunction();
                int answ = getlist.updatedesignname(TextBox_Edit_Design_Name.Text.Trim(), Convert.ToInt32(e.CommandName.ToString()));
                if (answ != 0)
                {
                    Label_design_error.Text = "Design Name Updated";
                }
                else
                {
                    Label_design_error.Text = "Design Name Did Not Update Please try again Later";
                }
            }
            else
            {
                // indicate there is nothing in the textbox
                Label_design_error.Text = "Please enter correct information";
            }
        }

        protected void Add_New_Stock(object sender, CommandEventArgs e)
        {
            if (TextBox_New_Stock.Text != "")
            {
                DataTransferFunction getlist = new DataTransferFunction();
                //is the stock refference available
                if (getlist.isthereanyproduct(TextBox_New_Stock.Text.Trim(), Convert.ToInt32(e.CommandName.ToString().Trim())) != true)
                {
                    Products statuses = new Products()
                    {
                        Product_Name = TextBox_New_Stock.Text.Trim(),
                        Product_Design_Name = e.CommandArgument.ToString().Trim(),
                        Prodcut_Design_ID = Convert.ToInt32(e.CommandName.ToString().Trim()),
                        Product_Show = 0,
                    };

                 bool answ = getlist.insertnewproduct(statuses);
                 if (answ == true)
                 {
                     Label_AddstockStatus.Text = "Product Name Added";
                     TextBox_New_Stock.Text = "";
                     listproductdata(e.CommandName.ToString().Trim());
                 }
                 else
                 {
                     Label_AddstockStatus.Text = "Product Name Not Added";
                 }

                }
                else
                {
                    Label_AddstockStatus.Text = "Product Name already Exists";
                }
            }
            else
            {
                Label_AddstockStatus.Text = "Please enter Correct Information";
            }


        }

        protected void Add_New_Design(object sender, CommandEventArgs e)
        {
            DataTransferFunction getlist = new DataTransferFunction();
            
            if (TextBox_New_Design_Ref.Text.Trim() != "" && TextBox_New_Design_Name.Text.Trim() != "")
            {
               //add new design name ---- or code?????????
                if (getlist.isthereany(TextBox_New_Design_Ref.Text.Trim()) == true)
                {
                    //insert new records
                    Label_Info.Text = "The Refernece code already exists";
                }
                else
                {
                    
                    getlist.insertnewdesign(TextBox_New_Design_Ref.Text.Trim(), TextBox_New_Design_Name.Text.Trim());
                    Label_Info.Text = "Details Added";
                    TextBox_New_Design_Ref.Text = "";
                    TextBox_New_Design_Name.Text = "";
                    listdata();
                }
               
            }
            else
            {
                Label_Info.Text = "Please enter the correct information";
                //add lable to indicate to add some text
            }

        }

        protected void Edit_Stock(object sender, CommandEventArgs e)
        {
            editthestock(Convert.ToInt32(e.CommandName.ToString()));
        }
        private void editthestock(int product_id)
        {
            design_addandlist.Visible = false;
            design_edit.Visible = false;
            addnewstock.Visible = false;
            edit_stock.Visible = true;
            TextBox_Product_Edit_Name.Enabled = false;
            //pull back all details from system
            DataTransferFunction getlist = new DataTransferFunction();
            DataTable prod = getlist.getmeblockdetail(product_id);
            Product_Save_Update.CommandName = prod.Rows[0].ItemArray[0].ToString();
            Product_Save_Update.CommandArgument = prod.Rows[0].ItemArray[11].ToString();
            Product_Image.ImageUrl = "/images/thumbs/" + prod.Rows[0].ItemArray[2].ToString() + ".jpg";
            Button_Save_Image.CommandName = prod.Rows[0].ItemArray[2].ToString().Trim();
            Button_Save_Image.CommandArgument = prod.Rows[0].ItemArray[0].ToString().Trim();
            Label_Design_Name.Text = prod.Rows[0].ItemArray[1].ToString();
            Label_Product_ID.Text = prod.Rows[0].ItemArray[0].ToString();
            TextBox_Product_Edit_Name.Text = prod.Rows[0].ItemArray[2].ToString();
            TextBox_Product_Edit_Colour.Text = prod.Rows[0].ItemArray[3].ToString();
            TextBox_Product_Description.Text = prod.Rows[0].ItemArray[4].ToString();
            TextBox_Product_Edit_4M_Ref.Text = prod.Rows[0].ItemArray[6].ToString();
            TextBox_Product_Edit_5M_Ref.Text = prod.Rows[0].ItemArray[7].ToString();
            TextBox_Product_Edit_Width_Descrip.Text = prod.Rows[0].ItemArray[5].ToString();
            TextBox_Product_Edit_Construction.Text = prod.Rows[0].ItemArray[8].ToString();
            TextBox_Product_Edit_Material.Text = prod.Rows[0].ItemArray[12].ToString();
            Product_Delete.CommandName = prod.Rows[0].ItemArray[0].ToString();
            Product_Delete.CommandArgument = prod.Rows[0].ItemArray[2].ToString();
            if (prod.Rows[0].ItemArray[13].ToString() == "1") { CheckBox_Show_Product.Checked = true; }
            else { CheckBox_Show_Product.Checked = false; }
            CheckBox_edit_Name.Checked = false;
            if (File.Exists(Server.MapPath("~/images/thumbs/" + prod.Rows[0].ItemArray[2].ToString() + ".jpg")))
            {
                //hide browse and show delete image
                fileupload1.Visible = false;
                Button_Save_Image.Visible = false;
                Product_Image.Visible = true;
                Button_Remove_Image.Visible = true;
                Button_Remove_Image.CommandName = prod.Rows[0].ItemArray[2].ToString();
                Button_Remove_Image.CommandArgument = prod.Rows[0].ItemArray[0].ToString();
            }
            else
            {

                //show upload and hide the image
                fileupload1.Visible = true;
                Button_Save_Image.Visible = true;
                Product_Image.Visible = false;
                Button_Remove_Image.Visible = false;
            }
        }

        protected void Back_Run(object sender, CommandEventArgs e)
        {
            design_addandlist.Visible = false;
            design_edit.Visible = false;
            addnewstock.Visible = false;
            edit_stock.Visible = false;
        }

        protected void Save_Update_Stock(object sender, CommandEventArgs e)
        {
            bool switched = false;
            DataTransferFunction getlist = new DataTransferFunction();
            int checkedme = 0;
            if (CheckBox_Show_Product.Checked == true) { checkedme = 1; }
            if (CheckBox_edit_Name.Checked == true)
            {
                if (getlist.isthereanyproduct(TextBox_Product_Edit_Name.Text.Trim(), Convert.ToInt32(e.CommandArgument.ToString().Trim())) == true)
                {
                    Label_updateproduct.Text = "The Product Name already exists";
                    switched = false;
                }else{switched = true;}
  
            }
            else{switched = true;}
            if (switched == true)
            {
                Products statuses = new Products()
                    {
                        Product_Name = TextBox_Product_Edit_Name.Text.Trim(),
                        Product_Id = Convert.ToInt32(e.CommandName.ToString().Trim()),
                        Product_Show = checkedme,
                        Product_Colour = TextBox_Product_Edit_Colour.Text.Trim(),
                        Product_Desciption = TextBox_Product_Description.Text.Trim(),
                        Product_Width_Desciption = TextBox_Product_Edit_Width_Descrip.Text.Trim(),
                        Product_4M_Ref = TextBox_Product_Edit_4M_Ref.Text.Trim(),
                        Product_5M_Ref = TextBox_Product_Edit_5M_Ref.Text.Trim(),
                        Product_Construction = TextBox_Product_Edit_Construction.Text.Trim(),
                        Product_Material = TextBox_Product_Edit_Material.Text.Trim()
                    };

              bool answerus = getlist.updateproducts(statuses);

              if (answerus == true) { Label_updateproduct.Text = "The Product Updated"; editthestock(Convert.ToInt32(e.CommandName.ToString().Trim()));}


            }



        }

        protected void CheckBox_edit_Name_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBox_edit_Name.Checked == true) { TextBox_Product_Edit_Name.Enabled = true; }
            else { TextBox_Product_Edit_Name.Enabled = false; }
        }

        protected void Remove_Image(object sender, CommandEventArgs e)
        {
            deletetheimages(e.CommandName.ToString().Trim(), Convert.ToInt32(e.CommandArgument.ToString().Trim()), 1);
        }

        private void deletetheimages(string imagename, int productid, int switching)
        {
            if (File.Exists(Server.MapPath("images/fullImage/" + imagename + ".jpg")))
            {
                File.Delete(Server.MapPath("images/fullImage/" + imagename + ".jpg"));
            }
            if (File.Exists(Server.MapPath("images/thumbs/" + imagename + ".jpg")))
            {
                File.Delete(Server.MapPath("images/thumbs/" + imagename + ".jpg"));
            }
            if (switching == 1) { editthestock(productid); } else 
            {
                design_addandlist.Visible = false;
                design_edit.Visible = true;
                addnewstock.Visible = true;
                edit_stock.Visible = false;
                listproductdata(Product_Save_Update.CommandArgument.ToString()); 
            }
           
        }

        protected void Product_Delete_Command(object sender, CommandEventArgs e)
        {
            
            DataTransferFunction getlist = new DataTransferFunction();
            bool isdeleted = getlist.deleteproduct(Convert.ToInt32(e.CommandName.ToString()));
            if (isdeleted == true) { deletetheimages(e.CommandArgument.ToString(), 0, 0); }
            else { Label_updateproduct.Text = "The Product did NOT Delete"; }
        }
    }
}