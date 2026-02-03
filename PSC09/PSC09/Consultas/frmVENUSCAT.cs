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
    public partial class frmVENUSCAT : Form
    {
        public frmVENUSCAT()
        {
            InitializeComponent();
            EstiloDGV();
        }

        public Boolean EData;
        public string var1;
        public string var2;

        private void frmVENCAT_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            this.Text = "Consulta";
            EData = false;
        }
        private void frmVENCAT_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void EstiloDGV()
        {
            this.dgv.EnableHeadersVisualStyles = false;
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.ColumnHeadersVisible = true;
            this.dgv.RowHeadersVisible = false;

            this.dgv.Columns.Add("A", "CATEGORIA");
            this.dgv.Columns.Add("B", "SUBCATEGORIA");

            DataGridViewColumn
            column = dgv.Columns[0]; column.Width = 100;
            column = dgv.Columns[1]; column.Width = 100;

            this.dgv.BorderStyle = BorderStyle.FixedSingle;
            this.dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            this.dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgv.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            this.dgv.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            this.dgv.BackgroundColor = Color.White;

            this.dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            this.dgv.ColumnHeadersDefaultCellStyle.Padding = new Padding(0, 6, 0, 6);
            this.dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.CornflowerBlue;
            this.dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        }

        private void BuscarData(string _strBuscar)
        {
            EData = false;
            this.dgv.Rows.Clear();
            this.dgv.Refresh();

            string _query =
                "   SELECT CATEGORIA,CATEGORIANOMBRE " +
                "     FROM CATEGORIAS " +
                "    WHERE ESTATUS = 1" +
                "      AND CATEGORIANOMBRE LIKE '%" + txtBuscar.Text + "%' " +
                " ORDER BY  ASC";

            SqlConnection cnx = new SqlConnection(cnn.db); cnx.Open();
            SqlCommand cmd = new SqlCommand(_query, cnx);

            SqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                dgv.Rows.Add();
                int xRow = dgv.Rows.Count - 1;

                dgv[0, xRow].Value = rdr["CATEGORIA"].ToString();
                dgv[1, xRow].Value = rdr["CATEGORIANOMBRE"].ToString();
            }

            cmd.Dispose();
            cnx.Close();
        }

        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                e.Handled = true;
                if (txtBuscar.Text.Trim() != string.Empty)
                {
                    btnBuscar.Focus();
                }
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            BuscarData(txtBuscar.Text);
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            if (dgv.RowCount > 0)
            {
                EData = true;
                var1 = dgv.CurrentRow.Cells[0].Value.ToString();
                var2 = dgv.CurrentRow.Cells[1].Value.ToString();

                this.Close();
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            //Limpiar el DataGridView
            EData = false;
            this.dgv.Rows.Clear();
            this.dgv.Refresh();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtBuscar_Leave(object sender, EventArgs e)
        {
            btnBuscar.PerformClick();
        }

    }
}
