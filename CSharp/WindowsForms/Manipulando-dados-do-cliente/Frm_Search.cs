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
    List<List<string>> _SearchList = new List<List<string>>();
    public string IdSelect { get; set; }
    public Frm_Search(List<List<string>> searchList)
    {
      InitializeComponent();
      _SearchList = searchList;
      this.Text = "Busca";
      tls_principal.Items[0].ToolTipText = "Salvar a seleção";
      tls_principal.Items[1].ToolTipText = "Fechar a Seleção";
      fillList();
      lst_search.Sorted = true;
    }

    private void fillList()
    {
      lst_search.Items.Clear();

      for( int i = 0; i < _SearchList.Count; i++ )
      {
        ItemBox item = new ItemBox();
        item.id = _SearchList[i][0];
        item.name = _SearchList[i][1];
        lst_search.Items.Add(item);
      }
    }

    private void deleteToolStripButton1_Click(object sender, EventArgs e)
    {
      DialogResult = DialogResult.Cancel;
      this.Close();
    }

    private void salvarToolStripButton_Click(object sender, EventArgs e)
    {
      ItemBox selectedItem = (ItemBox)lst_search.Items[lst_search.SelectedIndex];
      IdSelect = selectedItem.id;
      DialogResult = DialogResult.OK;
      this.Close();
    }

    class ItemBox
    {
      public string id { get; set; }
      public string name { get; set; }

      public override string ToString()
      {
        return name;
      }
    }
  }
}
