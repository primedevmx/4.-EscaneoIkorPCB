using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Net.Mail;
using System.Windows.Forms;

namespace EscaneoIkor.Configuracion
{
    public partial class frmMonitores : Form
    {
        #region PROPIEDADES
        mSeguridad _mSecurity = new mSeguridad();
        #endregion PROPIEDADES
        #region CONSTRUCTORES

        public frmMonitores()
        {
            InitializeComponent();
        }

        #endregion CONSTRUCTORES
        #region SQL

        private void tsbCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void frmMonitores_Load(object sender, EventArgs e)
        {
            string strConvert2 = Convert.ToString(Convert.ToDecimal(Properties.Settings.Default.strMiliTimerConnSQL) / 60000);
            numericCorreoSQL.Value = Convert.ToDecimal(strConvert2);

            string strConvert3 = Convert.ToString(Convert.ToDecimal(Properties.Settings.Default.strMiliTimerConnExcel) / 60000);
            numericEXCEL.Value = Convert.ToDecimal(strConvert3);

            string strConvert4 = Convert.ToString(Convert.ToDecimal(Properties.Settings.Default.strMiliTimerConnXML) / 60000);
            numericXML.Value = Convert.ToDecimal(strConvert4);

            TSBTN_STOP_SQL_Click(null, null);
       
        }
        
        private void TSBTN_START_SQL_Click(object sender, EventArgs e)
        {
            #region VENTANA
            tsbEstatusDaemon_SQL.Text = " Estatus - Activado <- ";
            tsbEstatusDaemon_SQL.ForeColor = Color.LightGreen;
            TSBTN_START_SQL.Enabled = false;
            TSBTN_STOP_SQL.Enabled = true;
            #endregion VENTANA

            //Timer->>
            vInicioTimerMonitorConnSQL();
        }

        private void TSBTN_STOP_SQL_Click(object sender, EventArgs e)
        {
            #region VENTANA
            TSBTN_START_SQL.Enabled = true;
            tsbEstatusDaemon_SQL.Text = " Estatus - Detenido <- ";
            tsbEstatusDaemon_SQL.ForeColor = Color.White;
            TSBTN_STOP_SQL.Enabled = false;
            #endregion VENTANA

            vFinTimerMonitorConnSQL();
        }

        private void btnGuardar_SQLSERVER_Click(object sender, EventArgs e)
        {
            string strCOnvert = Convert.ToString(Convert.ToDecimal(numericCorreoSQL.Value) * 60000);

            Properties.Settings.Default.strMiliTimerConnSQL = strCOnvert;
            Properties.Settings.Default.Save();

            MessageBox.Show("Se ha registrado correctamente la cuenta de [Correo Electronico] SQL. \n \n - Puede usted continuar. ", "Atención"
                    , MessageBoxButtons.OK, MessageBoxIcon.Question);  
        }

        private void vInicioTimerMonitorConnSQL()
        {
            timerMonitorConexionSQL.Start();
            timerMonitorConexionSQL.Enabled = true;
            timerMonitorConexionSQL.Interval = Convert.ToInt32(Properties.Settings.Default.strMiliTimerConnSQL);
        }

        private void vFinTimerMonitorConnSQL()
        {
            timerMonitorConexionSQL.Stop();
            timerMonitorConexionSQL.Enabled = false;
            timerMonitorConexionSQL.Interval = Convert.ToInt32(Properties.Settings.Default.strMiliTimerConnSQL);
        }

        private void OnTimer_timerMonitorConexion_SQL_Event(object sender, EventArgs e)
        {
            DataSet dsReturn = new DataSet("ParametrosAPP");
            string strCommand = "";
            string strSalida = "";

            strCommand = "SELECT TOP 1 * FROM [dbo].[Scaneo_tblDataMatrix]";


            Cursor.Current = Cursors.WaitCursor;

            try
            {
                //Consulta->>
                dsReturn =
                    Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(_mSecurity.strConnSQL, CommandType.Text, strCommand);


                if (dsReturn.Tables[0].Rows.Count > 0)
                {
                    //ok->>
                }

            }
            catch (Exception EX)
            {
                dsReturn = null;
                strSalida = EX.Message + " \r\n \r\n "
                    + " \r\n \r\n - Verifique la configuracion de los parametros del servidor sql.";

                //Envia correo error en la conexion->>
                fn_envioCorreoAutomatizado(strSalida);

                //Se detiene el monitor para evitar que se sigan enviando correos ->>
                timerMonitorConexionSQL.Stop();
                timerMonitorConexionSQL.Enabled = false;

                //De detiene el daemon ->>
                TSBTN_STOP_SQL_Click(null, null);


            }
        }

        #endregion SQL
        #region METODOS

        private void fn_envioCorreoAutomatizado(string strMsgErr)
        {
            try
            {
                char[] cCut = { ',', ';', ':', '-', ' ' };
                string[] strPara = Properties.Settings.Default.strCuentaReceptora.ToString().Split(cCut);

                foreach (string strDato in strPara)
                {
                    string strMssg =
                          "<!DOCTYPE HTML PUBLIC \"-//W3C//DTD HTML 4.0 Transitional//EN\">"
                        + "<HTML><HEAD><META http-equiv=Content-Type content=\"text/html; charset=iso-8859-1\">"
                        + "</HEAD>"
                        + "<BODY>"
                            + "<table align = 'center' width = 1200>"
                                + "<tr><td><font size = '3' face = 'Calibri'>Buen D&iacute;a,</font> " + strDato + " </td>"
                                + "<td align = 'right'><font size = '2' face = 'Calibri'>" + DateTime.Now.ToString("D") + "</font></td></tr>"
                            + "</table>"
                            + "<p><font size = '3' face = 'Calibri'>"
                                + "Por medio de la presente, se notifica que se ha perdido la conexion con el servidor, "
                                + "<br>y por consiguiente el [Sistema Escaneo Ikor] ha sido detenido. " + DateTime.Now.ToString() + ".</br>"
                                + "<br> </br>"
                                + "<br> Mensaje del error: </br>"
                                + "<br>" + strMsgErr + "</br>"
                            + "</font></p>"
                            + "<p><font size = '3' face = 'Calibri'>"
                                + "[Daemon Ikor]."
                            + "</font></p>"
                            + "<p><font size = '1' face = 'Calibri'>"
                                + "<hr color = #E46C0A>"
                                + "Correo generado autom&aacute;ticamente desde el [Daemon Ikor]."
                            + "</font></p>"
                        + "</BODY>";

                    MailMessage message = new MailMessage();
                    MailAddress fromAddress = new MailAddress(Properties.Settings.Default.strCuentaEmisora);
                    MailAddress toAddress = new MailAddress(strDato, "");
                    message.From = fromAddress;
                    message.To.Add(toAddress);
                    message.Subject = "Daemon Ikor - Sistema de Escaneo Ikor Detenido";
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
        private void btnMGExcel_Click(object sender, EventArgs e)
        {
            string strCOnvert = Convert.ToString(Convert.ToDecimal(numericEXCEL.Value) * 60000);

            Properties.Settings.Default.strMiliTimerConnExcel = strCOnvert;
            Properties.Settings.Default.Save();

            MessageBox.Show("Se ha registrado correctamente el timer de Excel. \n \n - Puede usted continuar. ", "Atención"
                    , MessageBoxButtons.OK, MessageBoxIcon.Question);  
        }

        private void btnMGXml_Click(object sender, EventArgs e)
        {
            string strCOnvert = Convert.ToString(Convert.ToDecimal(numericXML.Value) * 60000);

            Properties.Settings.Default.strMiliTimerConnXML = strCOnvert;
            Properties.Settings.Default.Save();

            MessageBox.Show("Se ha registrado correctamente el timer de XML. \n \n - Puede usted continuar. ", "Atención"
                    , MessageBoxButtons.OK, MessageBoxIcon.Question);
        }
        #endregion EVENTOS

   }
}
