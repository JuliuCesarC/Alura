namespace Formularios_Componente_e_Eventos.FormsUserControl
{
  partial class Frm_CheckPassword_UC
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
      if( disposing && (components != null) )
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
      this.btn_showPassword = new System.Windows.Forms.Button();
      this.lbl_title = new System.Windows.Forms.Label();
      this.btn_clear = new System.Windows.Forms.Button();
      this.txt_password = new System.Windows.Forms.TextBox();
      this.lbl_grade = new System.Windows.Forms.Label();
      this.SuspendLayout();
      // 
      // btn_showPassword
      // 
      this.btn_showPassword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btn_showPassword.Location = new System.Drawing.Point(697, 210);
      this.btn_showPassword.Name = "btn_showPassword";
      this.btn_showPassword.Size = new System.Drawing.Size(294, 46);
      this.btn_showPassword.TabIndex = 9;
      this.btn_showPassword.Text = "Mostrar senha";
      this.btn_showPassword.UseVisualStyleBackColor = true;
      this.btn_showPassword.Click += new System.EventHandler(this.btn_showPassword_Click);
      // 
      // lbl_title
      // 
      this.lbl_title.AutoSize = true;
      this.lbl_title.Font = new System.Drawing.Font("Arial Narrow", 13.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.lbl_title.Location = new System.Drawing.Point(116, 61);
      this.lbl_title.Name = "lbl_title";
      this.lbl_title.Size = new System.Drawing.Size(417, 43);
      this.lbl_title.TabIndex = 8;
      this.lbl_title.Text = "Testador de força de senha";
      // 
      // btn_clear
      // 
      this.btn_clear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btn_clear.Location = new System.Drawing.Point(697, 149);
      this.btn_clear.Name = "btn_clear";
      this.btn_clear.Size = new System.Drawing.Size(294, 46);
      this.btn_clear.TabIndex = 7;
      this.btn_clear.Text = "Limpar";
      this.btn_clear.UseVisualStyleBackColor = true;
      this.btn_clear.Click += new System.EventHandler(this.btn_clear_Click);
      // 
      // txt_password
      // 
      this.txt_password.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.txt_password.Location = new System.Drawing.Point(59, 153);
      this.txt_password.Name = "txt_password";
      this.txt_password.PasswordChar = '*';
      this.txt_password.PlaceholderText = "Digite uma senha...";
      this.txt_password.Size = new System.Drawing.Size(594, 39);
      this.txt_password.TabIndex = 6;
      this.txt_password.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_password_KeyDown);
      // 
      // lbl_grade
      // 
      this.lbl_grade.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.lbl_grade.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.lbl_grade.Font = new System.Drawing.Font("Segoe UI Black", 16.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.lbl_grade.Location = new System.Drawing.Point(59, 257);
      this.lbl_grade.Name = "lbl_grade";
      this.lbl_grade.Size = new System.Drawing.Size(289, 67);
      this.lbl_grade.TabIndex = 5;
      // 
      // Frm_CheckPassword_UC
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.btn_showPassword);
      this.Controls.Add(this.lbl_title);
      this.Controls.Add(this.btn_clear);
      this.Controls.Add(this.txt_password);
      this.Controls.Add(this.lbl_grade);
      this.Name = "Frm_CheckPassword_UC";
      this.Size = new System.Drawing.Size(1061, 421);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private Button btn_showPassword;
    private Label lbl_title;
    private Button btn_clear;
    private TextBox txt_password;
    private Label lbl_grade;
  }
}
