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
  public partial class Frm_Question: Form
  {
    public Frm_Question(string message, string imageName)
    {
      InitializeComponent();

      Image myImage = (Image)global::Formularios_Componente_e_Eventos.Properties.Resources.ResourceManager.GetObject(imageName);

      pcb_question.Image = myImage;
      lbl_question.Text = message;
    }

    private void btn_run_Click(object sender, EventArgs e)
    {
      DialogResult = DialogResult.Yes;
      this.Close();
    }

    private void btn_stop_Click(object sender, EventArgs e)
    {
      DialogResult = DialogResult.Cancel;
      this.Close();
    }
  }
}
