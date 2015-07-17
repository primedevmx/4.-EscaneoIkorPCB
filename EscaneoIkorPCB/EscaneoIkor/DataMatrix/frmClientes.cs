using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EscaneoIkor.DataMatrix
{
    public partial class frmClientes : Form
    {
        cDataMatrix _cData = new cDataMatrix();

        public frmClientes(int intProd, string strCte)
        {
            InitializeComponent();
            vCargarProducto();
            cmbProducto.SelectedValue = intProd;
            txtCliente.Text = strCte;
        }

        private void btnActPass_Click(object sender, EventArgs e)
        {
            if (cmbProducto.Text == "")
            {
                MessageBox.Show("Favor de Ingresar un numero de producto.", "ATENCIÓN", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (txtCliente.Text == "")
            {
                MessageBox.Show("Favor de Ingresar un numero de cliente.", "ATENCIÓN", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DataSet dsProducto = new DataSet();
            _cData.vchCliente = txtCliente.Text.Trim();
            _cData.vchProducto = cmbProducto.Text.Trim();
            _cData.intAccion = 5;
            dsProducto = _cData.dsScaneo_sp_MtoDataMatrix();
            try
            {
                if (dsProducto != null && dsProducto.Tables[0].Rows.Count > 0)
                {
                    if (Convert.ToBoolean(dsProducto.Tables[0].Rows[0][0]))
                    {
                        MessageBox.Show(dsProducto.Tables[0].Rows[0][1].ToString(), "ATENCIÓN"
                            , MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                        this.Dispose();
                    }
                    else
                    {
                        MessageBox.Show(dsProducto.Tables[0].Rows[0][1].ToString(), "ATENCIÓN"
                         , MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                        this.Dispose();
                    }

                }

            }
            catch { }
        }

        private void btnDesactivar_Click(object sender, EventArgs e)
        {
            if (cmbProducto.Text == "")
            {
                MessageBox.Show("Favor de Ingresar un numero de producto.", "ATENCIÓN", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (txtCliente.Text == "")
            {
                MessageBox.Show("Favor de Ingresar un numero de cliente.", "ATENCIÓN", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult reply = MessageBox.Show("¿Está SEGURO de desactivar el cliente?.",
                    "Advertencia Verificar Datos", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (reply == DialogResult.No)
            {
                return;
            }

            DataSet dsProducto = new DataSet();
            _cData.vchCliente = txtCliente.Text.Trim();
            _cData.vchProducto = cmbProducto.Text.Trim();
            _cData.intAccion = 6;
            dsProducto = _cData.dsScaneo_sp_MtoDataMatrix();
            try
            {
                if (dsProducto != null && dsProducto.Tables[0].Rows.Count > 0)
                {
                    if (Convert.ToBoolean(dsProducto.Tables[0].Rows[0][0]))
                    {
                        MessageBox.Show(dsProducto.Tables[0].Rows[0][1].ToString(), "ATENCIÓN"
                            , MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                        this.Dispose();
                    }
                    else
                    {
                        MessageBox.Show(dsProducto.Tables[0].Rows[0][1].ToString(), "ATENCIÓN"
                            , MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                        this.Dispose();
                    }

                }

            }
            catch { }
        }

        private void vCargarProducto()
        {
            DataSet dsProducto = new DataSet();
            _cData.intAccion = 1;
            dsProducto = _cData.dsScaneo_sp_MtoDataMatrix();
            try
            {
                cmbProducto.DataSource = dsProducto.Tables[0].Copy();
                cmbProducto.ValueMember = "IDDM";
                cmbProducto.DisplayMember = "vchProducto";
                cmbProducto.SelectedIndex = -1;
            }
            catch { }
        }

        private void tsbCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

    }
}
