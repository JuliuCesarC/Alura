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
  public partial class Frm_MouseEvent: Form
  {
    public Frm_MouseEvent()
    {
      InitializeComponent();
    }

    private void btn_mouse_MouseEnter(object sender, EventArgs e)
    {
      btn_mouse.Text = "Mouse enter";
    }

    private void btn_mouse_MouseLeave(object sender, EventArgs e)
    {
      btn_mouse.Text = "Mouse leave";
    }

    private void btn_mouse_MouseDown(object sender, MouseEventArgs e)
    {
      btn_mouse.Text = "Mouse down";
    }

    private void btn_mouse_MouseUp(object sender, MouseEventArgs e)
    {
      btn_mouse.Text = "Mouse up";
    }
  }
}
