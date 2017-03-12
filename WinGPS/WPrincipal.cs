using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Gps.Core.Util;

namespace WinGPS
{
    public partial class WPrincipal : Form
    {
        public WPrincipal()
        {
            InitializeComponent();
        }

        private void btnProcesar_Click(object sender, EventArgs e)
        {
            this.txtAreaOut.Text = Convertt.HEXToASCII(this.txtAreaInput.Text.Trim());
        }
    }
}
