using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Splain1_1
{
    public partial class Gistograms : Form
    {
        public Gistograms()
        {
            InitializeComponent();
        }

        public void ShowGistogramm(Bitmap bmp)
        {
            double[] R = new double[256];
            double[] G = new double[256];
            double[] B = new double[256];
            
            for(int i=0;i<bmp.Width;i++)
            {
                for (int j=0;j<bmp.Height;j++)
                {
                    Color cl = bmp.GetPixel(i, j);
                    double r = cl.R;
                    double g = cl.G;
                    double b = cl.B;

                    for(int k=0;k<R.Length;k++)
                        if (r == k) R[k]++;

                    for (int k = 0; k < G.Length; k++)
                        if (g == k) G[k]++;

                    for (int k = 0; k < B.Length; k++)
                        if (b == k) B[k]++;

                }
            }
            
            for(int j=0;j<R.Length; j++)
            {
                chart1.Series[0].Points.AddXY(j, R[j]);
                chart2.Series[0].Points.AddXY(j, G[j]);
                chart3.Series[0].Points.AddXY(j, B[j]);
            }

        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void chart2_Click(object sender, EventArgs e)
        {

        }

        private void chart3_Click(object sender, EventArgs e)
        {

        }
    }
}
