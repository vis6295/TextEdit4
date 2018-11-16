using Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TextLib;

namespace TextEdit4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            //this.SuspendLayout();
            //textEdit.Dock = DockStyle.Fill;
            //this.Controls.Add(textEdit);
            
            //textEdit.Parent = this;

            textEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            textEdit.BackColor = Color.Black;
            textEdit.Parent = tabPage1;
            textEdit.BringToFront();
            //this.textEdit.Location = new System.Drawing.Point(0, 0);
            //this.textEdit.Name = "panel2";
            //this.textEdit.Size = new System.Drawing.Size(600, 450);
            //this.textEdit.TabIndex = 1;
            //this.Controls.Add(this.textEdit);
            //this.panel2.Controls.Add(this.textEdit);
            //this.ResumeLayout(false);
        }

        LogForm logForm = new LogForm();
        TextEdit textEdit = new TextEdit();

        private void button1_Click(object sender, EventArgs e)
        {
            LogForm.msg("button1_Click");
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            Point pt = new Point(this.Location.X + this.Width, this.Location.Y);
            //this.StartPosition = 0;
            logForm.StartPosition = 0;
            logForm.Location = pt;
            logForm.Show(this);
            this.BringToFront();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"{ClientSize.Width} : {ClientSize.Height}\n{textEdit.Width} : {textEdit.Height}");
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            //base.OnResize(e);
            LogForm.msg($"form OnResize: {Width} / {Height}\n\tsize: {Size.Width} / {Size.Height}");
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            LogForm.msg($"form OnSizeChanged: {Width} / {Height}\n\tsize: {Size.Width} / {Size.Height}");
        }
    }
}
