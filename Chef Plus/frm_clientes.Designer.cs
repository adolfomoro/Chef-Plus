using ChefPlus.core;
namespace Chef_Plus
{
    partial class frm_clientes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_clientes));
            this.pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
            this.textEdit1 = new DevExpress.XtraEditors.TextEdit();
            this.btn_new = new DevExpress.XtraEditors.SimpleButton();
            this.panel_control_top = new DevExpress.XtraEditors.PanelControl();
            this.panel_control_buttons = new DevExpress.XtraEditors.PanelControl();
            this.btn_menu_back = new DevExpress.XtraEditors.SimpleButton();
            this.btn_trash = new DevExpress.XtraEditors.SimpleButton();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.nome = new DevExpress.XtraGrid.Columns.GridColumn();
            this.telefone = new DevExpress.XtraGrid.Columns.GridColumn();
            this.celular = new DevExpress.XtraGrid.Columns.GridColumn();
            this.endereco = new DevExpress.XtraGrid.Columns.GridColumn();
            this.numero = new DevExpress.XtraGrid.Columns.GridColumn();
            this.saldo = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panel_control_top)).BeginInit();
            this.panel_control_top.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panel_control_buttons)).BeginInit();
            this.panel_control_buttons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureEdit1
            // 
            this.pictureEdit1.Cursor = System.Windows.Forms.Cursors.Default;
            this.pictureEdit1.EditValue = ((object)(resources.GetObject("pictureEdit1.EditValue")));
            this.pictureEdit1.Location = new System.Drawing.Point(18, 18);
            this.pictureEdit1.Name = "pictureEdit1";
            this.pictureEdit1.Properties.AllowFocused = false;
            this.pictureEdit1.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.pictureEdit1.Properties.Appearance.Options.UseBackColor = true;
            this.pictureEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pictureEdit1.Properties.PictureAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.pictureEdit1.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.pictureEdit1.Properties.ShowMenu = false;
            this.pictureEdit1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom;
            this.pictureEdit1.Size = new System.Drawing.Size(20, 20);
            this.pictureEdit1.TabIndex = 0;
            // 
            // textEdit1
            // 
            this.textEdit1.EditValue = "";
            this.textEdit1.Location = new System.Drawing.Point(45, 15);
            this.textEdit1.Name = "textEdit1";
            this.textEdit1.Properties.Appearance.BackColor = System.Drawing.Color.DimGray;
            this.textEdit1.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textEdit1.Properties.Appearance.ForeColor = System.Drawing.Color.Silver;
            this.textEdit1.Properties.Appearance.Options.UseBackColor = true;
            this.textEdit1.Properties.Appearance.Options.UseFont = true;
            this.textEdit1.Properties.Appearance.Options.UseForeColor = true;
            this.textEdit1.Properties.Appearance.Options.UseTextOptions = true;
            this.textEdit1.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.textEdit1.Properties.AutoHeight = false;
            this.textEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.textEdit1.Properties.Tag = "";
            this.textEdit1.Size = new System.Drawing.Size(274, 26);
            this.textEdit1.TabIndex = 1;
            this.textEdit1.EditValueChanged += new System.EventHandler(this.textEdit1_EditValueChanged);
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
            this.btn_new.Location = new System.Drawing.Point(1102, 8);
            this.btn_new.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.btn_new.Name = "btn_new";
            this.btn_new.Size = new System.Drawing.Size(109, 40);
            this.btn_new.TabIndex = 2;
            this.btn_new.Text = "Novo";
            this.btn_new.Click += new System.EventHandler(this.btn_new_Click);
            // 
            // panel_control_top
            // 
            this.panel_control_top.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.panel_control_top.Appearance.Options.UseBackColor = true;
            this.panel_control_top.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panel_control_top.Controls.Add(this.btn_new);
            this.panel_control_top.Controls.Add(this.textEdit1);
            this.panel_control_top.Controls.Add(this.pictureEdit1);
            this.panel_control_top.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_control_top.Location = new System.Drawing.Point(0, 0);
            this.panel_control_top.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.panel_control_top.LookAndFeel.UseDefaultLookAndFeel = false;
            this.panel_control_top.Name = "panel_control_top";
            this.panel_control_top.Size = new System.Drawing.Size(1223, 56);
            this.panel_control_top.TabIndex = 0;
            // 
            // panel_control_buttons
            // 
            this.panel_control_buttons.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.panel_control_buttons.Appearance.Options.UseBackColor = true;
            this.panel_control_buttons.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panel_control_buttons.Controls.Add(this.btn_menu_back);
            this.panel_control_buttons.Controls.Add(this.btn_trash);
            this.panel_control_buttons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel_control_buttons.Location = new System.Drawing.Point(0, 497);
            this.panel_control_buttons.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.panel_control_buttons.LookAndFeel.UseDefaultLookAndFeel = false;
            this.panel_control_buttons.Name = "panel_control_buttons";
            this.panel_control_buttons.Size = new System.Drawing.Size(1223, 56);
            this.panel_control_buttons.TabIndex = 2;
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
            this.btn_menu_back.Location = new System.Drawing.Point(1099, 8);
            this.btn_menu_back.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.btn_menu_back.Name = "btn_menu_back";
            this.btn_menu_back.Size = new System.Drawing.Size(112, 40);
            this.btn_menu_back.TabIndex = 1;
            this.btn_menu_back.Text = "Voltar  ";
            this.btn_menu_back.Click += new System.EventHandler(this.btn_menu_back_Click);
            // 
            // btn_trash
            // 
            this.btn_trash.AllowFocus = false;
            this.btn_trash.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.btn_trash.Appearance.BackColor2 = System.Drawing.Color.Transparent;
            this.btn_trash.Appearance.BorderColor = System.Drawing.Color.Transparent;
            this.btn_trash.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_trash.Appearance.ForeColor = System.Drawing.Color.White;
            this.btn_trash.Appearance.Options.UseBackColor = true;
            this.btn_trash.Appearance.Options.UseBorderColor = true;
            this.btn_trash.Appearance.Options.UseFont = true;
            this.btn_trash.Appearance.Options.UseForeColor = true;
            this.btn_trash.AppearanceHovered.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(207)))), ((int)(((byte)(244)))));
            this.btn_trash.AppearanceHovered.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.btn_trash.AppearanceHovered.Options.UseBackColor = true;
            this.btn_trash.AppearanceHovered.Options.UseBorderColor = true;
            this.btn_trash.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.btn_trash.ImageOptions.Image = global::Chef_Plus.Properties.Resources.printer;
            this.btn_trash.Location = new System.Drawing.Point(12, 8);
            this.btn_trash.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.btn_trash.Name = "btn_trash";
            this.btn_trash.Size = new System.Drawing.Size(109, 40);
            this.btn_trash.TabIndex = 0;
            this.btn_trash.Text = "Imprimir";
            this.btn_trash.Click += new System.EventHandler(this.btn_trash_Click);
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 56);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1223, 441);
            this.gridControl1.TabIndex = 1;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.id,
            this.nome,
            this.telefone,
            this.celular,
            this.endereco,
            this.numero,
            this.saldo});
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
            this.gridView1.DoubleClick += new System.EventHandler(this.gridView1_DoubleClick);
            // 
            // id
            // 
            this.id.Caption = "Cód. Sistema";
            this.id.FieldName = "id";
            this.id.Name = "id";
            this.id.Width = 79;
            // 
            // nome
            // 
            this.nome.Caption = "Nome";
            this.nome.FieldName = "nome";
            this.nome.Name = "nome";
            this.nome.Visible = true;
            this.nome.VisibleIndex = 0;
            this.nome.Width = 183;
            // 
            // telefone
            // 
            this.telefone.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.telefone.AppearanceCell.Options.UseFont = true;
            this.telefone.Caption = "Telefone Principal";
            this.telefone.FieldName = "celular";
            this.telefone.Name = "telefone";
            this.telefone.Visible = true;
            this.telefone.VisibleIndex = 1;
            this.telefone.Width = 82;
            // 
            // celular
            // 
            this.celular.Caption = "Telefone Secundário";
            this.celular.FieldName = "telefone";
            this.celular.Name = "celular";
            this.celular.Visible = true;
            this.celular.VisibleIndex = 2;
            this.celular.Width = 80;
            // 
            // endereco
            // 
            this.endereco.Caption = "Endereço";
            this.endereco.FieldName = "endereco";
            this.endereco.Name = "endereco";
            this.endereco.Visible = true;
            this.endereco.VisibleIndex = 3;
            this.endereco.Width = 208;
            // 
            // numero
            // 
            this.numero.Caption = "Número";
            this.numero.FieldName = "numero";
            this.numero.Name = "numero";
            this.numero.Visible = true;
            this.numero.VisibleIndex = 4;
            this.numero.Width = 56;
            // 
            // saldo
            // 
            this.saldo.Caption = "Saldo Atual";
            this.saldo.FieldName = "saldo";
            this.saldo.Name = "saldo";
            this.saldo.Visible = true;
            this.saldo.VisibleIndex = 5;
            this.saldo.Width = 99;
            // 
            // frm_clientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1223, 553);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.panel_control_buttons);
            this.Controls.Add(this.panel_control_top);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_clientes";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Clientes";
            this.Load += new System.EventHandler(this.frm_clientes_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frm_clientes_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panel_control_top)).EndInit();
            this.panel_control_top.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panel_control_buttons)).EndInit();
            this.panel_control_buttons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.PictureEdit pictureEdit1;
        private DevExpress.XtraEditors.TextEdit textEdit1;
        private DevExpress.XtraEditors.SimpleButton btn_new;
        private DevExpress.XtraEditors.PanelControl panel_control_top;
        private DevExpress.XtraEditors.PanelControl panel_control_buttons;
        private DevExpress.XtraEditors.SimpleButton btn_menu_back;
        private DevExpress.XtraEditors.SimpleButton btn_trash;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn id;
        private DevExpress.XtraGrid.Columns.GridColumn nome;
        private DevExpress.XtraGrid.Columns.GridColumn telefone;
        private DevExpress.XtraGrid.Columns.GridColumn celular;
        private DevExpress.XtraGrid.Columns.GridColumn endereco;
        private DevExpress.XtraGrid.Columns.GridColumn numero;
        private DevExpress.XtraGrid.Columns.GridColumn saldo;
    }
}