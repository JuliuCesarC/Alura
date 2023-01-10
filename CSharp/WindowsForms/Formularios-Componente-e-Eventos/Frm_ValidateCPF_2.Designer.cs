namespace Formularios_Componente_e_Eventos
{
  partial class Frm_ValidateCPF_2
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
      this.msk_textCPF = new System.Windows.Forms.MaskedTextBox();
      this.btn_clear = new System.Windows.Forms.Button();
      this.btn_validate = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // msk_textCPF
      // 
      this.msk_textCPF.Location = new System.Drawing.Point(50, 100);
      this.msk_textCPF.Mask = "000,000,000-00";
      this.msk_textCPF.Name = "msk_textCPF";
      this.msk_textCPF.Size = new System.Drawing.Size(650, 39);
      this.msk_textCPF.TabIndex = 0;
      // 
      // btn_clear
      // 
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
      this.btn_validate.Location = new System.Drawing.Point(728, 180);
      this.btn_validate.Name = "btn_validate";
      this.btn_validate.Size = new System.Drawing.Size(215, 50);
      this.btn_validate.TabIndex = 2;
      this.btn_validate.Text = "Validar";
      this.btn_validate.UseVisualStyleBackColor = true;
      this.btn_validate.Click += new System.EventHandler(this.btn_validate_Click);
      // 
      // Frm_ValidateCPF_2
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(974, 379);
      this.Controls.Add(this.btn_validate);
      this.Controls.Add(this.btn_clear);
      this.Controls.Add(this.msk_textCPF);
      this.Name = "Frm_ValidateCPF_2";
      this.Text = "Validação de CPF";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private MaskedTextBox msk_textCPF;
    private Button btn_clear;
    private Button btn_validate;
  }
}