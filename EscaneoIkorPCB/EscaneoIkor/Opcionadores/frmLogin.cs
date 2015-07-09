using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace EscaneoIkor
{
    /// <summary>
    /// Autor: 
    ///     Miguel Gutierrez Arroyo
    /// Fecha: 
    ///     2014/05/06
    /// 
    /// Descripcion: 
    ///     Login de la Aplicacion
    /// Acciones: 
    ///     Login
    /// 
    /// </summary> 
    public partial class frmLogin : Form
    {
        #region CONSTRUCTORES
        public frmLogin()
        {
            InitializeComponent();
            txtUsuario.Text = Properties.Settings.Default.LastUser;
        }
        #endregion CONSTRUCTORES
        #region PROPIEDADES
        bool _bAutentica = false;
        bool _bDev = false;
        mSeguridad _mSecurity;
        string _strConnFirebid = "";
        DataSet _dsAutenticacion;
        #endregion PROPIEDADES
        #region EVENTOS
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            _bAutentica = false;
            _bDev = false;
            _mSecurity = new mSeguridad();
            _mSecurity.bUsuarioAdmin = false;
            _mSecurity.bUsuarioProduc = false;
            _dsAutenticacion = new DataSet();

            //Versión Desarrollo-->
            if (txtPassword.Text == System.Configuration.ConfigurationSettings.AppSettings["DevPassKey"])
            {
                _bAutentica = true;
                _bDev = true;
                _mSecurity.bUsuarioAdmin = true;
            }

            //Consulta->
            _mSecurity.vchUsuario = txtUsuario.Text.Trim();
            _mSecurity.vchPassword = txtPassword.Text.Trim();
            _mSecurity.intAccion = 1;

            _dsAutenticacion =
                _mSecurity.dsValidaAutenticacion();
            
            if (!_bDev)
            {
                if (_dsAutenticacion.Tables[0].Rows.Count == 0)
                {
                    MessageBox.Show("Favor de verificar su [Cuenta de Usuario] y [Contraseña].", "Atención"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else { _bAutentica = true; }
            }

            //Autenticacion->>
            if (_bAutentica)
            {       
                try
                {
                    //Cuenta en BD->>
                    if (_dsAutenticacion.Tables[1].Rows.Count == 0)
                    {
                        MessageBox.Show("Favor de verificar su [Cuenta de Usuario] ya que no existe en el sistema.", "Atención"
                            , MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    //Cuenta Activa->>
                    if (_dsAutenticacion.Tables[1].Rows[0]["vchStatus"].ToString().Trim() != "ACT")
                    {
                        MessageBox.Show("Favor de verificar su [Cuenta de Usuario] con el administrador del sistema, su cuenta se encuentra suspendida."
                            , "Atención" , MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    //Previa Validacion-->
                    //Oper->>
                    if (_dsAutenticacion.Tables[1].Rows[0]["idTipoUsuario"].ToString().Trim() == "3")
                    {

                        if (string.IsNullOrEmpty(txtUsuario.Text))
                        {
                            txtPassword.Text = string.Empty;
                            txtUsuario.Focus();
                            txtUsuario.SelectAll();
                            MessageBox.Show("Favor de verificar su [Cuenta de Usuario] y [Contraseña].", "Atención"
                                , MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                    }
                    else
                    {
                        //Admin->>
                        if (string.IsNullOrEmpty(txtUsuario.Text) || string.IsNullOrEmpty(txtPassword.Text))
                        {
                            txtPassword.Text = string.Empty;
                            txtUsuario.Focus();
                            txtUsuario.SelectAll();
                            MessageBox.Show("Favor de verificar su [Cuenta de Usuario] y [Contraseña].", "Atención"
                                , MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                    }

                        #region DATOS SEGURIDAD
                        _mSecurity.idUsuario = Convert.ToInt32(_dsAutenticacion.Tables[1].Rows[0]["idUsuario"].ToString().Trim());
                        _mSecurity.vchUsuario = _dsAutenticacion.Tables[1].Rows[0]["vchUsuario"].ToString().Trim();
                        _mSecurity.vchUsuarioSistema = _dsAutenticacion.Tables[1].Rows[0]["vchUsuario"].ToString().Trim();
                        _mSecurity.vchNombreUsuario = _dsAutenticacion.Tables[1].Rows[0]["vchNombreUsuario"].ToString().Trim();
                        _mSecurity.vchPassword = _dsAutenticacion.Tables[1].Rows[0]["vchPassword"].ToString().Trim();
                        _mSecurity.vchStatus = _dsAutenticacion.Tables[1].Rows[0]["vchStatus"].ToString().Trim();
                        _mSecurity.idTipoUsuario = Convert.ToInt32(_dsAutenticacion.Tables[1].Rows[0]["idTipoUsuario"].ToString().Trim());
                        _mSecurity.vchTipoUsuario = _dsAutenticacion.Tables[1].Rows[0]["vchTipoUsuario"].ToString().Trim();
                        #endregion DATOS SEGURIDAD

                        //Admin->>
                        if (_dsAutenticacion.Tables[1].Rows[0]["idTipoUsuario"].ToString().Trim() == "1")
                        {
                            _mSecurity.bUsuarioAdmin = true;
                        }
                        else
                        {
                            //Product-->
                            _mSecurity.bUsuarioProduc = true;
                        }

                                
                    
                }
                catch (Exception EX)
                {
                    MessageBox.Show("Connect BD Fail: \n - " + EX.Message, "Atención"
                                , MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            //Show-->
            if (_bAutentica)
            {   
                //Actualiza Contraseña->>
                if (Convert.ToBoolean(_dsAutenticacion.Tables[1].Rows[0]["bitVerificacion"]))
                {
                    this.Visible = false;
                    this.ShowInTaskbar = false;

                    Seguridad.frmActualizaContraseña FRM = new Seguridad.frmActualizaContraseña(_mSecurity.vchUsuario, _mSecurity.idUsuario,true);
                    FRM.ShowDialog();

                    if (FRM._intCloseUser == 1)
                    {
                        MessageBox.Show("Para acceder por primera vez al [Sistema], primero debe actualizar su [Contraseña].", "Atención"
                            , MessageBoxButtons.OK, MessageBoxIcon.Question);

                        this.Close();
                        this.Dispose();
                        return;
                    }
                }

                #region LASTUSER
                //LastUser->
                _mSecurity.vchUsuarioSistema = txtUsuario.Text.Trim();
                try
                {

                    Properties.Settings.Default.LastUser = txtUsuario.Text.Trim();
                    Properties.Settings.Default.Save();
                }
                catch { }
                #endregion LASTUSER

                //Iniciamos Sistema->
                Opcionadores.frmPrincipal frmPpal = new Opcionadores.frmPrincipal(_mSecurity);
                frmPpal.Show();
                this.Visible = false;
                this.ShowInTaskbar = false;
                
            }
            else
            {
                MessageBox.Show("Favor de verificar su [Cuenta de Usuario] y [Contraseña].", "Atención"
                    , MessageBoxButtons.OK, MessageBoxIcon.Question);
                return;
            }

        }    
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void frmLogin_Load(object sender, EventArgs e)
        {            
            try
            {
                //txtUsuario.Text = clSeguridad.strLeerRegistro("LastUser");
            }
            catch { }
            if (string.IsNullOrEmpty(txtUsuario.Text))
            {
                //txtUsuario.Text = Environment.UserName;
            }
            txtPassword.Focus();
            try
            {
                lblVersion.Text += " " + System.Deployment.Application.ApplicationDeployment.CurrentDeployment.CurrentVersion;
            }
            catch
            {
                lblVersion.Text += " Desarrollo";
            }       

        }
        private void txtUsuario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnAceptar_Click(null,null);
            }
        }
        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnAceptar_Click(null, null);

            }
        }  
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.M))
            {
                SqlServer.frmServidorSqlServer _FRM = new SqlServer.frmServidorSqlServer();
                _FRM.ShowDialog();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        #endregion EVENTOS
        #region METODOS
        #endregion METODOS        
    }
}