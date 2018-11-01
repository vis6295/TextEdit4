using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TextEdit4
{
    public partial class TextEdit : Control
    {
        public TextEdit()
        {
            //InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(Pens.Red, new Rectangle(10, 10, this.Width - 20, this.Height - 20));
        }
    }
}
