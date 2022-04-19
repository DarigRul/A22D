namespace ALTIMA_ERP_2022.Comercial.Precios
{
    partial class CatalogoPreciosFamiliaComposicion
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
            DevComponents.DotNetBar.SuperGrid.ColumnGroupHeader columnGroupHeader1 = new DevComponents.DotNetBar.SuperGrid.ColumnGroupHeader();
            DevComponents.DotNetBar.SuperGrid.Style.Background background1 = new DevComponents.DotNetBar.SuperGrid.Style.Background();
            DevComponents.DotNetBar.SuperGrid.ColumnGroupHeader columnGroupHeader2 = new DevComponents.DotNetBar.SuperGrid.ColumnGroupHeader();
            DevComponents.DotNetBar.SuperGrid.Style.Background background2 = new DevComponents.DotNetBar.SuperGrid.Style.Background();
            DevComponents.DotNetBar.SuperGrid.ColumnGroupHeader columnGroupHeader3 = new DevComponents.DotNetBar.SuperGrid.ColumnGroupHeader();
            DevComponents.DotNetBar.SuperGrid.Style.Background background3 = new DevComponents.DotNetBar.SuperGrid.Style.Background();
            this.bar1 = new DevComponents.DotNetBar.Bar();
            this.btnAgregar = new DevComponents.DotNetBar.ButtonItem();
            this.btnModificar = new DevComponents.DotNetBar.ButtonItem();
            this.btnActivar = new DevComponents.DotNetBar.ButtonItem();
            this.btnDesactivar = new DevComponents.DotNetBar.ButtonItem();
            this.btnReporte = new DevComponents.DotNetBar.ButtonItem();
            this.btnSalir = new DevComponents.DotNetBar.ButtonItem();
            this.sgcPreciosFamiliaComposicion = new DevComponents.DotNetBar.SuperGrid.SuperGridControl();
            this.id_precio = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.id_familia_composicion = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.id_familia_prenda = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.familia_prenda = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.familia_composicion = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.local_actual = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.foraneo_actual = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.linea_expres_local_actual = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.linea_expres_foraneo_actual = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.ecommerce_actual = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.local_anterior = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.foraneo_anterior = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.linea_expres_local_anterior = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.linea_expres_foraneo_anterior = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.ecommerce_anterior = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.muestrario = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.venta_interna = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.extra1 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.extra2 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.extra3 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.estatus = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.estatus_texto = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).BeginInit();
            this.SuspendLayout();
            // 
            // bar1
            // 
            this.bar1.AntiAlias = true;
            this.bar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.bar1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.bar1.IsMaximized = false;
            this.bar1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnAgregar,
            this.btnModificar,
            this.btnActivar,
            this.btnDesactivar,
            this.btnReporte,
            this.btnSalir});
            this.bar1.Location = new System.Drawing.Point(0, 0);
            this.bar1.Name = "bar1";
            this.bar1.Size = new System.Drawing.Size(1870, 33);
            this.bar1.Stretch = true;
            this.bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.bar1.TabIndex = 0;
            this.bar1.TabStop = false;
            this.bar1.Text = "bar1";
            // 
            // btnAgregar
            // 
            this.btnAgregar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnAgregar.Image = global::ALTIMA_ERP_2022.Properties.Resources.agregar;
            this.btnAgregar.ImageFixedSize = new System.Drawing.Size(24, 24);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnModificar.Image = global::ALTIMA_ERP_2022.Properties.Resources.editar;
            this.btnModificar.ImageFixedSize = new System.Drawing.Size(24, 24);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Text = "Modificar";
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnActivar
            // 
            this.btnActivar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnActivar.Image = global::ALTIMA_ERP_2022.Properties.Resources.activar;
            this.btnActivar.ImageFixedSize = new System.Drawing.Size(24, 24);
            this.btnActivar.Name = "btnActivar";
            this.btnActivar.Text = "Activar";
            this.btnActivar.Click += new System.EventHandler(this.btnActivar_Click);
            // 
            // btnDesactivar
            // 
            this.btnDesactivar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnDesactivar.Image = global::ALTIMA_ERP_2022.Properties.Resources.desactivar;
            this.btnDesactivar.ImageFixedSize = new System.Drawing.Size(24, 24);
            this.btnDesactivar.Name = "btnDesactivar";
            this.btnDesactivar.Text = "Desactivar";
            this.btnDesactivar.Click += new System.EventHandler(this.btnDesactivar_Click);
            // 
            // btnReporte
            // 
            this.btnReporte.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnReporte.Image = global::ALTIMA_ERP_2022.Properties.Resources.reporte;
            this.btnReporte.ImageFixedSize = new System.Drawing.Size(24, 24);
            this.btnReporte.Name = "btnReporte";
            this.btnReporte.Text = "Reporte";
            this.btnReporte.Click += new System.EventHandler(this.btnReporte_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnSalir.Image = global::ALTIMA_ERP_2022.Properties.Resources.salir;
            this.btnSalir.ImageFixedSize = new System.Drawing.Size(24, 24);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Text = "Salir";
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // sgcPreciosFamiliaComposicion
            // 
            this.sgcPreciosFamiliaComposicion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.sgcPreciosFamiliaComposicion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sgcPreciosFamiliaComposicion.FilterExprColors.SysFunction = System.Drawing.Color.DarkRed;
            this.sgcPreciosFamiliaComposicion.ForeColor = System.Drawing.Color.Black;
            this.sgcPreciosFamiliaComposicion.Location = new System.Drawing.Point(0, 33);
            this.sgcPreciosFamiliaComposicion.Name = "sgcPreciosFamiliaComposicion";
            // 
            // 
            // 
            this.sgcPreciosFamiliaComposicion.PrimaryGrid.AllowEdit = false;
            // 
            // 
            // 
            columnGroupHeader1.EndDisplayIndex = 9;
            background1.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            columnGroupHeader1.HeaderStyles.Default.Background = background1;
            columnGroupHeader1.HeaderStyles.Default.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            columnGroupHeader1.HeaderText = "Precios Locales";
            columnGroupHeader1.Name = "precios_locales";
            columnGroupHeader1.StartDisplayIndex = 5;
            columnGroupHeader2.EndDisplayIndex = 14;
            background2.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            columnGroupHeader2.HeaderStyles.Default.Background = background2;
            columnGroupHeader2.Name = "Precios Anteriores";
            columnGroupHeader2.StartDisplayIndex = 10;
            columnGroupHeader3.EndDisplayIndex = 19;
            background3.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            columnGroupHeader3.HeaderStyles.Default.Background = background3;
            columnGroupHeader3.HeaderText = "Otros Precios";
            columnGroupHeader3.Name = "OtrosPrecios";
            columnGroupHeader3.StartDisplayIndex = 15;
            this.sgcPreciosFamiliaComposicion.PrimaryGrid.ColumnHeader.GroupHeaders.Add(columnGroupHeader1);
            this.sgcPreciosFamiliaComposicion.PrimaryGrid.ColumnHeader.GroupHeaders.Add(columnGroupHeader2);
            this.sgcPreciosFamiliaComposicion.PrimaryGrid.ColumnHeader.GroupHeaders.Add(columnGroupHeader3);
            this.sgcPreciosFamiliaComposicion.PrimaryGrid.Columns.Add(this.id_precio);
            this.sgcPreciosFamiliaComposicion.PrimaryGrid.Columns.Add(this.id_familia_composicion);
            this.sgcPreciosFamiliaComposicion.PrimaryGrid.Columns.Add(this.id_familia_prenda);
            this.sgcPreciosFamiliaComposicion.PrimaryGrid.Columns.Add(this.familia_prenda);
            this.sgcPreciosFamiliaComposicion.PrimaryGrid.Columns.Add(this.familia_composicion);
            this.sgcPreciosFamiliaComposicion.PrimaryGrid.Columns.Add(this.local_actual);
            this.sgcPreciosFamiliaComposicion.PrimaryGrid.Columns.Add(this.foraneo_actual);
            this.sgcPreciosFamiliaComposicion.PrimaryGrid.Columns.Add(this.linea_expres_local_actual);
            this.sgcPreciosFamiliaComposicion.PrimaryGrid.Columns.Add(this.linea_expres_foraneo_actual);
            this.sgcPreciosFamiliaComposicion.PrimaryGrid.Columns.Add(this.ecommerce_actual);
            this.sgcPreciosFamiliaComposicion.PrimaryGrid.Columns.Add(this.local_anterior);
            this.sgcPreciosFamiliaComposicion.PrimaryGrid.Columns.Add(this.foraneo_anterior);
            this.sgcPreciosFamiliaComposicion.PrimaryGrid.Columns.Add(this.linea_expres_local_anterior);
            this.sgcPreciosFamiliaComposicion.PrimaryGrid.Columns.Add(this.linea_expres_foraneo_anterior);
            this.sgcPreciosFamiliaComposicion.PrimaryGrid.Columns.Add(this.ecommerce_anterior);
            this.sgcPreciosFamiliaComposicion.PrimaryGrid.Columns.Add(this.muestrario);
            this.sgcPreciosFamiliaComposicion.PrimaryGrid.Columns.Add(this.venta_interna);
            this.sgcPreciosFamiliaComposicion.PrimaryGrid.Columns.Add(this.extra1);
            this.sgcPreciosFamiliaComposicion.PrimaryGrid.Columns.Add(this.extra2);
            this.sgcPreciosFamiliaComposicion.PrimaryGrid.Columns.Add(this.extra3);
            this.sgcPreciosFamiliaComposicion.PrimaryGrid.Columns.Add(this.estatus);
            this.sgcPreciosFamiliaComposicion.PrimaryGrid.Columns.Add(this.estatus_texto);
            this.sgcPreciosFamiliaComposicion.PrimaryGrid.EnableColumnFiltering = true;
            this.sgcPreciosFamiliaComposicion.PrimaryGrid.EnableFiltering = true;
            this.sgcPreciosFamiliaComposicion.PrimaryGrid.EnableRowFiltering = true;
            // 
            // 
            // 
            this.sgcPreciosFamiliaComposicion.PrimaryGrid.Filter.RowHeight = 25;
            this.sgcPreciosFamiliaComposicion.PrimaryGrid.Filter.ShowPanelFilterExpr = true;
            this.sgcPreciosFamiliaComposicion.PrimaryGrid.Filter.Visible = true;
            this.sgcPreciosFamiliaComposicion.PrimaryGrid.FilterLevel = ((DevComponents.DotNetBar.SuperGrid.FilterLevel)((DevComponents.DotNetBar.SuperGrid.FilterLevel.Root | DevComponents.DotNetBar.SuperGrid.FilterLevel.Expanded)));
            this.sgcPreciosFamiliaComposicion.PrimaryGrid.FilterMatchType = DevComponents.DotNetBar.SuperGrid.FilterMatchType.RegularExpressions;
            this.sgcPreciosFamiliaComposicion.PrimaryGrid.MultiSelect = false;
            this.sgcPreciosFamiliaComposicion.PrimaryGrid.SelectionGranularity = DevComponents.DotNetBar.SuperGrid.SelectionGranularity.Row;
            this.sgcPreciosFamiliaComposicion.PrimaryGrid.UseAlternateColumnStyle = true;
            this.sgcPreciosFamiliaComposicion.PrimaryGrid.UseAlternateRowStyle = true;
            this.sgcPreciosFamiliaComposicion.Size = new System.Drawing.Size(1870, 679);
            this.sgcPreciosFamiliaComposicion.TabIndex = 1;
            this.sgcPreciosFamiliaComposicion.Text = "superGridControl1";
            this.sgcPreciosFamiliaComposicion.DataBindingComplete += new System.EventHandler<DevComponents.DotNetBar.SuperGrid.GridDataBindingCompleteEventArgs>(this.sgcPreciosFamiliaComposicion_DataBindingComplete);
            this.sgcPreciosFamiliaComposicion.SelectionChanged += new System.EventHandler<DevComponents.DotNetBar.SuperGrid.GridEventArgs>(this.sgcPreciosFamiliaComposicion_SelectionChanged);
            // 
            // id_precio
            // 
            this.id_precio.AllowEdit = false;
            this.id_precio.DataPropertyName = "id_precio";
            this.id_precio.EnableFiltering = DevComponents.DotNetBar.SuperGrid.Style.Tbool.True;
            this.id_precio.FilterAutoScan = true;
            this.id_precio.FilterEditType = DevComponents.DotNetBar.SuperGrid.FilterEditType.TextBox;
            this.id_precio.FilterMatchType = DevComponents.DotNetBar.SuperGrid.FilterMatchType.RegularExpressions;
            this.id_precio.HeaderText = "id_precio";
            this.id_precio.Name = "id_precio";
            this.id_precio.ShowPanelFilterExpr = DevComponents.DotNetBar.SuperGrid.Style.Tbool.True;
            this.id_precio.Visible = false;
            // 
            // id_familia_composicion
            // 
            this.id_familia_composicion.AllowEdit = false;
            this.id_familia_composicion.DataPropertyName = "id_familia_composicion";
            this.id_familia_composicion.EnableFiltering = DevComponents.DotNetBar.SuperGrid.Style.Tbool.True;
            this.id_familia_composicion.FilterAutoScan = true;
            this.id_familia_composicion.FilterEditType = DevComponents.DotNetBar.SuperGrid.FilterEditType.TextBox;
            this.id_familia_composicion.FilterMatchType = DevComponents.DotNetBar.SuperGrid.FilterMatchType.RegularExpressions;
            this.id_familia_composicion.HeaderText = "id_familia_composicion";
            this.id_familia_composicion.Name = "id_familia_composicion";
            this.id_familia_composicion.ShowPanelFilterExpr = DevComponents.DotNetBar.SuperGrid.Style.Tbool.True;
            this.id_familia_composicion.Visible = false;
            // 
            // id_familia_prenda
            // 
            this.id_familia_prenda.AllowEdit = false;
            this.id_familia_prenda.DataPropertyName = "id_familia_prenda";
            this.id_familia_prenda.EnableFiltering = DevComponents.DotNetBar.SuperGrid.Style.Tbool.True;
            this.id_familia_prenda.FilterAutoScan = true;
            this.id_familia_prenda.FilterEditType = DevComponents.DotNetBar.SuperGrid.FilterEditType.TextBox;
            this.id_familia_prenda.FilterMatchType = DevComponents.DotNetBar.SuperGrid.FilterMatchType.RegularExpressions;
            this.id_familia_prenda.HeaderText = "id_familia_prenda";
            this.id_familia_prenda.Name = "id_familia_prenda";
            this.id_familia_prenda.ShowPanelFilterExpr = DevComponents.DotNetBar.SuperGrid.Style.Tbool.True;
            this.id_familia_prenda.Visible = false;
            // 
            // familia_prenda
            // 
            this.familia_prenda.AllowEdit = false;
            this.familia_prenda.AutoSizeMode = DevComponents.DotNetBar.SuperGrid.ColumnAutoSizeMode.Fill;
            this.familia_prenda.DataPropertyName = "familia_prenda";
            this.familia_prenda.EnableFiltering = DevComponents.DotNetBar.SuperGrid.Style.Tbool.True;
            this.familia_prenda.FilterAutoScan = true;
            this.familia_prenda.FilterEditType = DevComponents.DotNetBar.SuperGrid.FilterEditType.TextBox;
            this.familia_prenda.FilterMatchType = DevComponents.DotNetBar.SuperGrid.FilterMatchType.RegularExpressions;
            this.familia_prenda.HeaderText = "Familia Prenda";
            this.familia_prenda.Name = "familia_prenda";
            this.familia_prenda.ShowPanelFilterExpr = DevComponents.DotNetBar.SuperGrid.Style.Tbool.True;
            // 
            // familia_composicion
            // 
            this.familia_composicion.AllowEdit = false;
            this.familia_composicion.AutoSizeMode = DevComponents.DotNetBar.SuperGrid.ColumnAutoSizeMode.DisplayedCells;
            this.familia_composicion.DataPropertyName = "familia_composicion";
            this.familia_composicion.EnableFiltering = DevComponents.DotNetBar.SuperGrid.Style.Tbool.True;
            this.familia_composicion.FilterAutoScan = true;
            this.familia_composicion.FilterEditType = DevComponents.DotNetBar.SuperGrid.FilterEditType.TextBox;
            this.familia_composicion.FilterMatchType = DevComponents.DotNetBar.SuperGrid.FilterMatchType.RegularExpressions;
            this.familia_composicion.HeaderText = "Famila composición";
            this.familia_composicion.Name = "familia_composicion";
            this.familia_composicion.ShowPanelFilterExpr = DevComponents.DotNetBar.SuperGrid.Style.Tbool.True;
            // 
            // local_actual
            // 
            this.local_actual.AllowEdit = false;
            this.local_actual.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleRight;
            this.local_actual.DataPropertyName = "local_actual";
            this.local_actual.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridMaskedTextBoxEditControl);
            this.local_actual.EnableFiltering = DevComponents.DotNetBar.SuperGrid.Style.Tbool.True;
            this.local_actual.FilterAutoScan = true;
            this.local_actual.FilterEditType = DevComponents.DotNetBar.SuperGrid.FilterEditType.TextBox;
            this.local_actual.FilterMatchType = DevComponents.DotNetBar.SuperGrid.FilterMatchType.RegularExpressions;
            this.local_actual.HeaderText = "Local";
            this.local_actual.Name = "local_actual";
            this.local_actual.RenderType = typeof(DevComponents.DotNetBar.SuperGrid.GridMaskedTextBoxEditControl);
            this.local_actual.ShowPanelFilterExpr = DevComponents.DotNetBar.SuperGrid.Style.Tbool.True;
            // 
            // foraneo_actual
            // 
            this.foraneo_actual.AllowEdit = false;
            this.foraneo_actual.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleRight;
            this.foraneo_actual.DataPropertyName = "foraneo_actual";
            this.foraneo_actual.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridMaskedTextBoxEditControl);
            this.foraneo_actual.EnableFiltering = DevComponents.DotNetBar.SuperGrid.Style.Tbool.True;
            this.foraneo_actual.FilterAutoScan = true;
            this.foraneo_actual.FilterEditType = DevComponents.DotNetBar.SuperGrid.FilterEditType.TextBox;
            this.foraneo_actual.FilterMatchType = DevComponents.DotNetBar.SuperGrid.FilterMatchType.RegularExpressions;
            this.foraneo_actual.HeaderText = "Foraneo";
            this.foraneo_actual.Name = "foraneo_actual";
            this.foraneo_actual.RenderType = typeof(DevComponents.DotNetBar.SuperGrid.GridMaskedTextBoxEditControl);
            this.foraneo_actual.ShowPanelFilterExpr = DevComponents.DotNetBar.SuperGrid.Style.Tbool.True;
            // 
            // linea_expres_local_actual
            // 
            this.linea_expres_local_actual.AllowEdit = false;
            this.linea_expres_local_actual.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleRight;
            this.linea_expres_local_actual.DataPropertyName = "linea_expres_local_actual";
            this.linea_expres_local_actual.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridMaskedTextBoxEditControl);
            this.linea_expres_local_actual.EnableFiltering = DevComponents.DotNetBar.SuperGrid.Style.Tbool.True;
            this.linea_expres_local_actual.FilterAutoScan = true;
            this.linea_expres_local_actual.FilterEditType = DevComponents.DotNetBar.SuperGrid.FilterEditType.TextBox;
            this.linea_expres_local_actual.FilterMatchType = DevComponents.DotNetBar.SuperGrid.FilterMatchType.RegularExpressions;
            this.linea_expres_local_actual.HeaderText = "LE Local";
            this.linea_expres_local_actual.Name = "linea_expres_local_actual";
            this.linea_expres_local_actual.RenderType = typeof(DevComponents.DotNetBar.SuperGrid.GridMaskedTextBoxEditControl);
            this.linea_expres_local_actual.ShowPanelFilterExpr = DevComponents.DotNetBar.SuperGrid.Style.Tbool.True;
            // 
            // linea_expres_foraneo_actual
            // 
            this.linea_expres_foraneo_actual.AllowEdit = false;
            this.linea_expres_foraneo_actual.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleRight;
            this.linea_expres_foraneo_actual.DataPropertyName = "linea_expres_foraneo_actual";
            this.linea_expres_foraneo_actual.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridMaskedTextBoxEditControl);
            this.linea_expres_foraneo_actual.EnableFiltering = DevComponents.DotNetBar.SuperGrid.Style.Tbool.True;
            this.linea_expres_foraneo_actual.FilterAutoScan = true;
            this.linea_expres_foraneo_actual.FilterEditType = DevComponents.DotNetBar.SuperGrid.FilterEditType.TextBox;
            this.linea_expres_foraneo_actual.FilterMatchType = DevComponents.DotNetBar.SuperGrid.FilterMatchType.RegularExpressions;
            this.linea_expres_foraneo_actual.HeaderText = "LE Foraneo";
            this.linea_expres_foraneo_actual.Name = "linea_expres_foraneo_actual";
            this.linea_expres_foraneo_actual.RenderType = typeof(DevComponents.DotNetBar.SuperGrid.GridMaskedTextBoxEditControl);
            this.linea_expres_foraneo_actual.ShowPanelFilterExpr = DevComponents.DotNetBar.SuperGrid.Style.Tbool.True;
            // 
            // ecommerce_actual
            // 
            this.ecommerce_actual.AllowEdit = false;
            this.ecommerce_actual.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleRight;
            this.ecommerce_actual.DataPropertyName = "ecommerce_actual";
            this.ecommerce_actual.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridMaskedTextBoxEditControl);
            this.ecommerce_actual.EnableFiltering = DevComponents.DotNetBar.SuperGrid.Style.Tbool.True;
            this.ecommerce_actual.FilterAutoScan = true;
            this.ecommerce_actual.FilterEditType = DevComponents.DotNetBar.SuperGrid.FilterEditType.TextBox;
            this.ecommerce_actual.FilterMatchType = DevComponents.DotNetBar.SuperGrid.FilterMatchType.RegularExpressions;
            this.ecommerce_actual.HeaderText = "Ecommerce";
            this.ecommerce_actual.Name = "ecommerce_actual";
            this.ecommerce_actual.RenderType = typeof(DevComponents.DotNetBar.SuperGrid.GridMaskedTextBoxEditControl);
            this.ecommerce_actual.ShowPanelFilterExpr = DevComponents.DotNetBar.SuperGrid.Style.Tbool.True;
            // 
            // local_anterior
            // 
            this.local_anterior.AllowEdit = false;
            this.local_anterior.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleRight;
            this.local_anterior.DataPropertyName = "local_anterior";
            this.local_anterior.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridMaskedTextBoxEditControl);
            this.local_anterior.EnableFiltering = DevComponents.DotNetBar.SuperGrid.Style.Tbool.True;
            this.local_anterior.FilterAutoScan = true;
            this.local_anterior.FilterEditType = DevComponents.DotNetBar.SuperGrid.FilterEditType.TextBox;
            this.local_anterior.FilterMatchType = DevComponents.DotNetBar.SuperGrid.FilterMatchType.RegularExpressions;
            this.local_anterior.HeaderText = "Local Anterior";
            this.local_anterior.Name = "local_anterior";
            this.local_anterior.RenderType = typeof(DevComponents.DotNetBar.SuperGrid.GridMaskedTextBoxEditControl);
            this.local_anterior.ShowPanelFilterExpr = DevComponents.DotNetBar.SuperGrid.Style.Tbool.True;
            // 
            // foraneo_anterior
            // 
            this.foraneo_anterior.AllowEdit = false;
            this.foraneo_anterior.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleRight;
            this.foraneo_anterior.DataPropertyName = "foraneo_anterior";
            this.foraneo_anterior.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridMaskedTextBoxEditControl);
            this.foraneo_anterior.EnableFiltering = DevComponents.DotNetBar.SuperGrid.Style.Tbool.True;
            this.foraneo_anterior.FilterAutoScan = true;
            this.foraneo_anterior.FilterEditType = DevComponents.DotNetBar.SuperGrid.FilterEditType.TextBox;
            this.foraneo_anterior.FilterMatchType = DevComponents.DotNetBar.SuperGrid.FilterMatchType.RegularExpressions;
            this.foraneo_anterior.HeaderText = "Foraneo Anterior";
            this.foraneo_anterior.Name = "foraneo_anterior";
            this.foraneo_anterior.RenderType = typeof(DevComponents.DotNetBar.SuperGrid.GridMaskedTextBoxEditControl);
            this.foraneo_anterior.ShowPanelFilterExpr = DevComponents.DotNetBar.SuperGrid.Style.Tbool.True;
            // 
            // linea_expres_local_anterior
            // 
            this.linea_expres_local_anterior.AllowEdit = false;
            this.linea_expres_local_anterior.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleRight;
            this.linea_expres_local_anterior.DataPropertyName = "linea_expres_local_anterior";
            this.linea_expres_local_anterior.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridMaskedTextBoxEditControl);
            this.linea_expres_local_anterior.EnableFiltering = DevComponents.DotNetBar.SuperGrid.Style.Tbool.True;
            this.linea_expres_local_anterior.FilterAutoScan = true;
            this.linea_expres_local_anterior.FilterEditType = DevComponents.DotNetBar.SuperGrid.FilterEditType.TextBox;
            this.linea_expres_local_anterior.FilterMatchType = DevComponents.DotNetBar.SuperGrid.FilterMatchType.RegularExpressions;
            this.linea_expres_local_anterior.HeaderText = "LE Local Anterior";
            this.linea_expres_local_anterior.Name = "linea_expres_local_anterior";
            this.linea_expres_local_anterior.RenderType = typeof(DevComponents.DotNetBar.SuperGrid.GridMaskedTextBoxEditControl);
            this.linea_expres_local_anterior.ShowPanelFilterExpr = DevComponents.DotNetBar.SuperGrid.Style.Tbool.True;
            // 
            // linea_expres_foraneo_anterior
            // 
            this.linea_expres_foraneo_anterior.AllowEdit = false;
            this.linea_expres_foraneo_anterior.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleRight;
            this.linea_expres_foraneo_anterior.DataPropertyName = "linea_expres_foraneo_anterior";
            this.linea_expres_foraneo_anterior.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridMaskedTextBoxEditControl);
            this.linea_expres_foraneo_anterior.EnableFiltering = DevComponents.DotNetBar.SuperGrid.Style.Tbool.True;
            this.linea_expres_foraneo_anterior.FilterAutoScan = true;
            this.linea_expres_foraneo_anterior.FilterEditType = DevComponents.DotNetBar.SuperGrid.FilterEditType.TextBox;
            this.linea_expres_foraneo_anterior.FilterMatchType = DevComponents.DotNetBar.SuperGrid.FilterMatchType.RegularExpressions;
            this.linea_expres_foraneo_anterior.HeaderText = "LE Foraneo Anterior";
            this.linea_expres_foraneo_anterior.Name = "linea_expres_foraneo_anterior";
            this.linea_expres_foraneo_anterior.RenderType = typeof(DevComponents.DotNetBar.SuperGrid.GridMaskedTextBoxEditControl);
            this.linea_expres_foraneo_anterior.ShowPanelFilterExpr = DevComponents.DotNetBar.SuperGrid.Style.Tbool.True;
            // 
            // ecommerce_anterior
            // 
            this.ecommerce_anterior.AllowEdit = false;
            this.ecommerce_anterior.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleRight;
            this.ecommerce_anterior.DataPropertyName = "ecommerce_anterior";
            this.ecommerce_anterior.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridMaskedTextBoxEditControl);
            this.ecommerce_anterior.EnableFiltering = DevComponents.DotNetBar.SuperGrid.Style.Tbool.True;
            this.ecommerce_anterior.FilterAutoScan = true;
            this.ecommerce_anterior.FilterEditType = DevComponents.DotNetBar.SuperGrid.FilterEditType.TextBox;
            this.ecommerce_anterior.FilterMatchType = DevComponents.DotNetBar.SuperGrid.FilterMatchType.RegularExpressions;
            this.ecommerce_anterior.HeaderText = "Ecommerce";
            this.ecommerce_anterior.Name = "ecommerce_anterior";
            this.ecommerce_anterior.RenderType = typeof(DevComponents.DotNetBar.SuperGrid.GridMaskedTextBoxEditControl);
            this.ecommerce_anterior.ShowPanelFilterExpr = DevComponents.DotNetBar.SuperGrid.Style.Tbool.True;
            // 
            // muestrario
            // 
            this.muestrario.AllowEdit = false;
            this.muestrario.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleRight;
            this.muestrario.DataPropertyName = "muestrario";
            this.muestrario.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridMaskedTextBoxEditControl);
            this.muestrario.EnableFiltering = DevComponents.DotNetBar.SuperGrid.Style.Tbool.True;
            this.muestrario.FilterAutoScan = true;
            this.muestrario.FilterEditType = DevComponents.DotNetBar.SuperGrid.FilterEditType.TextBox;
            this.muestrario.FilterMatchType = DevComponents.DotNetBar.SuperGrid.FilterMatchType.RegularExpressions;
            this.muestrario.HeaderText = "Muestraio";
            this.muestrario.Name = "muestrario";
            this.muestrario.RenderType = typeof(DevComponents.DotNetBar.SuperGrid.GridMaskedTextBoxEditControl);
            this.muestrario.ShowPanelFilterExpr = DevComponents.DotNetBar.SuperGrid.Style.Tbool.True;
            // 
            // venta_interna
            // 
            this.venta_interna.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleRight;
            this.venta_interna.DataPropertyName = "venta_interna";
            this.venta_interna.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridMaskedTextBoxEditControl);
            this.venta_interna.EnableFiltering = DevComponents.DotNetBar.SuperGrid.Style.Tbool.True;
            this.venta_interna.FilterAutoScan = true;
            this.venta_interna.FilterEditType = DevComponents.DotNetBar.SuperGrid.FilterEditType.TextBox;
            this.venta_interna.FilterMatchType = DevComponents.DotNetBar.SuperGrid.FilterMatchType.RegularExpressions;
            this.venta_interna.HeaderText = "Venta Interna";
            this.venta_interna.Name = "venta_interna";
            this.venta_interna.RenderType = typeof(DevComponents.DotNetBar.SuperGrid.GridMaskedTextBoxEditControl);
            this.venta_interna.ShowPanelFilterExpr = DevComponents.DotNetBar.SuperGrid.Style.Tbool.True;
            // 
            // extra1
            // 
            this.extra1.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleRight;
            this.extra1.DataPropertyName = "extra1";
            this.extra1.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridMaskedTextBoxEditControl);
            this.extra1.EnableFiltering = DevComponents.DotNetBar.SuperGrid.Style.Tbool.True;
            this.extra1.FilterAutoScan = true;
            this.extra1.FilterEditType = DevComponents.DotNetBar.SuperGrid.FilterEditType.TextBox;
            this.extra1.FilterMatchType = DevComponents.DotNetBar.SuperGrid.FilterMatchType.RegularExpressions;
            this.extra1.HeaderText = "Extra 1";
            this.extra1.Name = "extra1";
            this.extra1.RenderType = typeof(DevComponents.DotNetBar.SuperGrid.GridMaskedTextBoxEditControl);
            this.extra1.ShowPanelFilterExpr = DevComponents.DotNetBar.SuperGrid.Style.Tbool.True;
            // 
            // extra2
            // 
            this.extra2.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleRight;
            this.extra2.DataPropertyName = "extra2";
            this.extra2.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridMaskedTextBoxEditControl);
            this.extra2.EnableFiltering = DevComponents.DotNetBar.SuperGrid.Style.Tbool.True;
            this.extra2.FilterAutoScan = true;
            this.extra2.FilterEditType = DevComponents.DotNetBar.SuperGrid.FilterEditType.TextBox;
            this.extra2.FilterMatchType = DevComponents.DotNetBar.SuperGrid.FilterMatchType.RegularExpressions;
            this.extra2.HeaderText = "Extra 2";
            this.extra2.Name = "extra2";
            this.extra2.RenderType = typeof(DevComponents.DotNetBar.SuperGrid.GridMaskedTextBoxEditControl);
            this.extra2.ShowPanelFilterExpr = DevComponents.DotNetBar.SuperGrid.Style.Tbool.True;
            // 
            // extra3
            // 
            this.extra3.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleRight;
            this.extra3.DataPropertyName = "extra3";
            this.extra3.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridMaskedTextBoxEditControl);
            this.extra3.EnableFiltering = DevComponents.DotNetBar.SuperGrid.Style.Tbool.True;
            this.extra3.FilterAutoScan = true;
            this.extra3.FilterEditType = DevComponents.DotNetBar.SuperGrid.FilterEditType.TextBox;
            this.extra3.FilterMatchType = DevComponents.DotNetBar.SuperGrid.FilterMatchType.RegularExpressions;
            this.extra3.HeaderText = "Extra 3";
            this.extra3.Name = "extra3";
            this.extra3.RenderType = typeof(DevComponents.DotNetBar.SuperGrid.GridMaskedTextBoxEditControl);
            this.extra3.ShowPanelFilterExpr = DevComponents.DotNetBar.SuperGrid.Style.Tbool.True;
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
            this.estatus_texto.DataPropertyName = "estatus_texto";
            this.estatus_texto.HeaderText = "Estatus";
            this.estatus_texto.Name = "estatus_texto";
            // 
            // CatalogoPreciosFamiliaComposicion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1870, 712);
            this.Controls.Add(this.sgcPreciosFamiliaComposicion);
            this.Controls.Add(this.bar1);
            this.DoubleBuffered = true;
            this.MinimizeBox = false;
            this.Name = "CatalogoPreciosFamiliaComposicion";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Catálogo de precios";
            this.Load += new System.EventHandler(this.CatalogoPreciosFamiliaComposicion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Bar bar1;
        private DevComponents.DotNetBar.ButtonItem btnAgregar;
        private DevComponents.DotNetBar.ButtonItem btnModificar;
        private DevComponents.DotNetBar.ButtonItem btnActivar;
        private DevComponents.DotNetBar.ButtonItem btnDesactivar;
        private DevComponents.DotNetBar.ButtonItem btnReporte;
        private DevComponents.DotNetBar.ButtonItem btnSalir;
        private DevComponents.DotNetBar.SuperGrid.SuperGridControl sgcPreciosFamiliaComposicion;
        private DevComponents.DotNetBar.SuperGrid.GridColumn id_precio;
        private DevComponents.DotNetBar.SuperGrid.GridColumn id_familia_composicion;
        private DevComponents.DotNetBar.SuperGrid.GridColumn id_familia_prenda;
        private DevComponents.DotNetBar.SuperGrid.GridColumn familia_composicion;
        private DevComponents.DotNetBar.SuperGrid.GridColumn familia_prenda;
        private DevComponents.DotNetBar.SuperGrid.GridColumn local_actual;
        private DevComponents.DotNetBar.SuperGrid.GridColumn local_anterior;
        private DevComponents.DotNetBar.SuperGrid.GridColumn foraneo_actual;
        private DevComponents.DotNetBar.SuperGrid.GridColumn foraneo_anterior;
        private DevComponents.DotNetBar.SuperGrid.GridColumn linea_expres_local_actual;
        private DevComponents.DotNetBar.SuperGrid.GridColumn linea_expres_foraneo_anterior;
        private DevComponents.DotNetBar.SuperGrid.GridColumn linea_expres_local_anterior;
        private DevComponents.DotNetBar.SuperGrid.GridColumn linea_expres_foraneo_actual;
        private DevComponents.DotNetBar.SuperGrid.GridColumn muestrario;
        private DevComponents.DotNetBar.SuperGrid.GridColumn ecommerce_actual;
        private DevComponents.DotNetBar.SuperGrid.GridColumn venta_interna;
        private DevComponents.DotNetBar.SuperGrid.GridColumn extra1;
        private DevComponents.DotNetBar.SuperGrid.GridColumn extra2;
        private DevComponents.DotNetBar.SuperGrid.GridColumn extra3;
        private DevComponents.DotNetBar.SuperGrid.GridColumn estatus;
        private DevComponents.DotNetBar.SuperGrid.GridColumn estatus_texto;
        private DevComponents.DotNetBar.SuperGrid.GridColumn ecommerce_anterior;
    }
}