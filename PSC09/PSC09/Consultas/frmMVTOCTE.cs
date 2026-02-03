using PSC09.Formularios;
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
using System.Xml.Linq;

namespace PSC09
{
    public partial class frmMVTOCTE : Form
    {
        public frmMVTOCTE()
        {
            InitializeComponent();
            EstiloDgv();
        }

        string debito;
        string credito;
        string bcepend;

        double tDeb;
        double tCre;

        private void frmMVTOCTE_Load(object sender, EventArgs e)
        {
            this.Text = "Movimientos Cliente";
            this.KeyPreview = true;
        }

        private void frmMVTOCTE_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void txtCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                e.Handled = true;
                if (txtCliente.Text.Trim() != string.Empty)
                {
                    btnBuscar.Focus();
                }
            }
        }

        private void txtCliente_Leave(object sender, EventArgs e)
        {
            if (txtCliente.Text.Trim() != string.Empty)
            {
                lblNombre.Text = Busco.BuscarCliente(txtCliente.Text, out bool found, out string nivel, out string tipo, out string paga);

                BuscarMovimientosCliente(txtCliente.Text);
            }
        }

        private void txtCliente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F4)
            {
                btnVENCTE.PerformClick();
            }
        }

        // --------------------------------------------------------
        // BOTONES
        // --------------------------------------------------------
        private void btnVENCTE_Click(object sender, EventArgs e)
        {
            frmVENCTE frm = new frmVENCTE();
            frm.ShowDialog();

            if (frm.EData == true)
            {
                txtCliente.Text = frm.var1;
                lblNombre.Text = frm.var2;

                BuscarMovimientosCliente(txtCliente.Text);  // ejecuta el metodo, para mostrar la data del cliente
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.dgv.Rows.Clear();
            this.dgv.Refresh();

            lblBalance.Text = "";
            lblCredito.Text = "";
            lblDebito.Text = "";
            lblNombre.Text = "";
            txtCliente.Clear();

            txtCliente.Focus();
        }

        private void btnSeleccion_Click(object sender, EventArgs e)
        {
            if (dgv.RowCount > 0)  // VERIFICA QUE EL DGV TENGA LINEA
            {
                // Asigna los valores 
                string _origen = dgv.CurrentRow.Cells[4].Value.ToString();
                string _docume = dgv.CurrentRow.Cells[1].Value.ToString();

                if (_origen == "D") // abrira el formulario de factura, por que el origen es debito
                {
                    frmFactura frm = new frmFactura(txtCliente.Text, _docume);
                    frm.ShowDialog();
                }

                if (_origen == "C") // abrira el formulario de recibo, por que el origen es credito
                {
                    frmRecibos frm = new frmRecibos();
                    frm.ShowDialog();
                }
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnSeleccion.PerformClick();  // ejecuta el evento del boton btnSeleccion
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if(txtCliente.Text !="")  BuscarMovimientosCliente(txtCliente.Text);
        }

        // --------------------------------------------------------
        // METODOS
        // --------------------------------------------------------

        private void BuscarMovimientosCliente(string nmrCliente)
        {
            string sQuery = "SELECT IDCLIENTE, FECHA, DOCUMENTO, APLICADO, ORIGEN, TIPDOC, BCEPENDIENTE, MONTO " +
                            "  FROM MVTOCTE " +
                            " WHERE IDCLIENTE ='" + nmrCliente +
                            "'  AND ACTIVO    = 1";

            SqlConnection cxn = new SqlConnection(cnn.db); cxn.Open();
            SqlCommand cmd = new SqlCommand(sQuery, cxn);
            SqlDataReader rsd = cmd.ExecuteReader();

            while (rsd.Read())
            {
                dgv.Rows.Add();
                int xRows = dgv.Rows.Count - 1;

                debito = "";
                credito = "";
                bcepend = "";

                string origen = rsd["ORIGEN"].ToString();  // origen del registro debito, credito
                if (origen == "D")
                {
                    debito = rsd["MONTO"].ToString();
                    bcepend = rsd["BCEPENDIENTE"].ToString();
                    credito = "";
                }

                if (origen == "C")
                {
                    debito = "";
                    credito = rsd["MONTO"].ToString();
                    bcepend = "";
                }

                dgv[0, xRows].Value = rsd["TIPDOC"].ToString();
                dgv[1, xRows].Value = rsd["DOCUMENTO"].ToString();
                dgv[2, xRows].Value = rsd["APLICADO"].ToString();
                dgv[3, xRows].Value = rsd["FECHA"].ToString();
                dgv[4, xRows].Value = rsd["ORIGEN"].ToString();
                dgv[5, xRows].Value = debito;
                dgv[6, xRows].Value = credito;
                dgv[7, xRows].Value = bcepend;
            }

            TotalizarMovimientos();
        }

        private void TotalizarMovimientos() 
        {
            lblBalance.Text = "";
            lblCredito.Text = "";
            lblDebito.Text = "";

            foreach (DataGridViewRow row in dgv.Rows)
            {
                // obtiene los valores de la columna
                string _debito = (row.Cells[5].Value.ToString());
                string _credito = (row.Cells[6].Value.ToString());

                // sumariza los debitos y los creditos
                if (_debito  != "") tDeb = tDeb + Convert.ToDouble(_debito);
                if (_credito != "") tCre = tCre + Convert.ToDouble(_credito);
            }

            lblDebito.Text = tDeb.ToString();
            lblCredito.Text = tCre.ToString();

            lblBalance.Text = (tDeb - tCre).ToString();
        }

        private void EstiloDgv()
        {
            this.dgv.EnableHeadersVisualStyles = false;
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.ColumnHeadersVisible = true;
            this.dgv.RowHeadersVisible = false;

            this.dgv.Columns.Add("Col00", "Tipo Doc");
            this.dgv.Columns.Add("Col01", "Documento");
            this.dgv.Columns.Add("Col02", "Aplicado");
            this.dgv.Columns.Add("Col03", "Fecha");
            this.dgv.Columns.Add("Col04", "Origen");
            this.dgv.Columns.Add("Col05", "Debito");
            this.dgv.Columns.Add("Col06", "Credito");
            this.dgv.Columns.Add("Col06", "Balance");

            DataGridViewColumn
            column = dgv.Columns[00]; column.Width = 050;
            column = dgv.Columns[01]; column.Width = 100;
            column = dgv.Columns[02]; column.Width = 100;
            column = dgv.Columns[03]; column.Width = 110;
            column = dgv.Columns[04]; column.Width = 120;
            column = dgv.Columns[05]; column.Width = 140;
            column = dgv.Columns[06]; column.Width = 140;
            column = dgv.Columns[07]; column.Width = 140;

            this.dgv.BorderStyle = BorderStyle.None;
            this.dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            this.dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgv.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            this.dgv.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            this.dgv.BackgroundColor = Color.LightGray;

            this.dgv.EnableHeadersVisualStyles = false;
            this.dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            this.dgv.ColumnHeadersDefaultCellStyle.Padding = new Padding(0, 6, 0, 6);
            this.dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.CornflowerBlue;
            this.dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        }
    }
}
