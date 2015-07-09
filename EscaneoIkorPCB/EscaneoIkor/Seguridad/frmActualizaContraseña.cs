using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EscaneoIkor.Seguridad
{
    public partial class frmActualizaContraseña : Form
    {
        #region GLOBALES
        mSeguridad _mSecurity = new mSeguridad();
        DataSet _dsMain = new DataSet();
        DataRow _dROBDs = null;
        private int _idUsuario = -1;
        public int _intCloseUser = -1;
        private bool _bLogin = false;
        #endregion GLOBALES
        #region CONSTRUCTORES
        public frmActualizaContraseña()
        {
            InitializeComponent();
        }
        public frmActualizaContraseña(string strNombreUsuario, int idUsuario)
        {
            InitializeComponent();
            txtUsuario.Text = strNombreUsuario;
            _idUsuario = idUsuario;
            this.Text = "Actualiza la contraseña del usuario : " + strNombreUsuario;
        }
        public frmActualizaContraseña(string strNombreUsuario, int idUsuario,bool bLogin)
        {
            InitializeComponent();
            txtUsuario.Text = strNombreUsuario;
            _idUsuario = idUsuario;
            this.Text = "Actualiza la contraseña del usuario : " + strNombreUsuario;
            _bLogin = bLogin;
        }
        #endregion CONSTRUCTORES
        #region EVENTOS
        private void tsbCerrar_Click(object sender, EventArgs e)
        {
            _intCloseUser = 1;
            this.Close();
            this.Dispose();
        }
        private void txtPass2_TextChanged(object sender, EventArgs e)
        {
            if (txtPass1.Text.Trim() == txtPass2.Text.Trim())
            {
                label5.Visible = true;
            }
            else {
                label5.Visible = false;                
            }
        }
        private void btnActPass_Click(object sender, EventArgs e)
        {
            DataSet dsModUsr = new DataSet();

            try
            {
                //Previa Validacion ->>
                string error;
                if (!bValidarDatos(out error))
                {
                    MessageBox.Show(error, "Validar Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DialogResult _DR = MessageBox.Show("- ¿Está correcta la información?",
                                "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (_DR == DialogResult.No)
                {
                    return;
                }

                Cursor.Current = Cursors.WaitCursor;

                //Valores->>
                _mSecurity.idUsuario = _idUsuario;
                _mSecurity.vchPassword = txtPass1.Text.Trim();
                _mSecurity.intAccion = 5;

                //MTO->>
                dsModUsr = _mSecurity.dsSeguridad_sp_MtoUsuarios();

                if ((dsModUsr != null && dsModUsr.Tables[0].Rows.Count > 0) && dsModUsr.Tables[0].Rows[0][0].ToString().Trim() == "1")
                {
                    vLimpiarPantalla();

                    MessageBox.Show("Operación realizada satisfactoriamente. \n - Puede usted continuar. ", "Mensaje del Sistema"
                                           , MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //Actualiza Verificacion para Login->
                    if (_bLogin)
                    {
                        _mSecurity.idUsuario = _idUsuario;
                        _mSecurity.intAccion = 7;

                        //MTO->>
                        dsModUsr = _mSecurity.dsSeguridad_sp_MtoUsuarios();
                        if ((dsModUsr == null && dsModUsr.Tables[0].Rows.Count > 0) && dsModUsr.Tables[0].Rows[0][0].ToString().Trim() == "0")
                        {
                            MessageBox.Show("Oops ha ocurrido un error [:(] . \n - Por favor verifique. ", "Mensaje del Sistema"
                                           , MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }
                    
                    //Cerrar->
                    this.Close();
                    this.Dispose();
                }
                else
                {

                    MessageBox.Show("Oops ha ocurrido un error [:(] . \n - Por favor verifique. ", "Mensaje del Sistema"
                                           , MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                Cursor.Current = Cursors.Arrow;

            }
            catch (Exception EX)
            {
                MessageBox.Show("Connect BD Fail: <<- \n " + EX.Message, "Atención"
                                      , MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void txtPass2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnActPass_Click(null, null);
            }
        }
        #endregion EVENTOS
        #region METODOS
        private void vLimpiarPantalla()
        {
            txtPass1.Text = "";
            txtPass2.Text = "";
            label5.Visible = false;
        }
        private bool bValidarDatos(out string err)
        {
            err = "";
            if (txtPass1.Text == "") { err = "Debe especificar la contraseña del usuario."; }
            else if (txtPass2.Text == "") { err = "Debe especificar la contraseña."; }
            else if (txtPass1.Text.Trim() != txtPass2.Text.Trim()) { err = "Las contraseñas no coinciden, por favor verifique."; }

            return (err == "");
        }  
        #endregion METODOS       
    }
}
