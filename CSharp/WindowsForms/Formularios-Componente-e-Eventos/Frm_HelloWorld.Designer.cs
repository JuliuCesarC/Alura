namespace Formularios_Componente_e_Eventos
{
  partial class Frm_HelloWorld
  {
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
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
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.lbl_Titulo = new System.Windows.Forms.Label();
      this.btn_sair = new System.Windows.Forms.Button();
      this.txt_conteudoLabel = new System.Windows.Forms.TextBox();
      this.btn_alteraTitulo = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // lbl_Titulo
      // 
      this.lbl_Titulo.AutoSize = true;
      this.lbl_Titulo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.lbl_Titulo.Location = new System.Drawing.Point(30, 30);
      this.lbl_Titulo.Name = "lbl_Titulo";
      this.lbl_Titulo.Size = new System.Drawing.Size(294, 45);
      this.lbl_Titulo.TabIndex = 0;
      this.lbl_Titulo.Text = "Visual Studio .NET";
      // 
      // btn_sair
      // 
      this.btn_sair.Location = new System.Drawing.Point(805, 618);
      this.btn_sair.Name = "btn_sair";
      this.btn_sair.Size = new System.Drawing.Size(200, 50);
      this.btn_sair.TabIndex = 1;
      this.btn_sair.Text = "Fechar";
      this.btn_sair.UseVisualStyleBackColor = true;
      this.btn_sair.Click += new System.EventHandler(this.btn_sair_Click);
      // 
      // txt_conteudoLabel
      // 
      this.txt_conteudoLabel.Location = new System.Drawing.Point(30, 90);
      this.txt_conteudoLabel.Name = "txt_conteudoLabel";
      this.txt_conteudoLabel.PlaceholderText = "Digite um texto...";
      this.txt_conteudoLabel.Size = new System.Drawing.Size(509, 39);
      this.txt_conteudoLabel.TabIndex = 2;
      // 
      // btn_alteraTitulo
      // 
      this.btn_alteraTitulo.Location = new System.Drawing.Point(30, 157);
      this.btn_alteraTitulo.Name = "btn_alteraTitulo";
      this.btn_alteraTitulo.Size = new System.Drawing.Size(294, 46);
      this.btn_alteraTitulo.TabIndex = 3;
      this.btn_alteraTitulo.Text = "Alterar titulo";
      this.btn_alteraTitulo.UseVisualStyleBackColor = true;
      this.btn_alteraTitulo.Click += new System.EventHandler(this.btn_alteraTitulo_Click);
      // 
      // Frm_HelloWorld
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1017, 680);
      this.Controls.Add(this.btn_alteraTitulo);
      this.Controls.Add(this.txt_conteudoLabel);
      this.Controls.Add(this.btn_sair);
      this.Controls.Add(this.lbl_Titulo);
      this.Name = "Frm_HelloWorld";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Form1";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private Label lbl_Titulo;
    private Button btn_sair;
    private TextBox txt_conteudoLabel;
    private Button btn_alteraTitulo;
  }
}