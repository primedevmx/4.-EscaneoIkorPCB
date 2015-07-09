using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Net.Mail;
using System.Windows.Forms;

namespace EscaneoIkor.Seguridad
{
    public partial class frmUsuarios : Form
    {
        #region GLOBALES
        mSeguridad _mSecurity = new mSeguridad();
        DataSet _dsMain = new DataSet();
        DataRow _dROBDs = null;
        #endregion GLOBALES
        #region CONSTRUCTORES
        public frmUsuarios(mSeguridad _mSec)
        {
            InitializeComponent();
            _mSecurity = _mSec;
            btnActPass.Enabled = false;

        }
        #endregion CONSTRUCTORES
        #region METODOS
        private void vCargarInfo()
        {
            try
            {
                //Grid->>
                _mSecurity.vchUsuario = "";
                _mSecurity.vchPassword = "";
                _mSecurity.intAccion = 2;
                _dsMain = _mSecurity.dsSeguridad_sp_MtoUsuarios();
                uctrlTablaConFiltro1.DataSource = _dsMain.Tables[0].Copy();
                //ConfGrid->>
                uctrlTablaConFiltro1.gridDatos.AutoSizeColumnsMode
                    = DataGridViewAutoSizeColumnsMode.Fill;

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

                //Ocultar id->>
                uctrlTablaConFiltro1.gridDatos.Columns["idUsuario"].Visible = false;

                //Combo->>
                cmbTipoUsuario.DataSource = _dsMain.Tables[1].Copy();
                cmbTipoUsuario.ValueMember = "idTipoUsuario";
                cmbTipoUsuario.DisplayMember = "vchNombre";
                cmbTipoUsuario.SelectedIndex = -1;
            }
            catch { }

        }
        private void vLimpiarPantalla()
        {
            tsbEliminar.Visible = false;
            tsbModificar.Visible = false;
            tsbGuardar.Visible = true;
            txtNombre.Text = "";
            txtUsuario.Text = "";
            cmbEstatus.SelectedIndex = -1;
            cmbTipoUsuario.SelectedIndex = -1;
            btnActPass.Enabled = false;
            txtCorreoElectronico.Text = "";

            _dROBDs = null;
            vCargarInfo();
        }
        private bool bValidarDatos(out string err)
        {
            err = "";
            if (txtNombre.Text == "") { err = "Debe especificar el Nombre del Usuario."; }
            else if (txtUsuario.Text == "") { err = "Debe especificar el Usuario de Inicio de Sesion."; }
            else if (cmbEstatus.Text == "") { err = "Debe especificar el Estatus."; }
            else if (cmbTipoUsuario.Text == "") { err = "Debe especificar el tipo de Usuario."; }
            else if (txtCorreoElectronico.Text == "") { err = "Debe especificar el correo electronico de Usuario."; }

            return (err == "");
        }
        private int intIdTipoUsuario(string str)
        {
            int intRet = -1;
            try
            {
                DataTable dt = _dsMain.Tables[1].Select("vchNombre ='" + str + "'").CopyToDataTable();
                intRet = Convert.ToInt32(dt.Rows[0][0].ToString());
            }
            catch {            
            }

            return intRet;
        }
        private void fn_envioCorreoAutomatizado(string strMsgErr)
        {
            try
            {
                char[] cCut = { ',', ';', ':', '-', ' ' };
                string[] strPara = txtCorreoElectronico.Text.Trim().Split(cCut);

                foreach (string strDato in strPara)
                {
                    string strMssg =
                          "<!DOCTYPE HTML PUBLIC \"-//W3C//DTD HTML 4.0 Transitional//EN\">"
                        + "<HTML><HEAD><META http-equiv=Content-Type content=\"text/html; charset=iso-8859-1\">"
                        + "</HEAD>"
                        + "<BODY>"
                            + "<table align = 'center' width = 1200>"
                                + "<tr><td><font size = '3' face = 'Calibri'>Buen D&iacute;a,</font> <b>" + strDato + "</b> </td>"
                                + "<td align = 'right'><font size = '2' face = 'Calibri'>" + DateTime.Now.ToString("D") + "</font></td></tr>"
                            + "</table>"
                            + "<p><font size = '3' face = 'Calibri'>"
                                + "Por medio de la presente, se notifica que se ha generado satisfactoriamente su cuenta de usuario en el [Sistema de Escaneo Ikor], "
                                + "<br> </br>"
                                + "<br>Datos de la cuenta: </br>"
                                + "<br>" + strMsgErr + "</br>"
                            + "</font></p>"
                            + "<p><font size = '3' face = 'Calibri'>"
                                + "[Sistema de Escaneo Ikor]."
                            + "</font></p>"
                            + "<p><font size = '1' face = 'Calibri'>"
                                + "<hr color = #E46C0A>"
                                + "Correo generado autom&aacute;ticamente desde el [Sistema de Escaneo Ikor]."
                            + "</font></p>"
                        + "</BODY>";

                    MailMessage message = new MailMessage();
                    MailAddress fromAddress = new MailAddress(Properties.Settings.Default.strCuentaEmisora);
                    MailAddress toAddress = new MailAddress(strDato, "");
                    message.From = fromAddress;
                    message.To.Add(toAddress);
                    message.Subject = "Sistema Escaneo Ikor - Cuenta del Sistema";
                    message.Body = strMssg;
                    System.Net.Mime.ContentType mType = new System.Net.Mime.ContentType("text/html");
                    System.Net.Mail.AlternateView mView = System.Net.Mail.AlternateView.CreateAlternateViewFromString(strMssg, mType);
                    message.AlternateViews.Add(mView);
                    message.Priority = System.Net.Mail.MailPriority.High;
                    SmtpClient smtpClient = new SmtpClient();
                    smtpClient.Host = "smtp.gmail.com";
                    smtpClient.Port = 587;
                    smtpClient.Credentials = new System.Net.NetworkCredential(Properties.Settings.Default.strCuentaEmisora, Properties.Settings.Default.strContrasenaEmisora);
                    smtpClient.EnableSsl = true;
                    smtpClient.Send(message);
                }

            }
            catch
            {
            }
        }
        #endregion METODOS
        #region EVENTOS
        private void frmUsuarios_Load(object sender, EventArgs e)
        {
            vCargarInfo();
        }
        private void tsbLimpiar_Click(object sender, EventArgs e)
        {
            vLimpiarPantalla();
        }
        private void tsbCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }
        private void tsbGuardar_Click(object sender, EventArgs e)
        {
            DataSet dsGuardarUsr = new DataSet();

            try
            {
                //Previa Validacion ->>
                if (_dROBDs != null)
                {
                    return;
                }

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
                _mSecurity.vchUsuario = txtUsuario.Text.Trim();
                _mSecurity.vchNombreUsuario = txtNombre.Text.Trim();
                _mSecurity.vchCorreoElectronico = txtCorreoElectronico.Text.Trim();
                _mSecurity.vchStatus = cmbEstatus.Text.Trim();
                _mSecurity.idTipoUsuario = Convert.ToInt32(cmbTipoUsuario.SelectedValue);
                _mSecurity.intAccion = 3;

                //Password->>
                if (cmbTipoUsuario.Text.Trim() == "OPERADOR")
                {
                    _mSecurity.vchPassword = "";
                }
                else {                    
                    int intC = txtNombre.Text.Length;
                    _mSecurity.vchPassword = "";
                    _mSecurity.vchPassword = txtNombre.Text.Substring(0, 3) + txtNombre.Text.Substring(intC - 3, 2 ) + "_" +
                        cmbTipoUsuario.Text.Substring(0, 3) + "00" + DateTime.Now.ToShortTimeString(); 
                }

                //MTO->>
                dsGuardarUsr = _mSecurity.dsSeguridad_sp_MtoUsuarios();

                if ((dsGuardarUsr != null && dsGuardarUsr.Tables[0].Rows.Count > 0) && dsGuardarUsr.Tables[0].Rows[0][0].ToString().Trim() == "1")
                {
                    //Correo->>
                    if (cmbTipoUsuario.Text.Trim() != "OPERADOR")
                    {
                        fn_envioCorreoAutomatizado("Cuenta de usuario: <b>" +
                            txtUsuario.Text.Trim() + "</b> con el password: <b>" + _mSecurity.vchPassword + "</b>");
                    }

                    vLimpiarPantalla();

                    MessageBox.Show("Operación realizada satisfactoriamente. \n - Puede usted continuar. ", "Mensaje del Sistema"
                                           , MessageBoxButtons.OK, MessageBoxIcon.Information);

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
        private void uctrlTablaConFiltro1_GridDatos_DoubleClick(object sender, uctrlTablaConFiltro.GridDatos_DoubleClickEnventArgs e)
        {
            _dROBDs = ((DataRowView)uctrlTablaConFiltro1.gridDatos.CurrentRow.DataBoundItem).Row;

            if (_dROBDs != null)
            {
                tsbEliminar.Visible = true;
                tsbModificar.Visible = true;
                tsbGuardar.Visible = false;
                btnActPass.Enabled = true;

                //Asig de Valores->>
                txtNombre.Text = _dROBDs["Nombre Usuario"].ToString();
                txtUsuario.Text = _dROBDs["vchUsuario"].ToString();
                txtCorreoElectronico.Text = _dROBDs["vchCorreoElectronico"].ToString();
                cmbEstatus.Text = _dROBDs["vchStatus"].ToString();
                cmbTipoUsuario.SelectedValue = intIdTipoUsuario(_dROBDs["Tipo Usuario"].ToString().Trim());


            }
        }
        private void btnActPass_Click(object sender, EventArgs e)
        {
            //Previa Validacion ->>
            if (_dROBDs == null)
            {
                return;
            }

            Seguridad.frmActualizaContraseña FRM = new frmActualizaContraseña(_dROBDs[1].ToString().Trim(), Convert.ToInt32(_dROBDs[0].ToString().Trim()));
            FRM.ShowDialog();

            if (FRM._intCloseUser != 1)
            {
                vLimpiarPantalla();
            }


        }
        private void tsbModificar_Click(object sender, EventArgs e)
        {
            DataSet dsModUsr = new DataSet();

            try
            {
                //Previa Validacion ->>
                if (_dROBDs == null)
                {
                    return;
                }

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
                _mSecurity.idUsuario = Convert.ToInt32(_dROBDs[0].ToString().Trim());
                _mSecurity.vchUsuario = txtUsuario.Text.Trim();
                _mSecurity.vchNombreUsuario = txtNombre.Text.Trim();
                _mSecurity.vchCorreoElectronico = txtCorreoElectronico.Text.Trim();
                _mSecurity.vchStatus = cmbEstatus.Text.Trim();
                _mSecurity.idTipoUsuario = Convert.ToInt32(cmbTipoUsuario.SelectedValue);
                _mSecurity.intAccion = 4;

                //MTO->>
                dsModUsr = _mSecurity.dsSeguridad_sp_MtoUsuarios();

                if ((dsModUsr != null && dsModUsr.Tables[0].Rows.Count > 0) && dsModUsr.Tables[0].Rows[0][0].ToString().Trim() == "1")
                {
                    vLimpiarPantalla();

                    MessageBox.Show("Operación realizada satisfactoriamente. \n - Puede usted continuar. ", "Mensaje del Sistema"
                                           , MessageBoxButtons.OK, MessageBoxIcon.Information);

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
        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            DataSet dsDelUsr = new DataSet();

            try
            {
                //Previa Validacion ->>
                if (_dROBDs == null)
                {
                    return;
                }


                DialogResult _DR = MessageBox.Show("- ¿Está seguro de eliminar el usuario?",
                                "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (_DR == DialogResult.No)
                {
                    return;
                }

                Cursor.Current = Cursors.WaitCursor;

                //Valores->>
                _mSecurity.idUsuario = Convert.ToInt32(_dROBDs[0].ToString().Trim());
                _mSecurity.vchUsuario = txtUsuario.Text.Trim();
                _mSecurity.vchNombreUsuario = txtNombre.Text.Trim();
                _mSecurity.vchStatus = cmbEstatus.Text.Trim();
                _mSecurity.idTipoUsuario = Convert.ToInt32(cmbTipoUsuario.SelectedValue);
                _mSecurity.intAccion = 6;

                //MTO->>
                dsDelUsr = _mSecurity.dsSeguridad_sp_MtoUsuarios();

                if ((dsDelUsr != null && dsDelUsr.Tables[0].Rows.Count > 0) && dsDelUsr.Tables[0].Rows[0][0].ToString().Trim() == "1")
                {
                    vLimpiarPantalla();

                    MessageBox.Show("Operación realizada satisfactoriamente. \n - Puede usted continuar. ", "Mensaje del Sistema"
                                           , MessageBoxButtons.OK, MessageBoxIcon.Information);

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
        #endregion EVENTOS
    }
}
