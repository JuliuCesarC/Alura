namespace Formularios_Componente_e_Eventos
{
  partial class Frm_Login
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
      this.pic_login = new System.Windows.Forms.PictureBox();
      this.btn_cancel = new System.Windows.Forms.Button();
      this.btn_ok = new System.Windows.Forms.Button();
      this.lbl_login = new System.Windows.Forms.Label();
      this.lbl_password = new System.Windows.Forms.Label();
      this.txt_login = new System.Windows.Forms.TextBox();
      this.txt_password = new System.Windows.Forms.TextBox();
      ((System.ComponentModel.ISupportInitialize)(this.pic_login)).BeginInit();
      this.SuspendLayout();
      // 
      // pic_login
      // 
      this.pic_login.Image = global::Formularios_Componente_e_Eventos.Properties.Resources.key;
      this.pic_login.Location = new System.Drawing.Point(12, 12);
      this.pic_login.Name = "pic_login";
      this.pic_login.Size = new System.Drawing.Size(280, 280);
      this.pic_login.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
      this.pic_login.TabIndex = 0;
      this.pic_login.TabStop = false;
      // 
      // btn_cancel
      // 
      this.btn_cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.btn_cancel.Location = new System.Drawing.Point(12, 322);
      this.btn_cancel.Name = "btn_cancel";
      this.btn_cancel.Size = new System.Drawing.Size(150, 46);
      this.btn_cancel.TabIndex = 1;
      this.btn_cancel.Text = "Cancel";
      this.btn_cancel.UseVisualStyleBackColor = true;
      this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
      // 
      // btn_ok
      // 
      this.btn_ok.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.btn_ok.Location = new System.Drawing.Point(638, 322);
      this.btn_ok.Name = "btn_ok";
      this.btn_ok.Size = new System.Drawing.Size(150, 46);
      this.btn_ok.TabIndex = 2;
      this.btn_ok.Text = "OK";
      this.btn_ok.UseVisualStyleBackColor = true;
      this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
      // 
      // lbl_login
      // 
      this.lbl_login.AutoSize = true;
      this.lbl_login.Location = new System.Drawing.Point(309, 46);
      this.lbl_login.Name = "lbl_login";
      this.lbl_login.Size = new System.Drawing.Size(78, 32);
      this.lbl_login.TabIndex = 3;
      this.lbl_login.Text = "label1";
      // 
      // lbl_password
      // 
      this.lbl_password.AutoSize = true;
      this.lbl_password.Location = new System.Drawing.Point(309, 179);
      this.lbl_password.Name = "lbl_password";
      this.lbl_password.Size = new System.Drawing.Size(78, 32);
      this.lbl_password.TabIndex = 4;
      this.lbl_password.Text = "label2";
      // 
      // txt_login
      // 
      this.txt_login.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.txt_login.Location = new System.Drawing.Point(309, 90);
      this.txt_login.Name = "txt_login";
      this.txt_login.Size = new System.Drawing.Size(479, 39);
      this.txt_login.TabIndex = 5;
      // 
      // txt_password
      // 
      this.txt_password.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.txt_password.Location = new System.Drawing.Point(309, 225);
      this.txt_password.Name = "txt_password";
      this.txt_password.PasswordChar = '*';
      this.txt_password.Size = new System.Drawing.Size(479, 39);
      this.txt_password.TabIndex = 6;
      // 
      // Frm_Login
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(800, 380);
      this.Controls.Add(this.txt_password);
      this.Controls.Add(this.txt_login);
      this.Controls.Add(this.lbl_password);
      this.Controls.Add(this.lbl_login);
      this.Controls.Add(this.btn_ok);
      this.Controls.Add(this.btn_cancel);
      this.Controls.Add(this.pic_login);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
      this.Name = "Frm_Login";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Frm_Login";
      ((System.ComponentModel.ISupportInitialize)(this.pic_login)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private PictureBox pic_login;
    private Button btn_cancel;
    private Button btn_ok;
    private Label lbl_login;
    private Label lbl_password;
    private TextBox txt_login;
    private TextBox txt_password;
  }
}