using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data.OleDb;
using System.Data.Common;
using System.IO;
using System.Xml;
using System.Linq;
using Microsoft.ApplicationBlocks.Data;
using System.Windows.Forms;

namespace EscaneoIkor.DataMatrix
{
    public partial class frmDataMatrix : Form
    {
        #region GLOBALES
        mSeguridad _mSecurity = new mSeguridad();
        cDataMatrix _cData = new cDataMatrix();
        DataTable _dtDataMatrix = new DataTable();
        DataRow _drDM = null;
        int _intCI = -1;

        #endregion GLOBALES
        #region CONSTRUCTORES
        public frmDataMatrix(mSeguridad mSec)
        {
            InitializeComponent();
            _mSecurity = mSec;
            #region VENTANA
            uctrlTablaConFiltro1.toolBusqueda.Visible = false;
            groupBox2.Enabled = false;
            groupBox3.Enabled = false;
            groupBox4.Enabled = false;
            #endregion VENTANA
        }
        public frmDataMatrix()
        {
            InitializeComponent();
        }
        #endregion CONSTRUCTORES
        #region EVENTOS
        private void frmDataMatrix_Load(object sender, EventArgs e)
        {
            vCargar();
        }

        private void tsbGuardar_Click(object sender, EventArgs e)
        {
            int intReg = 0;

            uctrlTablaConFiltro1.gridDatos.EndEdit();

            _dtDataMatrix =
                (DataTable)uctrlTablaConFiltro1.gridDatos.DataSource;

            intReg = _dtDataMatrix.Rows.Count;

            DialogResult reply = MessageBox.Show("Se encuentra a punto de actualizar "+intReg.ToString()+" registros de la DataMatrix,"
                + "\r\n - ¿Está correcta la información?.",
                     "Advertencia Verificar Datos", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (reply == DialogResult.No)
            {
                return;
            }

            DataSet dsRs_DM= new DataSet();
            _cData.intAccion = 8;
            dsRs_DM = this.dsScaneo_sp_EliminaDataMatrix();

            if(!Convert.ToBoolean(dsRs_DM.Tables[0].Rows[0][0]))
            {
                MessageBox.Show("Ocurrió un error en el proceso.", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DataSet dsRsNew_DM = new DataSet();
            _cData.intAccion = 7;
            dsRsNew_DM = this.dsScaneo_sp_InsertaDataMatrix();

            if (Convert.ToBoolean(dsRs_DM.Tables[0].Rows[0][0]))
            {
                MessageBox.Show("Operación realizada satisfactoriamente.","MENSAJE",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }

            vLimpiar();

        }

        private void tsbModificar_Click(object sender, EventArgs e)
        {

        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {

        }

        private void tsbLimpiar_Click(object sender, EventArgs e)
        {
            vLimpiar();
        }

        private void tsbCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void cmbProducto_SelectedValueChanged(object sender, EventArgs e)
        {
            DataSet dsClientes = new DataSet();
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                //Proceso->
                _cData.vchProducto = cmbProducto.Text.Trim();
                _cData.intIDCliente = Convert.ToInt32(cmbCliente.SelectedValue);
                _cData.intIDDM = Convert.ToInt32(cmbProducto.SelectedValue);                
                _cData.intAccion = 2;                
                dsClientes = _cData.dsScaneo_sp_MtoDataMatrix();
                //ComboClientes->
                cmbCliente.DataSource = dsClientes.Tables[0].Copy();
                cmbCliente.ValueMember = "IDCliente";
                cmbCliente.DisplayMember = "vchCliente";
                cmbCliente.SelectedIndex = -1;
            
            }
            catch { }
            Cursor.Current = Cursors.Arrow;

        }
        
        private void uctrlTablaConFiltro1_GridDatos_DoubleClick(object sender, uctrlTablaConFiltro.GridDatos_DoubleClickEnventArgs e)
        {
            _drDM = ((DataRowView)uctrlTablaConFiltro1.gridDatos.CurrentRow.DataBoundItem).Row;

            if (_drDM != null)
            {
                txtBinTexto.Text = _drDM["vchCodigoBinTexto"].ToString().Trim();
                txtBin1.Text = _drDM["vchBin1"].ToString().Trim();
                txtBin2.Text = _drDM["vchBin2"].ToString().Trim();
                txtBin3.Text = _drDM["vchBin3"].ToString().Trim();
                txtBinCC.Text = _drDM["vchDatamatrixCC"].ToString().Trim();
            }

        }

        private void cmbCliente_SelectedValueChanged(object sender, EventArgs e)
        {
            DataSet dsDM = new DataSet();
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                //Proceso->
                _cData.vchProducto = cmbProducto.Text.Trim();
                _cData.intIDCliente = Convert.ToInt32(cmbCliente.SelectedValue);
                _cData.intIDDM = Convert.ToInt32(cmbProducto.SelectedValue);
                _cData.intAccion = 2;
                dsDM = _cData.dsScaneo_sp_MtoDataMatrix();
                //DataMatrix->
                _dtDataMatrix = dsDM.Tables[1].Copy();
                //Ventana->
                groupBox2.Enabled = false;
                groupBox3.Enabled = false;
                groupBox4.Enabled = false;
                //Grid->
                uctrlTablaConFiltro1.gridDatos.DataSource = _dtDataMatrix.Copy();
                uctrlTablaConFiltro1.gridDatos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                uctrlTablaConFiltro1.gridDatos.Columns[0].Visible = false;
                uctrlTablaConFiltro1.gridDatos.Columns[2].Visible = false;
                uctrlTablaConFiltro1.gridDatos.Columns[3].Visible = false;
                uctrlTablaConFiltro1.gridDatos.Columns[4].Visible = false;
                uctrlTablaConFiltro1.gridDatos.Columns[6].Visible = false;
                uctrlTablaConFiltro1.gridDatos.Columns[7].Visible = false;
                uctrlTablaConFiltro1.gridDatos.Columns[13].Visible = false;
                #region SELECCIONAR SOLO UNA ROW DATAGRIDVIEW
                this.uctrlTablaConFiltro1.gridDatos.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;
                this.uctrlTablaConFiltro1.gridDatos.MultiSelect = false;
                #endregion SELECCIONAR SOLO UNA ROW DATAGRIDVIEW
                #region DESACTIVAR SORTMODE
                foreach (DataGridViewColumn columna in uctrlTablaConFiltro1.gridDatos.Columns)
                {
                    columna.SortMode = DataGridViewColumnSortMode.NotSortable;
                }
                #endregion DESACTIVAR SORTMODE

            }
            catch { }
            Cursor.Current = Cursors.Arrow;
        }

        private void btnAgrProducto_Click(object sender, EventArgs e)
        {
            frmMtoProducto FRM = new frmMtoProducto(cmbProducto.Text.Trim());
            FRM.ShowDialog();
            vCargarProducto();
            cmbCliente.DataSource = null;
        }

        private void btnAgrCliente_Click(object sender, EventArgs e)
        {
            frmClientes FRM = new frmClientes(Convert.ToInt32(cmbProducto.SelectedValue),cmbCliente.Text.Trim());
            FRM.ShowDialog();
            cmbProducto_SelectedValueChanged(null,null);
        }

        #endregion EVENTOS
        #region ARROWS
        private void btnDOWN_Click(object sender, EventArgs e)
        {
            _intCI = -1;
            try
            {

                _intCI = uctrlTablaConFiltro1.gridDatos.CurrentRow.Index;
            }
            catch { }

            if (_intCI != -1)
            {
                string error;
                if (!bValidaDatosDM(out error))
                {
                    MessageBox.Show(error, "ATENCIÓN", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                uctrlTablaConFiltro1.gridDatos.Rows[uctrlTablaConFiltro1.gridDatos.CurrentRow.Index].Cells["vchCliente"].Value
                    = cmbCliente.Text.Trim();
                uctrlTablaConFiltro1.gridDatos.Rows[uctrlTablaConFiltro1.gridDatos.CurrentRow.Index].Cells["vchProducto"].Value
                    = cmbProducto.Text.Trim();
                uctrlTablaConFiltro1.gridDatos.Rows[uctrlTablaConFiltro1.gridDatos.CurrentRow.Index].Cells["vchCodigoBinTexto"].Value
                    = txtBinTexto.Text.Trim();
                uctrlTablaConFiltro1.gridDatos.Rows[uctrlTablaConFiltro1.gridDatos.CurrentRow.Index].Cells["vchBin1"].Value
                    = txtBin1.Text.Trim();
                uctrlTablaConFiltro1.gridDatos.Rows[uctrlTablaConFiltro1.gridDatos.CurrentRow.Index].Cells["vchBin2"].Value
                    = txtBin2.Text.Trim();
                uctrlTablaConFiltro1.gridDatos.Rows[uctrlTablaConFiltro1.gridDatos.CurrentRow.Index].Cells["vchBin3"].Value
                    = txtBin3.Text.Trim();
                uctrlTablaConFiltro1.gridDatos.Rows[uctrlTablaConFiltro1.gridDatos.CurrentRow.Index].Cells["vchDatamatrixCC"].Value
                    = txtBinCC.Text.Trim();
            }
            else {
                MessageBox.Show("Favor de insertar una [Nueva Fila] a la grilla.", "ATENCIÓN", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;        
            }

            uctrlTablaConFiltro1.gridDatos.EndEdit();
          
            //Ventana->
            txtBinTexto.Text = "";
            txtBin1.Text = "";
            txtBin2.Text = "";
            txtBin3.Text = "";
            txtBinCC.Text = "";

        }
        private bool bValidaDatosDM(out string err)
        {
            err = "";
            if (txtBinTexto.Text == "") { err = "Debe especificar el [Codigo Bin para Texto]."; }
            else if (txtBin1.Text == "") { err = "Debe especificar el [Bin Real de LED Recibido 1]."; }
            else if (txtBin2.Text == "") { err = "Debe especificar el [Bin Real de LED Recibido 2]."; }
            else if (txtBin3.Text == "") { err = "Debe especificar el [Bin Real de LED Recibido 3]."; }
            else if (txtBinCC.Text == "") { err = "Debe especificar el [Codigo Bin CC para DataMatrix]."; }

            return (err == "");
        }
        private void btnNEWrow_Click(object sender, EventArgs e)
        {
            DataTable dtPaso = (DataTable)uctrlTablaConFiltro1.gridDatos.DataSource;
            DataRow DRO = dtPaso.NewRow();
            dtPaso.Rows.Add(DRO);
            int index = dtPaso.Rows.Count-1;
            if (index > 0)
            {
                uctrlTablaConFiltro1.gridDatos.CurrentCell = uctrlTablaConFiltro1.gridDatos.Rows[index].Cells[1];
            }
        }
        private void btnUP_Click(object sender, EventArgs e)
        {
            _drDM = ((DataRowView)uctrlTablaConFiltro1.gridDatos.CurrentRow.DataBoundItem).Row;

            if (_drDM != null)
            {
                txtBinTexto.Text = _drDM["vchCodigoBinTexto"].ToString().Trim();
                txtBin1.Text = _drDM["vchBin1"].ToString().Trim();
                txtBin2.Text = _drDM["vchBin2"].ToString().Trim();
                txtBin3.Text = _drDM["vchBin3"].ToString().Trim();
                txtBinCC.Text = _drDM["vchDatamatrixCC"].ToString().Trim();
            }
        }
        private void btnQuitarRow_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dtPaso = (DataTable)uctrlTablaConFiltro1.gridDatos.DataSource;
                DataRow DRO = ((DataRowView)uctrlTablaConFiltro1.gridDatos.CurrentRow.DataBoundItem).Row;
                dtPaso.Rows.Remove(DRO);
                uctrlTablaConFiltro1.gridDatos.DataSource = dtPaso.Copy();
                int index = dtPaso.Rows.Count - 1;
                if (index > 0)
                {
                    uctrlTablaConFiltro1.gridDatos.CurrentCell = uctrlTablaConFiltro1.gridDatos.Rows[index].Cells[1];
                }
            }
            catch { }
        }
        private void btnE_DM_Click(object sender, EventArgs e)
        {
            if (cmbProducto.Text == "")
            {
                MessageBox.Show("Favor de seleccionar el producto.", "ATENCIÓN");
                return;
            }
            else if (cmbCliente.Text == "")
            {
                MessageBox.Show("Favor de seleccionar al cliente.", "ATENCIÓN");
                return;
            }

            groupBox2.Enabled = true;
            groupBox3.Enabled = true;
            groupBox4.Enabled = true;
            groupBox1.Enabled = false;
        }  
        #endregion ARROWS
        #region METODOS
        private void vCargar()
        {
            vCargarProducto();
        }
        private void vCargarProducto()
        {
            DataSet dsProducto = new DataSet();
            _cData.intAccion = 1;
            dsProducto=_cData.dsScaneo_sp_MtoDataMatrix();
            try
            {
                cmbProducto.SelectedValueChanged -= new EventHandler(cmbProducto_SelectedValueChanged);             
                cmbProducto.DataSource = dsProducto.Tables[0].Copy();
                cmbProducto.ValueMember = "IDDM";
                cmbProducto.DisplayMember = "vchProducto";
                cmbProducto.SelectedIndex = -1;
                cmbProducto.SelectedValueChanged += new EventHandler(cmbProducto_SelectedValueChanged);
            }
            catch { }
        }
        private void vLimpiar()
        {
            cmbCliente.DataSource = null;
            cmbProducto.SelectedIndex = -1;
            groupBox1.Enabled = true;
            groupBox2.Enabled = false;
            groupBox3.Enabled = false;
            groupBox4.Enabled = false;
            txtBinTexto.Text = "";
            txtBin1.Text = "";
            txtBin2.Text = "";
            txtBin3.Text = "";
            txtBinCC.Text = "";
        }
        public DataSet dsScaneo_sp_EliminaDataMatrix()
        {
            DataSet dsResult = new DataSet();
            try
            {
                SqlParameter[] arParms = new SqlParameter[11];

                arParms[0] = new SqlParameter("@IDDM", SqlDbType.Int);
                arParms[0].Value = _cData.intIDDM;
                arParms[1] = new SqlParameter("@IDCliente", SqlDbType.Int);
                arParms[1].Value = _cData.intIDCliente;
                arParms[2] = new SqlParameter("@IDBin", SqlDbType.Int);
                arParms[2].Value = _cData.intIDBin;
                arParms[3] = new SqlParameter("@vchProducto", SqlDbType.VarChar, 50);
                arParms[3].Value = cmbProducto.Text.Trim();
                arParms[4] = new SqlParameter("@vchCliente", SqlDbType.VarChar, 50);
                arParms[4].Value = _cData.vchCliente;
                arParms[5] = new SqlParameter("@vchCodigoBinTexto", SqlDbType.VarChar, 50);
                arParms[5].Value = _cData.vchCodigoBinTexto;
                arParms[6] = new SqlParameter("@vchBin1", SqlDbType.VarChar, 50);
                arParms[6].Value = _cData.vchBin1;
                arParms[7] = new SqlParameter("@vchBin2", SqlDbType.VarChar, 50);
                arParms[7].Value = _cData.vchBin2;
                arParms[8] = new SqlParameter("@vchBin3", SqlDbType.VarChar, 50);
                arParms[8].Value = _cData.vchBin3;
                arParms[9] = new SqlParameter("@vchDatamatrixCC", SqlDbType.VarChar, 50);
                arParms[9].Value = _cData.vchDatamatrixCC;
                arParms[10] = new SqlParameter("@intAccion", SqlDbType.Int);
                arParms[10].Value = _cData.intAccion;


                dsResult = SqlHelper.ExecuteDataset(_cData.strConnSQL, CommandType.StoredProcedure, "[dbo].[Scaneo_sp_MtoDataMatrix]", arParms);

                return dsResult;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public DataSet dsScaneo_sp_InsertaDataMatrix()
        {
            DataSet dsResult = new DataSet();
            try
            {
                SqlParameter[] arParms = new SqlParameter[11];

                arParms[0] = new SqlParameter("@IDDM", SqlDbType.Int);
                arParms[1] = new SqlParameter("@IDCliente", SqlDbType.Int);
                arParms[2] = new SqlParameter("@IDBin", SqlDbType.Int);
                arParms[3] = new SqlParameter("@vchProducto", SqlDbType.VarChar, 50);
                arParms[4] = new SqlParameter("@vchCliente", SqlDbType.VarChar, 50);
                arParms[5] = new SqlParameter("@vchCodigoBinTexto", SqlDbType.VarChar, 50);
                arParms[6] = new SqlParameter("@vchBin1", SqlDbType.VarChar, 50);
                arParms[7] = new SqlParameter("@vchBin2", SqlDbType.VarChar, 50);
                arParms[8] = new SqlParameter("@vchBin3", SqlDbType.VarChar, 50);
                arParms[9] = new SqlParameter("@vchDatamatrixCC", SqlDbType.VarChar, 50);
                arParms[10] = new SqlParameter("@intAccion", SqlDbType.Int);


                arParms[0].Value = _cData.intIDDM;
                arParms[1].Value = _cData.intIDCliente;
                arParms[2].Value = _cData.intIDBin;
                arParms[3].Value = _dtDataMatrix.Rows[0][5].ToString().Trim();
                arParms[4].Value = _cData.vchCliente;
                arParms[10].Value = _cData.intAccion;

                foreach (DataRow DR in _dtDataMatrix.Rows)
                {

                    arParms[5].Value = DR[8].ToString().Trim();
                    arParms[6].Value = DR[9].ToString().Trim();
                    arParms[7].Value = DR[10].ToString().Trim();
                    arParms[8].Value = DR[11].ToString().Trim();
                    arParms[9].Value = DR[12].ToString().Trim();

                    dsResult = SqlHelper.ExecuteDataset(_cData.strConnSQL, CommandType.StoredProcedure, "[dbo].[Scaneo_sp_MtoDataMatrix]", arParms);
                }



                return dsResult;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion METODOS 
    }
}
