namespace Formularios_Componente_e_Eventos
{
  partial class Frm_ImageFile_US
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
      this.lbl_imageFile = new System.Windows.Forms.Label();
      this.pic_imageFile = new System.Windows.Forms.PictureBox();
      this.btn_color = new System.Windows.Forms.Button();
      this.bnt_font = new System.Windows.Forms.Button();
      ((System.ComponentModel.ISupportInitialize)(this.pic_imageFile)).BeginInit();
      this.SuspendLayout();
      // 
      // lbl_imageFile
      // 
      this.lbl_imageFile.AutoSize = true;
      this.lbl_imageFile.Font = new System.Drawing.Font("Segoe UI", 13.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.lbl_imageFile.Location = new System.Drawing.Point(38, 44);
      this.lbl_imageFile.Name = "lbl_imageFile";
      this.lbl_imageFile.Size = new System.Drawing.Size(387, 50);
      this.lbl_imageFile.TabIndex = 0;
      this.lbl_imageFile.Text = "DialogBoxes Padrões";
      // 
      // pic_imageFile
      // 
      this.pic_imageFile.Location = new System.Drawing.Point(38, 125);
      this.pic_imageFile.Name = "pic_imageFile";
      this.pic_imageFile.Size = new System.Drawing.Size(561, 345);
      this.pic_imageFile.TabIndex = 1;
      this.pic_imageFile.TabStop = false;
      // 
      // btn_color
      // 
      this.btn_color.Location = new System.Drawing.Point(635, 409);
      this.btn_color.Name = "btn_color";
      this.btn_color.Size = new System.Drawing.Size(150, 46);
      this.btn_color.TabIndex = 2;
      this.btn_color.Text = "Cor";
      this.btn_color.UseVisualStyleBackColor = true;
      this.btn_color.Click += new System.EventHandler(this.btn_color_Click);
      // 
      // bnt_font
      // 
      this.bnt_font.Location = new System.Drawing.Point(635, 461);
      this.bnt_font.Name = "bnt_font";
      this.bnt_font.Size = new System.Drawing.Size(150, 46);
      this.bnt_font.TabIndex = 3;
      this.bnt_font.Text = "Fonte";
      this.bnt_font.UseVisualStyleBackColor = true;
      this.bnt_font.Click += new System.EventHandler(this.bnt_font_Click);
      // 
      // Frm_ImageFile_US
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.bnt_font);
      this.Controls.Add(this.btn_color);
      this.Controls.Add(this.pic_imageFile);
      this.Controls.Add(this.lbl_imageFile);
      this.Name = "Frm_ImageFile_US";
      this.Size = new System.Drawing.Size(788, 510);
      ((System.ComponentModel.ISupportInitialize)(this.pic_imageFile)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private Label lbl_imageFile;
    private PictureBox pic_imageFile;
    private Button btn_color;
    private Button bnt_font;
  }
}
