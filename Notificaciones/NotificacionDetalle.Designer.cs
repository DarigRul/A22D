
namespace ALTIMA_ERP_2022.Notificaciones
{
    partial class NotificacionDetalle
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
            this.dtiFechaCreacion = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.dtiFechaVisto = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.lblEstatus = new DevComponents.DotNetBar.LabelX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.txtDescripcion = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.chbVisto = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.btnAceptar = new DevComponents.DotNetBar.ButtonX();
            ((System.ComponentModel.ISupportInitialize)(this.dtiFechaCreacion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtiFechaVisto)).BeginInit();
            this.SuspendLayout();
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(12, 12);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(95, 23);
            this.labelX1.TabIndex = 0;
            this.labelX1.Text = "Fecha creación: ";
            // 
            // dtiFechaCreacion
            // 
            // 
            // 
            // 
            this.dtiFechaCreacion.BackgroundStyle.Class = "DateTimeInputBackground";
            this.dtiFechaCreacion.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtiFechaCreacion.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.dtiFechaCreacion.ButtonDropDown.Visible = true;
            this.dtiFechaCreacion.Enabled = false;
            this.dtiFechaCreacion.Format = DevComponents.Editors.eDateTimePickerFormat.Long;
            this.dtiFechaCreacion.IsPopupCalendarOpen = false;
            this.dtiFechaCreacion.Location = new System.Drawing.Point(113, 15);
            // 
            // 
            // 
            // 
            // 
            // 
            this.dtiFechaCreacion.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtiFechaCreacion.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            this.dtiFechaCreacion.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.dtiFechaCreacion.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.dtiFechaCreacion.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.dtiFechaCreacion.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.dtiFechaCreacion.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.dtiFechaCreacion.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.dtiFechaCreacion.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.dtiFechaCreacion.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtiFechaCreacion.MonthCalendar.DisplayMonth = new System.DateTime(2022, 3, 1, 0, 0, 0, 0);
            this.dtiFechaCreacion.MonthCalendar.MinDate = new System.DateTime(2022, 1, 1, 0, 0, 0, 0);
            // 
            // 
            // 
            this.dtiFechaCreacion.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.dtiFechaCreacion.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.dtiFechaCreacion.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.dtiFechaCreacion.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtiFechaCreacion.MonthCalendar.TodayButtonVisible = true;
            this.dtiFechaCreacion.Name = "dtiFechaCreacion";
            this.dtiFechaCreacion.Size = new System.Drawing.Size(260, 20);
            this.dtiFechaCreacion.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.dtiFechaCreacion.TabIndex = 1;
            // 
            // labelX2
            // 
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(379, 15);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(72, 23);
            this.labelX2.TabIndex = 0;
            this.labelX2.Text = "Fecha visto: ";
            // 
            // dtiFechaVisto
            // 
            // 
            // 
            // 
            this.dtiFechaVisto.BackgroundStyle.Class = "DateTimeInputBackground";
            this.dtiFechaVisto.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtiFechaVisto.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.dtiFechaVisto.ButtonDropDown.Visible = true;
            this.dtiFechaVisto.Enabled = false;
            this.dtiFechaVisto.Format = DevComponents.Editors.eDateTimePickerFormat.Long;
            this.dtiFechaVisto.IsPopupCalendarOpen = false;
            this.dtiFechaVisto.Location = new System.Drawing.Point(457, 18);
            // 
            // 
            // 
            // 
            // 
            // 
            this.dtiFechaVisto.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtiFechaVisto.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            this.dtiFechaVisto.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.dtiFechaVisto.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.dtiFechaVisto.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.dtiFechaVisto.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.dtiFechaVisto.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.dtiFechaVisto.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.dtiFechaVisto.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.dtiFechaVisto.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtiFechaVisto.MonthCalendar.DisplayMonth = new System.DateTime(2022, 3, 1, 0, 0, 0, 0);
            this.dtiFechaVisto.MonthCalendar.MinDate = new System.DateTime(2022, 1, 1, 0, 0, 0, 0);
            // 
            // 
            // 
            this.dtiFechaVisto.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.dtiFechaVisto.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.dtiFechaVisto.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.dtiFechaVisto.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtiFechaVisto.MonthCalendar.TodayButtonVisible = true;
            this.dtiFechaVisto.Name = "dtiFechaVisto";
            this.dtiFechaVisto.Size = new System.Drawing.Size(260, 20);
            this.dtiFechaVisto.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.dtiFechaVisto.TabIndex = 1;
            // 
            // labelX3
            // 
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Location = new System.Drawing.Point(12, 41);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(75, 23);
            this.labelX3.TabIndex = 2;
            this.labelX3.Text = "Estátus: ";
            // 
            // lblEstatus
            // 
            // 
            // 
            // 
            this.lblEstatus.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblEstatus.Location = new System.Drawing.Point(113, 41);
            this.lblEstatus.Name = "lblEstatus";
            this.lblEstatus.Size = new System.Drawing.Size(260, 23);
            this.lblEstatus.TabIndex = 2;
            this.lblEstatus.Text = "Nueva";
            // 
            // labelX4
            // 
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Location = new System.Drawing.Point(12, 70);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(75, 23);
            this.labelX4.TabIndex = 2;
            this.labelX4.Text = "Descripción: ";
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
            this.txtDescripcion.Location = new System.Drawing.Point(12, 99);
            this.txtDescripcion.Multiline = true;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.PreventEnterBeep = true;
            this.txtDescripcion.ReadOnly = true;
            this.txtDescripcion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescripcion.Size = new System.Drawing.Size(705, 159);
            this.txtDescripcion.TabIndex = 3;
            // 
            // chbVisto
            // 
            // 
            // 
            // 
            this.chbVisto.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chbVisto.CheckBoxPosition = DevComponents.DotNetBar.eCheckBoxPosition.Right;
            this.chbVisto.Location = new System.Drawing.Point(12, 269);
            this.chbVisto.Name = "chbVisto";
            this.chbVisto.Size = new System.Drawing.Size(118, 23);
            this.chbVisto.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chbVisto.TabIndex = 5;
            this.chbVisto.Text = "Marcar como visto";
            // 
            // btnAceptar
            // 
            this.btnAceptar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAceptar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnAceptar.Image = global::ALTIMA_ERP_2022.Properties.Resources.aceptar;
            this.btnAceptar.ImageFixedSize = new System.Drawing.Size(24, 24);
            this.btnAceptar.Location = new System.Drawing.Point(622, 264);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(100, 30);
            this.btnAceptar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnAceptar.TabIndex = 6;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // NotificacionDetalle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 314);
            this.ControlBox = false;
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.chbVisto);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.lblEstatus);
            this.Controls.Add(this.labelX4);
            this.Controls.Add(this.labelX3);
            this.Controls.Add(this.dtiFechaVisto);
            this.Controls.Add(this.dtiFechaCreacion);
            this.Controls.Add(this.labelX2);
            this.Controls.Add(this.labelX1);
            this.DoubleBuffered = true;
            this.KeyPreview = true;
            this.Name = "NotificacionDetalle";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Detalle de la notificación";
            this.Load += new System.EventHandler(this.NotificacionDetalle_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtiFechaCreacion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtiFechaVisto)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dtiFechaCreacion;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dtiFechaVisto;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.LabelX lblEstatus;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.Controls.TextBoxX txtDescripcion;
        private DevComponents.DotNetBar.Controls.CheckBoxX chbVisto;
        private DevComponents.DotNetBar.ButtonX btnAceptar;
    }
}