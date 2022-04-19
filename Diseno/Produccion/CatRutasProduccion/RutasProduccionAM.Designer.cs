namespace ALTIMA_ERP_2022.Diseno.Produccion.CatRutasProduccion
{
    partial class RutasProduccionAM
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
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.cmbprocesostree = new DevComponents.DotNetBar.Controls.ComboTree();
            this.nombre_proceso = new DevComponents.AdvTree.ColumnHeader();
            this.tipo_proceso = new DevComponents.AdvTree.ColumnHeader();
            this.btnEliminar = new DevComponents.DotNetBar.ButtonX();
            this.btnAgregar = new DevComponents.DotNetBar.ButtonX();
            this.lvProcesos = new System.Windows.Forms.ListView();
            this.id = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Nombre = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Tipo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Cancelar = new DevComponents.DotNetBar.ButtonX();
            this.btnAceptar = new DevComponents.DotNetBar.ButtonX();
            this.SuspendLayout();
            // 
            // txtNombre
            // 
            // 
            // 
            // 
            this.txtNombre.Border.Class = "TextBoxBorder";
            this.txtNombre.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtNombre.Location = new System.Drawing.Point(94, 13);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.PreventEnterBeep = true;
            this.txtNombre.Size = new System.Drawing.Size(256, 20);
            this.txtNombre.TabIndex = 1;
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(13, 9);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(75, 23);
            this.labelX1.TabIndex = 3;
            this.labelX1.Text = "Nombre";
            // 
            // labelX2
            // 
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(13, 46);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(75, 23);
            this.labelX2.TabIndex = 3;
            this.labelX2.Text = "Proceso";
            // 
            // cmbprocesostree
            // 
            this.cmbprocesostree.BackColor = System.Drawing.SystemColors.Window;
            // 
            // 
            // 
            this.cmbprocesostree.BackgroundStyle.Class = "TextBoxBorder";
            this.cmbprocesostree.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.cmbprocesostree.ButtonDropDown.Visible = true;
            this.cmbprocesostree.Columns.Add(this.nombre_proceso);
            this.cmbprocesostree.Columns.Add(this.tipo_proceso);
            this.cmbprocesostree.GridRowLines = true;
            this.cmbprocesostree.Location = new System.Drawing.Point(94, 46);
            this.cmbprocesostree.Name = "cmbprocesostree";
            this.cmbprocesostree.Size = new System.Drawing.Size(256, 23);
            this.cmbprocesostree.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cmbprocesostree.TabIndex = 4;
            // 
            // nombre_proceso
            // 
            this.nombre_proceso.ColumnName = "nombre";
            this.nombre_proceso.DataFieldName = "nombre";
            this.nombre_proceso.Name = "nombre_proceso";
            this.nombre_proceso.Text = "Nombre";
            this.nombre_proceso.Width.Absolute = 150;
            // 
            // tipo_proceso
            // 
            this.tipo_proceso.ColumnName = "tipo";
            this.tipo_proceso.DataFieldName = "tipo";
            this.tipo_proceso.Name = "tipo_proceso";
            this.tipo_proceso.Text = "Tipo";
            this.tipo_proceso.Width.Absolute = 150;
            // 
            // btnEliminar
            // 
            this.btnEliminar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnEliminar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnEliminar.Location = new System.Drawing.Point(193, 76);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(75, 23);
            this.btnEliminar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnEliminar.TabIndex = 5;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAgregar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnAgregar.Location = new System.Drawing.Point(274, 76);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(75, 23);
            this.btnAgregar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnAgregar.TabIndex = 5;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // lvProcesos
            // 
            this.lvProcesos.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.id,
            this.Nombre,
            this.Tipo});
            this.lvProcesos.FullRowSelect = true;
            this.lvProcesos.HideSelection = false;
            this.lvProcesos.Location = new System.Drawing.Point(13, 122);
            this.lvProcesos.MultiSelect = false;
            this.lvProcesos.Name = "lvProcesos";
            this.lvProcesos.Size = new System.Drawing.Size(336, 320);
            this.lvProcesos.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvProcesos.TabIndex = 6;
            this.lvProcesos.UseCompatibleStateImageBehavior = false;
            this.lvProcesos.View = System.Windows.Forms.View.Details;
            // 
            // id
            // 
            this.id.Text = "id";
            // 
            // Nombre
            // 
            this.Nombre.Text = "Proceso";
            this.Nombre.Width = 150;
            // 
            // Tipo
            // 
            this.Tipo.Text = "Tipo";
            this.Tipo.Width = 120;
            // 
            // Cancelar
            // 
            this.Cancelar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.Cancelar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.Cancelar.Image = global::ALTIMA_ERP_2022.Properties.Resources.cancelar;
            this.Cancelar.ImageFixedSize = new System.Drawing.Size(24, 24);
            this.Cancelar.Location = new System.Drawing.Point(143, 448);
            this.Cancelar.Name = "Cancelar";
            this.Cancelar.Size = new System.Drawing.Size(100, 35);
            this.Cancelar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.Cancelar.TabIndex = 8;
            this.Cancelar.Text = "Cancelar";
            this.Cancelar.Click += new System.EventHandler(this.Cancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAceptar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnAceptar.Image = global::ALTIMA_ERP_2022.Properties.Resources.aceptar;
            this.btnAceptar.ImageFixedSize = new System.Drawing.Size(24, 24);
            this.btnAceptar.Location = new System.Drawing.Point(249, 448);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(100, 35);
            this.btnAceptar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnAceptar.TabIndex = 7;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // RutasProduccionAM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(361, 487);
            this.Controls.Add(this.Cancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.lvProcesos);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.cmbprocesostree);
            this.Controls.Add(this.labelX2);
            this.Controls.Add(this.labelX1);
            this.Controls.Add(this.txtNombre);
            this.DoubleBuffered = true;
            this.MinimizeBox = false;
            this.Name = "RutasProduccionAM";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Agregar / Modificar Ruta de producción";
            this.Load += new System.EventHandler(this.RutasProduccionAM_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private DevComponents.DotNetBar.Controls.TextBoxX txtNombre;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.Controls.ComboTree cmbprocesostree;
        private DevComponents.DotNetBar.ButtonX btnEliminar;
        private DevComponents.DotNetBar.ButtonX btnAgregar;
        private System.Windows.Forms.ListView lvProcesos;
        private DevComponents.AdvTree.ColumnHeader nombre_proceso;
        private DevComponents.AdvTree.ColumnHeader tipo_proceso;
        private System.Windows.Forms.ColumnHeader Nombre;
        private System.Windows.Forms.ColumnHeader Tipo;
        private System.Windows.Forms.ColumnHeader id;
        private DevComponents.DotNetBar.ButtonX Cancelar;
        private DevComponents.DotNetBar.ButtonX btnAceptar;
    }
}