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
  public partial class Frm_RegisterClient_UC: UserControl
  {
    public Frm_RegisterClient_UC()
    {
      InitializeComponent();

      grb_clientCode.Text = "Código do Cliente";
      grb_address.Text = "Endereço";
      grb_income.Text = "Renda";
      grb_personalData.Text = "Dados pessoais";
      lbl_district.Text = "Bairro";
      lbl_CEP.Text = "CEP";
      lbl_complement.Text = "Complemento";
      lbl_CPF.Text = "CPF";
      lbl_state.Text = "Estado";
      lbl_streetAddress.Text = "Logradouro";
      lbl_clientName.Text = "Nome";
      lbl_mothersName.Text = "Nome da Mãe";
      lbl_fathersName.Text = "Nome do Pai";
      lbl_profession.Text = "Profissão";
      lbl_familyIncome.Text = "Renda Familiar";
      lbl_phoneNumber.Text = "Telefone";
      lbl_city.Text = "Cidade";
      chk_fathersName.Text = "Nome do pai";
      rdb_male.Text = "Masculino";
      rdb_female.Text = "Feminino";
      rdb_undefinedGender.Text = "Indefinido";

      var file = "lista_de_estados.txt";
      var lines = File.ReadAllLines(file);
      // Utilizando a classe 'File' para ler o arquivo 'txt' que possui todos os estados do Brasil, e fazendo um 'foreach' para adicionar todos os estados no 'ComboBox'.

      cmb_state.Items.Clear();
      foreach( var line in lines )
      {
        cmb_state.Items.Add(line);
      }
    }

    private void chk_fathersName_CheckedChanged(object sender, EventArgs e)
    {
      if( !chk_fathersName.Checked )
      {
        txt_fathersName.Enabled = false;
      }
      else
      {
        txt_fathersName.Enabled = true;
      }
    }
  }
}
