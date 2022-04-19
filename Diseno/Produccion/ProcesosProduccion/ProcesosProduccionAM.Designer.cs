namespace ALTIMA_ERP_2022.Diseno.Produccion.ProcesosProduccion
{
    partial class ProcesosProduccionAM
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
            this.Cancelar = new DevComponents.DotNetBar.ButtonX();
            this.btnAceptar = new DevComponents.DotNetBar.ButtonX();
            this.lblNombre = new DevComponents.DotNetBar.LabelX();
            this.cmbTipoProceso = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.INTERNO = new DevComponents.Editors.ComboItem();
            this.EXTERNO = new DevComponents.Editors.ComboItem();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.SuspendLayout();
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
            this.txtNombre.Location = new System.Drawing.Point(80, 12);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.PreventEnterBeep = true;
            this.txtNombre.Size = new System.Drawing.Size(294, 20);
            this.txtNombre.TabIndex = 0;
            // 
            // Cancelar
            // 
            this.Cancelar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.Cancelar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.Cancelar.Image = global::ALTIMA_ERP_2022.Properties.Resources.cancelar;
            this.Cancelar.ImageFixedSize = new System.Drawing.Size(24, 24);
            this.Cancelar.Location = new System.Drawing.Point(168, 65);
            this.Cancelar.Name = "Cancelar";
            this.Cancelar.Size = new System.Drawing.Size(100, 35);
            this.Cancelar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.Cancelar.TabIndex = 3;
            this.Cancelar.Text = "Cancelar";
            this.Cancelar.Click += new System.EventHandler(this.Cancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAceptar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnAceptar.Image = global::ALTIMA_ERP_2022.Properties.Resources.aceptar;
            this.btnAceptar.ImageFixedSize = new System.Drawing.Size(24, 24);
            this.btnAceptar.Location = new System.Drawing.Point(274, 65);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(100, 35);
            this.btnAceptar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnAceptar.TabIndex = 2;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // lblNombre
            // 
            // 
            // 
            // 
            this.lblNombre.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblNombre.Location = new System.Drawing.Point(13, 8);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(61, 23);
            this.lblNombre.TabIndex = 7;
            this.lblNombre.Text = "Proceso";
            // 
            // cmbTipoProceso
            // 
            this.cmbTipoProceso.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbTipoProceso.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbTipoProceso.DisplayMember = "Text";
            this.cmbTipoProceso.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbTipoProceso.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoProceso.ForeColor = System.Drawing.Color.Black;
            this.cmbTipoProceso.FormattingEnabled = true;
            this.cmbTipoProceso.ItemHeight = 15;
            this.cmbTipoProceso.Items.AddRange(new object[] {
            this.INTERNO,
            this.EXTERNO});
            this.cmbTipoProceso.Location = new System.Drawing.Point(80, 39);
            this.cmbTipoProceso.Name = "cmbTipoProceso";
            this.cmbTipoProceso.Size = new System.Drawing.Size(294, 21);
            this.cmbTipoProceso.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cmbTipoProceso.TabIndex = 1;
            this.cmbTipoProceso.SelectedIndexChanged += new System.EventHandler(this.cmbTipoProceso_SelectedIndexChanged);
            // 
            // INTERNO
            // 
            this.INTERNO.Text = "INTERNO";
            // 
            // EXTERNO
            // 
            this.EXTERNO.Text = "EXTERNO";
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(12, 36);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(61, 23);
            this.labelX1.TabIndex = 7;
            this.labelX1.Text = "Tipo";
            // 
            // ProcesosProduccionAM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 105);
            this.Controls.Add(this.cmbTipoProceso);
            this.Controls.Add(this.labelX1);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.Cancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.txtNombre);
            this.DoubleBuffered = true;
            this.MinimizeBox = false;
            this.Name = "ProcesosProduccionAM";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Procesos de producción diseño";
            this.Load += new System.EventHandler(this.ProcesosProduccionAM_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.TextBoxX txtNombre;
        private DevComponents.DotNetBar.ButtonX Cancelar;
        private DevComponents.DotNetBar.ButtonX btnAceptar;
        private DevComponents.DotNetBar.LabelX lblNombre;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cmbTipoProceso;
        private DevComponents.Editors.ComboItem INTERNO;
        private DevComponents.Editors.ComboItem EXTERNO;
        private DevComponents.DotNetBar.LabelX labelX1;
    }
}