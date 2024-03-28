namespace Chef_Plus
{
    partial class UserControl_Complementos
    {
        /// <summary> 
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Designer de Componentes

        /// <summary> 
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.checkEdit1 = new DevExpress.XtraEditors.CheckEdit();
            this.spinEdit1 = new DevExpress.XtraEditors.SpinEdit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // checkEdit1
            // 
            this.checkEdit1.Location = new System.Drawing.Point(7, 7);
            this.checkEdit1.Name = "checkEdit1";
            this.checkEdit1.Properties.AllowHtmlDraw = DevExpress.Utils.DefaultBoolean.True;
            this.checkEdit1.Properties.Caption = "Complemtno";
            this.checkEdit1.Size = new System.Drawing.Size(220, 19);
            this.checkEdit1.TabIndex = 1;
            this.checkEdit1.CheckedChanged += new System.EventHandler(this.checkEdit1_CheckedChanged);
            this.checkEdit1.CheckStateChanged += new System.EventHandler(this.checkEdit1_CheckStateChanged);
            // 
            // spinEdit1
            // 
            this.spinEdit1.EditValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.spinEdit1.Location = new System.Drawing.Point(248, 7);
            this.spinEdit1.Name = "spinEdit1";
            this.spinEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinEdit1.Properties.DisplayFormat.FormatString = "N00";
            this.spinEdit1.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Default;
            this.spinEdit1.Properties.IsFloatValue = false;
            this.spinEdit1.Properties.Mask.EditMask = "N00";
            this.spinEdit1.Properties.MaxValue = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.spinEdit1.Properties.MinValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.spinEdit1.Size = new System.Drawing.Size(50, 20);
            this.spinEdit1.TabIndex = 2;
            this.spinEdit1.Visible = false;
            this.spinEdit1.EditValueChanged += new System.EventHandler(this.spinEdit1_EditValueChanged);
            this.spinEdit1.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(this.spinEdit1_EditValueChanging);
            // 
            // UserControl_Complementos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.spinEdit1);
            this.Controls.Add(this.checkEdit1);
            this.Name = "UserControl_Complementos";
            this.Size = new System.Drawing.Size(312, 33);
            this.Load += new System.EventHandler(this.UserControl_Complementos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit1.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.CheckEdit checkEdit1;
        private DevExpress.XtraEditors.SpinEdit spinEdit1;
    }
}
