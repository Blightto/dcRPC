using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dcRPC
{
    public partial class bildirim : Form
    {
        public bildirim()
        {
            InitializeComponent();
        }

        private void bildirim_Load(object sender, EventArgs e)
        {
            Top = Screen.PrimaryScreen.Bounds.Height - Height - 50;
            Left = Screen.PrimaryScreen.Bounds.Width - Width - 10;
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
