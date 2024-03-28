namespace Chef_Plus
{
    partial class frm_tt
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_tt));
            this.panel_control_buttons = new DevExpress.XtraEditors.PanelControl();
            this.btn_menu_back = new DevExpress.XtraEditors.SimpleButton();
            this.panel_control_top = new DevExpress.XtraEditors.PanelControl();
            this.btn_new_tipo = new DevExpress.XtraEditors.SimpleButton();
            this.btn_new_tamanho = new DevExpress.XtraEditors.SimpleButton();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.tipos_id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tipo_nome = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridControl2 = new DevExpress.XtraGrid.GridControl();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.tamanhos_id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tamanhos_nome = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tamanhos_sigla = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridControl3 = new DevExpress.XtraGrid.GridControl();
            this.gridView3 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.produtos_id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.produtos_nome = new DevExpress.XtraGrid.Columns.GridColumn();
            this.produtos_valor = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.panel_control_buttons)).BeginInit();
            this.panel_control_buttons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panel_control_top)).BeginInit();
            this.panel_control_top.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).BeginInit();
            this.SuspendLayout();
            // 
            // panel_control_buttons
            // 
            this.panel_control_buttons.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.panel_control_buttons.Appearance.Options.UseBackColor = true;
            this.panel_control_buttons.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panel_control_buttons.Controls.Add(this.btn_menu_back);
            this.panel_control_buttons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel_control_buttons.Location = new System.Drawing.Point(0, 394);
            this.panel_control_buttons.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.panel_control_buttons.LookAndFeel.UseDefaultLookAndFeel = false;
            this.panel_control_buttons.Name = "panel_control_buttons";
            this.panel_control_buttons.Size = new System.Drawing.Size(924, 56);
            this.panel_control_buttons.TabIndex = 20;
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
            this.btn_menu_back.Location = new System.Drawing.Point(800, 8);
            this.btn_menu_back.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.btn_menu_back.Name = "btn_menu_back";
            this.btn_menu_back.Size = new System.Drawing.Size(112, 40);
            this.btn_menu_back.TabIndex = 12;
            this.btn_menu_back.Text = "Voltar  ";
            this.btn_menu_back.Click += new System.EventHandler(this.btn_menu_back_Click);
            // 
            // panel_control_top
            // 
            this.panel_control_top.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.panel_control_top.Appearance.Options.UseBackColor = true;
            this.panel_control_top.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panel_control_top.Controls.Add(this.btn_new_tipo);
            this.panel_control_top.Controls.Add(this.btn_new_tamanho);
            this.panel_control_top.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_control_top.Location = new System.Drawing.Point(0, 0);
            this.panel_control_top.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.panel_control_top.LookAndFeel.UseDefaultLookAndFeel = false;
            this.panel_control_top.Name = "panel_control_top";
            this.panel_control_top.Size = new System.Drawing.Size(924, 56);
            this.panel_control_top.TabIndex = 19;
            // 
            // btn_new_tipo
            // 
            this.btn_new_tipo.AllowFocus = false;
            this.btn_new_tipo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_new_tipo.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.btn_new_tipo.Appearance.BackColor2 = System.Drawing.Color.Transparent;
            this.btn_new_tipo.Appearance.BorderColor = System.Drawing.Color.Transparent;
            this.btn_new_tipo.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_new_tipo.Appearance.ForeColor = System.Drawing.Color.White;
            this.btn_new_tipo.Appearance.Options.UseBackColor = true;
            this.btn_new_tipo.Appearance.Options.UseBorderColor = true;
            this.btn_new_tipo.Appearance.Options.UseFont = true;
            this.btn_new_tipo.Appearance.Options.UseForeColor = true;
            this.btn_new_tipo.AppearanceHovered.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(207)))), ((int)(((byte)(244)))));
            this.btn_new_tipo.AppearanceHovered.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.btn_new_tipo.AppearanceHovered.Options.UseBackColor = true;
            this.btn_new_tipo.AppearanceHovered.Options.UseBorderColor = true;
            this.btn_new_tipo.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.btn_new_tipo.ImageOptions.Image = global::Chef_Plus.Properties.Resources.add_button;
            this.btn_new_tipo.Location = new System.Drawing.Point(628, 8);
            this.btn_new_tipo.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.btn_new_tipo.Name = "btn_new_tipo";
            this.btn_new_tipo.Size = new System.Drawing.Size(125, 40);
            this.btn_new_tipo.TabIndex = 11;
            this.btn_new_tipo.Text = "Novo Tipo";
            this.btn_new_tipo.Click += new System.EventHandler(this.btn_new_tipo_Click);
            // 
            // btn_new_tamanho
            // 
            this.btn_new_tamanho.AllowFocus = false;
            this.btn_new_tamanho.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_new_tamanho.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.btn_new_tamanho.Appearance.BackColor2 = System.Drawing.Color.Transparent;
            this.btn_new_tamanho.Appearance.BorderColor = System.Drawing.Color.Transparent;
            this.btn_new_tamanho.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_new_tamanho.Appearance.ForeColor = System.Drawing.Color.White;
            this.btn_new_tamanho.Appearance.Options.UseBackColor = true;
            this.btn_new_tamanho.Appearance.Options.UseBorderColor = true;
            this.btn_new_tamanho.Appearance.Options.UseFont = true;
            this.btn_new_tamanho.Appearance.Options.UseForeColor = true;
            this.btn_new_tamanho.AppearanceHovered.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(207)))), ((int)(((byte)(244)))));
            this.btn_new_tamanho.AppearanceHovered.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.btn_new_tamanho.AppearanceHovered.Options.UseBackColor = true;
            this.btn_new_tamanho.AppearanceHovered.Options.UseBorderColor = true;
            this.btn_new_tamanho.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.btn_new_tamanho.ImageOptions.Image = global::Chef_Plus.Properties.Resources.add_button;
            this.btn_new_tamanho.Location = new System.Drawing.Point(759, 8);
            this.btn_new_tamanho.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.btn_new_tamanho.Name = "btn_new_tamanho";
            this.btn_new_tamanho.Size = new System.Drawing.Size(153, 40);
            this.btn_new_tamanho.TabIndex = 10;
            this.btn_new_tamanho.Text = "Novo Tamanho";
            this.btn_new_tamanho.Click += new System.EventHandler(this.btn_new_tamanho_Click);
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.gridControl1.Location = new System.Drawing.Point(0, 56);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(244, 338);
            this.gridControl1.TabIndex = 22;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridView1.Appearance.Row.Options.UseFont = true;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.tipos_id,
            this.tipo_nome});
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
            this.gridView1.RowHeight = 56;
            this.gridView1.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridView1_FocusedRowChanged);
            this.gridView1.DoubleClick += new System.EventHandler(this.gridView1_DoubleClick);
            // 
            // tipos_id
            // 
            this.tipos_id.Caption = "tipos_id";
            this.tipos_id.FieldName = "id";
            this.tipos_id.Name = "tipos_id";
            // 
            // tipo_nome
            // 
            this.tipo_nome.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tipo_nome.AppearanceHeader.Options.UseFont = true;
            this.tipo_nome.AppearanceHeader.Options.UseTextOptions = true;
            this.tipo_nome.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.tipo_nome.Caption = "Tipos";
            this.tipo_nome.FieldName = "nome";
            this.tipo_nome.Name = "tipo_nome";
            this.tipo_nome.Visible = true;
            this.tipo_nome.VisibleIndex = 0;
            // 
            // gridControl2
            // 
            this.gridControl2.Dock = System.Windows.Forms.DockStyle.Left;
            this.gridControl2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridControl2.Location = new System.Drawing.Point(244, 56);
            this.gridControl2.MainView = this.gridView2;
            this.gridControl2.Name = "gridControl2";
            this.gridControl2.Size = new System.Drawing.Size(302, 338);
            this.gridControl2.TabIndex = 23;
            this.gridControl2.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
            // 
            // gridView2
            // 
            this.gridView2.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridView2.Appearance.Row.Options.UseFont = true;
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.tamanhos_id,
            this.tamanhos_nome,
            this.tamanhos_sigla});
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
            this.gridView2.RowHeight = 41;
            this.gridView2.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridView2_FocusedRowChanged);
            this.gridView2.DoubleClick += new System.EventHandler(this.gridView2_DoubleClick);
            // 
            // tamanhos_id
            // 
            this.tamanhos_id.Caption = "tamanhos_id";
            this.tamanhos_id.FieldName = "id";
            this.tamanhos_id.Name = "tamanhos_id";
            // 
            // tamanhos_nome
            // 
            this.tamanhos_nome.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tamanhos_nome.AppearanceHeader.Options.UseFont = true;
            this.tamanhos_nome.AppearanceHeader.Options.UseTextOptions = true;
            this.tamanhos_nome.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.tamanhos_nome.Caption = "Tamanhos";
            this.tamanhos_nome.FieldName = "nome";
            this.tamanhos_nome.Name = "tamanhos_nome";
            this.tamanhos_nome.Visible = true;
            this.tamanhos_nome.VisibleIndex = 0;
            this.tamanhos_nome.Width = 228;
            // 
            // tamanhos_sigla
            // 
            this.tamanhos_sigla.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tamanhos_sigla.AppearanceHeader.Options.UseFont = true;
            this.tamanhos_sigla.AppearanceHeader.Options.UseTextOptions = true;
            this.tamanhos_sigla.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.tamanhos_sigla.Caption = "Sigla";
            this.tamanhos_sigla.FieldName = "sigla";
            this.tamanhos_sigla.Name = "tamanhos_sigla";
            this.tamanhos_sigla.Visible = true;
            this.tamanhos_sigla.VisibleIndex = 1;
            this.tamanhos_sigla.Width = 72;
            // 
            // gridControl3
            // 
            this.gridControl3.Dock = System.Windows.Forms.DockStyle.Left;
            this.gridControl3.Location = new System.Drawing.Point(546, 56);
            this.gridControl3.MainView = this.gridView3;
            this.gridControl3.Name = "gridControl3";
            this.gridControl3.Size = new System.Drawing.Size(378, 338);
            this.gridControl3.TabIndex = 24;
            this.gridControl3.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView3});
            // 
            // gridView3
            // 
            this.gridView3.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.produtos_id,
            this.produtos_nome,
            this.produtos_valor});
            this.gridView3.GridControl = this.gridControl3;
            this.gridView3.Name = "gridView3";
            this.gridView3.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView3.OptionsBehavior.Editable = false;
            this.gridView3.OptionsBehavior.ReadOnly = true;
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
            // 
            // produtos_id
            // 
            this.produtos_id.Caption = "produtos_id";
            this.produtos_id.FieldName = "id";
            this.produtos_id.Name = "produtos_id";
            // 
            // produtos_nome
            // 
            this.produtos_nome.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.produtos_nome.AppearanceHeader.Options.UseFont = true;
            this.produtos_nome.AppearanceHeader.Options.UseTextOptions = true;
            this.produtos_nome.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.produtos_nome.Caption = "Produtos Vinculados";
            this.produtos_nome.FieldName = "nome";
            this.produtos_nome.Name = "produtos_nome";
            this.produtos_nome.Visible = true;
            this.produtos_nome.VisibleIndex = 0;
            this.produtos_nome.Width = 270;
            // 
            // produtos_valor
            // 
            this.produtos_valor.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.produtos_valor.AppearanceHeader.Options.UseFont = true;
            this.produtos_valor.AppearanceHeader.Options.UseTextOptions = true;
            this.produtos_valor.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.produtos_valor.Caption = "Valor";
            this.produtos_valor.FieldName = "preco_venda";
            this.produtos_valor.Name = "produtos_valor";
            this.produtos_valor.Visible = true;
            this.produtos_valor.VisibleIndex = 1;
            this.produtos_valor.Width = 106;
            // 
            // frm_tt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(924, 450);
            this.Controls.Add(this.gridControl3);
            this.Controls.Add(this.gridControl2);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.panel_control_buttons);
            this.Controls.Add(this.panel_control_top);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_tt";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tipos e Tamanhos de Produtos";
            this.Load += new System.EventHandler(this.frm_tt_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frm_tt_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.panel_control_buttons)).EndInit();
            this.panel_control_buttons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panel_control_top)).EndInit();
            this.panel_control_top.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panel_control_buttons;
        private DevExpress.XtraEditors.SimpleButton btn_menu_back;
        private DevExpress.XtraEditors.PanelControl panel_control_top;
        private DevExpress.XtraEditors.SimpleButton btn_new_tamanho;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn tipos_id;
        private DevExpress.XtraGrid.Columns.GridColumn tipo_nome;
        private DevExpress.XtraGrid.GridControl gridControl2;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Columns.GridColumn tamanhos_id;
        private DevExpress.XtraGrid.Columns.GridColumn tamanhos_nome;
        private DevExpress.XtraGrid.Columns.GridColumn tamanhos_sigla;
        private DevExpress.XtraGrid.GridControl gridControl3;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView3;
        private DevExpress.XtraGrid.Columns.GridColumn produtos_id;
        private DevExpress.XtraGrid.Columns.GridColumn produtos_nome;
        private DevExpress.XtraGrid.Columns.GridColumn produtos_valor;
        private DevExpress.XtraEditors.SimpleButton btn_new_tipo;
    }
}