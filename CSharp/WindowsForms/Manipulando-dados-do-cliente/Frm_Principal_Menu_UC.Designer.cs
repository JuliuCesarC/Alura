namespace Formularios_Componente_e_Eventos
{
  partial class Frm_Principal_Menu_UC
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
      this.components = new System.ComponentModel.Container();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Principal_Menu_UC));
      this.mnu_principal = new System.Windows.Forms.MenuStrip();
      this.arquivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.conectarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.desconectarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.novoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.demonstraçãoKeyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.helloWorldToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.mascaraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.valídaCpfToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.valídaCPF2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.checaSenhaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.fecharAbaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.sairToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.byteBankToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.cadastrosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.clientesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.açõesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.abrirImagemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.windowsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.tbc_application = new System.Windows.Forms.TabControl();
      this.iml_image = new System.Windows.Forms.ImageList(this.components);
      this.mnu_principal.SuspendLayout();
      this.SuspendLayout();
      // 
      // mnu_principal
      // 
      this.mnu_principal.ImageScalingSize = new System.Drawing.Size(32, 32);
      this.mnu_principal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.arquivoToolStripMenuItem,
            this.byteBankToolStripMenuItem,
            this.açõesToolStripMenuItem,
            this.windowsToolStripMenuItem});
      this.mnu_principal.Location = new System.Drawing.Point(0, 0);
      this.mnu_principal.Name = "mnu_principal";
      this.mnu_principal.Size = new System.Drawing.Size(1574, 40);
      this.mnu_principal.TabIndex = 0;
      this.mnu_principal.Text = "menuStrip1";
      // 
      // arquivoToolStripMenuItem
      // 
      this.arquivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.conectarToolStripMenuItem,
            this.desconectarToolStripMenuItem,
            this.novoToolStripMenuItem,
            this.fecharAbaToolStripMenuItem,
            this.sairToolStripMenuItem});
      this.arquivoToolStripMenuItem.Name = "arquivoToolStripMenuItem";
      this.arquivoToolStripMenuItem.Size = new System.Drawing.Size(117, 36);
      this.arquivoToolStripMenuItem.Text = "Arquivo";
      // 
      // conectarToolStripMenuItem
      // 
      this.conectarToolStripMenuItem.Name = "conectarToolStripMenuItem";
      this.conectarToolStripMenuItem.Size = new System.Drawing.Size(408, 44);
      this.conectarToolStripMenuItem.Text = "Conectar";
      this.conectarToolStripMenuItem.Click += new System.EventHandler(this.conectarToolStripMenuItem_Click);
      // 
      // desconectarToolStripMenuItem
      // 
      this.desconectarToolStripMenuItem.Name = "desconectarToolStripMenuItem";
      this.desconectarToolStripMenuItem.Size = new System.Drawing.Size(408, 44);
      this.desconectarToolStripMenuItem.Text = "Desconectar";
      this.desconectarToolStripMenuItem.Click += new System.EventHandler(this.desconectarToolStripMenuItem_Click);
      // 
      // novoToolStripMenuItem
      // 
      this.novoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.demonstraçãoKeyToolStripMenuItem,
            this.helloWorldToolStripMenuItem,
            this.mascaraToolStripMenuItem,
            this.valídaCpfToolStripMenuItem,
            this.valídaCPF2ToolStripMenuItem,
            this.checaSenhaToolStripMenuItem});
      this.novoToolStripMenuItem.Name = "novoToolStripMenuItem";
      this.novoToolStripMenuItem.Size = new System.Drawing.Size(408, 44);
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
      this.demonstraçãoKeyToolStripMenuItem.Click += new System.EventHandler(this.KeyDownToolStripMenuItem_Click);
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
      // valídaCpfToolStripMenuItem
      // 
      this.valídaCpfToolStripMenuItem.Image = global::Formularios_Componente_e_Eventos.Properties.Resources.Frm_ValidaCPF;
      this.valídaCpfToolStripMenuItem.Name = "valídaCpfToolStripMenuItem";
      this.valídaCpfToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.C)));
      this.valídaCpfToolStripMenuItem.Size = new System.Drawing.Size(493, 44);
      this.valídaCpfToolStripMenuItem.Text = "Valída &CPF";
      this.valídaCpfToolStripMenuItem.Click += new System.EventHandler(this.validaCpfToolStripMenuItem_Click);
      // 
      // valídaCPF2ToolStripMenuItem
      // 
      this.valídaCPF2ToolStripMenuItem.Image = global::Formularios_Componente_e_Eventos.Properties.Resources.Frm_ValidaCPF2;
      this.valídaCPF2ToolStripMenuItem.Name = "valídaCPF2ToolStripMenuItem";
      this.valídaCPF2ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.C)));
      this.valídaCPF2ToolStripMenuItem.Size = new System.Drawing.Size(493, 44);
      this.valídaCPF2ToolStripMenuItem.Text = "Valída &CPF 2";
      this.valídaCPF2ToolStripMenuItem.Click += new System.EventHandler(this.validaCPF2ToolStripMenuItem_Click);
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
      // fecharAbaToolStripMenuItem
      // 
      this.fecharAbaToolStripMenuItem.Name = "fecharAbaToolStripMenuItem";
      this.fecharAbaToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.X)));
      this.fecharAbaToolStripMenuItem.Size = new System.Drawing.Size(408, 44);
      this.fecharAbaToolStripMenuItem.Text = "Fechar aba";
      this.fecharAbaToolStripMenuItem.Click += new System.EventHandler(this.fecharAbaToolStripMenuItem_Click);
      // 
      // sairToolStripMenuItem
      // 
      this.sairToolStripMenuItem.Name = "sairToolStripMenuItem";
      this.sairToolStripMenuItem.Size = new System.Drawing.Size(408, 44);
      this.sairToolStripMenuItem.Text = "Sair";
      this.sairToolStripMenuItem.Click += new System.EventHandler(this.sairToolStripMenuItem_Click);
      // 
      // byteBankToolStripMenuItem
      // 
      this.byteBankToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cadastrosToolStripMenuItem});
      this.byteBankToolStripMenuItem.Image = global::Formularios_Componente_e_Eventos.Properties.Resources.money;
      this.byteBankToolStripMenuItem.Name = "byteBankToolStripMenuItem";
      this.byteBankToolStripMenuItem.Size = new System.Drawing.Size(165, 36);
      this.byteBankToolStripMenuItem.Text = "ByteBank";
      // 
      // cadastrosToolStripMenuItem
      // 
      this.cadastrosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clientesToolStripMenuItem});
      this.cadastrosToolStripMenuItem.Image = global::Formularios_Componente_e_Eventos.Properties.Resources.Cadastros;
      this.cadastrosToolStripMenuItem.Name = "cadastrosToolStripMenuItem";
      this.cadastrosToolStripMenuItem.Size = new System.Drawing.Size(250, 44);
      this.cadastrosToolStripMenuItem.Text = "Cadastros";
      // 
      // clientesToolStripMenuItem
      // 
      this.clientesToolStripMenuItem.Image = global::Formularios_Componente_e_Eventos.Properties.Resources.user;
      this.clientesToolStripMenuItem.Name = "clientesToolStripMenuItem";
      this.clientesToolStripMenuItem.Size = new System.Drawing.Size(232, 44);
      this.clientesToolStripMenuItem.Text = "Clientes";
      this.clientesToolStripMenuItem.Click += new System.EventHandler(this.clientesToolStripMenuItem_Click);
      // 
      // açõesToolStripMenuItem
      // 
      this.açõesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.abrirImagemToolStripMenuItem});
      this.açõesToolStripMenuItem.Name = "açõesToolStripMenuItem";
      this.açõesToolStripMenuItem.Size = new System.Drawing.Size(97, 36);
      this.açõesToolStripMenuItem.Text = "Ações";
      // 
      // abrirImagemToolStripMenuItem
      // 
      this.abrirImagemToolStripMenuItem.Name = "abrirImagemToolStripMenuItem";
      this.abrirImagemToolStripMenuItem.Size = new System.Drawing.Size(292, 44);
      this.abrirImagemToolStripMenuItem.Text = "Abrir Imagem";
      this.abrirImagemToolStripMenuItem.Click += new System.EventHandler(this.abrirImagemToolStripMenuItem_Click);
      // 
      // windowsToolStripMenuItem
      // 
      this.windowsToolStripMenuItem.Name = "windowsToolStripMenuItem";
      this.windowsToolStripMenuItem.Size = new System.Drawing.Size(131, 36);
      this.windowsToolStripMenuItem.Text = "Windows";
      // 
      // tbc_application
      // 
      this.tbc_application.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tbc_application.ImageList = this.iml_image;
      this.tbc_application.Location = new System.Drawing.Point(0, 40);
      this.tbc_application.Name = "tbc_application";
      this.tbc_application.SelectedIndex = 0;
      this.tbc_application.Size = new System.Drawing.Size(1574, 1139);
      this.tbc_application.TabIndex = 1;
      this.tbc_application.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tbc_application_MouseDown);
      // 
      // iml_image
      // 
      this.iml_image.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
      this.iml_image.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("iml_image.ImageStream")));
      this.iml_image.TransparentColor = System.Drawing.Color.Transparent;
      this.iml_image.Images.SetKeyName(0, "Frm_DemonstracaoKey.png");
      this.iml_image.Images.SetKeyName(1, "Frm_HelloWorld.png");
      this.iml_image.Images.SetKeyName(2, "Frm_Mascara.png");
      this.iml_image.Images.SetKeyName(3, "Frm_ValidaCPF.png");
      this.iml_image.Images.SetKeyName(4, "Frm_ValidaCPF2.png");
      this.iml_image.Images.SetKeyName(5, "Frm_ValidaSenha.png");
      this.iml_image.Images.SetKeyName(6, "Frm_Question.png");
      this.iml_image.Images.SetKeyName(7, "user.png");
      // 
      // Frm_Principal_Menu_UC
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1574, 1179);
      this.Controls.Add(this.tbc_application);
      this.Controls.Add(this.mnu_principal);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.MainMenuStrip = this.mnu_principal;
      this.Name = "Frm_Principal_Menu_UC";
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
    private ToolStripMenuItem valídaCpfToolStripMenuItem;
    private ToolStripMenuItem valídaCPF2ToolStripMenuItem;
    private ToolStripMenuItem checaSenhaToolStripMenuItem;
    private ToolStripMenuItem sairToolStripMenuItem;
    private ToolStripMenuItem windowsToolStripMenuItem;
    private TabControl tbc_application;
    private ImageList iml_image;
    private ToolStripMenuItem fecharAbaToolStripMenuItem;
    private ToolStripMenuItem açõesToolStripMenuItem;
    private ToolStripMenuItem abrirImagemToolStripMenuItem;
    private ToolStripMenuItem conectarToolStripMenuItem;
    private ToolStripMenuItem desconectarToolStripMenuItem;
    private ToolStripMenuItem byteBankToolStripMenuItem;
    private ToolStripMenuItem cadastrosToolStripMenuItem;
    private ToolStripMenuItem clientesToolStripMenuItem;
  }
}