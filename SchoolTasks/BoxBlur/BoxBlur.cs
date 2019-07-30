using System.Drawing;

namespace BoxBlur
{
    class BoxBlur
    {
        static void Main(string[] args)
        {
            Bitmap image = new Bitmap("..\\..\\image.jpg");

            for (int y = 0; y < image.Height; ++y)
            {
                for (int x = 0; x < image.Width; ++x)
                {
                    Color pixel = image.GetPixel(x, y);
//                    Color newColor = Color.FromArgb(maxRgb - pixel.R, maxRgb - pixel.G, maxRgb - pixel.B);
                    result[x, y, 0] = maxRgb - pixel.R;
                    result[x, y, 1] = maxRgb - pixel.G;
                    result[x, y, 2] = maxRgb - pixel.B;

//                    image.SetPixel(x, y, newColor);
                }
            }

            double[,] effectMatrix =
            {
                {1.0 / 9.0, 1.0 / 9.0, 1.0 / 9.0},
                {1.0 / 9.0, 1.0 / 9.0, 1.0 / 9.0},
                {1.0 / 9.0, 1.0 / 9.0, 1.0 / 9.0}
            };

            GetWithEffect(image, effectMatrix).Save("out.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
        }

        private static Bitmap GetWithEffect(Bitmap input, double[,] effectMatrix)
        {
            Bitmap result = new Bitmap(input.Width - 1, input.Height - 1);
            int indentFromSide = effectMatrix.GetLength(0) / 2;

            for (int y = 0; y < result.Height; ++y)
            {
                for (int x = 0; x < result.Width; ++x)
                {

                }
            }

            return result;
        }
    }
}