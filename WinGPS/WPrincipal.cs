﻿using System;
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
            try
            {
                String trama = this.txtAreaInput.Text.Trim();
               
                GpsCore gpsc = Traductor.Translate(trama);

                this.txtImei.Text = gpsc.Imei;
                this.txtEvento.Text = gpsc.Evento;
                this.txtTrama.Text = gpsc.Trama;
                this.txtTiempo.Text = gpsc.Tiempo;
                this.txtNaveacion.Text = gpsc.Navegacion;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error :(", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
