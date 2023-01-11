namespace Formularios_Componente_e_Eventos
{
  partial class Frm_Mask
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Mask));
      this.msk_textBox = new System.Windows.Forms.MaskedTextBox();
      this.btn_hour = new System.Windows.Forms.Button();
      this.btn_currency = new System.Windows.Forms.Button();
      this.btn_CEP = new System.Windows.Forms.Button();
      this.btn_password = new System.Windows.Forms.Button();
      this.btn_phoneNumber = new System.Windows.Forms.Button();
      this.btn_date = new System.Windows.Forms.Button();
      this.btn_showPassword = new System.Windows.Forms.Button();
      this.lbl_format = new System.Windows.Forms.Label();
      this.lbl_content = new System.Windows.Forms.Label();
      this.SuspendLayout();
      // 
      // msk_textBox
      // 
      this.msk_textBox.Location = new System.Drawing.Point(60, 48);
      this.msk_textBox.Name = "msk_textBox";
      this.msk_textBox.Size = new System.Drawing.Size(750, 39);
      this.msk_textBox.TabIndex = 1;
      // 
      // btn_hour
      // 
      this.btn_hour.Location = new System.Drawing.Point(60, 206);
      this.btn_hour.Name = "btn_hour";
      this.btn_hour.Size = new System.Drawing.Size(240, 75);
      this.btn_hour.TabIndex = 2;
      this.btn_hour.Text = "Hora";
      this.btn_hour.UseVisualStyleBackColor = true;
      this.btn_hour.Click += new System.EventHandler(this.btn_hour_Click);
      // 
      // btn_currency
      // 
      this.btn_currency.Location = new System.Drawing.Point(570, 206);
      this.btn_currency.Name = "btn_currency";
      this.btn_currency.Size = new System.Drawing.Size(240, 75);
      this.btn_currency.TabIndex = 3;
      this.btn_currency.Text = "Moeda";
      this.btn_currency.UseVisualStyleBackColor = true;
      this.btn_currency.Click += new System.EventHandler(this.btn_currency_Click);
      // 
      // btn_CEP
      // 
      this.btn_CEP.Location = new System.Drawing.Point(315, 206);
      this.btn_CEP.Name = "btn_CEP";
      this.btn_CEP.Size = new System.Drawing.Size(240, 75);
      this.btn_CEP.TabIndex = 4;
      this.btn_CEP.Text = "CEP";
      this.btn_CEP.UseVisualStyleBackColor = true;
      this.btn_CEP.Click += new System.EventHandler(this.btn_CEP_Click);
      // 
      // btn_password
      // 
      this.btn_password.Location = new System.Drawing.Point(315, 301);
      this.btn_password.Name = "btn_password";
      this.btn_password.Size = new System.Drawing.Size(240, 75);
      this.btn_password.TabIndex = 7;
      this.btn_password.Text = "Senha";
      this.btn_password.UseVisualStyleBackColor = true;
      this.btn_password.Click += new System.EventHandler(this.btn_password_Click);
      // 
      // btn_phoneNumber
      // 
      this.btn_phoneNumber.Location = new System.Drawing.Point(570, 301);
      this.btn_phoneNumber.Name = "btn_phoneNumber";
      this.btn_phoneNumber.Size = new System.Drawing.Size(240, 75);
      this.btn_phoneNumber.TabIndex = 6;
      this.btn_phoneNumber.Text = "Telefone";
      this.btn_phoneNumber.UseVisualStyleBackColor = true;
      this.btn_phoneNumber.Click += new System.EventHandler(this.btn_phoneNumber_Click);
      // 
      // btn_date
      // 
      this.btn_date.Location = new System.Drawing.Point(60, 301);
      this.btn_date.Name = "btn_date";
      this.btn_date.Size = new System.Drawing.Size(240, 75);
      this.btn_date.TabIndex = 5;
      this.btn_date.Text = "Data";
      this.btn_date.UseVisualStyleBackColor = true;
      this.btn_date.Click += new System.EventHandler(this.btn_date_Click);
      // 
      // btn_showPassword
      // 
      this.btn_showPassword.Location = new System.Drawing.Point(60, 396);
      this.btn_showPassword.Name = "btn_showPassword";
      this.btn_showPassword.Size = new System.Drawing.Size(750, 75);
      this.btn_showPassword.TabIndex = 8;
      this.btn_showPassword.Text = "Mostrar Conteúdo";
      this.btn_showPassword.UseVisualStyleBackColor = true;
      this.btn_showPassword.Click += new System.EventHandler(this.btn_showPassword_Click);
      // 
      // lbl_format
      // 
      this.lbl_format.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.lbl_format.Font = new System.Drawing.Font("Segoe UI Black", 13.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.lbl_format.Location = new System.Drawing.Point(60, 103);
      this.lbl_format.Name = "lbl_format";
      this.lbl_format.Size = new System.Drawing.Size(373, 64);
      this.lbl_format.TabIndex = 10;
      // 
      // lbl_content
      // 
      this.lbl_content.Font = new System.Drawing.Font("Segoe UI Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.lbl_content.Location = new System.Drawing.Point(60, 514);
      this.lbl_content.Name = "lbl_content";
      this.lbl_content.Size = new System.Drawing.Size(750, 64);
      this.lbl_content.TabIndex = 11;
      // 
      // Frm_Mask
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(874, 629);
      this.Controls.Add(this.lbl_content);
      this.Controls.Add(this.lbl_format);
      this.Controls.Add(this.btn_showPassword);
      this.Controls.Add(this.btn_password);
      this.Controls.Add(this.btn_phoneNumber);
      this.Controls.Add(this.btn_date);
      this.Controls.Add(this.btn_CEP);
      this.Controls.Add(this.btn_currency);
      this.Controls.Add(this.btn_hour);
      this.Controls.Add(this.msk_textBox);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.MaximizeBox = false;
      this.Name = "Frm_Mask";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Frm_Mask";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion
    private MaskedTextBox msk_textBox;
    private Button btn_hour;
    private Button btn_currency;
    private Button btn_CEP;
    private Button btn_password;
    private Button btn_phoneNumber;
    private Button btn_date;
    private Button btn_showPassword;
    private Label lbl_format;
    private Label lbl_content;
  }
}