using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EscaneoIkor.Configuracion
{
    public partial class frmConfiguracionRepositorios : Form
    {
        public frmConfiguracionRepositorios()
        {
            InitializeComponent();
            txtRepositorio.Text = Properties.Settings.Default.strRepoXMLs;
            txtRepositorioExcel.Text = Properties.Settings.Default.strRepoExcel;
            txtRespaldoSQL.Text = Properties.Settings.Default.strRespaldoSQL;
            CHK_APP_RESP.Checked = Convert.ToBoolean(Properties.Settings.Default.bAplicaResp);
        }

        private void tsbCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }
   
        private void btnGuardarRepositorio_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.strRepoXMLs = txtRepositorio.Text.Trim();
            Properties.Settings.Default.Save();
            MessageBox.Show("Se ha registrado correctamente el directorio de repositorio de [XMLs]. \n \n - Puede usted continuar. ", "Atención"
                   , MessageBoxButtons.OK, MessageBoxIcon.Question);  
        }

        private void btnSeleccionarRepositorio_Click(object sender, EventArgs e)
        {
            this.folderBrowserDialog1.ShowNewFolderButton = false;

            this.folderBrowserDialog1.RootFolder =
                                        System.Environment.SpecialFolder.MyComputer;

            DialogResult result = this.folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                txtRepositorio.Text = this.folderBrowserDialog1.SelectedPath;
            }
        }

        private void btnSeleccionarRepositorioDAT_Click(object sender, EventArgs e)
        {
            this.folderBrowserDialog1.ShowNewFolderButton = false;

            this.folderBrowserDialog1.RootFolder =
                                        System.Environment.SpecialFolder.MyComputer;

            DialogResult result = this.folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                txtRepositorio.Text = this.folderBrowserDialog1.SelectedPath;
            }
        }

        private void btnGuardarRepositorioTXT_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.strRepoExcel = txtRepositorioExcel.Text.Trim()+"\\";
            Properties.Settings.Default.Save();
            MessageBox.Show("Se ha registrado correctamente el directorio de repositorio de [Excels]. \n \n - Puede usted continuar. ", "Atención"
                   , MessageBoxButtons.OK, MessageBoxIcon.Question); 
        }

        private void btnSeleccionarRepositorioTXT_Click(object sender, EventArgs e)
        {
            this.folderBrowserDialog1.ShowNewFolderButton = false;

            this.folderBrowserDialog1.RootFolder =
                                        System.Environment.SpecialFolder.MyComputer;

            DialogResult result = this.folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                txtRepositorioExcel.Text = this.folderBrowserDialog1.SelectedPath;
            }
        }

        private void btnSeleccionarRepositorioSQL_Click(object sender, EventArgs e)
        {
            this.folderBrowserDialog1.ShowNewFolderButton = false;

            this.folderBrowserDialog1.RootFolder =
                                        System.Environment.SpecialFolder.MyComputer;

            DialogResult result = this.folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                txtRespaldoSQL.Text = this.folderBrowserDialog1.SelectedPath;
            }
        }

        private void btnGuardarRepoSQL_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.bAplicaResp = CHK_APP_RESP.Checked.ToString();
            if (!CHK_APP_RESP.Checked)
            {
                txtRespaldoSQL.Text = "C:\\";
            }
            Properties.Settings.Default.strRespaldoSQL = txtRespaldoSQL.Text.Trim();
            Properties.Settings.Default.Save();
            MessageBox.Show("Se ha registrado correctamente el directorio de repositorio de [sql]. \n \n - Puede usted continuar. ", "Atención"
                   , MessageBoxButtons.OK, MessageBoxIcon.Question); 
        }

        private void tsbCerrar_Click_1(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void toolStrip4_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }



    }
}
