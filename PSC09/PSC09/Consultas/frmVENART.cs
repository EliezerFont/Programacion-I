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
    public partial class frmVENART : Form
    {
        public frmVENART()
        {
            InitializeComponent();
            EstiloDGV();
        }

        public Boolean EData;
        public string var1;
        public string var2;

        private void frmVENART_Load(object sender, EventArgs e)
        {
            this.Text = "Consulta";
            this.KeyPreview = true;
            EData = false;

            EstiloDGV();
        }

        private void frmVENART_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
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

        private void txtBuscar_Leave(object sender, EventArgs e)
        {
            btnBuscar.PerformClick();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            BuscarData(txtBuscar.Text);
        }

        private void btnSelecciona_Click(object sender, EventArgs e)
        {
            if (dgv.Rows.Count > 0)
            {
                if (dgv.CurrentRow != null)
                {
                    if (dgv.CurrentRow.Cells[0].Value != null &&
                        dgv.CurrentRow.Cells[1].Value != null)
                    {
                        EData = true;
                        var1 = dgv.CurrentRow.Cells[0].Value.ToString();
                        var2 = dgv.CurrentRow.Cells[1].Value.ToString();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("La fila seleccionada tiene valores vacíos.",
                                       "Advertencia",
                                       MessageBoxButtons.OK,
                                       MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Por favor, seleccione una fila.",
                                   "Advertencia",
                                   MessageBoxButtons.OK,
                                   MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("No hay datos para seleccionar.",
                               "Información",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Information);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            EData = false;
            this.dgv.Rows.Clear();
            this.dgv.Refresh();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e) // ✅ CORREGIDO
        {
            if (e.RowIndex >= 0)
            {
                EData = true;
                var1 = dgv.Rows[e.RowIndex].Cells[0].Value.ToString();
                var2 = dgv.Rows[e.RowIndex].Cells[1].Value.ToString();
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

            this.dgv.Columns.Add("A", "IDPRODUCTO");
            this.dgv.Columns.Add("B", "DESCRIPCION");
            this.dgv.Columns.Add("c", "STOCK");

            DataGridViewColumn column;
            column = dgv.Columns[0]; column.Width = 120;
            column = dgv.Columns[1]; column.Width = 250;
            column = dgv.Columns[2]; column.Width = 250;

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
                @"  SELECT IDPRODUCTO, DESCRIPCION, STOCK 
                    FROM PRODUCTOS 
                    WHERE ESTATUS = 1 
                    AND DESCRIPCION LIKE @buscar 
                    ORDER BY DESCRIPCION ASC";

            using (SqlConnection cnx = new SqlConnection(cnn.db))
            {
                cnx.Open();
                using (SqlCommand cmd = new SqlCommand(_query, cnx))
                {
                    cmd.Parameters.AddWithValue("@buscar", "%" + txtBuscar.Text + "%");

                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            dgv.Rows.Add(
                                rdr["IDPRODUCTO"].ToString(),
                                rdr["DESCRIPCION"].ToString(),
                                rdr["STOCK"].ToString()
                            );
                        }
                    }
                }
            }
        }
    }
}
