using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSC09
{
    public class Busco
    {
        public static string BuscaUltimoNumero(string nmId) {

            SqlConnection cnx = new SqlConnection(cnn.db); cnx.Open();
            SqlCommand cmd = new SqlCommand("SELECT CONTADOR + 1 AS ULTIMO FROM SECUENCIAS WHERE ID ='" + nmId + "'", cnx);
            SqlDataReader rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                return rdr["ULTIMO"].ToString();
            }

            cmd.Dispose();
            cnx.Close();
            return null;
        }
    }
}
