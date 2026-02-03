using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PSC09
{
    public partial class frmMenu : Form
    {
        public frmMenu()
        {
            InitializeComponent();
        }

        private void usuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.ShowDialog();
        }

        private void articuloToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProducto frm = new frmProducto();
            frm.ShowDialog();
        }

        private void clienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCliente frm = new frmCliente();
            frm.ShowDialog();
        }

        private void ProductoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void FacturaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmFactura frm = new frmFactura("","");
            frm.ShowDialog();
        }

        private void VENSUCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmVENUSR frm = new frmVENUSR();
            frm.ShowDialog();
        }
    }
}
