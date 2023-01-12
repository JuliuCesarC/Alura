using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Formularios_Componente_e_Eventos
{
    public partial class Frm_HelloWorld_UC: UserControl
    {
        public Frm_HelloWorld_UC()
        {
            InitializeComponent();
        }

    private void btn_alteraTitulo_Click(object sender, EventArgs e)
    {
      lbl_Titulo.Text = txt_conteudoLabel.Text;
    }
  }
}
