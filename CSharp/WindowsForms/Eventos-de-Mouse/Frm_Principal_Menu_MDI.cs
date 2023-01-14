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
  public partial class Frm_Principal_Menu_MDI: Form
  {
    public Frm_Principal_Menu_MDI()
    {
      InitializeComponent();
    }
    private void mnu_principal_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
    {

    }
    private void demonstraçãoKeyToolStripMenuItem_Click(object sender, EventArgs e)
    {
      Frm_keyDown KeyDown = new Frm_keyDown();
      KeyDown.MdiParent= this;
      KeyDown.Show();
    }
    private void helloWorldToolStripMenuItem_Click(object sender, EventArgs e)
    {
      Frm_HelloWorld HelloWorld = new Frm_HelloWorld();
      HelloWorld.MdiParent= this;
      HelloWorld.Show();
    }

    private void mascaraToolStripMenuItem_Click(object sender, EventArgs e)
    {
      Frm_Mask Mask = new Frm_Mask();
      Mask.MdiParent= this;
      Mask.Show();
    }
    private void vaídaCpfToolStripMenuItem_Click(object sender, EventArgs e)
    {
      Frm_ValidateCPF ValidateCPF = new Frm_ValidateCPF();
      ValidateCPF.MdiParent= this;
      ValidateCPF.Show();
    }
    private void valídaCPF2ToolStripMenuItem_Click(object sender, EventArgs e)
    {
      Frm_ValidateCPF_2 ValidateCPF_2 = new Frm_ValidateCPF_2();
      ValidateCPF_2.MdiParent= this;
      ValidateCPF_2.Show();
    }
    private void checaSenhaToolStripMenuItem_Click(object sender, EventArgs e)
    {
      Frm_CheckPassword CheckPassword = new Frm_CheckPassword();
      CheckPassword.MdiParent= this;
      CheckPassword.Show();
    }

    private void sairToolStripMenuItem_Click(object sender, EventArgs e)
    {
      Application.Exit();
    }

    private void cascataToolStripMenuItem_Click(object sender, EventArgs e)
    {
      this.LayoutMdi(System.Windows.Forms.MdiLayout.Cascade);
    }

    private void horizontalToolStripMenuItem_Click(object sender, EventArgs e)
    {
      this.LayoutMdi(System.Windows.Forms.MdiLayout.TileHorizontal);
    }

    private void verticalToolStripMenuItem_Click(object sender, EventArgs e)
    {
      this.LayoutMdi(System.Windows.Forms.MdiLayout.TileVertical);
    }
  }
}