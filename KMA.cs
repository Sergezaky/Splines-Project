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
    public partial class KMA : Form
    {
        public KMA()
        {
            InitializeComponent();
        }

        public void LoadIm(Bitmap p1,Bitmap p2,Bitmap p3,Bitmap p4)
        {
            pictureBox1.Image = p1;
            pictureBox2.Image = p2;
            pictureBox3.Image = p3;
            pictureBox4.Image = p4;
        }

       

        private void KMA_Load(object sender, EventArgs e)
        {

        }
    }
}
