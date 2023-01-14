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
  public partial class Frm_ImageFile_US: UserControl
  {
    public Frm_ImageFile_US(string imageFileName)
    {
      InitializeComponent();
      lbl_imageFile.Text = imageFileName;
      pic_imageFile.Image = Image.FromFile(imageFileName);
      // O 'Image.FromFile' retorna a imagem do caminho informado.
    }

    private void btn_color_Click(object sender, EventArgs e)
    {
      ColorDialog CDb = new ColorDialog();
      if( CDb.ShowDialog() == DialogResult.OK)
      {
        lbl_imageFile.ForeColor = CDb.Color;
        // A cor selecionada na caixa de cor ja esta no formate que é entendida pelo 'ForeColor'.
      }
    }

    private void bnt_font_Click(object sender, EventArgs e)
    {
      FontDialog FDb = new FontDialog();
      if( FDb.ShowDialog() == DialogResult.OK)
      {
        lbl_imageFile.Font = FDb.Font;
      }
    }
  }
}
