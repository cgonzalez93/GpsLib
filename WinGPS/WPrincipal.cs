using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GpsLibs.Util;
using GpsLibs;
using GpsLib;

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
            String trama =this.txtAreaInput.Text.Trim();
            if (trama.IsHexadecimal()) throw new ArgumentException("No Es un Hexadecimal");
            GpsCore gpsc = Traductor.Translate(trama);
            
            this.txtImei.Text =gpsc.Imei ;
        }
    }
}
