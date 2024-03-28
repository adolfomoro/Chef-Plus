namespace Chef_Plus
{
    partial class frm_mesas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_mesas));
            this.layoutView1 = new DevExpress.XtraGrid.Views.Layout.LayoutView();
            this.id = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_id = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.comanda = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_nome = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.atendente = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_telefone = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.permanencia = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_status = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.status = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_layoutViewColumn1_1 = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.subtotal = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_layoutViewColumn1 = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.date_abertura = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_layoutViewColumn1_2 = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.layoutViewCard1 = new DevExpress.XtraGrid.Views.Layout.LayoutViewCard();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.checkEdit1 = new DevExpress.XtraEditors.CheckEdit();
            this.btn_new = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.layoutView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_id)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_nome)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_telefone)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_status)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_layoutViewColumn1_1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_layoutViewColumn1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_layoutViewColumn1_2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewCard1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutView1
            // 
            this.layoutView1.Appearance.CardCaption.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Bold);
            this.layoutView1.Appearance.CardCaption.Options.UseFont = true;
            this.layoutView1.CardHorzInterval = 6;
            this.layoutView1.CardMinSize = new System.Drawing.Size(213, 110);
            this.layoutView1.CardVertInterval = 6;
            this.layoutView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.LayoutViewColumn[] {
            this.id,
            this.comanda,
            this.atendente,
            this.permanencia,
            this.status,
            this.subtotal,
            this.date_abertura});
            this.layoutView1.GridControl = this.gridControl1;
            this.layoutView1.HiddenItems.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutViewField_id,
            this.layoutViewField_nome,
            this.layoutViewField_layoutViewColumn1_2,
            this.layoutViewField_layoutViewColumn1});
            this.layoutView1.Name = "layoutView1";
            this.layoutView1.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.layoutView1.OptionsBehavior.Editable = false;
            this.layoutView1.OptionsBehavior.ReadOnly = true;
            this.layoutView1.OptionsCustomization.AllowFilter = false;
            this.layoutView1.OptionsCustomization.AllowSort = false;
            this.layoutView1.OptionsFind.AllowFindPanel = false;
            this.layoutView1.OptionsFind.ShowClearButton = false;
            this.layoutView1.OptionsFind.ShowCloseButton = false;
            this.layoutView1.OptionsFind.ShowFindButton = false;
            this.layoutView1.OptionsMultiRecordMode.MultiRowScrollBarOrientation = DevExpress.XtraGrid.Views.Layout.ScrollBarOrientation.Vertical;
            this.layoutView1.OptionsView.ContentAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.layoutView1.OptionsView.FocusRectStyle = DevExpress.XtraGrid.Views.Layout.FocusRectStyle.None;
            this.layoutView1.OptionsView.PartialCardsSimpleScrolling = DevExpress.Utils.DefaultBoolean.True;
            this.layoutView1.OptionsView.ShowCardExpandButton = false;
            this.layoutView1.OptionsView.ShowHeaderPanel = false;
            this.layoutView1.OptionsView.ViewMode = DevExpress.XtraGrid.Views.Layout.LayoutViewMode.MultiRow;
            this.layoutView1.TemplateCard = this.layoutViewCard1;
            this.layoutView1.CustomDrawCardCaption += new DevExpress.XtraGrid.Views.Layout.Events.LayoutViewCustomDrawCardCaptionEventHandler(this.layoutView1_CustomDrawCardCaption);
            this.layoutView1.CustomFieldValueStyle += new DevExpress.XtraGrid.Views.Layout.Events.LayoutViewFieldValueStyleEventHandler(this.layoutView1_CustomFieldValueStyle);
            this.layoutView1.CardClick += new DevExpress.XtraGrid.Views.Layout.Events.CardClickEventHandler(this.layoutView1_CardClick);
            this.layoutView1.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(this.layoutView1_CustomColumnDisplayText);
            // 
            // id
            // 
            this.id.AppearanceCell.Options.UseFont = true;
            this.id.Caption = "id";
            this.id.FieldName = "id";
            this.id.LayoutViewField = this.layoutViewField_id;
            this.id.Name = "id";
            // 
            // layoutViewField_id
            // 
            this.layoutViewField_id.EditorPreferredWidth = 20;
            this.layoutViewField_id.Location = new System.Drawing.Point(0, 0);
            this.layoutViewField_id.Name = "layoutViewField_id";
            this.layoutViewField_id.Size = new System.Drawing.Size(179, 72);
            this.layoutViewField_id.TextSize = new System.Drawing.Size(46, 13);
            // 
            // comanda
            // 
            this.comanda.Caption = "comanda";
            this.comanda.FieldName = "comanda";
            this.comanda.LayoutViewField = this.layoutViewField_nome;
            this.comanda.Name = "comanda";
            this.comanda.Width = 392;
            // 
            // layoutViewField_nome
            // 
            this.layoutViewField_nome.EditorPreferredWidth = 20;
            this.layoutViewField_nome.Location = new System.Drawing.Point(0, 0);
            this.layoutViewField_nome.Name = "layoutViewField_nome";
            this.layoutViewField_nome.OptionsTableLayoutItem.ColumnIndex = 1;
            this.layoutViewField_nome.Size = new System.Drawing.Size(179, 72);
            this.layoutViewField_nome.TextSize = new System.Drawing.Size(46, 13);
            // 
            // atendente
            // 
            this.atendente.Caption = "Atendente";
            this.atendente.FieldName = "atendente";
            this.atendente.LayoutViewField = this.layoutViewField_telefone;
            this.atendente.Name = "atendente";
            this.atendente.Width = 155;
            // 
            // layoutViewField_telefone
            // 
            this.layoutViewField_telefone.EditorPreferredWidth = 119;
            this.layoutViewField_telefone.Location = new System.Drawing.Point(0, 0);
            this.layoutViewField_telefone.Name = "layoutViewField_telefone";
            this.layoutViewField_telefone.OptionsTableLayoutItem.RowIndex = 1;
            this.layoutViewField_telefone.Size = new System.Drawing.Size(193, 24);
            this.layoutViewField_telefone.TextSize = new System.Drawing.Size(65, 13);
            // 
            // permanencia
            // 
            this.permanencia.Caption = "Permanência";
            this.permanencia.FieldName = "permanencia";
            this.permanencia.LayoutViewField = this.layoutViewField_status;
            this.permanencia.Name = "permanencia";
            this.permanencia.Width = 145;
            // 
            // layoutViewField_status
            // 
            this.layoutViewField_status.EditorPreferredWidth = 119;
            this.layoutViewField_status.Location = new System.Drawing.Point(0, 24);
            this.layoutViewField_status.Name = "layoutViewField_status";
            this.layoutViewField_status.OptionsTableLayoutItem.ColumnIndex = 1;
            this.layoutViewField_status.OptionsTableLayoutItem.RowIndex = 1;
            this.layoutViewField_status.Size = new System.Drawing.Size(193, 24);
            this.layoutViewField_status.TextSize = new System.Drawing.Size(65, 13);
            // 
            // status
            // 
            this.status.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.status.AppearanceCell.Options.UseFont = true;
            this.status.Caption = "Status";
            this.status.FieldName = "status";
            this.status.LayoutViewField = this.layoutViewField_layoutViewColumn1_1;
            this.status.Name = "status";
            // 
            // layoutViewField_layoutViewColumn1_1
            // 
            this.layoutViewField_layoutViewColumn1_1.EditorPreferredWidth = 119;
            this.layoutViewField_layoutViewColumn1_1.Location = new System.Drawing.Point(0, 48);
            this.layoutViewField_layoutViewColumn1_1.Name = "layoutViewField_layoutViewColumn1_1";
            this.layoutViewField_layoutViewColumn1_1.Size = new System.Drawing.Size(193, 24);
            this.layoutViewField_layoutViewColumn1_1.TextSize = new System.Drawing.Size(65, 13);
            // 
            // subtotal
            // 
            this.subtotal.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.subtotal.AppearanceCell.Options.UseFont = true;
            this.subtotal.AppearanceCell.Options.UseTextOptions = true;
            this.subtotal.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.subtotal.Caption = "Subtotal";
            this.subtotal.FieldName = "subtotal";
            this.subtotal.LayoutViewField = this.layoutViewField_layoutViewColumn1;
            this.subtotal.Name = "subtotal";
            // 
            // layoutViewField_layoutViewColumn1
            // 
            this.layoutViewField_layoutViewColumn1.EditorPreferredWidth = 20;
            this.layoutViewField_layoutViewColumn1.Location = new System.Drawing.Point(0, 0);
            this.layoutViewField_layoutViewColumn1.Name = "layoutViewField_layoutViewColumn1";
            this.layoutViewField_layoutViewColumn1.Size = new System.Drawing.Size(179, 72);
            this.layoutViewField_layoutViewColumn1.TextSize = new System.Drawing.Size(65, 13);
            // 
            // date_abertura
            // 
            this.date_abertura.FieldName = "date_abertura";
            this.date_abertura.LayoutViewField = this.layoutViewField_layoutViewColumn1_2;
            this.date_abertura.Name = "date_abertura";
            // 
            // layoutViewField_layoutViewColumn1_2
            // 
            this.layoutViewField_layoutViewColumn1_2.EditorPreferredWidth = 10;
            this.layoutViewField_layoutViewColumn1_2.Location = new System.Drawing.Point(0, 0);
            this.layoutViewField_layoutViewColumn1_2.Name = "layoutViewField_layoutViewColumn1_2";
            this.layoutViewField_layoutViewColumn1_2.Size = new System.Drawing.Size(179, 72);
            this.layoutViewField_layoutViewColumn1_2.TextSize = new System.Drawing.Size(65, 20);
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.Location = new System.Drawing.Point(0, 53);
            this.gridControl1.MainView = this.layoutView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1294, 499);
            this.gridControl1.TabIndex = 20;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.layoutView1});
            // 
            // layoutViewCard1
            // 
            this.layoutViewCard1.CustomizationFormText = "TemplateCard";
            this.layoutViewCard1.HeaderButtonsLocation = DevExpress.Utils.GroupElementLocation.AfterText;
            this.layoutViewCard1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutViewField_telefone,
            this.layoutViewField_status,
            this.layoutViewField_layoutViewColumn1_1});
            this.layoutViewCard1.Name = "layoutViewCard1";
            this.layoutViewCard1.OptionsItemText.TextToControlDistance = 5;
            this.layoutViewCard1.Text = "TemplateCard";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.Gray;
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Appearance.Options.UseForeColor = true;
            this.labelControl1.Location = new System.Drawing.Point(12, 12);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(304, 29);
            this.labelControl1.TabIndex = 21;
            this.labelControl1.Text = "Digite [NÚMERO] + [ENTER]";
            // 
            // checkEdit1
            // 
            this.checkEdit1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkEdit1.Location = new System.Drawing.Point(794, 562);
            this.checkEdit1.Name = "checkEdit1";
            this.checkEdit1.Properties.Caption = "Mostrar Subtotal";
            this.checkEdit1.Size = new System.Drawing.Size(107, 19);
            this.checkEdit1.TabIndex = 22;
            this.checkEdit1.CheckedChanged += new System.EventHandler(this.checkEdit1_CheckedChanged);
            // 
            // btn_new
            // 
            this.btn_new.AllowFocus = false;
            this.btn_new.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_new.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.btn_new.Appearance.BackColor2 = System.Drawing.Color.Transparent;
            this.btn_new.Appearance.BorderColor = System.Drawing.Color.Transparent;
            this.btn_new.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_new.Appearance.ForeColor = System.Drawing.Color.Black;
            this.btn_new.Appearance.Options.UseBackColor = true;
            this.btn_new.Appearance.Options.UseBorderColor = true;
            this.btn_new.Appearance.Options.UseFont = true;
            this.btn_new.Appearance.Options.UseForeColor = true;
            this.btn_new.AppearanceHovered.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(207)))), ((int)(((byte)(244)))));
            this.btn_new.AppearanceHovered.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.btn_new.AppearanceHovered.Options.UseBackColor = true;
            this.btn_new.AppearanceHovered.Options.UseBorderColor = true;
            this.btn_new.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.btn_new.ImageOptions.Image = global::Chef_Plus.Properties.Resources.add_button;
            this.btn_new.Location = new System.Drawing.Point(1146, 7);
            this.btn_new.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.btn_new.Name = "btn_new";
            this.btn_new.Size = new System.Drawing.Size(136, 40);
            this.btn_new.TabIndex = 23;
            this.btn_new.Text = "Novo Balcão";
            this.btn_new.Click += new System.EventHandler(this.btn_new_Click);
            // 
            // frm_mesas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1294, 593);
            this.Controls.Add(this.btn_new);
            this.Controls.Add(this.checkEdit1);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.gridControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MinimizeBox = false;
            this.Name = "frm_mesas";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Comandas / Mesas";
            this.Load += new System.EventHandler(this.frm_mesas_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frm_mesas_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frm_mesas_KeyPress);
            this.Resize += new System.EventHandler(this.frm_mesas_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.layoutView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_id)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_nome)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_telefone)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_status)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_layoutViewColumn1_1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_layoutViewColumn1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_layoutViewColumn1_2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewCard1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit1.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.Views.Layout.LayoutView layoutView1;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn id;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn comanda;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn atendente;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn permanencia;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn status;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn subtotal;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn date_abertura;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.CheckEdit checkEdit1;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_id;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_nome;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_telefone;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_status;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_layoutViewColumn1_1;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_layoutViewColumn1;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_layoutViewColumn1_2;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewCard layoutViewCard1;
        private DevExpress.XtraEditors.SimpleButton btn_new;
    }
}