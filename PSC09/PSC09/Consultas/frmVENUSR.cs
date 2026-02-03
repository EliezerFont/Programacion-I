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

namespace PSC09
{
    public partial class frmVENUSR : Form
    {

        public Boolean EData;
        public string var1;
        public string var2;

        public frmVENUSR()
        {
            InitializeComponent();
            EstiloDGV();
        }

        private void EstiloDGV()
        {

        }

        private void frmVENUSR_Load(object sender, EventArgs e)
        {

            this.Text = "Consulta";
            this.KeyPreview = true;
            EData = false;

        }


        private void frmVENUSR_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.Close();
            }
        }

        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if((int)e.KeyChar == (int)Keys.Enter)
            {
                e.Handled = true;
                if(txtBuscar.Text.Trim() != string.Empty)
                {
                    btnBuscar.Focus();
                }
            }
        }

        private void txtBuscar_Leave(object sender, EventArgs e)
        {
            btnBuscar.PerformClick();
        }


        public static string BuscarUltimaSecuencia(string _numId) 
        { 
            using (SqlConnection cnx = new SqlConnection(cnn.db)) 
            { 
                cnx.Open(); 
                string _query = "SELECT CONTADOR + 1 AS ULTIMO FROM SECUENCIAS WHERE ID='" + _numId + "'"; 
                SqlCommand cmd = new SqlCommand(_query, cnx); 
                SqlDataReader dr = cmd.ExecuteReader(); 
                if (dr.Read()) 
                { 
                    return dr["ULTIMO"].ToString(); 
                } 
                return null; 
            } 
        }
    }
}
