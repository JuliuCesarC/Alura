using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Formularios_Componente_e_Eventos.FormsUserControl
{
  public partial class Frm_KeyDown_UC: UserControl
  {
    public Frm_KeyDown_UC()
    {
      InitializeComponent();
    }

    private void txt_input_KeyDown(object sender, KeyEventArgs e)
    {
      txt_msg.AppendText("\r\n" + "precionei uma tecla " + e.KeyCode + "\r\n");
      txt_msg.AppendText("\t" + "Código da tecla: " + ((int)e.KeyCode) + "\r\n");
      lbl_lower.Text = e.KeyCode.ToString().ToLower();
      lbl_upper.Text = e.KeyCode.ToString().ToUpper();
    }

    private void btn_reset_Click(object sender, EventArgs e)
    {
      txt_msg.Text = "";
      txt_input.Text = "";
      lbl_upper.Text = "";
      lbl_lower.Text = "";
    }
  }
}
