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
        public static string BuscaUltimoNumero(string nmId)
        {

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


        public static string BuscarSucursal(string _numId, out bool _found)
        {
            using (SqlConnection cnx = new SqlConnection(cnn.db))
            {
                cnx.Open();
                string _query = @"SELECT NombreDeSucursal FROM SUCURSALES WHERE IDSUCURSAL = @ID";

                SqlCommand cmd = new SqlCommand(_query, cnx);
                cmd.Parameters.AddWithValue("@ID", _numId);
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    _found = true;
                    return dr["NombreDeSucursal"].ToString();
                }

                _found = false;
                return null;
            }
        }

        public static string BuscarPuestoTrabajo(string _puesto) 
        { 
            SqlConnection cnx = new SqlConnection(cnn.db); 
            cnx.Open(); 
            SqlCommand cmd = new SqlCommand("SELECT PUESTODETRABAJO FROM POSICION WHERE IDPUESTO = @PUESTO", cnx); 
            cmd.Parameters.AddWithValue("@PUESTO", _puesto); 
            SqlDataReader dr = cmd.ExecuteReader(); 
            if (dr.Read()) 
            { 
                return dr["NOMBREDEPOSICION"].ToString(); 
            
            } 
            cnx.Close();
            return null; 
        }
        public static string BuscarUltimaSecuencia(string _numId) 
        { 
            using (SqlConnection cnx = new SqlConnection(cnn.db)) 
                { 
                cnx.Open(); 
                string _query = "SELECT CONTADOR + 1 AS ULTIMO FROM SECUENCIAS WHERE ID= @ID"; 
                SqlCommand cmd = new SqlCommand(_query, cnx); 
                cmd.Parameters.AddWithValue("@ID", _numId); 
                SqlDataReader dr = cmd.ExecuteReader(); 
                if (dr.Read()) 
                { 
                    return dr["ULTIMO"].ToString(); 
                } 
                return null; 
            } 
        }
        public static string BuscarSuplidor(string suplidor, out bool _found)
        {
            using (SqlConnection cnx = new SqlConnection(cnn.db))
            {
                cnx.Open(); // abre la base de datos
                string _Query = "SELECT SUPLIDORNOMBRE FROM SUPLIDORES WHERE IDSUPLIDOR ='" + suplidor + "'"; 
                SqlCommand cmd = new SqlCommand(_Query, cnx); // envia el script al servidor
                SqlDataReader rdr = cmd.ExecuteReader(); // ejecuta el query en el servidor
                if (rdr.Read()) // pregunta si el contenedor trajo informacion
                {
                    _found = true;
                    return rdr["SUPLIDORNOMBRE"].ToString(); 
                }
                _found = false;
            } return null; 
        }

        public static string BuscarCategoria(string categoria, out bool _found)
        {
            using (SqlConnection cnx = new SqlConnection(cnn.db))
            {
                cnx.Open();
                string _Query = "SLECT CATEGORIANOMBRE FROM CATEGORIAS WHERE CATEGORIA = @A1";

                SqlCommand cmd = new SqlCommand(_Query, cnx);
                cmd.Parameters.AddWithValue("@A1", categoria);
                SqlDataReader rdr = cmd.ExecuteReader();

                if(rdr.Read())
                {
                    _found = true;
                    return rdr["CATEGORIANOMBRE"].ToString() ;
                }
                _found = false;
            }return null;
        }

        public static string BuscarSubCategoria(string categoria, string subcat)
        {
            using (SqlConnection cnx = new SqlConnection (cnn.db))
            {
                cnx.Open();
                string _Query = "SLECT CATEGORIANOMBRE FROM CATEGORIAS WHERE CATEGORIA = @A1";

                SqlCommand cmd = new SqlCommand(_Query, cnx);
                cmd.Parameters.AddWithValue("@A1", categoria);
                cmd.Parameters.AddWithValue("@A2", categoria);
                SqlDataReader rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    return rdr["CATEGORIANOMBRE"].ToString();
                }
            }return null; 
        }

        public static string BuscarCliente(string cliente, out bool found, out string nivel, out string tipo, out string paga)
        {
            found = false;
            nivel = null;
            tipo = null;
            paga = null;

            using (SqlConnection cnx = new SqlConnection(cnn.db))
            {
                cnx.Open();
                string _Query = "SELECT NOMBRECLIENTE, NIVELPRECIO, TIPOCLIENTE, IMPUESTOPAGA FROM CLIENTES WHERE IDCLIENTE = @A1";

                SqlCommand cmd = new SqlCommand(_Query, cnx);
                cmd.Parameters.AddWithValue("@A1", cliente);
                SqlDataReader rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    found = true;
                    nivel = rdr["NIVELPRECIO"].ToString();
                    tipo = rdr["TIPOCLIENTE"].ToString();
                    paga = rdr["IMPUESTOPAGA"].ToString();

                    return rdr["NOMBRECLIENTE"].ToString();
                }
            }

            return null;
        }

        public static string BuscaNombreCliente(string nmId)
        {
            SqlConnection cnx = new SqlConnection(cnn.db); cnx.Open();
            SqlCommand cmd = new SqlCommand("SELECT NOMBRECLIENTE FROM CLIENTES WHERE IDCLIENTE ='" + nmId + "'", cnx);
            SqlDataReader rdr = cmd.ExecuteReader();

            if (rdr.Read())
            {
                return rdr["NOMBRECLIENTE"].ToString();
            }

            cmd.Dispose();
            cnx.Close();
            return null;
        }

        public static string BuscarArticulo(string articulo, out bool found)

        {

            found = false;

            using (SqlConnection cnx = new SqlConnection(cnn.db))

            {

                cnx.Open();

                string _Query = "SELECT DESCRIPCION FROM PRODUCTOS WHERE IDPRODUCTO = @A1";

                SqlCommand cmd = new SqlCommand(_Query, cnx);

                cmd.Parameters.AddWithValue("@A1", articulo);

                SqlDataReader rdr = cmd.ExecuteReader();

                if (rdr.Read())

                {

                    found = true;

                    return rdr["DESCRIPCION"].ToString();

                }

            }

            return null;

        }

    }

}
