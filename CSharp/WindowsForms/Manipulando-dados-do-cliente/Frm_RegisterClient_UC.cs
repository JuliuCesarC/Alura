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
using LibraryWF.DataBase;

namespace Formularios_Componente_e_Eventos
{
  public partial class Frm_RegisterClient_UC : UserControl
  {
    string directory = "C:\\Users\\Cesar\\Desktop\\Curso_Dev\\Alura\\CSharp\\WindowsForms\\Manipulando-dados-do-cliente\\Banco-de-dados";
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
      foreach (var line in lines)
      {
        cmb_state.Items.Add(line);
      }
    }

    private void ClearForm()
    {
      txt_clientID.Text = "";
      txt_district.Text = "";
      txt_CEP.Text = "";
      txt_complement.Text = "";
      txt_CPF.Text = "";
      cmb_state.SelectedIndex = -1;
      txt_streetAddress.Text = "";
      txt_clientName.Text = "";
      txt_mothersName.Text = "";
      txt_fathersName.Text = "";
      txt_profession.Text = "";
      txt_familyIncome.Text = "";
      txt_phoneNumber.Text = "";
      txt_city.Text = "";
      chk_fathersName.Checked = true;
      rdb_male.Checked = true;
    }

    private void chk_fathersName_CheckedChanged(object sender, EventArgs e)
    {
      if (!chk_fathersName.Checked)
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

        string clientJson = Client.SerializedClassUnit(C);

        Binder F = new Binder(directory);
        if (F.status)
        {
          F.AddClient(C.ID, clientJson);
          if (F.status)
          {
            MessageBox.Show("OK: " + F.message, "ByteBank", MessageBoxButtons.OK, MessageBoxIcon.Information);
          }
          else
          {
            MessageBox.Show("ERRO: " + F.message, "ByteBank", MessageBoxButtons.OK, MessageBoxIcon.Error);
          }
        }
        else
        {
          MessageBox.Show("ERRO: " + F.message, "ByteBank", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
      }
      catch (ValidationException Ex)
      {
        MessageBox.Show(Ex.Message, "ByteBank", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
      catch (Exception Ex)
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

      if (chk_fathersName.Checked)
      {
        C.FathersName = txt_fathersName.Text;
        C.HaveFather = true;
      }
      else
      {
        C.HaveFather = false;
      }

      if (rdb_male.Checked)
      {
        C.Gender = 0;
      }
      if (rdb_female.Checked)
      {
        C.Gender = 1;
      }
      if (rdb_undefinedGender.Checked)
      {
        C.Gender = 2;
      }

      if (cmb_state.SelectedIndex < 0)
      {
        C.State = "";
      }
      else
      {
        C.State = cmb_state.Items[cmb_state.SelectedIndex].ToString();
      }

      if (Information.IsNumeric(txt_familyIncome.Text))
      {
        double income = Convert.ToDouble(txt_familyIncome.Text);
        if (income < 0)
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
      string vCEP = txt_CEP.Text.Trim();
      if (vCEP != "")
      {
        if (vCEP.Length == 8)
        {
          if (Information.IsNumeric(vCEP))
          {
            var vJSON = Cls_Utils.GeraJSONCEP(vCEP);

            CEP.Unit Cep = new CEP.Unit();
            Cep = CEP.DesSerializedClassUnit(vJSON);
            txt_streetAddress.Text = Cep.logradouro;
            txt_district.Text = Cep.bairro;
            txt_city.Text = Cep.localidade;

            for (int i = 0; i < cmb_state.Items.Count - 1; i++)
            {
              var vPos = Strings.InStr(cmb_state.Items[i].ToString(), "(" + Cep.uf + ")");
              if (vPos > 0)
              {
                cmb_state.SelectedIndex = i;
              }
            }
          }
        }
      }
    }

    private void clearToolStripButton1_Click(object sender, EventArgs e)
    {
      ClearForm();
    }

    private void abrirToolStripButton_Click(object sender, EventArgs e)
    {
      if (txt_clientID.Text == "")
      {
        MessageBox.Show("Código do cliente vazio.", "ByteBank", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
      else
      {
        Binder F = new Binder(directory);
        if (F.status)
        {
          string clientJSON = F.Search(txt_clientID.Text);

          Client.Unit C = new Client.Unit();
          C = Client.DesSerializedClassUnit(clientJSON);
          writeOnForm(C);
        }
        else
        {
          MessageBox.Show("ERRO: " + F.message, "ByteBank", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
      }
    }

    private void writeOnForm(Client.Unit C)
    {
      txt_clientID.Text = C.ID;
      txt_clientName.Text = C.Name;
      txt_mothersName.Text = C.MothersName;
      txt_CPF.Text = C.CPF;
      txt_CEP.Text = C.CEP;
      txt_streetAddress.Text = C.streetAddress;
      txt_complement.Text = C.complement;
      txt_city.Text = C.city;
      txt_district.Text = C.district;
      txt_profession.Text = C.profession;
      txt_phoneNumber.Text = C.phoneNumber;
      txt_familyIncome.Text = C.familyIncome.ToString();

      if (C.HaveFather)
      {
        txt_fathersName.Text = C.FathersName;
        C.HaveFather = true;
      }
      else
      {
        txt_fathersName.Text = "";
        C.HaveFather = false;
      }

      if (C.Gender == 0)
      {
        rdb_male.Checked = true;
      }
      if (C.Gender == 1)
      {
        rdb_female.Checked = true;
      }
      if (C.Gender == 2)
      {
        rdb_undefinedGender.Checked = true;
      }


      if (C.State == "")
      {
        cmb_state.SelectedIndex = -1;
      }
      else
      {
        for (int i = 0; i < cmb_state.Items.Count - 1; i++)
        {
          if (C.State == cmb_state.Items[i].ToString())
          {
            cmb_state.SelectedIndex = i;
          }
        }
      }

      if (Information.IsNumeric(txt_familyIncome.Text))
      {
        double income = Convert.ToDouble(txt_familyIncome.Text);
        if (income < 0)
        {
          C.familyIncome = 0;
        }
        else
        {
          C.familyIncome = income;
        }
      }
    }

    private void salvarToolStripButton_Click(object sender, EventArgs e)
    {
      try
      {
        Client.Unit C = new Client.Unit();
        C = FormDataToClass();
        C.CheckClass();
        C.CheckComplement();

        string clientJson = Client.SerializedClassUnit(C);

        Binder F = new Binder(directory);
        if (F.status)
        {
          F.Save(C.ID, clientJson);
          if (F.status)
          {
            MessageBox.Show("OK: " + F.message, "ByteBank", MessageBoxButtons.OK, MessageBoxIcon.Information);
          }
          else
          {
            MessageBox.Show("ERRO: " + F.message, "ByteBank", MessageBoxButtons.OK, MessageBoxIcon.Error);
          }
        }
        else
        {
          MessageBox.Show("ERRO: " + F.message, "ByteBank", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
      }
      catch (ValidationException Ex)
      {
        MessageBox.Show(Ex.Message, "ByteBank", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
      catch (Exception Ex)
      {
        MessageBox.Show(Ex.Message, "ByteBank", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    private void deleteToolStripButton1_Click(object sender, EventArgs e)
    {
      if (txt_clientID.Text.Trim() == "")
      {
        MessageBox.Show("Código do cliente  vazio.", "ByteBank", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
      else
      {
        Binder F = new Binder(directory);
        if (F.status)
        {
          string clientJson = F.Search(txt_clientID.Text);
          Client.Unit C = new Client.Unit();
          C = Client.DesSerializedClassUnit(clientJson);
          writeOnForm(C);

          Frm_Question Db = new Frm_Question("Deseja excluir cliente?", "Frm_Question");
          Db.ShowDialog();

          if (Db.DialogResult == DialogResult.Yes)
          {
            F.Delete(txt_clientID.Text);
            if (F.status)
            {
              MessageBox.Show("OK: " + F.message, "ByteBank", MessageBoxButtons.OK, MessageBoxIcon.Information);
              ClearForm();
            }
            else
            {
              MessageBox.Show("ERRO: " + F.message, "ByteBank", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
          }
        }
        else
        {
          MessageBox.Show("ERRO: " + F.message, "ByteBank", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
      }
    }
  }
}
