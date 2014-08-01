using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Functions
{
    public class Products
    {
        public string Product_Design_Name { get; set; }
        public string Product_Name { get; set; }
        public string Product_Colour { get; set; }
        public string Product_Desciption { get; set; }
        public string Product_Width_Desciption { get; set; }
        public string Product_4M_Ref { get; set; }
        public string Product_5M_Ref { get; set; }
        public string Product_Construction { get; set; }
        public int Product_4M_Status { get; set; }
        public int Product_5M_Status { get; set; }
        public int Prodcut_Design_ID { get; set; }
        public string Product_Material { get; set; }
        public int Product_Show { get; set; }
        public int Product_Id { get; set; }

    }

    public class Design
    {
        public string Design_Ref { get; set; }
        public string Design_Name { get; set; }

    }
}
