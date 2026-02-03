using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace PSC09
{
    public partial class frmVENFAT: Form
    {
        public frmVENFAT()
        {
            InitializeComponent();
        }

        public Boolean EData;
        public string var1;
        public string var2;

        private void frmVENFAT_Load(object sender, EventArgs e)
        {
            this.Text = "Consulta";
            this.KeyPreview = true;
            EData = false;
        }

        private void frmVENFAT_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            BuscarDatos(txtBuscar.Text);
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
            // Limpia el DataGridView
            this.dgv.Rows.Clear();
            this.dgv.Refresh();

            EData = false;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void BuscarDatos(string buscar)
        {
            // Limpia el DataGridView
            this.dgv.Rows.Clear();
            this.dgv.Refresh();

            EData = false;

            string miQuery = "     SELECT A.FACTURA, " +
                             "            A.CLIENTE, " +
                             "            B.NOMBRECLIENTE, " +
                             "            A.FECHA, " +
                             "            A.MONTOFACTURADO " +
                             "       FROM HFACTURA A " +
                             " INNER JOIN CLIENTES B ON A.CLIENTE = B.IDCLIENTE" +
                             "      WHERE B.NOMBRECLIENTE LIKE '%" + buscar +
                             "%'      AND A.ACTIVO  = '0'";

            SqlConnection cxn = new SqlConnection(cnn.db); cxn.Open();
            SqlCommand cmd = new SqlCommand(miQuery, cxn);

            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                dgv.Rows.Add();  // agregamos una linea al contador
                int xrows = dgv.Rows.Count - 1;  // le restamo uno al contador de linea

                dgv[0, xrows].Value = dr["FACTURA"].ToString();
                dgv[1, xrows].Value = dr["NOMBRECLIENTE"].ToString();
                dgv[2, xrows].Value = dr["FECHA"].ToString();
                dgv[4, xrows].Value = dr["MONTOFACTURADO"].ToString();
            }

            cmd.Dispose();
            cxn.Close();
        }

        private void EstiloDataGridView()
        {
            this.dgv.EnableHeadersVisualStyles = false;
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.ColumnHeadersVisible = true;
            this.dgv.RowHeadersVisible = false;

            this.dgv.Columns.Add("Col00", "FACTURA");
            this.dgv.Columns.Add("Col01", "NOMBRE");
            this.dgv.Columns.Add("Col02", "FECHA");
            this.dgv.Columns.Add("Col03", "MONTO");

            DataGridViewColumn
            column = dgv.Columns[00]; column.Width = 140;
            column = dgv.Columns[01]; column.Width = 300;
            column = dgv.Columns[00]; column.Width = 100;
            column = dgv.Columns[00]; column.Width = 100;

            this.dgv.BorderStyle = BorderStyle.FixedSingle;
            this.dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            this.dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgv.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            this.dgv.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            this.dgv.BackgroundColor = Color.LightGray;

            this.dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            this.dgv.ColumnHeadersDefaultCellStyle.Padding = new Padding(0, 6, 0, 6);
            this.dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.CornflowerBlue;
            this.dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
