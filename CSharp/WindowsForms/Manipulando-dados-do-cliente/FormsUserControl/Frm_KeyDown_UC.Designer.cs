namespace Formularios_Componente_e_Eventos.FormsUserControl
{
  partial class Frm_KeyDown_UC
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
      this.lbl_lower = new System.Windows.Forms.Label();
      this.lbl_upper = new System.Windows.Forms.Label();
      this.lbl_maius = new System.Windows.Forms.Label();
      this.lbl_minus = new System.Windows.Forms.Label();
      this.btn_reset = new System.Windows.Forms.Button();
      this.txt_msg = new System.Windows.Forms.TextBox();
      this.txt_input = new System.Windows.Forms.TextBox();
      this.SuspendLayout();
      // 
      // lbl_lower
      // 
      this.lbl_lower.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.lbl_lower.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
      this.lbl_lower.Location = new System.Drawing.Point(838, 373);
      this.lbl_lower.Name = "lbl_lower";
      this.lbl_lower.Size = new System.Drawing.Size(94, 78);
      this.lbl_lower.TabIndex = 13;
      // 
      // lbl_upper
      // 
      this.lbl_upper.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.lbl_upper.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
      this.lbl_upper.Location = new System.Drawing.Point(838, 173);
      this.lbl_upper.Name = "lbl_upper";
      this.lbl_upper.Size = new System.Drawing.Size(94, 78);
      this.lbl_upper.TabIndex = 12;
      // 
      // lbl_maius
      // 
      this.lbl_maius.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.lbl_maius.AutoSize = true;
      this.lbl_maius.Location = new System.Drawing.Point(718, 173);
      this.lbl_maius.Name = "lbl_maius";
      this.lbl_maius.Size = new System.Drawing.Size(83, 32);
      this.lbl_maius.TabIndex = 11;
      this.lbl_maius.Text = "Maius.";
      // 
      // lbl_minus
      // 
      this.lbl_minus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.lbl_minus.AutoSize = true;
      this.lbl_minus.Location = new System.Drawing.Point(718, 373);
      this.lbl_minus.Name = "lbl_minus";
      this.lbl_minus.Size = new System.Drawing.Size(85, 32);
      this.lbl_minus.TabIndex = 10;
      this.lbl_minus.Text = "Minus.";
      // 
      // btn_reset
      // 
      this.btn_reset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btn_reset.Location = new System.Drawing.Point(812, 35);
      this.btn_reset.Name = "btn_reset";
      this.btn_reset.Size = new System.Drawing.Size(150, 46);
      this.btn_reset.TabIndex = 9;
      this.btn_reset.Text = "Limpa";
      this.btn_reset.UseVisualStyleBackColor = true;
      this.btn_reset.Click += new System.EventHandler(this.btn_reset_Click);
      // 
      // txt_msg
      // 
      this.txt_msg.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.txt_msg.Location = new System.Drawing.Point(30, 103);
      this.txt_msg.Multiline = true;
      this.txt_msg.Name = "txt_msg";
      this.txt_msg.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
      this.txt_msg.Size = new System.Drawing.Size(670, 721);
      this.txt_msg.TabIndex = 8;
      this.txt_msg.TabStop = false;
      // 
      // txt_input
      // 
      this.txt_input.Location = new System.Drawing.Point(30, 35);
      this.txt_input.Name = "txt_input";
      this.txt_input.Size = new System.Drawing.Size(200, 39);
      this.txt_input.TabIndex = 7;
      this.txt_input.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_input_KeyDown);
      // 
      // Frm_KeyDown_UC
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.lbl_lower);
      this.Controls.Add(this.lbl_upper);
      this.Controls.Add(this.lbl_maius);
      this.Controls.Add(this.lbl_minus);
      this.Controls.Add(this.btn_reset);
      this.Controls.Add(this.txt_msg);
      this.Controls.Add(this.txt_input);
      this.Name = "Frm_KeyDown_UC";
      this.Size = new System.Drawing.Size(977, 854);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private Label lbl_lower;
    private Label lbl_upper;
    private Label lbl_maius;
    private Label lbl_minus;
    private Button btn_reset;
    private TextBox txt_msg;
    private TextBox txt_input;
  }
}
