namespace Formularios_Componente_e_Eventos
{
  partial class Frm_CheckPassword
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
      this.lbl_grade = new System.Windows.Forms.Label();
      this.txt_password = new System.Windows.Forms.TextBox();
      this.btn_clear = new System.Windows.Forms.Button();
      this.lbl_title = new System.Windows.Forms.Label();
      this.btn_showPassword = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // lbl_grade
      // 
      this.lbl_grade.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.lbl_grade.Font = new System.Drawing.Font("Segoe UI Black", 16.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.lbl_grade.Location = new System.Drawing.Point(35, 226);
      this.lbl_grade.Name = "lbl_grade";
      this.lbl_grade.Size = new System.Drawing.Size(289, 67);
      this.lbl_grade.TabIndex = 0;
      // 
      // txt_password
      // 
      this.txt_password.Location = new System.Drawing.Point(35, 150);
      this.txt_password.Name = "txt_password";
      this.txt_password.PasswordChar = '*';
      this.txt_password.PlaceholderText = "Digite uma senha...";
      this.txt_password.Size = new System.Drawing.Size(594, 39);
      this.txt_password.TabIndex = 1;
      this.txt_password.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_password_KeyDown);
      // 
      // btn_clear
      // 
      this.btn_clear.Location = new System.Drawing.Point(673, 146);
      this.btn_clear.Name = "btn_clear";
      this.btn_clear.Size = new System.Drawing.Size(294, 46);
      this.btn_clear.TabIndex = 2;
      this.btn_clear.Text = "Limpar";
      this.btn_clear.UseVisualStyleBackColor = true;
      this.btn_clear.Click += new System.EventHandler(this.btn_clear_Click);
      // 
      // lbl_title
      // 
      this.lbl_title.AutoSize = true;
      this.lbl_title.Font = new System.Drawing.Font("Arial Narrow", 13.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.lbl_title.Location = new System.Drawing.Point(92, 58);
      this.lbl_title.Name = "lbl_title";
      this.lbl_title.Size = new System.Drawing.Size(417, 43);
      this.lbl_title.TabIndex = 3;
      this.lbl_title.Text = "Testador de força de senha";
      // 
      // btn_showPassword
      // 
      this.btn_showPassword.Location = new System.Drawing.Point(673, 207);
      this.btn_showPassword.Name = "btn_showPassword";
      this.btn_showPassword.Size = new System.Drawing.Size(294, 46);
      this.btn_showPassword.TabIndex = 4;
      this.btn_showPassword.Text = "Mostrar senha";
      this.btn_showPassword.UseVisualStyleBackColor = true;
      this.btn_showPassword.Click += new System.EventHandler(this.btn_verSenha_Click);
      // 
      // CheckPassword
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1002, 351);
      this.Controls.Add(this.btn_showPassword);
      this.Controls.Add(this.lbl_title);
      this.Controls.Add(this.btn_clear);
      this.Controls.Add(this.txt_password);
      this.Controls.Add(this.lbl_grade);
      this.Name = "CheckPassword";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Força da senha";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private Label lbl_grade;
    private TextBox txt_password;
    private Button btn_clear;
    private Label lbl_title;
    private Button btn_showPassword;
  }
}