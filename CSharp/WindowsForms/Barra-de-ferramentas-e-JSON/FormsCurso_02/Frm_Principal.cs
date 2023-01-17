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
  public partial class Frm_Principal: Form
  {
    public Frm_Principal()
    {
      InitializeComponent();
    }

    private void btn_KeyDown_Click(object sender, EventArgs e)
    {
      Frm_keyDown KeyDown= new Frm_keyDown();
      KeyDown.ShowDialog();
    }

    private void bnt_Hello_Click(object sender, EventArgs e)
    {
      Frm_HelloWorld HelloWorld= new Frm_HelloWorld();
      HelloWorld.ShowDialog();
    }

    private void btn_Mask_Click(object sender, EventArgs e)
    {
      Frm_Mask Mask= new Frm_Mask();
      Mask.ShowDialog();
    }

    private void btn_VCPF_Click(object sender, EventArgs e)
    {
      Frm_ValidateCPF ValidateCPF= new Frm_ValidateCPF();
      ValidateCPF.ShowDialog();
    }

    private void btn_VCPF2_Click(object sender, EventArgs e)
    {
      Frm_ValidateCPF_2 ValidateCPF_2 = new Frm_ValidateCPF_2();
      ValidateCPF_2.ShowDialog();
    }

    private void btn_VPassword_Click(object sender, EventArgs e)
    {
      Frm_CheckPassword CheckPassword= new Frm_CheckPassword();
      CheckPassword.ShowDialog();
    }
  }
}
