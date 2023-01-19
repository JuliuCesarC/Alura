using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibraryWF.Class;
using System.ComponentModel.DataAnnotations;
using Microsoft.VisualBasic;
using LibraryWF;
using Newtonsoft.Json;

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

      tls_principal.Items[0].ToolTipText = "Incluir cliente";
      tls_principal.Items[1].ToolTipText = "Seleciona cliente cadastrado";
      tls_principal.Items[2].ToolTipText = "Salvar alterações";
      tls_principal.Items[3].ToolTipText = "Apagar cliente";
      tls_principal.Items[4].ToolTipText = "Limpa dados do formulário";

      var file = "lista_de_estados.txt";
      var lines = File.ReadAllLines(file);
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

    private void novaToolStripButton_Click(object sender, EventArgs e)
    {
      try
      {
        Client.Unit C = new Client.Unit();
        C = FormDataToClass();
        C.CheckClass();
        C.CheckComplement();
        MessageBox.Show("Usuário adicionado com sucesso", "ByteBank", MessageBoxButtons.OK, MessageBoxIcon.Information);
      }
      catch( ValidationException Ex )
      {
        MessageBox.Show(Ex.Message, "ByteBank", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
      catch( Exception Ex )
      {
        MessageBox.Show(Ex.Message, "ByteBank", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }
    Client.Unit FormDataToClass()
    {
      Client.Unit C = new Client.Unit();
      C.ID = txt_clientID.Text;
      C.Name = txt_clientName.Text;
      C.MothersName = txt_mothersName.Text;
      C.CPF = txt_CPF.Text;
      C.CEP = txt_CEP.Text;
      C.streetAddress = txt_streetAddress.Text;
      C.complement = txt_complement.Text;
      C.city = txt_city.Text;
      C.district = txt_district.Text;
      C.profession = txt_profession.Text;
      C.phoneNumber = txt_phoneNumber.Text;

      if( chk_fathersName.Checked )
      {
        C.FathersName = txt_fathersName.Text;
        C.HaveFather = true;
      }
      else
      {
        C.HaveFather = false;
      }

      if( rdb_male.Checked )
      {
        C.Gender = 0;
      }
      if( rdb_female.Checked )
      {
        C.Gender = 1;
      }
      if( rdb_undefinedGender.Checked )
      {
        C.Gender = 2;
      }

      if( cmb_state.SelectedIndex < 0 )
      {
        C.State = "";
      }
      else
      {
        C.State = cmb_state.Items[cmb_state.SelectedIndex].ToString();
      }

      if( Information.IsNumeric(txt_familyIncome.Text) )
      {
        double income = Convert.ToDouble(txt_familyIncome.Text);
        if( income < 0 )
        {
          C.familyIncome = 0;
        }
        else
        {
          C.familyIncome = income;
        }
      }

      return C;
    }

    private void txt_CEP_Leave(object sender, EventArgs e)
    {
      string vCEP = txt_CEP.Text;
      if( vCEP != "" )
      {
        if( vCEP.Length == 8 )
        {
          if( Information.IsNumeric(vCEP) )
          {

            var vJSON = Cls_Utils.GeraJSONCEP(vCEP);

            CEP.Unit Cep = new CEP.Unit();
            Cep = CEP.DesSerializedClassUnit(vJSON);
            txt_streetAddress.Text = Cep.logradouro;
            txt_district.Text = Cep.bairro;
            txt_city.Text = Cep.localidade;
          }
        }
      }
    }
  }
}
