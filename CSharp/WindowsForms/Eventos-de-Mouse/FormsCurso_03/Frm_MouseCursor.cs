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
  public partial class Frm_MouseCursor: Form
  {
    public Frm_MouseCursor()
    {
      InitializeComponent();
    }

    private void button1_Click(object sender, EventArgs e)
    {
      this.Cursor = Cursors.WaitCursor;
      for( int i = 0; i < 5; i++ )
      {
        Thread.Sleep(1000);
      }
      // É preciso atentar ao fato de que no final da aplicação precisamos voltar o cursor para o padrão, pois se não for feito o cursor ficara no formato que escolhermos acima até ser fechado o formulário.
      this.Cursor = Cursors.Default;
    }
  }
}
