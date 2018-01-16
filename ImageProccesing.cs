using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Drawing.Drawing2D;

namespace Splain1_1
{
    struct RGB
        {
            public float R;
            public float G;
            public float B;
        }

    class ImageProccesing
    {
        #region комбинированый фильтр
        public Bitmap ComboFilter(Bitmap bm)
        {
            Bitmap Zbtmp = new Bitmap(bm.Width * 2, bm.Height * 2);
            Bitmap tmpA = z2l5A(bm);
            Bitmap tmpB = z2l5B(bm);
            Bitmap tmpC = z2l5C(bm);
            Bitmap tmpD = z2l5D(bm);

            for (int i = 0; i < bm.Width; i++)
            {
                for (int j = 0; j < bm.Height; j++)
                {
                    Zbtmp.SetPixel(2 * i, 2 * j, tmpA.GetPixel(i, j));
                    Zbtmp.SetPixel((2 * i) + 1, 2 * j, tmpB.GetPixel(i, j));
                    Zbtmp.SetPixel(2 * i, (2 * j) + 1, tmpC.GetPixel(i, j));
                    Zbtmp.SetPixel((2 * i) + 1, (2 * j) + 1, tmpD.GetPixel(i, j));
                }
            }
            return Zbtmp;
        }

        double[] vector = new double[] { 0, 5, 461, 4724, -63068, 57878, 57878, -63068, 4724, 461, 5 };
        double[] vect1 = new double[] { 0, 0, 40, 2928, -15680, -56432, 138288, -56432, -15680, 2928, 40 };
        double delitel = 1152 * 384;
        double del2 = 384;

        #region Вариант Руслана
        //double[] vector = new double[] { -11017, 22756754, -151349858, -967111630, -2863182025, 22229970912, 367391463552,22229970912, -2863182025, -967111630, -151349858, 22756754, -11017 };
        //double[] vect1 = new double[] { 0, -44068, 91247356, -1061812484, 1805781596, -25094051712, 226225684224,226225684224, -25094051712, 1805781596, -1061812484, 91247356, -44068 };
        //double delitel = Math.Sqrt(1.6316236e+23);
        //double del2 = Math.Sqrt( 1.6316236e+23);
        #endregion

        #region Валин вариант
        //double[] vector = new double[] { 0, -1, -19, 123, 617, 617, 123, -19, -1 };
        //double[] vect1 = new double[] { -1, -24, 32, 1304, 3138, 1304, 32, -24, -1 };
        //double delitel = (1440);
        //double del2 = 5760;
        #endregion

        public Bitmap Subdiv2D(Bitmap bm , double[]Ar,double[] Br, double aa)
        {
            Bitmap Zbtmp = new Bitmap(bm.Width * 2, bm.Height * 2);

            double[,] A = VectorOnVector(Ar, Ar);
            A = DivideArray(A, aa);
            A = DivideArray(A, aa);
            Bitmap tmpA = ConvolutionFilter(bm,A, 1.0, 0, false, false);



            double[,] B = VectorOnVector(Ar, Br);
            B = DivideArray(B, aa);
            B = DivideArray(B, aa);
            Bitmap tmpB = ConvolutionFilter(bm, B, 1.0, 0, false, false);

            double[,] C = Transpon1(B);
            Bitmap tmpC = ConvolutionFilter(bm,C, 1.0, 0, false, false);


            double[,] D = VectorOnVector(Br, Br);
            D = DivideArray(D, aa);
            D = DivideArray(D, aa);
            Bitmap tmpD = ConvolutionFilter(bm, D, 1.0, 0, false, false);

            for (int i = 0; i < bm.Width; i++)
            {
                for (int j = 0; j < bm.Height; j++)
                {
                    Zbtmp.SetPixel(2 * i, 2 * j, tmpA.GetPixel(i, j));
                    Zbtmp.SetPixel((2 * i) + 1, 2 * j, tmpB.GetPixel(i, j));
                    Zbtmp.SetPixel(2 * i, (2 * j) + 1, tmpC.GetPixel(i, j));
                    Zbtmp.SetPixel((2 * i) + 1, (2 * j) + 1, tmpD.GetPixel(i, j));
                }
            }
            return Zbtmp;
        }



        public Bitmap z2l5A(Bitmap sourceBitmap, bool grayscale = false)
        {   
            double[,] A = VectorOnVector(vector, vector);
            A = DivideArray(A, delitel);
            A = DivideArray(A, delitel);


            Bitmap resultBitmap = ConvolutionFilter(sourceBitmap,
                                    A, 1.0, 0, grayscale, false);

            return resultBitmap;
        }
        public double[,] DivideArray(double[,] arr, double d)
        {
            for(int i=0;i<arr.GetLength(0);i++)
            {
                for(int j=0;j<arr.GetLength(1);j++)
                {
                    arr[i, j] = arr[i, j] / d;
                }
            }
            return arr;
        }

        public double[,] VectorOnVector(double[] v1, double[] v2)
        {
            double[,] result = new double[v1.Length, v2.Length];

            for(int i=0;i<v1.Length; i++)
            {
                for (int j = 0; j < v2.Length; j++)
                {
                    result[i, j] = v1[i] * v2[j];
                }
            }

            return result;
        }

        public double[,] Transpon1(double[,] A)
        {
            double[,] B = new double[A.GetLength(1), A.GetLength(0)];
            for (int i = 0; i < A.GetLength(1); i++)
            {
                for (int j = 0; j < A.GetLength(0); j++)
                {
                    B[i, j] = A[j, i];
                }
            }
            return B;
        }

        double[,] C;
        public Bitmap z2l5B(Bitmap sourceBitmap, bool grayscale = false)
        {


            double[,] B = VectorOnVector( vect1,vector);
            B = DivideArray(B, delitel);
            B = DivideArray(B, del2);

            C = Transpon1(B);
            Bitmap resultBitmap = ConvolutionFilter(sourceBitmap,
                                    B, 1.0, 0, grayscale, false);

            return resultBitmap;
        }
        public  Bitmap z2l5C(Bitmap sourceBitmap, bool grayscale = false)
        {
            Bitmap resultBitmap = ConvolutionFilter(sourceBitmap,
                                    C, 1.0, 0, grayscale, false);

            return resultBitmap;
        }
        public  Bitmap z2l5D(Bitmap sourceBitmap, bool grayscale = false)
        {

            double[,] D = VectorOnVector(vect1, vect1);
            D = DivideArray(D, del2);
            D = DivideArray(D, del2);

        
            Bitmap resultBitmap = ConvolutionFilter(sourceBitmap,
                                    D, 1.0, 0, grayscale, false);

            return resultBitmap;
        }
        #endregion

        #region subdivision
        public Bitmap Subdivision(Bitmap bm)
        {
            Bitmap Zbtmp = new Bitmap(bm.Width * 2, bm.Height * 2);

            Bitmap tmpA = zoom2xA(bm, false);
            Bitmap tmpB = zoom2xB(bm, false);
            Bitmap tmpC = zoom2xC(bm, false);
            Bitmap tmpD = zoom2xD(bm, false);

            for (int i = 0; i < bm.Width; i++)
            {
                for (int j = 0; j < bm.Height; j++)
                {
                    Zbtmp.SetPixel(2 * i, 2 * j, tmpA.GetPixel(i, j));
                    Zbtmp.SetPixel((2 * i) + 1, 2 * j, tmpB.GetPixel(i, j));
                    Zbtmp.SetPixel(2 * i, (2 * j) + 1, tmpC.GetPixel(i, j));
                    Zbtmp.SetPixel((2 * i) + 1, (2 * j) + 1, tmpD.GetPixel(i, j));
                }
            }

            return Zbtmp;
        }

        public Bitmap zoom2xA(Bitmap sourceBitmap, bool grayscale = false)
        {
            double del = 1.0 / 2304;

            double[,] a = new double[,]
            {
                {1*del,-2*del,46*del,-2*del,1*del },
                {-2*del,4*del,92*del,4*del,-2*del },
                {-46*del,92*del,2116*del,92*del,-46*del },
                {-2*del,4*del,92*del,4*del,-2*del },
                {1*del,-2*del,46*del,-2*del,1*del }
            };

            Bitmap resultBitmap = ConvolutionFilter(sourceBitmap,
                                    a, 1.0, 0, grayscale);

            return resultBitmap;
        }
        public Bitmap zoom2xB(Bitmap sourceBitmap, bool grayscale = false)
        {
            double del = 1.0 / 576;

            double[,] b= new double[,]
            {
                {0,1*del,-7*del,-1*del,1*del },
                {0,-2*del,14*del,14*del,-2*del },
                {0,-46*del,322*del,322*del,-46*del },
                {0,-2*del,14*del,14*del,-2*del },
                {0,1*del,-7*del,-7*del,1*del }
            }
            ;

            Bitmap resultBitmap = ConvolutionFilter(sourceBitmap,
                                   b, 1.0, 0, grayscale);

            return resultBitmap;
        }
        public Bitmap zoom2xC(Bitmap sourceBitmap, bool grayscale = false)
        {
            double del = 1.0 / 576;

            double[,] c= new double[,]
            {
                {0,0,0,0,0 },
                {1*del,-2*del,-46*del,-2*del,1*del },
                {-7*del,14*del,322*del,14*del,-7*del },
                {-7*del,14*del,322*del,14*del,-7*del },
                {1*del,-2*del,-46*del,-2*del,1*del }
            }
            ;

            Bitmap resultBitmap = ConvolutionFilter(sourceBitmap,
                                    c, 1.0, 0, grayscale);

            return resultBitmap;
        }
        public Bitmap zoom2xD(Bitmap sourceBitmap, bool grayscale = false)
        {
            double del = 1.0 / 144;

            double[,] d= new double[,]
            {
                {0,0,0,-0,0 },
                {0,1*del,-7*del,-7*del,1*del },
                {0,-7*del,49*del,49*del,-7*del },
                {0,-7*del,49*del,49*del,-7*del },
                {0,1*del,-7*del,-7*del,1*del }
            }
            ;

            Bitmap resultBitmap = ConvolutionFilter(sourceBitmap,
                                    d, 1.0, 0, grayscale);

            return resultBitmap;
        }
        #endregion

        public Bitmap UniteBitmap(Bitmap[] btm, Bitmap bm)
        {
                Graphics g = Graphics.FromImage(bm);
                g.DrawImage(btm[0], 0, 0);
                g.DrawImage(btm[1], btm[0].Width, 0);
                g.DrawImage(btm[2], 0, btm[0].Height);
                g.DrawImage(btm[3], btm[0].Width, btm[0].Height);
                g.Dispose();
                return bm;
        }

        public Bitmap UniteBitmap(Bitmap btm, Bitmap bm)
        {
            Graphics g = Graphics.FromImage(bm);
            g.DrawImage(btm, 0, 0);
            g.Dispose();
            return bm;
        }


        public Bitmap Decrease_Image(Bitmap bt)
        {
            Bitmap result = new Bitmap(bt.Width / 2+1,bt.Height/2+1);
            int ii = 0;
            for(int i=0;i<bt.Width;i+=2)
            {
                int jj = 0;
                for(int j=0;j<bt.Height;j+=2)
                {
                    
                    result.SetPixel(ii,jj,bt.GetPixel(i,j));
                    jj++;
                }
                ii++;
            }

            return result;
        }

        #region 1 способ
        public Bitmap ConvolutionFilter(Bitmap sourceBitmap, double[,] filterMatrix, double factor = 1, int bias = 0, bool grayscale = false, bool HighFilter = false)
        {
            BitmapData sourceData = sourceBitmap.LockBits(new Rectangle(0, 0,
                                     sourceBitmap.Width, sourceBitmap.Height),
                                                       ImageLockMode.ReadOnly,
                                                 PixelFormat.Format32bppArgb);

            byte[] pixelBuffer = new byte[sourceData.Stride * sourceData.Height];
            byte[] resultBuffer = new byte[sourceData.Stride * sourceData.Height];

            Marshal.Copy(sourceData.Scan0, pixelBuffer, 0, pixelBuffer.Length);
            sourceBitmap.UnlockBits(sourceData);

            if (grayscale == true)
            {
                float rgb = 0;

                for (int k = 0; k < pixelBuffer.Length; k += 4)
                {
                    rgb = pixelBuffer[k] * 0.11f;
                    rgb += pixelBuffer[k + 1] * 0.59f;
                    rgb += pixelBuffer[k + 2] * 0.3f;


                    pixelBuffer[k] = (byte)rgb;
                    pixelBuffer[k + 1] = pixelBuffer[k];
                    pixelBuffer[k + 2] = pixelBuffer[k];
                    pixelBuffer[k + 3] = 255;
                }
            }

            double blue = 0.0;
            double green = 0.0;
            double red = 0.0;

            double minR = 0;
            double minG = 0;
            double minB = 0;

            double maxR = 255;
            double maxB = 255;
            double maxG = 255;

            int filterWidth = filterMatrix.GetLength(1);
            int filterHeight = filterMatrix.GetLength(0);

            int filterOffset = (filterWidth - 1) / 2;
            int calcOffset = 0;

            int byteOffset = 0;

            for (int offsetY = filterOffset; offsetY <
                sourceBitmap.Height - filterOffset; offsetY++)
            {
                for (int offsetX = filterOffset; offsetX <
                    sourceBitmap.Width - filterOffset; offsetX++)
                {
                    blue = 0;
                    green = 0;
                    red = 0;

                    byteOffset = offsetY *
                                 sourceData.Stride +
                                 offsetX * 4;

                    for (int filterY = -filterOffset;
                        filterY <= filterOffset; filterY++)
                    {
                        for (int filterX = -filterOffset;
                            filterX <= filterOffset; filterX++)
                        {

                            calcOffset = byteOffset +
                                         (filterX * 4) +
                                         (filterY * sourceData.Stride);

                            blue += (double)(pixelBuffer[calcOffset]) *
                                    filterMatrix[filterY + filterOffset,
                                                        filterX + filterOffset];

                            green += (double)(pixelBuffer[calcOffset + 1]) *
                                     filterMatrix[filterY + filterOffset,
                                                        filterX + filterOffset];

                            red += (double)(pixelBuffer[calcOffset + 2]) *
                                   filterMatrix[filterY + filterOffset,
                                                      filterX + filterOffset];
                        }
                    }

                    blue = factor * blue + bias;
                    green = factor * green + bias;
                    red = factor * red + bias;

                    if (blue > 255)
                    {if (blue > maxB) maxB = blue;
                        blue = 255;
                    }
                    else if (blue < 0)
                    {if (blue < minB) minB = blue;
                        blue = 0; }

                    if (green > 255)
                    {
                        if (green > maxG) maxG = green;
                        green = 255; }
                    else if (green < 0)
                    {
                        if (green < minG) minG = green;
                        green = 0; }

                    if (red > 255)
                    {
                        if (red > maxR) maxR = red;
                        red = 255; }
                    else if (red < 0)
                    {
                        if (red < minR) minB = red;
                        red = 0; }

                    if(HighFilter==false)
                    {
                    resultBuffer[byteOffset] = (byte)(blue);
                    resultBuffer[byteOffset + 1] = (byte)(green);
                    resultBuffer[byteOffset + 2] = (byte)(red);
                    resultBuffer[byteOffset + 3] = 255;
                    }
                }
            }

            if (HighFilter)
            {
                for (int offsetY = filterOffset; offsetY <
                sourceBitmap.Height - filterOffset; offsetY++)
                {
                    for (int offsetX = filterOffset; offsetX <
                        sourceBitmap.Width - filterOffset; offsetX++)
                    {
                        blue = 0;
                        green = 0;
                        red = 0;

                        byteOffset = offsetY *
                                     sourceData.Stride +
                                     offsetX * 4;

                        for (int filterY = -filterOffset;
                            filterY <= filterOffset; filterY++)
                        {
                            for (int filterX = -filterOffset;
                                filterX <= filterOffset; filterX++)
                            {

                                calcOffset = byteOffset +
                                             (filterX * 4) +
                                             (filterY * sourceData.Stride);

                                blue += (double)(pixelBuffer[calcOffset]) *
                                        filterMatrix[filterY + filterOffset,
                                                            filterX + filterOffset];

                                green += (double)(pixelBuffer[calcOffset + 1]) *
                                         filterMatrix[filterY + filterOffset,
                                                            filterX + filterOffset];

                                red += (double)(pixelBuffer[calcOffset + 2]) *
                                       filterMatrix[filterY + filterOffset,
                                                          filterX + filterOffset];
                            }
                        }

                        blue = factor * blue + bias;
                        green = factor * green + bias;
                        red = factor * red + bias;

                        blue = (blue - minR) * 255 / (maxB - minB);
                        green = (green - minG) * 255 / (maxG - minG);
                        red = (red - minR) * 255 / (maxR - minR);

                        if ((byte)red > 100 || (byte)blue > 100)
                        {
                            red = 255;
                            green = 255;
                            blue = 255;
                        }
                        else
                        {
                            red = 0;
                            green = 0;
                            blue = 0;
                        }

                        resultBuffer[byteOffset] = (byte)(blue);
                        resultBuffer[byteOffset + 1] = (byte)(green);
                        resultBuffer[byteOffset + 2] = (byte)(red);
                        resultBuffer[byteOffset + 3] = 255;

                    }
                }
            }

                    Bitmap resultBitmap = new Bitmap(sourceBitmap.Width, sourceBitmap.Height);

           

            BitmapData resultData = resultBitmap.LockBits(new Rectangle(0, 0,
                                     resultBitmap.Width, resultBitmap.Height),
                                                      ImageLockMode.WriteOnly,
                                                 PixelFormat.Format32bppArgb);

            Marshal.Copy(resultBuffer, 0, resultData.Scan0, resultBuffer.Length);
            resultBitmap.UnlockBits(resultData);

            return resultBitmap;
        }
        #endregion
        #region 2 способ
        public UInt32[,] matrix_filtration(int W, int H, UInt32[,] pixel, int N, double[,] matryx)
        {
            int i, j, k, m, gap = (int)(N / 2);
            int tmpH = H + 2 * gap, tmpW = W + 2 * gap;
            UInt32[,] tmppixel = new UInt32[tmpH, tmpW];
            UInt32[,] newpixel = new UInt32[H, W];
            //заполнение временного расширенного изображения
            //углы
            for (i = 0; i < gap; i++)
                for (j = 0; j < gap; j++)
                {
                    tmppixel[i, j] = pixel[0, 0];
                    tmppixel[i, tmpW - 1 - j] = pixel[0, W - 1];
                    tmppixel[tmpH - 1 - i, j] = pixel[H - 1, 0];
                    tmppixel[tmpH - 1 - i, tmpW - 1 - j] = pixel[H - 1, W - 1];
                }
            //крайние левая и правая стороны
            for (i = gap; i < tmpH - gap; i++)
                for (j = 0; j < gap; j++)
                {
                    tmppixel[i, j] = pixel[i - gap, j];
                    tmppixel[i, tmpW - 1 - j] = pixel[i - gap, W - 1 - j];
                }
            //крайние верхняя и нижняя стороны
            for (i = 0; i < gap; i++)
                for (j = gap; j < tmpW - gap; j++)
                {
                    tmppixel[i, j] = pixel[i, j - gap];
                    tmppixel[tmpH - 1 - i, j] = pixel[H - 1 - i, j - gap];
                }
            //центр
            for (i = 0; i < H; i++)
                for (j = 0; j < W; j++)
                    tmppixel[i + gap, j + gap] = pixel[i, j];
            //применение ядра свертки
            RGB ColorOfPixel = new RGB();
            RGB ColorOfCell = new RGB();
            for (i = gap; i < tmpH - gap; i++)
                for (j = gap; j < tmpW - gap; j++)
                {
                    ColorOfPixel.R = 0;
                    ColorOfPixel.G = 0;
                    ColorOfPixel.B = 0;
                    for (k = 0; k < N; k++)
                        for (m = 0; m < N; m++)
                        {
                            ColorOfCell = calculationOfColor(tmppixel[i - gap + k, j - gap + m], matryx[k, m]);
                            ColorOfPixel.R += ColorOfCell.R;
                            ColorOfPixel.G += ColorOfCell.G;
                            ColorOfPixel.B += ColorOfCell.B;
                        }
                    //контролируем переполнение переменных
                    if (ColorOfPixel.R < 0) ColorOfPixel.R = 0;
                    if (ColorOfPixel.R > 255) ColorOfPixel.R = 255;
                    if (ColorOfPixel.G < 0) ColorOfPixel.G = 0;
                    if (ColorOfPixel.G > 255) ColorOfPixel.G = 255;
                    if (ColorOfPixel.B < 0) ColorOfPixel.B = 0;
                    if (ColorOfPixel.B > 255) ColorOfPixel.B = 255;

                    newpixel[i - gap, j - gap] = build(ColorOfPixel);
                }

            return newpixel;
        }

        //вычисление нового цвета
        public static RGB calculationOfColor(UInt32 pixel, double coefficient)
        {
            RGB Color = new RGB();
            Color.R = (float)(coefficient * ((pixel & 0x00FF0000) >> 16));
            Color.G = (float)(coefficient * ((pixel & 0x0000FF00) >> 8));
            Color.B = (float)(coefficient * (pixel & 0x000000FF));
            return Color;
        }


        //сборка каналов
        public static UInt32 build(RGB ColorOfPixel)
        {
            UInt32 Color;
            Color = 0xFF000000 | ((UInt32)ColorOfPixel.R << 16) | ((UInt32)ColorOfPixel.G << 8) | ((UInt32)ColorOfPixel.B);
            return Color;
        }
        #endregion
    }
}

