using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeControlDeRecursos
{
    class DBAccess
    {
        public static SqlConnection conn = null;
        public void getDBConnection()
        {
            conn = new SqlConnection("Server= 3.128.144.165; Database=DB20172001423; UID=brandon.portan; PWD=BP20172001423;");
            conn.Open();
        }
    }
}
