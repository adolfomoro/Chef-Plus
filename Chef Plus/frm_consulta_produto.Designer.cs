namespace Chef_Plus
{
    partial class frm_consulta_produto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_consulta_produto));
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.textEdit1 = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.btn_menu_back = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.textEdit2 = new DevExpress.XtraEditors.TextEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.textEdit3 = new DevExpress.XtraEditors.TextEdit();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.textEdit4 = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit3.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit4.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.Gray;
            this.labelControl1.Appearance.Options.UseForeColor = true;
            this.labelControl1.Appearance.Options.UseTextOptions = true;
            this.labelControl1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelControl1.Location = new System.Drawing.Point(0, 0);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(763, 22);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "PESQUISA POR CÓDIGO INTERNO";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.ForeColor = System.Drawing.Color.White;
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Appearance.Options.UseForeColor = true;
            this.labelControl2.Location = new System.Drawing.Point(12, 34);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(41, 13);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "Código:";
            // 
            // textEdit1
            // 
            this.textEdit1.EditValue = "";
            this.textEdit1.Location = new System.Drawing.Point(12, 53);
            this.textEdit1.Name = "textEdit1";
            this.textEdit1.Properties.AllowFocused = false;
            this.textEdit1.Properties.Appearance.BackColor = System.Drawing.Color.DimGray;
            this.textEdit1.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textEdit1.Properties.Appearance.ForeColor = System.Drawing.Color.White;
            this.textEdit1.Properties.Appearance.Options.UseBackColor = true;
            this.textEdit1.Properties.Appearance.Options.UseFont = true;
            this.textEdit1.Properties.Appearance.Options.UseForeColor = true;
            this.textEdit1.Properties.Appearance.Options.UseTextOptions = true;
            this.textEdit1.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.textEdit1.Properties.AppearanceFocused.Options.UseTextOptions = true;
            this.textEdit1.Properties.AppearanceFocused.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.textEdit1.Properties.AutoHeight = false;
            this.textEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.textEdit1.Properties.MaxLength = 35;
            this.textEdit1.Size = new System.Drawing.Size(94, 27);
            this.textEdit1.TabIndex = 2;
            this.textEdit1.EditValueChanged += new System.EventHandler(this.textEdit1_EditValueChanged);
            this.textEdit1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textEdit1_KeyPress);
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.Appearance.ForeColor = System.Drawing.Color.IndianRed;
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Appearance.Options.UseForeColor = true;
            this.labelControl3.Appearance.Options.UseTextOptions = true;
            this.labelControl3.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labelControl3.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl3.Location = new System.Drawing.Point(112, 53);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(339, 27);
            this.labelControl3.TabIndex = 3;
            this.labelControl3.Text = "Produto não encontrado";
            // 
            // btn_menu_back
            // 
            this.btn_menu_back.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
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
            this.btn_menu_back.Location = new System.Drawing.Point(639, 91);
            this.btn_menu_back.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.btn_menu_back.Name = "btn_menu_back";
            this.btn_menu_back.Size = new System.Drawing.Size(112, 40);
            this.btn_menu_back.TabIndex = 10;
            this.btn_menu_back.Text = "Voltar  ";
            this.btn_menu_back.Click += new System.EventHandler(this.btn_menu_back_Click);
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl4.Appearance.ForeColor = System.Drawing.Color.White;
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Appearance.Options.UseForeColor = true;
            this.labelControl4.Location = new System.Drawing.Point(557, 34);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(68, 13);
            this.labelControl4.TabIndex = 6;
            this.labelControl4.Text = "Quantidade:";
            this.labelControl4.Visible = false;
            // 
            // textEdit2
            // 
            this.textEdit2.EditValue = "1";
            this.textEdit2.Location = new System.Drawing.Point(557, 53);
            this.textEdit2.Name = "textEdit2";
            this.textEdit2.Properties.AllowFocused = false;
            this.textEdit2.Properties.Appearance.BackColor = System.Drawing.Color.DimGray;
            this.textEdit2.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textEdit2.Properties.Appearance.ForeColor = System.Drawing.Color.White;
            this.textEdit2.Properties.Appearance.Options.UseBackColor = true;
            this.textEdit2.Properties.Appearance.Options.UseFont = true;
            this.textEdit2.Properties.Appearance.Options.UseForeColor = true;
            this.textEdit2.Properties.Appearance.Options.UseTextOptions = true;
            this.textEdit2.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.textEdit2.Properties.AutoHeight = false;
            this.textEdit2.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.textEdit2.Properties.MaxLength = 10;
            this.textEdit2.Size = new System.Drawing.Size(94, 27);
            this.textEdit2.TabIndex = 7;
            this.textEdit2.Visible = false;
            this.textEdit2.EditValueChanged += new System.EventHandler(this.textEdit2_EditValueChanged);
            this.textEdit2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textEdit2_KeyPress);
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl5.Appearance.ForeColor = System.Drawing.Color.White;
            this.labelControl5.Appearance.Options.UseFont = true;
            this.labelControl5.Appearance.Options.UseForeColor = true;
            this.labelControl5.Location = new System.Drawing.Point(457, 34);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(32, 13);
            this.labelControl5.TabIndex = 4;
            this.labelControl5.Text = "Valor:";
            this.labelControl5.Visible = false;
            // 
            // textEdit3
            // 
            this.textEdit3.EditValue = "0,00";
            this.textEdit3.Enabled = false;
            this.textEdit3.Location = new System.Drawing.Point(457, 53);
            this.textEdit3.Name = "textEdit3";
            this.textEdit3.Properties.AllowFocused = false;
            this.textEdit3.Properties.Appearance.BackColor = System.Drawing.Color.DimGray;
            this.textEdit3.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textEdit3.Properties.Appearance.ForeColor = System.Drawing.Color.White;
            this.textEdit3.Properties.Appearance.Options.UseBackColor = true;
            this.textEdit3.Properties.Appearance.Options.UseFont = true;
            this.textEdit3.Properties.Appearance.Options.UseForeColor = true;
            this.textEdit3.Properties.Appearance.Options.UseTextOptions = true;
            this.textEdit3.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.textEdit3.Properties.AutoHeight = false;
            this.textEdit3.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.textEdit3.Properties.MaxLength = 10;
            this.textEdit3.Size = new System.Drawing.Size(94, 27);
            this.textEdit3.TabIndex = 5;
            this.textEdit3.Visible = false;
            // 
            // labelControl6
            // 
            this.labelControl6.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl6.Appearance.ForeColor = System.Drawing.Color.White;
            this.labelControl6.Appearance.Options.UseFont = true;
            this.labelControl6.Appearance.Options.UseForeColor = true;
            this.labelControl6.Location = new System.Drawing.Point(657, 34);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(32, 13);
            this.labelControl6.TabIndex = 8;
            this.labelControl6.Text = "Total:";
            this.labelControl6.Visible = false;
            // 
            // textEdit4
            // 
            this.textEdit4.EditValue = "0,00";
            this.textEdit4.Enabled = false;
            this.textEdit4.Location = new System.Drawing.Point(657, 53);
            this.textEdit4.Name = "textEdit4";
            this.textEdit4.Properties.AllowFocused = false;
            this.textEdit4.Properties.Appearance.BackColor = System.Drawing.Color.DimGray;
            this.textEdit4.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textEdit4.Properties.Appearance.ForeColor = System.Drawing.Color.White;
            this.textEdit4.Properties.Appearance.Options.UseBackColor = true;
            this.textEdit4.Properties.Appearance.Options.UseFont = true;
            this.textEdit4.Properties.Appearance.Options.UseForeColor = true;
            this.textEdit4.Properties.Appearance.Options.UseTextOptions = true;
            this.textEdit4.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.textEdit4.Properties.AutoHeight = false;
            this.textEdit4.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.textEdit4.Properties.MaxLength = 10;
            this.textEdit4.Size = new System.Drawing.Size(94, 27);
            this.textEdit4.TabIndex = 9;
            this.textEdit4.Visible = false;
            // 
            // frm_consulta_produto
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(65)))));
            this.Appearance.Options.UseBackColor = true;
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(763, 143);
            this.ControlBox = false;
            this.Controls.Add(this.labelControl6);
            this.Controls.Add(this.textEdit4);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.textEdit3);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.textEdit2);
            this.Controls.Add(this.btn_menu_back);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.textEdit1);
            this.Controls.Add(this.labelControl1);
            this.Font = new System.Drawing.Font("Segoe UI Symbol", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "frm_consulta_produto";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frm_consulta_produto_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frm_consulta_produto_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit3.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit4.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit textEdit1;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.SimpleButton btn_menu_back;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.TextEdit textEdit2;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.TextEdit textEdit3;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.TextEdit textEdit4;
    }
}