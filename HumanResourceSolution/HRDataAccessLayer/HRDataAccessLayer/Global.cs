using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace HRDataAccessLayer 
{
    public static class Global
    {
        #region ImageToArray
        public static byte[] ImageToArray(Image img)
        {
            byte[] photoArray;
            MemoryStream ms = new MemoryStream();
            img.Save(ms, ImageFormat.Png);
            photoArray = ms.ToArray();
            return photoArray;
        }
        #endregion

        #region ArrayToImage
        public static Image ArrayToImage(byte[] photoArray)
        {
            MemoryStream ms = new MemoryStream(photoArray);
            Image img = Image.FromStream(ms);
            return img;
        }
        #endregion
    }
}
