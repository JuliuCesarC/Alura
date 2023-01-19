using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Formularios_Componente_e_Eventos.FormsUserControl
{
  public partial class Frm_Mask_UC: UserControl
  {
    public Frm_Mask_UC()
    {
      InitializeComponent();
    }

    private void btn_showPassword_Click(object sender, EventArgs e)
    {
      lbl_content.Text = msk_textBox.Text;
    }

    private void btn_hour_Click(object sender, EventArgs e)
    {
      msk_textBox.Mask = "00:00";
      lbl_format.Text = msk_textBox.Mask;
      lbl_content.Text = "";
      msk_textBox.Text = "";
      msk_textBox.UseSystemPasswordChar = false;
      msk_textBox.Focus();
    }

    private void btn_CEP_Click(object sender, EventArgs e)
    {
      msk_textBox.Mask = "00000-000";
      lbl_format.Text = msk_textBox.Mask;
      lbl_content.Text = "";
      msk_textBox.Text = "";
      msk_textBox.UseSystemPasswordChar = false;
      msk_textBox.Focus();
    }

    private void btn_currency_Click(object sender, EventArgs e)
    {
      msk_textBox.Mask = "$ 000,000,000.00";
      lbl_format.Text = msk_textBox.Mask;
      lbl_content.Text = "";
      msk_textBox.Text = "";
      msk_textBox.UseSystemPasswordChar = false;
      msk_textBox.Focus();
    }

    private void btn_date_Click(object sender, EventArgs e)
    {
      msk_textBox.Mask = "00/00/0000";
      lbl_format.Text = msk_textBox.Mask;
      lbl_content.Text = "";
      msk_textBox.Text = "";
      msk_textBox.UseSystemPasswordChar = false;
      msk_textBox.Focus();
    }

    private void btn_password_Click(object sender, EventArgs e)
    {
      msk_textBox.Mask = "000000";
      lbl_format.Text = msk_textBox.Mask;
      lbl_content.Text = "";
      msk_textBox.Text = "";
      msk_textBox.UseSystemPasswordChar = true;
      msk_textBox.Focus();
    }

    private void btn_phoneNumber_Click(object sender, EventArgs e)
    {
      msk_textBox.Mask = "(00)00000-0000";
      lbl_format.Text = msk_textBox.Mask;
      lbl_content.Text = "";
      msk_textBox.Text = "";
      msk_textBox.UseSystemPasswordChar = false;
      msk_textBox.Focus();
    }
  }
}
