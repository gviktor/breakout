using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace breakout
{
    public partial class Form1 : Form
    {
            bool balraMegy;
            bool jobbraMegy;
            int sebesseg = 10;
            int labdaX = 5;
            int labdaY = 5;
            int pontszam = 0;
            private Random vel = new Random();
    public Form1()
        {
            InitializeComponent();
            foreach (Control vezerlo in this.Controls)
            {
                if (vezerlo is PictureBox && (string)vezerlo.Tag == "tegla")
                {
                    Color velSzin = Color.FromArgb(vel.Next(256), vel.Next(256), vel.Next(256));
                    vezerlo.BackColor = velSzin;
                   
                }
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A && jatekos.Left>0)
            {
                balraMegy = true;
            }
            if (e.KeyCode == Keys.D && jatekos.Left <920)
            {
                jobbraMegy = true;
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A && jatekos.Left > 0)
            {
                balraMegy = false;
            }
            if (e.KeyCode == Keys.D && jatekos.Left < 920)
            {
                jobbraMegy = false;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = pontszam.ToString();
            labda.Left += labdaX;
            labda.Top += labdaY;
            if (balraMegy) jatekos.Left -= sebesseg;
            if (jobbraMegy) jatekos.Left += sebesseg;
            if (jatekos.Left < 1) balraMegy = false;
            else if (jatekos.Left >900) jobbraMegy = false;
            if (labda.Left < 0 || labda.Left > 900) labdaX *= -1;
            if (labda.Top < 0 || labda.Bounds.IntersectsWith(jatekos.Bounds)) labdaY *= -1;
            // ütközés a téglákkal
            foreach (Control vezerlo in this.Controls)
            {
                if (vezerlo is PictureBox && (string)vezerlo.Tag == "tegla")
                {
                    if (labda.Bounds.IntersectsWith(vezerlo.Bounds))
                    {
                        this.Controls.Remove(vezerlo);
                        labdaY *= -1;
                        pontszam++;
                    }

                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void Form1_Move(object sender, EventArgs e)
        {
          
        }
    }
}
