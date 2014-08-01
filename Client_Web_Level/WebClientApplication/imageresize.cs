

using System;
using System.Web;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace WebClientApplication
{
    public class imageresize : IHttpHandler
    {
        
        #region IHttpHandler Members

        public bool IsReusable
        {
            
            get { return true; }
        }

        public void ProcessRequest(HttpContext context)
        {
            int _imageId;
            string nameimage;
            if (context.Request.QueryString["id"] != null)
            {
                _imageId = Convert.ToInt32(context.Request.QueryString["ID"]);
                nameimage = context.Request.QueryString["ID"].ToString();
            }
            else
            { throw new ArgumentException("No parameter specified"); }
            System.Drawing.Image image = System.Drawing.Image.FromFile("images/fullImage/" + nameimage);
            int newwidthimg = 130;
            float AspectRatio = (float)image.Size.Width / (float)image.Size.Height;
            int newHeight = 100;
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

        #endregion
    }
}
