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
  public partial class Frm_Principal_Menu: Form
  {
    public Frm_Principal_Menu()
    {
      InitializeComponent();
    }
    private void demonstraçãoKeyToolStripMenuItem_Click(object sender, EventArgs e)
    {
      Frm_keyDown KeyDown = new Frm_keyDown();
      KeyDown.ShowDialog();
    }
    private void helloWorldToolStripMenuItem_Click(object sender, EventArgs e)
    {
      Frm_HelloWorld HelloWorld = new Frm_HelloWorld();
      HelloWorld.ShowDialog();
    }

    private void mnu_principal_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
    {

    }
    private void mascaraToolStripMenuItem_Click(object sender, EventArgs e)
    {
      Frm_Mask Mask = new Frm_Mask();
      Mask.ShowDialog();
    }
    private void vaídaCpfToolStripMenuItem_Click(object sender, EventArgs e)
    {
      Frm_ValidateCPF ValidateCPF = new Frm_ValidateCPF();
      ValidateCPF.ShowDialog();
    }
    private void valídaCPF2ToolStripMenuItem_Click(object sender, EventArgs e)
    {
      Frm_ValidateCPF_2 ValidateCPF_2 = new Frm_ValidateCPF_2();
      ValidateCPF_2.ShowDialog();
    }
    private void checaSenhaToolStripMenuItem_Click(object sender, EventArgs e)
    {
      Frm_CheckPassword CheckPassword = new Frm_CheckPassword();
      CheckPassword.ShowDialog();
    }

    private void sairToolStripMenuItem_Click(object sender, EventArgs e)
    {
      Application.Exit();
    }
  }
}
