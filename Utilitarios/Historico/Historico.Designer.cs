
namespace ALTIMA_ERP_2022.Utilitarios.Historico
{
    partial class Historico
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
            this.sgcHistorico = new DevComponents.DotNetBar.SuperGrid.SuperGridControl();
            this.Fecha = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.Computadora = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.usuario = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.departamento = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.modulo = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.operacion = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.valor_anterior = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.valor_nuevo = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.observaciones = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.id_usuario = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.id_historico = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.panelMenu = new DevComponents.DotNetBar.PanelEx();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.dtiFechaFinal = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.dtiFechaInicial = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.btnSalir = new DevComponents.DotNetBar.ButtonX();
            this.btnReporte = new DevComponents.DotNetBar.ButtonX();
            this.btnImportar = new DevComponents.DotNetBar.ButtonX();
            this.panelMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtiFechaFinal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtiFechaInicial)).BeginInit();
            this.SuspendLayout();
            // 
            // sgcHistorico
            // 
            this.sgcHistorico.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.sgcHistorico.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sgcHistorico.FilterExprColors.SysFunction = System.Drawing.Color.DarkRed;
            this.sgcHistorico.ForeColor = System.Drawing.Color.Black;
            this.sgcHistorico.Location = new System.Drawing.Point(0, 71);
            this.sgcHistorico.Name = "sgcHistorico";
            // 
            // 
            // 
            this.sgcHistorico.PrimaryGrid.AllowEdit = false;
            this.sgcHistorico.PrimaryGrid.AllowRowHeaderResize = true;
            this.sgcHistorico.PrimaryGrid.AllowRowResize = true;
            this.sgcHistorico.PrimaryGrid.AutoGenerateColumns = false;
            this.sgcHistorico.PrimaryGrid.Columns.Add(this.Fecha);
            this.sgcHistorico.PrimaryGrid.Columns.Add(this.Computadora);
            this.sgcHistorico.PrimaryGrid.Columns.Add(this.usuario);
            this.sgcHistorico.PrimaryGrid.Columns.Add(this.departamento);
            this.sgcHistorico.PrimaryGrid.Columns.Add(this.modulo);
            this.sgcHistorico.PrimaryGrid.Columns.Add(this.operacion);
            this.sgcHistorico.PrimaryGrid.Columns.Add(this.valor_anterior);
            this.sgcHistorico.PrimaryGrid.Columns.Add(this.valor_nuevo);
            this.sgcHistorico.PrimaryGrid.Columns.Add(this.observaciones);
            this.sgcHistorico.PrimaryGrid.Columns.Add(this.id_usuario);
            this.sgcHistorico.PrimaryGrid.Columns.Add(this.id_historico);
            this.sgcHistorico.PrimaryGrid.EnableColumnFiltering = true;
            this.sgcHistorico.PrimaryGrid.EnableFiltering = true;
            this.sgcHistorico.PrimaryGrid.EnableRowFiltering = true;
            // 
            // 
            // 
            this.sgcHistorico.PrimaryGrid.Filter.RowHeight = 30;
            this.sgcHistorico.PrimaryGrid.Filter.Visible = true;
            this.sgcHistorico.PrimaryGrid.FilterMatchType = DevComponents.DotNetBar.SuperGrid.FilterMatchType.RegularExpressions;
            // 
            // 
            // 
            this.sgcHistorico.PrimaryGrid.Footer.RowHeight = 30;
            this.sgcHistorico.PrimaryGrid.MultiSelect = false;
            this.sgcHistorico.PrimaryGrid.UseAlternateColumnStyle = true;
            this.sgcHistorico.PrimaryGrid.UseAlternateRowStyle = true;
            this.sgcHistorico.Size = new System.Drawing.Size(1334, 576);
            this.sgcHistorico.TabIndex = 1;
            this.sgcHistorico.Text = "superGridControl1";
            this.sgcHistorico.DataBindingComplete += new System.EventHandler<DevComponents.DotNetBar.SuperGrid.GridDataBindingCompleteEventArgs>(this.sgcHistorico_DataBindingComplete);
            this.sgcHistorico.DataFilteringComplete += new System.EventHandler<DevComponents.DotNetBar.SuperGrid.GridDataFilteringCompleteEventArgs>(this.sgcHistorico_DataFilteringComplete);
            // 
            // Fecha
            // 
            this.Fecha.AutoSizeMode = DevComponents.DotNetBar.SuperGrid.ColumnAutoSizeMode.DisplayedCells;
            this.Fecha.DataPropertyName = "Fecha";
            this.Fecha.HeaderText = "Fecha";
            this.Fecha.Name = "Fecha";
            // 
            // Computadora
            // 
            this.Computadora.AutoSizeMode = DevComponents.DotNetBar.SuperGrid.ColumnAutoSizeMode.DisplayedCells;
            this.Computadora.DataPropertyName = "Computadora";
            this.Computadora.HeaderText = "Computadora";
            this.Computadora.Name = "Computadora";
            // 
            // usuario
            // 
            this.usuario.AutoSizeMode = DevComponents.DotNetBar.SuperGrid.ColumnAutoSizeMode.DisplayedCells;
            this.usuario.DataPropertyName = "usuario";
            this.usuario.HeaderText = "Usuario";
            this.usuario.Name = "usuario";
            // 
            // departamento
            // 
            this.departamento.AutoSizeMode = DevComponents.DotNetBar.SuperGrid.ColumnAutoSizeMode.DisplayedCells;
            this.departamento.DataPropertyName = "departamento";
            this.departamento.HeaderText = "Departamento";
            this.departamento.Name = "departamento";
            // 
            // modulo
            // 
            this.modulo.AutoSizeMode = DevComponents.DotNetBar.SuperGrid.ColumnAutoSizeMode.DisplayedCells;
            this.modulo.DataPropertyName = "modulo";
            this.modulo.HeaderText = "Módulo";
            this.modulo.Name = "modulo";
            // 
            // operacion
            // 
            this.operacion.AutoSizeMode = DevComponents.DotNetBar.SuperGrid.ColumnAutoSizeMode.DisplayedCells;
            this.operacion.DataPropertyName = "operacion";
            this.operacion.HeaderText = "Operación";
            this.operacion.Name = "operacion";
            // 
            // valor_anterior
            // 
            this.valor_anterior.AutoSizeMode = DevComponents.DotNetBar.SuperGrid.ColumnAutoSizeMode.Fill;
            this.valor_anterior.CellStyles.Default.AllowWrap = DevComponents.DotNetBar.SuperGrid.Style.Tbool.True;
            this.valor_anterior.DataPropertyName = "valor_anterior";
            this.valor_anterior.HeaderText = "Valor anterior";
            this.valor_anterior.MinimumWidth = 250;
            this.valor_anterior.Name = "valor_anterior";
            this.valor_anterior.Width = 250;
            // 
            // valor_nuevo
            // 
            this.valor_nuevo.AutoSizeMode = DevComponents.DotNetBar.SuperGrid.ColumnAutoSizeMode.Fill;
            this.valor_nuevo.CellStyles.Default.AllowWrap = DevComponents.DotNetBar.SuperGrid.Style.Tbool.True;
            this.valor_nuevo.DataPropertyName = "valor_nuevo";
            this.valor_nuevo.HeaderText = "Valor nuevo";
            this.valor_nuevo.MinimumWidth = 250;
            this.valor_nuevo.Name = "valor_nuevo";
            this.valor_nuevo.Width = 250;
            // 
            // observaciones
            // 
            this.observaciones.AutoSizeMode = DevComponents.DotNetBar.SuperGrid.ColumnAutoSizeMode.Fill;
            this.observaciones.DataPropertyName = "observaciones";
            this.observaciones.HeaderText = "Observaciones";
            this.observaciones.MinimumWidth = 100;
            this.observaciones.Name = "observaciones";
            // 
            // id_usuario
            // 
            this.id_usuario.DataPropertyName = "id_usuario";
            this.id_usuario.HeaderText = "id_usuario";
            this.id_usuario.Name = "id_usuario";
            this.id_usuario.Visible = false;
            // 
            // id_historico
            // 
            this.id_historico.DataPropertyName = "id_historico";
            this.id_historico.HeaderText = "id_historico";
            this.id_historico.Name = "id_historico";
            this.id_historico.Visible = false;
            // 
            // panelMenu
            // 
            this.panelMenu.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelMenu.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelMenu.Controls.Add(this.labelX2);
            this.panelMenu.Controls.Add(this.labelX1);
            this.panelMenu.Controls.Add(this.dtiFechaFinal);
            this.panelMenu.Controls.Add(this.dtiFechaInicial);
            this.panelMenu.Controls.Add(this.btnSalir);
            this.panelMenu.Controls.Add(this.btnReporte);
            this.panelMenu.Controls.Add(this.btnImportar);
            this.panelMenu.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(1334, 71);
            this.panelMenu.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelMenu.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelMenu.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelMenu.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelMenu.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelMenu.Style.GradientAngle = 90;
            this.panelMenu.TabIndex = 0;
            // 
            // labelX2
            // 
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(7, 35);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(75, 23);
            this.labelX2.TabIndex = 6;
            this.labelX2.Text = "Fecha final";
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(7, 9);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(75, 23);
            this.labelX1.TabIndex = 5;
            this.labelX1.Text = "Fecha inicial";
            // 
            // dtiFechaFinal
            // 
            // 
            // 
            // 
            this.dtiFechaFinal.BackgroundStyle.Class = "DateTimeInputBackground";
            this.dtiFechaFinal.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtiFechaFinal.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.dtiFechaFinal.ButtonDropDown.Visible = true;
            this.dtiFechaFinal.IsPopupCalendarOpen = false;
            this.dtiFechaFinal.Location = new System.Drawing.Point(88, 38);
            // 
            // 
            // 
            // 
            // 
            // 
            this.dtiFechaFinal.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtiFechaFinal.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            this.dtiFechaFinal.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.dtiFechaFinal.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.dtiFechaFinal.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.dtiFechaFinal.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.dtiFechaFinal.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.dtiFechaFinal.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.dtiFechaFinal.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.dtiFechaFinal.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtiFechaFinal.MonthCalendar.DisplayMonth = new System.DateTime(2022, 2, 1, 0, 0, 0, 0);
            // 
            // 
            // 
            this.dtiFechaFinal.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.dtiFechaFinal.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.dtiFechaFinal.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.dtiFechaFinal.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtiFechaFinal.MonthCalendar.TodayButtonVisible = true;
            this.dtiFechaFinal.Name = "dtiFechaFinal";
            this.dtiFechaFinal.Size = new System.Drawing.Size(132, 20);
            this.dtiFechaFinal.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.dtiFechaFinal.TabIndex = 1;
            // 
            // dtiFechaInicial
            // 
            // 
            // 
            // 
            this.dtiFechaInicial.BackgroundStyle.Class = "DateTimeInputBackground";
            this.dtiFechaInicial.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtiFechaInicial.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.dtiFechaInicial.ButtonDropDown.Visible = true;
            this.dtiFechaInicial.IsPopupCalendarOpen = false;
            this.dtiFechaInicial.Location = new System.Drawing.Point(88, 12);
            // 
            // 
            // 
            // 
            // 
            // 
            this.dtiFechaInicial.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtiFechaInicial.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            this.dtiFechaInicial.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.dtiFechaInicial.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.dtiFechaInicial.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.dtiFechaInicial.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.dtiFechaInicial.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.dtiFechaInicial.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.dtiFechaInicial.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.dtiFechaInicial.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtiFechaInicial.MonthCalendar.DisplayMonth = new System.DateTime(2022, 2, 1, 0, 0, 0, 0);
            // 
            // 
            // 
            this.dtiFechaInicial.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.dtiFechaInicial.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.dtiFechaInicial.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.dtiFechaInicial.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtiFechaInicial.MonthCalendar.TodayButtonVisible = true;
            this.dtiFechaInicial.Name = "dtiFechaInicial";
            this.dtiFechaInicial.Size = new System.Drawing.Size(132, 20);
            this.dtiFechaInicial.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.dtiFechaInicial.TabIndex = 0;
            // 
            // btnSalir
            // 
            this.btnSalir.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSalir.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSalir.Image = global::ALTIMA_ERP_2022.Properties.Resources.salir;
            this.btnSalir.ImageFixedSize = new System.Drawing.Size(24, 24);
            this.btnSalir.Location = new System.Drawing.Point(418, 12);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(90, 35);
            this.btnSalir.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnSalir.TabIndex = 4;
            this.btnSalir.Text = "Salir";
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnReporte
            // 
            this.btnReporte.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnReporte.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnReporte.Image = global::ALTIMA_ERP_2022.Properties.Resources.reporte;
            this.btnReporte.ImageFixedSize = new System.Drawing.Size(24, 24);
            this.btnReporte.Location = new System.Drawing.Point(322, 12);
            this.btnReporte.Name = "btnReporte";
            this.btnReporte.Size = new System.Drawing.Size(90, 35);
            this.btnReporte.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnReporte.TabIndex = 3;
            this.btnReporte.Text = "Reporte";
            this.btnReporte.Click += new System.EventHandler(this.btnReporte_Click);
            // 
            // btnImportar
            // 
            this.btnImportar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnImportar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnImportar.Image = global::ALTIMA_ERP_2022.Properties.Resources.importar;
            this.btnImportar.ImageFixedSize = new System.Drawing.Size(24, 24);
            this.btnImportar.Location = new System.Drawing.Point(226, 12);
            this.btnImportar.Name = "btnImportar";
            this.btnImportar.Size = new System.Drawing.Size(90, 35);
            this.btnImportar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnImportar.TabIndex = 2;
            this.btnImportar.Text = "Importar";
            this.btnImportar.Click += new System.EventHandler(this.btnImportar_Click);
            // 
            // Historico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1334, 647);
            this.Controls.Add(this.sgcHistorico);
            this.Controls.Add(this.panelMenu);
            this.DoubleBuffered = true;
            this.KeyPreview = true;
            this.Name = "Historico";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Historico";
            this.Load += new System.EventHandler(this.Historico_Load);
            this.panelMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtiFechaFinal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtiFechaInicial)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevComponents.DotNetBar.SuperGrid.SuperGridControl sgcHistorico;
        private DevComponents.DotNetBar.SuperGrid.GridColumn Fecha;
        private DevComponents.DotNetBar.SuperGrid.GridColumn Computadora;
        private DevComponents.DotNetBar.SuperGrid.GridColumn departamento;
        private DevComponents.DotNetBar.SuperGrid.GridColumn modulo;
        private DevComponents.DotNetBar.SuperGrid.GridColumn operacion;
        private DevComponents.DotNetBar.SuperGrid.GridColumn valor_anterior;
        private DevComponents.DotNetBar.SuperGrid.GridColumn valor_nuevo;
        private DevComponents.DotNetBar.SuperGrid.GridColumn observaciones;
        private DevComponents.DotNetBar.PanelEx panelMenu;
        private DevComponents.DotNetBar.ButtonX btnImportar;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dtiFechaFinal;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dtiFechaInicial;
        private DevComponents.DotNetBar.ButtonX btnSalir;
        private DevComponents.DotNetBar.ButtonX btnReporte;
        private DevComponents.DotNetBar.SuperGrid.GridColumn usuario;
        private DevComponents.DotNetBar.SuperGrid.GridColumn id_usuario;
        private DevComponents.DotNetBar.SuperGrid.GridColumn id_historico;
    }
}