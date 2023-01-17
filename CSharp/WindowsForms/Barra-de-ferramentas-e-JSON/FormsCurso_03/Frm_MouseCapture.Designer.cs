namespace Formularios_Componente_e_Eventos
{
  partial class Frm_MouseCapture
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
      this.btn_mouse = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // btn_mouse
      // 
      this.btn_mouse.Location = new System.Drawing.Point(201, 167);
      this.btn_mouse.Name = "btn_mouse";
      this.btn_mouse.Size = new System.Drawing.Size(658, 346);
      this.btn_mouse.TabIndex = 0;
      this.btn_mouse.Text = "button1";
      this.btn_mouse.UseVisualStyleBackColor = true;
      this.btn_mouse.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button1_MouseDown);
      // 
      // Frm_MouseCapture
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1054, 699);
      this.Controls.Add(this.btn_mouse);
      this.Name = "Frm_MouseCapture";
      this.Text = "Frm_MouseCapture";
      this.ResumeLayout(false);

    }

    #endregion

    private Button btn_mouse;
  }
}