using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using Microsoft.Win32;
using System.Diagnostics;
using System.Windows.Forms;
using System.Net.Mail;

namespace EscaneoIkor.Excel
{
    public partial class frmProcesarExcel : Form
    {
        #region PROPIEDADES
        System.Data.DataTable _dtTempArchivosProc = null;
        mSeguridad _mSecurity = new mSeguridad();
        cExcel _mExcel = new cExcel();
        #endregion PROPIEDADES
        #region CONSTRUCTORES
        public frmProcesarExcel(mSeguridad mSec)
        {
            InitializeComponent();
            _mSecurity = mSec;
        }
        public frmProcesarExcel()
        {
            InitializeComponent();
        }
        #endregion CONSTRUCTORES
        #region EVENTOS
        #region VENTANA
        private void frmConfiguracion_Load(object sender, EventArgs e)
        {
            vCargar();
            //GroupBox->>
            groupBox6.Text = "Bitácora del proceso -> Reporitorio -> [" + Properties.Settings.Default.strRepoExcel + "]";

            if (Properties.Settings.Default.cModoExcel == "M")
            {
                rbtnManual.Checked = true;
            }
            else if (Properties.Settings.Default.cModoExcel == "A")
            {
                rbtnAutomatico.Checked = true;
            }

            TSBTN_STOP_Click(null,null);

        }
        //Monitor de la conexion->>
        private void OnTimer_timerMonitorConexion_Event(object sender, EventArgs e)
        {
            ExtraerFicherorDelSubDirectorio(Properties.Settings.Default.strRepoExcel);

            //Leer Excel->
            DataSet DS_EXCEL = new DataSet();
            try
            {
                foreach (DataRow DR in _dtTempArchivosProc.Rows)
                {
                    DS_EXCEL = _mExcel.LeerExcel_DS(Properties.Settings.Default.strRepoExcel +"//"+DR[0].ToString().Trim());

                    foreach (DataTable DT_TEMP_XLS in DS_EXCEL.Tables)
                    {
                        foreach (DataRow DR_TEMP_XLS in DT_TEMP_XLS.Rows)
                        {
                            //Mto Excel->>
                            _mExcel.intOP = Convert.ToInt32(DR_TEMP_XLS["n_of"]);
                            _mExcel.intProd = Convert.ToInt32(DR_TEMP_XLS["cod_art"]);

                            //Bin->>
                            string[] strBin = Convert.ToString(DR_TEMP_XLS["descrip"]).Trim().Split('-');
                            if (strBin.Length > 1)
                            {
                                _mExcel.vchBin1 = strBin[0];
                                _mExcel.vchBin2 = strBin[1];
                                _mExcel.vchBin3 = strBin[2];
                            }
                            else
                            {
                                continue;
                            }

                            _mExcel.intAccion = 1;
                            DataSet DS_OP = _mExcel.dsScaneo_sp_MtoExcel();



                        }//END_DATAROW_XLS <=

                    }//END_DATATABLE_XLS <=

                    if (Convert.ToBoolean(Properties.Settings.Default.bAplicaResp))
                    {
                        //Move File->
                        if (Convert.ToBoolean(Properties.Settings.Default.bAplicaResp))
                        {
                            //Move File->
                            System.IO.File.Move(Properties.Settings.Default.strRepoExcel + "//" + DR[0].ToString().Trim()
                                , Properties.Settings.Default.strRespaldoSQL + "//" + DR[0].ToString().Trim());
                        }
                    }

                }//END_DATASET_XLS <=      

            }
            catch { }           


            vCargar();
        }
    
        private void ExtraerFicherorDelSubDirectorio(string ruta)
        {
            System.IO.DirectoryInfo oDirectorio = new System.IO.DirectoryInfo(ruta);
            //Limpiar->>
            tsbLimpiar_Click(null, null);
            //Tabla Temporal->>
            _dtTempArchivosProc = new System.Data.DataTable("ArchivosProcesar");
            System.Data.DataColumn dC = new DataColumn("Archivo(s)_a_procesar");
            _dtTempArchivosProc.Columns.Add(dC);

            //obtengo ls ficheros contenidos en la ruta
            foreach (System.IO.FileInfo file in oDirectorio.GetFiles())
            {
                DataRow dR = _dtTempArchivosProc.NewRow();
                dR[0] = file.Name;
                _dtTempArchivosProc.Rows.Add(dR);
                txtArchivo.Text += file.Name + ";";

            }
        }
        private void rbtnManual_CheckedChanged(object sender, EventArgs e)
        {
            panelAutomatico.Visible = false;
            panelManual.Visible = true;
            Properties.Settings.Default.cModoExcel = "M";
            Properties.Settings.Default.Save();
            tsbLimpiar_Click(null,null);
        }
        private void rbtnAutomatico_CheckedChanged(object sender, EventArgs e)
        {
            panelManual.Visible = false;
            panelAutomatico.Visible = true;
            Properties.Settings.Default.cModoExcel = "A";
            Properties.Settings.Default.Save();
            ExtraerFicherorDelSubDirectorio(Properties.Settings.Default.strRepoExcel);

        }
        private void tsbCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }
        #endregion VENTANA
        #region MANUAL
        private void btnSeleccionarArchivos_Click(object sender, EventArgs e)
        {
            //Limpiar->>
            tsbLimpiar_Click(null,null);
            //Tabla Temporal->>
            _dtTempArchivosProc = new System.Data.DataTable("ArchivosProcesar");
            System.Data.DataColumn dC = new DataColumn("Archivo(s)_a_procesar");
            _dtTempArchivosProc.Columns.Add(dC);

            //Dialog prop->>
            dlAbrir.CheckFileExists = true;
            dlAbrir.CheckPathExists = true;
            dlAbrir.Multiselect = true;
            dlAbrir.DefaultExt = "xlsx";
            dlAbrir.FileName = "";
            dlAbrir.Filter = "Archivos Excel (*.xlsx)|*.xlsx|2010 Files (*.xls)|*.xls";
            dlAbrir.Title = "Seleccionar fichero EXCEL a dividir y separar páginas";

            //Dialog->>
            if (dlAbrir.ShowDialog() == DialogResult.OK)
            {
                foreach (string str in dlAbrir.FileNames)
                {
                    DataRow dR = _dtTempArchivosProc.NewRow();
                    dR[0] = str;
                    _dtTempArchivosProc.Rows.Add(dR);
                    txtArchivo.Text += str + ";";
                }
            }

        }
        private void tsbProcesar_Click(object sender, EventArgs e)
        {
            if (txtArchivo.Text == "")
            {
                //Salida-->
                MessageBox.Show("Para Leer el Excel primero debe seleccionar uno o varios archivos, puede usted continuar.",
                         "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //Leer Excel->
            DataSet DS_EXCEL = new DataSet();
            try
            {
                foreach (DataRow DR in _dtTempArchivosProc.Rows)
                {
                    DS_EXCEL = _mExcel.LeerExcel_DS(DR[0].ToString().Trim());
                    
                    foreach (DataTable DT_TEMP_XLS in DS_EXCEL.Tables)
                    {
                        foreach (DataRow DR_TEMP_XLS in DT_TEMP_XLS.Rows)
                        { 
                            //Mto Excel->>
                            _mExcel.intOP = Convert.ToInt32(DR_TEMP_XLS["n_of"]);
                            _mExcel.intProd = Convert.ToInt32(DR_TEMP_XLS["cod_art"]);

                            //Bin->>
                            string [] strBin = Convert.ToString(DR_TEMP_XLS["descrip"]).Trim().Split('-');
                            if (strBin.Length > 1)
                            {
                                _mExcel.vchBin1 = strBin[0];
                                _mExcel.vchBin2 = strBin[1];
                                _mExcel.vchBin3 = strBin[2];
                            }
                            else {
                                continue;
                            }

                            _mExcel.intAccion = 1;
                            DataSet DS_OP = _mExcel.dsScaneo_sp_MtoExcel();

                           

                        }//END_DATAROW_XLS <=
                    
                    }//END_DATATABLE_XLS <=

                    if (Convert.ToBoolean(Properties.Settings.Default.bAplicaResp))
                    {
                        //Move File->
                        System.IO.File.Move(DR[0].ToString().Trim()
                            , Properties.Settings.Default.strRespaldoSQL + "//" + System.IO.Path.GetFileName(DR[0].ToString().Trim()));
                    }

                }//END_DATASET_XLS <=      


                //Salida-->
                MessageBox.Show("Operacion realizada satisfactoriamente, puede usted continuar.",
                         "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch { }

            tsbLimpiar_Click(null, null);
        }
        private void tsbLimpiar_Click(object sender, EventArgs e)
        {
            try
            {
                _dtTempArchivosProc = null;
                txtArchivo.Text = "";
                vCargar();

            }
            catch { }
        }
        #endregion MANUAL
        #region AUTOMATICO
        private void TSBTN_START_Click(object sender, EventArgs e)
        {
            #region VENTANA
            tsbEstatusDaemon.Text = " Estatus - Activado <- ";
            tsbEstatusDaemon.ForeColor = Color.LightGreen;
            TSBTN_START.Enabled = false;
            TSBTN_STOP.Enabled = true;
            groupBox5.Text = "Opciones del modo automatico ->> Estatus - Activado";
            #endregion VENTANA

            //Timer->>
            vInicioTimerMonitorConn();
        }
        private void TSBTN_STOP_Click(object sender, EventArgs e)
        {
            #region VENTANA
            TSBTN_START.Enabled = true;
            tsbEstatusDaemon.Text = " Estatus - Detenido <- ";
            tsbEstatusDaemon.ForeColor = Color.White;
            TSBTN_STOP.Enabled = false;
            groupBox5.Text = "Opciones del modo automatico ->> Estatus - Detenido";
            #endregion VENTANA
            vFinTimerMonitorConn();
        }
        #endregion AUTOMATICO
        #endregion EVENTOS
        #region METODOS
        private void vInicioTimerMonitorConn()
        {
            timerMonitorConexion.Start();
            timerMonitorConexion.Enabled = true;
            timerMonitorConexion.Interval = Convert.ToInt32(Properties.Settings.Default.strMiliTimerConnExcel);
        }
        private void vFinTimerMonitorConn()
        {
            timerMonitorConexion.Stop();
            timerMonitorConexion.Enabled = false;
            timerMonitorConexion.Interval = Convert.ToInt32(Properties.Settings.Default.strMiliTimerConnExcel);
        }    

        private void vCargar()
        {
            //Salida->>
            _mExcel.intAccion = 2;
            DataSet DS_RET = _mExcel.dsScaneo_sp_MtoExcel();
            uctrlTablaConFiltroResultados.gridDatos.DataSource = DS_RET.Tables[0].Copy();
            uctrlTablaConFiltroResultados.DataSource = DS_RET.Tables[0].Copy();
            uctrlTablaConFiltroResultados.gridDatos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            uctrlTablaConFiltroResultadosAuto.gridDatos.DataSource = DS_RET.Tables[0].Copy();
            uctrlTablaConFiltroResultadosAuto.DataSource = DS_RET.Tables[0].Copy();
            uctrlTablaConFiltroResultadosAuto.gridDatos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        #endregion METODOS
        #region UTIL
        private void mouseSobreControl(object sender, EventArgs e)
        {

            try
            {
                string strTipo = sender.GetType().ToString();
                switch (strTipo)
                {
                    case "System.Windows.Forms.ToolStripDropDownButton":
                        {
                            ToolStripDropDownButton tsdddbGral = (ToolStripDropDownButton)sender;
                            tsdddbGral.ForeColor = Color.Black;
                            break;
                        }
                    case "System.Windows.Forms.ToolStripMenuItem":
                        {
                            ToolStripMenuItem tsmiGral = (ToolStripMenuItem)sender;
                            tsmiGral.ForeColor = Color.Black;
                            break;
                        }
                    default:
                        {
                            ToolStripButton tsbtnGral = (ToolStripButton)sender;
                            tsbtnGral.ForeColor = Color.Black;
                            break;
                        }
                }
            }
            catch
            {

            }
        }
        private void mouseFueraControl(object sender, EventArgs e)
        {
            try
            {
                string strTipo = sender.GetType().ToString();
                switch (strTipo)
                {
                    case "System.Windows.Forms.ToolStripDropDownButton":
                        {
                            ToolStripDropDownButton tsdddbGral = (ToolStripDropDownButton)sender;
                            tsdddbGral.ForeColor = Color.White;
                            break;
                        }
                    case "System.Windows.Forms.ToolStripMenuItem":
                        {
                            ToolStripMenuItem tsmiGral = (ToolStripMenuItem)sender;
                            tsmiGral.ForeColor = Color.White;
                            break;
                        }
                    default:
                        {
                            ToolStripButton tsbtnGral = (ToolStripButton)sender;
                            tsbtnGral.ForeColor = Color.White;
                            break;
                        }
                }
            }
            catch
            {

            }
        }
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
                                + "Por medio de la presente, se notifica que se ha perdido la conexion con el servidor sql, "
                                + "<br>y por consiguiente el daemon Excel ha sido detenido. " + DateTime.Now.ToString() + ".</br>"
                                + "<br> </br>"
                                + "<br> Mensaje del error: </br>"
                                + "<br>" + strMsgErr + "</br>"
                            + "</font></p>"
                            + "<p><font size = '3' face = 'Calibri'>"
                                + "[Sistema Escaneo Ikor]."
                            + "</font></p>"
                            + "<p><font size = '1' face = 'Calibri'>"
                                + "<hr color = #E46C0A>"
                                + "Correo generado autom&aacute;ticamente desde el [Sistema Escaneo Ikor]."
                            + "</font></p>"
                        + "</BODY>";

                    MailMessage message = new MailMessage();
                    MailAddress fromAddress = new MailAddress(Properties.Settings.Default.strCuentaEmisora);
                    MailAddress toAddress = new MailAddress(strDato, "");
                    message.From = fromAddress;
                    message.To.Add(toAddress);
                    message.Subject = "Daemon Ikor - Excel Detenido";
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
        #endregion UTIL
    }
}
