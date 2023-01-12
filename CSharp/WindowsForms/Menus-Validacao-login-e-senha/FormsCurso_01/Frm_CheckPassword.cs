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
  public partial class Frm_CheckPassword: Form
  {
    public Frm_CheckPassword()
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

      if( lbl_grade.Text == "Inaceitavel" | lbl_grade.Text == "Fraca" )
      {
        lbl_grade.ForeColor = Color.Red;
      }
      if( lbl_grade.Text == "Aceitavel" )
      {
        lbl_grade.ForeColor = Color.Blue;
      }
      if( lbl_grade.Text == "Forte" | lbl_grade.Text == "Segura" )
      {
        lbl_grade.ForeColor = Color.Green;
      }
    }

    private void btn_verSenha_Click(object sender, EventArgs e)
    {
      if( txt_password.PasswordChar != '\0' )
      {
        txt_password.PasswordChar = '\0';
        // A propriedade 'PasswordChar' só aceita 1 caractere como argumento, por isso é preciso utilizar aspas simples, e para representar um caractere vazio utilizamos '\0'.
        btn_showPassword.Text = "Esconder senha";
      }
      else
      {
        txt_password.PasswordChar = '*';
        btn_showPassword.Text = "Mostrar senha";
      }
    }
  }
}
