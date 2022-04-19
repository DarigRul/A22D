
namespace ALTIMA_ERP_2022.Diseno.CatForros
{
    partial class ForrosAM
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
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.txtNombre = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.txtDescripcion = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.cmbComposicion = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.labelX6 = new DevComponents.DotNetBar.LabelX();
            this.cmbColor = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.labelX7 = new DevComponents.DotNetBar.LabelX();
            this.cmbProveedor = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.labelX8 = new DevComponents.DotNetBar.LabelX();
            this.txtClaveProveedor = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX9 = new DevComponents.DotNetBar.LabelX();
            this.btnEliminarImagen = new DevComponents.DotNetBar.ButtonX();
            this.btnCargarImagen = new DevComponents.DotNetBar.ButtonX();
            this.pbImagen = new System.Windows.Forms.PictureBox();
            this.btnAgregar = new DevComponents.DotNetBar.ButtonX();
            this.btnAceptar = new DevComponents.DotNetBar.ButtonX();
            this.btnCancelar = new DevComponents.DotNetBar.ButtonX();
            this.txtPorcentaje = new DevComponents.Editors.DoubleInput();
            this.txtAncho = new DevComponents.Editors.DoubleInput();
            this.lvComposiciones = new System.Windows.Forms.ListView();
            this.id_composicion = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.composicion = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.porcentaje = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.labelX10 = new DevComponents.DotNetBar.LabelX();
            this.lblPorcentaje = new DevComponents.DotNetBar.LabelX();
            this.labelX11 = new DevComponents.DotNetBar.LabelX();
            this.txtClaveForro = new DevComponents.DotNetBar.Controls.TextBoxX();
            ((System.ComponentModel.ISupportInitialize)(this.pbImagen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPorcentaje)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAncho)).BeginInit();
            this.SuspendLayout();
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(17, 20);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(75, 23);
            this.labelX1.TabIndex = 17;
            this.labelX1.Text = "Nombre: ";
            // 
            // txtNombre
            // 
            this.txtNombre.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtNombre.Border.Class = "TextBoxBorder";
            this.txtNombre.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtNombre.DisabledBackColor = System.Drawing.Color.White;
            this.txtNombre.ForeColor = System.Drawing.Color.Black;
            this.txtNombre.Location = new System.Drawing.Point(98, 21);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.PreventEnterBeep = true;
            this.txtNombre.Size = new System.Drawing.Size(244, 20);
            this.txtNombre.TabIndex = 0;
            // 
            // labelX2
            // 
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(17, 48);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(75, 23);
            this.labelX2.TabIndex = 18;
            this.labelX2.Text = "Descripción: ";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtDescripcion.Border.Class = "TextBoxBorder";
            this.txtDescripcion.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtDescripcion.DisabledBackColor = System.Drawing.Color.White;
            this.txtDescripcion.ForeColor = System.Drawing.Color.Black;
            this.txtDescripcion.Location = new System.Drawing.Point(98, 49);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.PreventEnterBeep = true;
            this.txtDescripcion.Size = new System.Drawing.Size(244, 20);
            this.txtDescripcion.TabIndex = 1;
            // 
            // labelX3
            // 
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Location = new System.Drawing.Point(17, 104);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(75, 23);
            this.labelX3.TabIndex = 20;
            this.labelX3.Text = "Composición: ";
            // 
            // cmbComposicion
            // 
            this.cmbComposicion.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbComposicion.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbComposicion.DisplayMember = "Text";
            this.cmbComposicion.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbComposicion.ForeColor = System.Drawing.Color.Black;
            this.cmbComposicion.FormattingEnabled = true;
            this.cmbComposicion.ItemHeight = 15;
            this.cmbComposicion.Location = new System.Drawing.Point(98, 105);
            this.cmbComposicion.Name = "cmbComposicion";
            this.cmbComposicion.Size = new System.Drawing.Size(244, 21);
            this.cmbComposicion.Sorted = true;
            this.cmbComposicion.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cmbComposicion.TabIndex = 3;
            // 
            // labelX4
            // 
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Location = new System.Drawing.Point(17, 132);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(75, 23);
            this.labelX4.TabIndex = 21;
            this.labelX4.Text = "Porcentaje: ";
            // 
            // labelX5
            // 
            // 
            // 
            // 
            this.labelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX5.Location = new System.Drawing.Point(17, 76);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(75, 23);
            this.labelX5.TabIndex = 19;
            this.labelX5.Text = "Ancho: ";
            // 
            // labelX6
            // 
            // 
            // 
            // 
            this.labelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX6.Location = new System.Drawing.Point(361, 48);
            this.labelX6.Name = "labelX6";
            this.labelX6.Size = new System.Drawing.Size(75, 23);
            this.labelX6.TabIndex = 27;
            this.labelX6.Text = "Color:";
            // 
            // cmbColor
            // 
            this.cmbColor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbColor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbColor.DisplayMember = "Text";
            this.cmbColor.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbColor.ForeColor = System.Drawing.Color.Black;
            this.cmbColor.FormattingEnabled = true;
            this.cmbColor.ItemHeight = 15;
            this.cmbColor.Location = new System.Drawing.Point(457, 49);
            this.cmbColor.Name = "cmbColor";
            this.cmbColor.Size = new System.Drawing.Size(244, 21);
            this.cmbColor.Sorted = true;
            this.cmbColor.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cmbColor.TabIndex = 10;
            // 
            // labelX7
            // 
            // 
            // 
            // 
            this.labelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX7.Location = new System.Drawing.Point(361, 76);
            this.labelX7.Name = "labelX7";
            this.labelX7.Size = new System.Drawing.Size(75, 23);
            this.labelX7.TabIndex = 28;
            this.labelX7.Text = "Proveedor: ";
            // 
            // cmbProveedor
            // 
            this.cmbProveedor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbProveedor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbProveedor.DisplayMember = "Text";
            this.cmbProveedor.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbProveedor.ForeColor = System.Drawing.Color.Black;
            this.cmbProveedor.FormattingEnabled = true;
            this.cmbProveedor.ItemHeight = 15;
            this.cmbProveedor.Location = new System.Drawing.Point(457, 77);
            this.cmbProveedor.Name = "cmbProveedor";
            this.cmbProveedor.Size = new System.Drawing.Size(244, 21);
            this.cmbProveedor.Sorted = true;
            this.cmbProveedor.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cmbProveedor.TabIndex = 11;
            // 
            // labelX8
            // 
            // 
            // 
            // 
            this.labelX8.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX8.Location = new System.Drawing.Point(361, 104);
            this.labelX8.Name = "labelX8";
            this.labelX8.Size = new System.Drawing.Size(90, 23);
            this.labelX8.TabIndex = 29;
            this.labelX8.Text = "Clave proveedor: ";
            // 
            // txtClaveProveedor
            // 
            this.txtClaveProveedor.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtClaveProveedor.Border.Class = "TextBoxBorder";
            this.txtClaveProveedor.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtClaveProveedor.DisabledBackColor = System.Drawing.Color.White;
            this.txtClaveProveedor.ForeColor = System.Drawing.Color.Black;
            this.txtClaveProveedor.Location = new System.Drawing.Point(456, 105);
            this.txtClaveProveedor.Name = "txtClaveProveedor";
            this.txtClaveProveedor.PreventEnterBeep = true;
            this.txtClaveProveedor.Size = new System.Drawing.Size(130, 20);
            this.txtClaveProveedor.TabIndex = 12;
            // 
            // labelX9
            // 
            // 
            // 
            // 
            this.labelX9.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX9.Location = new System.Drawing.Point(361, 132);
            this.labelX9.Name = "labelX9";
            this.labelX9.Size = new System.Drawing.Size(90, 23);
            this.labelX9.TabIndex = 30;
            this.labelX9.Text = "Imagen: ";
            // 
            // btnEliminarImagen
            // 
            this.btnEliminarImagen.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnEliminarImagen.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnEliminarImagen.Image = global::ALTIMA_ERP_2022.Properties.Resources.imagen_borrar;
            this.btnEliminarImagen.ImageFixedSize = new System.Drawing.Size(16, 16);
            this.btnEliminarImagen.Location = new System.Drawing.Point(581, 132);
            this.btnEliminarImagen.Name = "btnEliminarImagen";
            this.btnEliminarImagen.Size = new System.Drawing.Size(120, 23);
            this.btnEliminarImagen.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnEliminarImagen.TabIndex = 14;
            this.btnEliminarImagen.Text = "Eliminar";
            this.btnEliminarImagen.Click += new System.EventHandler(this.btnEliminarImagen_Click);
            // 
            // btnCargarImagen
            // 
            this.btnCargarImagen.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCargarImagen.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCargarImagen.Image = global::ALTIMA_ERP_2022.Properties.Resources.imagen_cargar;
            this.btnCargarImagen.ImageFixedSize = new System.Drawing.Size(16, 16);
            this.btnCargarImagen.Location = new System.Drawing.Point(458, 132);
            this.btnCargarImagen.Name = "btnCargarImagen";
            this.btnCargarImagen.Size = new System.Drawing.Size(117, 23);
            this.btnCargarImagen.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnCargarImagen.TabIndex = 13;
            this.btnCargarImagen.Text = "Cargar";
            this.btnCargarImagen.Click += new System.EventHandler(this.btnCargarImagen_Click);
            // 
            // pbImagen
            // 
            this.pbImagen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbImagen.InitialImage = global::ALTIMA_ERP_2022.Properties.Resources.imagen;
            this.pbImagen.Location = new System.Drawing.Point(457, 162);
            this.pbImagen.Name = "pbImagen";
            this.pbImagen.Size = new System.Drawing.Size(244, 212);
            this.pbImagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbImagen.TabIndex = 7;
            this.pbImagen.TabStop = false;
            // 
            // btnAgregar
            // 
            this.btnAgregar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAgregar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnAgregar.Image = global::ALTIMA_ERP_2022.Properties.Resources.agregar;
            this.btnAgregar.ImageFixedSize = new System.Drawing.Size(16, 16);
            this.btnAgregar.Location = new System.Drawing.Point(210, 132);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(132, 23);
            this.btnAgregar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnAgregar.TabIndex = 5;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAceptar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnAceptar.Image = global::ALTIMA_ERP_2022.Properties.Resources.aceptar;
            this.btnAceptar.ImageFixedSize = new System.Drawing.Size(24, 24);
            this.btnAceptar.Location = new System.Drawing.Point(603, 380);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(100, 35);
            this.btnAceptar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnAceptar.TabIndex = 15;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancelar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCancelar.Image = global::ALTIMA_ERP_2022.Properties.Resources.cancelar;
            this.btnCancelar.ImageFixedSize = new System.Drawing.Size(24, 24);
            this.btnCancelar.Location = new System.Drawing.Point(497, 380);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(100, 35);
            this.btnCancelar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnCancelar.TabIndex = 16;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // txtPorcentaje
            // 
            // 
            // 
            // 
            this.txtPorcentaje.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtPorcentaje.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtPorcentaje.ButtonCalculator.Visible = true;
            this.txtPorcentaje.ButtonClear.Visible = true;
            this.txtPorcentaje.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtPorcentaje.Increment = 1D;
            this.txtPorcentaje.Location = new System.Drawing.Point(98, 133);
            this.txtPorcentaje.Name = "txtPorcentaje";
            this.txtPorcentaje.Size = new System.Drawing.Size(106, 20);
            this.txtPorcentaje.TabIndex = 4;
            // 
            // txtAncho
            // 
            // 
            // 
            // 
            this.txtAncho.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtAncho.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtAncho.ButtonClear.Visible = true;
            this.txtAncho.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtAncho.Increment = 1D;
            this.txtAncho.Location = new System.Drawing.Point(98, 77);
            this.txtAncho.Name = "txtAncho";
            this.txtAncho.Size = new System.Drawing.Size(128, 20);
            this.txtAncho.TabIndex = 2;
            // 
            // lvComposiciones
            // 
            this.lvComposiciones.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.id_composicion,
            this.composicion,
            this.porcentaje});
            this.lvComposiciones.FullRowSelect = true;
            this.lvComposiciones.HideSelection = false;
            this.lvComposiciones.Location = new System.Drawing.Point(98, 162);
            this.lvComposiciones.MultiSelect = false;
            this.lvComposiciones.Name = "lvComposiciones";
            this.lvComposiciones.Size = new System.Drawing.Size(244, 212);
            this.lvComposiciones.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvComposiciones.TabIndex = 6;
            this.lvComposiciones.UseCompatibleStateImageBehavior = false;
            this.lvComposiciones.View = System.Windows.Forms.View.Details;
            this.lvComposiciones.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lvComposiciones_KeyDown);
            // 
            // id_composicion
            // 
            this.id_composicion.Text = "No. ";
            this.id_composicion.Width = 40;
            // 
            // composicion
            // 
            this.composicion.Text = "Composición";
            this.composicion.Width = 120;
            // 
            // porcentaje
            // 
            this.porcentaje.Text = "Porcentaje";
            this.porcentaje.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.porcentaje.Width = 70;
            // 
            // labelX10
            // 
            // 
            // 
            // 
            this.labelX10.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX10.Location = new System.Drawing.Point(95, 380);
            this.labelX10.Name = "labelX10";
            this.labelX10.Size = new System.Drawing.Size(166, 23);
            this.labelX10.TabIndex = 22;
            this.labelX10.Text = "Porcentaje de composición total: ";
            // 
            // lblPorcentaje
            // 
            // 
            // 
            // 
            this.lblPorcentaje.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblPorcentaje.FontBold = true;
            this.lblPorcentaje.Location = new System.Drawing.Point(267, 380);
            this.lblPorcentaje.Name = "lblPorcentaje";
            this.lblPorcentaje.Size = new System.Drawing.Size(75, 23);
            this.lblPorcentaje.TabIndex = 23;
            this.lblPorcentaje.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // labelX11
            // 
            // 
            // 
            // 
            this.labelX11.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX11.Location = new System.Drawing.Point(360, 20);
            this.labelX11.Name = "labelX11";
            this.labelX11.Size = new System.Drawing.Size(75, 23);
            this.labelX11.TabIndex = 24;
            this.labelX11.Text = "Clave forro: ";
            // 
            // txtClaveForro
            // 
            // 
            // 
            // 
            this.txtClaveForro.Border.Class = "TextBoxBorder";
            this.txtClaveForro.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtClaveForro.Location = new System.Drawing.Point(457, 21);
            this.txtClaveForro.Name = "txtClaveForro";
            this.txtClaveForro.PreventEnterBeep = true;
            this.txtClaveForro.Size = new System.Drawing.Size(129, 20);
            this.txtClaveForro.TabIndex = 7;
            // 
            // ForrosAM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(721, 434);
            this.ControlBox = false;
            this.Controls.Add(this.txtClaveForro);
            this.Controls.Add(this.labelX11);
            this.Controls.Add(this.lblPorcentaje);
            this.Controls.Add(this.labelX10);
            this.Controls.Add(this.lvComposiciones);
            this.Controls.Add(this.txtAncho);
            this.Controls.Add(this.txtPorcentaje);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.btnEliminarImagen);
            this.Controls.Add(this.btnCargarImagen);
            this.Controls.Add(this.pbImagen);
            this.Controls.Add(this.cmbProveedor);
            this.Controls.Add(this.cmbColor);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.cmbComposicion);
            this.Controls.Add(this.txtClaveProveedor);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.labelX3);
            this.Controls.Add(this.labelX9);
            this.Controls.Add(this.labelX8);
            this.Controls.Add(this.labelX7);
            this.Controls.Add(this.labelX6);
            this.Controls.Add(this.labelX5);
            this.Controls.Add(this.labelX2);
            this.Controls.Add(this.labelX4);
            this.Controls.Add(this.labelX1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.Name = "ForrosAM";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Agregar / Editar Forro";
            this.Load += new System.EventHandler(this.ForrosAM_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbImagen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPorcentaje)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAncho)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.Controls.TextBoxX txtNombre;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.Controls.TextBoxX txtDescripcion;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cmbComposicion;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.ButtonX btnAgregar;
        private DevComponents.DotNetBar.LabelX labelX5;
        private DevComponents.DotNetBar.LabelX labelX6;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cmbColor;
        private DevComponents.DotNetBar.LabelX labelX7;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cmbProveedor;
        private DevComponents.DotNetBar.LabelX labelX8;
        private DevComponents.DotNetBar.Controls.TextBoxX txtClaveProveedor;
        private DevComponents.DotNetBar.LabelX labelX9;
        private System.Windows.Forms.PictureBox pbImagen;
        private DevComponents.DotNetBar.ButtonX btnCargarImagen;
        private DevComponents.DotNetBar.ButtonX btnEliminarImagen;
        private DevComponents.DotNetBar.ButtonX btnAceptar;
        private DevComponents.DotNetBar.ButtonX btnCancelar;
        private DevComponents.Editors.DoubleInput txtPorcentaje;
        private DevComponents.Editors.DoubleInput txtAncho;
        private System.Windows.Forms.ListView lvComposiciones;
        private System.Windows.Forms.ColumnHeader id_composicion;
        private System.Windows.Forms.ColumnHeader composicion;
        private System.Windows.Forms.ColumnHeader porcentaje;
        private DevComponents.DotNetBar.LabelX labelX10;
        private DevComponents.DotNetBar.LabelX lblPorcentaje;
        private DevComponents.DotNetBar.LabelX labelX11;
        private DevComponents.DotNetBar.Controls.TextBoxX txtClaveForro;
    }
}