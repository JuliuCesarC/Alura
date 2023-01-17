namespace Formularios_Componente_e_Eventos
{
  partial class Frm_HelloWorld_UC
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
      this.btn_alteraTitulo = new System.Windows.Forms.Button();
      this.txt_conteudoLabel = new System.Windows.Forms.TextBox();
      this.lbl_Titulo = new System.Windows.Forms.Label();
      this.SuspendLayout();
      // 
      // btn_alteraTitulo
      // 
      this.btn_alteraTitulo.Location = new System.Drawing.Point(25, 155);
      this.btn_alteraTitulo.Name = "btn_alteraTitulo";
      this.btn_alteraTitulo.Size = new System.Drawing.Size(393, 46);
      this.btn_alteraTitulo.TabIndex = 6;
      this.btn_alteraTitulo.Text = "Alterar titulo";
      this.btn_alteraTitulo.UseVisualStyleBackColor = true;
      this.btn_alteraTitulo.Click += new System.EventHandler(this.btn_alteraTitulo_Click);
      // 
      // txt_conteudoLabel
      // 
      this.txt_conteudoLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.txt_conteudoLabel.Location = new System.Drawing.Point(25, 88);
      this.txt_conteudoLabel.Name = "txt_conteudoLabel";
      this.txt_conteudoLabel.PlaceholderText = "Digite um texto...";
      this.txt_conteudoLabel.Size = new System.Drawing.Size(848, 39);
      this.txt_conteudoLabel.TabIndex = 5;
      // 
      // lbl_Titulo
      // 
      this.lbl_Titulo.AutoSize = true;
      this.lbl_Titulo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.lbl_Titulo.Location = new System.Drawing.Point(25, 28);
      this.lbl_Titulo.Name = "lbl_Titulo";
      this.lbl_Titulo.Size = new System.Drawing.Size(294, 45);
      this.lbl_Titulo.TabIndex = 4;
      this.lbl_Titulo.Text = "Visual Studio .NET";
      // 
      // Frm_HelloWorld_UC
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.btn_alteraTitulo);
      this.Controls.Add(this.txt_conteudoLabel);
      this.Controls.Add(this.lbl_Titulo);
      this.Name = "Frm_HelloWorld_UC";
      this.Size = new System.Drawing.Size(900, 542);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private Button btn_alteraTitulo;
    private TextBox txt_conteudoLabel;
    private Label lbl_Titulo;
  }
}
