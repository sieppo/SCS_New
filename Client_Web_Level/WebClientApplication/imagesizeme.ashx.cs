using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;

namespace WebClientApplication
{
    /// <summary>
    /// Summary description for imagesizeme
    /// </summary>
    public class imagesizeme : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            //context.Response.ContentType = "text/plain";
            //context.Response.Write("Hello World");
            int _imageId;
            string nameimage;
            if (context.Request.QueryString["id"] != null)
            {
                //_imageId = Convert.ToInt32(context.Request.QueryString["ID"]);
                nameimage = context.Request.QueryString["ID"].ToString();
            }
            else
            { throw new ArgumentException("No parameter specified"); }

            if (!File.Exists(context.Server.MapPath("images/fullImage/" + nameimage)))
            { nameimage = "missing-piece.jpg"; }
            System.Drawing.Image image = System.Drawing.Image.FromFile(context.Server.MapPath("images/fullImage/" + nameimage), true);  //System.Drawing.Image.FromFile("~/images/fullImage/" + nameimage);
            int newwidthimg = 350;
            float AspectRatio = (float)image.Size.Width / (float)image.Size.Height;
            int newHeight = 350;
            Bitmap bitMAP1 = new Bitmap(newwidthimg, newHeight);
            Graphics imgGraph = Graphics.FromImage(bitMAP1);
            imgGraph.CompositingQuality = CompositingQuality.HighQuality;
            imgGraph.SmoothingMode = SmoothingMode.HighQuality;
            imgGraph.InterpolationMode = InterpolationMode.HighQualityBicubic;
            var imgDimesions = new Rectangle(0, 0, newwidthimg, newHeight);
            imgGraph.DrawImage(image, imgDimesions);
            bitMAP1.Save(context.Response.OutputStream, ImageFormat.Jpeg);

            imgGraph.Dispose();
            bitMAP1.Dispose();
            image.Dispose();
          
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}