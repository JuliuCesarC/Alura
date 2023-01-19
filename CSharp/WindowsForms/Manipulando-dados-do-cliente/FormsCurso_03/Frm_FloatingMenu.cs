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

    #region Exemplo_01
    //private void Frm_FloatingMenu_MouseDown(object sender, MouseEventArgs e)
    //{
    //  // Criando um menu flutuante e seus item:
    //  if( e.Button == MouseButtons.Right )
    //  {
    //    // O 'ContextMenuStrip' cria o menu dinamicamente.
    //    var ContextMenu = new ContextMenuStrip();

    //    // O 'ToolStripMenuItem' cria o item que iremos adicionar.
    //    // var vTollTip001 = new ToolStripMenuItem();
    //    // vTollTip001.Text = "Item menu 1";
    //    // ContextMenu.Items.Add( vTollTip001 );

    //    // Podemos criar os itens um por um e adicionar ele no Menu, ou podemos criar um método que retorna o item e então adicionar no Menu.

    //    ContextMenu.Items.Add(assembleItem("Novo item", "key"));
    //    ContextMenu.Items.Add(assembleItem("Item 2", "Frm_ValidaSenha"));
    //    ContextMenu.Show(this, new Point(e.X, e.Y));
    //  }
    //}
    //ToolStripMenuItem assembleItem(string text, string imageName)
    //{
    //  var item = new ToolStripMenuItem();
    //  item.Text = text;
    //  Image MyImage = (Image)Properties.Resources.ResourceManager.GetObject(imageName);
    //  item.Image = MyImage;

    //  return item;
    //}
    #endregion

    #region Exemplo_02
    private void Frm_FloatingMenu_MouseDown(object sender, MouseEventArgs e)
    {
      if( e.Button == MouseButtons.Right )
      {
        var ContextMenu = new ContextMenuStrip();

        var vToolTip01 = assembleItem("Novo item", "key");
        var vToolTip02 = assembleItem("Item 2", "Frm_ValidaSenha");

        ContextMenu.Items.Add(vToolTip01);
        ContextMenu.Items.Add(vToolTip02);
        ContextMenu.Show(this, new Point(e.X, e.Y));

        vToolTip01.Click += new System.EventHandler(vToolTip01_Click);
        vToolTip02.Click += new System.EventHandler(vToolTip02_Click);
      }
    }
    void vToolTip01_Click(object sender, EventArgs e)
    {
      MessageBox.Show("Opção 1 selecionada.");
    }
    void vToolTip02_Click(object sender, EventArgs e)
    {
      MessageBox.Show("Opção 2 selecionada.");
    }
    ToolStripMenuItem assembleItem(string text, string imageName)
    {
      var item = new ToolStripMenuItem();
      item.Text = text;
      Image MyImage = (Image)Properties.Resources.ResourceManager.GetObject(imageName);
      item.Image = MyImage;

      return item;
    }
    #endregion
  }
}
