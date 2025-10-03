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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Boolean ExisteData;
        private void Form1_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true; //Activa las teclas de funciones
            this.Text = "Maestro de Usuario";

            ExisteData = false;
            lblIdentifica.Text = Busco.BuscaUltimoNumero("0");
            pictureBox1.Image = System.Drawing.Image.FromFile(ruta.imagendefault);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Escape) //si la tecla que presionaste es igual a 27 entonces, cierra la aplicacion
            {
                this.Close(); //cerramos el formulario
            }

        }

        private void txtUsuario_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.F4) //si la tecla que presionaste es igual a 27 entonces, cierra la aplicacion
            {
                frmVENUSR frm = new frmVENUSR();
                frm.Show(); //cerramos el formulario
            }

        }

        private void txtUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {

            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                e.Handled = true;
                if (txtNombre.Text.Trim() != string.Empty)
                {
                    txtNombre.Focus();
                }
            }

        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {

            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                e.Handled = true;
                if (txtNombre.Text.Trim() != string.Empty)
                {
                    txtCorreo.Focus();
                }
            }

        }

        private void txtCorreo_KeyPress(object sender, KeyPressEventArgs e)
        {

            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                e.Handled = true;
                if (txtCorreo.Text.Trim() != string.Empty)
                {
                    txtPassword.Focus();
                }
            }

        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {

            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                e.Handled = true;
                if (txtPassword.Text.Trim() != string.Empty)
                {
                    txtPosicion.Focus();
                }
            }

        }

        private void txtPosicion_KeyPress(object sender, KeyPressEventArgs e)
        {

            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                e.Handled = true;
                if (txtPosicion.Text.Trim() != string.Empty)
                {
                    btnGuardar.Focus();
                }
            }

        }

        private void txtUsuario_Leave(object sender, EventArgs e)
        {

            if (txtUsuario.Text.Trim() != string.Empty)
            { BuscarUsuario(txtUsuario.Text); }

        }


        private void Form1_Load_1(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string _imagen = openFileDialog1.FileName;
                pictureBox1.Image = Image.FromFile(_imagen);
            }
        }

        private void BuscarPuestoDeTrabajo(string numPuesto)
        {
            string miQuery = "SELECT NOMBREDEPOSICION  FROM POSICION  WHERE IDPOSICION = @A1";

            SqlConnection cxn = new SqlConnection(cnn.db); cxn.Open();
            SqlCommand cmd = new SqlCommand(miQuery, cxn);
            cmd.Parameters.AddWithValue("@A1", numPuesto);

            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                lblPuestoDeTrabajo.Text = dr["NOMBREDEPOSICION"].ToString();
            }
        }

        private void BuscarUsuario(string numUSR)
        {

            ExisteData = false;

            string miQuery =
                "SELECT IDENTIFICATION, NOMBRE, NOMBRECORTO, CLAVE, POSICION, CORREO, FOTO " +
                "  FROM USUARIO" +
                " WHERE NOMBRECORTO = @A1 AND ACTIVO =1";

            SqlConnection cxn = new SqlConnection(cnn.db); cxn.Open();
            SqlCommand cmd = new SqlCommand(miQuery, cxn);
            cmd.Parameters.AddWithValue("@A1", numUSR);

            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                ExisteData = true;

                lblIdentifica.Text = dr["IDENTIFICATION"].ToString();
                txtNombre.Text = dr["NOMBRE"].ToString();
                txtCorreo.Text = dr["CORREO"].ToString();
                txtPassword.Text = dr["CLAVE"].ToString();
                txtUsuario.Text = dr["NOMBRECORTO"].ToString();
                txtPosicion.Text = dr["POSICION"].ToString();

                try
                {
                    // pictureBox1.Image = ConvertImage.ByteArrayToImage((Byte[])dr["FOTO"]);
                }
                catch
                {

                }
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void txtPosicion_Leave(object sender, EventArgs e)
        {
            if (txtPosicion.Text.Trim() != string.Empty)
            {
                BuscarPuestoDeTrabajo(txtPosicion.Text);
            }
        }

        private void ActualizarSecuencia(string _numID, string _next)
        {
            string _query = "UPDATE SECUENCIAS SET CONTADOR = @A2 WHERE ID = @A1";

            SqlConnection cnx = new SqlConnection(cnn.db); cnx.Open();
            SqlCommand cmd = new SqlCommand(_query, cnx);
            cmd.Parameters.AddWithValue("@A2", _numID);
            cmd.Parameters.AddWithValue("@A1", _next);

            cmd.ExecuteNonQuery();
            cmd.Dispose();
            cnx.Close();
        }
        private void LimpiarFormulario()
        {
            lblPuestoDeTrabajo.Text = string.Empty;
            txtCorreo.Clear();
            lblIdentifica.Text = "";
            label7.Text = "";
            txtPosicion.Clear();
            txtUsuario.Clear();
            txtNombre.Clear();
            txtPassword.Clear();
            pictureBox1.Image = null;
            ExisteData = false;

        }
        private void ActualizaData()
        {
            byte[] byteArrayImagen = ConvertImage.ImageToByteArray(pictureBox1.Image);

            string tQuery =
                "UPDATE USUARIO " +
                "   SET NOMBRE   = @A1, " +
                "       CLAVE    = @A3, " +
                "       POSICION = @A4, " +
                "       CORREO   = @A5  " +
                "       FOTO     = " + byteArrayImagen +
                "       SUCURSAL = @A6, " +
                "       ACTIVO   = @A7  " +
                " WHERE NOMBRECORTO = @A2";

            SqlConnection cxn = new SqlConnection(cnn.db); cxn.Open();
            SqlCommand cmd = new SqlCommand(tQuery, cxn);
            cmd.Parameters.AddWithValue("@A1", txtNombre.Text);
            cmd.Parameters.AddWithValue("@A2", txtUsuario.Text);
            cmd.Parameters.AddWithValue("@A3", txtPassword.Text);
            cmd.Parameters.AddWithValue("@A4", txtPosicion.Text);
            cmd.Parameters.AddWithValue("@A5", txtCorreo.Text);
            cmd.Parameters.AddWithValue("@A6", "01");
            cmd.Parameters.AddWithValue("@A7", "1");

            cmd.ExecuteNonQuery();
            cmd.Dispose();
            cxn.Close();
        }
        private void BorrarData(string usrName)
        {
            string tQuery = "UPDATE USUARIO SET ACTIVO = 3 WHERE NOMBRECORTO = @A2";

            SqlConnection cxn = new SqlConnection(cnn.db); cxn.Open();
            SqlCommand cmd = new SqlCommand(tQuery, cxn);
            cmd.Parameters.AddWithValue("@A2", usrName);

            cmd.ExecuteNonQuery();
            cmd.Dispose();
            cxn.Close();
        }

        private void InsertarData() 
        { 
        byte[] byteArrayImagen = ConvertImage.ImageToByteArray(pictureBox1.Image); 
            
        string tQuery = "INSERT INTO USUARIO (IDENTIFICACION, NOMBRE, NOMBRECORTO, CLAVE, POSICION, CORREO, FOTO, ACTIVO, SUCURSL) " + " VALUES (@A0, @A1, @A2, @A3, @A4, @A5, @A6, @A7, @A8)"; 
        
        SqlConnection cxn = new SqlConnection(cnn.db); cxn.Open(); 
        SqlCommand cmd = new SqlCommand(tQuery, cxn); 
        
        cmd.Parameters.AddWithValue("@A0", lblIdentifica.Text); 
        cmd.Parameters.AddWithValue("@A1", txtNombre.Text); 
        cmd.Parameters.AddWithValue("@A2", txtUsuario.Text);
        cmd.Parameters.AddWithValue("@A3", txtPassword.Text); 
        cmd.Parameters.AddWithValue("@A4", txtPosicion.Text); 
        cmd.Parameters.AddWithValue("@A5", txtCorreo.Text); 
        cmd.Parameters.AddWithValue("@A6", byteArrayImagen); 
        cmd.Parameters.AddWithValue("@A7", "1"); 
        cmd.Parameters.AddWithValue("@A8", "01");
      
        cmd.ExecuteNonQuery(); 
        cmd.Dispose(); 
        cxn.Close(); 

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {

            LimpiarFormulario();
            lblIdentifica.Text = Busco.BuscaUltimoNumero("0");
            txtUsuario.Focus();

        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {

            if(ExisteData == true)
            {
                BorrarData(txtUsuario.Text);
                lblIdentifica.Text = Busco.BuscaUltimoNumero("0");
                LimpiarFormulario();
            }

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {

            this.Close();

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

            if (!ValidarFormulario())
                return;

            if (!ExisteData)
            {
                InsertarData();
                ActualizarSecuencia("0", lblIdentifica.Text);
            }
            else
            {
                ActualizaData();
            }

            LimpiarFormulario();
            txtUsuario.Focus();
        }


        private bool ValidarFormulario()
        {
            if (string.IsNullOrWhiteSpace(txtUsuario.Text))
            {
                MostrarMensaje("usuario");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MostrarMensaje("nombre");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtCorreo.Text))
            {
                MostrarMensaje("correo");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MostrarMensaje("password");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtPosicion.Text))
            {
                MostrarMensaje("Posicion");
                return false;
            }

            return true;
        }

        private void MostrarMensaje(string campo)
        {
            MessageBox.Show($"Falta el {campo}", "MiApp", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnUsuario_Click(object sender, EventArgs e)
        {
            frmVENUSR frm = new frmVENUSR();
            frm.Show();

            if (frm.EData == true)
            {
                txtUsuario.Text = frm.var1;

                BuscarUsuario(txtUsuario.Text);
            }
        }

        private void btnPosicion_Click(object sender, EventArgs e)
        {

            frmVENUSR frm = new frmVENUSR();
            frm.Show();

            if (frm.EData == true)
            {
                txtUsuario.Text = frm.var1;

                BuscarUsuario(txtUsuario.Text);
            }

        }
    }
}
