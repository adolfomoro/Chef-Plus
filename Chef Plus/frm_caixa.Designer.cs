using ChefPlus.core;

namespace Chef_Plus
{
    partial class frm_caixa
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_caixa));
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.data_hora = new DevExpress.XtraGrid.Columns.GridColumn();
            this.descricao = new DevExpress.XtraGrid.Columns.GridColumn();
            this.entrada = new DevExpress.XtraGrid.Columns.GridColumn();
            this.saida = new DevExpress.XtraGrid.Columns.GridColumn();
            this.forma_pagamento = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tipo_reg = new DevExpress.XtraGrid.Columns.GridColumn();
            this.observacao = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.btn_abrir = new DevExpress.XtraEditors.SimpleButton();
            this.memoEdit1 = new DevExpress.XtraEditors.MemoEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.textEdit1 = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.gridControl2 = new DevExpress.XtraGrid.GridControl();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.resumo_descricao = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemMemoEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.resumo_valor = new DevExpress.XtraGrid.Columns.GridColumn();
            this.resumo_valor_tipo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btn_add = new DevExpress.XtraEditors.SimpleButton();
            this.btn_trash = new DevExpress.XtraEditors.SimpleButton();
            this.btn_fechar = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.memoEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Location = new System.Drawing.Point(261, 53);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(615, 474);
            this.gridControl1.TabIndex = 2;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.id,
            this.data_hora,
            this.descricao,
            this.entrada,
            this.saida,
            this.forma_pagamento,
            this.tipo_reg,
            this.observacao});
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
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowGroupExpandCollapseButtons = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.OptionsView.ShowIndicator = false;
            this.gridView1.RowHeight = 26;
            this.gridView1.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridView1_FocusedRowChanged);
            // 
            // id
            // 
            this.id.Caption = "gridColumn3";
            this.id.FieldName = "id";
            this.id.Name = "id";
            // 
            // data_hora
            // 
            this.data_hora.Caption = "Data / Hora";
            this.data_hora.FieldName = "data_hora";
            this.data_hora.Name = "data_hora";
            this.data_hora.Visible = true;
            this.data_hora.VisibleIndex = 0;
            this.data_hora.Width = 134;
            // 
            // descricao
            // 
            this.descricao.Caption = "Descrição";
            this.descricao.FieldName = "descricao";
            this.descricao.Name = "descricao";
            this.descricao.Visible = true;
            this.descricao.VisibleIndex = 1;
            this.descricao.Width = 273;
            // 
            // entrada
            // 
            this.entrada.AppearanceCell.ForeColor = System.Drawing.Color.Green;
            this.entrada.AppearanceCell.Options.UseForeColor = true;
            this.entrada.Caption = "Entrada";
            this.entrada.FieldName = "vlr_entrada";
            this.entrada.Name = "entrada";
            this.entrada.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "vlr_entrada", "{0:N2}")});
            this.entrada.Visible = true;
            this.entrada.VisibleIndex = 2;
            this.entrada.Width = 83;
            // 
            // saida
            // 
            this.saida.AppearanceCell.ForeColor = System.Drawing.Color.Red;
            this.saida.AppearanceCell.Options.UseForeColor = true;
            this.saida.Caption = "Saída";
            this.saida.FieldName = "vlr_saida";
            this.saida.Name = "saida";
            this.saida.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "vlr_saida", "{0:N2}")});
            this.saida.Visible = true;
            this.saida.VisibleIndex = 3;
            this.saida.Width = 83;
            // 
            // forma_pagamento
            // 
            this.forma_pagamento.Caption = "Forma de Pagamento";
            this.forma_pagamento.FieldName = "forma_pagamento";
            this.forma_pagamento.Name = "forma_pagamento";
            this.forma_pagamento.Visible = true;
            this.forma_pagamento.VisibleIndex = 4;
            this.forma_pagamento.Width = 135;
            // 
            // tipo_reg
            // 
            this.tipo_reg.Caption = "gridColumn3";
            this.tipo_reg.FieldName = "tipo_reg";
            this.tipo_reg.Name = "tipo_reg";
            // 
            // observacao
            // 
            this.observacao.Caption = "observacao";
            this.observacao.FieldName = "observacao";
            this.observacao.Name = "observacao";
            this.observacao.Visible = true;
            this.observacao.VisibleIndex = 5;
            // 
            // panelControl1
            // 
            this.panelControl1.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(65)))));
            this.panelControl1.Appearance.Options.UseBackColor = true;
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Controls.Add(this.labelControl6);
            this.panelControl1.Controls.Add(this.labelControl7);
            this.panelControl1.Controls.Add(this.labelControl5);
            this.panelControl1.Controls.Add(this.labelControl4);
            this.panelControl1.Controls.Add(this.btn_abrir);
            this.panelControl1.Controls.Add(this.memoEdit1);
            this.panelControl1.Controls.Add(this.labelControl3);
            this.panelControl1.Controls.Add(this.textEdit1);
            this.panelControl1.Controls.Add(this.labelControl2);
            this.panelControl1.Controls.Add(this.panelControl2);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(255, 585);
            this.panelControl1.TabIndex = 0;
            this.panelControl1.Paint += new System.Windows.Forms.PaintEventHandler(this.panelControl1_Paint);
            // 
            // labelControl6
            // 
            this.labelControl6.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl6.Appearance.ForeColor = System.Drawing.Color.White;
            this.labelControl6.Appearance.Options.UseFont = true;
            this.labelControl6.Appearance.Options.UseForeColor = true;
            this.labelControl6.Location = new System.Drawing.Point(12, 382);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(160, 13);
            this.labelControl6.TabIndex = 8;
            this.labelControl6.Text = "Data e Hora do Fechamento:";
            this.labelControl6.Visible = false;
            // 
            // labelControl7
            // 
            this.labelControl7.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl7.Appearance.ForeColor = System.Drawing.Color.White;
            this.labelControl7.Appearance.Options.UseFont = true;
            this.labelControl7.Appearance.Options.UseForeColor = true;
            this.labelControl7.Location = new System.Drawing.Point(12, 401);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(50, 13);
            this.labelControl7.TabIndex = 7;
            this.labelControl7.Text = "Data|Hora";
            this.labelControl7.Visible = false;
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.ForeColor = System.Drawing.Color.White;
            this.labelControl5.Appearance.Options.UseForeColor = true;
            this.labelControl5.Location = new System.Drawing.Point(12, 346);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(50, 13);
            this.labelControl5.TabIndex = 6;
            this.labelControl5.Text = "Data|Hora";
            this.labelControl5.Visible = false;
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl4.Appearance.ForeColor = System.Drawing.Color.White;
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Appearance.Options.UseForeColor = true;
            this.labelControl4.Location = new System.Drawing.Point(12, 327);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(141, 13);
            this.labelControl4.TabIndex = 5;
            this.labelControl4.Text = "Data e Hora da Abertura:";
            this.labelControl4.Visible = false;
            // 
            // btn_abrir
            // 
            this.btn_abrir.AllowFocus = false;
            this.btn_abrir.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_abrir.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.btn_abrir.Appearance.BackColor2 = System.Drawing.Color.Transparent;
            this.btn_abrir.Appearance.BorderColor = System.Drawing.Color.Transparent;
            this.btn_abrir.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_abrir.Appearance.ForeColor = System.Drawing.Color.White;
            this.btn_abrir.Appearance.Options.UseBackColor = true;
            this.btn_abrir.Appearance.Options.UseBorderColor = true;
            this.btn_abrir.Appearance.Options.UseFont = true;
            this.btn_abrir.Appearance.Options.UseForeColor = true;
            this.btn_abrir.Appearance.Options.UseTextOptions = true;
            this.btn_abrir.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.btn_abrir.AppearanceHovered.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(207)))), ((int)(((byte)(244)))));
            this.btn_abrir.AppearanceHovered.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.btn_abrir.AppearanceHovered.Options.UseBackColor = true;
            this.btn_abrir.AppearanceHovered.Options.UseBorderColor = true;
            this.btn_abrir.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.btn_abrir.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_abrir.ImageOptions.Image")));
            this.btn_abrir.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btn_abrir.Location = new System.Drawing.Point(112, 260);
            this.btn_abrir.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.btn_abrir.Name = "btn_abrir";
            this.btn_abrir.Size = new System.Drawing.Size(132, 40);
            this.btn_abrir.TabIndex = 4;
            this.btn_abrir.Text = "  Abrir Caixa  ";
            this.btn_abrir.Visible = false;
            this.btn_abrir.Click += new System.EventHandler(this.btn_abrir_Click);
            // 
            // memoEdit1
            // 
            this.memoEdit1.Location = new System.Drawing.Point(12, 142);
            this.memoEdit1.Name = "memoEdit1";
            this.memoEdit1.Properties.Appearance.BackColor = System.Drawing.Color.DimGray;
            this.memoEdit1.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.memoEdit1.Properties.Appearance.ForeColor = System.Drawing.Color.White;
            this.memoEdit1.Properties.Appearance.Options.UseBackColor = true;
            this.memoEdit1.Properties.Appearance.Options.UseFont = true;
            this.memoEdit1.Properties.Appearance.Options.UseForeColor = true;
            this.memoEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.memoEdit1.Properties.MaxLength = 500;
            this.memoEdit1.Properties.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.memoEdit1.Size = new System.Drawing.Size(232, 112);
            this.memoEdit1.TabIndex = 3;
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.Appearance.ForeColor = System.Drawing.Color.White;
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Appearance.Options.UseForeColor = true;
            this.labelControl3.Location = new System.Drawing.Point(12, 123);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(70, 13);
            this.labelControl3.TabIndex = 2;
            this.labelControl3.Text = "Observação:";
            // 
            // textEdit1
            // 
            this.textEdit1.EditValue = "0,00";
            this.textEdit1.Location = new System.Drawing.Point(12, 81);
            this.textEdit1.Name = "textEdit1";
            this.textEdit1.Properties.Appearance.BackColor = System.Drawing.Color.DimGray;
            this.textEdit1.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textEdit1.Properties.Appearance.ForeColor = System.Drawing.Color.White;
            this.textEdit1.Properties.Appearance.Options.UseBackColor = true;
            this.textEdit1.Properties.Appearance.Options.UseFont = true;
            this.textEdit1.Properties.Appearance.Options.UseForeColor = true;
            this.textEdit1.Properties.Appearance.Options.UseTextOptions = true;
            this.textEdit1.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.textEdit1.Properties.AutoHeight = false;
            this.textEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.textEdit1.Properties.MaxLength = 8;
            this.textEdit1.Size = new System.Drawing.Size(147, 27);
            this.textEdit1.TabIndex = 1;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.ForeColor = System.Drawing.Color.White;
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Appearance.Options.UseForeColor = true;
            this.labelControl2.Location = new System.Drawing.Point(12, 62);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(137, 13);
            this.labelControl2.TabIndex = 0;
            this.labelControl2.Text = "Valor Inicial (DINHEIRO):";
            // 
            // panelControl2
            // 
            this.panelControl2.Appearance.BackColor = System.Drawing.Color.Red;
            this.panelControl2.Appearance.Options.UseBackColor = true;
            this.panelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl2.Controls.Add(this.labelControl1);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl2.Location = new System.Drawing.Point(0, 0);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(255, 39);
            this.panelControl2.TabIndex = 1;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.Black;
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Appearance.Options.UseForeColor = true;
            this.labelControl1.Appearance.Options.UseTextOptions = true;
            this.labelControl1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.labelControl1.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelControl1.Location = new System.Drawing.Point(0, 0);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(255, 39);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Caixa Fechado";
            // 
            // gridControl2
            // 
            this.gridControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl2.Location = new System.Drawing.Point(2, 20);
            this.gridControl2.MainView = this.gridView2;
            this.gridControl2.Name = "gridControl2";
            this.gridControl2.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemMemoEdit1});
            this.gridControl2.Size = new System.Drawing.Size(297, 563);
            this.gridControl2.TabIndex = 3;
            this.gridControl2.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
            // 
            // gridView2
            // 
            this.gridView2.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(241)))), ((int)(((byte)(230)))));
            this.gridView2.Appearance.Empty.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(229)))), ((int)(((byte)(197)))));
            this.gridView2.Appearance.Empty.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.gridView2.Appearance.Empty.Options.UseBackColor = true;
            this.gridView2.Appearance.EvenRow.BackColor = System.Drawing.Color.Transparent;
            this.gridView2.Appearance.EvenRow.Options.UseBackColor = true;
            this.gridView2.Appearance.FocusedRow.BackColor = System.Drawing.Color.Transparent;
            this.gridView2.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gridView2.Appearance.Row.BackColor = System.Drawing.Color.Transparent;
            this.gridView2.Appearance.Row.Options.UseBackColor = true;
            this.gridView2.Appearance.SelectedRow.BackColor = System.Drawing.Color.Transparent;
            this.gridView2.Appearance.SelectedRow.Options.UseBackColor = true;
            this.gridView2.Appearance.TopNewRow.BackColor = System.Drawing.Color.Transparent;
            this.gridView2.Appearance.TopNewRow.Options.UseBackColor = true;
            this.gridView2.Appearance.VertLine.BackColor = System.Drawing.Color.Transparent;
            this.gridView2.Appearance.VertLine.Options.UseBackColor = true;
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.resumo_descricao,
            this.resumo_valor,
            this.resumo_valor_tipo});
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
            this.gridView2.OptionsView.ShowColumnHeaders = false;
            this.gridView2.OptionsView.ShowGroupExpandCollapseButtons = false;
            this.gridView2.OptionsView.ShowGroupPanel = false;
            this.gridView2.OptionsView.ShowIndicator = false;
            this.gridView2.RowHeight = 26;
            this.gridView2.ScrollStyle = DevExpress.XtraGrid.Views.Grid.ScrollStyleFlags.None;
            this.gridView2.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.gridView2_RowCellStyle);
            this.gridView2.RowStyle += new DevExpress.XtraGrid.Views.Grid.RowStyleEventHandler(this.gridView2_RowStyle);
            // 
            // resumo_descricao
            // 
            this.resumo_descricao.AppearanceCell.Options.UseTextOptions = true;
            this.resumo_descricao.AppearanceCell.TextOptions.Trimming = DevExpress.Utils.Trimming.EllipsisCharacter;
            this.resumo_descricao.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.resumo_descricao.Caption = "Descrição";
            this.resumo_descricao.ColumnEdit = this.repositoryItemMemoEdit1;
            this.resumo_descricao.FieldName = "descricao";
            this.resumo_descricao.Name = "resumo_descricao";
            this.resumo_descricao.Visible = true;
            this.resumo_descricao.VisibleIndex = 0;
            this.resumo_descricao.Width = 220;
            // 
            // repositoryItemMemoEdit1
            // 
            this.repositoryItemMemoEdit1.AllowHtmlDraw = DevExpress.Utils.DefaultBoolean.True;
            this.repositoryItemMemoEdit1.Name = "repositoryItemMemoEdit1";
            // 
            // resumo_valor
            // 
            this.resumo_valor.AppearanceCell.Options.UseTextOptions = true;
            this.resumo_valor.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.resumo_valor.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.resumo_valor.Caption = "valor";
            this.resumo_valor.ColumnEdit = this.repositoryItemMemoEdit1;
            this.resumo_valor.FieldName = "valor";
            this.resumo_valor.Name = "resumo_valor";
            this.resumo_valor.Visible = true;
            this.resumo_valor.VisibleIndex = 1;
            this.resumo_valor.Width = 80;
            // 
            // resumo_valor_tipo
            // 
            this.resumo_valor_tipo.Caption = "valor_tipo";
            this.resumo_valor_tipo.FieldName = "valor_tipo";
            this.resumo_valor_tipo.Name = "resumo_valor_tipo";
            // 
            // btn_add
            // 
            this.btn_add.AllowFocus = false;
            this.btn_add.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.btn_add.Appearance.BackColor2 = System.Drawing.Color.Transparent;
            this.btn_add.Appearance.BorderColor = System.Drawing.Color.Transparent;
            this.btn_add.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_add.Appearance.ForeColor = System.Drawing.Color.Black;
            this.btn_add.Appearance.Options.UseBackColor = true;
            this.btn_add.Appearance.Options.UseBorderColor = true;
            this.btn_add.Appearance.Options.UseFont = true;
            this.btn_add.Appearance.Options.UseForeColor = true;
            this.btn_add.AppearanceHovered.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(207)))), ((int)(((byte)(244)))));
            this.btn_add.AppearanceHovered.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.btn_add.AppearanceHovered.Options.UseBackColor = true;
            this.btn_add.AppearanceHovered.Options.UseBorderColor = true;
            this.btn_add.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.btn_add.Enabled = false;
            this.btn_add.ImageOptions.Image = global::Chef_Plus.Properties.Resources.add_button;
            this.btn_add.Location = new System.Drawing.Point(669, 7);
            this.btn_add.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(201, 40);
            this.btn_add.TabIndex = 1;
            this.btn_add.Text = "Adicionar Entrada/Saída";
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // btn_trash
            // 
            this.btn_trash.AllowFocus = false;
            this.btn_trash.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.btn_trash.Appearance.BackColor2 = System.Drawing.Color.Transparent;
            this.btn_trash.Appearance.BorderColor = System.Drawing.Color.Transparent;
            this.btn_trash.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_trash.Appearance.Options.UseBackColor = true;
            this.btn_trash.Appearance.Options.UseBorderColor = true;
            this.btn_trash.Appearance.Options.UseFont = true;
            this.btn_trash.AppearanceHovered.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(207)))), ((int)(((byte)(244)))));
            this.btn_trash.AppearanceHovered.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.btn_trash.AppearanceHovered.Options.UseBackColor = true;
            this.btn_trash.AppearanceHovered.Options.UseBorderColor = true;
            this.btn_trash.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.btn_trash.Enabled = false;
            this.btn_trash.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_trash.ImageOptions.Image")));
            this.btn_trash.Location = new System.Drawing.Point(261, 533);
            this.btn_trash.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.btn_trash.Name = "btn_trash";
            this.btn_trash.Size = new System.Drawing.Size(166, 40);
            this.btn_trash.TabIndex = 4;
            this.btn_trash.Text = "Excluir Lançamento";
            this.btn_trash.Click += new System.EventHandler(this.btn_trash_Click);
            // 
            // btn_fechar
            // 
            this.btn_fechar.AllowFocus = false;
            this.btn_fechar.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.btn_fechar.Appearance.BackColor2 = System.Drawing.Color.Transparent;
            this.btn_fechar.Appearance.BorderColor = System.Drawing.Color.Transparent;
            this.btn_fechar.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_fechar.Appearance.Options.UseBackColor = true;
            this.btn_fechar.Appearance.Options.UseBorderColor = true;
            this.btn_fechar.Appearance.Options.UseFont = true;
            this.btn_fechar.AppearanceHovered.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(207)))), ((int)(((byte)(244)))));
            this.btn_fechar.AppearanceHovered.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.btn_fechar.AppearanceHovered.Options.UseBackColor = true;
            this.btn_fechar.AppearanceHovered.Options.UseBorderColor = true;
            this.btn_fechar.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.btn_fechar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_fechar.ImageOptions.Image")));
            this.btn_fechar.Location = new System.Drawing.Point(742, 533);
            this.btn_fechar.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.btn_fechar.Name = "btn_fechar";
            this.btn_fechar.Size = new System.Drawing.Size(128, 40);
            this.btn_fechar.TabIndex = 5;
            this.btn_fechar.Text = "Fechar Caixa ";
            this.btn_fechar.Visible = false;
            this.btn_fechar.Click += new System.EventHandler(this.btn_fechar_Click);
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.gridControl2);
            this.groupControl1.Location = new System.Drawing.Point(876, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(301, 585);
            this.groupControl1.TabIndex = 6;
            this.groupControl1.Text = "Resumo do Caixa";
            // 
            // frm_caixa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1177, 585);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.btn_fechar);
            this.Controls.Add(this.btn_trash);
            this.Controls.Add(this.btn_add);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.panelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_caixa";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Caixa";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frm_caixa_FormClosing);
            this.Load += new System.EventHandler(this.cadastro_categoria_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frm_caixa_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.memoEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit textEdit1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.MemoEdit memoEdit1;
        private DevExpress.XtraEditors.SimpleButton btn_abrir;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.GridControl gridControl2;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Columns.GridColumn resumo_descricao;
        private DevExpress.XtraGrid.Columns.GridColumn resumo_valor;
        private DevExpress.XtraEditors.SimpleButton btn_add;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.SimpleButton btn_trash;
        private DevExpress.XtraEditors.SimpleButton btn_fechar;
        private DevExpress.XtraGrid.Columns.GridColumn id;
        private DevExpress.XtraGrid.Columns.GridColumn data_hora;
        private DevExpress.XtraGrid.Columns.GridColumn descricao;
        private DevExpress.XtraGrid.Columns.GridColumn entrada;
        private DevExpress.XtraGrid.Columns.GridColumn saida;
        private DevExpress.XtraGrid.Columns.GridColumn forma_pagamento;
        private DevExpress.XtraGrid.Columns.GridColumn tipo_reg;
        private DevExpress.XtraGrid.Columns.GridColumn observacao;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn resumo_valor_tipo;
        private DevExpress.XtraEditors.GroupControl groupControl1;
    }
}