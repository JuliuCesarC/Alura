namespace Formularios_Componente_e_Eventos
{
  partial class Frm_ValidateCPF
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
      if( disposing && (components != null) )
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_ValidateCPF));
      this.msk_textCPF = new System.Windows.Forms.MaskedTextBox();
      this.btn_clear = new System.Windows.Forms.Button();
      this.btn_validate = new System.Windows.Forms.Button();
      this.lbl_result = new System.Windows.Forms.Label();
      this.SuspendLayout();
      // 
      // msk_textCPF
      // 
      this.msk_textCPF.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.msk_textCPF.Location = new System.Drawing.Point(50, 100);
      this.msk_textCPF.Mask = "000,000,000-00";
      this.msk_textCPF.Name = "msk_textCPF";
      this.msk_textCPF.Size = new System.Drawing.Size(650, 39);
      this.msk_textCPF.TabIndex = 0;
      // 
      // btn_clear
      // 
      this.btn_clear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btn_clear.Location = new System.Drawing.Point(728, 94);
      this.btn_clear.Name = "btn_clear";
      this.btn_clear.Size = new System.Drawing.Size(215, 50);
      this.btn_clear.TabIndex = 1;
      this.btn_clear.Text = "Limpar";
      this.btn_clear.UseVisualStyleBackColor = true;
      this.btn_clear.Click += new System.EventHandler(this.btn_clear_Click);
      // 
      // btn_validate
      // 
      this.btn_validate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btn_validate.Location = new System.Drawing.Point(728, 180);
      this.btn_validate.Name = "btn_validate";
      this.btn_validate.Size = new System.Drawing.Size(215, 50);
      this.btn_validate.TabIndex = 2;
      this.btn_validate.Text = "Validar";
      this.btn_validate.UseVisualStyleBackColor = true;
      this.btn_validate.Click += new System.EventHandler(this.btn_validate_Click);
      // 
      // lbl_result
      // 
      this.lbl_result.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.lbl_result.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.lbl_result.Font = new System.Drawing.Font("Segoe UI", 16.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.lbl_result.Location = new System.Drawing.Point(61, 217);
      this.lbl_result.Name = "lbl_result";
      this.lbl_result.Size = new System.Drawing.Size(326, 83);
      this.lbl_result.TabIndex = 3;
      // 
      // Frm_ValidateCPF
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(974, 379);
      this.Controls.Add(this.lbl_result);
      this.Controls.Add(this.btn_validate);
      this.Controls.Add(this.btn_clear);
      this.Controls.Add(this.msk_textCPF);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.MinimumSize = new System.Drawing.Size(700, 400);
      this.Name = "Frm_ValidateCPF";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Validação de CPF";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private MaskedTextBox msk_textCPF;
    private Button btn_clear;
    private Button btn_validate;
    private Label lbl_result;
  }
}