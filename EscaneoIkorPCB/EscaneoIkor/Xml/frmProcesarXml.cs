using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Net.Mail;
using System.Windows.Forms;

namespace EscaneoIkor.Xml
{
    public partial class frmProcesarXml : Form
    {
        #region PROPIEDADES
        DataTable _dtTempArchivosProc = null;
        mSeguridad _mSecurity = new mSeguridad();
        cXml _mXML = new cXml();
        #endregion PROPIEDADES
        #region CONSTRUCTORES
        public frmProcesarXml(mSeguridad mSec)
        {
            InitializeComponent();
            _mSecurity = mSec;
        }
        public frmProcesarXml()
        {
            InitializeComponent();
        }
        #endregion CONSTRUCTORES
        #region EVENTOS
        #region VENTANA
        private void frmConfiguracion_Load(object sender, EventArgs e)
        {
            //GroupBox->>
            groupBox6.Text = "Bitácora del proceso -> Reporitorio -> [" + Properties.Settings.Default.strRepoXMLs + "]";

            if (Properties.Settings.Default.cModoXml == "M")
            {
                rbtnManual.Checked = true;
            }
            else if (Properties.Settings.Default.cModoXml == "A")
            {
                rbtnAutomatico.Checked = true;
            }

            vCargar();

            TSBTN_STOP_Click(null, null);

        }
        //Monitor de la conexion->>
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
        private void OnTimer_timerMonitorConexion_Event(object sender, EventArgs e)
        {
            ExtraerFicherorDelSubDirectorio(Properties.Settings.Default.strRepoXMLs);

            //Leer Excel->
            DataTable DT_XML = new DataTable();
            try
            {
                foreach (DataRow DR in _dtTempArchivosProc.Rows)
                {
                    DT_XML = _mXML.dtLeerXML(Properties.Settings.Default.strRepoXMLs + "//" +DR[0].ToString().Trim());

                    foreach (DataRow DR_TEMP_XLS in DT_XML.Rows)
                    {
                        //Mto XML->>
                        _mXML.vchBarCodeId = DR_TEMP_XLS[0].ToString().Trim();
                        _mXML.vchImageBarCodeId = DR_TEMP_XLS[1].ToString().Trim();
                        _mXML.vchScanTime = DR_TEMP_XLS[2].ToString().Trim();
                        _mXML.intAccion = 1;
                        DataSet DS_OP = _mXML.dsScaneo_sp_MtoXml();



                    }//END_DATAROW_XLS <=


                    if (Convert.ToBoolean(Properties.Settings.Default.bAplicaResp))
                    {
                        //Move File->
                        System.IO.File.Move(Properties.Settings.Default.strRepoXMLs + "//" + DR[0].ToString().Trim()
                            , Properties.Settings.Default.strRespaldoSQL + "//" + DR[0].ToString().Trim());
                    }

                    vCargar();

                    
                }//END_DATATABLE_XLS <=


            }
            catch { }

            
        }
        private void rbtnManual_CheckedChanged(object sender, EventArgs e)
        {
            panelAutomatico.Visible = false;
            panelManual.Visible = true;
            Properties.Settings.Default.cModoXml = "M";
            Properties.Settings.Default.Save();

            tsbLimpiar_Click(null,null);
        }
        private void rbtnAutomatico_CheckedChanged(object sender, EventArgs e)
        {
            panelManual.Visible = false;
            panelAutomatico.Visible = true;
            Properties.Settings.Default.cModoXml = "A";
            Properties.Settings.Default.Save();

            ExtraerFicherorDelSubDirectorio(Properties.Settings.Default.strRepoXMLs);

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
            _dtTempArchivosProc = new DataTable("ArchivosProcesar");
            DataColumn dC = new DataColumn("Archivo(s)_a_procesar");
            _dtTempArchivosProc.Columns.Add(dC);

            //Dialog prop->>
            dlAbrir.CheckFileExists = true;
            dlAbrir.CheckPathExists = true;
            dlAbrir.Multiselect = true;
            dlAbrir.DefaultExt = "xml";
            dlAbrir.FileName = "";
            dlAbrir.Filter = "Archivos XML (*.xml)|*.xml";
            dlAbrir.Title = "Seleccionar fichero XML a dividir y separar páginas";

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
                MessageBox.Show("Para Leer el XML primero debe seleccionar uno o varios archivos, puede usted continuar.",
                         "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //Leer Excel->
            DataTable DT_XML = new DataTable();
            try
            {
                foreach (DataRow DR in _dtTempArchivosProc.Rows)
                {
                    DT_XML = _mXML.dtLeerXML(DR[0].ToString().Trim());

                    foreach (DataRow DR_TEMP_XLS in DT_XML.Rows)
                    {
                        //Mto XML->>
                        _mXML.vchBarCodeId = DR_TEMP_XLS[0].ToString().Trim();
                        _mXML.vchImageBarCodeId = DR_TEMP_XLS[1].ToString().Trim();
                        _mXML.vchScanTime = DR_TEMP_XLS[2].ToString().Trim();
                        _mXML.intAccion = 1;
                        DataSet DS_OP = _mXML.dsScaneo_sp_MtoXml();



                    }//END_DATAROW_XLS <=


                       if (Convert.ToBoolean(Properties.Settings.Default.bAplicaResp))
                       {
                           //Move File->
                           System.IO.File.Move(DR[0].ToString().Trim()
                               , Properties.Settings.Default.strRespaldoSQL + "//" + System.IO.Path.GetFileName(DR[0].ToString().Trim()));
                       }

                       tsbLimpiar_Click(null, null);

                      
                    }//END_DATATABLE_XLS <=

                //Salida-->
                MessageBox.Show("Operacion realizada satisfactoriamente, puede usted continuar.",
                         "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
              

              }
            catch { }


        }
        private void tsbLimpiar_Click(object sender, EventArgs e)
        {
            try
            {
                _dtTempArchivosProc = null;
                vCargar();
                txtArchivo.Text = "";
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
        private void vFinTimerMonitorConn()
        {
            timerMonitorConexion.Stop();
            timerMonitorConexion.Enabled = false;
            timerMonitorConexion.Interval = Convert.ToInt32(Properties.Settings.Default.strMiliTimerConnExcel);
        }  
        #endregion AUTOMATICO
        #endregion EVENTOS
        #region METODOS
        private void vInicioTimerMonitorConn()
        {
            timerMonitorConexion.Start();
            timerMonitorConexion.Enabled = true;
            timerMonitorConexion.Interval = Convert.ToInt32(Properties.Settings.Default.strMiliTimerConnXML);
        }
        private void vCargar()
        {
            //Salida->>
            _mXML.intAccion = 2;
            DataSet DS_RET = _mXML.dsScaneo_sp_MtoXml();
            uctrlTablaConFiltroResultados.DataSource = DS_RET.Tables[0].Copy();
            uctrlTablaConFiltroResultados.gridDatos.DataSource = DS_RET.Tables[0].Copy();
            uctrlTablaConFiltroResultados.gridDatos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            uctrlTablaConFiltroResultadosAuto.DataSource = DS_RET.Tables[0].Copy();
            uctrlTablaConFiltroResultadosAuto.gridDatos.DataSource = DS_RET.Tables[0].Copy();
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
                                + "<br>y por consiguiente el daemon Xml ha sido detenido. " + DateTime.Now.ToString() + ".</br>"
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
                    message.Subject = "Daemon Ikor - Xml Detenido";
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
