using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaDeControlDeRecursos
{
    class DBAccess
    {
        private static SqlConnection conn = new SqlConnection("Server= 3.128.144.165; Database=DB20172001423; UID=brandon.portan; PWD=BP20172001423;");
        private static SqlDataAdapter adp;


        public static SqlConnection getDBConnection
        {
            get {
                return conn;
            }
        }
     public static DataTable getSelectCommandDT(string nombreSP, Dictionary<string, (object valor, ParameterDirection? direccion)> param)
        {
            DataTable dt = new DataTable();
            try
            {

                adp = new SqlDataAdapter(nombreSP, conn);
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;

                if (param == null) { 
                    adp.Fill(dt);
                    return dt;
                }


  
                foreach (KeyValuePair<string, (object valor, ParameterDirection? direccion)> par in param)
                {
                    string nombreParametro = par.Key;
                    object valorParametro = par.Value.valor;

                    adp.SelectCommand.Parameters.AddWithValue(nombreParametro, valorParametro);

                    if (par.Value.direccion.HasValue)
                    {
                        ParameterDirection direccion = (ParameterDirection)par.Value.direccion;
                        adp.SelectCommand.Parameters[par.Key].Direction = direccion;
                    }
                }
                
                adp.Fill(dt);

            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



            return dt;
        }

        public static DataTable getDataTable(string sp, Dictionary<string, object> parametros)
        {
            SqlConnection connection = conn;
            SqlDataAdapter adapter = new SqlDataAdapter(sp, connection);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            foreach (var param in parametros)
            {
                adapter.SelectCommand.Parameters.AddWithValue("@" + param.Key, param.Value);
            }

            DataTable tabResult = new DataTable();
            adapter.Fill(tabResult);

            return tabResult;
        }
    }
}
