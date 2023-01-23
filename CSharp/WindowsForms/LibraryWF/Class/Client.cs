using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using LibraryWF.DataBase;

namespace LibraryWF.Class
{
  public class Client
  {
    public class Unit
    {
      [Required(ErrorMessage = "Código do cliente obrigatório.")]
      [RegularExpression("([0-9]+)", ErrorMessage = "Código do cliente deve conter apenas números.")]
      [StringLength(6, MinimumLength = 6, ErrorMessage = "Código do cliente deve conter 6 dígitos.")]
      public string ID { get; set; }
      [Required(ErrorMessage = "Nome do cliente obrigatório.")]
      [StringLength(50, ErrorMessage = "Nome do cliente pode conter no máximo 50 caracteres.")]
      public string Name { get; set; }
      [Required(ErrorMessage = "Nome da mãe obrigatório.")]
      [StringLength(50, ErrorMessage = "Nome da mãe pode conter no máximo 50 caracteres.")]
      public string MothersName { get; set; }
      [StringLength(50, ErrorMessage = "Nome do pai pode conter no máximo 50 caracteres.")]
      public string FathersName { get; set; }
      public bool HaveFather { get; set; }
      [Required(ErrorMessage = "CPF do cliente obrigatório.")]
      [RegularExpression("([0-9]+)", ErrorMessage = "CPF do cliente deve conter apenas números.")]
      [StringLength(11, MinimumLength = 11, ErrorMessage = "CPF do cliente deve conter 11 dígitos.")]
      public string CPF { get; set; }
      [Required(ErrorMessage = "Gênero obrigatório.")]
      public int Gender { get; set; }
      [Required(ErrorMessage = "CEP do cliente obrigatório.")]
      [RegularExpression("([0-9]+)", ErrorMessage = "CEP do cliente deve conter apenas números.")]
      [StringLength(8, MinimumLength = 8, ErrorMessage = "CEP do cliente deve conter 8 dígitos.")]
      public string CEP { get; set; }
      [Required(ErrorMessage = "Nome da rua obrigatório.")]
      [StringLength(100, ErrorMessage = "Nome da rua deve conter no máximo 100 caracteres.")]
      public string streetAddress { get; set; }
      [StringLength(50, ErrorMessage = "Complemento pode conter no máximo 50 caracteres.")]
      public string complement { get; set; }
      [Required(ErrorMessage = "Nome da cidade obrigatório.")]
      [StringLength(50, ErrorMessage = "Nome da cidade deve conter no máximo 50 caracteres.")]
      public string city { get; set; }
      [Required(ErrorMessage = "Nome do bairro obrigatório.")]
      [StringLength(50, ErrorMessage = "Nome do bairro deve conter no máximo 50 caracteres.")]
      public string district { get; set; }
      [Required(ErrorMessage = "Nome do estado obrigatório.")]
      [StringLength(50, ErrorMessage = "Nome do estado deve conter no máximo 50 caracteres.")]
      public string State { get; set; }
      public string profession { get; set; }
      [Required(ErrorMessage = "Renda familiar obrigatório.")]
      [Range(0, double.MaxValue, ErrorMessage = "Renda familiar deve ser positiva.")]
      public double familyIncome { get; set; }
      [Required(ErrorMessage = "Numero de telefone obrigatório.")]
      [RegularExpression("([0-9]+)", ErrorMessage = "Numero de telefone deve conter apenas números.")]
      public string phoneNumber { get; set; }

      public void CheckClass()
      {
        ValidationContext context = new ValidationContext(this, serviceProvider: null, items: null);
        List<ValidationResult> results = new List<ValidationResult>();
        // As primeiras 2 linhas esta capturando das diretivas o resultado dos testes. Pois acionamos o 'Required' em alguns campos.

        bool isValid = Validator.TryValidateObject(this, context, results, true);
        // O 'TryValidateObject' valida os testes, e caso alguns dos testes tenha um problema, ira retornar false.  

        if( isValid == false )
        {
          StringBuilder sbrErrors = new StringBuilder();
          foreach( var validationResult in results )
          // O 'foreach' é para mostrar na tela todos os erros, e não apenas o primeiro erro.
          {
            sbrErrors.AppendLine(validationResult.ErrorMessage);
            // O método 'AppendLine' do 'StringBuilder' esta sendo utilizado para colocar cada mensagem de erro em linhas separadas.
          }
          throw new ValidationException(sbrErrors.ToString());
          // Com isso iremos forçar um erro com o 'throw', exibindo todas as mensagem que escolhemos no 'Required'.
        }
      }
      public void CheckComplement()
      {
        if( this.FathersName == this.MothersName )
        {
          throw new Exception("Nome da mãe não pode ser igual a do pai");
        }
        if( this.HaveFather == true && this.FathersName.Trim() == "" )
        {
          throw new Exception("Nome do pai deve ser informado caso a opção esteja marcada");
        }

        bool checkCPF = Cls_Utils.Valida(this.CPF);

        if( !checkCPF )
        {
          throw new Exception("CPF invalido");
        }
      }

      #region CRUD do fichario
      // --------------- // ---------------
      public void addBinder(string connection)
      {
        Binder F = new Binder(connection);
        if( F.status )
        {
          string clientJson = SerializedClassUnit(this);
          F.AddClient(this.ID, clientJson);
          if( !F.status )
          {
            throw new Exception(F.message);
          }
        }
        else
        {
          throw new Exception(F.message);
        }
      }
      // --------------- // ---------------
      public Unit searchBinder(string id, string connection)
      {
        Binder F = new Binder(connection);
        if( F.status )
        {
          string clientJSON = F.Search(id);
          return DesSerializedClassUnit(clientJSON);
        }
        else
        {
          throw new Exception(F.message);
        }
      }
      // --------------- // ---------------
      public void Save(string connection)
      {
        Binder F = new Binder(connection);
        if( F.status )
        {
          string clientJson = SerializedClassUnit(this);
          F.Save(this.ID, clientJson);
          if( !F.status )
          {
            throw new Exception(F.message);
          }
        }
        else
        {
          throw new Exception(F.message);
        }
      }
      // --------------- // ---------------
      public void Delete(string connection)
      {
        Binder F = new Binder(connection);
        if( F.status )
        {
          F.Delete(this.ID);
          if( !F.status )
          {
            throw new Exception(F.message);
          }
        }
        else
        {
          throw new Exception(F.message);
        }
      }
      // --------------- // ---------------
      public List<string> searchAllBinder(string connection)
      {
        Binder F = new Binder(connection);
        if( F.status )
        {
          return F.SearchAll();
        }
        else
        {
          throw new Exception(F.message);
        }
      }
      #endregion

    }

    public class List
    {
      public List<Unit> listUnit { get; set; }
    }


    public static Unit DesSerializedClassUnit(string vJson)
    {
      return JsonConvert.DeserializeObject<Unit>(vJson);
    }
    public static string SerializedClassUnit(Unit unit)
    {
      return JsonConvert.SerializeObject(unit);
    }
  }
}
