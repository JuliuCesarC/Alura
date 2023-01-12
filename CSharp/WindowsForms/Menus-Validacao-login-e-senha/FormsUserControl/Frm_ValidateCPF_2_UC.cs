using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibraryWF;

namespace Formularios_Componente_e_Eventos.FormsUserControl
{
  public partial class Frm_ValidateCPF_2_UC: UserControl
  {
    public Frm_ValidateCPF_2_UC()
    {
      InitializeComponent();
    }
    private void btn_clear_Click(object sender, EventArgs e)
    {
      msk_textCPF.Text = "";
      msk_textCPF.Focus();
    }

    private void btn_validate_Click(object sender, EventArgs e)
    {
      string vContent;
      vContent = msk_textCPF.Text;
      vContent = vContent.Replace(".", "").Replace("-", "");
      vContent = vContent.Trim();

      if( vContent == "" )
      {
        MessageBox.Show("É preciso informar um CPF", "Mensagem Validação", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
      else
      {
        if( vContent.Length != 11 )
        {
          MessageBox.Show("Um CPF precisa conter 11 digitos", "Mensagem Validação", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        else
        {
          if( MessageBox.Show("Deseja validar CPF?", "Mensagem de validação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes )
          {
            bool validateCPF = false;
            validateCPF = Cls_Utils.Valida(msk_textCPF.Text);
            if( validateCPF )
            {
              MessageBox.Show("CPF Válido", "Mensagem Validação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
              MessageBox.Show("CPF Inválido", "Mensagem Validação", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
          }
        }
      }


    }
  }
}
