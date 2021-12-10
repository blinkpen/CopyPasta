using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CopyPasta
{
    public partial class Form1 : Form
    {
        private int formCount = 0;
        private Color cpfBackcolor = SystemColors.Control;
        private Color cpfForecolor = Color.Black;
        private Color lightRed;

        public Form1()
        {
            InitializeComponent();
            colorDialog1.Color = SystemColors.Control;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void addNewCPF()
        {
            if (formCount == 0)
            {                
                CopyPastaForm newForm = new CopyPastaForm();
                newForm.Location = new Point(0, 30);
                newForm.BackColor = cpfBackcolor;                
                panel1.Controls.Add(newForm);
                newForm.Name = "New CopyPasta Form " + (formCount + 1);
                formCount += 1;
                //toolStripLabel1.Text = $"{formCount} CopyPasta Form";
                newForm.Controls["textBox2"].Text = newForm.Name;               
            }
            else
            {
                CopyPastaForm newForm = new CopyPastaForm();
                newForm.Name = "New CopyPasta Form " + (formCount + 1);
                newForm.BackColor = cpfBackcolor;                
                Control lastOne = panel1.Controls["New CopyPasta Form " + (formCount)];
                panel1.Controls.Add(newForm);
                newForm.Location = new Point(lastOne.Left, lastOne.Bottom + 2);
                newForm.Controls["textBox2"].Text = newForm.Name;                
                formCount += 1;
                //toolStripLabel1.Text = $"{formCount} CopyPasta Forms";
            }
            reCenterForms();
            assignColors();
            updateLabel();
        }

        private void updateLabel()
        {
            if(formCount == 1)
            {
                toolStripLabel1.Text = $"{formCount} CopyPasta Form";
            }
            else
            {
                toolStripLabel1.Text = $"{formCount} CopyPasta Forms";
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            foreach (CopyPastaForm cpf in panel1.Controls.OfType<CopyPastaForm>())
            {
                if (cpf.isSelected)
                {
                    panel1.Controls.Remove(cpf);
                    formCount -= 1;                    
                }
            }
            updateLabel();
        }

        private void assignColors()
        {
            foreach (CopyPastaForm cpf in panel1.Controls.OfType<CopyPastaForm>())
            {
                cpf.BackColor = cpfBackcolor;

                if (cpfBackcolor.GetBrightness() >= .5)
                {
                    foreach (Control c in cpf.Controls)
                    {
                        if (c.Name == "button1")
                        {

                        }
                        else if (c.Name == "textBox1")
                        {
                            if (cpfBackcolor == SystemColors.Control)
                            {
                                c.BackColor = Color.White;
                                c.ForeColor = Color.Black;                                
                            }
                            else
                            {
                                lightRed = ControlPaint.Light(cpfBackcolor);
                                c.BackColor = lightRed;
                                c.ForeColor = cpfForecolor;
                            }
                        }
                        else if (c.Name == "textBox2")
                        {
                            if (cpfBackcolor == SystemColors.Control)
                            {
                                c.BackColor = Color.White;
                                c.ForeColor = Color.Black;
                            }
                            else
                            {
                                lightRed = ControlPaint.Light(cpfBackcolor);
                                c.BackColor = lightRed;
                                c.ForeColor = cpfForecolor;
                            }
                        }
                        else
                        {
                            c.ForeColor = Color.Black;
                            cpfForecolor = Color.Black;
                        }
                    }
                }
                else if (cpfBackcolor.GetBrightness() < .5)
                {
                    foreach (Control c in cpf.Controls)
                    {
                        if (c.Name == "button1")
                        {

                        }
                        else if (c.Name == "textBox1")
                        {
                            if (cpfBackcolor == SystemColors.Control)
                            {
                                c.BackColor = Color.White;
                                c.ForeColor = Color.Black;
                            }
                            else
                            {
                                lightRed = ControlPaint.Light(cpfBackcolor);
                                c.BackColor = lightRed;
                                c.ForeColor = cpfForecolor;
                            }
                        }
                        else if (c.Name == "textBox2")
                        {
                            if (cpfBackcolor == SystemColors.Control)
                            {
                                c.BackColor = Color.White;
                                c.ForeColor = Color.Black;
                            }
                            else
                            {
                                lightRed = ControlPaint.Light(cpfBackcolor);
                                c.BackColor = lightRed;
                                c.ForeColor = cpfForecolor;
                            }
                        }
                        else
                        {
                            c.ForeColor = Color.White;
                            cpfForecolor = Color.White;
                        }
                    }
                }
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            addNewCPF();
        }

        private void reCenterForms()
        {
            foreach (CopyPastaForm cpf in panel1.Controls.OfType<CopyPastaForm>())
            {
                cpf.Left = (this.ClientSize.Width - cpf.Width) / 2;
            }
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            reCenterForms();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            colorDialog1.CustomColors = new int[] {
                                        ColorTranslator.ToOle(SystemColors.Control),
                                        ColorTranslator.ToOle(Color.FromArgb(39, 39, 39)),
                                        ColorTranslator.ToOle(Color.FromArgb(27, 27, 27))
                                      };
            colorDialog1.ShowDialog();
            cpfBackcolor = colorDialog1.Color;
            panel1.BackColor = colorDialog1.Color;
            assignColors();
            assignColors();
        }
    }
}


