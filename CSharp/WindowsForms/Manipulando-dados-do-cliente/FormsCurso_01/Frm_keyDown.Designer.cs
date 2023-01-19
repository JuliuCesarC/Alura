namespace Formularios_Componente_e_Eventos
{
  partial class Frm_keyDown
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_keyDown));
      this.txt_input = new System.Windows.Forms.TextBox();
      this.txt_msg = new System.Windows.Forms.TextBox();
      this.btn_reset = new System.Windows.Forms.Button();
      this.lbl_minus = new System.Windows.Forms.Label();
      this.lbl_maius = new System.Windows.Forms.Label();
      this.lbl_upper = new System.Windows.Forms.Label();
      this.lbl_lower = new System.Windows.Forms.Label();
      this.SuspendLayout();
      // 
      // txt_input
      // 
      this.txt_input.Location = new System.Drawing.Point(12, 12);
      this.txt_input.Name = "txt_input";
      this.txt_input.Size = new System.Drawing.Size(200, 39);
      this.txt_input.TabIndex = 0;
      this.txt_input.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_input_KeyDown);
      // 
      // txt_msg
      // 
      this.txt_msg.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.txt_msg.Location = new System.Drawing.Point(12, 80);
      this.txt_msg.Multiline = true;
      this.txt_msg.Name = "txt_msg";
      this.txt_msg.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
      this.txt_msg.Size = new System.Drawing.Size(670, 820);
      this.txt_msg.TabIndex = 1;
      this.txt_msg.TabStop = false;
      // 
      // btn_reset
      // 
      this.btn_reset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btn_reset.Location = new System.Drawing.Point(794, 12);
      this.btn_reset.Name = "btn_reset";
      this.btn_reset.Size = new System.Drawing.Size(150, 46);
      this.btn_reset.TabIndex = 2;
      this.btn_reset.Text = "Limpa";
      this.btn_reset.UseVisualStyleBackColor = true;
      this.btn_reset.Click += new System.EventHandler(this.btn_reset_Click);
      // 
      // lbl_minus
      // 
      this.lbl_minus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.lbl_minus.AutoSize = true;
      this.lbl_minus.Location = new System.Drawing.Point(700, 350);
      this.lbl_minus.Name = "lbl_minus";
      this.lbl_minus.Size = new System.Drawing.Size(85, 32);
      this.lbl_minus.TabIndex = 3;
      this.lbl_minus.Text = "Minus.";
      // 
      // lbl_maius
      // 
      this.lbl_maius.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.lbl_maius.AutoSize = true;
      this.lbl_maius.Location = new System.Drawing.Point(700, 150);
      this.lbl_maius.Name = "lbl_maius";
      this.lbl_maius.Size = new System.Drawing.Size(83, 32);
      this.lbl_maius.TabIndex = 4;
      this.lbl_maius.Text = "Maius.";
      // 
      // lbl_upper
      // 
      this.lbl_upper.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.lbl_upper.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
      this.lbl_upper.Location = new System.Drawing.Point(820, 150);
      this.lbl_upper.Name = "lbl_upper";
      this.lbl_upper.Size = new System.Drawing.Size(94, 78);
      this.lbl_upper.TabIndex = 5;
      // 
      // lbl_lower
      // 
      this.lbl_lower.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.lbl_lower.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
      this.lbl_lower.Location = new System.Drawing.Point(820, 350);
      this.lbl_lower.Name = "lbl_lower";
      this.lbl_lower.Size = new System.Drawing.Size(94, 78);
      this.lbl_lower.TabIndex = 6;
      // 
      // Frm_keyDown
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(956, 911);
      this.Controls.Add(this.lbl_lower);
      this.Controls.Add(this.lbl_upper);
      this.Controls.Add(this.lbl_maius);
      this.Controls.Add(this.lbl_minus);
      this.Controls.Add(this.btn_reset);
      this.Controls.Add(this.txt_msg);
      this.Controls.Add(this.txt_input);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Name = "Frm_keyDown";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Evento Key";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private TextBox txt_input;
    private TextBox txt_msg;
    private Button btn_reset;
    private Label lbl_minus;
    private Label lbl_maius;
    private Label lbl_upper;
    private Label lbl_lower;
  }
}