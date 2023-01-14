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
  public partial class Frm_Login: Form
  {
    public Frm_Login()
    {
      InitializeComponent();

      lbl_login.Text = "Usuário";
      lbl_password.Text = "Senha";
      btn_cancel.Text = "Cancel";
      btn_ok.Text = "OK";
    }
    public string password;
    public string login;

    private void btn_ok_Click(object sender, EventArgs e)
    {
      DialogResult = DialogResult.OK;

      password = txt_password.Text;
      login = txt_login.Text;

      this.Close();
    }

    private void btn_cancel_Click(object sender, EventArgs e)
    {
      DialogResult = DialogResult.Cancel;
      this.Close();
    }
  }
}
