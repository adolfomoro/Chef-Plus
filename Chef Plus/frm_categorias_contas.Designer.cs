using ChefPlus.core;

namespace Chef_Plus
{
    partial class frm_categorias_contas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_categorias_contas));
            this.panel_control_buttons = new DevExpress.XtraEditors.PanelControl();
            this.btn_menu_back = new DevExpress.XtraEditors.SimpleButton();
            this.panel_control_top = new DevExpress.XtraEditors.PanelControl();
            this.btn_new = new DevExpress.XtraEditors.SimpleButton();
            this.treeList1 = new DevExpress.XtraTreeList.TreeList();
            this.treeListColumn1 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            ((System.ComponentModel.ISupportInitialize)(this.panel_control_buttons)).BeginInit();
            this.panel_control_buttons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panel_control_top)).BeginInit();
            this.panel_control_top.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel_control_buttons
            // 
            this.panel_control_buttons.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.panel_control_buttons.Appearance.Options.UseBackColor = true;
            this.panel_control_buttons.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panel_control_buttons.Controls.Add(this.btn_menu_back);
            this.panel_control_buttons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel_control_buttons.Location = new System.Drawing.Point(0, 446);
            this.panel_control_buttons.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.panel_control_buttons.LookAndFeel.UseDefaultLookAndFeel = false;
            this.panel_control_buttons.Name = "panel_control_buttons";
            this.panel_control_buttons.Size = new System.Drawing.Size(553, 56);
            this.panel_control_buttons.TabIndex = 17;
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
            this.btn_menu_back.ImageOptions.Image = global::Chef_Plus.Properties.Resources.arrow_right;
            this.btn_menu_back.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.RightCenter;
            this.btn_menu_back.Location = new System.Drawing.Point(429, 8);
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
            this.panel_control_top.Controls.Add(this.btn_new);
            this.panel_control_top.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_control_top.Location = new System.Drawing.Point(0, 0);
            this.panel_control_top.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.panel_control_top.LookAndFeel.UseDefaultLookAndFeel = false;
            this.panel_control_top.Name = "panel_control_top";
            this.panel_control_top.Size = new System.Drawing.Size(553, 56);
            this.panel_control_top.TabIndex = 18;
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
            this.btn_new.Location = new System.Drawing.Point(432, 8);
            this.btn_new.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.btn_new.Name = "btn_new";
            this.btn_new.Size = new System.Drawing.Size(109, 40);
            this.btn_new.TabIndex = 10;
            this.btn_new.Text = "Novo";
            this.btn_new.Click += new System.EventHandler(this.btn_new_Click);
            // 
            // treeList1
            // 
            this.treeList1.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.treeListColumn1});
            this.treeList1.CustomizationFormBounds = new System.Drawing.Rectangle(645, 430, 210, 172);
            this.treeList1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeList1.KeyFieldName = "id";
            this.treeList1.Location = new System.Drawing.Point(0, 56);
            this.treeList1.Name = "treeList1";
            this.treeList1.OptionsBehavior.Editable = false;
            this.treeList1.OptionsBehavior.ReadOnly = true;
            this.treeList1.OptionsCustomization.AllowColumnMoving = false;
            this.treeList1.OptionsFind.AllowFindPanel = false;
            this.treeList1.OptionsFind.ShowClearButton = false;
            this.treeList1.OptionsFind.ShowCloseButton = false;
            this.treeList1.OptionsFind.ShowFindButton = false;
            this.treeList1.OptionsMenu.EnableColumnMenu = false;
            this.treeList1.OptionsMenu.EnableFooterMenu = false;
            this.treeList1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.treeList1.OptionsView.ShowIndicator = false;
            this.treeList1.ParentFieldName = "id_pai";
            this.treeList1.RowHeight = 26;
            this.treeList1.Size = new System.Drawing.Size(553, 390);
            this.treeList1.TabIndex = 19;
            this.treeList1.DoubleClick += new System.EventHandler(this.treeList1_DoubleClick);
            // 
            // treeListColumn1
            // 
            this.treeListColumn1.Caption = "Categorias de Contas";
            this.treeListColumn1.FieldName = "descricao";
            this.treeListColumn1.Name = "treeListColumn1";
            this.treeListColumn1.Visible = true;
            this.treeListColumn1.VisibleIndex = 0;
            // 
            // frm_categorias_contas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(553, 502);
            this.Controls.Add(this.treeList1);
            this.Controls.Add(this.panel_control_top);
            this.Controls.Add(this.panel_control_buttons);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_categorias_contas";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Categorias de Contas";
            this.Load += new System.EventHandler(this.frm_categorias_contas_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frm_categorias_contas_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.panel_control_buttons)).EndInit();
            this.panel_control_buttons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panel_control_top)).EndInit();
            this.panel_control_top.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panel_control_buttons;
        private DevExpress.XtraEditors.PanelControl panel_control_top;
        private DevExpress.XtraEditors.SimpleButton btn_new;
        private DevExpress.XtraEditors.SimpleButton btn_menu_back;
        private DevExpress.XtraTreeList.TreeList treeList1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn1;
    }
}