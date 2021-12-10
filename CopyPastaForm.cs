using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CopyPasta
{
    public partial class CopyPastaForm : UserControl
    {
        private int t1 = 0;
        public bool isSelected = false;
       
        public CopyPastaForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text != "")
            {
                System.Windows.Forms.Clipboard.SetText(textBox1.Text);
                timer1.Start();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            button1.Text = "Copied!";
            t1 += 1;
            if(t1 >= 150)
            {
                button1.Text = "Copy";
                timer1.Stop();
                t1 = 0;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked)
            {
                textBox1.ReadOnly = true;
                panel1.BackColor = Color.Red;
            }
            else
            {
                textBox1.ReadOnly = false;               
                panel1.BackColor = Color.Transparent;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox2.Checked)
            {
                textBox1.UseSystemPasswordChar = false;
            }
            else
            {
                textBox1.UseSystemPasswordChar = true;
            }
        }

        private void CopyPastaForm_Load(object sender, EventArgs e)
        {
            
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox3.Checked)
            {
                isSelected = true;
            }
            else
            {
                isSelected = false;
            }
        }
    }
}
