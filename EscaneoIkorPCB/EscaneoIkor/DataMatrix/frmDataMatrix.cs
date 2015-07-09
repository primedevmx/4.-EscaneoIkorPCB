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
    public partial class frmDataMatrix : Form
    {
        #region GLOBALES
        mSeguridad _mSecurity = new mSeguridad();

        #endregion GLOBALES
        #region CONSTRUCTORES
        public frmDataMatrix(mSeguridad mSec)
        {
            InitializeComponent();
            _mSecurity = mSec;
        }
        public frmDataMatrix()
        {
            InitializeComponent();
        }
        #endregion CONSTRUCTORES
        #region EVENTOS
        private void tsbGuardar_Click(object sender, EventArgs e)
        {

        }

        private void tsbModificar_Click(object sender, EventArgs e)
        {

        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {

        }

        private void tsbLimpiar_Click(object sender, EventArgs e)
        {

        }

        private void tsbCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }
        #endregion EVENTOS
        #region ARROWS
        private void btnDOWN_Click(object sender, EventArgs e)
        {

        }

        private void btnUP_Click(object sender, EventArgs e)
        {

        }
        #endregion ARROWS
        #region METODOS
        #endregion METODOS
    }
}
