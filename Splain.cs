using System;

namespace Splain1_1
{
    class Splain
    {

        public double funcS20(double x, double pi_1, double pi, double pi_plus1)
        {
            return ((1 - x) * (1 - x) * pi_1 + (6 - 2 * x * x) * pi + (1 + x) * (1 + x) * pi_plus1) / 8;
        }

        public double funcS21(double x, double pi_2, double pi_1, double pi, double pi_plus1, double pi_plus2)
        {
            return ((-1) * (1 - x) * (1 - x) * pi_2 + (2 - 16 * x + 10 * x * x) * pi_1 + (46 - 18 * x * x) * pi + (2 + 16 * x + 10 * x * x) * pi_plus1 - (1 + x) * (1 + x) * pi_plus2) / 48;
        }

        public double funcS32(double x, double pi_3, double pi_2, double pi_1, double pi, double pi_plus1, double pi_plus2, double pi_plus3, double pi_plus4)
        {
            return ((47 - 141 * x + 141 * x * x - 47 * x * x * x) * pi_3 + (653 + 579 * x - 1425 * x * x + 569 * x * x * x) * pi_2 + (-6849 + 1383 * x + 6885 * x * x - 3339 * x * x * x) * pi_1 + (33797 - 33705 * x - 5601 * x * x + 7501 * x * x * x) * pi + (33797 + 33705 * x - 5601 * x * x - 7501 * x * x * x) * pi_plus1 + (-6849 - 1383 * x + 6885 * x * x + 3335 * x * x * x) * pi_plus2 + (653 - 579 * x - 1425 * x * x - 569 * x * x * x) * pi_plus3 + (47 + 141 * x + 141 * x * x + 47 * x * x * x) * pi_plus4) / 55296;
        }

        public double funcS30(double x, double pi_1, double pi, double pi_plus1, double pi_plus2)
        {
            return (3 * pi - pi_1 - 3 * pi_plus1 + pi_plus2) * x * x * x / 48 + (pi_1 - 2 * pi + pi_plus1) * x * x / 8 + (pi_plus1 - pi_1) * x / 4 + (pi_1 + 4 * pi + pi_plus1) / 6;
        }
        public double S30(double x, double pi_1, double pi, double pi_plus1, double pi_plus2)
        {
          return  (1.0 / 48) * (
                    pi_1 * (1 - 3 * x + 3 * x * x - 1 * x * x * x) +
                    pi * (23 - 15 * x - 3 * x * x + 3 * x * x * x) +
                    pi_plus1 * (23 + 15 * x - 3 * x * x - 3 * x * x * x) +
                    pi_plus2 * (1 + 3 * x + 3 * x * x + 1 * x * x * x));
        }

        public double S31(double x, double pi_2, double pi_1, double pi, double pi_plus1, double pi_plus2, double pi_plus3)
        {
            return ((-5 + 15 * x - 15 * x * x + 5 * x * x * x) * pi_2 +
                    (-81 - 27 * x + 117 * x * x - 49 * x * x * x) * pi_1 +
                    (662 - 570 * x - 102 * x * x + 122 * x * x * x) * pi +
                    (662 + 570 * x - 102 * x * x - 122 * x * x * x) * pi_plus1 +
                    (-81 + 27 * x + 117 * x * x + 49 * x * x * x) * pi_plus2 +
                    (-5 - 15 * x - 15 * x * x - 5 * x * x * x) * pi_plus3) / 1152;
        }

        public double funcS22(double x, double pi_3, double pi_2, double pi_1, double pi, double pi_plus1, double pi_plus2, double pi_plus3)
        {
            return ((1 - x) * (1 - x) * pi_3 + ((-1) * 4 + 20 * x - 12 * x * x) * pi_2 + ((-1) * 106 * x - 5 + 75 * x * x) * pi_1 + (304 - 128 * x * x) * pi + (106 * x - 5 + 75 * x * x) * pi_plus1 + ((-1) * 4 - 20 * x - 12 * x * x) * pi_plus2 + (1 + x) * (1 + x) * pi_plus3) / 288;
        }

        public double funcS31(double x, double pi_2, double pi_1, double pi, double pi_plus1, double pi_plus2, double pi_plus3)
        {
            return ((-5 + 15 * x - 15 * x * x + 5 * x * x * x) * pi_2 + (-81 - 27 * x + 117 * x * x - 49 * x * x * x) * pi_1 + (662 - 570 * x - 102 * x * x + 122 * x * x * x) * pi + (662 + 570 * x - 102 * x * x - 122 * x * x * x) * pi_plus1 + (-81 + 27 * x + 117 * x * x + 49 * x * x * x) * pi_plus2 + (-5 - 15 * x - 15 * x * x - 5 * x * x * x) * pi_plus3) / 1152;
        }

        public double funcS40(double x, double pi_2, double pi_1, double pi, double pi_plus1, double pi_plus2)
        {
            return ((1 - 4 * x + 6 * x * x - 4 * x * x * x + x * x * x * x) * pi_2 + (76 - 88 * x + 24 * x * x + 8 * x * x * x - 4 * x * x * x * x) * pi_1 + (230 - 60 * x * x + 6 * x * x * x * x) * pi + (76 + 88 * x + 24 * x * x - 8 * x * x * x - 4 * x * x * x * x) * pi_plus1 + (1 + 4 * x + 6 * x * x + 4 * x * x * x + x * x * x * x) * pi_plus2) / 384;
        }

        public double funcS41(double x, double pi_3, double pi_2, double pi_1, double pi, double pi_plus1, double pi_plus2, double pi_plus3)
        {
            double x2 = x * x;
            double x3 = x * x * x;
            double x4 = x * x * x * x;
            return ((-1 + 4 * x - 6 * x2 + 4 * x3 - x4) * pi_3 + (-70 + 64 * x + 12 * x2 - 32 * x3 + 10 * x4) * pi_2 + (225 - 524 * x + 198 * x2 + 52 * x3 - 31 * x4) * pi_1 + (1228 - 408 * x2 + 44 * x4) * pi + (225 + 524 * x + 198 * x2 - 52 * x3 - 31 * x4) * pi_plus1 + (-70 - 64 * x + 12 * x2 + 32 * x3 + 10 * x4) * pi_plus2 + (-1 - 4 * x - 6 * x2 - 4 * x3 - x4) * pi_plus3) / 1536;
        }

        public double funcS42(double x, double pi_4, double pi_3, double pi_2, double pi_1, double pi, double pi_plus1, double pi_plus2, double pi_plus3, double pi_plus4)
        {
            double x2 = x * x;
            double x3 = x * x * x;
            double x4 = x * x * x * x;
            return ((13 - 52 * x + 78 * x2 - 52 * x3 + 13 * x4) * pi_4 + (876 - 696 * x - 360 * x2 + 552 * x3 - 164 * x4) * pi_3 + (-5084 + 8104 * x - 840 * x2 - 2648 * x3 + 964 * x4) * pi_2 + (8404 - 36952 * x + 16872 * x2 + 3848 * x3 - 2588 * x4) * pi_1 + (83742 - 31500 * x2 + 3550 * x4) * pi + (8404 + 36952 * x + 16872 * x2 - 3848 * x3 - 2588 * x4) * pi_plus1 + (-5084 - 8104 * x - 840 * x2 + 2648 * x3 + 964 * x4) * pi_plus2 + (876 + 696 * x - 360 * x2 - 552 * x3 - 164 * x4) * pi_plus3 + (13 + 52 * x + 78 * x2 + 52 * x3 + 13 * x4) * pi_plus4) / 92160;
        }

        public double funcS50(double x, double pi_2, double pi_1, double pi, double pi_plus1, double pi_plus2, double pi_plus3)
        {
            double x2 = x * x;
            double x3 = x * x * x;
            double x4 = x * x * x * x;
            double x5 = x * x * x * x * x;
            return (Math.Pow((1 - x), 5) * pi_2 + 
                (237 - 375 * x + 210 * x2 - 30 * x3 - 15 * x4 + 5 * x5) * pi_1 + 
                (1682 - 770 * x - 220 * x2 + 140 * x3 + 10 * x4 - 10 * x5) * pi + 
                (1682 + 770 * x - 220 * x2 - 140 * x3 + 10 * x4 + 10 * x5) * pi_plus1 + 
                (237 + 375 * x + 210 * x2 + 30 * x3 - 15 * x4 - 5 * x5) * pi_plus2 + 
                (Math.Pow(1 + x, 5)) * pi_plus3) / 3840;
        }
    }
}
