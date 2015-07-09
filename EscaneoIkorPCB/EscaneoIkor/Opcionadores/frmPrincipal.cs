using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace EscaneoIkor.Opcionadores
{
    public partial class frmPrincipal : Form
    {
        frmMenuSistema menu;
        frmMenuOperador menuOP;
        mSeguridad _mSecurity;
     
        public int ProgressValue
        {
            set
            {
            }

        }

        public frmPrincipal()
        {
            InitializeComponent();
        }

        public frmPrincipal(mSeguridad mSec)
        {
            _mSecurity = mSec;
            InitializeComponent();
            toolStripStatusLabel1.Text = _mSecurity.vchUsuarioSistema;
        }

        private void vMostrarMenuSistema()
        {
            menu = new frmMenuSistema(this, _mSecurity);
            menu.RightToLeftLayout = true;
            menu.Show(dockPanel1, DockState.DockLeftAutoHide);
        }

        private void vMostrarMenuOperador()
        {
            menuOP = new frmMenuOperador(this, _mSecurity);
            menuOP.RightToLeftLayout = true;
            menuOP.Show(dockPanel1, DockState.DockLeftAutoHide);
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            if (_mSecurity.idTipoUsuario == 3)
            {
                vMostrarMenuOperador();
            }
            else
            {
                vMostrarMenuSistema();
                vMostrarMenuOperador();
            }
          
            string Version;
            try
            {
                Version = System.Deployment.Application.ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString();
            }
            catch
            {
                Version = "Desarrollo";
            }


            lblVersion.Text = "Sistema Ikor Escaneo - PCB v." + Version;

            ProgressValue = 100;
           
        }
    
        private void mostrarMenúToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_mSecurity.idTipoUsuario == 3)
            {
                vMostrarMenuOperador();
            }
            else
            {
                vMostrarMenuSistema();
                vMostrarMenuOperador();
            }
          
        }

        private void dockPanel2_MouseHover(object sender, EventArgs e)
        {

        }

        private void dockPanel2_MouseLeave(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmOpcionConfiguracion frmConf = new frmOpcionConfiguracion(this, _mSecurity);
            clSeguridad.vCargaForma(frmConf, this, "Menú Configuración");
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
            frmLogin FRM = new frmLogin();
            FRM.ShowDialog();
        }
    }
}
