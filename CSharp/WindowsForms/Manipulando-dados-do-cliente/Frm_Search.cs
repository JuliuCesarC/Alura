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
  public partial class Frm_Search: Form
  {
    public Frm_Search()
    {
      InitializeComponent();
      this.Text = "Busca";
      tls_principal.Items[0].ToolTipText = "Salvar a seleção";
      tls_principal.Items[1].ToolTipText = "Fechar a Seleção";
    }

    private void deleteToolStripButton1_Click(object sender, EventArgs e)
    {
        this.Close();
    }
  }
}
