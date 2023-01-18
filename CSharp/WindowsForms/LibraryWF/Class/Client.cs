using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace LibraryWF.Class
{
  public class Client
  {
    public class Unit
    {
      [Required(ErrorMessage = "Código do cliente obrigatório")]
      public string ID { get; set; }
      public string Name { get; set; }
      public string MothersName { get; set; }
      public string FathersName { get; set; }
      public bool HaveFather { get; set; }
      public string CPF { get; set; }
      public int Gender { get; set; }
      public string CEP { get; set; }
      public string streetAddress { get; set; }
      public string complement { get; set; }
      public string city { get; set; }
      public string district { get; set; }
      public string State { get; set; }
      public string profession { get; set; }
      public double familyIncome { get; set; }
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
          }
          throw new ValidationException(sbrErrors.ToString());
          // Com isso iremos forçar um erro com o 'throw', exibindo todas as mensagem que escolhemos no 'Required'.
        }
      }

    }
    public class List
    {
      public List<Unit> listUnit { get; set; }
    }
  }
}
