using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using System.Data.SqlClient;
using System.Drawing.Printing;
using System.Collections;

namespace PSC09
{
    public partial class frmProducto : Form
    {
        public frmProducto()
        {
            InitializeComponent();
            EstiloDGV();
            EstiloDGV_OFER();
            EstiloDGV_ARTICULO();
            EstiloDGV_ALM();
            EstiloDGV_OFERTAS();
        }

        bool ExisteData;

        private void frmProducto_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            this.Text = "Articulos / Productos";

            txtArticulo.Text = Busco.BuscaUltimoNumero("4");      // Busca el siguiente codigo de articulo
            PicProducto.Image = Image.FromFile(ruta.imagendefault);  // coloca la imagen segun la ruta que esta en la clase

            txtAltura.Text = "40";  // coloca la altura maxima de las barras 
            txtCopia.Text = "2";    // cantidad de copias a imprimir

            MostrarCodigoBarra(txtArticulo.Text, txtAltura.Text);     // Muestra el codigo de barra
        }

        private void frmProducto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void txtArticulo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F4)
            {
                btnArticulo.PerformClick();
            }
        }

        private void txtArticulo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                e.Handled = true;
                if (txtArticulo.Text.Trim() != string.Empty)
                {
                    txtNombre.Focus();
                }
            }
        }

        private void txtArticulo_Leave(object sender, EventArgs e)
        {
            if (txtArticulo.Text.Trim() != string.Empty)
            {
                BuscarArticulo(txtArticulo.Text);
            }
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                e.Handled = true;
                if (txtNombre.Text.Trim() != string.Empty)
                {
                    txtCosto.Focus();
                }
            }
        }

        private void txtCosto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                e.Handled = true;
                if (txtCosto.Text.Trim() != string.Empty)
                {
                    txtPorciento.Focus();
                }
                return;
            }

            // Permite digitos, teclas de control y un punto decimal
            if (char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar))
            {
                // pertimido
                return;
            }

            // permite un solo punto o coma decimal, pero no ambos
            if ((e.KeyChar == '.'
                || e.KeyChar == ',')
                && !txtCosto.Text.Contains('.')
                && !txtCosto.Text.Contains(','))
            {
                return;
            }

            e.Handled = true;
        }

        private void txtCosto_Leave(object sender, EventArgs e)
        {
            string texto = txtCosto.Text.Trim();

            if (string.IsNullOrEmpty(texto))
                return;

            // reemplaza ',' por '.'
            string textoNormalizado = texto.Replace(',', '.');

            // Intentar convertir a decimal con punto como separador
            if (!decimal.TryParse(textoNormalizado, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal valor))
            {
                MessageBox.Show("Ingrese un número válido.", "ITLA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCosto.Focus();
                return;
            }

            // Muestra con 2 decimales, usa coma o punto según cultura local
            txtCosto.Text = valor.ToString("N2"); // 123,123.00
        }


        private void txtPorciento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                e.Handled = true;
                if (txtPorciento.Text.Trim() != string.Empty)
                {
                    txtBarCode.Focus();
                }
                return;
            }

            // Permite digitos, teclas de control y un punto decimal
            if (char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar))
            {
                // pertimido
                return;
            }

            // permite un solo punto o coma decimal, pero no ambos
            if ((e.KeyChar == '.'
                || e.KeyChar == ',')
                && !txtPorciento.Text.Contains('.')
                && !txtPorciento.Text.Contains(','))
            {
                return;
            }

            e.Handled = true;
        }

        private void txtPorciento_Leave(object sender, EventArgs e)
        {
            string texto = txtPorciento.Text.Trim();

            if (string.IsNullOrEmpty(texto))
                return;

            // reemplaza ',' por '.'
            string textoNormalizado = texto.Replace(',', '.');

            // Intentar convertir a decimal con punto como separador
            if (!decimal.TryParse(textoNormalizado, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal valor))
            {
                MessageBox.Show("Ingrese un número válido.", "ITLA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPorciento.Focus();
                return;
            }

            // Muestra con 2 decimales, usa coma o punto según cultura local
            txtPorciento.Text = valor.ToString("N2"); // 123,123.00
        }

        private void txtBarCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                e.Handled = true;
                if (txtBarCode.Text.Trim() != string.Empty)
                {
                    txtReorden.Focus();
                }
            }
        }

        private void txtReorden_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                e.Handled = true;
                if (txtReorden.Text.Trim() != string.Empty)
                {
                    txtPrecioA.Focus();
                }
                return;
            }

            // Permite digitos, teclas de control y un punto decimal
            if (char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar))
            {
                // pertimido
                return;
            }

            // permite un solo punto o coma decimal, pero no ambos
            if ((e.KeyChar == '.'
                || e.KeyChar == ',')
                && !txtReorden.Text.Contains('.')
                && !txtReorden.Text.Contains(','))
            {
                return;
            }

            e.Handled = true;
        }

        private void txtReorden_Leave(object sender, EventArgs e)
        {
            string texto = txtReorden.Text.Trim();

            if (string.IsNullOrEmpty(texto))
                return;

            // reemplaza ',' por '.'
            string textoNormalizado = texto.Replace(',', '.');

            // Intentar convertir a decimal con punto como separador
            if (!decimal.TryParse(textoNormalizado, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal valor))
            {
                MessageBox.Show("Ingrese un número válido.", "ITLA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtReorden.Focus();
                return;
            }

            // Muestra con 2 decimales, usa coma o punto según cultura local
            txtReorden.Text = valor.ToString("N2"); // 123,123.00
        }

        private void txtPrecioA_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                e.Handled = true;
                if (txtPrecioA.Text.Trim() != string.Empty)
                {
                    txtPrecioB.Focus();
                }
                return;
            }

            // Permite digitos, teclas de control y un punto decimal
            if (char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar))
            {
                // pertimido
                return;
            }

            // permite un solo punto o coma decimal, pero no ambos
            if ((e.KeyChar == '.'
                || e.KeyChar == ',')
                && !txtPrecioA.Text.Contains('.')
                && !txtPrecioA.Text.Contains(','))
            {
                return;
            }

            e.Handled = true;
        }

        private void txtPrecioA_Leave(object sender, EventArgs e)
        {
            string texto = txtPrecioA.Text.Trim();

            if (string.IsNullOrEmpty(texto))
                return;

            // reemplaza ',' por '.'
            string textoNormalizado = texto.Replace(',', '.');

            // Intentar convertir a decimal con punto como separador
            if (!decimal.TryParse(textoNormalizado, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal valor))
            {
                MessageBox.Show("Ingrese un número válido.", "ITLA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPrecioA.Focus();
                return;
            }

            // Muestra con 2 decimales, usa coma o punto según cultura local
            txtPrecioA.Text = valor.ToString("N2"); // 123,123.00
        }

        private void txtPrecioB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                e.Handled = true;
                if (txtPrecioB.Text.Trim() != string.Empty)
                {
                    txtPrecioC.Focus();
                }
                return;
            }

            // Permite digitos, teclas de control y un punto decimal
            if (char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar))
            {
                // pertimido
                return;
            }

            // permite un solo punto o coma decimal, pero no ambos
            if ((e.KeyChar == '.'
                || e.KeyChar == ',')
                && !txtPrecioB.Text.Contains('.')
                && !txtPrecioB.Text.Contains(','))
            {
                return;
            }

            e.Handled = true;
        }

        private void txtPrecioB_Leave(object sender, EventArgs e)
        {
            string texto = txtPrecioB.Text.Trim();

            if (string.IsNullOrEmpty(texto))
                return;

            // reemplaza ',' por '.'
            string textoNormalizado = texto.Replace(',', '.');

            // Intentar convertir a decimal con punto como separador
            if (!decimal.TryParse(textoNormalizado, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal valor))
            {
                MessageBox.Show("Ingrese un número válido.", "ITLA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPrecioB.Focus();
                return;
            }

            // Muestra con 2 decimales, usa coma o punto según cultura local
            txtPrecioB.Text = valor.ToString("N2"); // 123,123.00
        }

        private void txtPrecioC_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                e.Handled = true;
                if (txtPrecioC.Text.Trim() != string.Empty)
                {
                    txtPrecioD.Focus();
                }
                return;
            }

            // Permite digitos, teclas de control y un punto decimal
            if (char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar))
            {
                // pertimido
                return;
            }

            // permite un solo punto o coma decimal, pero no ambos
            if ((e.KeyChar == '.'
                || e.KeyChar == ',')
                && !txtPrecioC.Text.Contains('.')
                && !txtPrecioC.Text.Contains(','))
            {
                return;
            }

            e.Handled = true;
        }

        private void txtPrecioC_LocationChanged(object sender, EventArgs e)
        {
            string texto = txtPrecioC.Text.Trim();

            if (string.IsNullOrEmpty(texto))
                return;

            // reemplaza ',' por '.'
            string textoNormalizado = texto.Replace(',', '.');

            // Intentar convertir a decimal con punto como separador
            if (!decimal.TryParse(textoNormalizado, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal valor))
            {
                MessageBox.Show("Ingrese un número válido.", "ITLA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPrecioC.Focus();
                return;
            }

            // Muestra con 2 decimales, usa coma o punto según cultura local
            txtPrecioC.Text = valor.ToString("N2"); // 123,123.00
        }

        private void txtPrecioC_Leave(object sender, EventArgs e)
        {
            string texto = txtPrecioC.Text.Trim();

            if (string.IsNullOrEmpty(texto))
                return;

            // reemplaza ',' por '.'
            string textoNormalizado = texto.Replace(',', '.');

            // Intentar convertir a decimal con punto como separador
            if (!decimal.TryParse(textoNormalizado, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal valor))
            {
                MessageBox.Show("Ingrese un número válido.", "ITLA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPrecioC.Focus();
                return;
            }

            // Muestra con 2 decimales, usa coma o punto según cultura local
            txtPrecioC.Text = valor.ToString("N2"); // 123,123.00
        }

        private void txtPrecioD_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                e.Handled = true;
                if (txtPrecioD.Text.Trim() != string.Empty)
                {
                    txtPrecioE.Focus();
                }
                return;
            }

            // Permite digitos, teclas de control y un punto decimal
            if (char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar))
            {
                // pertimido
                return;
            }

            // permite un solo punto o coma decimal, pero no ambos
            if ((e.KeyChar == '.'
                || e.KeyChar == ',')
                && !txtPrecioD.Text.Contains('.')
                && !txtPrecioD.Text.Contains(','))
            {
                return;
            }

            e.Handled = true;
        }

        private void txtPrecioD_Leave(object sender, EventArgs e)
        {
            string texto = txtPrecioD.Text.Trim();

            if (string.IsNullOrEmpty(texto))
                return;

            // reemplaza ',' por '.'
            string textoNormalizado = texto.Replace(',', '.');

            // Intentar convertir a decimal con punto como separador
            if (!decimal.TryParse(textoNormalizado, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal valor))
            {
                MessageBox.Show("Ingrese un número válido.", "ITLA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPrecioD.Focus();
                return;
            }

            // Muestra con 2 decimales, usa coma o punto según cultura local
            txtPrecioD.Text = valor.ToString("N2"); // 123,123.00
        }

        private void txtPrecioE_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                e.Handled = true;
                if (txtPrecioE.Text.Trim() != string.Empty)
                {
                    txtSucursal.Focus();
                }
                return;
            }

            // Permite digitos, teclas de control y un punto decimal
            if (char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar))
            {
                // pertimido
                return;
            }

            // permite un solo punto o coma decimal, pero no ambos
            if ((e.KeyChar == '.'
                || e.KeyChar == ',')
                && !txtPrecioE.Text.Contains('.')
                && !txtPrecioE.Text.Contains(','))
            {
                return;
            }

            e.Handled = true;
        }

        private void txtPrecioE_Leave(object sender, EventArgs e)
        {
            string texto = txtPrecioE.Text.Trim();

            if (string.IsNullOrEmpty(texto))
                return;

            // reemplaza ',' por '.'
            string textoNormalizado = texto.Replace(',', '.');

            // Intentar convertir a decimal con punto como separador
            if (!decimal.TryParse(textoNormalizado, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal valor))
            {
                MessageBox.Show("Ingrese un número válido.", "ITLA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPrecioE.Focus();
                return;
            }

            // Muestra con 2 decimales, usa coma o punto según cultura local
            txtPrecioE.Text = valor.ToString("N2"); // 123,123.00
        }

        private void txtSucursal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                e.Handled = true;
                if (txtSucursal.Text.Trim() != string.Empty)
                {
                    txtCantidad.Focus();
                }
            }
        }

        private void txtSucursal_Leave(object sender, EventArgs e)
        {
            if (txtSucursal.Text.Trim() != string.Empty)
            {
                lblSucursal.Text = Busco.BuscarSucursal(txtSucursal.Text, out bool _found);
            }
        }

        private void txtSucursal_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F4)
            {
                btnSucursal.PerformClick();
            }
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                e.Handled = true;
                if (txtCantidad.Text.Trim() != string.Empty)
                {
                    btnInserta.Focus();
                }
                return;
            }

            // Permite digitos, teclas de control y un punto decimal
            if (char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar))
            {
                // pertimido
                return;
            }

            // permite un solo punto o coma decimal, pero no ambos
            if ((e.KeyChar == '.'
                || e.KeyChar == ',')
                && !txtCantidad.Text.Contains('.')
                && !txtCantidad.Text.Contains(','))
            {
                return;
            }

            e.Handled = true;
        }

        private void txtCantidad_Leave(object sender, EventArgs e)
        {
            if (txtSucursal.Text.Trim() != string.Empty)
            {
                btnInserta.PerformClick();
            }
        }

        private void dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv.RowCount > 0)
                btnEditarLinea.PerformClick();
        }

        private void txtAltura_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                e.Handled = true;
                if (txtAltura.Text.Trim() != string.Empty)
                {
                    txtCopia.Focus();
                }
            }
        }

        private void txtAltura_Leave(object sender, EventArgs e)
        {
            if (txtAltura.Text.Trim() != string.Empty)
                btnActualiza.PerformClick();
        }

        private void txtCopia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                e.Handled = true;
                if (txtCopia.Text.Trim() != string.Empty)
                {
                    btnImprimir.Focus();
                }
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!validarMaestros())
                return;
            
            if (!ValidarFormulario())
                return;

            if (!ExisteData)
            {
                InsertarRegistro();  // INSERTA EL NUEVO REGISTRO
                GuardarInventario(txtArticulo.Text, txtReorden.Text);
                GuardarOfertas(txtArticulo.Text);
                ActualizaSecuenciaProducto("4", txtArticulo.Text); // ACTUALIZA LA NUEVA SECUENCIA
            }
            else
            {
                ActualizarRegistro(txtArticulo.Text);
                GuardarInventario(txtArticulo.Text, txtReorden.Text);
                GuardarOfertas(txtArticulo.Text);
            }

            btnLimpiar.PerformClick();
        }


        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
            LimpiarTextBoxDetalle();
            txtArticulo.Text = Busco.BuscaUltimoNumero("4");
            txtArticulo.Focus();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (ExisteData == true)
            {
                DialogResult dialogResult = MessageBox.Show("Deseas Borrar el Registro", "ITLA", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dialogResult == DialogResult.Yes)
                {
                    DeleteArticulo(txtArticulo.Text);
                    btnLimpiaDetalle.PerformClick();
                }
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnArticulo_Click(object sender, EventArgs e)
        {
            frmVENUSR frm = new frmVENUSR();
            frm.ShowDialog();

            if (frm.EData == true)
            {
                txtArticulo.Text = frm.var1;
                txtNombre.Text = frm.var2;

                BuscarArticulo(txtArticulo.Text);
            }
        }

        private void btnSucursal_Click(object sender, EventArgs e)
        {
            frmVENUSR frm = new frmVENUSR();
            frm.ShowDialog();

            if (frm.EData == true)
            {
                lbl1.Text = frm.var2;
            }
        }

        private void btnInserta_Click(object sender, EventArgs e)
        {
            if (txtSucursal.Text.Trim() != "")
            {
                if (txtCantidad.Text.Trim() != "")
                {
                    AgregarLinea();
                    ContarCantidaddes();

                    LimpiarTextBoxDetalle();
                    txtSucursal.Focus();
                }
            }
        }

        private void btnLimpiarDetalle_Click(object sender, EventArgs e)
        {
            LimpiarTextBoxDetalle();
            txtSucursal.Focus();
        }

        private void btnBorrarLinea_Click(object sender, EventArgs e)
        {
            if (dgv.RowCount > 0)
            {
                BorrarUnaLinea();
                ContarCantidaddes();
                LimpiarTextBoxDetalle();
                txtSucursal.Focus();
            }
        }

        private void btnEditarLinea_Click(object sender, EventArgs e)
        {
            if (dgv.RowCount > 0)
            {
                LimpiarTextBoxDetalle();

                txtSucursal.Text = dgv.CurrentRow.Cells[0].Value.ToString();
                lbl1.Text = dgv.CurrentRow.Cells[1].Value.ToString();
                txtCantidad.Text = dgv.CurrentRow.Cells[2].Value.ToString();

                BorrarUnaLinea();
                ContarCantidaddes();

                txtSucursal.Focus();
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }

        private void btnActualiza_Click(object sender, EventArgs e)
        {
            if (txtAltura.Text.Trim() != string.Empty)
            {
                long _nHeight = long.Parse(txtAltura.Text.Trim());
                string _texto = txtArticulo.Text.ToString();

                PicBarCode.SizeMode = PictureBoxSizeMode.CenterImage;
                PicBarCode.BackColor = Color.White;
                PicBarCode.Image = Code128(_texto, PrintTextInCode: true, Height: _nHeight);
            }
        }


        private void picProducto_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string _imagen = openFileDialog1.FileName;
                PicProducto.Image = Image.FromFile(_imagen);
            }
        }

        // --------------------------------------------------
        // BARCODE
        // --------------------------------------------------
        private void MostrarCodigoBarra(string _codigo, string _altura)
        {
            long nHeight = long.Parse(_altura);
            string sTexto = Convert.ToString(_codigo);

            PicBarCode.SizeMode = PictureBoxSizeMode.CenterImage;
            PicBarCode.BackColor = Color.White;
            PicBarCode.Image = Code128(sTexto, PrintTextInCode: true, Height: nHeight);
        }

        public enum Code128SubTypes
        {
            CODE128 = iTextSharp.text.pdf.Barcode.CODE128,
            CODE128_RAW = iTextSharp.text.pdf.Barcode.CODE128_RAW,
            CODE128_UCC = iTextSharp.text.pdf.Barcode.CODE128_UCC,
        }

        public static Bitmap Code128(string _code, Code128SubTypes codeType = Code128SubTypes.CODE128, bool PrintTextInCode = false,
                                     float Height = 0, bool GenerateChecksum = true, bool ChecksumText = true)
        {
            if (_code.Trim() == "")
            {
                return null;
            }
            else
            {
                Barcode128 barcode = new Barcode128();

                barcode.CodeType = (int)codeType;
                barcode.StartStopText = true;
                barcode.GenerateChecksum = GenerateChecksum;
                barcode.ChecksumText = ChecksumText;
                if (Height != 0) barcode.BarHeight = Height;
                barcode.Code = _code;
                try
                {
                    System.Drawing.Bitmap bm = new System.Drawing.Bitmap(barcode.CreateDrawingImage
                        (System.Drawing.Color.Black, System.Drawing.Color.White));
                    if (PrintTextInCode == false)
                    {
                        return bm;
                    }
                    else
                    {
                        Bitmap bmT;
                        bmT = new Bitmap(bm.Width, bm.Height + 14);
                        Graphics g = Graphics.FromImage(bmT);
                        g.FillRectangle(new SolidBrush(Color.White), 0, 0, bm.Width, bm.Height + 14);

                        Font drawFont = new Font("Arial", 8);
                        SolidBrush drawBrush = new SolidBrush(Color.Black);

                        SizeF stringSize = new SizeF();
                        stringSize = g.MeasureString(_code, drawFont);
                        float xCenter = (bm.Width - stringSize.Width) / 2;
                        float x = xCenter;
                        float y = bm.Height;

                        StringFormat drawFormat = new StringFormat();
                        drawFormat.FormatFlags = StringFormatFlags.NoWrap;

                        g.DrawImage(bm, 0, 0);
                        g.DrawString(_code, drawFont, drawBrush, x, y, drawFormat);

                        return bmT;
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error Codigo De Barra Code128. Desc:" + ex.Message);
                }
            }
        }


        // --------------------------------------------------
        // METODOS
        // --------------------------------------------------

        private void EstiloDGV()
        {
            this.dgv.EnableHeadersVisualStyles = false;
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.ColumnHeadersVisible = true;
            this.dgv.RowHeadersVisible = true;

            this.dgv.Columns.Add("A", "Sucursal / Almacen");
            this.dgv.Columns.Add("B", "Nombre Sucursal / Almacen");
            this.dgv.Columns.Add("B", "Cantidad");

            DataGridViewColumn
            column = dgv.Columns[0]; column.Width = 160;
            column = dgv.Columns[1]; column.Width = 420;
            column = dgv.Columns[2]; column.Width = 125;
            dgv.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

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

        private void CuentaExistencia()
        {
            double _cant = 0;
            double cant = 0;

            lblExistencia.Text = "";

            foreach(DataGridViewRow row in dgv.Rows)
            {
                cant = Convert.ToDouble(dgv.CurrentRow.Cells[2].Value);
                _cant = _cant + cant;
            }
            lblExistencia.Text = _cant.ToString();
        }

        private void EstiloDGV_OFER()
        {
            this.dgvOFER.EnableHeadersVisualStyles = false;
            this.dgvOFER.AllowUserToAddRows = false;
            this.dgvOFER.AllowUserToDeleteRows = false;
            this.dgvOFER.ColumnHeadersVisible = true;
            this.dgvOFER.RowHeadersVisible = true;

            this.dgvOFER.Columns.Add("A", "Cant Ofer");
            this.dgvOFER.Columns.Add("B", "Cant Entrega");
            this.dgvOFER.Columns.Add("C", "Fecha Inicio");
            this.dgvOFER.Columns.Add("D", "Fecha Desde");
            this.dgvOFER.Columns.Add("E", "Precio Oferta");
            this.dgvOFER.Columns.Add("F", "% Descuento");

            DataGridViewColumn
            column = dgvOFER.Columns[0]; column.Width = 125;
            column = dgvOFER.Columns[1]; column.Width = 125;
            column = dgvOFER.Columns[2]; column.Width = 125;
            column = dgvOFER.Columns[3]; column.Width = 125;
            column = dgvOFER.Columns[4]; column.Width = 125;
            column = dgvOFER.Columns[5]; column.Width = 125;
            dgvOFER.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvOFER.BorderStyle = BorderStyle.FixedSingle;
            this.dgvOFER.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            this.dgvOFER.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvOFER.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            this.dgvOFER.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            this.dgvOFER.BackgroundColor = Color.White;
            this.dgvOFER.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            this.dgvOFER.ColumnHeadersDefaultCellStyle.Padding = new Padding(0, 6, 0, 6);
            this.dgvOFER.ColumnHeadersDefaultCellStyle.BackColor = Color.CornflowerBlue;
            this.dgvOFER.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        }

            private void LimpiarTextBoxDetalle()
            {
            txtSucursal.Clear();
            lbl1.Text = "";
            txtCantidad.Clear();
            }

        private void LimpiarFormulario()
        {
            txtArticulo.Clear();
            txtNombre.Clear();

            txtCosto.Clear();
            txtPorciento.Clear();
            txtBarCode.Clear();
            txtReorden.Clear();

            txtPrecioA.Clear();
            txtPrecioB.Clear();
            txtPrecioC.Clear();
            txtPrecioD.Clear();
            txtPrecioE.Clear();

            txtSucursal.Clear();
            lbl1.Text = "";
            txtCantidad.Clear();

            PicProducto.Image = null;
            PicBarCode.Image = null;

            txtAltura.Clear();
            txtCopia.Clear();

            // limpiar el DataGridView
            this.dgv.Rows.Clear();
            this.dgv.Refresh();

            // limpiar el DataGridView
            this.dgvOFER.Rows.Clear();
            this.dgvOFER.Refresh();

            txtCantidadOfertada.Clear();
            txtOfertaCantPorCompra.Clear();
            txtFechaFin.Clear();
            txtFechaInicia.Clear();
            txtPrecioOferta.Clear();
            txtDescuentoOferta.Clear();

            txtAltura.Text = "40";  // coloca la altura maxima de las barras 
            txtCopia.Text = "2";    // cantidad de copias a imprimir

            ExisteData = false;
        }

        private void BuscarArticulo(string _articulo)
        {
            if (PicProducto.Image == null)
                PicProducto.Image = Image.FromFile(ruta.imagendefault);

            ExisteData = false;

            LimpiarFormulario();
            LimpiarTextBoxDetalle();

            string query = @"SELECT IDPRODUCTO, DESCRIPCION, COSTO, PRECIOA, PRECIB, PRECIOC, PRECID, PRECIOE
                                    IMPUESTO, STOCK, BARCODE, IMAGEN, REORDEN 
                             FROM PRODUCTO
                            WHERE IDPRODUCTO = @A1 AND ESTATUS = 1";

            using (SqlConnection cxn = new SqlConnection(cnn.db))
            {
                cxn.Open();

                SqlCommand cmd = new SqlCommand(query, cxn);
                cmd.Parameters.AddWithValue("@A1", _articulo);
                SqlDataReader rcd = cmd.ExecuteReader();

                if (rcd.Read())
                {
                    txtArticulo.Text = rcd["IDPRODUCTO"].ToString();
                    txtNombre.Text = rcd["DESCRIPCION"].ToString();
                    txtCosto.Text = rcd["COSTO"].ToString();
                    txtPorciento.Text = rcd["IMPUESTO"].ToString();
                    txtReorden.Text = rcd["REORDEN"].ToString();
                    txtBarCode.Text = rcd["BARCODE"].ToString();

                    txtPrecioA.Text = rcd["PRECIOA"].ToString();
                    txtPrecioB.Text = rcd["PRECIOB"].ToString();
                    txtPrecioC.Text = rcd["PRECIOC"].ToString();
                    txtPrecioD.Text = rcd["PRECIOD"].ToString();
                    txtPrecioE.Text = rcd["PRECIOE"].ToString();

                    lblExistencia.Text = rcd["STOCK"].ToString();
                }

                try
                {
                    PicProducto.Image = ConvertImage.ByteArrayToImage((byte[])rcd["IMAGEN"]);
                }
                catch
                {
                    if (PicProducto.Image == null)
                        PicProducto.Image = Image.FromFile(ruta.imagendefault);
                }

                MostrarCodigoBarra(txtArticulo.Text, txtAltura.Text);
                ConsultarInventario(txtArticulo.Text);
                ConsultarOfertas(txtArticulo.Text);
            }
        }

        private void MostrarInventario(string _articulo)
        {
            string query = @"SELECT A.IDSUCURSAL, A.STOCK, B.NOMBREDESUCURSAL FROM ALMACENSTOCK A INNER JOIN SUCURSALES B 
                             ON A.IDSUCURSAL = B.IDALMACEN WHERE IDPRODUCTO = @A1";

            using (SqlConnection cxn = new SqlConnection())
            {
                cxn.Open();

                SqlCommand cmd = new SqlCommand(query, cxn);
                cmd.Parameters.AddWithValue("@A1", _articulo);
                SqlDataReader rcd = cmd.ExecuteReader();

                while (rcd.Read())
                {
                    dgv.Rows.Add();  // le agrega una linea a la grilla
                    int nRow = dgv.Rows.Count - 1;  // obtiene la linea anterior

                    dgv[0, nRow].Value = rcd["IDSUCURSAL"].ToString();
                    dgv[1, nRow].Value = rcd["NOMBREDESUCURSAL"].ToString();
                    dgv[2, nRow].Value = rcd["STOCK"].ToString();
                }

            }
        }

        private void AgregarLinea()
        {
            dgv.Rows.Add();
            int nRow = dgv.Rows.Count - 1;

            dgv[0, nRow].Value = txtSucursal.Text;
            dgv[1, nRow].Value = lbl1.Text;
            dgv[2, nRow].Value = txtCantidad.Text;
        }

        private void ContarCantidaddes()
        {
            double _nCant = 0;
            double _xCant = 0;

            hhhg.Text = "";

            foreach (DataGridViewRow cRow in dgv.Rows)
            {
                _xCant = Convert.ToDouble(dgv.CurrentRow.Cells[2].Value);
                _nCant = _nCant + _xCant;
            }

            hhhg.Text = _xCant.ToString("N2");
        }

        private void DeleteArticulo(string articulo)
        {
            string query = @"UPDATE PRODUCTO SET ESTATUS = 0 WHERE IDPRODUCTO = @C1";

            using (SqlConnection cxn = new SqlConnection())
            {
                cxn.Open();

                SqlCommand cmd = new SqlCommand(query, cxn);
                cmd.Parameters.AddWithValue("@C1", articulo);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
        }


        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            try
            {
                e.Graphics.DrawImage(PicBarCode.Image, 0, 0);
            }
            catch
            {

            }
        }

        private void InsertarRegistro()
        {
            if (PicProducto.Image == null)
                PicProducto.Image = Image.FromFile(ruta.imagendefault);

            byte[] byteArrayImage = ConvertImage.ImageToByteArray(PicProducto.Image);

            string query = @"
            INSERT INTO PRODUCTOS (IDPRODUCTO, DESCRIPCION, COSTO, PRECIOA, PRECIOB, PRECIOE, PRECIOD, PRECIOC,
                                   STOCK, BARCODE, ESTATUS, FOTO, REORDEN, IMPUESTO)
            VALUES (@A1, @A2, @A3, @A4, @A5, @A6, @A7, @A8, @A9, @A10, @A11, @A12, @A13, @A14)";

            using (SqlConnection cxn = new SqlConnection(cnn.db))
            {
                cxn.Open();

                SqlCommand cmd = new SqlCommand(query, cxn);
                cmd.Parameters.AddWithValue("@A1", txtArticulo.Text);
                cmd.Parameters.AddWithValue("@A2", txtNombre.Text);
                cmd.Parameters.AddWithValue("@A3", Convert.ToDouble(txtCosto.Text));
                cmd.Parameters.AddWithValue("@A4", Convert.ToDouble(txtPrecioA.Text));
                cmd.Parameters.AddWithValue("@A5", Convert.ToDouble(txtPrecioB.Text));
                cmd.Parameters.AddWithValue("@A6", Convert.ToDouble(txtPrecioE.Text));
                cmd.Parameters.AddWithValue("@A7", Convert.ToDouble(txtPrecioD.Text));
                cmd.Parameters.AddWithValue("@A8", Convert.ToDouble(txtPrecioC.Text));
                cmd.Parameters.AddWithValue("@A9", Convert.ToDouble(lblExistencia.Text));
                cmd.Parameters.AddWithValue("@A10", txtBarCode.Text);
                cmd.Parameters.AddWithValue("@A11", "1");
                cmd.Parameters.AddWithValue("@A12", byteArrayImage);
                cmd.Parameters.AddWithValue("@A13", Convert.ToDouble(txtReorden.Text));
                cmd.Parameters.AddWithValue("@A14", Convert.ToDouble(txtPorciento.Text));

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
        }

        private void ActualizarRegistro(string articulo)
        {
            if (PicProducto.Image == null)
                PicProducto.Image = Image.FromFile(ruta.imagendefault);

            byte[] byteArrayImage = ConvertImage.ImageToByteArray(PicProducto.Image);

            string query = @"UPDATE T1
                                SET DESCRIPCION = @A2, COSTO = @A3,
                               FROM PRODUCTOS T1
                              WHERE IDPRODUCTO = @A1";

            using (SqlConnection cxn = new SqlConnection())
            {
                cxn.Open();

                SqlCommand cmd = new SqlCommand(query, cxn);
                cmd.Parameters.AddWithValue("@A1", txtArticulo.Text);
                cmd.Parameters.AddWithValue("@A2", txtNombre.Text);
                cmd.Parameters.AddWithValue("@A3", txtCosto.Text);
                cmd.Parameters.AddWithValue("@A4", Convert.ToDouble(txtPrecioA.Text));
                cmd.Parameters.AddWithValue("@A5", Convert.ToDouble(txtPrecioB.Text));
                cmd.Parameters.AddWithValue("@A6", Convert.ToDouble(txtPrecioE.Text));
                cmd.Parameters.AddWithValue("@A7", Convert.ToDouble(txtPrecioD.Text));
                cmd.Parameters.AddWithValue("@A8", Convert.ToDouble(txtPrecioC.Text));
                cmd.Parameters.AddWithValue("@A9", hhhg.Text);
                cmd.Parameters.AddWithValue("@A10", txtBarCode.Text);
                cmd.Parameters.AddWithValue("@A12", byteArrayImage);
                cmd.Parameters.AddWithValue("@A13", Convert.ToDouble(txtReorden.Text));
                cmd.Parameters.AddWithValue("@A14", Convert.ToDouble(txtPorciento.Text));

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
        }

        private void ActualizaSecuenciaProducto(string nID, string articulo)
        {
            string query = @"UPDATE SECUENCIAS SET CONTADOR = @C2 WHERE ID = @C1";

            using (SqlConnection cxn = new SqlConnection(cnn.db))
            {
                cxn.Open();

                SqlCommand cmd = new SqlCommand(query, cxn);
                cmd.Parameters.AddWithValue("@C1", articulo);
                cmd.Parameters.AddWithValue("@C2", nID);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
        }

        private bool ValidarFormulario()
        {
            if (string.IsNullOrWhiteSpace(txtArticulo.Text))
            {
                MostrarMensaje("Articulo");
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MostrarMensaje("Nombre");
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtCosto.Text))
            {
                MostrarMensaje("Costo");
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtPrecioA.Text))
            {
                MostrarMensaje("Precio A");
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtPrecioB.Text))
            {
                MostrarMensaje("Precio B");
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtPrecioC.Text))
            {
                MostrarMensaje("Precio C");
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtPrecioD.Text))
            {
                MostrarMensaje("Precio D");
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtPrecioE.Text))
            {
                MostrarMensaje("Precio E");
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtPorciento.Text))
            {
                MostrarMensaje("Porciento");
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtBarCode.Text))
            {
                MostrarMensaje("Codigo Barra");
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtReorden.Text))
            {
                MostrarMensaje("Reorden");
                return false;
            }

            return true;
        }

        private bool validarMaestros()
        {
            if(!string.IsNullOrWhiteSpace(txtSuplidor.Text))
            {
                lblSuplidor.Text = Busco.BuscarSuplidor(txtSuplidor.Text, out bool found);

                if (!found)
                {
                    MostrarMensaje_Maestro("supldor / proveedor");
                    return false;
                }
            }

            if (!string.IsNullOrWhiteSpace(txtCategoria.Text))
            {
                uiuiu.Text = Busco.BuscarCategoria(txtCategoria.Text, out bool found);

                if (!found)
                {
                    MostrarMensaje_Maestro("categoria");
                    return false;
                }
            }

            if (!string.IsNullOrWhiteSpace(txtCategoria.Text))
            {
                if (!string.IsNullOrWhiteSpace(txtSubCategoria.Text))
                {
                    ddgdg.Text = Busco.BuscarCategoria(txtSubCategoria.Text, out bool found);

                    if (!found)
                    {
                        MostrarMensaje_Maestro("categoria");
                        return false;
                    }
                }
            }
            return true;
        }

        private void MostrarMensaje_Maestro(string campo)
        {
            MessageBox.Show($"Falta el {campo}", "Miapp", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void MostrarMensaje(string campo)
        {
            MessageBox.Show($"Falta el {campo}", "Miapp", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BorrarUnaLinea()
        {
            int CuantasLinea = Convert.ToInt32(dgv.RowCount);

            if (CuantasLinea == 1)
                dgv.Rows.RemoveAt(dgv.RowCount - 1);
            else
                dgv.Rows.Remove(dgv.CurrentRow);
        }


        // -----------------------------------------------------------------------------
        // OFERTAS
        // -----------------------------------------------------------------------------
        private void txtOfetaCantPorCompra_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                e.Handled = true;
                if (txtOfertaCantPorCompra.Text.Trim() != string.Empty)
                {
                    txtCantidadOfertada.Focus();
                }
                return;
            }

            // Permite digitos, teclas de control y un punto decimal
            if (char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar))
            {
                // pertimido
                return;
            }

            // permite un solo punto o coma decimal, pero no ambos
            if ((e.KeyChar == '.'
                || e.KeyChar == ',')
                && !txtOfertaCantPorCompra.Text.Contains('.')
                && !txtOfertaCantPorCompra.Text.Contains(','))
            {
                return;
            }

            e.Handled = true;
        }

        private void txtOfetaCantPorCompra_Leave(object sender, EventArgs e)
        {
            string texto = txtOfertaCantPorCompra.Text.Trim();

            if (string.IsNullOrEmpty(texto))
                return;

            // reemplaza ',' por '.'
            string textoNormalizado = texto.Replace(',', '.');

            // Intentar convertir a decimal con punto como separador
            if (!decimal.TryParse(textoNormalizado, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal valor))
            {
                MessageBox.Show("Ingrese un número válido.", "ITLA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtOfertaCantPorCompra.Focus();
                return;
            }

            // Muestra con 2 decimales, usa coma o punto según cultura local
            txtOfertaCantPorCompra.Text = valor.ToString("N2"); // 123,123.00
        }

        private void txtCantidadOfertada_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                e.Handled = true;
                if (txtCantidadOfertada.Text.Trim() != string.Empty)
                {
                    txtFechaInicia.Focus();
                }
                return;
            }

            // Permite digitos, teclas de control y un punto decimal
            if (char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar))
            {
                // pertimido
                return;
            }

            // permite un solo punto o coma decimal, pero no ambos
            if ((e.KeyChar == '.'
                || e.KeyChar == ',')
                && !txtCantidadOfertada.Text.Contains('.')
                && !txtCantidadOfertada.Text.Contains(','))
            {
                return;
            }

            e.Handled = true;
        }

        private void txtCantidadOfertada_Leave(object sender, EventArgs e)
        {
            string texto = txtCantidadOfertada.Text.Trim();

            if (string.IsNullOrEmpty(texto))
                return;

            // reemplaza ',' por '.'
            string textoNormalizado = texto.Replace(',', '.');

            // Intentar convertir a decimal con punto como separador
            if (!decimal.TryParse(textoNormalizado, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal valor))
            {
                MessageBox.Show("Ingrese un número válido.", "ITLA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCantidadOfertada.Focus();
                return;
            }

            // Muestra con 2 decimales, usa coma o punto según cultura local
            txtCantidadOfertada.Text = valor.ToString("N2"); // 123,123.00
        }

        private void txtFechaInicio_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void txtFechaInicio_Leave(object sender, EventArgs e)
        {

        }

        private void txtFechaFin_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Si presiona Enter
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                e.Handled = true;
                if(txtFechaFin.Text.Trim() != string.Empty)
                {
                    txtPrecioOferta.Focus();
                }
                return;
            }

            //Permite digitos y teclas de control(borrar, retroceso, etc.)
            if (char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar))
            {
                return;
            }

            //Permite punto o coma decimal (solo uno)
            if((e.KeyChar == '.' || e.KeyChar == ',')
            && !txtFechaFin.Text.Contains('.') 
            && !txtFechaFin.Text.Contains(','))
            {
                return;
            }

            //Si no cumple nada de lo anterior, se bloquea la tecla
            e.Handled = true;

        }

        private void txtFechaFin_Leave(object sender, EventArgs e)
        {

            string texto = txtFechaFin.Text.Trim();

            if (string.IsNullOrEmpty(texto))
                return;

            //Validar que sean exactamente 8 digitos (sin contar puntos o comas)
            string soloDigitos = new string(texto.Where(char.IsDigit).ToArray());

            if(soloDigitos.Length != 0)
            {
                MessageBox.Show("Debe tener exactamente 8 digitos.", "validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtFechaFin.Focus();
                txtFechaFin.SelectAll();
                return;
            }

            //Extraer partes
            int dia = int.Parse(soloDigitos.Substring(0, 2));   //Posiciones 1-2
            int mes = int.Parse(soloDigitos.Substring(2, 2));   //Posiciones 3-4

            //Validar dia y mes
            if (dia < 1 || dia > 31)
            {
                MessageBox.Show("El dia debe estar entre el 01 y 31.", "QLab", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtFechaFin.Focus();
                txtFechaFin.SelectAll();
                return;
            }

            if (mes < 1 || mes > 31)
            {
                MessageBox.Show("El dia debe estar entre el 01 y 31.", "QLab", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtFechaFin.Focus();
                txtFechaFin.SelectAll();
                return;
            }

            //Si todo esta bien, continua...

        }

        private void txtPrecioOferta_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtPrecioOferta_Leave(object sender, EventArgs e)
        {

        }

        private void txtDescuentoOferta_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtDescuentoOferta_Leave(object sender, EventArgs e)
        {

        }

        private void dgvOFER_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void btnInsertaOferta_Click(object sender, EventArgs e)
        {

            if(txtFechaInicia.Text.Trim() != string.Empty)
            {
                AgregarLinea_OFER();
                LimpiarTextBoxDetalle_OFER();
                txtOfertaCantPorCompra.Focus();
            }

        }

        private void btnLimpiarOferta_Click(object sender, EventArgs e)
        {

            LimpiarTextBoxDetalle_OFER();
            this.dgvOFER.Rows.Clear();
            this.dgvOFER.Refresh();

            txtOfertaCantPorCompra.Focus();

        }

        private void btnBorrarLineaOferta_Click(object sender, EventArgs e)
        {

            DeleteLineaDelDGV_OFER();

        }

        private void btnEditaLineaOferta_Click(object sender, EventArgs e)
        {

            if(dgv.RowCount > 0)
            {
                LimpiarTextBoxDetalle_OFER();

                txtOfertaCantPorCompra.Text = dgvOFER.CurrentRow.Cells[0].Value.ToString();
                txtCantidadOfertada.Text = dgvOFER.CurrentRow.Cells[1].Value.ToString();
                txtFechaInicia.Text = dgvOFER.CurrentRow.Cells[2].Value.ToString();
                txtPrecioOferta.Text = dgvOFER.CurrentRow.Cells[3].Value.ToString();
                txtDescuentoOferta.Text = dgvOFER.CurrentRow.Cells[1].Value.ToString();

                DeleteLineaDelDGV_OFER();
                txtOfertaCantPorCompra.Focus();
            }
        }

        private void EstiloDGV_ARTICULO()

        {

            this.dgvArt.EnableHeadersVisualStyles = false;

            this.dgvArt.AllowUserToAddRows = false;

            this.dgvArt.AllowUserToDeleteRows = false;

            this.dgvArt.ColumnHeadersVisible = true;

            this.dgvArt.RowHeadersVisible = false;

            this.dgvArt.Columns.Add("A", "ARTICULO");

            this.dgvArt.Columns.Add("B", "NOMBRE / DESCRIPCION");

            this.dgvArt.Columns.Add("C", "EXISTENCIA");

            this.dgvArt.Columns.Add("D", "REORDEN");

            this.dgvArt.Columns.Add("E", "COSTO");

            this.dgvArt.Columns.Add("F", "PRECIO A");

            this.dgvArt.Columns.Add("G", "PRECIO B");

            this.dgvArt.Columns.Add("H", "PRECIO C");

            this.dgvArt.Columns.Add("I", "PRECIO D");

            this.dgvArt.Columns.Add("J", "PRECIO E");

            DataGridViewColumn

            column = dgvArt.Columns[0]; column.Width = 125;

            column = dgvArt.Columns[1]; column.Width = 125;

            column = dgvArt.Columns[2]; column.Width = 125;

            column = dgvArt.Columns[3]; column.Width = 125;

            column = dgvArt.Columns[4]; column.Width = 125;

            column = dgvArt.Columns[5]; column.Width = 125;

            column = dgvArt.Columns[6]; column.Width = 125;

            column = dgvArt.Columns[7]; column.Width = 125;

            column = dgvArt.Columns[8]; column.Width = 125;

            column = dgvArt.Columns[9]; column.Width = 125;

            dgvArt.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            this.dgvArt.BorderStyle = BorderStyle.FixedSingle;

            this.dgvArt.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);

            this.dgvArt.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;

            this.dgvArt.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;

            this.dgvArt.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;

            this.dgvArt.BackgroundColor = Color.White;

            this.dgvArt.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;

            this.dgvArt.ColumnHeadersDefaultCellStyle.Padding = new Padding(0, 6, 0, 6);

            this.dgvArt.ColumnHeadersDefaultCellStyle.BackColor = Color.CornflowerBlue;

            this.dgvArt.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

        }

        private void EstiloDGV_ALM()

        {

            this.dgvStock.EnableHeadersVisualStyles = false;

            this.dgvStock.AllowUserToAddRows = false;

            this.dgvStock.AllowUserToDeleteRows = false;

            this.dgvStock.ColumnHeadersVisible = true;

            this.dgvStock.RowHeadersVisible = false;

            this.dgvStock.Columns.Add("A", "Sucursal / Almacen");

            this.dgvStock.Columns.Add("B", "Nombre Sucursal / Almacen");

            this.dgvStock.Columns.Add("B", "Cantidad");

            DataGridViewColumn

            column = dgvStock.Columns[0]; column.Width = 160;

            column = dgvStock.Columns[1]; column.Width = 420;

            column = dgvStock.Columns[2]; column.Width = 125;

            dgvStock.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            this.dgvStock.BorderStyle = BorderStyle.FixedSingle;

            this.dgvStock.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);

            this.dgvStock.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;

            this.dgvStock.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;

            this.dgvStock.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;

            this.dgvStock.BackgroundColor = Color.White;

            this.dgvStock.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;

            this.dgvStock.ColumnHeadersDefaultCellStyle.Padding = new Padding(0, 6, 0, 6);

            this.dgvStock.ColumnHeadersDefaultCellStyle.BackColor = Color.CornflowerBlue;

            this.dgvStock.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

        }

        private void EstiloDGV_OFERTAS()

        {

            this.dgvOferta.EnableHeadersVisualStyles = false;

            this.dgvOferta.AllowUserToAddRows = false;

            this.dgvOferta.AllowUserToDeleteRows = false;

            this.dgvOferta.ColumnHeadersVisible = true;

            this.dgvOferta.RowHeadersVisible = false;

            this.dgvOferta.Columns.Add("A", "Oferta x Cant");

            this.dgvOferta.Columns.Add("B", "Cant Ofertada");

            this.dgvOferta.Columns.Add("C", "Fecha Desde");

            this.dgvOferta.Columns.Add("D", "Fecha Fin");

            this.dgvOferta.Columns.Add("E", "Precio Oferta");

            this.dgvOferta.Columns.Add("F", "Descuento Oferta");

            DataGridViewColumn

            column = dgvOferta.Columns[0]; column.Width = 125;

            column = dgvOferta.Columns[1]; column.Width = 125;

            column = dgvOferta.Columns[2]; column.Width = 125;

            column = dgvOferta.Columns[3]; column.Width = 125;

            column = dgvOferta.Columns[4]; column.Width = 125;

            column = dgvOferta.Columns[5]; column.Width = 125;

            dgvOferta.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            this.dgvOferta.BorderStyle = BorderStyle.FixedSingle;

            this.dgvOferta.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);

            this.dgvOferta.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;

            this.dgvOferta.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;

            this.dgvOferta.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;

            this.dgvOferta.BackgroundColor = Color.White;

            this.dgvOferta.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;

            this.dgvOferta.ColumnHeadersDefaultCellStyle.Padding = new Padding(0, 6, 0, 6);

            this.dgvOferta.ColumnHeadersDefaultCellStyle.BackColor = Color.CornflowerBlue;

            this.dgvOferta.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

        }

        private void BuscarTodosLosArticulo(string nombre)

        {

            if (this.dgvArt == null) return;

            string _query = @"SELECT IDPRODUCTO, DESCRIPCION, STOCK, REORDEN, COSTO, 

              PRECIOA, PRECIOB, PRECIOC, PRECIOD, PRECIOE 

              FROM PRODUCTOS 

              WHERE ESTATUS = 1 AND DESCRIPCION LIKE @NOMBRE";

            using (SqlConnection cnx = new SqlConnection(cnn.db))

            {

                cnx.Open();

                using (SqlCommand cmd = new SqlCommand(_query, cnx))

                {

                    cmd.Parameters.AddWithValue("@NOMBRE", "%" + nombre + "%");

                    using (SqlDataReader rdr = cmd.ExecuteReader())

                    {

                        dgvArt.Rows.Clear();

                        while (rdr.Read())

                        {

                            dgvArt.Rows.Add();

                            int xRow = dgvArt.Rows.Count - 1;

                            dgvArt[0, xRow].Value = rdr["IDPRODUCTO"].ToString();

                            dgvArt[1, xRow].Value = rdr["DESCRIPCION"].ToString();

                            dgvArt[2, xRow].Value = rdr["STOCK"].ToString();

                            dgvArt[3, xRow].Value = rdr["REORDEN"].ToString();

                            dgvArt[4, xRow].Value = rdr["COSTO"].ToString();

                            dgvArt[5, xRow].Value = rdr["PRECIOA"].ToString();

                            dgvArt[6, xRow].Value = rdr["PRECIOB"].ToString();

                            dgvArt[7, xRow].Value = rdr["PRECIOC"].ToString();

                            dgvArt[8, xRow].Value = rdr["PRECIOD"].ToString();

                            dgvArt[9, xRow].Value = rdr["PRECIOE"].ToString();

                        }

                    }

                }

            }

        }

        private void MostrarExistenciasSucursales(string articulo)

        {

            string _query = @"";

            SqlConnection cnx = new SqlConnection(cnn.db); cnx.Open();

            SqlCommand cmd = new SqlCommand(_query, cnx);

            SqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())

            {

                dgvStock.Rows.Add();

                int xRow = dgvStock.Rows.Count - 1;

                dgvStock[0, xRow].Value = rdr[""].ToString();

                dgvStock[1, xRow].Value = rdr[""].ToString();

                dgvStock[2, xRow].Value = rdr[""].ToString();

            }

            cmd.Dispose();

            cnx.Close();

        }

        private void MostrasLasOfertas(string articulo)

        {

            string _query = @"";

            SqlConnection cnx = new SqlConnection(cnn.db); cnx.Open();

            SqlCommand cmd = new SqlCommand(_query, cnx);

            SqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())

            {

                dgvOferta.Rows.Add();

                int xRow = dgvOferta.Rows.Count - 1;

                dgvOferta[0, xRow].Value = rdr[""].ToString();

                dgvOferta[1, xRow].Value = rdr[""].ToString();

                dgvOferta[2, xRow].Value = rdr[""].ToString();

                dgvOferta[3, xRow].Value = rdr[""].ToString();

                dgvOferta[4, xRow].Value = rdr[""].ToString();

                dgvOferta[5, xRow].Value = rdr[""].ToString();

            }

            cmd.Dispose();

            cnx.Close();

        }

        // - ---------------------------------------------
        // METODOS OFERTAS
        // - ---------------------------------------------
        private void AgregarLinea_OFER()
        {
            dgvOFER.Rows.Add();
            int _row = dgvOFER.Rows.Count - 1;

            dgvOFER[0, _row].Value = txtOfertaCantPorCompra.Text;
            dgvOFER[1, _row].Value = txtCantidadOfertada.Text;
            dgvOFER[2, _row].Value = txtFechaInicia.Text;
            dgvOFER[3, _row].Value = txtFechaFin.Text;
            dgvOFER[4, _row].Value = txtPrecioOferta.Text;
            dgvOFER[5, _row].Value = txtDescuentoOferta.Text;
        }

        private void LimpiarTextBoxDetalle_OFER()
        {
            txtOfertaCantPorCompra.Clear();
            txtCantidadOfertada.Clear();
            txtFechaInicia.Clear();
            txtFechaFin.Clear();
            txtPrecioOferta.Clear();
            txtDescuentoOferta.Clear();
        }

        private void DeleteLineaDelDGV_OFER()
        {
            int CuantasTengo = Convert.ToInt32(dgvOFER.RowCount);

            if (CuantasTengo == 1)
                dgvOFER.Rows.RemoveAt(dgvOFER.RowCount - 1);
            else
                dgvOFER.Rows.Remove(dgvOFER.CurrentRow);
        }

        private void GuardarInventario(string articulo, string reorden)
        {
            string queri;
            string idStorage;
            string Quantity;

            BorrarExistencia_OFER(articulo);
            
            foreach(DataGridViewRow _row in dgv.Rows)
            {
                queri = "";
                idStorage = "01";
                Quantity = "0";

                if (_row.Cells[0].Value.ToString() != "")
                    idStorage = _row.Cells[0].Value.ToString();
                if (_row.Cells[2].Value.ToString() != "")
                    Quantity = _row.Cells[2].Value.ToString();

                queri = @"INSERT INTO ALMACENSTOCK (IDPRODUCTO, IDALMACEN, STOCK, REORDEN) VALES (@A1, @A2, @A3, @A4) ";

                using (SqlConnection cxn = new SqlConnection(cnn.db))
                {
                    cxn.Open();
                    SqlCommand cmd = new SqlCommand(queri, cxn);
                    cmd.Parameters.AddWithValue("IDPRODUCTO", articulo);
                    cmd.Parameters.AddWithValue("IDALMACEN", idStorage);
                    cmd.Parameters.AddWithValue("STOCK", Quantity);
                    cmd.Parameters.AddWithValue("REORDEN", reorden);

                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }
            }
        }

        private void GuardarOfertas(string articulo)
        {
            string query;

            BorrarExistencia_OFER(articulo);

            foreach(DataGridViewRow _row in dgv.Rows)
            {
                query = "";

                string oCC = "0";
                string cDF = "0";
                string fDE = "0";
                string fFN = "0";
                string pDF = "0";
                string Des = "0";

                if (_row.Cells[0].Value.ToString() != "") oCC = _row.Cells[0].Value.ToString();
                if (_row.Cells[1].Value.ToString() != "") cDF = _row.Cells[1].Value.ToString();
                if (_row.Cells[2].Value.ToString() != "") fDE = _row.Cells[2].Value.ToString();
                if (_row.Cells[3].Value.ToString() != "") fFN = _row.Cells[3].Value.ToString();
                if (_row.Cells[4].Value.ToString() != "") pDF = _row.Cells[4].Value.ToString();
                if (_row.Cells[5].Value.ToString() != "") Des = _row.Cells[5].Value.ToString();

                query = @"INSERT INTO ARTICULOS_OFERTAS (IDPRODUCTO, OfertaCantPorCompra, CantidadOfertada, 
                                                 FechaDesde, FechaFin, PrecioOferta, Descuento)
                VALUES (@A1, @A2, @A3, @A4, @A5, @A6) ";

                using (SqlConnection cxn = new SqlConnection(cnn.db))
                {
                    cxn.Open();
                    SqlCommand cmd = new SqlCommand(query, cxn);
                    cmd.Parameters.AddWithValue("@A1", articulo);
                    cmd.Parameters.AddWithValue("@A2", oCC);
                    cmd.Parameters.AddWithValue("@A3", cDF);
                    cmd.Parameters.AddWithValue("@A4", fDE);
                    cmd.Parameters.AddWithValue("@A5", fFN);
                    cmd.Parameters.AddWithValue("@A6", pDF);
                    cmd.Parameters.AddWithValue("@A7", Des);

                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }
            }
        }

        private void BorrarExistencia_OFER(string articulo)
        {
            string queri = "DELETE FROM ARTICULOS_OFERTAS WHERE IDPRODUCTO ='" + articulo + "'";

            SqlConnection cxn = new SqlConnection(cnn.db); cxn.Open();
            SqlCommand cmd = new SqlCommand(queri, cxn);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            cxn.Close();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            BuscarTodosLosArticulo(txtBuscar.Text);
        }

        private void txtCategoria_KeyPress(object sender, KeyPressEventArgs e)
        {
            if((int)e.KeyChar == (int)Keys.Enter)
            {
                e.Handled = true;
                if(txtCategoria.Text.Trim() != string.Empty)
                {
                    txtSubCategoria.Focus();
                }
            }
        }

        private void txtCategoria_Leave(object sender, EventArgs e)
        {

            if(txtCategoria.Text.Trim() != string.Empty)
            {
                uiuiu.Text = Busco.BuscarCategoria(txtCategoria.Text, out bool found);
            }

        }

        private void txtSubCategoria_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtSubCategoria_Leave(object sender, EventArgs e)
        {

        }

        private void btnCategoria_Click(object sender, EventArgs e)
        {
            frmVENUSCAT frm = new frmVENUSCAT();
            frm.ShowDialog();

            if(frm.EData == true)
            {
                txtSubCategoria.Text = frm.var1;
                txtSubCategoria.Text = frm.var2;
            }
        }

        private void dgvArt_Click(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv.RowCount > 0)
            {
                string articulo = dgvArt.CurrentRow.Cells[0].Value.ToString();

                ConsultarInventario(articulo);
                ConsultarOfertas(articulo);
            }
        }

        private void dgvArt_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dgv.RowCount > 0)
            {
                string articulo = dgvArt.CurrentRow.Cells[0].Value.ToString();

                ConsultarInventario(articulo);
                ConsultarOfertas(articulo);
            }
        }

        private void dgvArt_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            btnEditarLinea.PerformClick();
        }

        private void ConsultarInventario(string _articulo)
        {
            this.dgvStock.Rows.Clear();
            this.dgvStock.Refresh();

            string query = @"SELECT A.IDSUCURSAL, B.NOMBREDESUCURSAL, A.STOCK 
                                FROM ALMACENSTOCK A
                                INNER JOIN SUCURSALES B ON B.IDSUCURSAL = A.IDALMACEN
                                WHERE A.IDPRODUCTO = @A1";

            using (SqlConnection cxn = new SqlConnection(cnn.db))
            {
                cxn.Open();

                SqlCommand cmd = new SqlCommand(query, cxn);
                cmd.Parameters.AddWithValue("@A1", _articulo);
                SqlDataReader rcd = cmd.ExecuteReader();

                while (rcd.Read())
                {
                    dgvStock.Rows.Add();
                    int nRow = dgvStock.Rows.Count - 1;

                    dgvStock[0, nRow].Value = rcd["IDSUCURSAL"].ToString();
                    dgvStock[1, nRow].Value = rcd["NOMBREDESUCURSAL"].ToString();
                    dgvStock[2, nRow].Value = rcd["STOCK"].ToString();
                }
            }
        }

        private void ConsultarOfertas(string _articulo)
        {
            this.dgvOferta.Rows.Clear();
            this.dgvOferta.Refresh();

            string query = @"SELECT * FROM ARTICULOS_OFERTAS WHERE A.IDPRODUCTO = @A1";

            using (SqlConnection cxn = new SqlConnection(cnn.db))
            {
                cxn.Open();

                SqlCommand cmd = new SqlCommand(query, cxn);
                cmd.Parameters.AddWithValue(@"A1", _articulo);
                SqlDataReader rcd = cmd.ExecuteReader();

                while (rcd.Read())
                {
                    dgvOferta.Rows.Add();
                    int nRow = dgvOferta.Rows.Count - 1;

                    dgvOferta[0, nRow].Value = rcd["OfertaCantPorCompra"].ToString();
                    dgvOferta[1, nRow].Value = rcd["CantidadOferta"].ToString();
                    dgvOferta[2, nRow].Value = rcd["FechaDesde"].ToString();
                    dgvOferta[4, nRow].Value = rcd["FechaFin"].ToString();
                    dgvOferta[5, nRow].Value = rcd["Descuento"].ToString();
                }

            }
        }

        private void BuscarData(string buscar)
        {
            this.dgv.Rows.Clear();
            this.dgv.Refresh();
        }

        private void dgvArt_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
  
