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
  public partial class Frm_ValidateCPF: Form
  {
    public Frm_ValidateCPF()
    {
      InitializeComponent();
    }
    
    private void btn_clear_Click(object sender, EventArgs e)
    {
      msk_textCPF.Text = "";
      lbl_result.Text = "";
      msk_textCPF.Focus();
    }

    private void btn_validate_Click(object sender, EventArgs e)
    {
      bool validateCPF = false;
      validateCPF = Cls_Utils.Valida(msk_textCPF.Text);
      if( validateCPF )
      {
        lbl_result.Text = "CPF Válido";
        lbl_result.ForeColor = Color.Green;
      }
      else
      {
        lbl_result.Text = "CPF Inválido";
        lbl_result.ForeColor = Color.Red;
      }
    }
  }
}
