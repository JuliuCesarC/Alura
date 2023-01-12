using Formularios_Componente_e_Eventos.FormsUserControl;
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
    }

    int NameControlHelloWorld = 0;
    int NameControlCheckPassword = 0;
    int NameControlKeyDown = 0;
    int NameControlMask = 0;
    int NameControlCPF_1 = 0;
    int NameControlCPF_2 = 0;
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
        tbc_application.TabPages.Remove(tbc_application.SelectedTab);
      }
    }
  }
}