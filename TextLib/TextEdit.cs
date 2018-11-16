using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Common;

namespace TextLib
{
    public partial class TextEdit : Control
    {
        StrInfo[] buf { get; set; }

        public Font font = new Font("Consolas", 10);
        //public char EmptyChar = '◦';//символ - заполнитель
        //public char EmptyChar = '⋅';//какой то корткий символ. Хотя шрифт моношширинный :(
        //public char EmptyChar = '◦';
        public char EmptyChar = ' ';
        public Brush DefaultBrush = Brushes.GreenYellow;//для отображения шрифта
        public Color DefaultBkColor = Color.Black;
        public Brush bkBrush = Brushes.Black;

        public int iTop = 0;//верхняя строка
        public int iLeft = 0;//левый символ

        public float fontH, fontW, extW, extH;//размеры шрифра

        public int iH, iW;



        public TextEdit()
        {
            //InitializeComponent();
            DoubleBuffered = false;
            MinimumSize = new Size() { Width = 70, Height = 50 };


            iTop = 0;
            iLeft = 0;

            using (Graphics gr = Graphics.FromHwnd(IntPtr.Zero)) {
                SizeF pt1 = gr.MeasureString("*", font, new PointF(0, 0), StringFormat.GenericTypographic);
                SizeF pt2 = gr.MeasureString("**\n**", font, new PointF(0, 0), StringFormat.GenericTypographic);

                fontW = pt2.Width - pt1.Width;
                extW = pt1.Width - fontW;
                fontH = pt2.Height - pt1.Height;
                extH = pt1.Height - fontH;
            }
            LogForm.msg($"font size: {fontW} / {fontH}\next size: {extW} / {extH}");
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            //e.Graphics.DrawRectangle(Pens.Red, new Rectangle(10, 10, this.Width - 20, this.Height - 20));
            LogForm.msg($"OnPaint: {e.ClipRectangle.ToString()}");
            //Rectangle.Empty.IsEmpty;
            for (int i = 0; i < iH; i++)
            {
                string result = GetString(i);
                result = result.Substring(0, result.Length - 1) + '=';
                e.Graphics.DrawString(result, font, DefaultBrush, new PointF(0, (int)Math.Round(i * fontH)), StringFormat.GenericTypographic);
            }
        }

        string GetString(int idx)
        {
            string s = StringData.GetString(iTop+idx);
            if (s == null) return new string(EmptyChar, iW);
            else {
                int slen = s.Length;
                if (slen <= iLeft) return new string(EmptyChar, iW);
                else {
                    if (slen - iLeft >= iW) return s.Substring(iLeft, iW);
                    else return s.Substring(iLeft)+ new string(EmptyChar, iW-(slen - iLeft));
                }
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            LogForm.msg($"OnResize: {Width} / {Height}\n\tsize: {Size.Width} / {Size.Height}");
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            LogForm.msg($"OnSizeChanged: {Width} / {Height}\n\tsize: {Size.Width} / {Size.Height}");
            int w = (int)Math.Ceiling(Width / fontW);
            int h = (int)Math.Ceiling(Height / fontH);
            iW = w; iH = h;
            LogForm.msg($"iW: {iW} / iH: {iH}");
        }
    }

    struct StrInfo {
        public string str;
        //public ColorInfo[] colorArray;
        public bool needReload;
        public bool needRepaint;
    }

    //struct ColorInfo {
    //    public int schema;
    //    public int len;
    //}

}
