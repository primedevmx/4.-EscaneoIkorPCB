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
using mExcel = Microsoft.Office.Interop.Excel;
using Microsoft.ApplicationBlocks.Data;

namespace EscaneoIkor.Excel
{
    public class cExcel
    {
        #region PROPIEDADES PRIVADAS
        //Int -->
        private int _intOP = -1;
        private int _intProd = -1;
        private int _intAccion = -1;

        //String-->
        private string _strConnSQL = "";
        private string _vchBin1 = "";
        private string _vchBin2 = "";
        private string _vchBin3 = "";

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
        public int intOP
        {
            get
            {
                return this._intOP;
            }
            set
            {
                this._intOP = value;
            }
        }
        public int intProd
        {
            get
            {
                return this._intProd;
            }
            set
            {
                this._intProd = value;
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

        #endregion PROPIEDADES PUBLICAS
        #region METODOS PUBLICOS
        public string CrearExcel_DS(DataSet DS, string strFile)
        {
            #region CREACION DE VARIABLES

            mExcel.Application eAplicacion = new mExcel.Application();
            mExcel.Workbook eLibro = null;
            System.Globalization.CultureInfo CurrentCI = System.Threading.Thread.CurrentThread.CurrentCulture;
            #endregion
            #region CUERPO
            try
            {
                #region Crear Libro
                try { eLibro = eAplicacion.Workbooks.Add(System.Reflection.Missing.Value); }
                catch
                {
                    System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
                    eLibro = eAplicacion.Workbooks.Add(System.Reflection.Missing.Value);
                }
                #endregion
                #region Crear Hojas
                foreach (DataTable dtbHoja in DS.Tables)
                {
                    int intColumnas = dtbHoja.Columns.Count;
                    #region HOJA Excel
                    mExcel.Worksheet eHoja = DS.Tables.IndexOf(dtbHoja) < 3 ?
                        (mExcel.Worksheet)eAplicacion.Sheets[DS.Tables.IndexOf(dtbHoja) + 1] :
                        (mExcel.Worksheet)eAplicacion.Sheets.Add(eAplicacion.Sheets[DS.Tables.IndexOf(dtbHoja)], Type.Missing, Type.Missing, Type.Missing);
                    eHoja.Name = dtbHoja.TableName;

                    mExcel.Range rCeldas = eHoja.Cells[1, 1];

                    mExcel.Range rRango = eHoja.UsedRange; ;

                    #region COLUMNAS
                    rRango = rCeldas[1, 1];
                    for (int i = 0; i < dtbHoja.Columns.Count; i++)
                        eHoja.Cells[1, 1 + i] = dtbHoja.Columns[i].ColumnName;
                    #endregion
                    #region LLENDO DE FILAS
                    int intFila = 2;
                    int intValor = 0;
                    foreach (DataRow dtrDatos in dtbHoja.Rows)
                    {
                        //rRango = (Excel.Range)rCeldas.get_Range(rCeldas[intFila, 1], rCeldas[intFila, dtbHoja.Columns.Count]);
                        rRango = rCeldas[intFila, dtbHoja.Columns.Count];

                        for (int i = 0; i < dtbHoja.Columns.Count; i++)
                            eHoja.Cells[intFila, 1 + i] = Int32.TryParse(dtrDatos[dtbHoja.Columns[i]].ToString(), out intValor) ?
                                intValor.ToString() : (dtrDatos[dtbHoja.Columns[i]].ToString().Contains("'") ?
                                dtrDatos[dtbHoja.Columns[i]].ToString() : "'" + dtrDatos[dtbHoja.Columns[i]].ToString());
                        intFila++;
                    }
                    #endregion
                    #endregion
                }
                #endregion
                #region GUARDAR EXCEL
                eAplicacion.DisplayAlerts = false;
                eLibro.SaveAs(strFile,
                    System.Reflection.Missing.Value,
                    System.Reflection.Missing.Value,
                    System.Reflection.Missing.Value,
                    System.Reflection.Missing.Value,
                    System.Reflection.Missing.Value,
                    Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange,
                    System.Reflection.Missing.Value,
                    System.Reflection.Missing.Value,
                    System.Reflection.Missing.Value,
                    System.Reflection.Missing.Value,
                    System.Reflection.Missing.Value);
                #endregion
                return "EXITO";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                #region CERRAR LIBRO
                if (eLibro != null)
                    eLibro.Close(false, null, null);
                eAplicacion.Quit();
                System.Threading.Thread.CurrentThread.CurrentCulture = CurrentCI;
                #endregion
            }
            #endregion
        }
        public DataSet LeerExcel_DS(string strArchivo)
        {
            #region CREACION DE VARIABLES
            DataSet dtsExcel = new DataSet("Excel");
            mExcel.Application eAplicacion = new mExcel.Application();
            mExcel.Workbook eLibro = null;
            System.Globalization.CultureInfo CurrentCI = System.Threading.Thread.CurrentThread.CurrentCulture;
            #endregion
            #region CUERPO
            try
            {
                #region ABRIR LIBRO
                try
                {
                    eLibro = eAplicacion.Workbooks.Open(strArchivo,
                        System.Reflection.Missing.Value, System.Reflection.Missing.Value, System.Reflection.Missing.Value, System.Reflection.Missing.Value,
                        System.Reflection.Missing.Value, System.Reflection.Missing.Value, System.Reflection.Missing.Value, System.Reflection.Missing.Value,
                        System.Reflection.Missing.Value, System.Reflection.Missing.Value, System.Reflection.Missing.Value, System.Reflection.Missing.Value,
                        System.Reflection.Missing.Value, System.Reflection.Missing.Value);
                }
                catch
                {
                    // AJUSTAR CURRENTINFO
                    System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
                    // ABRIR WORKBOOK
                    eLibro = eAplicacion.Workbooks.Open(strArchivo,
                        System.Reflection.Missing.Value, System.Reflection.Missing.Value, System.Reflection.Missing.Value, System.Reflection.Missing.Value,
                        System.Reflection.Missing.Value, System.Reflection.Missing.Value, System.Reflection.Missing.Value, System.Reflection.Missing.Value,
                        System.Reflection.Missing.Value, System.Reflection.Missing.Value, System.Reflection.Missing.Value, System.Reflection.Missing.Value,
                        System.Reflection.Missing.Value, System.Reflection.Missing.Value);
                }
                #endregion
                #region LEER HOJAS
                for (int intContador = 1; intContador <= eLibro.Sheets.Count; intContador++)
                {
                    mExcel.Worksheet eHoja = (mExcel.Worksheet)eLibro.Sheets[intContador];
                    mExcel.Range eRango = eHoja.UsedRange;
                    object[,] oValores = (object[,])eRango.get_Value(mExcel.XlRangeValueDataType.xlRangeValueDefault);
                    if (oValores != null)
                    {
                        DataTable dtbHoja = new DataTable(eHoja.Name);
                        for (int j = 1; j <= oValores.GetLength(1); j++)
                            try
                            {
                                dtbHoja.Columns.Add(oValores[1, j].ToString(),
                                    (oValores[1, j].ToString().Equals("Respuesta") || oValores[1, j].ToString().Equals("Sección") || oValores[1, j].ToString().Equals("SubSección")
                                        ? typeof(string) : oValores[2, j].GetType()));
                            }
                            catch
                            {
                                dtbHoja.Columns.Add(oValores[1, j].ToString(), typeof(object));
                            }
                        for (int h = 2; h <= oValores.GetLength(0); h++)
                        {
                            DataRow dtrHoja = dtbHoja.NewRow();
                            for (int k = 1; k <= oValores.GetLength(1); k++)
                                dtrHoja[k - 1] = oValores[h, k];
                            dtbHoja.Rows.Add(dtrHoja);
                        }
                        dtsExcel.Tables.Add(dtbHoja);
                    }
                }
                #endregion
            }
            catch (Exception ex)
            {
                return Error(ex.Message);
            }
            finally
            {
                #region CERRAR LIBRO
                if (eLibro != null)
                    eLibro.Close(false, strArchivo, null);
                eAplicacion.Quit();
                // AJUSTAR CURRENTINFO
                System.Threading.Thread.CurrentThread.CurrentCulture = CurrentCI;
                #endregion
            }
            #endregion
            return dtsExcel;
        }
        public DataSet dsScaneo_sp_MtoExcel()
        {
            DataSet dsResult = new DataSet();
            try
            {
                SqlParameter[] arParms = new SqlParameter[6];

                arParms[0] = new SqlParameter("@intOP", SqlDbType.Int);
                arParms[0].Value = this._intOP;
                arParms[1] = new SqlParameter("@intProd", SqlDbType.Int);
                arParms[1].Value = this._intProd;
                arParms[2] = new SqlParameter("@vchBin1", SqlDbType.VarChar, 50);
                arParms[2].Value = this._vchBin1;
                arParms[3] = new SqlParameter("@vchBin2", SqlDbType.VarChar, 50);
                arParms[3].Value = this._vchBin2;
                arParms[4] = new SqlParameter("@vchBin3", SqlDbType.VarChar, 50);
                arParms[4].Value = this._vchBin3;
                arParms[5] = new SqlParameter("@intAccion", SqlDbType.Int);
                arParms[5].Value = this._intAccion;


                dsResult = SqlHelper.ExecuteDataset(strConnSQL, CommandType.StoredProcedure, "[dbo].[Scaneo_sp_MtoExcel]", arParms);

                return dsResult;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion METODOS PUBLICOS
        #region METODOS PRIVADOS
        private DataSet Error(string strMensaje)
        {
            DataSet dtsError = new DataSet("Error");
            DataTable dtbError = new DataTable("Error");
            dtbError.Columns.Add("Error");
            dtbError.Rows.Add(strMensaje);
            dtsError.Tables.Add(dtbError);
            return dtsError;
        }
        #endregion
    }
}
