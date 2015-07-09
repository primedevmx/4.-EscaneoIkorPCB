using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EscaneoIkor.Opcionadores
{
    public partial class frmOpcionConfiguracion : Form
    {
        frmPrincipal mdipr;
        mSeguridad _mSecurity = new mSeguridad();

        public frmOpcionConfiguracion(Form frmMDI,mSeguridad mSec)
        {
            InitializeComponent();
            mdipr = (frmPrincipal)frmMDI;
            _mSecurity = mSec;
            
            //Seguridad->>
            if (_mSecurity.idTipoUsuario != 1)
            {
                btnUsuarios.Visible = false;
                lblUsuarios.Visible = false;
            }
                     
        }

        private void tsbCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }     

        private void btnServidorSqlServer_Click(object sender, EventArgs e)
        {
            SqlServer.frmServidorSqlServer frm1 = new SqlServer.frmServidorSqlServer();
            clSeguridad.vCargaForma(frm1, mdipr, "Servidor Sql Server");
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            Seguridad.frmUsuarios frm1 = new Seguridad.frmUsuarios(_mSecurity);
            clSeguridad.vCargaForma(frm1, mdipr, "Configuración de Usuarios");
        }

        private void btnCuentasCorreo_Click(object sender, EventArgs e)
        {
            Configuracion.frmConfiguracionCorreo frm1 = new Configuracion.frmConfiguracionCorreo();
            clSeguridad.vCargaForma(frm1, mdipr, "Configuración de Cuentas de Correo");
        }

        private void btnMonitores_Click(object sender, EventArgs e)
        {
            Configuracion.frmMonitores frm1 = new Configuracion.frmMonitores();
            clSeguridad.vCargaForma(frm1, mdipr, "Configuración de Monitores");
        }

        private void btnRepositorios_Click(object sender, EventArgs e)
        {
            Configuracion.frmConfiguracionRepositorios frm1 = new Configuracion.frmConfiguracionRepositorios();
            clSeguridad.vCargaForma(frm1, mdipr, "Configuración de Repositorios");
        }
    }
}
