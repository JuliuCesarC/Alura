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
  public partial class Frm_MouseCapture: Form
  {
    public Frm_MouseCapture()
    {
      InitializeComponent();
    }

    private void button1_MouseDown(object sender, MouseEventArgs e)
    {
      string str1 = e.Location.ToString();
      string str2 = e.Button.ToString();

      MessageBox.Show("Localização do mouse: "+ str1+", e foi precionado o botão: "+ str2);
    }
  }
}
