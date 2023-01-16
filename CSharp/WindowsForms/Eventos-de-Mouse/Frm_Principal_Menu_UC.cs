using Formularios_Componente_e_Eventos.FormsUserControl;
using LibraryWF;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Formularios_Componente_e_Eventos
{
  public partial class Frm_Principal_Menu_UC: Form
  {
    public Frm_Principal_Menu_UC()
    {
      InitializeComponent();

      novoToolStripMenuItem.Enabled = false;
      fecharAbaToolStripMenuItem.Enabled = false;
      abrirImagemToolStripMenuItem.Enabled = false;
      desconectarToolStripMenuItem.Enabled = false;
      cadastrosToolStripMenuItem.Enabled = false;
    }

    int NameControlHelloWorld = 0;
    int NameControlCheckPassword = 0;
    int NameControlKeyDown = 0;
    int NameControlMask = 0;
    int NameControlCPF_1 = 0;
    int NameControlCPF_2 = 0;
    int NameControlImageFile = 0;
    int NameControlClient = 0;
    private void KeyDownToolStripMenuItem_Click(object sender, EventArgs e)
    {
      Frm_KeyDown_UC keyDown = new Frm_KeyDown_UC();
      keyDown.Dock = DockStyle.Fill;
      TabPage TB = new TabPage();
      TB.Name = "KeyDown_" + NameControlKeyDown;
      TB.Text = "KeyDown_" + NameControlKeyDown;
      TB.ImageIndex = 0;
      TB.Controls.Add(keyDown);
      tbc_application.TabPages.Add(TB);
      NameControlKeyDown++;
    }
    private void helloWorldToolStripMenuItem_Click(object sender, EventArgs e)
    {
      Frm_HelloWorld_UC helloWorld_UC = new Frm_HelloWorld_UC();
      helloWorld_UC.Dock = DockStyle.Fill;
      TabPage TB = new TabPage();
      TB.Name = "Hello_World_" + NameControlHelloWorld;
      TB.Text = "Hello_" + NameControlHelloWorld;
      TB.ImageIndex = 1;
      TB.Controls.Add(helloWorld_UC);
      tbc_application.TabPages.Add(TB);
      NameControlHelloWorld++;
    }
    private void mascaraToolStripMenuItem_Click(object sender, EventArgs e)
    {
      Frm_Mask_UC mask = new Frm_Mask_UC();
      TabPage TB = new TabPage();
      TB.Name = "Mask_" + NameControlMask;
      TB.Text = "Mask_" + NameControlMask;
      TB.ImageIndex = 2;
      TB.Controls.Add(mask);
      tbc_application.TabPages.Add(TB);
      NameControlMask++;
    }
    private void validaCpfToolStripMenuItem_Click(object sender, EventArgs e)
    {
      Frm_ValidateCPF_UC cpf = new Frm_ValidateCPF_UC();
      cpf.Dock = DockStyle.Fill;
      TabPage TB = new TabPage();
      TB.Name = "CPF_" + NameControlCPF_1;
      TB.Text = "CPF_" + NameControlCPF_1;
      TB.ImageIndex = 3;
      TB.Controls.Add(cpf);
      tbc_application.TabPages.Add(TB);
      NameControlCPF_1++;
    }
    private void validaCPF2ToolStripMenuItem_Click(object sender, EventArgs e)
    {
      Frm_ValidateCPF_2_UC cpf2 = new Frm_ValidateCPF_2_UC();
      cpf2.Dock = DockStyle.Fill;
      TabPage TB = new TabPage();
      TB.Name = "CPF_2_" + NameControlCPF_2;
      TB.Text = "CPF_2_" + NameControlCPF_2;
      TB.ImageIndex = 4;
      TB.Controls.Add(cpf2);
      tbc_application.TabPages.Add(TB);
      NameControlCPF_2++;
    }
    private void checaSenhaToolStripMenuItem_Click(object sender, EventArgs e)
    {
      Frm_CheckPassword_UC check = new Frm_CheckPassword_UC();
      check.Dock = DockStyle.Fill;
      TabPage TB = new TabPage();
      TB.Name = "Check_Password_" + NameControlCheckPassword;
      TB.Text = "Check_" + NameControlCheckPassword;
      TB.ImageIndex = 5;
      TB.Controls.Add(check);
      tbc_application.TabPages.Add(TB);
      NameControlCheckPassword++;
    }

    private void sairToolStripMenuItem_Click(object sender, EventArgs e)
    {
      Application.Exit();
    }

    private void fecharAbaToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if( !(tbc_application.SelectedTab == null) )
      {
        deleteTab(tbc_application.SelectedTab);
      }
    }

    private void abrirImagemToolStripMenuItem_Click(object sender, EventArgs e)
    {
      OpenFileDialog Db = new OpenFileDialog();
      Db.InitialDirectory = "C:\\Users\\Cesar\\Desktop\\Curso_Dev\\Alura\\CSharp\\WindowsForms\\Menus-Validacao-login-e-senha\\Images";
      Db.Filter = "PNG|*.PNG";
      Db.Title = "Escolha a Imagem";

      if( Db.ShowDialog() == DialogResult.OK )
      {
        string imageFileName = Db.FileName;

        Frm_ImageFile_US image = new Frm_ImageFile_US(imageFileName);
        image.Dock = DockStyle.Fill;
        TabPage TB = new TabPage();
        TB.Name = "Image_File_" + NameControlImageFile;
        TB.Text = "Image_" + NameControlImageFile;
        TB.ImageIndex = 6;
        TB.Controls.Add(image);
        tbc_application.TabPages.Add(TB);
        NameControlImageFile++;
      }
    }

    private void conectarToolStripMenuItem_Click(object sender, EventArgs e)
    {
      Frm_Login L = new Frm_Login();
      L.ShowDialog();

      if( L.DialogResult == DialogResult.OK && L.login.Trim() != "" )
      {
        string password = L.password;

        if( Cls_Utils.CheckPassword(password) )
        {
          conectarToolStripMenuItem.Enabled = false;

          novoToolStripMenuItem.Enabled = true;
          fecharAbaToolStripMenuItem.Enabled = true;
          abrirImagemToolStripMenuItem.Enabled = true;
          desconectarToolStripMenuItem.Enabled = true;
          cadastrosToolStripMenuItem.Enabled = true;
          MessageBox.Show("Usuário logado com sucesso");
        }
      }
    }

    private void desconectarToolStripMenuItem_Click(object sender, EventArgs e)
    {
      Frm_Question question = new Frm_Question("Deseja efetuar o Logout?", "Frm_Question");
      question.ShowDialog();

      if( question.DialogResult == DialogResult.Yes )
      {
        for( int i = tbc_application.TabPages.Count - 1; i >= 0; i-- )
          // É preciso remover as abas de traz pra frente, ou seja, remove a ultima, depois a penúltima e assim sucessivamente até a de numero 0.
        {
          deleteTab(tbc_application.TabPages[i]);
        }
        conectarToolStripMenuItem.Enabled = true;

        novoToolStripMenuItem.Enabled = false;
        fecharAbaToolStripMenuItem.Enabled = false;
        abrirImagemToolStripMenuItem.Enabled = false;
        desconectarToolStripMenuItem.Enabled = false;
        cadastrosToolStripMenuItem.Enabled = false;
      }
    }

    private void tbc_application_MouseDown(object sender, MouseEventArgs e)
    {
      if( e.Button == MouseButtons.Right )
      {
        var ContextMenu = new ContextMenuStrip();

        var vToolTip01 = assembleItem("Apagar aba", "DeleteTab");
        var vToolTip02 = assembleItem("Apagar todas a esqueda", "DeleteLeft");
        var vToolTip03 = assembleItem("Apagar todas a direita", "DeleteRight");
        var vToolTip04 = assembleItem("Apagar todas menos a aba selecionada", "DeleteAll");

        ContextMenu.Items.Add(vToolTip01);
        ContextMenu.Items.Add(vToolTip02);
        ContextMenu.Items.Add(vToolTip03);
        ContextMenu.Items.Add(vToolTip04);
        ContextMenu.Show(this, new Point(e.X, e.Y));

        vToolTip01.Click += new System.EventHandler(vToolTip01_Click);
        vToolTip02.Click += new System.EventHandler(vToolTip02_Click);
        vToolTip03.Click += new System.EventHandler(vToolTip03_Click);
        vToolTip04.Click += new System.EventHandler(vToolTip04_Click);
      }
    }
    void vToolTip01_Click(object sender, EventArgs e)
    {
      if( !(tbc_application.SelectedTab == null) )
      {
        deleteTab(tbc_application.SelectedTab);
      }
    }
    void vToolTip02_Click(object sender, EventArgs e)
    {
      if( !(tbc_application.SelectedTab == null) )
      {
        ClearLeft(tbc_application.SelectedIndex);
      }
    }
    void vToolTip03_Click(object sender, EventArgs e)
    {      
      if( !(tbc_application.SelectedTab == null) )
      {
        ClearRight(tbc_application.SelectedIndex);
      }
    }
    void vToolTip04_Click(object sender, EventArgs e)
    {
      ClearLeft(tbc_application.SelectedIndex);
      ClearRight(tbc_application.SelectedIndex);
    }
    ToolStripMenuItem assembleItem(string text, string imageName)
    {
      var item = new ToolStripMenuItem();
      item.Text = text;
      Image MyImage = (Image)Properties.Resources.ResourceManager.GetObject(imageName);
      item.Image = MyImage;

      return item;
    }
    void ClearLeft(int SelectedItem)
    {
      for( int i = SelectedItem - 1; i >= 0; i-- )
      {
        deleteTab(tbc_application.TabPages[i]);
      }
    }
    void ClearRight(int SelectedItem)
    {
      for( int i = tbc_application.TabPages.Count - 1; i > SelectedItem; i-- )
      {
        deleteTab(tbc_application.TabPages[i]);
      }
    }

    private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if( NameControlClient == 0 )
      {
      Frm_RegisterClient_UC client = new Frm_RegisterClient_UC();
      client.Dock = DockStyle.Fill;
      TabPage TB = new TabPage();
      TB.Name = "Cadastro_de_Cliente";
      TB.Text = "Cadastro_de_Cliente";
      TB.ImageIndex = 7;
      TB.Controls.Add(client);
      tbc_application.TabPages.Add(TB);
      NameControlClient++;
      }
      else
      {
        MessageBox.Show("Só é possivel abrir uma aba de cadastro.", "Banco ByteBank", MessageBoxButtons.OK, MessageBoxIcon.Warning);
      }
    }
    void deleteTab(TabPage TB)
    {
      if( TB.Name == "Cadastro_de_Cliente" )
      {
        NameControlClient = 0;
      }
      tbc_application.TabPages.Remove(TB);
    }
  }
}