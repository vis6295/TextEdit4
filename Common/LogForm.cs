using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Common
{
    public partial class LogForm : Form
    {
        static LogForm instance;

        public LogForm()
        {
            InitializeComponent();
            instance = this;
            timer1.Enabled = true;
        }

        StringBuilder buf = new StringBuilder();

        object o = new object();
        public static void msg(string str) {
            instance._msg(str);
        }
        public void _msg(string str) {
            lock (o) {
                buf.AppendLine(str);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lock (o) {
                if (buf.Length > 0) {
                    richTextBox1.AppendText(buf.ToString());
                    buf.Clear();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }
    }
}
