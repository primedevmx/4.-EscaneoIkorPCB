using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using MdiTabStrip.Design;
using MdiTabStrip;

namespace EscaneoIkor.Opcionadores
{
    /// <summary>
    /// Autor: 
    ///     Miguel Gutierrez Arroyo
    /// Fecha: 
    ///     2014/05/06
    /// 
    /// Descripcion: 
    ///     Menu Dinámico de la Aplicación
    /// Acciones: 
    ///     Desplegar Modulos
    /// 
    /// </summary> 
    public partial class frmMenuSistema : ToolWindow
    {
        #region PROPIEDADES
        frmPrincipal mdipr;
        mSeguridad _mSecurity = new mSeguridad();
        #endregion PROPIEDADES
        #region CONSTRUCTORES
        public frmMenuSistema(Form frmMDI , mSeguridad mSec)
        {
            mdipr = (frmPrincipal)frmMDI;
            InitializeComponent();
            _mSecurity = mSec;
        }
        #endregion CONSTRUCTORES
        #region METODOS
        #endregion METODOS
        #region EVENTOS
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            //Configuracion Sistema->
            frmOpcionConfiguracion frmConf = new frmOpcionConfiguracion(mdipr, _mSecurity);
            clSeguridad.vCargaForma(frmConf, mdipr, "Menú Configuración");
        }
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            //Excel->>
            Excel.frmProcesarExcel frmConf = new Excel.frmProcesarExcel(_mSecurity);
            clSeguridad.vCargaForma(frmConf, mdipr, "Operación del Excel");
        }
        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            //Xml->>
            Xml.frmProcesarXml frmConf = new Xml.frmProcesarXml(_mSecurity);
            clSeguridad.vCargaForma(frmConf, mdipr, "Operación del Xml");
        }
        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            //Data-Matrix->>
            DataMatrix.frmDataMatrix frmData = new DataMatrix.frmDataMatrix(_mSecurity);
            clSeguridad.vCargaForma(frmData, mdipr, "Configuración de la DataMatrix");
        }
        #endregion EVENTOS
    }
}