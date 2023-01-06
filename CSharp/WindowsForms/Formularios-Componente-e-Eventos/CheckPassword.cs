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
  public partial class CheckPassword: Form
  {
    public CheckPassword()
    {
      InitializeComponent();
    }

    private void btn_clear_Click(object sender, EventArgs e)
    {
      txt_password.Text = "";
      lbl_grade.Text = "";
    }

    private void txt_password_KeyDown(object sender, KeyEventArgs e)
    {
      ChecaForcaSenha Check = new ChecaForcaSenha();
      ChecaForcaSenha.ForcaDaSenha strong;

      strong = Check.GetForcaDaSenha(txt_password.Text);
      lbl_grade.Text = strong.ToString();
    }
  }
}
