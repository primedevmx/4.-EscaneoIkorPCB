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

namespace EscaneoIkor.Xml
{
    public class cXml
    {
        #region PROPIEDADES PRIVADAS
        //Int-->
        private int _intAccion = -1;

        //String-->
        private string _strConnSQL = "";
        private string _vchBarCodeId = "";
        private string _vchImageBarCodeId = "";
        private string _vchScanTime = "";

        #endregion PROPIEDADES PRIVADAS
        #region PROPIEDADES PUBLICAS
        //Int-->
        public int intAccion
        {
            get
            {
                return this._intAccion;
            }
            set
            {
                this._intAccion = value;
            }
        }

        //String-->
        public string strConnSQL
        {
            get
            {
                return this._strConnSQL = Properties.Settings.Default.InstanciaServerSql;
            }
            set
            {
                this._strConnSQL = value;
            }
        }

        public string vchBarCodeId
        {
            get
            {
                return this._vchBarCodeId;
            }
            set
            {
                this._vchBarCodeId = value;
            }
        }

        public string vchImageBarCodeId
        {
            get
            {
                return this._vchImageBarCodeId;
            }
            set
            {
                this._vchImageBarCodeId = value;
            }
        }
        
        public string vchScanTime
        {
            get
            {
                return this._vchScanTime;
            }
            set
            {
                this._vchScanTime = value;
            }
        }

        #endregion PROPIEDADES PUBLICAS
        #region METODOS PUBLICOS
        public DataSet dsScaneo_sp_MtoXml()
        {
            DataSet dsResult = new DataSet();
            try
            {
                SqlParameter[] arParms = new SqlParameter[4];

                arParms[0] = new SqlParameter("@vchBarcodeId", SqlDbType.VarChar, 50);
                arParms[0].Value = this._vchBarCodeId;
                arParms[1] = new SqlParameter("@vchImageBarcodeId", SqlDbType.VarChar, 50);
                arParms[1].Value = this._vchImageBarCodeId;
                arParms[2] = new SqlParameter("@vchUploadTime", SqlDbType.VarChar, 50);
                arParms[2].Value = this._vchScanTime;
                arParms[3] = new SqlParameter("@intAccion", SqlDbType.Int);
                arParms[3].Value = this._intAccion;


                dsResult = SqlHelper.ExecuteDataset(strConnSQL, CommandType.StoredProcedure, "[dbo].[Scaneo_sp_MtoXML]", arParms);

                return dsResult;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public DataTable dtLeerXML(string strRutaArchivo)
        {
            //Datatable 1 ->>
            DataTable dtTemp = new DataTable(Path.GetFileName(strRutaArchivo));
            DataColumn dc0 = new DataColumn("vchBarcodeId");
            DataColumn dc1 = new DataColumn("vchImageBarcodeId");
            DataColumn dc2 = new DataColumn("vchScanTime");
            dtTemp.Columns.Add(dc0);
            dtTemp.Columns.Add(dc1);
            dtTemp.Columns.Add(dc2);

            //Datatable 2 ->>            
            DataTable dtTemp2 = new DataTable("tblxmlinfo_" + Path.GetFileNameWithoutExtension(strRutaArchivo));
            DataColumn dc00 = new DataColumn("chEstatus");
            DataColumn dc11 = new DataColumn("vchArchivo");
            DataColumn dc22 = new DataColumn("vchDescripcion");
            dtTemp2.Columns.Add(dc00);
            dtTemp2.Columns.Add(dc11);
            dtTemp2.Columns.Add(dc22);        

            //Variables del XML->>
            string strBarcodeId = "";
            string strImageBarcodeId = "";
            string strScanTime = "";


            try
            {
                XmlDocument xDoc = new XmlDocument();
                xDoc.Load(strRutaArchivo);

                XmlNodeList xJob = xDoc.GetElementsByTagName("Job");
                XmlNodeList xBarcode = ((XmlElement)xJob[0]).GetElementsByTagName("Barcode");
                XmlNodeList xImageBarcode = ((XmlElement)xBarcode[0]).GetElementsByTagName("ImageBarcode");

                //BarcodeId->>
                foreach (XmlElement nodo in xBarcode)
                {
                    strBarcodeId = nodo.GetAttribute("id");
                }

                //ImageBarcodeId->>
                foreach (XmlElement nodo in xImageBarcode)
                {
                    strImageBarcodeId = nodo.GetAttribute("id");
                    strScanTime = DateTime.Now.ToString();
                    DataRow DRO =
                        dtTemp.NewRow();
                    DRO[0] = strBarcodeId;
                    DRO[1] = strImageBarcodeId;
                    DRO[2] = strScanTime;
                    dtTemp.Rows.Add(DRO);
                }

                

            }
            catch (XmlException EX)
            {
                //Error de estructura->>
                //Mensaje dt->
                DataRow DRo = dtTemp2.NewRow();
                DRo[0] = "ERR";
                DRo[1] = Path.GetFileName(strRutaArchivo);
                DRo[2] = "ERROR LECTURA - [" + EX.Message + "]. ";
                dtTemp2.Rows.Add(DRo);

                return dtTemp2;

            }



            return dtTemp;

        }
        #endregion METODOS PUBLICOS
    }
}
