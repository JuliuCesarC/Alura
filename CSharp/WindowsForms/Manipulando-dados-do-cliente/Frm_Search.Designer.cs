namespace Formularios_Componente_e_Eventos
{
  partial class Frm_Search
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Search));
      this.tls_principal = new System.Windows.Forms.ToolStrip();
      this.salvarToolStripButton = new System.Windows.Forms.ToolStripButton();
      this.deleteToolStripButton1 = new System.Windows.Forms.ToolStripButton();
      this.listBox1 = new System.Windows.Forms.ListBox();
      this.tls_principal.SuspendLayout();
      this.SuspendLayout();
      // 
      // tls_principal
      // 
      this.tls_principal.ImageScalingSize = new System.Drawing.Size(32, 32);
      this.tls_principal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.salvarToolStripButton,
            this.deleteToolStripButton1});
      this.tls_principal.Location = new System.Drawing.Point(0, 0);
      this.tls_principal.Name = "tls_principal";
      this.tls_principal.Size = new System.Drawing.Size(974, 42);
      this.tls_principal.TabIndex = 42;
      this.tls_principal.Text = "toolStrip1";
      // 
      // salvarToolStripButton
      // 
      this.salvarToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.salvarToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("salvarToolStripButton.Image")));
      this.salvarToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.salvarToolStripButton.Name = "salvarToolStripButton";
      this.salvarToolStripButton.Size = new System.Drawing.Size(46, 36);
      this.salvarToolStripButton.Text = "&Salvar";
      // 
      // deleteToolStripButton1
      // 
      this.deleteToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.deleteToolStripButton1.Image = global::Formularios_Componente_e_Eventos.Properties.Resources.ExcluirBarra;
      this.deleteToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.deleteToolStripButton1.Name = "deleteToolStripButton1";
      this.deleteToolStripButton1.Size = new System.Drawing.Size(46, 36);
      this.deleteToolStripButton1.Text = "toolStripButton1";
      this.deleteToolStripButton1.ToolTipText = "Fechar";
      this.deleteToolStripButton1.Click += new System.EventHandler(this.deleteToolStripButton1_Click);
      // 
      // listBox1
      // 
      this.listBox1.FormattingEnabled = true;
      this.listBox1.ItemHeight = 32;
      this.listBox1.Location = new System.Drawing.Point(12, 78);
      this.listBox1.Name = "listBox1";
      this.listBox1.Size = new System.Drawing.Size(950, 836);
      this.listBox1.TabIndex = 43;
      // 
      // Frm_Search
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(974, 929);
      this.Controls.Add(this.listBox1);
      this.Controls.Add(this.tls_principal);
      this.Name = "Frm_Search";
      this.Text = "Frm_Search";
      this.tls_principal.ResumeLayout(false);
      this.tls_principal.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private ToolStrip tls_principal;
    private ToolStripButton salvarToolStripButton;
    private ToolStripButton deleteToolStripButton1;
    private ListBox listBox1;
  }
}