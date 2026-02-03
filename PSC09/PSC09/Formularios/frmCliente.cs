using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PSC09
{
    public partial class frmCliente : Form
    {

        public frmCliente()
        {
            InitializeComponent();
        }

        bool ExisteData;

        private void BuscarCliente(string cliente)
        {
            ExisteData = false;

            string miQuery =
                 @"SELECT IDCLIENTE, IDENTIFICACION, NOMBRE, DIRECCION, SECTOR, CIUDAD, TELEFONO, MOVIL, CORREO, 
                       IMPUESTOPAGA, FOTO, NIVELPRECIO, CONTACTO, ENVIOSDIRECCION, TIPODOCUMENTO, TIPOCLIENTE
                    FROM CLIENTES WHERE IDCLIENTE = @A1 AND  IDESTATUS = '1'";

            using (SqlConnection cnx = new SqlConnection(cnn.db))
            {
                cnx.Open();

                SqlCommand cmd = new SqlCommand(miQuery, cnx);
                cmd.Parameters.AddWithValue("@A1", cliente);
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    ExisteData = true;

                    txtCliente.Text = dr["IDCLIENTE"].ToString();
                    txtDocumento.Text = dr["IDENTIFICACION"].ToString();
                    txtNombre.Text = dr["NOMBRE"].ToString();
                    txtDireccion.Text = dr["DIRECCION"].ToString();
                    txtSector.Text = dr["SECTOR"].ToString();
                    txtCiudad.Text = dr["CIUDAD"].ToString();
                    txtTelefono.Text = dr["TELEFONO"].ToString();
                    txtMovil.Text = dr["MOVIL"].ToString();
                    txtCorreo.Text = dr["CORREO"].ToString();

                    txtEnvio.Text = dr["ENVIOSDIRECCION"].ToString();
                    txtContacto.Text = dr["CONTACTO"].ToString();
                    lblBalance.Text = dr["BALANCEPENDIENTE"].ToString();

                    if (dr["NIVELPRECIO"].ToString() == "1")
                        CboNivel.Text = "PRECIO A";
                    if (dr["NIVELPRECIO"].ToString() == "2")
                        CboNivel.Text = "PRECIO B";
                    if (dr["NIVELPRECIO"].ToString() == "3")
                        CboNivel.Text = "PRECIO C";
                    if (dr["NIVELPRECIO"].ToString() == "4")
                        CboNivel.Text = "PRECIO D";
                    if (dr["NIVELPRECIO"].ToString() == "5")
                        CboNivel.Text = "PRECIO E";


                    if (dr["IMPUESTOPAGA"].ToString() == "1")
                        CboPaga.Text = "Si";
                    if (dr["IMPUESTOPAGA"].ToString() == "2")
                        CboPaga.Text = "No";


                    if (dr["TIPODOCUMENTO"].ToString() == "1")
                        CboDocumento.Text = "Cedula";
                    if (dr["TIPODOCUMENTO"].ToString() == "2")
                        CboDocumento.Text = "Pasaporte";
                    if (dr["TIPODOCUMENTO"].ToString() == "3")
                        CboDocumento.Text = "RNC";

                    if (dr["TIPOCLIENTE"].ToString() == "1")
                        CboTipo.Text = "Persona";
                    if (dr["TIPOCLIENTE"].ToString() == "2")
                        CboTipo.Text = "Empresa";
                    if (dr["TIPOCLIENTE"].ToString() == "3")
                        CboTipo.Text = "Gobierno";
                    if (dr["TIPOCLIENTE"].ToString() == "4")
                        CboTipo.Text = "Ongs";

                    try
                    {
                        PicCliente.Image = ConvertImage.ByteArrayToImage((byte[])dr["FOTO"]);
                    }
                    catch
                    {
                        if (PicCliente.Image == null)
                            PicCliente.Image = Image.FromFile(ruta.imagendefault);
                    }
                }
            }
        }

        private void frmClientes_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            this.Text = "Clientes";

            txtCliente.Text = Busco.BuscaUltimoNumero("1");
            LLenarComboBox();
            PicCliente.Image = Image.FromFile(ruta.imagendefault);
        }



        private void BorrarRegistro(string cliente)
        {
            string query = @"UPDATE CLIENTES SET ESTATUS = 0 WHERE IDCLIENTE = @A1";

            using (SqlConnection cxn = new SqlConnection(cnn.db))
            {
                cxn.Open();

                SqlCommand cmd = new SqlCommand(query, cxn);
                cmd.Parameters.AddWithValue("@A2", cliente);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
        }

        private void LimpiarFormulario()
        {
            txtCliente.Clear();
            txtDocumento.Clear();
            txtNombre.Clear();
            txtDireccion.Clear();
            txtSector.Clear();
            txtCiudad.Clear();
            txtTelefono.Clear();
            txtMovil.Clear();
            txtCorreo.Clear();
            txtContacto.Clear();
            txtEnvio.Clear();
            lblBalance.Text = "";
            PicCliente.Image = null;

            ExisteData = false;

            if (PicCliente.Image == null)
                PicCliente.Image = Image.FromFile(ruta.imagendefault);
        }

        private void InsertarClientes(string cliente)
        {
            if (PicCliente.Image == null)
                PicCliente.Image = Image.FromFile(ruta.imagendefault);

            byte[] byteArray = ConvertImage.ImageToByteArray(PicCliente.Image);

            string query = @"INSERT INTO CLIENTES ( IDCLIENTE, NOMBRECLIENTE, IDENTIFICACION, TIPOCLIENTE, DIRECCION, SECTOR,
                     CIUDAD, TELEFONO, MOVIL, CORREO, ESTATUS, FOTO, ENVIOSDIRECCION, BALANCEPENDIENTE, NIVELPRECIO, 
                     TIPODOCUMENTO, PAGAIMPUESTO )
                     VALUES (@A1, @A2, @A3, @A4, @A5, @A6, @A7, @A8, @A9, @A10, @A11, @A12, @A13, @A14, @A15, @A16, @A17)";

            using (SqlConnection cxn = new SqlConnection(cnn.db))
            {
                cxn.Open();
                SqlCommand cmd = new SqlCommand(query, cxn);

                cmd.Parameters.AddWithValue("@A1", txtCliente.Text);
                cmd.Parameters.AddWithValue("@A2", txtNombre.Text);

                cmd.Parameters.AddWithValue("@A3", txtDocumento.Text);
                if (CboTipo.Text == "Persona")
                    cmd.Parameters.AddWithValue("@A4", "1");
                if (CboTipo.Text == "Empresa")
                    cmd.Parameters.AddWithValue("@A4", "2");
                if (CboTipo.Text == "Gobierno")
                    cmd.Parameters.AddWithValue("@A4", "3");
                if (CboTipo.Text == "Ongs")
                    cmd.Parameters.AddWithValue("@A4", "4");

                cmd.Parameters.AddWithValue("@A5", txtDireccion.Text);
                cmd.Parameters.AddWithValue("@A6", txtSector.Text);
                cmd.Parameters.AddWithValue("@A7", txtCiudad.Text);
                cmd.Parameters.AddWithValue("@A8", txtTelefono.Text);

                cmd.Parameters.AddWithValue("@A9", txtMovil.Text);  // si no es numérico no uses Convert
                cmd.Parameters.AddWithValue("@A10", txtCorreo.Text);

                cmd.Parameters.AddWithValue("@A11", "1");
                cmd.Parameters.AddWithValue("@A12", byteArray);
                cmd.Parameters.AddWithValue("@A13", txtEnvio.Text);
                cmd.Parameters.AddWithValue("@A14", lblBalance.Text);

                if (CboNivel.Text == "PRECIO A")
                    cmd.Parameters.AddWithValue("@A15", "1");
                if (CboNivel.Text == "PRECIO B")
                    cmd.Parameters.AddWithValue("@A15", "2");
                if (CboNivel.Text == "PRECIO C")
                    cmd.Parameters.AddWithValue("@A4", "3");
                if (CboNivel.Text == "PRECIO D")
                    cmd.Parameters.AddWithValue("@A15", "4");
                if (CboNivel.Text == "PRECIO E")
                    cmd.Parameters.AddWithValue("@A15", "5");

                if (CboDocumento.Text == "Cedula")
                    cmd.Parameters.AddWithValue("@A16", "1");
                if (CboDocumento.Text == "Pasaporte")
                    cmd.Parameters.AddWithValue("@A16", "2");
                if (CboDocumento.Text == "RNC")
                    cmd.Parameters.AddWithValue("@A16", "3");

                if (CboPaga.Text == "Si")
                    cmd.Parameters.AddWithValue("@A17", "1");
                if (CboPaga.Text == "No")
                    cmd.Parameters.AddWithValue("@A17", "2");

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
        }

        private void ActualizarClientes(string cliente)
        {
            if (PicCliente.Image == null)
                PicCliente.Image = Image.FromFile(ruta.imagendefault);

            byte[] byteArray = ConvertImage.ImageToByteArray(PicCliente.Image);

            string query = @"";

            using (SqlConnection cxn = new SqlConnection(cnn.db))
            {
                cxn.Open();
                SqlCommand cmd = new SqlCommand(query, cxn);

                cmd.Parameters.AddWithValue("@A1", txtCliente.Text);
                cmd.Parameters.AddWithValue("@A2", txtNombre.Text);

                cmd.Parameters.AddWithValue("@A3", txtDocumento.Text);

                if (CboTipo.Text == "Persona")
                    cmd.Parameters.AddWithValue("@A4", "1");
                if (CboTipo.Text == "Empresa")
                    cmd.Parameters.AddWithValue("@A4", "2");
                if (CboTipo.Text == "Gobierno")
                    cmd.Parameters.AddWithValue("@A4", "3");
                if (CboTipo.Text == "Ongs")
                    cmd.Parameters.AddWithValue("@A4", "4");

                cmd.Parameters.AddWithValue("@A5", txtDireccion.Text);
                cmd.Parameters.AddWithValue("@A6", txtSector.Text);
                cmd.Parameters.AddWithValue("@A7", txtCiudad.Text);
                cmd.Parameters.AddWithValue("@A8", txtTelefono.Text);

                cmd.Parameters.AddWithValue("@A9", txtMovil.Text);  // si no es numérico no uses Convert
                cmd.Parameters.AddWithValue("@A10", txtCorreo.Text);

                cmd.Parameters.AddWithValue("@A11", "1");
                cmd.Parameters.AddWithValue("@A12", byteArray);
                cmd.Parameters.AddWithValue("@A13", txtEnvio.Text);
                cmd.Parameters.AddWithValue("@A14", lblBalance.Text);

                if (CboNivel.Text == "PRECIO A")
                    cmd.Parameters.AddWithValue("@A15", "1");
                if (CboNivel.Text == "PRECIO B")
                    cmd.Parameters.AddWithValue("@A15", "2");
                if (CboNivel.Text == "PRECIO C")
                    cmd.Parameters.AddWithValue("@A4", "3");
                if (CboNivel.Text == "PRECIO D")
                    cmd.Parameters.AddWithValue("@A15", "4");
                if (CboNivel.Text == "PRECIO E")
                    cmd.Parameters.AddWithValue("@A15", "5");

                if (CboDocumento.Text == "Cedula")
                    cmd.Parameters.AddWithValue("@A16", "1");
                if (CboDocumento.Text == "Pasaporte")
                    cmd.Parameters.AddWithValue("@A16", "2");
                if (CboDocumento.Text == "RNC")
                    cmd.Parameters.AddWithValue("@A16", "3");

                if (CboPaga.Text == "Si")
                    cmd.Parameters.AddWithValue("@A17", "1");
                if (CboPaga.Text == "No")
                    cmd.Parameters.AddWithValue("@A17", "2");

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
        }

        private void ActualizaSecuenciaClientes(string id, string cliente)
        {
            string query = @"UPDATE SECUENCIAS SET CONTADOR = @A2 WHERE ID = @A1";

            using (SqlConnection cxn = new SqlConnection(cnn.db))
            {
                cxn.Open();

                SqlCommand cmd = new SqlCommand(query, cxn);
                cmd.Parameters.AddWithValue("@A1", id);
                cmd.Parameters.AddWithValue("@A2", cliente);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
        }

        private void LLenarComboBox()
        {
            List<Item> lista = new List<Item>();

            lista.Add(new Item("Persona", 1));
            lista.Add(new Item("Empresa", 2));
            lista.Add(new Item("Gobierno", 3));
            lista.Add(new Item("Ongs", 4));

            CboTipo.DisplayMember = "_nombre";
            CboTipo.ValueMember = "_valor";
            CboTipo.DataSource = lista;

            // ------------------------------

            List<Item> lists = new List<Item>();

            lists.Add(new Item("Cedula", 1));
            lists.Add(new Item("Pasaporte", 2));
            lists.Add(new Item("RNC", 3));

            CboDocumento.DisplayMember = "_nombre";
            CboDocumento.ValueMember = "_valor";
            CboDocumento.DataSource = lists;

            // ------------------------------

            List<Item> listx = new List<Item>();

            listx.Add(new Item("PRECIO A", 1));
            listx.Add(new Item("PRECIO B", 2));
            listx.Add(new Item("PRECIO C", 3));
            listx.Add(new Item("PRECIO D", 4));
            listx.Add(new Item("PRECIO E", 5));

            CboNivel.DisplayMember = "_nombre";
            CboNivel.ValueMember = "_valor";
            CboNivel.DataSource = listx;

            // ------------------------------

            List<Item> listo = new List<Item>();

            listo.Add(new Item("Si", 1));
            listo.Add(new Item("No", 2));

            CboPaga.DisplayMember = "_nombre";
            CboPaga.ValueMember = "_valor";
            CboPaga.DataSource = listo;
        }

        private void txtCorreo_KeyPress(object sender, KeyPressEventArgs e)

        {

            // Letras, números y caracteres permitidos

            if (char.IsLetterOrDigit(e.KeyChar) ||

                e.KeyChar == '@' ||

                e.KeyChar == '.' ||

                e.KeyChar == '_' ||

                e.KeyChar == '-' ||

                char.IsControl(e.KeyChar))

            {

                e.Handled = false;

            }

            else

            {

                e.Handled = true; // Bloquea caracteres no válidos

            }

        }

        private void txtCorreo_Leave(object sender, EventArgs e)

        {

            string correo = txtCorreo.Text.Trim();

            // Regex para validar correo

            string patron = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";

            if (!Regex.IsMatch(correo, patron))

            {

                MessageBox.Show("Correo inválido, por favor ingrese uno correcto.",

                                "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                txtCorreo.Focus();

                txtCorreo.SelectAll();

            }

        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)

        {

            // Solo números y teclas de control (Backspace, Supr, etc.)

            if (char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar))

            {

                e.Handled = false;

            }

            else

            {

                e.Handled = true;  // Bloquea caracteres no numéricos

            }

        }

        private void txtTelefono_Leave(object sender, EventArgs e)

        {

            string movil = txtMovil.Text.Trim();

            // Validación básica: mínimo 8 y máximo 10 dígitos

            if (movil.Length < 8 || movil.Length > 10)

            {

                MessageBox.Show("Número de teléfono inválido. Debe tener entre 8 y 10 dígitos.",

                                "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                txtTelefono.Focus();

                txtTelefono.SelectAll();

            }

        }

        private void txtMovil_KeyPress(object sender, KeyPressEventArgs e)

        {

            // Solo números y teclas de control (Backspace, Supr, etc.)

            if (char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar))

            {

                e.Handled = false;

            }

            else

            {

                e.Handled = true;  // Bloquea caracteres no numéricos

            }

        }

        private void txtMovil_Leave(object sender, EventArgs e)

        {

            string movil = txtMovil.Text.Trim();

            // Solo dígitos y debe tener entre 8 y 10 dígitos

            string patron = @"^\d{8,10}$";

            if (!Regex.IsMatch(movil, patron))

            {

                MessageBox.Show("Número de teléfono inválido. Solo números (8 a 10 dígitos).",

                                "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                txtMovil.Focus();

                txtMovil.SelectAll();

            }

        }


        private bool ValidarFormulario()
        {
            if (string.IsNullOrWhiteSpace(txtCliente.Text))
            {
                MostrarMensaje("Cliente");
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtDocumento.Text))
            {
                MostrarMensaje("Documento");
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MostrarMensaje("Nombre");
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtDireccion.Text))
            {
                MostrarMensaje("Direccion");
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtSector.Text))
            {
                MostrarMensaje("Sector");
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtCiudad.Text))
            {
                MostrarMensaje("Ciudad");
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtTelefono.Text))
            {
                MostrarMensaje("Telefono");
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtMovil.Text))
            {
                MostrarMensaje("Movil");
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtCorreo.Text))
            {
                MostrarMensaje("Correo");
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtContacto.Text))
            {
                MostrarMensaje("Contacto");
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtEnvio.Text))
            {
                MostrarMensaje("Direccion de Envio");
                return false;
            }
            return true;
        }
        private void MostrarMensaje(string campo)
        {
            MessageBox.Show($"Falta el {campo}", "Miapp", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void txtCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                e.Handled = true;
                if (txtCliente.Text.Trim() != string.Empty)
                {
                    CboTipo.Focus();
                }
            }
        }

        private void txtCliente_Leave(object sender, EventArgs e)
        {
            if (txtCliente.Text.Trim() != string.Empty)
            {
                BuscarCliente(txtCliente.Text);
            }
        }
    }
}
