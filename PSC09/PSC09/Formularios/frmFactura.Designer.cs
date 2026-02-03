namespace PSC09
{
    partial class frmFactura
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnFactura = new System.Windows.Forms.Button();
            this.label38 = new System.Windows.Forms.Label();
            this.btnCliente = new System.Windows.Forms.Button();
            this.txtCliente = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSalirMaestro = new System.Windows.Forms.Button();
            this.btnBorrarMaestro = new System.Windows.Forms.Button();
            this.btnLimpiarMaestro = new System.Windows.Forms.Button();
            this.btnGuardarMaestro = new System.Windows.Forms.Button();
            this.label39 = new System.Windows.Forms.Label();
            this.button19 = new System.Windows.Forms.Button();
            this.button18 = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnInsertarLn = new System.Windows.Forms.Button();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnArticulo = new System.Windows.Forms.Button();
            this.txtArticulo = new System.Windows.Forms.TextBox();
            this.lblArticulo = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblSubtotal = new System.Windows.Forms.Label();
            this.lblImpuesto = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblFactura = new System.Windows.Forms.Label();
            this.lblFechaFactura = new System.Windows.Forms.Label();
            this.lblPaga = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.lblPrecio = new System.Windows.Forms.Label();
            this.lblImpuestoLn = new System.Windows.Forms.Label();
            this.lblTotalLn = new System.Windows.Forms.Label();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.lblSucursal = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.NivelPrecio = new System.Windows.Forms.Label();
            this.lblNivel = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.lblTipo = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // btnFactura
            // 
            this.btnFactura.Location = new System.Drawing.Point(363, 76);
            this.btnFactura.Name = "btnFactura";
            this.btnFactura.Size = new System.Drawing.Size(47, 29);
            this.btnFactura.TabIndex = 119;
            this.btnFactura.UseVisualStyleBackColor = true;
            this.btnFactura.Click += new System.EventHandler(this.btnCONFACT_Click);
            // 
            // label38
            // 
            this.label38.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label38.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label38.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label38.Location = new System.Drawing.Point(11, 77);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(211, 28);
            this.label38.TabIndex = 116;
            this.label38.Text = "Numero Factura";
            this.label38.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnCliente
            // 
            this.btnCliente.Location = new System.Drawing.Point(363, 104);
            this.btnCliente.Name = "btnCliente";
            this.btnCliente.Size = new System.Drawing.Size(47, 29);
            this.btnCliente.TabIndex = 123;
            this.btnCliente.UseVisualStyleBackColor = true;
            this.btnCliente.Click += new System.EventHandler(this.btnVENCTE_Click);
            // 
            // txtCliente
            // 
            this.txtCliente.Location = new System.Drawing.Point(228, 105);
            this.txtCliente.Multiline = true;
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.Size = new System.Drawing.Size(129, 28);
            this.txtCliente.TabIndex = 122;
            this.txtCliente.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCliente_KeyDown);
            this.txtCliente.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCliente_KeyPress);
            this.txtCliente.Leave += new System.EventHandler(this.txtCliente_Leave);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(11, 105);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(211, 28);
            this.label1.TabIndex = 121;
            this.label1.Text = "Cliente";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(11, 139);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(264, 28);
            this.label2.TabIndex = 124;
            this.label2.Text = "Fecha Factura";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(889, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(219, 28);
            this.label3.TabIndex = 127;
            this.label3.Text = "Paga Impuesto";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnSalirMaestro
            // 
            this.btnSalirMaestro.Location = new System.Drawing.Point(769, 9);
            this.btnSalirMaestro.Name = "btnSalirMaestro";
            this.btnSalirMaestro.Size = new System.Drawing.Size(88, 56);
            this.btnSalirMaestro.TabIndex = 133;
            this.btnSalirMaestro.Text = "Salir";
            this.btnSalirMaestro.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalirMaestro.UseVisualStyleBackColor = true;
            this.btnSalirMaestro.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnBorrarMaestro
            // 
            this.btnBorrarMaestro.Location = new System.Drawing.Point(682, 9);
            this.btnBorrarMaestro.Name = "btnBorrarMaestro";
            this.btnBorrarMaestro.Size = new System.Drawing.Size(91, 56);
            this.btnBorrarMaestro.TabIndex = 132;
            this.btnBorrarMaestro.Text = "Borrar";
            this.btnBorrarMaestro.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBorrarMaestro.UseVisualStyleBackColor = true;
            this.btnBorrarMaestro.Click += new System.EventHandler(this.btnBorrar_Click);
            // 
            // btnLimpiarMaestro
            // 
            this.btnLimpiarMaestro.Location = new System.Drawing.Point(594, 9);
            this.btnLimpiarMaestro.Name = "btnLimpiarMaestro";
            this.btnLimpiarMaestro.Size = new System.Drawing.Size(91, 56);
            this.btnLimpiarMaestro.TabIndex = 131;
            this.btnLimpiarMaestro.Text = "Limpiar";
            this.btnLimpiarMaestro.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnLimpiarMaestro.UseVisualStyleBackColor = true;
            this.btnLimpiarMaestro.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnGuardarMaestro
            // 
            this.btnGuardarMaestro.Location = new System.Drawing.Point(507, 9);
            this.btnGuardarMaestro.Name = "btnGuardarMaestro";
            this.btnGuardarMaestro.Size = new System.Drawing.Size(90, 56);
            this.btnGuardarMaestro.TabIndex = 130;
            this.btnGuardarMaestro.Text = "Guardar";
            this.btnGuardarMaestro.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGuardarMaestro.UseVisualStyleBackColor = true;
            this.btnGuardarMaestro.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // label39
            // 
            this.label39.BackColor = System.Drawing.SystemColors.HotTrack;
            this.label39.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label39.ForeColor = System.Drawing.SystemColors.Window;
            this.label39.Location = new System.Drawing.Point(2, 9);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(509, 56);
            this.label39.TabIndex = 129;
            this.label39.Text = "Facturacion ";
            this.label39.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // button19
            // 
            this.button19.Location = new System.Drawing.Point(426, 570);
            this.button19.Name = "button19";
            this.button19.Size = new System.Drawing.Size(134, 59);
            this.button19.TabIndex = 148;
            this.button19.Text = "Guardar";
            this.button19.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button19.UseVisualStyleBackColor = true;
            // 
            // button18
            // 
            this.button18.Location = new System.Drawing.Point(286, 570);
            this.button18.Name = "button18";
            this.button18.Size = new System.Drawing.Size(134, 59);
            this.button18.TabIndex = 147;
            this.button18.Text = "Borrar";
            this.button18.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button18.UseVisualStyleBackColor = true;
            this.button18.Click += new System.EventHandler(this.btnBorrarLn_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(146, 570);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(134, 59);
            this.btnLimpiar.TabIndex = 146;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiarDT_Click);
            // 
            // btnInsertarLn
            // 
            this.btnInsertarLn.Location = new System.Drawing.Point(6, 570);
            this.btnInsertarLn.Name = "btnInsertarLn";
            this.btnInsertarLn.Size = new System.Drawing.Size(134, 59);
            this.btnInsertarLn.TabIndex = 145;
            this.btnInsertarLn.Text = "Insertar";
            this.btnInsertarLn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnInsertarLn.UseVisualStyleBackColor = true;
            this.btnInsertarLn.Click += new System.EventHandler(this.btnInsertarLn_Click);
            // 
            // dgv
            // 
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Location = new System.Drawing.Point(6, 279);
            this.dgv.Name = "dgv";
            this.dgv.Size = new System.Drawing.Size(1076, 285);
            this.dgv.TabIndex = 144;
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.label11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label11.Location = new System.Drawing.Point(1106, 210);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(153, 28);
            this.label11.TabIndex = 138;
            this.label11.Text = "Total Ln";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.label10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label10.Location = new System.Drawing.Point(947, 211);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(153, 28);
            this.label10.TabIndex = 137;
            this.label10.Text = "Impuesto";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label9.Location = new System.Drawing.Point(788, 211);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(153, 28);
            this.label9.TabIndex = 136;
            this.label9.Text = "Precio";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label8.Location = new System.Drawing.Point(629, 210);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(153, 28);
            this.label8.TabIndex = 135;
            this.label8.Text = "Cantidad";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label7.Location = new System.Drawing.Point(183, 210);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(440, 28);
            this.label7.TabIndex = 134;
            this.label7.Text = "Descripcion";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnArticulo
            // 
            this.btnArticulo.Location = new System.Drawing.Point(135, 241);
            this.btnArticulo.Name = "btnArticulo";
            this.btnArticulo.Size = new System.Drawing.Size(42, 21);
            this.btnArticulo.TabIndex = 152;
            this.btnArticulo.UseVisualStyleBackColor = true;
            this.btnArticulo.Click += new System.EventHandler(this.btnArticulo_Click);
            // 
            // txtArticulo
            // 
            this.txtArticulo.Location = new System.Drawing.Point(8, 241);
            this.txtArticulo.Name = "txtArticulo";
            this.txtArticulo.Size = new System.Drawing.Size(121, 20);
            this.txtArticulo.TabIndex = 151;
            this.txtArticulo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtArticulo_KeyDown);
            this.txtArticulo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtArticulo_KeyPress);
            this.txtArticulo.Leave += new System.EventHandler(this.txtArticulo_Leave);
            // 
            // lblArticulo
            // 
            this.lblArticulo.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.lblArticulo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblArticulo.Location = new System.Drawing.Point(8, 211);
            this.lblArticulo.Name = "lblArticulo";
            this.lblArticulo.Size = new System.Drawing.Size(169, 27);
            this.lblArticulo.TabIndex = 150;
            this.lblArticulo.Text = "Articulo";
            this.lblArticulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(736, 570);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(211, 28);
            this.label4.TabIndex = 153;
            this.label4.Text = "Sub Total";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(736, 601);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(211, 28);
            this.label5.TabIndex = 155;
            this.label5.Text = "Impuesto";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(736, 638);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(211, 28);
            this.label6.TabIndex = 157;
            this.label6.Text = "Total";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSubtotal
            // 
            this.lblSubtotal.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.lblSubtotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSubtotal.Location = new System.Drawing.Point(953, 570);
            this.lblSubtotal.Name = "lblSubtotal";
            this.lblSubtotal.Size = new System.Drawing.Size(129, 28);
            this.lblSubtotal.TabIndex = 159;
            this.lblSubtotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblImpuesto
            // 
            this.lblImpuesto.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.lblImpuesto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblImpuesto.Location = new System.Drawing.Point(953, 601);
            this.lblImpuesto.Name = "lblImpuesto";
            this.lblImpuesto.Size = new System.Drawing.Size(129, 28);
            this.lblImpuesto.TabIndex = 160;
            this.lblImpuesto.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTotal
            // 
            this.lblTotal.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.lblTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTotal.Location = new System.Drawing.Point(953, 638);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(129, 28);
            this.lblTotal.TabIndex = 161;
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblFactura
            // 
            this.lblFactura.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.lblFactura.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblFactura.Location = new System.Drawing.Point(228, 76);
            this.lblFactura.Name = "lblFactura";
            this.lblFactura.Size = new System.Drawing.Size(129, 28);
            this.lblFactura.TabIndex = 162;
            this.lblFactura.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblFechaFactura
            // 
            this.lblFechaFactura.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.lblFechaFactura.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblFechaFactura.Location = new System.Drawing.Point(281, 139);
            this.lblFechaFactura.Name = "lblFechaFactura";
            this.lblFechaFactura.Size = new System.Drawing.Size(129, 28);
            this.lblFechaFactura.TabIndex = 163;
            this.lblFechaFactura.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPaga
            // 
            this.lblPaga.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.lblPaga.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPaga.Location = new System.Drawing.Point(1114, 88);
            this.lblPaga.Name = "lblPaga";
            this.lblPaga.Size = new System.Drawing.Size(58, 28);
            this.lblPaga.TabIndex = 164;
            this.lblPaga.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label15
            // 
            this.label15.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.label15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label15.Location = new System.Drawing.Point(183, 241);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(440, 28);
            this.label15.TabIndex = 165;
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPrecio
            // 
            this.lblPrecio.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.lblPrecio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPrecio.Location = new System.Drawing.Point(788, 242);
            this.lblPrecio.Name = "lblPrecio";
            this.lblPrecio.Size = new System.Drawing.Size(153, 28);
            this.lblPrecio.TabIndex = 167;
            this.lblPrecio.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblImpuestoLn
            // 
            this.lblImpuestoLn.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.lblImpuestoLn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblImpuestoLn.Location = new System.Drawing.Point(947, 242);
            this.lblImpuestoLn.Name = "lblImpuestoLn";
            this.lblImpuestoLn.Size = new System.Drawing.Size(153, 28);
            this.lblImpuestoLn.TabIndex = 168;
            this.lblImpuestoLn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTotalLn
            // 
            this.lblTotalLn.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.lblTotalLn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTotalLn.Location = new System.Drawing.Point(1106, 242);
            this.lblTotalLn.Name = "lblTotalLn";
            this.lblTotalLn.Size = new System.Drawing.Size(153, 28);
            this.lblTotalLn.TabIndex = 169;
            this.lblTotalLn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtCantidad
            // 
            this.txtCantidad.Location = new System.Drawing.Point(629, 241);
            this.txtCantidad.Multiline = true;
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(153, 28);
            this.txtCantidad.TabIndex = 170;
            this.txtCantidad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCantidad_KeyPress);
            this.txtCantidad.Leave += new System.EventHandler(this.txtCantidad_Leave);
            // 
            // lblSucursal
            // 
            this.lblSucursal.BackColor = System.Drawing.SystemColors.HotTrack;
            this.lblSucursal.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSucursal.ForeColor = System.Drawing.SystemColors.Window;
            this.lblSucursal.Location = new System.Drawing.Point(357, 9);
            this.lblSucursal.Name = "lblSucursal";
            this.lblSucursal.Size = new System.Drawing.Size(154, 56);
            this.lblSucursal.TabIndex = 171;
            this.lblSucursal.Text = "Sucursal";
            this.lblSucursal.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblNombre
            // 
            this.lblNombre.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.lblNombre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblNombre.Location = new System.Drawing.Point(416, 105);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(269, 28);
            this.lblNombre.TabIndex = 172;
            this.lblNombre.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // NivelPrecio
            // 
            this.NivelPrecio.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.NivelPrecio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NivelPrecio.Location = new System.Drawing.Point(889, 126);
            this.NivelPrecio.Name = "NivelPrecio";
            this.NivelPrecio.Size = new System.Drawing.Size(219, 28);
            this.NivelPrecio.TabIndex = 173;
            this.NivelPrecio.Text = "Nivel de Precio";
            this.NivelPrecio.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblNivel
            // 
            this.lblNivel.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.lblNivel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblNivel.Location = new System.Drawing.Point(1114, 126);
            this.lblNivel.Name = "lblNivel";
            this.lblNivel.Size = new System.Drawing.Size(58, 28);
            this.lblNivel.TabIndex = 174;
            this.lblNivel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(11, 167);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(219, 28);
            this.label12.TabIndex = 175;
            this.label12.Text = "Lleva Comprobatoria Fiscal";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(236, 174);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 176;
            // 
            // lblTipo
            // 
            this.lblTipo.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.lblTipo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTipo.Location = new System.Drawing.Point(1114, 167);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(58, 28);
            this.lblTipo.TabIndex = 178;
            this.lblTipo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label17
            // 
            this.label17.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label17.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label17.Location = new System.Drawing.Point(889, 167);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(219, 28);
            this.label17.TabIndex = 177;
            this.label17.Text = "Tipo de Cliente";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmFactura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1337, 724);
            this.Controls.Add(this.lblTipo);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.lblNivel);
            this.Controls.Add(this.NivelPrecio);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.lblSucursal);
            this.Controls.Add(this.txtCantidad);
            this.Controls.Add(this.lblTotalLn);
            this.Controls.Add(this.lblImpuestoLn);
            this.Controls.Add(this.lblPrecio);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.lblPaga);
            this.Controls.Add(this.lblFechaFactura);
            this.Controls.Add(this.lblFactura);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.lblImpuesto);
            this.Controls.Add(this.lblSubtotal);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnArticulo);
            this.Controls.Add(this.txtArticulo);
            this.Controls.Add(this.lblArticulo);
            this.Controls.Add(this.button19);
            this.Controls.Add(this.button18);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnInsertarLn);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnSalirMaestro);
            this.Controls.Add(this.btnBorrarMaestro);
            this.Controls.Add(this.btnLimpiarMaestro);
            this.Controls.Add(this.btnGuardarMaestro);
            this.Controls.Add(this.label39);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnCliente);
            this.Controls.Add(this.txtCliente);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnFactura);
            this.Controls.Add(this.label38);
            this.Name = "frmFactura";
            this.Text = "frmFactura";
            this.Load += new System.EventHandler(this.frmFactura_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmFactura_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnFactura;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.Button btnCliente;
        private System.Windows.Forms.TextBox txtCliente;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSalirMaestro;
        private System.Windows.Forms.Button btnBorrarMaestro;
        private System.Windows.Forms.Button btnLimpiarMaestro;
        private System.Windows.Forms.Button btnGuardarMaestro;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.Button button19;
        private System.Windows.Forms.Button button18;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnInsertarLn;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnArticulo;
        private System.Windows.Forms.TextBox txtArticulo;
        private System.Windows.Forms.Label lblArticulo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblSubtotal;
        private System.Windows.Forms.Label lblImpuesto;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblFactura;
        private System.Windows.Forms.Label lblFechaFactura;
        private System.Windows.Forms.Label lblPaga;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label lblPrecio;
        private System.Windows.Forms.Label lblImpuestoLn;
        private System.Windows.Forms.Label lblTotalLn;
        private System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.Label lblSucursal;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label NivelPrecio;
        private System.Windows.Forms.Label lblNivel;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label lblTipo;
        private System.Windows.Forms.Label label17;
    }
}