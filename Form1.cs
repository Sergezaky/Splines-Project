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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBox2.Text = "5";
            checkBox1.Checked = false;
            textBox1.Text = "50";
            textBox3.Text = "-1";
            textBox4.Text = "1";
            textBox5.Text = "20";
            textBox8.Text = "10";
            panel1.AutoScroll = true;
        }

        double wtf = 0;
        int n = 0;

        Splain spcl = new Splain();
        bool parametr = false;
        List<double> P = new List<double>();

        public double SumOfMatrixElement(double[,] Matrix)
        {
            double sum = 0;

            for(int i=0;i<Matrix.GetLength(0);i++)
            {
                for(int j=0;j<Matrix.GetLength(1);j++)
                {
                    sum += Matrix[i, j];
                }
            }

            return sum;
        }

        private void chart1_Click(object sender, EventArgs e)
        {
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            parametr = false;
            P.Clear();
            chart1.Series.Clear();
            chart1.Series.Add("Вип.");
            chart1.Series.Add("Сплайн");
            chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            chart1.Series[1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            Random rnd = new Random();
            n = int.Parse(textBox1.Text);

            for (int i=0;i<n;i++)
            {
                double randomnumb =  rnd.Next(Convert.ToInt32(textBox2.Text));

                P.Add(randomnumb);
                chart1.Series[0].Points.AddXY(i+0.5,randomnumb);
            }
            for(int k=0;k<3;k++)
            {
                double randomnumb = rnd.Next(Convert.ToInt32(textBox2.Text));
                P.Add(randomnumb);
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
        }



        #region побудова сплайнов

        private void s20ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            #region равномерное разбитие
           
                chart1.Series[1].Points.Clear();
                wtf = 0;
                double ez = Convert.ToDouble(textBox5.Text);
                double eps = 2 / ez;
            if (parametr == false)
            {
                for (int i = 0; i < n; i++)
                {
                    double pi_2 = 0;
                    double pi_1 = 0;
                    double pi_p1 = 0;
                    double pi_p2 = 0;

                    try { pi_1 = P[i - 1]; }
                    catch { pi_1 = P[i]; }

                    try { pi_p1 = P[i + 1]; }
                    catch { pi_p1 = P[i]; }

                    try { pi_p2 = P[i + 2]; }
                    catch { pi_p2 = P[i]; }

                    try { pi_2 = P[i - 2]; }
                    catch { pi_2 = P[i]; }

                    for (double d = Convert.ToDouble(textBox3.Text) + eps; d < Convert.ToDouble(textBox4.Text); d += eps)
                    {
                        wtf += eps / 2;
                        chart1.Series[1].Points.AddXY(wtf, spcl.funcS20(d, pi_1, P[i], pi_p1));
                    }
                }
            }
            #endregion
            if (parametr)
            {
                
                chart2.Series[0].Points.Clear();
                List<double> ti = new List<double>();
                List<double> pi = new List<double>();

                chart3.Series[0].Points.Clear();
                chart4.Series[0].Points.Clear();
                wtf = 0;
                ez = Convert.ToDouble(textBox5.Text);
                eps = 2 / ez;

                for (int i = 0; i < int.Parse(textBox8.Text); i++)
                {
                    double pi_2 = 0;
                    double pi_1 = 0;
                    double pi_p1 = 0;
                    double pi_p2 = 0;

                    try { pi_1 = Ti[i - 1]; }
                    catch { pi_1 = Ti[i]; }

                    try { pi_p1 = Ti[i + 1]; }
                    catch { pi_p1 = Ti[i]; }

                    try { pi_p2 = Ti[i + 2]; }
                    catch { pi_p2 = Ti[i]; }

                    try { pi_2 = Ti[i - 2]; }
                    catch { pi_2 = Ti[i]; }

                    for (double d = Convert.ToDouble(textBox3.Text) + eps; d < Convert.ToDouble(textBox4.Text); d += eps)
                    {
                        double tempor = spcl.funcS20(d, pi_1, Ti[i], pi_p1);
                        wtf += eps / 2;
                        ti.Add(tempor);
                        chart4.Series[0].Points.AddXY(wtf - 0.5, tempor);
                    }
                }

                wtf = 0;
                 ez = Convert.ToDouble(textBox5.Text);
                 eps = 2 / ez;
                
                for (int i = 0; i < int.Parse(textBox8.Text); i++)
                {
                    double pi_2 = 0;
                    double pi_1 = 0;
                    double pi_p1 = 0;
                    double pi_p2 = 0;

                    try { pi_1 = Pi[i - 1]; }
                    catch { pi_1 = Pi[i]; }

                    try { pi_p1 = Pi[i + 1]; }
                    catch { pi_p1 = Pi[i]; }

                    try { pi_p2 = Pi[i + 2]; }
                    catch { pi_p2 = Pi[i]; }

                    try { pi_2 = Pi[i - 2]; }
                    catch { pi_2 = Pi[i]; }

                    for (double d = Convert.ToDouble(textBox3.Text) + eps; d < Convert.ToDouble(textBox4.Text); d += eps)
                    {
                        double tempor1 = spcl.funcS20(d, pi_1, Pi[i], pi_p1);
                        wtf += eps / 2;
                        pi.Add(tempor1);
                        chart3.Series[0].Points.AddXY(wtf - 0.5,tempor1 );
                    }
                }

                for (int index = 20; index < pi.Count-20; index++)
                {

                    chart2.Series[0].Points.AddXY(ti[index], pi[index]);
                }
            }
        }

        private void s21ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            #region равномерное разбитие
            chart1.Series[1].Points.Clear();
            wtf = 0;
            double ez = Convert.ToDouble(textBox5.Text);
            double eps = 2 / ez;
            if (parametr == false)
            {
                for (int i = 0; i < n; i++)
                {
                    double pi_2 = 0;
                    double pi_1 = 0;
                    double pi_p1 = 0;
                    double pi_p2 = 0;

                    try { pi_1 = P[i - 1]; }
                    catch { pi_1 = P[i]; }

                    try { pi_p1 = P[i + 1]; }
                    catch { pi_p1 = P[i]; }

                    try { pi_p2 = P[i + 2]; }
                    catch { pi_p2 = P[i]; }

                    try { pi_2 = P[i - 2]; }
                    catch { pi_2 = P[i]; }

                    for (double d = Convert.ToDouble(textBox3.Text) + eps; d < Convert.ToDouble(textBox4.Text); d += eps)
                    {
                        wtf += eps / 2;
                        chart1.Series[1].Points.AddXY(wtf, spcl.funcS21(d, pi_2, pi_1, P[i], pi_p1, pi_p2));
                    }

                }
            }
            #endregion
            if (parametr)
            {
                chart2.Series[0].Points.Clear();
                List<double> ti = new List<double>();
                List<double> pi = new List<double>();

                chart3.Series[0].Points.Clear();
                chart4.Series[0].Points.Clear();
                wtf = 0;
                ez = Convert.ToDouble(textBox5.Text);
                eps = 2 / ez;

                for (int i = 0; i < int.Parse(textBox8.Text); i++)
                {
                    double pi_2 = 0;
                    double pi_1 = 0;
                    double pi_p1 = 0;
                    double pi_p2 = 0;

                    try { pi_1 = Ti[i - 1]; }
                    catch { pi_1 = Ti[i]; }

                    try { pi_p1 = Ti[i + 1]; }
                    catch { pi_p1 = Ti[i]; }

                    try { pi_p2 = Ti[i + 2]; }
                    catch { pi_p2 = Ti[i]; }

                    try { pi_2 = Ti[i - 2]; }
                    catch { pi_2 = Ti[i]; }

                    for (double d = Convert.ToDouble(textBox3.Text) + eps; d < Convert.ToDouble(textBox4.Text); d += eps)
                    {
                        double tempor = spcl.funcS21(d, pi_2, pi_1, Ti[i], pi_p1, pi_p2);
                        ti.Add(tempor);
                        
                        chart4.Series[0].Points.AddXY(wtf - 0.5,tempor );wtf += eps / 2;
                    }
                }

                wtf = 0;
                ez = Convert.ToDouble(textBox5.Text);
                eps = 2 / ez;

                for (int i = 0; i < int.Parse(textBox8.Text); i++)
                {
                    double pi_2 = 0;
                    double pi_1 = 0;
                    double pi_p1 = 0;
                    double pi_p2 = 0;

                    try { pi_1 = Pi[i - 1]; }
                    catch { pi_1 = Pi[i]; }

                    try { pi_p1 = Pi[i + 1]; }
                    catch { pi_p1 = Pi[i]; }

                    try { pi_p2 = Pi[i + 2]; }
                    catch { pi_p2 = Pi[i]; }

                    try { pi_2 = Pi[i - 2]; }
                    catch { pi_2 = Pi[i]; }

                    for (double d = Convert.ToDouble(textBox3.Text) + eps; d < Convert.ToDouble(textBox4.Text); d += eps)
                    {
                        double tempo1 = spcl.funcS21(d, pi_2, pi_1, Pi[i], pi_p1, pi_p2);
                        pi.Add(tempo1);
                        
                        chart3.Series[0].Points.AddXY(wtf - 0.5, tempo1);
                        wtf += eps / 2;
                    }

                    wtf = 0;
                    for (int index = 30; index < pi.Count-30; index++)
                    {
                        wtf += eps / 2;
                        chart2.Series[0].Points.AddXY(ti[index], pi[index]);
                    }
                }
            }
        }

        public double Scalar(List<double> A, List<double> B,int index)
        {
            return A[index] * B[index];
        }

        private void s22ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            #region равномерное разбитие
            
                chart1.Series[1].Points.Clear();
                wtf = 0;
                double ez = Convert.ToDouble(textBox5.Text);
                double eps = 2 / ez;
            if (!parametr)
            {
                for (int i = 0; i < n; i++)
                {
                    double pi_3 = 0;
                    double pi_2 = 0;
                    double pi_1 = 0;
                    double pi_p1 = 0;
                    double pi_p2 = 0;
                    double pi_p3 = 0;

                    try { pi_1 = P[i - 1]; }
                    catch { pi_1 = P[i]; }

                    try { pi_p1 = P[i + 1]; }
                    catch { pi_p1 = P[i]; }

                    try { pi_p2 = P[i + 2]; }
                    catch { pi_p2 = P[i]; }

                    try { pi_2 = P[i - 2]; }
                    catch { pi_2 = P[i]; }

                    try { pi_3 = P[i - 3]; }
                    catch { pi_3 = P[i]; }

                    try { pi_p3 = P[i + 3]; }
                    catch { pi_p3 = P[i]; }

                    for (double d = Convert.ToDouble(textBox3.Text) + eps; d < Convert.ToDouble(textBox4.Text); d += eps)
                    {
                        wtf += eps / 2;
                        chart1.Series[1].Points.AddXY(wtf, spcl.funcS22(d, pi_3, pi_2, pi_1, P[i], pi_p1, pi_p2, pi_p3));
                    }

                }
            }
            #endregion

            if (parametr)
            {
                chart2.Series[0].Points.Clear();
                List<double> ti = new List<double>();
                List<double> pi = new List<double>();

                chart3.Series[0].Points.Clear();
                chart4.Series[0].Points.Clear();
                wtf = 0;
                ez = Convert.ToDouble(textBox5.Text);
                eps = 2 / ez;

                for (int i = 0; i < int.Parse(textBox8.Text); i++)
                {
                    double pi_3 = 0;
                    double pi_2 = 0;
                    double pi_1 = 0;
                    double pi_p1 = 0;
                    double pi_p2 = 0;
                    double pi_p3 = 0;

                    try { pi_1 = Ti[i - 1]; }
                    catch { pi_1 = Ti[i]; }

                    try { pi_p1 = Ti[i + 1]; }
                    catch { pi_p1 = Ti[i]; }

                    try { pi_p2 = Ti[i + 2]; }
                    catch { pi_p2 = Ti[i]; }

                    try { pi_2 = Ti[i - 2]; }
                    catch { pi_2 = Ti[i]; }

                    try { pi_3 = Ti[i - 3]; }
                    catch { pi_3 = Ti[i]; }

                    try { pi_p3 = Ti[i + 3]; }
                    catch { pi_p3 = Ti[i]; }

                    for (double d = Convert.ToDouble(textBox3.Text) + eps; d < Convert.ToDouble(textBox4.Text); d += eps)
                    {
                        double tempor = spcl.funcS22(d, pi_3, pi_2, pi_1, Ti[i], pi_p1, pi_p2, pi_p3);
                        ti.Add(tempor);
                        wtf += eps / 2;
                        chart4.Series[0].Points.AddXY(wtf - 0.5,tempor);
                    }
                }

                wtf = 0;
                ez = Convert.ToDouble(textBox5.Text);
                eps = 2 / ez;

                for (int i = 0; i < int.Parse(textBox8.Text); i++)
                {
                    double pi_3 = 0;
                    double pi_2 = 0;
                    double pi_1 = 0;
                    double pi_p1 = 0;
                    double pi_p2 = 0;
                    double pi_p3 = 0;

                    try { pi_1 = Pi[i - 1]; }
                    catch { pi_1 = Pi[i]; }

                    try { pi_p1 = Pi[i + 1]; }
                    catch { pi_p1 = Pi[i]; }

                    try { pi_p2 = Pi[i + 2]; }
                    catch { pi_p2 = Pi[i]; }

                    try { pi_2 = Pi[i - 2]; }
                    catch { pi_2 = Pi[i]; }

                    try { pi_3 = Pi[i - 3]; }
                    catch { pi_3 = Pi[i]; }

                    try { pi_p3 = Pi[i + 3]; }
                    catch { pi_p3 = Pi[i]; }

                    for (double d = Convert.ToDouble(textBox3.Text) + eps; d < Convert.ToDouble(textBox4.Text); d += eps)
                    {
                        double temp11 = spcl.funcS22(d, pi_3, pi_2, pi_1, Pi[i], pi_p1, pi_p2, pi_p3);
                        wtf += eps / 2;
                        pi.Add(temp11);
                        chart3.Series[0].Points.AddXY(wtf - 0.5,temp11);
                    }

                    wtf = 0;
                    for (int index = 30; index < pi.Count-30; index++)
                    {
                        wtf += eps / 2;
                        chart2.Series[0].Points.AddXY(ti[index],pi[index]);
                    }
                }
            }
        }

        private void s30ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            #region равномерное разбитие
            chart1.Series[1].Points.Clear();
            wtf = 0;
            double ez = Convert.ToDouble(textBox5.Text);
            double eps = 2 / ez;
            if (parametr == false)
            {
                for (int i = 0; i < n; i++)
                {
                    double pi_3 = 0;
                    double pi_2 = 0;
                    double pi_1 = 0;
                    double pi_p1 = 0;
                    double pi_p2 = 0;
                    double pi_p3 = 0;

                    try { pi_1 = P[i - 1]; }
                    catch { pi_1 = P[i]; }

                    try { pi_p1 = P[i + 1]; }
                    catch { pi_p1 = P[i]; }

                    try { pi_p2 = P[i + 2]; }
                    catch { pi_p2 = P[i]; }

                    try { pi_2 = P[i - 2]; }
                    catch { pi_2 = P[i]; }

                    try { pi_3 = P[i - 3]; }
                    catch { pi_3 = P[i]; }

                    try { pi_p3 = P[i + 3]; }
                    catch { pi_p3 = P[i]; }

                    for (double d = Convert.ToDouble(textBox3.Text) + 0.5; d < Convert.ToDouble(textBox4.Text) + 0.5; d += eps)
                    {
                        wtf += eps / 2;
                        //    chart1.Series[1].Points.AddXY(wtf+0.5, spcl.funcS30(d, pi_1, P[i], pi_p1, pi_p2));
                        chart1.Series[1].Points.AddXY(wtf + 0.5, spcl.S30(d, pi_1, P[i], pi_p1, pi_p2));
                    }

                }
            }
            #endregion

            if (parametr)
            {
                chart2.Series[0].Points.Clear();
                List<double> ti = new List<double>();
                List<double> pi = new List<double>();

                chart3.Series[0].Points.Clear();
                chart4.Series[0].Points.Clear();
                wtf = 0;
                ez = Convert.ToDouble(textBox5.Text);
                eps = 2 / ez;

                for (int i = 0; i < int.Parse(textBox8.Text); i++)
                {
                    double pi_3 = 0;
                    double pi_2 = 0;
                    double pi_1 = 0;
                    double pi_p1 = 0;
                    double pi_p2 = 0;
                    double pi_p3 = 0;

                    try { pi_1 = Ti[i - 1]; }
                    catch { pi_1 = Ti[i]; }

                    try { pi_p1 = Ti[i + 1]; }
                    catch { pi_p1 = Ti[i]; }

                    try { pi_p2 = Ti[i + 2]; }
                    catch { pi_p2 = Ti[i]; }

                    try { pi_2 = Ti[i - 2]; }
                    catch { pi_2 = Ti[i]; }

                    try { pi_3 = Ti[i - 3]; }
                    catch { pi_3 = Ti[i]; }

                    try { pi_p3 = Ti[i + 3]; }
                    catch { pi_p3 = Ti[i]; }

                    for (double d = Convert.ToDouble(textBox3.Text) + eps; d < Convert.ToDouble(textBox4.Text); d += eps)
                    {
                        double tempor = spcl.S30(d,pi_1, Ti[i], pi_p1, pi_p2);
                        ti.Add(tempor);
                        wtf += eps / 2;
                        chart4.Series[0].Points.AddXY(wtf - 0.5, tempor);
                    }
                }

                wtf = 0;
                ez = Convert.ToDouble(textBox5.Text);
                eps = 2 / ez;

                for (int i = 0; i < int.Parse(textBox8.Text); i++)
                {
                    double pi_3 = 0;
                    double pi_2 = 0;
                    double pi_1 = 0;
                    double pi_p1 = 0;
                    double pi_p2 = 0;
                    double pi_p3 = 0;

                    try { pi_1 = Pi[i - 1]; }
                    catch { pi_1 = Pi[i]; }

                    try { pi_p1 = Pi[i + 1]; }
                    catch { pi_p1 = Pi[i]; }

                    try { pi_p2 = Pi[i + 2]; }
                    catch { pi_p2 = Pi[i]; }

                    try { pi_2 = Pi[i - 2]; }
                    catch { pi_2 = Pi[i]; }

                    try { pi_3 = Pi[i - 3]; }
                    catch { pi_3 = Pi[i]; }

                    try { pi_p3 = Pi[i + 3]; }
                    catch { pi_p3 = Pi[i]; }

                    for (double d = Convert.ToDouble(textBox3.Text) + eps; d < Convert.ToDouble(textBox4.Text); d += eps)
                    {
                        double temp11 = spcl.S30(d, pi_1, Pi[i], pi_p1, pi_p2);
                        pi.Add(temp11);
                        wtf += eps / 2;
                        chart3.Series[0].Points.AddXY(wtf - 0.5, temp11);
                    }

                    wtf = 0;
                    for (int index = 30; index < pi.Count-30; index++)
                    {
                        wtf += eps / 2;
                        chart2.Series[0].Points.AddXY(ti[index], pi[index]);
                    }
                }
            }
        }

        private void s31ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            #region равномерное разбитие
            chart1.Series[1].Points.Clear();
            wtf = 0;
            double ez = Convert.ToDouble(textBox5.Text);
            double eps = 2 / ez;
            if (parametr == false)
            {
                for (int i = 0; i < n; i++)
                {
                    double pi_3 = 0;
                    double pi_2 = 0;
                    double pi_1 = 0;
                    double pi_p1 = 0;
                    double pi_p2 = 0;
                    double pi_p3 = 0;

                    try { pi_1 = P[i - 1]; }
                    catch { pi_1 = P[i]; }

                    try { pi_p1 = P[i + 1]; }
                    catch { pi_p1 = P[i]; }

                    try { pi_p2 = P[i + 2]; }
                    catch { pi_p2 = P[i]; }

                    try { pi_2 = P[i - 2]; }
                    catch { pi_2 = P[i]; }

                    try { pi_3 = P[i - 3]; }
                    catch { pi_3 = P[i]; }

                    try { pi_p3 = P[i + 3]; }
                    catch { pi_p3 = P[i]; }

                    for (double d = Convert.ToDouble(textBox3.Text) + 0.5; d < Convert.ToDouble(textBox4.Text) + 0.5; d += eps)
                    {
                        wtf += eps / 2;
                        chart1.Series[1].Points.AddXY(wtf + 0.5, spcl.funcS31(d, pi_2, pi_1, P[i], pi_p1, pi_p2, pi_p3));
                    }

                }
            }
            #endregion
            if (parametr)
            {
                chart2.Series[0].Points.Clear();
                List<double> ti = new List<double>();
                List<double> pi = new List<double>();

                chart3.Series[0].Points.Clear();
                chart4.Series[0].Points.Clear();
                wtf = 0;
                ez = Convert.ToDouble(textBox5.Text);
                eps = 2 / ez;

                for (int i = 0; i < int.Parse(textBox8.Text); i++)
                {
                    double pi_3 = 0;
                    double pi_2 = 0;
                    double pi_1 = 0;
                    double pi_p1 = 0;
                    double pi_p2 = 0;
                    double pi_p3 = 0;

                    try { pi_1 = Ti[i - 1]; }
                    catch { pi_1 = Ti[i]; }

                    try { pi_p1 = Ti[i + 1]; }
                    catch { pi_p1 = Ti[i]; }

                    try { pi_p2 = Ti[i + 2]; }
                    catch { pi_p2 = Ti[i]; }

                    try { pi_2 = Ti[i - 2]; }
                    catch { pi_2 = Ti[i]; }

                    try { pi_3 = Ti[i - 3]; }
                    catch { pi_3 = Ti[i]; }

                    try { pi_p3 = Ti[i + 3]; }
                    catch { pi_p3 = Ti[i]; }

                    for (double d = Convert.ToDouble(textBox3.Text)+eps; d < Convert.ToDouble(textBox4.Text); d += eps)
                    {
                        double tempor = spcl.S31(d, pi_2, pi_1, Ti[i], pi_p1, pi_p2, pi_p3);
                        ti.Add(tempor);
                        wtf += eps / 2;
                        chart4.Series[0].Points.AddXY(wtf + 0.5, tempor);
                    }
                }

                wtf = 0;
                ez = Convert.ToDouble(textBox5.Text);
                eps = 2 / ez;

                for (int i = 0; i < int.Parse(textBox8.Text); i++)
                {
                    double pi_3 = 0;
                    double pi_2 = 0;
                    double pi_1 = 0;
                    double pi_p1 = 0;
                    double pi_p2 = 0;
                    double pi_p3 = 0;

                    try { pi_1 = Pi[i - 1]; }
                    catch { pi_1 = Pi[i]; }

                    try { pi_p1 = Pi[i + 1]; }
                    catch { pi_p1 = Pi[i]; }

                    try { pi_p2 = Pi[i + 2]; }
                    catch { pi_p2 = Pi[i]; }

                    try { pi_2 = Pi[i - 2]; }
                    catch { pi_2 = Pi[i]; }

                    try { pi_3 = Pi[i - 3]; }
                    catch { pi_3 = Pi[i]; }

                    try { pi_p3 = Pi[i + 3]; }
                    catch { pi_p3 = Pi[i]; }

                    for (double d = Convert.ToDouble(textBox3.Text)+eps; d < Convert.ToDouble(textBox4.Text); d += eps)
                    {
                    //    double temp11 = spcl.funcS31(d, pi_2, pi_1, Pi[i], pi_p1, pi_p2, pi_p3);
                        double temp11 = spcl.S31(d, pi_2, pi_1, Pi[i], pi_p1, pi_p2, pi_p3);
                        wtf += eps / 2;
                        pi.Add(temp11);
                        chart3.Series[0].Points.AddXY(wtf + 0.5, temp11);
                    }

                    wtf = 0;
                    for (int index = 30; index < pi.Count-30; index++)
                    {
                        wtf += eps / 2;
                        chart2.Series[0].Points.AddXY(ti[index], pi[index]);
                    }
                }
            }
        }

        private void s32ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            #region равномерное разбитие
            chart1.Series[1].Points.Clear();
            wtf = 0;
            double ez = Convert.ToDouble(textBox5.Text);
            double eps = 2 / ez;
            if (parametr == false)
            {
                for (int i = 0; i < n; i++)
                {
                    double pi_3 = 0;
                    double pi_2 = 0;
                    double pi_1 = 0;
                    double pi_p1 = 0;
                    double pi_p2 = 0;
                    double pi_p3 = 0;
                    double pi_p4 = 0;

                    try { pi_1 = P[i - 1]; }
                    catch { pi_1 = P[i]; }

                    try { pi_p1 = P[i + 1]; }
                    catch { pi_p1 = P[i]; }

                    try { pi_p2 = P[i + 2]; }
                    catch { pi_p2 = P[i]; }

                    try { pi_2 = P[i - 2]; }
                    catch { pi_2 = P[i]; }

                    try { pi_3 = P[i - 3]; }
                    catch { pi_3 = P[i]; }

                    try { pi_p3 = P[i + 3]; }
                    catch { pi_p3 = P[i]; }

                    try { pi_p4 = P[i + 4]; }
                    catch { pi_p4 = P[i]; }

                    for (double d = Convert.ToDouble(textBox3.Text) + 0.5; d < Convert.ToDouble(textBox4.Text) + 0.5; d += eps)
                    {
                        wtf += eps / 2;
                        chart1.Series[1].Points.AddXY(wtf + 0.5, spcl.funcS32(d, pi_3, pi_2, pi_1, P[i], pi_p1, pi_p2, pi_p3, pi_p4));
                    }

                }
            }
            #endregion
            if (parametr)
            {
                chart2.Series[0].Points.Clear();
                List<double> ti = new List<double>();
                List<double> pi = new List<double>();

                chart3.Series[0].Points.Clear();
                chart4.Series[0].Points.Clear();
                wtf = 0;
                ez = Convert.ToDouble(textBox5.Text);
                eps = 2 / ez;

                for (int i = 0; i < int.Parse(textBox8.Text); i++)
                {
                    double pi_3 = 0;
                    double pi_2 = 0;
                    double pi_1 = 0;
                    double pi_p1 = 0;
                    double pi_p2 = 0;
                    double pi_p3 = 0;
                    double pi_p4 = 0;

                    try { pi_p4 = Ti[i + 4]; }
                    catch { pi_p4 = Ti[i]; }

                    try { pi_1 = Ti[i - 1]; }
                    catch { pi_1 = Ti[i]; }

                    try { pi_p1 = Ti[i + 1]; }
                    catch { pi_p1 = Ti[i]; }

                    try { pi_p2 = Ti[i + 2]; }
                    catch { pi_p2 = Ti[i]; }

                    try { pi_2 = Ti[i - 2]; }
                    catch { pi_2 = Ti[i]; }

                    try { pi_3 = Ti[i - 3]; }
                    catch { pi_3 = Ti[i]; }

                    try { pi_p3 = Ti[i + 3]; }
                    catch { pi_p3 = Ti[i]; }

                    for (double d = Convert.ToDouble(textBox3.Text)+eps; d < Convert.ToDouble(textBox4.Text); d += eps)
                    {
                        double tempor = spcl.funcS32(d,pi_3, pi_2, pi_1, Ti[i], pi_p1, pi_p2, pi_p3,pi_p4);
                        ti.Add(tempor);
                        wtf += eps / 2;
                        chart4.Series[0].Points.AddXY(wtf - 0.5, tempor);
                    }
                }

                wtf = 0;
                ez = Convert.ToDouble(textBox5.Text);
                eps = 2 / ez;

                for (int i = 0; i < int.Parse(textBox8.Text); i++)
                {
                    double pi_3 = 0;
                    double pi_2 = 0;
                    double pi_1 = 0;
                    double pi_p1 = 0;
                    double pi_p2 = 0;
                    double pi_p3 = 0;
                    double pi_p4 = 0;

                    try { pi_p4 = Pi[i + 4]; }
                    catch { pi_p4 = Pi[i]; }

                    try { pi_1 = Pi[i - 1]; }
                    catch { pi_1 = Pi[i]; }

                    try { pi_p1 = Pi[i + 1]; }
                    catch { pi_p1 = Pi[i]; }

                    try { pi_p2 = Pi[i + 2]; }
                    catch { pi_p2 = Pi[i]; }

                    try { pi_2 = Pi[i - 2]; }
                    catch { pi_2 = Pi[i]; }

                    try { pi_3 = Pi[i - 3]; }
                    catch { pi_3 = Pi[i]; }

                    try { pi_p3 = Pi[i + 3]; }
                    catch { pi_p3 = Pi[i]; }

                    for (double d = Convert.ToDouble(textBox3.Text)+eps; d < Convert.ToDouble(textBox4.Text); d += eps)
                    {
                        double temp11 = spcl.funcS32(d, pi_3, pi_2, pi_1, Pi[i], pi_p1, pi_p2, pi_p3, pi_p4);
                        wtf += eps / 2;
                        pi.Add(temp11);
                        chart3.Series[0].Points.AddXY(wtf - 0.5, temp11);
                    }

                    wtf = 0;
                    for (int index = 40; index < pi.Count-40; index++)
                    {
                        wtf += eps / 2;
                        chart2.Series[0].Points.AddXY(ti[index], pi[index]);
                    }
                }
            }
        }

        private void s40ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            #region равномерное разбитие
            chart1.Series[1].Points.Clear();
            wtf = 0;
            double ez = Convert.ToDouble(textBox5.Text);
            double eps = 2 / ez;
            if (parametr == false)
            {
                for (int i = 0; i < n; i++)
                {
                    double pi_3 = 0;
                    double pi_2 = 0;
                    double pi_1 = 0;
                    double pi_p1 = 0;
                    double pi_p2 = 0;
                    double pi_p3 = 0;
                    double pi_p4 = 0;

                    try { pi_1 = P[i - 1]; }
                    catch { pi_1 = P[i]; }

                    try { pi_p1 = P[i + 1]; }
                    catch { pi_p1 = P[i]; }

                    try { pi_p2 = P[i + 2]; }
                    catch { pi_p2 = P[i]; }

                    try { pi_2 = P[i - 2]; }
                    catch { pi_2 = P[i]; }

                    try { pi_3 = P[i - 3]; }
                    catch { pi_3 = P[i]; }

                    try { pi_p3 = P[i + 3]; }
                    catch { pi_p3 = P[i]; }

                    try { pi_p4 = P[i + 4]; }
                    catch { pi_p4 = P[i]; }

                    for (double d = Convert.ToDouble(textBox3.Text) + eps; d < Convert.ToDouble(textBox4.Text); d += eps)
                    {
                        wtf += eps / 2;
                        chart1.Series[1].Points.AddXY(wtf, spcl.funcS40(d, pi_2, pi_1, P[i], pi_p1, pi_p2));
                    }

                }
            }
            #endregion
            if (parametr)
            {
                chart2.Series[0].Points.Clear();
                List<double> ti = new List<double>();
                List<double> pi = new List<double>();

                chart3.Series[0].Points.Clear();
                chart4.Series[0].Points.Clear();
                wtf = 0;
                ez = Convert.ToDouble(textBox5.Text);
                eps = 2 / ez;

                for (int i = 0; i < int.Parse(textBox8.Text); i++)
                {
                    double pi_2 = 0;
                    double pi_1 = 0;
                    double pi_p1 = 0;
                    double pi_p2 = 0;

                    try { pi_1 = Ti[i - 1]; }
                    catch { pi_1 = Ti[i]; }

                    try { pi_p1 = Ti[i + 1]; }
                    catch { pi_p1 = Ti[i]; }

                    try { pi_p2 = Ti[i + 2]; }
                    catch { pi_p2 = Ti[i]; }

                    try { pi_2 = Ti[i - 2]; }
                    catch { pi_2 = Ti[i]; }

                    for (double d = Convert.ToDouble(textBox3.Text) + eps; d < Convert.ToDouble(textBox4.Text); d += eps)
                    {
                        double tempor = spcl.funcS40(d,pi_2, pi_1, Ti[i], pi_p1,pi_p2);
                        wtf += eps / 2;
                        ti.Add(tempor);
                        chart4.Series[0].Points.AddXY(wtf - 0.5, tempor);
                    }
                }

                wtf = 0;
                ez = Convert.ToDouble(textBox5.Text);
                eps = 2 / ez;

                for (int i = 0; i < int.Parse(textBox8.Text); i++)
                {
                    double pi_2 = 0;
                    double pi_1 = 0;
                    double pi_p1 = 0;
                    double pi_p2 = 0;

                    try { pi_1 = Pi[i - 1]; }
                    catch { pi_1 = Pi[i]; }

                    try { pi_p1 = Pi[i + 1]; }
                    catch { pi_p1 = Pi[i]; }

                    try { pi_p2 = Pi[i + 2]; }
                    catch { pi_p2 = Pi[i]; }

                    try { pi_2 = Pi[i - 2]; }
                    catch { pi_2 = Pi[i]; }

                    for (double d = Convert.ToDouble(textBox3.Text) + eps; d < Convert.ToDouble(textBox4.Text); d += eps)
                    {
                        double tempor1 = spcl.funcS40(d, pi_2, pi_1, Pi[i], pi_p1, pi_p2);
                        wtf += eps / 2;
                        pi.Add(tempor1);
                        chart3.Series[0].Points.AddXY(wtf - 0.5, tempor1);
                    }
                }
                wtf = 0;
                for (int index = 30; index < pi.Count-30; index++)
                {
                    wtf += eps / 2;
                    chart2.Series[0].Points.AddXY(ti[index], pi[index]);
                }

            }
        }

        private void s41ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            #region равномерное разбитие
            chart1.Series[1].Points.Clear();
            wtf = 0;
            double ez = Convert.ToDouble(textBox5.Text);
            double eps = 2 / ez;
            if (parametr == false)
            {
                for (int i = 0; i < n; i++)
                {
                    double pi_3 = 0;
                    double pi_2 = 0;
                    double pi_1 = 0;
                    double pi_p1 = 0;
                    double pi_p2 = 0;
                    double pi_p3 = 0;
                    double pi_p4 = 0;

                    try { pi_1 = P[i - 1]; }
                    catch { pi_1 = P[i]; }

                    try { pi_p1 = P[i + 1]; }
                    catch { pi_p1 = P[i]; }

                    try { pi_p2 = P[i + 2]; }
                    catch { pi_p2 = P[i]; }

                    try { pi_2 = P[i - 2]; }
                    catch { pi_2 = P[i]; }

                    try { pi_3 = P[i - 3]; }
                    catch { pi_3 = P[i]; }

                    try { pi_p3 = P[i + 3]; }
                    catch { pi_p3 = P[i]; }

                    try { pi_p4 = P[i + 4]; }
                    catch { pi_p4 = P[i]; }

                    for (double d = Convert.ToDouble(textBox3.Text) + eps; d < Convert.ToDouble(textBox4.Text); d += eps)
                    {
                        chart1.Series[1].Points.AddXY(wtf, spcl.funcS41(d, pi_3, pi_2, pi_1, P[i], pi_p1, pi_p2, pi_p3));
                        wtf += eps / 2;
                    }

                }
            }
            #endregion
            if (parametr)
            {
                chart2.Series[0].Points.Clear();
                List<double> ti = new List<double>();
                List<double> pi = new List<double>();

                chart3.Series[0].Points.Clear();
                chart4.Series[0].Points.Clear();
                wtf = 0;
                ez = Convert.ToDouble(textBox5.Text);
                eps = 2 / ez;

                for (int i = 0; i < int.Parse(textBox8.Text); i++)
                {
                    double pi_3 = 0;
                    double pi_2 = 0;
                    double pi_1 = 0;
                    double pi_p1 = 0;
                    double pi_p2 = 0;
                    double pi_p3 = 0;
                    double pi_p4 = 0;

                    try { pi_p4 = Ti[i + 4]; }
                    catch { pi_p4 = Ti[i]; }

                    try { pi_1 = Ti[i - 1]; }
                    catch { pi_1 = Ti[i]; }

                    try { pi_p1 = Ti[i + 1]; }
                    catch { pi_p1 = Ti[i]; }

                    try { pi_p2 = Ti[i + 2]; }
                    catch { pi_p2 = Ti[i]; }

                    try { pi_2 = Ti[i - 2]; }
                    catch { pi_2 = Ti[i]; }

                    try { pi_3 = Ti[i - 3]; }
                    catch { pi_3 = Ti[i]; }

                    try { pi_p3 = Ti[i + 3]; }
                    catch { pi_p3 = Ti[i]; }

                    for (double d = Convert.ToDouble(textBox3.Text) + eps; d < Convert.ToDouble(textBox4.Text); d += eps)
                    {
                        double tempor = spcl.funcS41(d,pi_3, pi_2, pi_1, Ti[i], pi_p1, pi_p2,pi_p3);
                        wtf += eps / 2;
                        ti.Add(tempor);
                        chart4.Series[0].Points.AddXY(wtf - 0.5, tempor);
                    }
                }

                wtf = 0;
                ez = Convert.ToDouble(textBox5.Text);
                eps = 2 / ez;

                for (int i = 0; i < int.Parse(textBox8.Text); i++)
                {
                    double pi_3 = 0;
                    double pi_2 = 0;
                    double pi_1 = 0;
                    double pi_p1 = 0;
                    double pi_p2 = 0;
                    double pi_p3 = 0;
                    double pi_p4 = 0;

                    try { pi_p4 = Pi[i + 4]; }
                    catch { pi_p4 = Pi[i]; }

                    try { pi_1 = Pi[i - 1]; }
                    catch { pi_1 = Pi[i]; }

                    try { pi_p1 = Pi[i + 1]; }
                    catch { pi_p1 = Pi[i]; }

                    try { pi_p2 = Pi[i + 2]; }
                    catch { pi_p2 = Pi[i]; }

                    try { pi_2 = Pi[i - 2]; }
                    catch { pi_2 = Pi[i]; }

                    try { pi_3 = Pi[i - 3]; }
                    catch { pi_3 = Pi[i]; }

                    try { pi_p3 = Pi[i + 3]; }
                    catch { pi_p3 = Pi[i]; }

                    for (double d = Convert.ToDouble(textBox3.Text) + eps; d < Convert.ToDouble(textBox4.Text); d += eps)
                    {
                        double tempor1 = spcl.funcS41(d,pi_3, pi_2, pi_1, Pi[i], pi_p1, pi_p2,pi_p3);
                        wtf += eps / 2;
                        pi.Add(tempor1);
                        chart3.Series[0].Points.AddXY(wtf - 0.5, tempor1);
                    }
                }
                wtf = 0;
                for (int index = 30; index < pi.Count-30; index++)
                {
                    wtf += eps / 2;
                    chart2.Series[0].Points.AddXY(ti[index], pi[index]);
                }

            }
        }

        private void s42ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            #region равномерное разбитие
            chart1.Series[1].Points.Clear();
            wtf = 0;
            double ez = Convert.ToDouble(textBox5.Text);
            double eps = 2 / ez;
            if (parametr == false)
            {
                for (int i = 0; i < n; i++)
                {
                    double pi_4 = 0;
                    double pi_3 = 0;
                    double pi_2 = 0;
                    double pi_1 = 0;
                    double pi_p1 = 0;
                    double pi_p2 = 0;
                    double pi_p3 = 0;
                    double pi_p4 = 0;

                    try { pi_1 = P[i - 1]; }
                    catch { pi_1 = P[i]; }

                    try { pi_p1 = P[i + 1]; }
                    catch { pi_p1 = P[i]; }

                    try { pi_p2 = P[i + 2]; }
                    catch { pi_p2 = P[i]; }

                    try { pi_2 = P[i - 2]; }
                    catch { pi_2 = P[i]; }

                    try { pi_3 = P[i - 3]; }
                    catch { pi_3 = P[i]; }

                    try { pi_4 = P[i - 4]; }
                    catch { pi_4 = P[i]; }

                    try { pi_p3 = P[i + 3]; }
                    catch { pi_p3 = P[i]; }

                    try { pi_p4 = P[i + 4]; }
                    catch { pi_p4 = P[i]; }

                    for (double d = Convert.ToDouble(textBox3.Text) + eps; d < Convert.ToDouble(textBox4.Text); d += eps)
                    {
                        wtf += eps / 2;
                        chart1.Series[1].Points.AddXY(wtf, spcl.funcS42(d, pi_4, pi_3, pi_2, pi_1, P[i], pi_p1, pi_p2, pi_p3, pi_p4));
                    }

                }
            }
            #endregion
            if (parametr)
            {
                chart2.Series[0].Points.Clear();
                List<double> ti = new List<double>();
                List<double> pi = new List<double>();

                chart3.Series[0].Points.Clear();
                chart4.Series[0].Points.Clear();
                wtf = 0;
                ez = Convert.ToDouble(textBox5.Text);
                eps = 2 / ez;

                for (int i = 0; i < int.Parse(textBox8.Text); i++)
                {
                    double pi_4 = 0;
                    double pi_3 = 0;
                    double pi_2 = 0;
                    double pi_1 = 0;
                    double pi_p1 = 0;
                    double pi_p2 = 0;
                    double pi_p3 = 0;
                    double pi_p4 = 0;

                    try { pi_4 = Ti[i - 4]; }
                    catch { pi_4 = Ti[i]; }

                    try { pi_p4 = Ti[i + 4]; }
                    catch { pi_p4 = Ti[i]; }

                    try { pi_1 = Ti[i - 1]; }
                    catch { pi_1 = Ti[i]; }

                    try { pi_p1 = Ti[i + 1]; }
                    catch { pi_p1 = Ti[i]; }

                    try { pi_p2 = Ti[i + 2]; }
                    catch { pi_p2 = Ti[i]; }

                    try { pi_2 = Ti[i - 2]; }
                    catch { pi_2 = Ti[i]; }

                    try { pi_3 = Ti[i - 3]; }
                    catch { pi_3 = Ti[i]; }

                    try { pi_p3 = Ti[i + 3]; }
                    catch { pi_p3 = Ti[i]; }

                    for (double d = Convert.ToDouble(textBox3.Text) + eps; d < Convert.ToDouble(textBox4.Text); d += eps)
                    {
                        double tempor = spcl.funcS42(d,pi_4, pi_3, pi_2, pi_1, Ti[i], pi_p1, pi_p2, pi_p3,pi_p4);
                        wtf += eps / 2;
                        ti.Add(tempor);
                        chart4.Series[0].Points.AddXY(wtf - 0.5, tempor);
                    }
                }

                wtf = 0;
                ez = Convert.ToDouble(textBox5.Text);
                eps = 2 / ez;

                for (int i = 0; i < int.Parse(textBox8.Text); i++)
                {
                    double pi_4 = 0;
                    double pi_3 = 0;
                    double pi_2 = 0;
                    double pi_1 = 0;
                    double pi_p1 = 0;
                    double pi_p2 = 0;
                    double pi_p3 = 0;
                    double pi_p4 = 0;

                    try { pi_4 = Pi[i - 4]; }
                    catch { pi_4 = Pi[i]; }

                    try { pi_p4 = Pi[i + 4]; }
                    catch { pi_p4 = Pi[i]; }

                    try { pi_1 = Pi[i - 1]; }
                    catch { pi_1 = Pi[i]; }

                    try { pi_p1 = Pi[i + 1]; }
                    catch { pi_p1 = Pi[i]; }

                    try { pi_p2 = Pi[i + 2]; }
                    catch { pi_p2 = Pi[i]; }

                    try { pi_2 = Pi[i - 2]; }
                    catch { pi_2 = Pi[i]; }

                    try { pi_3 = Pi[i - 3]; }
                    catch { pi_3 = Pi[i]; }

                    try { pi_p3 = Pi[i + 3]; }
                    catch { pi_p3 = Pi[i]; }

                    for (double d = Convert.ToDouble(textBox3.Text) + eps; d < Convert.ToDouble(textBox4.Text); d += eps)
                    {
                        double tempor1 = spcl.funcS42(d,pi_4, pi_3, pi_2, pi_1, Pi[i], pi_p1, pi_p2, pi_p3,pi_p4);
                        wtf += eps / 2;
                        pi.Add(tempor1);
                        chart3.Series[0].Points.AddXY(wtf - 0.5, tempor1);
                    }
                }
                wtf = 0;
                for (int index = 30; index < pi.Count-30; index++)
                {
                    wtf += eps / 2;
                    chart2.Series[0].Points.AddXY(ti[index], pi[index]);
                }

            }
        }

        private void s50ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            #region равномерное разбитие
            chart1.Series[1].Points.Clear();
            wtf = 0;
            double ez = Convert.ToDouble(textBox5.Text);
            double eps = 2 / ez;
            if (parametr == false)
            {
                for (int i = 0; i < n; i++)
                {
                    double pi_4 = 0;
                    double pi_3 = 0;
                    double pi_2 = 0;
                    double pi_1 = 0;
                    double pi_p1 = 0;
                    double pi_p2 = 0;
                    double pi_p3 = 0;
                    double pi_p4 = 0;

                    try { pi_1 = P[i - 1]; }
                    catch { pi_1 = P[i]; }

                    try { pi_p1 = P[i + 1]; }
                    catch { pi_p1 = P[i]; }

                    try { pi_p2 = P[i + 2]; }
                    catch { pi_p2 = P[i]; }

                    try { pi_2 = P[i - 2]; }
                    catch { pi_2 = P[i]; }

                    try { pi_3 = P[i - 3]; }
                    catch { pi_3 = P[i]; }

                    try { pi_4 = P[i - 4]; }
                    catch { pi_4 = P[i]; }

                    try { pi_p3 = P[i + 3]; }
                    catch { pi_p3 = P[i]; }

                    try { pi_p4 = P[i + 4]; }
                    catch { pi_p4 = P[i]; }

                    for (double d = Convert.ToDouble(textBox3.Text) + 0.5; d < Convert.ToDouble(textBox4.Text) + 0.5; d += eps)
                    {
                        wtf += eps / 2;
                        chart1.Series[1].Points.AddXY(wtf + 0.5, spcl.funcS50(d, pi_2, pi_1, P[i], pi_p1, pi_p2, pi_p3));
                    }

                }
            }
            #endregion
            if (parametr)
            {
                chart2.Series[0].Points.Clear();
                List<double> ti = new List<double>();
                List<double> pi = new List<double>();

                chart3.Series[0].Points.Clear();
                chart4.Series[0].Points.Clear();
                wtf = 0;
                ez = Convert.ToDouble(textBox5.Text);
                eps = 2 / ez;

                for (int i = 0; i < int.Parse(textBox8.Text); i++)
                {
                    double pi_3 = 0;
                    double pi_2 = 0;
                    double pi_1 = 0;
                    double pi_p1 = 0;
                    double pi_p2 = 0;
                    double pi_p3 = 0;

                    try { pi_1 = Ti[i - 1]; }
                    catch { pi_1 = Ti[i]; }

                    try { pi_p1 = Ti[i + 1]; }
                    catch { pi_p1 = Ti[i]; }

                    try { pi_p2 = Ti[i + 2]; }
                    catch { pi_p2 = Ti[i]; }

                    try { pi_2 = Ti[i - 2]; }
                    catch { pi_2 = Ti[i]; }

                    try { pi_3 = Ti[i - 3]; }
                    catch { pi_3 = Ti[i]; }

                    try { pi_p3 = Ti[i + 3]; }
                    catch { pi_p3 = Ti[i]; }

                    for (double d = Convert.ToDouble(textBox3.Text)+0.5; d < Convert.ToDouble(textBox4.Text)+0.5; d += eps)
                    {
                        double tempor = spcl.funcS50(d,pi_2, pi_1, Ti[i], pi_p1, pi_p2,pi_p3);
                        ti.Add(tempor);
                        wtf += eps / 2;
                        chart4.Series[0].Points.AddXY(wtf + 0.5, tempor);
                    }
                }

                wtf = 0;
                ez = Convert.ToDouble(textBox5.Text);
                eps = 2 / ez;

                for (int i = 0; i < int.Parse(textBox8.Text); i++)
                {
                    double pi_3 = 0;
                    double pi_2 = 0;
                    double pi_1 = 0;
                    double pi_p1 = 0;
                    double pi_p2 = 0;
                    double pi_p3 = 0;

                    try { pi_1 = Pi[i - 1]; }
                    catch { pi_1 = Pi[i]; }

                    try { pi_p1 = Pi[i + 1]; }
                    catch { pi_p1 = Pi[i]; }

                    try { pi_p2 = Pi[i + 2]; }
                    catch { pi_p2 = Pi[i]; }

                    try { pi_2 = Pi[i - 2]; }
                    catch { pi_2 = Pi[i]; }

                    try { pi_3 = Pi[i - 3]; }
                    catch { pi_3 = Pi[i]; }

                    try { pi_p3 = Pi[i + 3]; }
                    catch { pi_p3 = Pi[i]; }

                    for (double d = Convert.ToDouble(textBox3.Text)+0.5; d < Convert.ToDouble(textBox4.Text)+0.5; d += eps)
                    {
                        double temp11 = spcl.funcS50(d,pi_2, pi_1, Pi[i], pi_p1, pi_p2,pi_p3);
                        wtf += eps / 2;
                        pi.Add(temp11);
                        chart3.Series[0].Points.AddXY(wtf + 0.5, temp11);
                    }

                    wtf = 0;
                    for (int index = 40; index < pi.Count-40; index++)
                    {
                        wtf += eps / 2;
                        chart2.Series[0].Points.AddXY(ti[index], pi[index]);
                    }
                }
            }
        }

        #endregion

        private void button2_Click(object sender, EventArgs e)
        {
            double x =Convert.ToDouble(textBox6.Text);

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        List<double[]> PointsGen = new List<double[]>();
        double[] Pi;
        double[] Ti;

        public void NotRegularGeneration(System.Windows.Forms.DataVisualization.Charting.Chart chart)
        {
            Random rnd = new Random();
            parametr = true;

            PointsGen.Clear();
            chart.Series[0].Points.Clear();
            double deltat = 0;
            n = int.Parse(textBox8.Text);
            for (int i = 0; i < n; i++)
            {
                deltat += rnd.NextDouble();

                PointsGen.Add(new double[] { deltat, rnd.Next(5) + rnd.NextDouble() });
                chart.Series[0].Points.AddXY(deltat, PointsGen[i][1]);
            }
            

        }

        private void button3_Click(object sender, EventArgs e)
        {
            chart2.Series[0].Points.Clear();
            chart3.Series[0].Points.Clear();
            chart4.Series[0].Points.Clear();
            NotRegularGeneration(chart2);
            Pi = new double[n];
            Ti = new double[n];
            for (int t=0;t<n;t++)
            {
                Ti[t] = PointsGen[t][0];
                Pi[t] = PointsGen[t][1];
                chart4.Series[0].Points.AddXY(t,Ti[t]);
                chart3.Series[0].Points.AddXY(t, Pi[t]);

            }

        }

        private void chart2_Click(object sender, EventArgs e)
        {

        }
        #region Контуры генерация
        private void контурToolStripMenuItem_Click(object sender, EventArgs e)
        {
            parametr = true;
            textBox8.Text = "5";
            PointsGen.Clear();
            chart2.Series[0].Points.Clear();
            chart3.Series[0].Points.Clear();
            chart4.Series[0].Points.Clear();
            double deltat = 0;

            Random rnd = new Random();
            //for(int i=0;i<2;i++)
            //{
                deltat = rnd.NextDouble();
                double time = deltat;
                PointsGen.Add(new double[] {time ,rnd.Next(2)});
                time += rnd.NextDouble() / 10;
                PointsGen.Add(new double[] { time, rnd.Next(5) });
                time += rnd.Next(5);
                PointsGen.Add(new double[] { time, rnd.Next(2,5) });
                PointsGen.Add(new double[] { time+rnd.NextDouble()/10, rnd.Next(2) });
               // PointsGen.Add(new double[] { PointsGen[0][0],PointsGen[0][1]});
            //}

            for(int j=0;j<3;j++)
            for(int i=0;i<4;i++){ PointsGen.Add(PointsGen[i]);}
            textBox8.Text = PointsGen.Count.ToString() ;
            Pi = new double[PointsGen.Count];
            Ti = new double[PointsGen.Count];

            for (int t = 0; t < PointsGen.Count; t++)
            {
                chart2.Series[0].Points.AddXY(PointsGen[t][0], PointsGen[t][1]);
                Ti[t] = PointsGen[t][0];
                Pi[t] = PointsGen[t][1];
                chart4.Series[0].Points.AddXY(t, Ti[t]);
                chart3.Series[0].Points.AddXY(t, Pi[t]);

            }
        }

        private void зiркаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            parametr = true;
           
            PointsGen.Clear();
            chart2.Series[0].Points.Clear();
            chart3.Series[0].Points.Clear();
            chart4.Series[0].Points.Clear();

            PointsGen.Add(new double[] { 3.5, 4 });
            PointsGen.Add(new double[] { 2, 5 });
            PointsGen.Add(new double[] { 4, 5 });
            PointsGen.Add(new double[] { 5, 7 });
            PointsGen.Add(new double[] { 6, 5 });
            PointsGen.Add(new double[] { 8, 5 });
            PointsGen.Add(new double[] { 6.3, 4 });
            PointsGen.Add(new double[] { 7, 2 });
            PointsGen.Add(new double[] { 5, 3 });
            PointsGen.Add(new double[] { 3,2});
            PointsGen.Add(new double[] { 3.5, 4 });
            PointsGen.Add(new double[] { 2, 5 });
            PointsGen.Add(new double[] { 4, 5 });
            PointsGen.Add(new double[] { 5, 7 });
            PointsGen.Add(new double[] { 6, 5 });
            PointsGen.Add(new double[] { 8, 5 });
            PointsGen.Add(new double[] { 6.3, 4 });
            PointsGen.Add(new double[] { 7, 2 });
            PointsGen.Add(new double[] { 5, 3 });
            PointsGen.Add(new double[] { 3, 2 });
            PointsGen.Add(new double[] { 3.5, 4 });
            PointsGen.Add(new double[] { 2, 5 });
            PointsGen.Add(new double[] { 4, 5 });
            PointsGen.Add(new double[] { 5, 7 });
            PointsGen.Add(new double[] { 6, 5 });
            PointsGen.Add(new double[] { 8, 5 });
            PointsGen.Add(new double[] { 6.3, 4 });
            PointsGen.Add(new double[] { 7, 2 });
            PointsGen.Add(new double[] { 5, 3 });
            PointsGen.Add(new double[] { 3, 2 });

            textBox8.Text = PointsGen.Count.ToString() ;
            Pi = new double[PointsGen.Count];
            Ti = new double[PointsGen.Count];
            for (int t = 0; t < PointsGen.Count; t++)
            {
                chart2.Series[0].Points.AddXY(PointsGen[t][0], PointsGen[t][1]);
                Ti[t] = PointsGen[t][0];
                Pi[t] = PointsGen[t][1];
                chart4.Series[0].Points.AddXY(t, Ti[t]);
                chart3.Series[0].Points.AddXY(t, Pi[t]);

            }
        }
        #endregion

        private void фiльтриToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        List<double> KMAPoints = new List<double>();
        List<PointF> Generated_points = new List<PointF>();
        private void сгенеруватиПослiдовнiстьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            KMAPoints.Clear();
            Generated_points.Clear();
            chart5.Series[0].Points.Clear();
            chart5.Series[1].Points.Clear();

            chart5.Series[0].Color = Color.Red;
            double len = 0;
            Random r1 = new Random();
            Random r2 = new Random();
            bool ones = false;
            while(len<100)
            {
                if (ones == false)
                {
                    double numbers1 = r1.Next(10);
                    for(float i=0;i<numbers1; i+=(float)0.1)
                    {
                        double noise = r2.NextDouble()/10;
                        Generated_points.Add(new PointF(i,0+(float)noise));
                        KMAPoints.Add(0 + (float)noise);
                    }
                    len += numbers1;
                    ones = true;
                }

                if (ones)
                {
                    double numbers2 = r1.Next(10);
                    for (float i = 0; i < numbers2; i += (float)0.1)
                    {
                        double noise = r2.NextDouble()/10;
                        Generated_points.Add(new PointF(i, 1 + (float)noise));
                        KMAPoints.Add(1 + (float)noise);
                    }
                    len += numbers2;
                    ones = false;
                }

            }
            for(int k=0;k<Generated_points.Count;k++)
            {
                chart5.Series[0].Points.AddXY(k*0.1,(double)Generated_points[k].Y);
            }
            
        }

        #region KMA oдномерное
        List<double[]> P2_array = new List<double[]>();
        int KMA_counter1D = 0;


        public List<double> KMA1DBack(List<double> X)
        {
            List<double> result = new List<double>();
            double[] back = P2_array[KMA_counter1D - 1];
            for(int i=0;i<X.Count;i++)
            {
                result.Add(X[i]+back[i]);
                result.Add(X[i]-back[i]);
            }

            KMA_counter1D--;
            return result;
        }

        public List<double> KMA1D(List<double> X)
        {
            List<double> result = new List<double>();

            double[] p22 = new double[X.Count/2];
            for(int i=0;i<X.Count/2;i++)
            {
                result.Add((X[i*2]+X[i*2+1]) / 2);
                p22[i] =(X[2*i]-X[i*2+1])/2 ;
            }
            KMA_counter1D++;
            P2_array.Add(p22);
            return result;
        }

        private void провести1ХiдToolStripMenuItem_Click(object sender, EventArgs e)
        {
            KMAPoints = KMA1D(KMAPoints);
            chart5.Series[0].Points.Clear();
            for (int i = 0; i < KMAPoints.Count; i++)
            {
                chart5.Series[0].Points.AddXY(i, KMAPoints[i]);
            }
        }

        private void вiдновитиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            KMAPoints = KMA1DBack(KMAPoints);
            chart5.Series[0].Points.Clear();
            for (int i = 0; i < KMAPoints.Count; i++)
            {
                chart5.Series[0].Points.AddXY(i, KMAPoints[i]);
            }
        }
        #endregion


        private void маленькепотiмПереробитиНазвуToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void большеЧемМаленькоеToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        public List<double[]> Regularization(List<double[]> points,int Iterrations)
        {
            List<double[]> newList = new List<double[]>(points);

            int mt = points.Count;
            double tmin = newList[0][0];
            double tmax = newList[newList.Count - 1][0];
            double ht = (tmin - tmax) / mt;
            double[] ti = new double[mt-1];//???

            for (int i = 0; i < ti.Length; i++)
            {
                ti[i] = tmin + (i + 0.5) * ht;

            }


            return newList;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            NotRegularGeneration(chart6);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            chart6.Series[0].Points.Clear();
            List<double[]> temp = Regularization(PointsGen,6);

            for (int i = 0; i < temp.Count; i++)
            {
                chart6.Series[0].Points.AddXY(temp[i][0],temp[i][1]);
            }  
        }

        private void завантажитиToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }




        public void CountStatistics(Bitmap bm)
        {
            if (checkBox1.Checked == true)
            {
                richTextBox1.Clear();
                richTextBox1.AppendText("Завантажено зображення " + pictureBox1.Image.Width + "x" + pictureBox1.Image.Height + "\n");
                Statistic st = new Statistic();
                double[] PA = st.P_Average(bm);
                double pa = st.P_Average(bm, true);
                richTextBox1.AppendText("\n");
                richTextBox1.AppendText("P_середне(R) = " + PA[0].ToString() + "\n");
                richTextBox1.AppendText("P_середне(G) = " + PA[1].ToString() + "\n");
                richTextBox1.AppendText("P_середне(B) = " + PA[2].ToString() + "\n");
                richTextBox1.AppendText("P_середне(grey) = " + pa.ToString() + "\n");
                double[] Gammakv = st.Disp_p(bm);
                double GammakvGrey = st.Disp_p(bm, true);
                richTextBox1.AppendText("\n");
                richTextBox1.AppendText("Gamma^2(R) = " + Gammakv[0].ToString() + "\n");
                richTextBox1.AppendText("Gamma^2(G) = " + Gammakv[1].ToString() + "\n");
                richTextBox1.AppendText("Gamma^2(B) = " + Gammakv[2].ToString() + "\n");
                richTextBox1.AppendText("Gamma^2(grey) = " + GammakvGrey.ToString() + "\n");
                double[] E_av = st.E_average(new Bitmap(file), bm);
                double E_av_grey = st.E_average(new Bitmap(file), bm, true);
                richTextBox1.AppendText("\n");
                richTextBox1.AppendText("E_Середне(R) = " + E_av[0].ToString() + "\n");
                richTextBox1.AppendText("E_Середне(G) = " + E_av[1].ToString() + "\n");
                richTextBox1.AppendText("E_Середне(B) = " + E_av[2].ToString() + "\n");
                richTextBox1.AppendText("E_Середне(grey) = " + E_av_grey.ToString() + "\n");

                double[] GME = st.Gamma_E(new Bitmap(file), bm);
                double GME_grey = st.Gamma_E(new Bitmap(file), bm, true);
                richTextBox1.AppendText("\n");
                richTextBox1.AppendText("Gamma_E(R) = " + GME[0].ToString() + "\n");
                richTextBox1.AppendText("Gamma_E(G) = " + GME[1].ToString() + "\n");
                richTextBox1.AppendText("Gamma_E(B) = " + GME[2].ToString() + "\n");
                richTextBox1.AppendText("Gamma_E(grey) = " + GME_grey.ToString() + "\n");

                richTextBox1.AppendText("\n");
                richTextBox1.AppendText("PSNR = " + st.GimmitheholyPSNR(new Bitmap(file), bm).ToString() + "\n");

                //double[] Delta_E = st.Delta_E(new Bitmap(file), bm);
                //double Delta_E_grey = st.Delta_E(new Bitmap(file), bm,true);

                //richTextBox1.AppendText("\n");
                //richTextBox1.AppendText("Delta_E(R) = " + (Delta_E[0]*100).ToString() + "%\n");
                //richTextBox1.AppendText("Delta_E(G) = " + (Delta_E[1]*100).ToString() + "%\n");
                //richTextBox1.AppendText("Delta_E(B) = " + (Delta_E[2]*100).ToString() + "%\n");
                //richTextBox1.AppendText("Delta_E(grey) = " + (Delta_E_grey*100).ToString() + "%\n");

                //if((Delta_E[0] * 100<5)||(Delta_E[1] * 100<5) ||(Delta_E[2] * 100<5) ||(Delta_E_grey * 100<5))
                //{
                //    richTextBox1.AppendText("Змiни не помiтнi оком");
                //}
            }
        }

        private void файлToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        string file;
        private void завантажитиЗображенняToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    file = openFileDialog1.FileName;
                    pictureBox1.Image = new Bitmap(file);
                    this.Text = "Завантажено зображення " + file;

                    Image_dimension.Clear(); ;
                    KMACounter = 0;

                    CountStatistics(new Bitmap(pictureBox1.Image));
                }
            }
            catch
            {
            }
        }

        public  double[,] Matr_Mult1(double[] mas_1, double[] mas_2)
        {
            double[,] result = new double[mas_1.GetLength(0), mas_2.GetLength(0)];
            if (mas_1.GetLength(0) == mas_2.GetLength(0))
            {
                for (int i = 0; i < mas_1.GetLength(0); i++)
                {
                    for (int j = 0; j < mas_2.Length; j++)
                    {
                        for (int k = 0; k < mas_1.Length; k++)
                        {
                            result[i, j] += mas_1[ k] * mas_2[k];
                        }
                    }
                }
            }
            return result;
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
       
        public static UInt32[,] pixel;
        public static Bitmap image;

        
        public void Filtration(double[,] sharpness, double koef)
        {
            ImageProccesing im = new ImageProccesing();
            image = new Bitmap(pictureBox1.Image);
            pixel = new UInt32[image.Height, image.Width];
            for (int y = 0; y < image.Height; y++)
                for (int x = 0; x < image.Width; x++)
                    pixel[y, x] = (UInt32)(image.GetPixel(x, y).ToArgb());

            for(int i=0;i<sharpness.GetLength(0);i++)
            {
                for(int j=0;j<sharpness.GetLength(0);j++)
                {
                    sharpness[i, j] = sharpness[i, j] / koef;
                }

            }

            pixel = im.matrix_filtration(image.Width, image.Height, pixel, sharpness.GetLength(0), sharpness);
            FromPixelToBitmap();
            pictureBox1.Image = image;

        }

        //public void FiltrationVCH(double[,] sharpness, double koef)
        //{
        //    ImageProccesing im = new ImageProccesing();
        //    image = new Bitmap(pictureBox1.Image);
        //    Bitmap prev = new Bitmap(pictureBox1.Image);
        //    pixel = new UInt32[image.Height, image.Width];
        //    for (int y = 0; y < image.Height; y++)
        //        for (int x = 0; x < image.Width; x++)
        //            pixel[y, x] = (UInt32)(image.GetPixel(x, y).ToArgb());

        //    for (int i = 0; i < sharpness.GetLength(0); i++)
        //    {
        //        for (int j = 0; j < sharpness.GetLength(0); j++)
        //        {
        //            sharpness[i, j] = sharpness[i, j] / koef;
        //        }

        //    }

        //    pixel = im.matrix_filtration(image.Width, image.Height, pixel, sharpness.GetLength(0), sharpness);
        //    FromPixelToBitmap();
        //    pictureBox1.Image = im.Difference(prev,image);

        //}


        public void Filtration(double[,] sharpness, double koef,Bitmap image)
        {
            ImageProccesing im = new ImageProccesing();
            pixel = new UInt32[image.Height, image.Width];
            for (int y = 0; y < image.Height; y++)
                for (int x = 0; x < image.Width; x++)
                    pixel[y, x] = (UInt32)(image.GetPixel(x, y).ToArgb());

            for (int i = 0; i < sharpness.GetLength(0); i++)
            {
                for (int j = 0; j < sharpness.GetLength(0); j++)
                {
                    sharpness[i, j] = sharpness[i, j] / koef;
                }

            }

            Bitmap bm = new Bitmap(image);
            pixel = im.matrix_filtration(bm.Width, bm.Height, pixel, sharpness.GetLength(0), sharpness);
            FromPixelToBitmap(bm);
            pictureBox1.Image = bm;

        }


        //преобразование из UINT32 to Bitmap
        public static void FromPixelToBitmap()
        {
            for (int y = 0; y < image.Height; y++)
                for (int x = 0; x < image.Width; x++)
                    image.SetPixel(x, y, Color.FromArgb((int)pixel[y, x]));
        }

        //преобразование из UINT32 to Bitmap
        public static void FromPixelToBitmap(Bitmap img)
        {
            for (int y = 0; y < img.Height; y++)
                for (int x = 0; x < img.Width; x++)
                    img.SetPixel(x, y, Color.FromArgb((int)pixel[y, x]));
        }

        private void контраснийФiльтрS20ToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void testS30ToolStripMenuItem_Click(object sender, EventArgs e)
        {   
        }

        private void розмиттяS40ToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void контраснийS30ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            double[,] sharpness = new double[,] { {1,-6,24,-6,1 }, {-6,36,-144,36,-6 }, {24,-144,576,-144,24 }, { -6, 36, -144, 36, -6 }, { 1, -6, 24, -6, 1 } };
            Filtration(sharpness,196);
        }

        private void зворотнiй40ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            double[,] sharpness = new double[,] { { -1, -76, -230, -76, -1 }, { -76, -5776, -17480, -5776, -76 }, { -230, -17480, 94556, -17480, -230 }, { -76, -5776, -17480, -5776, -76 }, { -1, -76, -230, -76, -1 } };
            Filtration(sharpness, 147456,new Bitmap(pictureBox1.Image));
        }

        private void зворотнiй30ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            double[,] sharpness = new double[,] { {-1,-4,-1 }, {-4,20,-4 }, {-1,-4,-1 } };
            Filtration(sharpness, 36);
        }

        private void s50ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            
        }

        private void зберегтиЗображенняToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "JPeg Image|*.jpg|Bitmap Image|*.bmp|Gif Image|*.gif";
            saveFileDialog1.Title = "Зберегти зображення";
            saveFileDialog1.ShowDialog();
            if (saveFileDialog1.FileName != "")
            {
                System.IO.FileStream fs =
                   (System.IO.FileStream)saveFileDialog1.OpenFile();
                        pictureBox1.Image.Save(fs,System.Drawing.Imaging.ImageFormat.Jpeg);

                fs.Close();
            }
        }

        #region Стабилизатор 1
        public Bitmap stab1(Bitmap sourceBitmap, bool grayscale = false)
        {
            double[,] sharpness = new double[,] { {3.75457E-09,8.93587E-07,5.40282E-06,-7.38748E-05, 5.40282E-06, 8.93587E-07, 3.75457E-09 },
                                                  {8.93587E-07,0.000212674,0.001285871,-0.011758221,0.001285871,0.000212674,8.93587E-07 }, 
                                                  {5.40282E-06,0.001285871, 0.007774658,-0.106305883,0.007774658,0.001285871,5.40282E-06}, 
                                                  {-7.38748E-05,-0.01758221,-0.106305883,1.45356119,-0.106305883,-0.01758221,-7.38748E-05 }, 
                                                  {5.40282E-06,0.001285871, 0.007774658,-0.106305883,0.007774658,0.001285871,5.40282E-06 }, 
                                                  {8.93587E-07,0.000212674,0.001285871,-0.011758221,0.001285871,0.000212674,8.93587E-07  }, 
                                                  {3.75457E-09,8.93587E-07,5.40282E-06,-7.38748E-05, 5.40282E-06, 8.93587E-07, 3.75457E-09 } };
            Bitmap resultBitmap = im.ConvolutionFilter(sourceBitmap,
                                    sharpness, 1.0, 0, grayscale);

            return resultBitmap;
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Bitmap bm = new Bitmap(pictureBox1.Image);
            bm = stab1(bm, false);
            pictureBox1.Image = bm;
            CountStatistics(new Bitmap(pictureBox1.Image));
        }

        #endregion
        #region Стабилизатор 2
        public Bitmap stab2(Bitmap sourceBitmap, bool grayscale = false)
        {
            double[,] sharpness = new double[,] { {1.24562E-08,2.96456E-06,1.159314E-05,-0.000149424,1.159314E-05,2.96456E-06,1.24562E-08 },
                                                  {2.96456E-06,0.000705566,0.003791678,-0.035562919,0.003791678,0.000705566,2.96456E-06 },
                                                  {1.59314E-05,0.003791678,0.020376288,-0.191113331, 0.020376288,0.003791678,1.59314E-05},
                                                  {-0.000149424,-0.035562919,-0.191113391,1.792490633,-0.191113391,-0.035562919, -0.000149424},
                                                  {1.59314E-05,0.003791678,0.020376288,-0.191113331, 0.020376288,0.003791678,1.59314E-05 },
                                                  {2.96456E-06,0.000705566,0.003791678,-0.035562919,0.003791678,0.000705566,2.96456E-06  },
                                                  { 1.24562E-08,2.96456E-06,1.159314E-05,-0.000149424,1.159314E-05,2.96456E-06,1.24562E-08} };
            Bitmap resultBitmap = im.ConvolutionFilter(sourceBitmap,
                                    sharpness, 1.0, 0, grayscale);

            return resultBitmap;
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            Bitmap bm = new Bitmap(pictureBox1.Image);
            bm = stab2(bm, false);
            pictureBox1.Image = bm;
            CountStatistics(new Bitmap(pictureBox1.Image));
        }
        #endregion
        #region Стабилизатор 3
        public Bitmap stab3( Bitmap sourceBitmap, bool grayscale = false)
        {
            double[,] sharpness = new double[,] { {1.6236E-10,4.1165E-08,9.20847E-07,2.14132E-06,-1.8949E-05,2.14132E-06,9.20847E-07,4.1165E-08 ,1.6236E-10},
                                                  {4.1165E-08,1.0437E-05,0.000233473,0.000542915,-0.004804375,0.000542915,0.000233473,1.0437E-05,4.1165E-08 },
                                                  {9.20847E-07,0.000233473,0.000522272,0.012144825,-0.107472272,0.012144825,0.000522272,0.000233473,9.20847E-07 },
                                                  {2.14132E-06,0.000542915,0.012144825,0.028241375,-0.249914233,0.028241375,0.012144825,0.000542915,2.14132E-06 },
                                                  {-1.8949E-05,-0.004804375,-0.107472272,-0.249914233,2.211546853,-0.249914233,-0.107472272,-0.004804375,-1.8949E-05 },
                                                  {2.14132E-06,0.000542915,0.012144825,0.028241375,-0.249914233,0.028241375,0.012144825,0.000542915,2.14132E-06  },
                                                  {9.20847E-07,0.000233473,0.000522272,0.012144825,-0.107472272,0.012144825,0.000522272,0.000233473,9.20847E-07 },
                                                  {4.1165E-08,1.0437E-05,0.000233473,0.000542915,-0.004804375,0.000542915,0.000233473,1.0437E-05,4.1165E-08 },
                                                  {1.6236E-10,4.1165E-08,9.20847E-07,2.14132E-06,-1.8949E-05,2.14132E-06,9.20847E-07,4.1165E-08 ,1.6236E-10 } };
            Bitmap resultBitmap = im.ConvolutionFilter(sourceBitmap,
                                    sharpness, 1.0, 0, grayscale);

            return resultBitmap;
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            Bitmap bm = new Bitmap(pictureBox1.Image);
            bm = stab3(bm, false);
            pictureBox1.Image = bm;
            CountStatistics(new Bitmap(pictureBox1.Image));
        }
        #endregion
        #region Стабилизатор 4
        public Bitmap stab4(Bitmap sourceBitmap, bool grayscale = false)
        {
            double[,] sharpness = new double[,] { {5.26177E-10,1.32248E-07,3.7676E-06,4.92362E-06,-3.85865E-05,4.92362E-06,3.7676E-06,1.32248E-07,5.26177E-10},
                                                  {1.32248E-07,3.32391E-05,0.000695605,0.001237494,-0.009698272,0.001237494,0.000695605,3.32391E-05, 1.32248E-07},
                                                  {3.7676E-06,0.000695605,0.0145571357,0.025897446,-0.202958992,0.025897446,0.0145571357,0.000695605,3.7676E-06},
                                                  {4.92362E-06,0.001237494,0.025897446,0.046072025,-0.361067725,0.046072025, 0.025897446,0.001237494,4.92362E-06 },
                                                  {-3.85865E-05,-0.009698272,-0.202958992,-0.361067725,2.829697678,-0.361067725,-0.202958992,-0.009698272,-3.85865E-05 },
                                                  {4.92362E-06,0.001237494,0.025897446,0.046072025,-0.361067725,0.046072025, 0.025897446,0.001237494,4.92362E-06  },
                                                  {3.7676E-06,0.000695605,0.0145571357,0.025897446,-0.202958992,0.025897446,0.0145571357,0.000695605,3.7676E-06},
                                                  {1.32248E-07,3.32391E-05,0.000695605,0.001237494,-0.009698272,0.001237494,0.000695605,3.32391E-05, 1.32248E-07 },
                                                  {5.26177E-10,1.32248E-07,3.7676E-06,4.92362E-06,-3.85865E-05,4.92362E-06,3.7676E-06,1.32248E-07,5.26177E-10 } };
            Bitmap resultBitmap = im.ConvolutionFilter(sourceBitmap,
                                    sharpness, 1.0, 0, grayscale);

            return resultBitmap;
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            Bitmap bm = new Bitmap(pictureBox1.Image);
            bm = stab4(bm, false);
            pictureBox1.Image = bm;
            CountStatistics(new Bitmap(pictureBox1.Image));
        }
        #endregion

        private void гамма0ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            double[,] sharpness = new double[,] { {1,8,-74,8,1 }, 
                                                  {8,64,-592,64,8 }, 
                                                  {-74,-592,5476,-592,-74 }, 
                                                  {8,64,-592,64,8  }, 
                                                  { 1,8,-74,8,1 } };
            Filtration(sharpness, 3136);
        }

        public  Bitmap K50(Bitmap sourceBitmap, bool grayscale = false)
        {
            double del = 160574;
            double a = -609.0 / del;
            double b = -14144.0 / del;
            double c = 73080.0 / del;
            double d = -202800.0 / del;
            double e = 449520.0 / del;


            double[,] bb= new double[,]
            {
                { a*a, b*a, c*a, d*a, e*a, d*a, c*a, b*a,a*a },
                { a*b, b*b, c*b, d*b, e*b, d*b, c*b, b*b,a*b },
                { a*c, b*c, c*c, d*c, e*c, d*c, c*c, b*c,a*c },
                { a*d, b*d, c*d, d*d, e*d, d*d, c*d, b*d,a*d },
                { a*e, b*e, c*e, d*e, e*e, d*e, c*e, b*e,a*e },
                { a*d, b*d, c*d, d*d, e*d, d*d, c*d, b*d,a*d },
                { a*c, b*c, c*c, d*c, e*c, d*c, c*c, b*c,a*c },
                { a*b, b*b, c*b, d*b, e*b, d*b, c*b, b*b,a*b },
                { a*a, b*a, c*a, d*a, e*a, d*a, c*a, b*a,a*a}

            }
            ;

            Bitmap resultBitmap = im.ConvolutionFilter(sourceBitmap,
                                    bb, 1.0, 0, grayscale);

            return resultBitmap;
        }

        private void s50ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Bitmap bm = new Bitmap(pictureBox1.Image);
            bm = K50(bm, false);
            pictureBox1.Image = bm;
            CountStatistics(new Bitmap(pictureBox1.Image));
        }

        private void s20ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            double[,] sharpness = new double[,] { { 1, -8, 48, -8, 1 }, { -8, 64, -384, 64, -8 }, { 48, -384, 2304, -384, 48 }, { -8, 64, -384, 64, -8 }, { 1, -8, 48, -8, 1 } };
            Filtration(sharpness, 1156);
            CountStatistics(new Bitmap(pictureBox1.Image));
        }

        private void s30ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            double[,] sharpness = new double[,] { { 1, -6, 24, -6, 1 }, { -6, 36, -144, 36, -6 }, { 24, -144, 576, -144, 24 }, { -6, 36, -144, 36, -6 }, { 1, -6, 24, -6, 1 } };
            Filtration(sharpness, 196);
            CountStatistics(new Bitmap(pictureBox1.Image));
        }

        private void s30ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            double[,] sharpness = new double[,] { { 1, 6, 1 }, { 6, 36, 6 }, { 1, 6, 1 } };
            Filtration(sharpness, 64);
            CountStatistics(new Bitmap(pictureBox1.Image));
        }

        private void s40ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            double[,] sharpness = new double[,] { { 1, 76, 230, 76, 1 }, { 76, 5776, 17480, 5776, 76 }, { 230, 17480, 52900, 17480, 230 }, { 76, 5776, 17480, 5776, 76 }, { 1, 76, 230, 76, 1 } };
            Filtration(sharpness, 147456);
            CountStatistics(new Bitmap(pictureBox1.Image));
        }

        private void s50ToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            double[,] sharpness = new double[,] { { 1, 26, 66, 26, 1 }, { 26, 676, 1716, 676, 26 }, { 66, 1716, 4356, 1716, 66 }, { 26, 676, 1716, 676, 26 }, { 1, 26, 66, 26, 1 } };
            Filtration(sharpness, 14400);
            CountStatistics(new Bitmap(pictureBox1.Image));
        }


        ImageProccesing im = new ImageProccesing();

        #region Високочастотний С 2.0
        public Bitmap H20(Bitmap sourceBitmap, bool grayscale = false)
        {
            
            double a = 1.0 / 64;
            double[,] g= new double[,]
            {  {-1*a,-6*a,-1*a },
                { -6*a,28*a,-6*a},
                { -1*a,-6*a,-1*a} }
            ;

            Bitmap resultBitmap = im.ConvolutionFilter(sourceBitmap,g, 1.0, 0, grayscale,true);

            return resultBitmap;
        }

        private void s20ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Bitmap bm = new Bitmap(pictureBox1.Image);
            bm = H20(bm, false);
            pictureBox1.Image = bm;
            CountStatistics(new Bitmap(pictureBox1.Image));
        }
        #endregion
        private void високочастотнiToolStripMenuItem_Click(object sender, EventArgs e)
        { 
        }
        #region Високочастотний С 3.0
        public  Bitmap H30( Bitmap sourceBitmap, bool grayscale = false)
        {
            double a = 1.0 / 36;
           double[,] b= new double[,]
            { {-1*a,-4*a,-1*a },
                { -4*a,20*a,-4*a},
                { -1*a,-4*a,-1*a} }
            ;

            Bitmap resultBitmap = im.ConvolutionFilter(sourceBitmap,
                                   b, 1.0, 0, grayscale,true);

            return resultBitmap;
        }

        private void s30ToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            Bitmap bm = new Bitmap(pictureBox1.Image);
            bm = H30(bm,false);
            pictureBox1.Image = bm;
            CountStatistics(new Bitmap(pictureBox1.Image));
        }
        #endregion
        #region  Високочастотний С 4.0
        public Bitmap H40(Bitmap sourceBitmap, bool grayscale = false)
        {
            double a = 147456.0;
            double[,] b= new double[,]
            {
                    {-1.0/a,   -76.0/a,   -230.0/a,   -76.0/a,   -1.0/a },
                    {-76.0/a,  -5776.0/a, -17480.0/a, -5776.0/a, -76.0/a },
                    {-230.0/a, -17480.0/a, 94556.0/a, -17480.0/a, -230.0/a, },
                     {-76.0/a, -5776.0/a, -17480.0/a, -5776.0/a,  -76.0/a },
                     {-1.0/a,  -76.0/a,   -230.0/a,   -76.0/a,    -1.0/a }
            }
            ;

            Bitmap resultBitmap = im.ConvolutionFilter(sourceBitmap,
                                    b, 1.0, 0, grayscale,true);
            return resultBitmap;
        }

        private void s40ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Bitmap bm = new Bitmap(pictureBox1.Image);
            bm = H40(bm, false);
            pictureBox1.Image = bm;
            CountStatistics(new Bitmap(pictureBox1.Image));
        }
        #endregion
        #region Високочастотний С 5.0
        public Bitmap H50(Bitmap sourceBitmap, bool grayscale = false)
        {
            double a = 1.0 / 14400;
            double[,] b= new double[,]
            {
                    {-1*a,   -26*a,    -66*a,    -26*a,   -1*a },
                    {-26*a,  -676*a,   -1716*a,  -676*a,  -26*a },
                    {-66*a,  -1716*a,  10044*a,  -1716*a, -66*a },
                     {-26*a, -676*a,   -1716*a,  -676*a,  -26*a },
                     {-1*a,  -26*a,    -66*a,    -26*a,   -1*a }
            }
            ;
            Bitmap resultBitmap = im.ConvolutionFilter(sourceBitmap,
                                   b, 1.0, 0, grayscale,true);

            return resultBitmap;
        }

        private void s50ToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            Bitmap bm = new Bitmap(pictureBox1.Image);
            bm = H50(bm, false);
            pictureBox1.Image = bm;
            CountStatistics(new Bitmap(pictureBox1.Image));
        }
        #endregion

        //Завантаження початкового зображення
        private void вiдмiнитиВсiДiiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = new Bitmap(file);
            CountStatistics(new Bitmap(pictureBox1.Image));
        }

        public Bitmap L20( Bitmap sourceBitmap, bool grayscale = false)
        {
            double[,] a= new double[,]
                { { 1*(1.0/64), 6*(1.0/64), 1*(1.0/64)  },
                  { 6*(1.0/64),  36*(1.0/64), 6*(1.0/64)  },
                  { 1*(1.0/64), 6*(1.0/64), 1*(1.0/64)  }, };

            Bitmap resultBitmap = im.ConvolutionFilter(sourceBitmap,
                                    a, 1.0, 0, grayscale);

            return resultBitmap;
        }
        private void s20ToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            Bitmap bm = new Bitmap(pictureBox1.Image);
            bm =L20(bm, false);
            pictureBox1.Image = bm;
            CountStatistics(new Bitmap(pictureBox1.Image));
        }

        public  Bitmap K40( Bitmap sourceBitmap, bool grayscale = false)
        {
            double a = -0.0067154;
            double b = -0.0492947;
            double c = 0.25787256;
            double d = -0.80938034;
            double e = 2.20221768;

            double[,] gg= new double[,]
            {
                { a*a, b*a, c*a, d*a, e*a, d*a, c*a, b*a,a*a },
                { a*b, b*b, c*b, d*b, e*b, d*b, c*b, b*b,a*b },
                { a*c, b*c, c*c, d*c, e*c, d*c, c*c, b*c,a*c },
                { a*d, b*d, c*d, d*d, e*d, d*d, c*d, b*d,a*d },
                { a*e, b*e, c*e, d*e, e*e, d*e, c*e, b*e,a*e },
                { a*d, b*d, c*d, d*d, e*d, d*d, c*d, b*d,a*d },
                { a*c, b*c, c*c, d*c, e*c, d*c, c*c, b*c,a*c },
                { a*b, b*b, c*b, d*b, e*b, d*b, c*b, b*b,a*b },
                { a*a, b*a, c*a, d*a, e*a, d*a, c*a, b*a,a*a}

            }
            ;

            Bitmap resultBitmap = im.ConvolutionFilter(sourceBitmap,
                                   gg, 1.0, 0, grayscale);

            return resultBitmap;
        }

        private void s40ToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            Bitmap bm = new Bitmap(pictureBox1.Image);
            bm = K40(bm, false);
            pictureBox1.Image = bm;
        }

        private void тестToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }


        private void роботаЗЗображеннямиToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void контраснiToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void показатиГiстограмиНасиченостейToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Gistograms gist = new Gistograms();
            gist.Show();
            gist.ShowGistogramm(new Bitmap(pictureBox1.Image));
        }

        private void стабiлiзаториToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                CountStatistics(new Bitmap(pictureBox1.Image));
            }
            catch { }
        }

        public Bitmap HARA20(Bitmap sourceBitmap, bool grayscale = false)
        {
            double[,] a = new double[,]
                { {0.25,0.25 }, {0.25,0.25 } };

            Bitmap resultBitmap = im.ConvolutionFilter(sourceBitmap,
                                    a, 1.0, 0, grayscale,true);

            return resultBitmap;
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Bitmap bm = new Bitmap(pictureBox1.Image);
            bm = HARA20(bm, false);
            pictureBox1.Image = bm;
        }

        private void зменшенняВдвiчiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap bm = new Bitmap(pictureBox1.Image);
            pictureBox1.Image = im.Decrease_Image(bm);
        }

        private void вiдмiнитиОстаннюДiюToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }



        private void збiльшитиХ2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = im.Subdivision(new Bitmap(pictureBox1.Image));
        }
        

        private void testButtonToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        
        #region KMA

        List<Bitmap[]> Image_dimension = new List<Bitmap[]>();
        int KMACounter = 0;

        private void kMAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(KMACounter==0)
            {
                Bitmap bm = new Bitmap(pictureBox1.Image);
                Bitmap p1;
                Bitmap p2;
                Bitmap p3;
                Bitmap p4;

                p1 = asd(bm, new double[] { 1.0 / 4, 1.0 / 4, 1.0 / 4, 1.0 / 4 });
                p2 = asd(bm, new double[] { 1.0 / 4, 1.0 / 4, -1.0 / 4, -1.0 / 4 });
                p3 = asd(bm, new double[] { 1.0 / 4, -1.0 / 4, 1.0 / 4, -1.0 / 4 });
                p4 = asd(bm, new double[] { 1.0 / 4, -1.0 / 4, -1.0 / 4, 1.0 / 4 });

                Image_dimension.Add(new Bitmap[] {p1,p2,p3,p4 });

                pictureBox1.Image = im.UniteBitmap(Image_dimension[KMACounter],bm);
                KMACounter++;
            }
            else
            {
                Bitmap bm = Image_dimension[KMACounter-1][0];
                Bitmap p1;
                Bitmap p2;
                Bitmap p3;
                Bitmap p4;

                p1 = asd(bm, new double[] { 1.0 / 4, 1.0 / 4, 1.0 / 4, 1.0 / 4 });
                p2 = asd(bm, new double[] { 1.0 / 4, 1.0 / 4, -1.0 / 4, -1.0 / 4 });
                p3 = asd(bm, new double[] { 1.0 / 4, -1.0 / 4, 1.0 / 4, -1.0 / 4 });
                p4 = asd(bm, new double[] { 1.0 / 4, -1.0 / 4, -1.0 / 4, 1.0 / 4 });

                Image_dimension.Add(new Bitmap[] { p1, p2, p3, p4 });

                pictureBox1.Image = im.UniteBitmap(Image_dimension[KMACounter], new Bitmap(pictureBox1.Image));

                KMACounter++;
            }
        }

        public Bitmap asd(Bitmap a, double[] m)
        {

            Bitmap b = new Bitmap(a.Width / 2, a.Height / 2);
            for (int j = 0; j < b.Width; j++)
            {
                for (int i = 0; i < b.Height; i++)
                {
                    Color c = Color.FromArgb(
                        255,
                       (byte)(m[0] * a.GetPixel(2 * j, 2 * i).R + m[1] * a.GetPixel((2 * j) + 1, 2 * i).R + m[2] * a.GetPixel(2 * j, (2 * i) + 1).R + m[3] * a.GetPixel((2 * j) + 1, (2 * i) + 1).R),
                       (byte)(m[0] * a.GetPixel(2 * j, 2 * i).G + m[1] * a.GetPixel((2 * j) + 1, 2 * i).G + m[2] * a.GetPixel(2 * j, (2 * i) + 1).G + m[3] * a.GetPixel((2 * j) + 1, (2 * i) + 1).G),
                        (byte)(m[0] * a.GetPixel(2 * j, 2 * i).B + m[1] * a.GetPixel((2 * j) + 1, 2 * i).B + m[2] * a.GetPixel(2 * j, (2 * i) + 1).B + m[3] * a.GetPixel((2 * j) + 1, (2 * i) + 1).B)
                        );
                    b.SetPixel(j, i, c);
                }
            }
            return b;

        }
        

        public Bitmap Kmazv(Bitmap p11, Bitmap p22, Bitmap p33, Bitmap p44)
        {
            Bitmap b = new Bitmap(p11.Width * 2, p11.Height * 2);
            for (int j = 0; j < b.Width / 2; j++)
            {
                for (int i = 0; i < b.Height / 2; i++)
                {


                    Color p1 = Color.FromArgb(255,
                       (byte)(p11.GetPixel(j, i).R + p22.GetPixel(j, i).R + p33.GetPixel(j, i).R + p44.GetPixel(j, i).R),
                     (byte)(p11.GetPixel(j, i).G + p22.GetPixel(j, i).G + p33.GetPixel(j, i).G + p44.GetPixel(j, i).G),
                     (byte)(p11.GetPixel(j, i).B + p22.GetPixel(j, i).B + p33.GetPixel(j, i).B + p44.GetPixel(j, i).B)
                       );
                    Color p2 = Color.FromArgb(255,
                       (byte)(p11.GetPixel(j, i).R + p22.GetPixel(j, i).R - p33.GetPixel(j, i).R - p44.GetPixel(j, i).R),
                       (byte)(p11.GetPixel(j, i).G + p22.GetPixel(j, i).G - p33.GetPixel(j, i).G - p44.GetPixel(j, i).G),
                       (byte)(p11.GetPixel(j, i).B + p22.GetPixel(j, i).B - p33.GetPixel(j, i).B - p44.GetPixel(j, i).B)
                       );
                    Color p3 = Color.FromArgb(255,
                       (byte)(p11.GetPixel(j, i).R - p22.GetPixel(j, i).R + p33.GetPixel(j, i).R - p44.GetPixel(j, i).R),
                       (byte)(p11.GetPixel(j, i).G - p22.GetPixel(j, i).G + p33.GetPixel(j, i).G - p44.GetPixel(j, i).G),
                       (byte)(p11.GetPixel(j, i).B - p22.GetPixel(j, i).B + p33.GetPixel(j, i).B - p44.GetPixel(j, i).B)
                       );
                    Color p4 = Color.FromArgb(255,
                      (byte)(p11.GetPixel(j, i).R - p22.GetPixel(j, i).R - p33.GetPixel(j, i).R + p44.GetPixel(j, i).R),
                      (byte)(p11.GetPixel(j, i).G - p22.GetPixel(j, i).G - p33.GetPixel(j, i).G + p44.GetPixel(j, i).G),
                      (byte)(p11.GetPixel(j, i).B - p22.GetPixel(j, i).B - p33.GetPixel(j, i).B + p44.GetPixel(j, i).B)
                       );


                    b.SetPixel(2 * j, 2 * i, p1);
                    b.SetPixel((2 * j) + 1, 2 * i, p2);
                    b.SetPixel(2 * j, (2 * i) + 1, p3);
                    b.SetPixel((2 * j) + 1, (2 * i) + 1, p4);
                }
            }
            return b;
        }

        private void зворотнеToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Bitmap[] pg = Image_dimension[KMACounter - 1];

            if (checkBox2.Checked == true)
            {
                KMA kmaform = new KMA();
                kmaform.Show();
                kmaform.LoadIm(pg[0], pg[1], pg[2], pg[3]);
            }


            Bitmap s = Kmazv(pg[0], pg[1], pg[2], pg[3]);
            try
            {
                Image_dimension[KMACounter - 2][0] = s;
            }
            catch { }
            pictureBox1.Image = im.UniteBitmap(s, new Bitmap(pictureBox1.Image));
            KMACounter--;

        }
        #endregion

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        //List<double> tst;
        //bool once = true;
        //private void testToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    if(once)
        //    {
        //    double[] test = new double[] { 220, 211, 212, 218, 217, 214, 210, 202 };
        //    tst = test.ToList();
        //        once = false;
        //    }
            
        //    tst = KMA1D(tst);
        //}

        //private void backToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    tst = KMA1DBack(tst);
        //}

        private void кМАToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }



        private void комбiнованийФiльтрToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = im.ComboFilter(new Bitmap(pictureBox1.Image));
        }
        

        private void s20ToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            Statistic sc = new Statistic();
            List<PointF> vich = sc.CON(Generated_points, new double[] { -1.0 / 8, 1.0 / 4, -1.0 / 8 });
            chart5.Series[1].Points.Clear();
            for (int k = 0; k < vich.Count; k++)
            {
                chart5.Series[1].Points.AddXY(k * 0.1, (double)vich[k].Y);
            }
        }

        private void chart5_Click(object sender, EventArgs e)
        {

        }

        private void s30ToolStripMenuItem4_Click(object sender, EventArgs e)
        {

            Statistic sc = new Statistic();
            List<PointF> vich = sc.CON(Generated_points, new double[] { 1.0 / 6, 4.0 / 6, 1.0 / 6 });
            chart5.Series[1].Points.Clear();
            for (int k = 0; k < vich.Count; k++)
            {
                chart5.Series[1].Points.AddXY(k * 0.1, (double)Generated_points[k].Y-(double)vich[k].Y);
            }
        }

        private void s40ToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            Statistic sc = new Statistic();
            List<PointF> vich = sc.CON(Generated_points, new double[] { -1.0 / 384, -76.0 / 384, 154.0 / 384, -76.0 / 384, -1.0 / 384 });
            chart5.Series[1].Points.Clear();
            for (int k = 0; k < vich.Count; k++)
            {
                chart5.Series[1].Points.AddXY(k * 0.1, (double)vich[k].Y);
            }
        }

        private void s50ToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            Statistic sc = new Statistic();
            List<PointF> vich = sc.CON(Generated_points, new double[] { -1.0 / 120, -26.0 / 120, 54.0 / 120, -26.0 / 120, -1.0 / 120 });
            chart5.Series[1].Points.Clear();
            for (int k = 0; k < vich.Count; k++)
            {
                chart5.Series[1].Points.AddXY(k * 0.1, (double)vich[k].Y);
            }
        }

        private void s20ToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            Statistic sc = new Statistic();
            List<PointF> vich = sc.CON(Generated_points, new double[] { 1.0 / 8, 3.0 / 4, 1.0 / 8 });
            chart5.Series[1].Points.Clear();
            for (int k = 0; k < vich.Count; k++)
            {
                chart5.Series[1].Points.AddXY(k * 0.1, (double)vich[k].Y);
            }
        }

        private void s30ToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            
            Statistic sc = new Statistic();
            List<PointF> vich = sc.CON(Generated_points, new double[] { 1.0 / 6, 4.0 / 6, 1.0 / 6 });
            chart5.Series[1].Points.Clear();
            for (int k = 0; k < vich.Count; k++)
            {
                chart5.Series[1].Points.AddXY(k * 0.1, (double)vich[k].Y);
            }
        }

        private void s40ToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            
            Statistic sc = new Statistic();
            List<PointF> vich = sc.CON(Generated_points, new double[] { 1.0 / 384, 76.0 / 384, 230.0 / 384, 76.0 / 384, 1.0 / 384 });
            chart5.Series[1].Points.Clear();
            for (int k = 0; k < vich.Count; k++)
            {
                chart5.Series[1].Points.AddXY(k * 0.1, (double)vich[k].Y);
            }
        }

        private void s50ToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            Statistic sc = new Statistic();
            List<PointF> vich = sc.CON(Generated_points, new double[] { 1.0 / 120, 26.0 / 120, 66.0 / 120, 26.0 / 120, 1.0 / 120 });
            chart5.Series[1].Points.Clear();
            for (int k = 0; k < vich.Count; k++)
            {
                chart5.Series[1].Points.AddXY(k * 0.1, (double)vich[k].Y);
            }
        }

        private void s20ToolStripMenuItem6_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = im.Subdiv2D(new Bitmap(pictureBox1.Image), new double[] { 1, 6, 1 }, new double[] { 0, 4, 4 },8);
        }

        private void s21ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = im.Subdiv2D(new Bitmap(pictureBox1.Image), new double[] { -1, 2,46,2, -1 }, new double[] { 0, -4,28,28, -4 }, 48);
        }

        private void s22ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = im.Subdiv2D(new Bitmap(pictureBox1.Image), new double[] {1,-4,-5,304,-5,-4,1 }, new double[] {0,4,-36,176,176,-36,4 }, 288);
        }

        private void s30ToolStripMenuItem6_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = im.Subdiv2D(new Bitmap(pictureBox1.Image), new double[] {1,23,23,1  }, new double[] {0,8,32,8 },48 );
        }


        private void s31ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = im.Subdiv2D(new Bitmap(pictureBox1.Image), new double[] {-5,-81,662,662,-81,-5 }, new double[] {0,-40,112,1008,112,-40 },1152 );
        }

        private void s32ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = im.Subdiv2D(new Bitmap(pictureBox1.Image), new double[] {47,653,-6849,33797,33797,-6849,653,47  }, new double[] { 0,376,-1920,1992,54400,1992,-1920,376 }, 55296);
        }

        private void s40ToolStripMenuItem6_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = im.Subdiv2D(new Bitmap(pictureBox1.Image), new double[] {1,76,230,76,1 }, new double[] {0,16,176,176,16  }, 384);
        }

        private void s41ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = im.Subdiv2D(new Bitmap(pictureBox1.Image), new double[] {-1,-70,225,1228,225,-7,-1  }, new double[] {0,-16,-80,864,864,-80,-16},1536 );
        }

        private void s42ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = im.Subdiv2D(new Bitmap(pictureBox1.Image), new double[] { 13,876,-5084,8404,83742,8404,-5084,876,13 }, new double[] {0,208,496,-10416,55792,55792,-10416,496,208  },92160 );
        }

        private void s50ToolStripMenuItem6_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = im.Subdiv2D(new Bitmap(pictureBox1.Image), new double[] { 1,237,1682,1682,237,1}, new double[] { 0,32,832,2112,832,32 },3840);
        }

        private void testToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

