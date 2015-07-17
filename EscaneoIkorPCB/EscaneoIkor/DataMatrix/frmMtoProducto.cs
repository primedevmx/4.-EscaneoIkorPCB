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
    public partial class frmMtoProducto : Form
    {
        cDataMatrix _cData = new cDataMatrix();

        public frmMtoProducto(string strProd)
        {
            InitializeComponent();
            txtProducto.Text = strProd;
        }

        private void tsbCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void btnActPass_Click(object sender, EventArgs e)
        {
            if (txtProducto.Text == "")
            {
                MessageBox.Show("Favor de Ingresar un numero de producto.","ATENCIÓN",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }

            DataSet dsProducto = new DataSet();
            _cData.vchProducto = txtProducto.Text.Trim();
            _cData.intAccion = 3;
            dsProducto = _cData.dsScaneo_sp_MtoDataMatrix();
            try
            {
                if (dsProducto != null && dsProducto.Tables[0].Rows.Count > 0)
                { 
                    if(Convert.ToBoolean(dsProducto.Tables[0].Rows[0][0]))
                    {
                        MessageBox.Show(dsProducto.Tables[0].Rows[0][1].ToString(), "ATENCIÓN"
                            ,MessageBoxButtons.OK,MessageBoxIcon.Information);
                        this.Close();
                        this.Dispose();
                    }
                    else{
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
            if (txtProducto.Text == "")
            {
                MessageBox.Show("Favor de Ingresar un numero de producto.", "ATENCIÓN", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult reply = MessageBox.Show("¿Está SEGURO de desactivar el producto?.",
                     "Advertencia Verificar Datos", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (reply == DialogResult.No)
            {
                return;
            }

            DataSet dsProducto = new DataSet();
            _cData.vchProducto = txtProducto.Text.Trim();
            _cData.intAccion = 4;
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
                            , MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                  
                }

            }
            catch { }

        }
    }
}
