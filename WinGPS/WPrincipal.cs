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
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;

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
                this.txtLatitud.Text = gpsc.Latitud.ToString().Replace(',', '.');
                this.txtLonguitud.Text = gpsc.Longitud.ToString().Replace(',', '.');
                this.txtVelocidad.Text = gpsc.Velocidad;
                this.txtFecha.Text = gpsc.Fecha;
                this.txtCursor.Text = gpsc.Cursor;
                this.txtVariacionMagnetica.Text = gpsc.Variacion;
                this.txtSumaCompObligatoria.Text = gpsc.Mandatory;
                this.MapLoad(gpsc.Latitud, gpsc.Longitud, this.gMapControl1);
                //this.webBrowser1.Navigate(String.Format("http://www.google.com/maps/place/{0},{1}", gpsc.Latitud, gpsc.Longitud));

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error :(", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void MapLoad(double lat, double longi, GMapControl mControl)
        {
            try
            {
                GMapOverlay mOverlay = new GMapOverlay("markers");
                mControl.MapProvider = GMap.NET.MapProviders.GoogleMapProvider.Instance;
                GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerOnly;
                mControl.Position = new GMap.NET.PointLatLng(lat, longi);
                mControl.MaxZoom = 21;
                mControl.MinZoom = 3;
                mControl.Zoom = 14;
                mControl.DragButton = MouseButtons.Left;
                GMarkerGoogle marker = new GMarkerGoogle(new GMap.NET.PointLatLng(mControl.Position.Lat, mControl.Position.Lng), GMarkerGoogleType.blue);
                mOverlay.Markers.Add(marker);
                mControl.Overlays.Add(mOverlay);
            }
            catch (Exception e)
            {
                MessageBox.Show("ERROR AL RENDERIZAR MAPA: "+e.Message);
            }
        }
    }
}
