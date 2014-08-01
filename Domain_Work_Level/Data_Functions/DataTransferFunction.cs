using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Data_Level.DataSet_SCSTableAdapters;
using Data_Level.DataSet_ProductsTableAdapters;
using System.IO;
using Data_Functions;


namespace Data_Functions
{
  public class DataTransferFunction
    {

        public string authentication(string username, string password)
        {
            string screen = "";
            UsersTableAdapter authent = new UsersTableAdapter();
          var screens = authent.GetDataByAuth(username, password);
          if (screens.Count > 0)
          {
              screen = screens.Rows[0].ItemArray[4].ToString();
          }
          
            return screen;
        }

        public string authenticationAdmin(string username, string password)
        {
            string screen = "";
            UsersTableAdapter authent = new UsersTableAdapter();
            var screens = authent.GetDataByAuth(username, password);
            if (screens.Count > 0)
            {
                screen = screens.Rows[0].ItemArray[4].ToString();
            }

            return screen;
        }

        public DataTable getmeprolist()
        {
            DataTable ds = null;

            ProductsTableAdapter alldesigns = new ProductsTableAdapter();
            ds = alldesigns.GetDataByDesignGroup();
            return ds;
        }


        public DataTable getmeblocklist(string design_id)
        {
            DataTable ds = null;

            ProductsTableAdapter alldesigns = new ProductsTableAdapter();
            ds = alldesigns.GetDataByProductByDesignID(design_id);
            return ds;
        }
        public DataTable getmeblocklist2(Int32 design_id)
        {
            DataTable ds = null;

            ProductsTableAdapter alldesigns = new ProductsTableAdapter();
            ds = alldesigns.GetDataByDesignId(design_id);
            return ds;
        }

        public DataTable getmeblockdetail(Int32 product_id)
        {
            DataTable ds = null;

            ProductsTableAdapter alldesigns = new ProductsTableAdapter();
            ds = alldesigns.GetDataByProductByProID(product_id);
            return ds;
        }

        public bool isthereany(string designid)
        {
            bool returninfo = false;
            DesignsTableAdapter alldesigns = new DesignsTableAdapter();

            var isitthere = alldesigns.ScalarQueryAny(designid);
            if (isitthere.ToString() != "0") { returninfo = true; }
            
            return returninfo;

        }
        public void insertnewdesign(string reference, string newnew)
        {
            DesignsTableAdapter alldesigns = new DesignsTableAdapter();
            alldesigns.InsertQueryNew(reference, newnew);
        }
        public DataTable getdesignbyid(int reference)
        {
            DataTable ds = null;
            DesignsTableAdapter alldesigns = new DesignsTableAdapter();
            ds = alldesigns.GetDataById(reference);
            return ds;
        }

        public int updatedesignname(string designname, int designid)
        {
             DesignsTableAdapter alldesigns = new DesignsTableAdapter();
             int ans = alldesigns.UpdateQueryDesignNane(designname, designid);
             ProductsTableAdapter alldesigns2 = new ProductsTableAdapter();
             int ans2 = alldesigns2.UpdateQueryDesignnames(designname, designid);
            if(ans != 0 && ans2 != 0){ans = 1;} else {ans = 0;}
          
             return ans;
        }

        public bool isthereanyproduct(string name, int designid)
        {
            bool returninfo = false;
            ProductsTableAdapter alldesigns = new ProductsTableAdapter();

            var isitthere = alldesigns.ScalarQueryProductName(name, designid);
           if (isitthere.ToString() != "0") { returninfo = true; }

            return returninfo;

        }

        public bool insertnewproduct(Products obj)
        {
            bool returninfo = false;
            ProductsTableAdapter alldesigns = new ProductsTableAdapter();

            try
            {
                alldesigns.InsertQueryNewProduct(obj.Product_Design_Name, obj.Product_Name, obj.Product_Show, obj.Prodcut_Design_ID);
                returninfo = true;
            }
            catch
            {
                returninfo = false;
            }
            return returninfo;
        }

        public bool updateproducts(Products obj)
        {
            bool returninfo = false;
            ProductsTableAdapter alldesigns = new ProductsTableAdapter();

            try
            {
                alldesigns.UpdateQueryProducts(obj.Product_Name, obj.Product_Colour, obj.Product_Desciption, obj.Product_Width_Desciption, obj.Product_4M_Ref, obj.Product_5M_Ref, obj.Product_Construction
                    , obj.Product_Material, obj.Product_Show, obj.Product_Id);
                returninfo = true;
            }
            catch
            {
                returninfo = false;
            }
            return returninfo;
        }

        public bool deleteproduct(int productid)
        {
            bool returninfo = false;
            ProductsTableAdapter alldesigns = new ProductsTableAdapter();
            try
            {
                alldesigns.DeleteQueryProduct(productid);
                returninfo = true;
            }
            catch
            {
                returninfo = false;
            }
            return returninfo;
        }
        public DataTable ReadXML(string file)
        {
            //create the DataTable that will hold the data
            DataTable table = new DataTable("XmlData");
            try
            {
                //open the file using a Stream
                using (Stream stream = new FileStream(file, FileMode.Open, FileAccess.Read))
                {
                    //create the table with the appropriate column names
                    table.Columns.Add("Name", typeof(string));
                    table.Columns.Add("Power", typeof(int));
                    table.Columns.Add("Location", typeof(string));

                    //use ReadXml to read the XML stream
                    table.ReadXml(stream);

                    //return the results
                    return table;
                }
            }
            catch (Exception ex)
            {
                return table;
            }
        }
    }
}
