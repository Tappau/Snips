using System.Drawing;
using System.Drawing.Imaging;

namespace SnipsSolution.Extensions
{
    public static class BitmapExtensions
    {
        public static Bitmap ToGreyScale(this Bitmap bitmap)
        {
            var newBitmap = new Bitmap(bitmap.Width, bitmap.Height);
            var graphics = Graphics.FromImage(newBitmap);

            //Greyscale colour matrix
            var colourMatrix = new ColorMatrix(new[]
            {
                new[] {.3f, .3f, .3f, 0, 0},
                new[] {.59f, .59f, .59f, 0, 0},
                new[] {.11f, .11f, .11f, 0, 0},
                new float[] {0, 0, 0, 1, 0},
                new float[] {0, 0, 0, 0, 1}
            });

            var attributes = new ImageAttributes();
            attributes.SetColorMatrix(colourMatrix);

            graphics.DrawImage(bitmap, new Rectangle(0, 0, bitmap.Width, bitmap.Height), 0, 0, bitmap.Width,
                bitmap.Height, GraphicsUnit.Pixel, attributes);
            graphics.Dispose();

            return newBitmap;
        }
    }
}