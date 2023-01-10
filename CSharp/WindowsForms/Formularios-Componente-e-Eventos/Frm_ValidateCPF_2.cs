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
  public partial class Frm_ValidateCPF_2: Form
  {
    public Frm_ValidateCPF_2()
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
