namespace ALTIMA_ERP_2022.Diseno.CatFamiliaComposicion
{
    partial class FamiliaComposicionAM
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
            this.txtNombre = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblNombre = new DevComponents.DotNetBar.LabelX();
            this.Cancelar = new DevComponents.DotNetBar.ButtonX();
            this.btnAceptar = new DevComponents.DotNetBar.ButtonX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.LvComposiciones = new System.Windows.Forms.ListView();
            this.cmbInstruccionesCuidado = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.cmbComposiciones = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.lvInstruccionesCuidado = new System.Windows.Forms.ListView();
            this.btnAgregaIc = new DevComponents.DotNetBar.ButtonX();
            this.btnEliminaric = new DevComponents.DotNetBar.ButtonX();
            this.btnComposicionEliminar = new DevComponents.DotNetBar.ButtonX();
            this.btnComposicionAgregar = new DevComponents.DotNetBar.ButtonX();
            this.SuspendLayout();
            // 
            // txtNombre
            // 
            // 
            // 
            // 
            this.txtNombre.Border.Class = "TextBoxBorder";
            this.txtNombre.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtNombre.Location = new System.Drawing.Point(129, 12);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.PreventEnterBeep = true;
            this.txtNombre.Size = new System.Drawing.Size(316, 20);
            this.txtNombre.TabIndex = 0;
            // 
            // lblNombre
            // 
            // 
            // 
            // 
            this.lblNombre.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblNombre.Location = new System.Drawing.Point(12, 12);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(111, 23);
            this.lblNombre.TabIndex = 1;
            this.lblNombre.Text = "Familia Composiciòn";
            // 
            // Cancelar
            // 
            this.Cancelar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.Cancelar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.Cancelar.Image = global::ALTIMA_ERP_2022.Properties.Resources.cancelar;
            this.Cancelar.ImageFixedSize = new System.Drawing.Size(24, 24);
            this.Cancelar.Location = new System.Drawing.Point(239, 443);
            this.Cancelar.Name = "Cancelar";
            this.Cancelar.Size = new System.Drawing.Size(100, 35);
            this.Cancelar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.Cancelar.TabIndex = 6;
            this.Cancelar.Text = "Cancelar";
            this.Cancelar.Click += new System.EventHandler(this.Cancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAceptar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnAceptar.Image = global::ALTIMA_ERP_2022.Properties.Resources.aceptar;
            this.btnAceptar.ImageFixedSize = new System.Drawing.Size(24, 24);
            this.btnAceptar.Location = new System.Drawing.Point(345, 443);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(100, 35);
            this.btnAceptar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnAceptar.TabIndex = 5;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.FontBold = true;
            this.labelX1.Location = new System.Drawing.Point(12, 41);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(201, 23);
            this.labelX1.TabIndex = 7;
            this.labelX1.Text = "Selecciona Instrucciones de cuidado";
            // 
            // labelX2
            // 
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.FontBold = true;
            this.labelX2.Location = new System.Drawing.Point(245, 41);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(196, 23);
            this.labelX2.TabIndex = 8;
            this.labelX2.Text = "Selecciona Composiciones";
            // 
            // LvComposiciones
            // 
            this.LvComposiciones.HideSelection = false;
            this.LvComposiciones.Location = new System.Drawing.Point(245, 104);
            this.LvComposiciones.Name = "LvComposiciones";
            this.LvComposiciones.Size = new System.Drawing.Size(200, 333);
            this.LvComposiciones.TabIndex = 10;
            this.LvComposiciones.UseCompatibleStateImageBehavior = false;
            this.LvComposiciones.View = System.Windows.Forms.View.List;
            // 
            // cmbInstruccionesCuidado
            // 
            this.cmbInstruccionesCuidado.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbInstruccionesCuidado.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbInstruccionesCuidado.DisplayMember = "Text";
            this.cmbInstruccionesCuidado.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbInstruccionesCuidado.FormattingEnabled = true;
            this.cmbInstruccionesCuidado.ItemHeight = 15;
            this.cmbInstruccionesCuidado.Location = new System.Drawing.Point(12, 71);
            this.cmbInstruccionesCuidado.Name = "cmbInstruccionesCuidado";
            this.cmbInstruccionesCuidado.Size = new System.Drawing.Size(151, 21);
            this.cmbInstruccionesCuidado.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cmbInstruccionesCuidado.TabIndex = 1;
            // 
            // cmbComposiciones
            // 
            this.cmbComposiciones.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbComposiciones.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbComposiciones.DisplayMember = "Text";
            this.cmbComposiciones.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbComposiciones.FormattingEnabled = true;
            this.cmbComposiciones.ItemHeight = 15;
            this.cmbComposiciones.Location = new System.Drawing.Point(245, 69);
            this.cmbComposiciones.Name = "cmbComposiciones";
            this.cmbComposiciones.Size = new System.Drawing.Size(148, 21);
            this.cmbComposiciones.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cmbComposiciones.TabIndex = 3;
            // 
            // lvInstruccionesCuidado
            // 
            this.lvInstruccionesCuidado.HideSelection = false;
            this.lvInstruccionesCuidado.Location = new System.Drawing.Point(14, 104);
            this.lvInstruccionesCuidado.Name = "lvInstruccionesCuidado";
            this.lvInstruccionesCuidado.Size = new System.Drawing.Size(198, 333);
            this.lvInstruccionesCuidado.TabIndex = 13;
            this.lvInstruccionesCuidado.UseCompatibleStateImageBehavior = false;
            this.lvInstruccionesCuidado.View = System.Windows.Forms.View.List;
            // 
            // btnAgregaIc
            // 
            this.btnAgregaIc.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAgregaIc.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnAgregaIc.Location = new System.Drawing.Point(170, 71);
            this.btnAgregaIc.Name = "btnAgregaIc";
            this.btnAgregaIc.Size = new System.Drawing.Size(20, 20);
            this.btnAgregaIc.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnAgregaIc.TabIndex = 2;
            this.btnAgregaIc.Text = "+";
            this.btnAgregaIc.Click += new System.EventHandler(this.btnAgregaIc_Click);
            // 
            // btnEliminaric
            // 
            this.btnEliminaric.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnEliminaric.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnEliminaric.Location = new System.Drawing.Point(193, 72);
            this.btnEliminaric.Name = "btnEliminaric";
            this.btnEliminaric.Size = new System.Drawing.Size(20, 20);
            this.btnEliminaric.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnEliminaric.TabIndex = 15;
            this.btnEliminaric.Text = "-";
            this.btnEliminaric.Click += new System.EventHandler(this.btnEliminaric_Click);
            // 
            // btnComposicionEliminar
            // 
            this.btnComposicionEliminar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnComposicionEliminar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnComposicionEliminar.Location = new System.Drawing.Point(425, 72);
            this.btnComposicionEliminar.Name = "btnComposicionEliminar";
            this.btnComposicionEliminar.Size = new System.Drawing.Size(20, 20);
            this.btnComposicionEliminar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnComposicionEliminar.TabIndex = 17;
            this.btnComposicionEliminar.Text = "-";
            this.btnComposicionEliminar.Click += new System.EventHandler(this.btnComposicionEliminar_Click);
            // 
            // btnComposicionAgregar
            // 
            this.btnComposicionAgregar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnComposicionAgregar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnComposicionAgregar.Location = new System.Drawing.Point(399, 71);
            this.btnComposicionAgregar.Name = "btnComposicionAgregar";
            this.btnComposicionAgregar.Size = new System.Drawing.Size(20, 20);
            this.btnComposicionAgregar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnComposicionAgregar.TabIndex = 4;
            this.btnComposicionAgregar.Text = "+";
            this.btnComposicionAgregar.Click += new System.EventHandler(this.btnComposicionAgregar_Click);
            // 
            // FamiliaComposicionAM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(453, 493);
            this.Controls.Add(this.btnComposicionEliminar);
            this.Controls.Add(this.btnComposicionAgregar);
            this.Controls.Add(this.btnEliminaric);
            this.Controls.Add(this.btnAgregaIc);
            this.Controls.Add(this.lvInstruccionesCuidado);
            this.Controls.Add(this.cmbComposiciones);
            this.Controls.Add(this.cmbInstruccionesCuidado);
            this.Controls.Add(this.LvComposiciones);
            this.Controls.Add(this.labelX2);
            this.Controls.Add(this.labelX1);
            this.Controls.Add(this.Cancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.txtNombre);
            this.DoubleBuffered = true;
            this.MinimizeBox = false;
            this.Name = "FamiliaComposicionAM";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Familia de composición Agregar / Modificar";
            this.Load += new System.EventHandler(this.FamiliaComposicionAM_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.TextBoxX txtNombre;
        private DevComponents.DotNetBar.LabelX lblNombre;
        private DevComponents.DotNetBar.ButtonX Cancelar;
        private DevComponents.DotNetBar.ButtonX btnAceptar;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.LabelX labelX2;
        private System.Windows.Forms.ListView LvComposiciones;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cmbInstruccionesCuidado;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cmbComposiciones;
        private System.Windows.Forms.ListView lvInstruccionesCuidado;
        private DevComponents.DotNetBar.ButtonX btnAgregaIc;
        private DevComponents.DotNetBar.ButtonX btnEliminaric;
        private DevComponents.DotNetBar.ButtonX btnComposicionEliminar;
        private DevComponents.DotNetBar.ButtonX btnComposicionAgregar;
    }
}