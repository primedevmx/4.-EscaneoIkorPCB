using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EscaneoIkor.Operador
{
    public class cOperador
    {
        #region PROPIEDADES PRIVADAS
        //Int-->
        private int _intAccion = -1;

        //String-->
        private string _strConnSQL = "";

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

        #endregion PROPIEDADES PUBLICAS
        #region METODOS PUBLICOS
        #endregion METODOS PUBLICOS
    }
}

