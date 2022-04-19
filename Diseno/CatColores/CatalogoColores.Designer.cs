
namespace ALTIMA_ERP_2022.Diseno.CatColores
{
    partial class CatalogoColores
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
            this.sgcColores = new DevComponents.DotNetBar.SuperGrid.SuperGridControl();
            this.id_color = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.nombre = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.codigo_color = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.estatus = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.estatus_texto = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.btnSalir = new DevComponents.DotNetBar.ButtonX();
            this.btnReporte = new DevComponents.DotNetBar.ButtonX();
            this.btnDesactivar = new DevComponents.DotNetBar.ButtonX();
            this.btnActivar = new DevComponents.DotNetBar.ButtonX();
            this.btnEditar = new DevComponents.DotNetBar.ButtonX();
            this.btnAgregar = new DevComponents.DotNetBar.ButtonX();
            this.panelEx1.SuspendLayout();
            this.SuspendLayout();
            // 
            // sgcColores
            // 
            this.sgcColores.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.sgcColores.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sgcColores.FilterExprColors.SysFunction = System.Drawing.Color.DarkRed;
            this.sgcColores.ForeColor = System.Drawing.Color.Black;
            this.sgcColores.Location = new System.Drawing.Point(0, 49);
            this.sgcColores.Name = "sgcColores";
            // 
            // 
            // 
            this.sgcColores.PrimaryGrid.AllowEdit = false;
            this.sgcColores.PrimaryGrid.AutoGenerateColumns = false;
            this.sgcColores.PrimaryGrid.Columns.Add(this.id_color);
            this.sgcColores.PrimaryGrid.Columns.Add(this.nombre);
            this.sgcColores.PrimaryGrid.Columns.Add(this.codigo_color);
            this.sgcColores.PrimaryGrid.Columns.Add(this.estatus);
            this.sgcColores.PrimaryGrid.Columns.Add(this.estatus_texto);
            this.sgcColores.PrimaryGrid.EnableColumnFiltering = true;
            this.sgcColores.PrimaryGrid.EnableFiltering = true;
            this.sgcColores.PrimaryGrid.EnableRowFiltering = true;
            // 
            // 
            // 
            this.sgcColores.PrimaryGrid.Filter.RowHeight = 30;
            this.sgcColores.PrimaryGrid.Filter.Visible = true;
            this.sgcColores.PrimaryGrid.FilterMatchType = DevComponents.DotNetBar.SuperGrid.FilterMatchType.RegularExpressions;
            // 
            // 
            // 
            this.sgcColores.PrimaryGrid.Footer.RowHeight = 30;
            this.sgcColores.PrimaryGrid.InitialSelection = DevComponents.DotNetBar.SuperGrid.RelativeSelection.Row;
            this.sgcColores.PrimaryGrid.MultiSelect = false;
            this.sgcColores.PrimaryGrid.SelectionGranularity = DevComponents.DotNetBar.SuperGrid.SelectionGranularity.Row;
            this.sgcColores.PrimaryGrid.UseAlternateColumnStyle = true;
            this.sgcColores.PrimaryGrid.UseAlternateRowStyle = true;
            this.sgcColores.Size = new System.Drawing.Size(599, 401);
            this.sgcColores.TabIndex = 8;
            this.sgcColores.Text = "superGridControl1";
            this.sgcColores.DataBindingComplete += new System.EventHandler<DevComponents.DotNetBar.SuperGrid.GridDataBindingCompleteEventArgs>(this.sgcColores_DataBindingComplete);
            this.sgcColores.SelectionChanged += new System.EventHandler<DevComponents.DotNetBar.SuperGrid.GridEventArgs>(this.sgcColores_SelectionChanged);
            // 
            // id_color
            // 
            this.id_color.DataPropertyName = "id_color";
            this.id_color.HeaderText = "id_color";
            this.id_color.Name = "id_color";
            this.id_color.Visible = false;
            // 
            // nombre
            // 
            this.nombre.AutoSizeMode = DevComponents.DotNetBar.SuperGrid.ColumnAutoSizeMode.Fill;
            this.nombre.DataPropertyName = "nombre";
            this.nombre.HeaderText = "Nombre";
            this.nombre.Name = "nombre";
            // 
            // codigo_color
            // 
            this.codigo_color.DataPropertyName = "codigo_color";
            this.codigo_color.HeaderText = "Color";
            this.codigo_color.Name = "codigo_color";
            // 
            // estatus
            // 
            this.estatus.DataPropertyName = "estatus";
            this.estatus.HeaderText = "estatus";
            this.estatus.Name = "estatus";
            this.estatus.Visible = false;
            // 
            // estatus_texto
            // 
            this.estatus_texto.AutoSizeMode = DevComponents.DotNetBar.SuperGrid.ColumnAutoSizeMode.DisplayedCells;
            this.estatus_texto.DataPropertyName = "estatus_texto";
            this.estatus_texto.EnableFiltering = DevComponents.DotNetBar.SuperGrid.Style.Tbool.True;
            this.estatus_texto.FilterAutoScan = true;
            this.estatus_texto.HeaderText = "Estatus";
            this.estatus_texto.MinimumWidth = 150;
            this.estatus_texto.Name = "estatus_texto";
            this.estatus_texto.Width = 150;
            // 
            // panelEx1
            // 
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx1.Controls.Add(this.btnSalir);
            this.panelEx1.Controls.Add(this.btnReporte);
            this.panelEx1.Controls.Add(this.btnDesactivar);
            this.panelEx1.Controls.Add(this.btnActivar);
            this.panelEx1.Controls.Add(this.btnEditar);
            this.panelEx1.Controls.Add(this.btnAgregar);
            this.panelEx1.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelEx1.Location = new System.Drawing.Point(0, 0);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(599, 49);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.TabIndex = 9;
            // 
            // btnSalir
            // 
            this.btnSalir.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSalir.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSalir.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnSalir.Image = global::ALTIMA_ERP_2022.Properties.Resources.salir;
            this.btnSalir.ImageFixedSize = new System.Drawing.Size(24, 24);
            this.btnSalir.Location = new System.Drawing.Point(485, 0);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(97, 49);
            this.btnSalir.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnSalir.TabIndex = 7;
            this.btnSalir.Text = "Salir";
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnReporte
            // 
            this.btnReporte.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnReporte.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnReporte.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnReporte.Image = global::ALTIMA_ERP_2022.Properties.Resources.reporte;
            this.btnReporte.ImageFixedSize = new System.Drawing.Size(24, 24);
            this.btnReporte.Location = new System.Drawing.Point(388, 0);
            this.btnReporte.Name = "btnReporte";
            this.btnReporte.Size = new System.Drawing.Size(97, 49);
            this.btnReporte.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnReporte.TabIndex = 6;
            this.btnReporte.Text = "Reporte";
            this.btnReporte.Click += new System.EventHandler(this.btnReporte_Click);
            // 
            // btnDesactivar
            // 
            this.btnDesactivar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnDesactivar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnDesactivar.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnDesactivar.Image = global::ALTIMA_ERP_2022.Properties.Resources.desactivar;
            this.btnDesactivar.ImageFixedSize = new System.Drawing.Size(24, 24);
            this.btnDesactivar.Location = new System.Drawing.Point(291, 0);
            this.btnDesactivar.Name = "btnDesactivar";
            this.btnDesactivar.Size = new System.Drawing.Size(97, 49);
            this.btnDesactivar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnDesactivar.TabIndex = 3;
            this.btnDesactivar.Text = "Desactivar";
            this.btnDesactivar.Click += new System.EventHandler(this.btnDesactivar_Click);
            // 
            // btnActivar
            // 
            this.btnActivar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnActivar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnActivar.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnActivar.Image = global::ALTIMA_ERP_2022.Properties.Resources.activar;
            this.btnActivar.ImageFixedSize = new System.Drawing.Size(24, 24);
            this.btnActivar.Location = new System.Drawing.Point(194, 0);
            this.btnActivar.Name = "btnActivar";
            this.btnActivar.Size = new System.Drawing.Size(97, 49);
            this.btnActivar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnActivar.TabIndex = 2;
            this.btnActivar.Text = "Activar";
            this.btnActivar.Click += new System.EventHandler(this.btnActivar_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnEditar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnEditar.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnEditar.Image = global::ALTIMA_ERP_2022.Properties.Resources.editar;
            this.btnEditar.ImageFixedSize = new System.Drawing.Size(24, 24);
            this.btnEditar.Location = new System.Drawing.Point(97, 0);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(97, 49);
            this.btnEditar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnEditar.TabIndex = 1;
            this.btnEditar.Text = "Editar";
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAgregar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnAgregar.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnAgregar.Image = global::ALTIMA_ERP_2022.Properties.Resources.agregar;
            this.btnAgregar.ImageFixedSize = new System.Drawing.Size(24, 24);
            this.btnAgregar.Location = new System.Drawing.Point(0, 0);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(97, 49);
            this.btnAgregar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnAgregar.TabIndex = 0;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // CatalogoColores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(599, 450);
            this.Controls.Add(this.sgcColores);
            this.Controls.Add(this.panelEx1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Name = "CatalogoColores";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Catalogo de Colores ";
            this.Load += new System.EventHandler(this.CatalogoColores_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CatalogoColores_KeyDown);
            this.panelEx1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private DevComponents.DotNetBar.SuperGrid.SuperGridControl sgcColores;
        private DevComponents.DotNetBar.SuperGrid.GridColumn id_color;
        private DevComponents.DotNetBar.SuperGrid.GridColumn nombre;
        private DevComponents.DotNetBar.SuperGrid.GridColumn codigo_color;
        private DevComponents.DotNetBar.SuperGrid.GridColumn estatus;
        private DevComponents.DotNetBar.PanelEx panelEx1;
        private DevComponents.DotNetBar.ButtonX btnEditar;
        private DevComponents.DotNetBar.ButtonX btnAgregar;
        private DevComponents.DotNetBar.ButtonX btnDesactivar;
        private DevComponents.DotNetBar.ButtonX btnActivar;
        private DevComponents.DotNetBar.SuperGrid.GridColumn estatus_texto;
        private DevComponents.DotNetBar.ButtonX btnReporte;
        private DevComponents.DotNetBar.ButtonX btnSalir;
    }
}