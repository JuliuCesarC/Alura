namespace Formularios_Componente_e_Eventos
{
  partial class Frm_Principal_Menu
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Principal_Menu));
      this.mnu_principal = new System.Windows.Forms.MenuStrip();
      this.arquivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.novoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.demonstraçãoKeyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.helloWorldToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.mascaraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.vaídaCpfToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.valídaCPF2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.checaSenhaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.sairToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.windowsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.mnu_principal.SuspendLayout();
      this.SuspendLayout();
      // 
      // mnu_principal
      // 
      this.mnu_principal.ImageScalingSize = new System.Drawing.Size(32, 32);
      this.mnu_principal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.arquivoToolStripMenuItem,
            this.windowsToolStripMenuItem});
      this.mnu_principal.Location = new System.Drawing.Point(0, 0);
      this.mnu_principal.Name = "mnu_principal";
      this.mnu_principal.Size = new System.Drawing.Size(800, 42);
      this.mnu_principal.TabIndex = 0;
      this.mnu_principal.Text = "menuStrip1";
      this.mnu_principal.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.mnu_principal_ItemClicked);
      // 
      // arquivoToolStripMenuItem
      // 
      this.arquivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.novoToolStripMenuItem,
            this.sairToolStripMenuItem});
      this.arquivoToolStripMenuItem.Name = "arquivoToolStripMenuItem";
      this.arquivoToolStripMenuItem.Size = new System.Drawing.Size(117, 38);
      this.arquivoToolStripMenuItem.Text = "Arquivo";
      // 
      // novoToolStripMenuItem
      // 
      this.novoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.demonstraçãoKeyToolStripMenuItem,
            this.helloWorldToolStripMenuItem,
            this.mascaraToolStripMenuItem,
            this.vaídaCpfToolStripMenuItem,
            this.valídaCPF2ToolStripMenuItem,
            this.checaSenhaToolStripMenuItem});
      this.novoToolStripMenuItem.Name = "novoToolStripMenuItem";
      this.novoToolStripMenuItem.Size = new System.Drawing.Size(359, 44);
      this.novoToolStripMenuItem.Text = "Novo";
      // 
      // demonstraçãoKeyToolStripMenuItem
      // 
      this.demonstraçãoKeyToolStripMenuItem.Image = global::Formularios_Componente_e_Eventos.Properties.Resources.Frm_DemonstracaoKey;
      this.demonstraçãoKeyToolStripMenuItem.Name = "demonstraçãoKeyToolStripMenuItem";
      this.demonstraçãoKeyToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.K)));
      this.demonstraçãoKeyToolStripMenuItem.Size = new System.Drawing.Size(493, 44);
      this.demonstraçãoKeyToolStripMenuItem.Text = "Demonstração &Key";
      this.demonstraçãoKeyToolStripMenuItem.Click += new System.EventHandler(this.demonstraçãoKeyToolStripMenuItem_Click);
      // 
      // helloWorldToolStripMenuItem
      // 
      this.helloWorldToolStripMenuItem.Image = global::Formularios_Componente_e_Eventos.Properties.Resources.Frm_HelloWorld;
      this.helloWorldToolStripMenuItem.Name = "helloWorldToolStripMenuItem";
      this.helloWorldToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.H)));
      this.helloWorldToolStripMenuItem.Size = new System.Drawing.Size(493, 44);
      this.helloWorldToolStripMenuItem.Text = "&Hello World";
      this.helloWorldToolStripMenuItem.Click += new System.EventHandler(this.helloWorldToolStripMenuItem_Click);
      // 
      // mascaraToolStripMenuItem
      // 
      this.mascaraToolStripMenuItem.Image = global::Formularios_Componente_e_Eventos.Properties.Resources.Frm_Mascara;
      this.mascaraToolStripMenuItem.Name = "mascaraToolStripMenuItem";
      this.mascaraToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.M)));
      this.mascaraToolStripMenuItem.Size = new System.Drawing.Size(493, 44);
      this.mascaraToolStripMenuItem.Text = "&Mascara";
      this.mascaraToolStripMenuItem.Click += new System.EventHandler(this.mascaraToolStripMenuItem_Click);
      // 
      // vaídaCpfToolStripMenuItem
      // 
      this.vaídaCpfToolStripMenuItem.Image = global::Formularios_Componente_e_Eventos.Properties.Resources.Frm_ValidaCPF;
      this.vaídaCpfToolStripMenuItem.Name = "vaídaCpfToolStripMenuItem";
      this.vaídaCpfToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.C)));
      this.vaídaCpfToolStripMenuItem.Size = new System.Drawing.Size(493, 44);
      this.vaídaCpfToolStripMenuItem.Text = "Valída &CPF";
      this.vaídaCpfToolStripMenuItem.Click += new System.EventHandler(this.vaídaCpfToolStripMenuItem_Click);
      // 
      // valídaCPF2ToolStripMenuItem
      // 
      this.valídaCPF2ToolStripMenuItem.Image = global::Formularios_Componente_e_Eventos.Properties.Resources.Frm_ValidaCPF2;
      this.valídaCPF2ToolStripMenuItem.Name = "valídaCPF2ToolStripMenuItem";
      this.valídaCPF2ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.C)));
      this.valídaCPF2ToolStripMenuItem.Size = new System.Drawing.Size(493, 44);
      this.valídaCPF2ToolStripMenuItem.Text = "Valída &CPF 2";
      this.valídaCPF2ToolStripMenuItem.Click += new System.EventHandler(this.valídaCPF2ToolStripMenuItem_Click);
      // 
      // checaSenhaToolStripMenuItem
      // 
      this.checaSenhaToolStripMenuItem.Image = global::Formularios_Componente_e_Eventos.Properties.Resources.Frm_ValidaSenha;
      this.checaSenhaToolStripMenuItem.Name = "checaSenhaToolStripMenuItem";
      this.checaSenhaToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
      this.checaSenhaToolStripMenuItem.Size = new System.Drawing.Size(493, 44);
      this.checaSenhaToolStripMenuItem.Text = "Valída &Senha";
      this.checaSenhaToolStripMenuItem.Click += new System.EventHandler(this.checaSenhaToolStripMenuItem_Click);
      // 
      // sairToolStripMenuItem
      // 
      this.sairToolStripMenuItem.Name = "sairToolStripMenuItem";
      this.sairToolStripMenuItem.Size = new System.Drawing.Size(359, 44);
      this.sairToolStripMenuItem.Text = "Sair";
      this.sairToolStripMenuItem.Click += new System.EventHandler(this.sairToolStripMenuItem_Click);
      // 
      // windowsToolStripMenuItem
      // 
      this.windowsToolStripMenuItem.Name = "windowsToolStripMenuItem";
      this.windowsToolStripMenuItem.Size = new System.Drawing.Size(131, 38);
      this.windowsToolStripMenuItem.Text = "Windows";
      // 
      // Frm_Principal_Menu
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(800, 450);
      this.Controls.Add(this.mnu_principal);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.MainMenuStrip = this.mnu_principal;
      this.Name = "Frm_Principal_Menu";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Principal";
      this.mnu_principal.ResumeLayout(false);
      this.mnu_principal.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private MenuStrip mnu_principal;
    private ToolStripMenuItem arquivoToolStripMenuItem;
    private ToolStripMenuItem novoToolStripMenuItem;
    private ToolStripMenuItem demonstraçãoKeyToolStripMenuItem;
    private ToolStripMenuItem helloWorldToolStripMenuItem;
    private ToolStripMenuItem mascaraToolStripMenuItem;
    private ToolStripMenuItem vaídaCpfToolStripMenuItem;
    private ToolStripMenuItem valídaCPF2ToolStripMenuItem;
    private ToolStripMenuItem checaSenhaToolStripMenuItem;
    private ToolStripMenuItem sairToolStripMenuItem;
    private ToolStripMenuItem windowsToolStripMenuItem;
  }
}