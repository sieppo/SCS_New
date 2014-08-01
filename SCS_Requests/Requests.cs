using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;
using System.ComponentModel;

namespace SCS_Requests
{
  public class Requests
    {

      public DataTable requestforstocklive(string key)
      {
          ServiceReference1.SCS_ServiceClient newproxy = new ServiceReference1.SCS_ServiceClient();
          DataTable dt = null;
          try
          {
                     var newtable33 = newproxy.gettotals(key);
            dt = newtable33.gettotals.Tables[0];
             
          }
          catch
          {
              newproxy.Close();
          }
          newproxy.Close();
          return dt;

      }

      public DataTable requestforstockref(string stockref)
      {
          ServiceReference1.SCS_ServiceClient newproxy = new ServiceReference1.SCS_ServiceClient();
          DataTable dt = null;
          try
          {
              var newtable33 = newproxy.getbystock(stockref);
              dt = newtable33.gettotals.Tables[0];
              
          }
          catch
          {
              newproxy.Close();
          }
          newproxy.Close();
          return dt;

      }


    }
}
