namespace Formularios_Componente_e_Eventos
{
  partial class Frm_Principal
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
      this.btn_KeyDown = new System.Windows.Forms.Button();
      this.bnt_Hello = new System.Windows.Forms.Button();
      this.btn_Mask = new System.Windows.Forms.Button();
      this.btn_VPassword = new System.Windows.Forms.Button();
      this.btn_VCPF2 = new System.Windows.Forms.Button();
      this.btn_VCPF = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // btn_KeyDown
      // 
      this.btn_KeyDown.Location = new System.Drawing.Point(12, 12);
      this.btn_KeyDown.Name = "btn_KeyDown";
      this.btn_KeyDown.Size = new System.Drawing.Size(250, 100);
      this.btn_KeyDown.TabIndex = 0;
      this.btn_KeyDown.Text = "Demonstração KeyDown";
      this.btn_KeyDown.UseVisualStyleBackColor = true;
      this.btn_KeyDown.Click += new System.EventHandler(this.btn_KeyDown_Click);
      // 
      // bnt_Hello
      // 
      this.bnt_Hello.Location = new System.Drawing.Point(274, 12);
      this.bnt_Hello.Name = "bnt_Hello";
      this.bnt_Hello.Size = new System.Drawing.Size(250, 100);
      this.bnt_Hello.TabIndex = 1;
      this.bnt_Hello.Text = "Hello World";
      this.bnt_Hello.UseVisualStyleBackColor = true;
      this.bnt_Hello.Click += new System.EventHandler(this.bnt_Hello_Click);
      // 
      // btn_Mask
      // 
      this.btn_Mask.Location = new System.Drawing.Point(540, 12);
      this.btn_Mask.Name = "btn_Mask";
      this.btn_Mask.Size = new System.Drawing.Size(250, 100);
      this.btn_Mask.TabIndex = 2;
      this.btn_Mask.Text = "Mascara";
      this.btn_Mask.UseVisualStyleBackColor = true;
      this.btn_Mask.Click += new System.EventHandler(this.btn_Mask_Click);
      // 
      // btn_VPassword
      // 
      this.btn_VPassword.Location = new System.Drawing.Point(540, 127);
      this.btn_VPassword.Name = "btn_VPassword";
      this.btn_VPassword.Size = new System.Drawing.Size(250, 100);
      this.btn_VPassword.TabIndex = 5;
      this.btn_VPassword.Text = "Valida Senha";
      this.btn_VPassword.UseVisualStyleBackColor = true;
      this.btn_VPassword.Click += new System.EventHandler(this.btn_VPassword_Click);
      // 
      // btn_VCPF2
      // 
      this.btn_VCPF2.Location = new System.Drawing.Point(274, 127);
      this.btn_VCPF2.Name = "btn_VCPF2";
      this.btn_VCPF2.Size = new System.Drawing.Size(250, 100);
      this.btn_VCPF2.TabIndex = 4;
      this.btn_VCPF2.Text = "Valida CPF 2";
      this.btn_VCPF2.UseVisualStyleBackColor = true;
      this.btn_VCPF2.Click += new System.EventHandler(this.btn_VCPF2_Click);
      // 
      // btn_VCPF
      // 
      this.btn_VCPF.Location = new System.Drawing.Point(12, 127);
      this.btn_VCPF.Name = "btn_VCPF";
      this.btn_VCPF.Size = new System.Drawing.Size(250, 100);
      this.btn_VCPF.TabIndex = 3;
      this.btn_VCPF.Text = "Valida CPF";
      this.btn_VCPF.UseVisualStyleBackColor = true;
      this.btn_VCPF.Click += new System.EventHandler(this.btn_VCPF_Click);
      // 
      // Frm_Principal
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(802, 239);
      this.Controls.Add(this.btn_VPassword);
      this.Controls.Add(this.btn_VCPF2);
      this.Controls.Add(this.btn_VCPF);
      this.Controls.Add(this.btn_Mask);
      this.Controls.Add(this.bnt_Hello);
      this.Controls.Add(this.btn_KeyDown);
      this.Name = "Frm_Principal";
      this.Text = "Frm_Principal";
      this.ResumeLayout(false);

    }

    #endregion

    private Button btn_KeyDown;
    private Button bnt_Hello;
    private Button btn_Mask;
    private Button btn_VPassword;
    private Button btn_VCPF2;
    private Button btn_VCPF;
  }
}