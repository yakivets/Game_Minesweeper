using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace saper_22
{
    public partial class Form1 : Form
    {
        byte i, j, k, x, y, x1, y1;
        Random rnd = new Random();
        bool f, flag;

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        Button[,] b;
        byte[,] w;
        bool[,] q;

       

        private void b_Click(object sender, MouseEventArgs e)
        {  if (BackColor == Color.Red) return;
            for (i = 0; i < x; i++)
            {
                for (j = 0; j < y; j++)
                {
                    if (sender == b[i, j])
                    {   
                        if (e.Button == MouseButtons.Right)
                        {
                            b[i, j].Text = (b[i, j].Text == "") ? "F" : "";
                            return;
                        }
                        if (b[i, j].Text == "F") return;
                        b[i, j].Enabled = false; b[i, j].BackColor = Color.White;
                        if (w[i, j] == 10) { BackColor = Color.Red; return; }
                        if (w[i,j]>0) { b[i, j].Text = "" + w[i, j]; return; }
                        pustota(i,j); 
                        return;
                    }
                }
            }
        }

        void pustota(byte i8, byte j8)
        {
            if (j8 > 0) {   // up
                for (j = (byte)(j8 - 1); j >=0 && j<y; j--)
                {
                    b[i8, j].Enabled = false; b[i8, j].BackColor = Color.White;
                    if (w[i8, j] > 0) { b[i8, j].Text = "" + w[i8, j]; break; }
                    else q[i8, j] = true;
                }
             }
            if (j8 <y-1)  //down
            {
                for (j = (byte)(j8 + 1); j <y; j++)
                {
                    b[i8, j].Enabled = false; b[i8, j].BackColor = Color.White;
                    if (w[i8, j] > 0) { b[i8, j].Text = "" + w[i8, j]; break; }
                    else q[i8, j] = true;
                }
            }
            if (i8 > 0)
            {   // left
                for (i = (byte)(i8 - 1); i >=0; i--)
                {
                    b[i, j8].Enabled = false; b[i, j8].BackColor = Color.White;
                    if (w[i, j8] > 0) { b[i, j8].Text = "" + w[i, j8]; break; }
                    else q[i, j8] = true;
                }
            }
            if (i8 <x-1)
            {   // right
                for (i = (byte)(i8 + 1); i <x; i++)
                {
                    b[i, j8].Enabled = false; b[i, j8].BackColor = Color.White;
                    if (w[i, j8] > 0) { b[i, j8].Text = "" + w[i, j8]; break; }
                    else q[i, j8] = true;
                }
            }
            if (i8 < x - 1 && j8>0)
            {   // right-up
                for (i = 1; i < 255; i++)
                {   if (i8 + i > x - 1 || j8 - i < 0) break;
                    b[i8+i, j8-i].Enabled = false; b[i8+i, j8-i].BackColor = Color.White;
                    if (w[i8+i, j8-i] > 0) { b[i8+i, j8-i].Text = "" + w[i8+i, j8-i]; break; }
                    else q[i8+i, j8-i] = true;
                }
            }
            if (i8 >0 && j8 <y-1)
            {   // left-down
                for (i = 1; i < 255; i++)
                {
                    if (i8 - i <0 || j8 + i >y-1) break;
                    b[i8 - i, j8 + i].Enabled = false; b[i8 - i, j8 + i].BackColor = Color.White;
                    if (w[i8 - i, j8 + i] > 0) { b[i8 - i, j8 + i].Text = "" + w[i8 - i, j8 + i]; break; }
                    else q[i8 - i, j8 + i] = true;
                }
            }
            if (i8 > 0 && j8 < y - 1)
            {   // left-up
                for (i = 1; i < 255; i++)
                {
                    if (i8 - i <0  || j8-i<0) break;
                    b[i8 - i, j8 - i].Enabled = false; b[i8 - i, j8 - i].BackColor = Color.White;
                    if (w[i8 - i, j8 - i] > 0) { b[i8 - i, j8 - i].Text = "" + w[i8 - i, j8 - i]; break; }
                    else q[i8 - i, j8 - i] = true;
                }
            }
        }

      
        private void Button1_Click(object sender, EventArgs e)
        {
            BackColor = Color.White;
            panel1.Visible = false;
            Application.DoEvents();
            panel1.Controls.Clear();
            b = null; w = null; q = null;
            x = (byte)numericUpDown1.Value; y = (byte)numericUpDown2.Value;
            b = new Button[x, y];  w = new byte[x, y]; q = new bool[x, y];
            panel1.Width = 10 + x * 21; panel1.Height = 10 + y * 21;
            for (i = 0; i < x; i++)
            {
                for (j = 0; j < y; j++)
                {
                    b[i, j] = new Button(); b[i, j].BackColor = Color.Yellow;
                    b[i, j].SetBounds(5 + i * 21, 5 + j * 21, 20, 20);
                    panel1.Controls.Add(b[i, j]);
                    b[i, j].MouseDown += b_Click;
                   
                    w[i, j] = 0; q[i, j] = false;
                }
            }

            for (i = 0; i < x * y * (byte)numericUpDown3.Value / 100; i++)
            {
               A1:  x1 = (byte)rnd.Next(x); y1 = (byte)rnd.Next(y);
                if (w[x1, y1] == 10) goto A1;
                w[x1, y1] = 10;
               
                if (x1 < x - 1 && y1 > 0 && w[x1 + 1, y1 - 1] < 10) w[x1 + 1, y1 - 1]++;
                if (x1 < x - 1  && w[x1 + 1, y1 ] < 10) w[x1 + 1, y1 ]++;
                if (x1 < x - 1 && y1 <y-1 && w[x1 + 1, y1 + 1] < 10) w[x1 + 1, y1 + 1]++;

                if (y1 < y - 1 && w[x1, y1 + 1] < 10) w[x1, y1 + 1]++;
                if (x1 >0 && y1 < y - 1 && w[x1 - 1, y1 + 1] < 10) w[x1 - 1, y1 + 1]++;
                if (x1 >0 &&  w[x1 - 1, y1 ] < 10) w[x1 - 1, y1]++;
                if (x1 >0 && y1 >0 && w[x1 - 1, y1 - 1] < 10) w[x1 - 1, y1 - 1]++;
                if (y1 >0 && w[x1, y1 - 1] < 10) w[x1 , y1 - 1]++;

            }

            panel1.Visible = true;

        }

       
        
        public Form1()
        {
            InitializeComponent();
        }
    }
}
