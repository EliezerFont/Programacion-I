using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PSC09 { 
    public partial class frmVENUSUBCAT : Form
    {
        public Boolean EData;

        public frmVENUSUBCAT()
        {
            InitializeComponent();
        }

        private void frmVENUSUBCAT_Load(object sender, EventArgs e)
        {

        }

        private void BuscarData(string _strBuscar)
        {
            EData = false;
            this.dgv.Rows.Clear();
            this.dgv.Refresh();

            string _query =
                "   SELECT IDCATEGORIA, SUBCATEGORIA, NOMBRE  " +
                "       FROM CATEGORIAS_SUB " +
                "   WHERE ESTATUS = 1 " +
                "   AND NOMBRE LIKE '%" + txtBuscarSub.Text + "%' " +
                "  ORDER BY  ASC";

            SqlConnection cnx = new SqlConnection(cnn.db); cnx.Open();
            SqlCommand cmd = new SqlCommand(_query, cnx);

            SqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                dgv.Rows.Add();
                int xRow = dgv.Rows.Count - 1;

                dgv[0, xRow].Value = rdr["IDCATEGORIA"].ToString();
                dgv[1, xRow].Value = rdr["SUBCATEGORIA"].ToString();
                dgv[2, xRow].Value = rdr["NOMBRE"].ToString();
            }

            cmd.Dispose();
            cnx.Close();
        }
    }
}

