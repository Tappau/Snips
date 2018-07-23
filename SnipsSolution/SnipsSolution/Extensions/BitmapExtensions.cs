using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnipsSolution.Extensions
{
    public static class BitmapExtensions
    {

        public static Bitmap ToGreyScale(this Bitmap bitmap)
        {
            Bitmap newBitmap = new Bitmap(bitmap.Width, bitmap.Height);
            Graphics graphics = Graphics.FromImage(newBitmap);

            //Greyscale colour matrix
            ColorMatrix colourMatrix = new ColorMatrix(new float[][]
            {
                new float[] {.3f, .3f, .3f, 0 ,0},
                new float[] {.59f, .59f, .59f, 0,0},
                new float[] {.11f, .11f, .11f, 0 ,0},
                new float[] {0,0,0,1,0},
                new float[] {0,0,0,0,1}
            });

            ImageAttributes attributes = new ImageAttributes();
            attributes.SetColorMatrix(colourMatrix);

            graphics.DrawImage(bitmap, new Rectangle(0,0, bitmap.Width, bitmap.Height), 0,0, bitmap.Width, bitmap.Height, GraphicsUnit.Pixel, attributes);
            graphics.Dispose();

            return newBitmap;
        }
    }
}
