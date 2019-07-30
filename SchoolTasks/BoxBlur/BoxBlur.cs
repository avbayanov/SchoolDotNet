using System;
using System.Drawing;

namespace BoxBlur
{
    class BoxBlur
    {
        static void Main(string[] args)
        {
            Bitmap image = new Bitmap("..\\..\\image.jpg");

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
            int indentFromSide = effectMatrix.GetLength(0) / 2;
            Bitmap result = new Bitmap(input.Width - (indentFromSide * 2), input.Height - (indentFromSide * 2));

            for (int yInInput = indentFromSide; yInInput < input.Height - indentFromSide; ++yInInput)
            {
                for (int xInInput = indentFromSide; xInInput < input.Width - indentFromSide; ++xInInput)
                {
                    double[] pixel = new double[3];

                    for (int yInFocus = yInInput - indentFromSide, yInEffectMatrix = 0;
                        yInFocus <= yInInput + indentFromSide;
                        yInFocus++, yInEffectMatrix++)
                    {
                        for (int xInFocus = xInInput - indentFromSide, xInEffectMatrix = 0;
                            xInFocus <= xInInput + indentFromSide;
                            xInFocus++, xInEffectMatrix++)
                        {
                            Color neighborPixel = input.GetPixel(xInFocus, yInFocus);

                            pixel[0] += effectMatrix[xInEffectMatrix, yInEffectMatrix] * neighborPixel.R;
                            pixel[1] += effectMatrix[xInEffectMatrix, yInEffectMatrix] * neighborPixel.G;
                            pixel[2] += effectMatrix[xInEffectMatrix, yInEffectMatrix] * neighborPixel.B;
                        }
                    }

                    for (int i = 0; i < pixel.Length; i++)
                    {
                        if (pixel[i] > 255)
                        {
                            pixel[i] = 255;
                        }
                        else if (pixel[i] < 0)
                        {
                            pixel[i] = 0;
                        }
                    }

                    result.SetPixel(xInInput - indentFromSide, yInInput - indentFromSide,
                        Color.FromArgb((int) Math.Round(pixel[0]), (int) Math.Round(pixel[1]),
                            (int) Math.Round(pixel[2])));
                }
            }

            return result;
        }
    }
}