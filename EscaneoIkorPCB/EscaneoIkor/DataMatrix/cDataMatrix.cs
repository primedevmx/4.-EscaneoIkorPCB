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


namespace EscaneoIkor.DataMatrix
{
    public class cDataMatrix
    {
        #region PROPIEDADES PRIVADAS
        //Int-->
        private int _intAccion = -1;
        private int _intIDDM = -1;
        private int _intIDCliente = -1;
        private int _intIDBin = -1;

        //String-->
        private string _strConnSQL = "";
        private string _vchProducto = "";
        private string _vchCliente = "";
        private string _vchCodigoBinTexto = "";
        private string _vchBin1 = "";
        private string _vchBin2 = "";
        private string _vchBin3 = "";
        private string _vchDatamatrixCC = "";

        DataTable _dt_DM = new DataTable();

        #endregion PROPIEDADES PRIVADAS
        #region PROPIEDADES PUBLICAS
        //Int-->
        public int intIDBin
        {
            get
            {
                return this._intIDBin;
            }
            set
            {
                this._intIDBin = value;
            }
        }
        public int intIDCliente
        {
            get
            {
                return this._intIDCliente;
            }
            set
            {
                this._intIDCliente = value;
            }
        }
        public int intIDDM
        {
            get
            {
                return this._intIDDM;
            }
            set
            {
                this._intIDDM = value;
            }
        }
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
        public string vchDatamatrixCC
        {
            get
            {
                return this._vchDatamatrixCC;
            }
            set
            {
                this._vchDatamatrixCC = value;
            }
        }
        public string vchBin3
        {
            get
            {
                return this._vchBin3;
            }
            set
            {
                this._vchBin3 = value;
            }
        }
        public string vchBin2
        {
            get
            {
                return this._vchBin2;
            }
            set
            {
                this._vchBin2 = value;
            }
        }
        public string vchBin1
        {
            get
            {
                return this._vchBin1;
            }
            set
            {
                this._vchBin1 = value;
            }
        }
        public string vchCodigoBinTexto
        {
            get
            {
                return this._vchCodigoBinTexto;
            }
            set
            {
                this._vchCodigoBinTexto = value;
            }
        }
        public string vchCliente
        {
            get
            {
                return this._vchCliente;
            }
            set
            {
                this._vchCliente = value;
            }
        }
        public string vchProducto
        {
            get
            {
                return this._vchProducto;
            }
            set
            {
                this._vchProducto = value;
            }
        }
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

        public DataTable dt_DM
        {
            get
            {
                return this._dt_DM;
            }
            set
            {
                this._dt_DM = value;
            }
        }


        #endregion PROPIEDADES PUBLICAS
        #region METODOS PUBLICOS
        public DataSet dsScaneo_sp_MtoDataMatrix()
        {
            DataSet dsResult = new DataSet();
            try
            {
                SqlParameter[] arParms = new SqlParameter[11];

                arParms[0] = new SqlParameter("@IDDM", SqlDbType.Int);
                arParms[0].Value = this._intIDDM;
                arParms[1] = new SqlParameter("@IDCliente", SqlDbType.Int);
                arParms[1].Value = this._intIDCliente;
                arParms[2] = new SqlParameter("@IDBin", SqlDbType.Int);
                arParms[2].Value = this._intIDBin;
                arParms[3] = new SqlParameter("@vchProducto", SqlDbType.VarChar, 50);
                arParms[3].Value = this._vchProducto;
                arParms[4] = new SqlParameter("@vchCliente", SqlDbType.VarChar, 50);
                arParms[4].Value = this._vchCliente;
                arParms[5] = new SqlParameter("@vchCodigoBinTexto", SqlDbType.VarChar, 50);
                arParms[5].Value = this._vchCodigoBinTexto;
                arParms[6] = new SqlParameter("@vchBin1", SqlDbType.VarChar, 50);
                arParms[6].Value = this._vchBin1;
                arParms[7] = new SqlParameter("@vchBin2", SqlDbType.VarChar, 50);
                arParms[7].Value = this._vchBin2;
                arParms[8] = new SqlParameter("@vchBin3", SqlDbType.VarChar, 50);
                arParms[8].Value = this._vchBin3;
                arParms[9] = new SqlParameter("@vchDatamatrixCC", SqlDbType.VarChar, 50);
                arParms[9].Value = this._vchDatamatrixCC;
                arParms[10] = new SqlParameter("@intAccion", SqlDbType.Int);
                arParms[10].Value = this._intAccion;


                dsResult = SqlHelper.ExecuteDataset(strConnSQL, CommandType.StoredProcedure, "[dbo].[Scaneo_sp_MtoDataMatrix]", arParms);

                return dsResult;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        #endregion METODOS PUBLICOS
    }
}
