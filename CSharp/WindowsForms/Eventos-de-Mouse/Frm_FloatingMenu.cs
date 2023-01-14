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
  public partial class Frm_FloatingMenu: Form
  {
    public Frm_FloatingMenu()
    {
      InitializeComponent();
    }

    private void Frm_FloatingMenu_MouseDown(object sender, MouseEventArgs e)
    {
      if( e.Button == MouseButtons.Right )
      {
        var ContextMenu = new ContextMenuStrip();
        // Representa o menu que iremos adicionar dinamicamente.
        var vTollTip001 = new ToolStripMenuItem();
        // Representa o item do menu.

        vTollTip001.Text = "Item menu 1";
        ContextMenu.Items.Add( vTollTip001 );
        ContextMenu.Show(this, new Point(e.X, e.Y));
      }
    }
  }
}
