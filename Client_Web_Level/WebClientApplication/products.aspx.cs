using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using Data_Functions;
using System.Data;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Web.UI.HtmlControls;
using SCS_Requests;


namespace WebClientApplication
{
    public partial class products : System.Web.UI.Page
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
                    listdata();
                }
            }
        }

        protected void listdata()
        {
            Label_results.Text = ""; Label_ourDesign.Text = "";
            listview.Visible = true;
            blockview.Visible = false;
            detailview.Visible = false;
            DataTransferFunction getlist = new DataTransferFunction();
            DataView dv = new DataView(getlist.getmeprolist());
            this.scslistproducts.DataSource = dv;
            this.scslistproducts.DataBind();

        }
        protected void change4m(object sender, CommandEventArgs e)
        {
            if (fourm.Visible != true)
            {
                fourm.Visible = true;
            }
            else
            {
                fourm.Visible = false;
            }
        }
        protected void change5m(object sender, CommandEventArgs e)
        {
            if (fivem.Visible != true)
            {
                fivem.Visible = true;
            }
            else
            {
                fivem.Visible = false;
            }
        }
        protected void MainGoBack(object sender, CommandEventArgs e)
        {
            listdata();
        }
        protected void GoBack(object sender, CommandEventArgs e)
        {
             resulting(Label_results.Text, Label_ourDesign.Text);
        }
        private void resulting(string ref101, string ref102)
        {
            fourm.Visible = false;
            fivem.Visible = false;
            Requests requestings = new Requests();
            DataTable newss = null;
            DataTable longin = null;
            listview.Visible = false;
            detailview.Visible = false;
            blockview.Visible = true;
            Label_results.Text = ref101;
            Label_ourDesign.Text = ref102;
            DataTransferFunction getlist = new DataTransferFunction();
            //get info from realitex through service
            newss = getlist.getmeblocklist(ref102);
            longin = requestings.requestforstocklive(ref102);
            // 0 = not available 1 = no stock 2= medium stock 3 = plenty stock
            DataTable dt = new DataTable();
            dt.Clear();
            dt.Columns.Add("Product_Id");
            dt.Columns.Add("Product_Colour");
            dt.Columns.Add("Product_Name");
            dt.Columns.Add("Product_4M_Status");
            dt.Columns.Add("Product_5M_Status");

            foreach (DataRow drow in newss.Rows)
            {
                DataRow _ravi = dt.NewRow();
                string totals4m = "";
                string totals5m = "";

                if (longin != null)
                {
                    if (drow["Product_4M_Ref"].ToString().Trim() != "")
                    {
                        //fourm.Visible = true;
                        DataRow[] nnnn = null;
                        nnnn = longin.Select("sp_stockref = '" + drow["Product_4M_Ref"].ToString().Trim() + "'");
                        if (nnnn.Count() > 0)
                        {
                            // totals4m = nnnn[0].ItemArray.GetValue(1).ToString();
                            totals4m = "1";
                            if (Convert.ToInt32(Math.Round(Convert.ToDouble(nnnn[0].ItemArray.GetValue(1).ToString()))) >= 30) { totals4m = "2"; }
                            if (Convert.ToInt32(Math.Round(Convert.ToDouble(nnnn[0].ItemArray.GetValue(1).ToString()))) >= 60) { totals4m = "3"; }
                        }
                        else
                        {
                            totals4m = "1";
                        }
                    }
                    else
                    {
                        fourm.Visible = false;
                        totals4m = "";
                    }

                    if (drow["Product_5M_Ref"].ToString().Trim() != "")
                    {
                        //fivem.Visible = true;
                        DataRow[] nnnn1 = null;
                        nnnn1 = longin.Select("sp_stockref = '" + drow["Product_5M_Ref"].ToString().Trim() + "'");
                        if (nnnn1.Count() > 0)
                        {
                            //totals5m = nnnn1[0].ItemArray.GetValue(1).ToString();
                            totals5m = "1";
                            if (Convert.ToInt32(Math.Round(Convert.ToDouble(nnnn1[0].ItemArray.GetValue(1).ToString()))) >= 30) { totals5m = "2"; }
                            if (Convert.ToInt32(Math.Round(Convert.ToDouble(nnnn1[0].ItemArray.GetValue(1).ToString()))) >= 60) { totals5m = "3"; }
                        }
                        else
                        {
                            totals5m = "1";
                        }
                    }
                    else
                    {
                        fivem.Visible = false;
                        totals5m = "";
                    }
                }
                else
                {
                    totals4m = "0";
                    totals5m = "0";
                }
                //create table
                _ravi["Product_Id"] = drow["Product_Id"].ToString().Trim();
                _ravi["Product_Colour"] = drow["Product_Colour"].ToString().Trim();
                _ravi["Product_Name"] = drow["Product_Name"].ToString().Trim();
                _ravi["Product_4M_Status"] = totals4m;
                _ravi["Product_5M_Status"] = totals5m;
                dt.Rows.Add(_ravi);

            }
            // then add it to the a data table to build into the view below instead of what is now.......

            DataView dv = new DataView(dt); //this is the old one
            this.scsblocklist.DataSource = dv;
            this.scsblocklist.DataBind();
            
           
        }
        protected void results(object sender, CommandEventArgs e)
        {
            resulting(e.CommandName.ToString(), e.CommandArgument.ToString());
            
        }

        protected void Detail_Info(object sender, CommandEventArgs e)
        {
            listview.Visible = false;
            blockview.Visible = false;
            detailview.Visible = true;
            Label_Code.Visible = false;
            Label_Code2.Visible = false;
            DataTable testing = null;
            Requests requestings = new Requests();
            var names = e.CommandName.ToString().Split(',');
              string ttttt = names[0].ToString().Trim(); //4m status
              string ttttt2 = names[1].ToString().Trim(); //5m status
              if (ttttt != "")
              {
                  M4Meter.Attributes["class"] = GetName(ttttt);
                  M4Meter.InnerText = "4M";
              }
              else
              {
                  M4Meter.Attributes["class"] = "remove";
                  M4Meter.InnerText = "";
              }
              if (ttttt2 != "")
              {
                  M5Meter.Attributes["class"] = GetName(ttttt2);
                  M5Meter.InnerText = "5M";
              }
              else
              {
                  M5Meter.Attributes["class"] = "remove";
                  M5Meter.InnerText = "";
              }
              DataTransferFunction getlist = new DataTransferFunction();
                DataView dv = new DataView(getlist.getmeblockdetail(Convert.ToInt32(e.CommandArgument.ToString())));
                Label_Name.Text = dv.Table.Rows[0]["Product_Design_Name"].ToString() + " -- " + dv.Table.Rows[0]["Product_Colour"].ToString();
                if (dv.Table.Rows[0]["Product_4M_Ref"].ToString() != "")
                {
                    Label_Code.Visible = true; M4Meter.Visible = true;
                    Label_Code.Text = dv.Table.Rows[0]["Product_4M_Ref"].ToString();
                    testing = requestings.requestforstockref(dv.Table.Rows[0]["Product_4M_Ref"].ToString());
                    DataView dv4M = new DataView(requestings.requestforstockref(dv.Table.Rows[0]["Product_4M_Ref"].ToString())); //this is the old one
                    this.DataList4M.DataSource = dv4M;
                    this.DataList4M.DataBind();
                }
                if (dv.Table.Rows[0]["Product_5M_Ref"].ToString() != "")
                {
                    Label_Code2.Visible = true; M5Meter.Visible = true;
                    Label_Code2.Text = dv.Table.Rows[0]["Product_5M_Ref"].ToString();

                    DataView dv5M = new DataView(requestings.requestforstockref(dv.Table.Rows[0]["Product_5M_Ref"].ToString())); //this is the old one
                    this.DataList5M.DataSource = dv5M;
                    this.DataList5M.DataBind();
                }
                Label_Summary.Text = dv.Table.Rows[0]["Product_Description"].ToString();
                Label_Construction.Text = dv.Table.Rows[0]["Product_Construction"].ToString();
                Label_Material.Text = dv.Table.Rows[0]["Product_Material"].ToString();
                //HiddenB.CommandArgument = e.CommandArgument.ToString();
                bigimage.ImageUrl ="imagesizeme.ashx?ID=" + dv.Table.Rows[0]["Product_Name"].ToString() + ".jpg";
            
        
        }
        protected void YourButton_Click(object sender, CommandEventArgs e)
        {
            DataTransferFunction getlist = new DataTransferFunction();
            DataView dv = new DataView(getlist.getmeblockdetail(Convert.ToInt32(e.CommandArgument.ToString().Trim())));
            DataRow row;
            row = dv.Table.Rows[0];

            foreach (DataRow drow in dv.Table.Rows)
            {

                if (drow.RowState != DataRowState.Deleted)
                {


                }
            }
           //sl_main.Attributes["class"] = "level 4m left nil";
           //sl_main.InnerText = "4M";
           
           //sl_main2.Attributes["class"] = "level 4m left nil";
           //sl_main2.InnerText = "5M";
           //Div1.Visible = true;
        }

        //'<%# GetName((int)Eval("id")) %>'
        protected string GetName(string pro_id)
        {
            if (pro_id == "1")
            {
                return "level 4m left nil";
            }
            else if (pro_id == "2")
            {
                return "level 4m left low";
            }
            else if (pro_id == "3")
            {
                return "level 4m left normal";
            }
            else
            {
                return "remove";
            }
           
        }
        //protected void YourButton_Click2(object sender, CommandEventArgs e)
        //{
        //    DataTransferFunction getlist = new DataTransferFunction();
        //    DataView dv = new DataView(getlist.getmeblockdetail(Convert.ToInt32(e.CommandArgument.ToString().Trim())));
        //      DataRow row;
        //        row = dv.Table.Rows[0];
                
        //        foreach (DataRow drow in dv.Table.Rows)
              
        //        {

        //            if (drow.RowState != DataRowState.Deleted)
        //            {
                        
                     
        //            }
        //        }
        //    sl_main.Attributes["class"] = "level 4m left nil";
        //    sl_main.InnerText = "4M";

        //    sl_main2.Attributes["class"] = "level 4m left nil";
        //    sl_main2.InnerText = "5M";
                    
           
        //}


      
    }
}