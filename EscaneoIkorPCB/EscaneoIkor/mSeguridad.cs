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

namespace EscaneoIkor
{
    public class mSeguridad
    {
        #region PROPIEDADES PRIVADAS
        //Int -->
        private int _intAccion = -1;
        private int _idUsuario = -1;
        private int _idTipoUsuario = -1;

        //String-->
        private string _strUsuarioSistema = "";
        private string _strConnSQL = "";
        private string _vchNombreUsuario = "";
        private string _vchUsuario = "";
        private string _vchPassword = "";
        private string _vchStatus = "";
        private string _vchTipoUsuario = "";
        private string _vchCorreoElectronico = "";

        //Bool-->
        private bool _bUsuarioAdmin = false;
        private bool _bUsuarioProduc = false;
        private bool _bAplicaReglas = false;
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
        public int idUsuario
        {
            get
            {
                return this._idUsuario;
            }
            set
            {
                this._idUsuario = value;
            }
        }
        public int idTipoUsuario
        {
            get
            {
                return this._idTipoUsuario;
            }
            set
            {
                this._idTipoUsuario = value;
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
        public string vchUsuario
        {
            get
            {
                return this._vchUsuario;
            }
            set
            {
                this._vchUsuario = value;
            }
        }
        public string vchNombreUsuario
        {
            get
            {
                return this._vchNombreUsuario;
            }
            set
            {
                this._vchNombreUsuario = value;
            }
        }
        public string vchPassword
        {
            get
            {
                return this._vchPassword;
            }
            set
            {
                this._vchPassword = value;
            }
        }
        public string vchUsuarioSistema
        {
            get
            {
                return this._strUsuarioSistema;
            }
            set
            {
                this._strUsuarioSistema = value;
            }
        }
        public string vchStatus
        {
            get
            {
                return this._vchStatus;
            }
            set
            {
                this._vchStatus = value;
            }
        }
        public string vchTipoUsuario
        {
            get
            {
                return this._vchTipoUsuario;
            }
            set
            {
                this._vchTipoUsuario = value;
            }
        }
        public string vchCorreoElectronico
        {
            get
            {
                return this._vchCorreoElectronico;
            }
            set
            {
                this._vchCorreoElectronico = value;
            }
        }

       
        //Bool-->
        public bool bUsuarioAdmin
        {
            get
            {
                return this._bUsuarioAdmin;
            }
            set
            {
                this._bUsuarioAdmin = value;
            }
        }
        public bool bUsuarioProduc
        {
            get
            {
                return this._bUsuarioProduc;
            }
            set
            {
                this._bUsuarioProduc = value;
            }
        }
        public bool bAplicaReglas
        {
            get
            {
                return this._bAplicaReglas;
            }
            set
            {
                this._bAplicaReglas = value;
            }
        }
        #endregion PROPIEDADES PUBLICAS
        #region METODOS PUBLICOS
        public DataSet dsValidaAutenticacion()
        {
            DataSet dsResult = new DataSet();
            try
            {
                SqlParameter[] arParms = new SqlParameter[8];

                arParms[0] = new SqlParameter("@idUsuario", SqlDbType.VarChar, 50);
                arParms[0].Value = this._idUsuario;
                arParms[1] = new SqlParameter("@vchUsuario", SqlDbType.VarChar, 50);
                arParms[1].Value = this._vchUsuario;
                arParms[2] = new SqlParameter("@vchPassword", SqlDbType.VarChar, 50);
                arParms[2].Value = this._vchPassword;
                arParms[3] = new SqlParameter("@vchCorreoElectronico", SqlDbType.VarChar, 50);
                arParms[3].Value = this._vchCorreoElectronico;
                arParms[4] = new SqlParameter("@vchNombre", SqlDbType.VarChar, 50);
                arParms[4].Value = this._vchNombreUsuario;
                arParms[5] = new SqlParameter("@vchStatus", SqlDbType.VarChar, 50);
                arParms[5].Value = this._vchStatus;
                arParms[6] = new SqlParameter("@idTipoUsuario", SqlDbType.VarChar, 50);
                arParms[6].Value = this._idTipoUsuario;
                arParms[7] = new SqlParameter("@Accion", SqlDbType.Int);
                arParms[7].Value = this._intAccion;

                dsResult = SqlHelper.ExecuteDataset(strConnSQL, CommandType.StoredProcedure, "Seguridad_sp_MtoUsuarios", arParms);

                return dsResult;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public DataSet dsSeguridad_sp_MtoUsuarios()
        {
            DataSet dsResult = new DataSet();
            try
            {
                SqlParameter[] arParms = new SqlParameter[8];

                arParms[0] = new SqlParameter("@idUsuario", SqlDbType.VarChar, 50);
                arParms[0].Value = this._idUsuario;
                arParms[1] = new SqlParameter("@vchUsuario", SqlDbType.VarChar, 50);
                arParms[1].Value = this._vchUsuario;
                arParms[2] = new SqlParameter("@vchPassword", SqlDbType.VarChar, 50);
                arParms[2].Value = this._vchPassword;
                arParms[3] = new SqlParameter("@vchCorreoElectronico", SqlDbType.VarChar, 50);
                arParms[3].Value = this._vchCorreoElectronico;
                arParms[4] = new SqlParameter("@vchNombre", SqlDbType.VarChar, 50);
                arParms[4].Value = this._vchNombreUsuario;
                arParms[5] = new SqlParameter("@vchStatus", SqlDbType.VarChar, 50);
                arParms[5].Value = this._vchStatus;
                arParms[6] = new SqlParameter("@idTipoUsuario", SqlDbType.VarChar, 50);
                arParms[6].Value = this._idTipoUsuario;
                arParms[7] = new SqlParameter("@Accion", SqlDbType.Int);
                arParms[7].Value = this._intAccion;


                dsResult = SqlHelper.ExecuteDataset(strConnSQL, CommandType.StoredProcedure, "Seguridad_sp_MtoUsuarios", arParms);

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
