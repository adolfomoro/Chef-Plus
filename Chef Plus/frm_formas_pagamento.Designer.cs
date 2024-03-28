namespace Chef_Plus
{
    partial class frm_formas_pagamento
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_formas_pagamento));
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.forma_id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.forma_nome = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridControl3 = new DevExpress.XtraGrid.GridControl();
            this.gridView3 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.bandeiras_v_id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.bandeiras_v_vinculado = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.bandeiras_v_descricao = new DevExpress.XtraGrid.Columns.GridColumn();
            this.bandeiras_v_dias_receber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.bandeiras_v_taxa = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.panel_control_top = new DevExpress.XtraEditors.PanelControl();
            this.btn_new = new DevExpress.XtraEditors.SimpleButton();
            this.gridControl2 = new DevExpress.XtraGrid.GridControl();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.bandeiras_id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.bandeiras_descricao = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panel_control_buttons = new DevExpress.XtraEditors.PanelControl();
            this.btn_menu_back = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panel_control_top)).BeginInit();
            this.panel_control_top.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panel_control_buttons)).BeginInit();
            this.panel_control_buttons.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Location = new System.Drawing.Point(0, 56);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(348, 245);
            this.gridControl1.TabIndex = 1;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.forma_id,
            this.forma_nome});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsBehavior.ReadOnly = true;
            this.gridView1.OptionsCustomization.AllowColumnMoving = false;
            this.gridView1.OptionsFind.AllowFindPanel = false;
            this.gridView1.OptionsFind.ShowClearButton = false;
            this.gridView1.OptionsFind.ShowCloseButton = false;
            this.gridView1.OptionsFind.ShowFindButton = false;
            this.gridView1.OptionsMenu.EnableColumnMenu = false;
            this.gridView1.OptionsMenu.EnableFooterMenu = false;
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsView.ShowGroupExpandCollapseButtons = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.OptionsView.ShowIndicator = false;
            this.gridView1.RowHeight = 26;
            this.gridView1.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridView1_FocusedRowChanged);
            this.gridView1.DoubleClick += new System.EventHandler(this.gridView1_DoubleClick);
            // 
            // forma_id
            // 
            this.forma_id.Caption = "Cód. Sistema";
            this.forma_id.FieldName = "id";
            this.forma_id.Name = "forma_id";
            this.forma_id.Width = 83;
            // 
            // forma_nome
            // 
            this.forma_nome.AppearanceHeader.Options.UseTextOptions = true;
            this.forma_nome.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.forma_nome.Caption = "Forma de Pagamento";
            this.forma_nome.FieldName = "nome";
            this.forma_nome.Name = "forma_nome";
            this.forma_nome.Visible = true;
            this.forma_nome.VisibleIndex = 0;
            this.forma_nome.Width = 119;
            // 
            // gridControl3
            // 
            this.gridControl3.Location = new System.Drawing.Point(348, 56);
            this.gridControl3.MainView = this.gridView3;
            this.gridControl3.Name = "gridControl3";
            this.gridControl3.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1,
            this.repositoryItemTextEdit1,
            this.repositoryItemTextEdit2});
            this.gridControl3.Size = new System.Drawing.Size(452, 471);
            this.gridControl3.TabIndex = 2;
            this.gridControl3.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView3});
            // 
            // gridView3
            // 
            this.gridView3.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.bandeiras_v_id,
            this.bandeiras_v_vinculado,
            this.bandeiras_v_descricao,
            this.bandeiras_v_dias_receber,
            this.bandeiras_v_taxa});
            this.gridView3.GridControl = this.gridControl3;
            this.gridView3.Name = "gridView3";
            this.gridView3.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView3.OptionsCustomization.AllowColumnMoving = false;
            this.gridView3.OptionsFind.AllowFindPanel = false;
            this.gridView3.OptionsFind.ShowClearButton = false;
            this.gridView3.OptionsFind.ShowCloseButton = false;
            this.gridView3.OptionsFind.ShowFindButton = false;
            this.gridView3.OptionsMenu.EnableColumnMenu = false;
            this.gridView3.OptionsMenu.EnableFooterMenu = false;
            this.gridView3.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView3.OptionsView.ShowGroupExpandCollapseButtons = false;
            this.gridView3.OptionsView.ShowGroupPanel = false;
            this.gridView3.OptionsView.ShowIndicator = false;
            this.gridView3.RowHeight = 26;
            this.gridView3.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView3_CellValueChanged);
            // 
            // bandeiras_v_id
            // 
            this.bandeiras_v_id.Caption = "Cód. Sistema";
            this.bandeiras_v_id.FieldName = "id";
            this.bandeiras_v_id.Name = "bandeiras_v_id";
            this.bandeiras_v_id.OptionsColumn.AllowEdit = false;
            this.bandeiras_v_id.Width = 83;
            // 
            // bandeiras_v_vinculado
            // 
            this.bandeiras_v_vinculado.AppearanceHeader.Options.UseTextOptions = true;
            this.bandeiras_v_vinculado.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.bandeiras_v_vinculado.Caption = "Vinculado";
            this.bandeiras_v_vinculado.ColumnEdit = this.repositoryItemCheckEdit1;
            this.bandeiras_v_vinculado.FieldName = "status";
            this.bandeiras_v_vinculado.Name = "bandeiras_v_vinculado";
            this.bandeiras_v_vinculado.Visible = true;
            this.bandeiras_v_vinculado.VisibleIndex = 0;
            this.bandeiras_v_vinculado.Width = 97;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            this.repositoryItemCheckEdit1.CheckedChanged += new System.EventHandler(this.repositoryItemCheckEdit1_CheckedChanged);
            // 
            // bandeiras_v_descricao
            // 
            this.bandeiras_v_descricao.AppearanceHeader.Options.UseTextOptions = true;
            this.bandeiras_v_descricao.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.bandeiras_v_descricao.Caption = "Bandeira";
            this.bandeiras_v_descricao.FieldName = "descricao";
            this.bandeiras_v_descricao.Name = "bandeiras_v_descricao";
            this.bandeiras_v_descricao.OptionsColumn.AllowEdit = false;
            this.bandeiras_v_descricao.Visible = true;
            this.bandeiras_v_descricao.VisibleIndex = 1;
            this.bandeiras_v_descricao.Width = 293;
            // 
            // bandeiras_v_dias_receber
            // 
            this.bandeiras_v_dias_receber.AppearanceCell.Options.UseTextOptions = true;
            this.bandeiras_v_dias_receber.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.bandeiras_v_dias_receber.AppearanceHeader.Options.UseTextOptions = true;
            this.bandeiras_v_dias_receber.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.bandeiras_v_dias_receber.Caption = "Dias Para Receber";
            this.bandeiras_v_dias_receber.ColumnEdit = this.repositoryItemTextEdit1;
            this.bandeiras_v_dias_receber.FieldName = "dias";
            this.bandeiras_v_dias_receber.Name = "bandeiras_v_dias_receber";
            this.bandeiras_v_dias_receber.Visible = true;
            this.bandeiras_v_dias_receber.VisibleIndex = 3;
            this.bandeiras_v_dias_receber.Width = 168;
            // 
            // repositoryItemTextEdit1
            // 
            this.repositoryItemTextEdit1.AutoHeight = false;
            this.repositoryItemTextEdit1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.repositoryItemTextEdit1.MaxLength = 3;
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            this.repositoryItemTextEdit1.EditValueChanged += new System.EventHandler(this.repositoryItemTextEdit1_EditValueChanged);
            this.repositoryItemTextEdit1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.repositoryItemTextEdit1_KeyPress);
            this.repositoryItemTextEdit1.Leave += new System.EventHandler(this.repositoryItemTextEdit1_Leave);
            // 
            // bandeiras_v_taxa
            // 
            this.bandeiras_v_taxa.AppearanceCell.Options.UseTextOptions = true;
            this.bandeiras_v_taxa.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.bandeiras_v_taxa.AppearanceHeader.Options.UseTextOptions = true;
            this.bandeiras_v_taxa.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.bandeiras_v_taxa.Caption = "Taxa %";
            this.bandeiras_v_taxa.ColumnEdit = this.repositoryItemTextEdit2;
            this.bandeiras_v_taxa.FieldName = "taxa";
            this.bandeiras_v_taxa.Name = "bandeiras_v_taxa";
            this.bandeiras_v_taxa.Visible = true;
            this.bandeiras_v_taxa.VisibleIndex = 2;
            this.bandeiras_v_taxa.Width = 150;
            // 
            // repositoryItemTextEdit2
            // 
            this.repositoryItemTextEdit2.AutoHeight = false;
            this.repositoryItemTextEdit2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.repositoryItemTextEdit2.MaxLength = 100;
            this.repositoryItemTextEdit2.Name = "repositoryItemTextEdit2";
            this.repositoryItemTextEdit2.EditValueChanged += new System.EventHandler(this.repositoryItemTextEdit2_EditValueChanged);
            this.repositoryItemTextEdit2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.repositoryItemTextEdit2_KeyPress);
            this.repositoryItemTextEdit2.Leave += new System.EventHandler(this.repositoryItemTextEdit2_Leave);
            // 
            // panel_control_top
            // 
            this.panel_control_top.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.panel_control_top.Appearance.Options.UseBackColor = true;
            this.panel_control_top.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panel_control_top.Controls.Add(this.simpleButton1);
            this.panel_control_top.Controls.Add(this.btn_new);
            this.panel_control_top.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_control_top.Location = new System.Drawing.Point(0, 0);
            this.panel_control_top.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.panel_control_top.LookAndFeel.UseDefaultLookAndFeel = false;
            this.panel_control_top.Name = "panel_control_top";
            this.panel_control_top.Size = new System.Drawing.Size(800, 56);
            this.panel_control_top.TabIndex = 3;
            // 
            // btn_new
            // 
            this.btn_new.AllowFocus = false;
            this.btn_new.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_new.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.btn_new.Appearance.BackColor2 = System.Drawing.Color.Transparent;
            this.btn_new.Appearance.BorderColor = System.Drawing.Color.Transparent;
            this.btn_new.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_new.Appearance.ForeColor = System.Drawing.Color.White;
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
            this.btn_new.Location = new System.Drawing.Point(642, 8);
            this.btn_new.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.btn_new.Name = "btn_new";
            this.btn_new.Size = new System.Drawing.Size(146, 40);
            this.btn_new.TabIndex = 10;
            this.btn_new.Text = "Nova Bandeira";
            this.btn_new.Click += new System.EventHandler(this.btn_new_Click);
            // 
            // gridControl2
            // 
            this.gridControl2.Location = new System.Drawing.Point(0, 301);
            this.gridControl2.MainView = this.gridView2;
            this.gridControl2.Name = "gridControl2";
            this.gridControl2.Size = new System.Drawing.Size(348, 226);
            this.gridControl2.TabIndex = 4;
            this.gridControl2.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
            // 
            // gridView2
            // 
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.bandeiras_id,
            this.bandeiras_descricao});
            this.gridView2.GridControl = this.gridControl2;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView2.OptionsBehavior.Editable = false;
            this.gridView2.OptionsBehavior.ReadOnly = true;
            this.gridView2.OptionsCustomization.AllowColumnMoving = false;
            this.gridView2.OptionsFind.AllowFindPanel = false;
            this.gridView2.OptionsFind.ShowClearButton = false;
            this.gridView2.OptionsFind.ShowCloseButton = false;
            this.gridView2.OptionsFind.ShowFindButton = false;
            this.gridView2.OptionsMenu.EnableColumnMenu = false;
            this.gridView2.OptionsMenu.EnableFooterMenu = false;
            this.gridView2.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView2.OptionsView.ShowGroupExpandCollapseButtons = false;
            this.gridView2.OptionsView.ShowGroupPanel = false;
            this.gridView2.OptionsView.ShowIndicator = false;
            this.gridView2.RowHeight = 26;
            this.gridView2.DoubleClick += new System.EventHandler(this.gridView2_DoubleClick);
            // 
            // bandeiras_id
            // 
            this.bandeiras_id.Caption = "Cód. Sistema";
            this.bandeiras_id.FieldName = "id";
            this.bandeiras_id.Name = "bandeiras_id";
            this.bandeiras_id.Width = 83;
            // 
            // bandeiras_descricao
            // 
            this.bandeiras_descricao.AppearanceHeader.Options.UseTextOptions = true;
            this.bandeiras_descricao.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.bandeiras_descricao.Caption = "Bandeiras de Cartões";
            this.bandeiras_descricao.FieldName = "descricao";
            this.bandeiras_descricao.Name = "bandeiras_descricao";
            this.bandeiras_descricao.Visible = true;
            this.bandeiras_descricao.VisibleIndex = 0;
            this.bandeiras_descricao.Width = 119;
            // 
            // panel_control_buttons
            // 
            this.panel_control_buttons.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.panel_control_buttons.Appearance.Options.UseBackColor = true;
            this.panel_control_buttons.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panel_control_buttons.Controls.Add(this.btn_menu_back);
            this.panel_control_buttons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel_control_buttons.Location = new System.Drawing.Point(0, 527);
            this.panel_control_buttons.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.panel_control_buttons.LookAndFeel.UseDefaultLookAndFeel = false;
            this.panel_control_buttons.Name = "panel_control_buttons";
            this.panel_control_buttons.Size = new System.Drawing.Size(800, 56);
            this.panel_control_buttons.TabIndex = 19;
            // 
            // btn_menu_back
            // 
            this.btn_menu_back.AllowFocus = false;
            this.btn_menu_back.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_menu_back.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.btn_menu_back.Appearance.BackColor2 = System.Drawing.Color.Transparent;
            this.btn_menu_back.Appearance.BorderColor = System.Drawing.Color.Transparent;
            this.btn_menu_back.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_menu_back.Appearance.ForeColor = System.Drawing.Color.White;
            this.btn_menu_back.Appearance.Options.UseBackColor = true;
            this.btn_menu_back.Appearance.Options.UseBorderColor = true;
            this.btn_menu_back.Appearance.Options.UseFont = true;
            this.btn_menu_back.Appearance.Options.UseForeColor = true;
            this.btn_menu_back.Appearance.Options.UseTextOptions = true;
            this.btn_menu_back.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.btn_menu_back.AppearanceHovered.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(207)))), ((int)(((byte)(244)))));
            this.btn_menu_back.AppearanceHovered.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.btn_menu_back.AppearanceHovered.Options.UseBackColor = true;
            this.btn_menu_back.AppearanceHovered.Options.UseBorderColor = true;
            this.btn_menu_back.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.btn_menu_back.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_menu_back.ImageOptions.Image")));
            this.btn_menu_back.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.RightCenter;
            this.btn_menu_back.Location = new System.Drawing.Point(676, 8);
            this.btn_menu_back.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.btn_menu_back.Name = "btn_menu_back";
            this.btn_menu_back.Size = new System.Drawing.Size(112, 40);
            this.btn_menu_back.TabIndex = 12;
            this.btn_menu_back.Text = "Voltar  ";
            this.btn_menu_back.Click += new System.EventHandler(this.btn_menu_back_Click);
            // 
            // simpleButton1
            // 
            this.simpleButton1.AllowFocus = false;
            this.simpleButton1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButton1.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.simpleButton1.Appearance.BackColor2 = System.Drawing.Color.Transparent;
            this.simpleButton1.Appearance.BorderColor = System.Drawing.Color.Transparent;
            this.simpleButton1.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButton1.Appearance.ForeColor = System.Drawing.Color.White;
            this.simpleButton1.Appearance.Options.UseBackColor = true;
            this.simpleButton1.Appearance.Options.UseBorderColor = true;
            this.simpleButton1.Appearance.Options.UseFont = true;
            this.simpleButton1.Appearance.Options.UseForeColor = true;
            this.simpleButton1.AppearanceHovered.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(207)))), ((int)(((byte)(244)))));
            this.simpleButton1.AppearanceHovered.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.simpleButton1.AppearanceHovered.Options.UseBackColor = true;
            this.simpleButton1.AppearanceHovered.Options.UseBorderColor = true;
            this.simpleButton1.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.simpleButton1.ImageOptions.Image = global::Chef_Plus.Properties.Resources.add_button;
            this.simpleButton1.Location = new System.Drawing.Point(411, 8);
            this.simpleButton1.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(225, 40);
            this.simpleButton1.TabIndex = 11;
            this.simpleButton1.Text = "Nova Forma de Pagamento";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // frm_formas_pagamento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 583);
            this.Controls.Add(this.panel_control_buttons);
            this.Controls.Add(this.gridControl2);
            this.Controls.Add(this.panel_control_top);
            this.Controls.Add(this.gridControl3);
            this.Controls.Add(this.gridControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_formas_pagamento";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Formas de Pagamento";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frm_formas_pagamento_FormClosing);
            this.Load += new System.EventHandler(this.frm_formas_pagamento_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frm_formas_pagamento_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panel_control_top)).EndInit();
            this.panel_control_top.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panel_control_buttons)).EndInit();
            this.panel_control_buttons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn forma_id;
        private DevExpress.XtraGrid.Columns.GridColumn forma_nome;
        private DevExpress.XtraGrid.GridControl gridControl3;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView3;
        private DevExpress.XtraGrid.Columns.GridColumn bandeiras_v_id;
        private DevExpress.XtraGrid.Columns.GridColumn bandeiras_v_vinculado;
        private DevExpress.XtraGrid.Columns.GridColumn bandeiras_v_descricao;
        private DevExpress.XtraGrid.Columns.GridColumn bandeiras_v_dias_receber;
        private DevExpress.XtraGrid.Columns.GridColumn bandeiras_v_taxa;
        private DevExpress.XtraEditors.PanelControl panel_control_top;
        private DevExpress.XtraEditors.SimpleButton btn_new;
        private DevExpress.XtraGrid.GridControl gridControl2;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Columns.GridColumn bandeiras_id;
        private DevExpress.XtraGrid.Columns.GridColumn bandeiras_descricao;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit2;
        private DevExpress.XtraEditors.PanelControl panel_control_buttons;
        private DevExpress.XtraEditors.SimpleButton btn_menu_back;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
    }
}