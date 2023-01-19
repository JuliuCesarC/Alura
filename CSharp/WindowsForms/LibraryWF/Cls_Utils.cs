using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LibraryWF
{
  public class Cls_Utils
  {
    public static bool CheckPassword(string password)
    {
      if (password == "Curso")
      {
        return true;
      }
      else
      {
        return false;
      }
    }
    public static string GeraJSONCEP(string CEP)
    {
      System.Net.HttpWebRequest requisicao = (HttpWebRequest)WebRequest.Create("https://viacep.com.br/ws/" + CEP + "/json/");
      // A 'HttpWebRequest' serve para criar uma requisição HTTP.
      HttpWebResponse resposta = (HttpWebResponse)requisicao.GetResponse();
      // E a 'HttpWebResponse' serve para obter a resposta.

      int cont;
      byte[] buffer = new byte[1000];
      // Como iremos utilizar o 'Stream' para o fluxo de dados, então criamos uma variável 'buffer' para armazenar os dados.
      StringBuilder sb = new StringBuilder();
      // Já o 'StringBuilder' sera utilizado para acumular a resposta e gerar um texto.
      string temp;
      // 'temp' sera utilizado para armazenar temporariamente os dados durante o loop.
      Stream stream = resposta.GetResponseStream();
      // Com o 'Stream' obtemos o fluxo de dados da resposta HTTP.
      do
      {
        // Um resumo do funcionamento do loop. Primeiramente utilizamos o 'stream.Read' para ler o fluxo de dados e armazenar uma parte dele no 'buffer' e também serve para atribuir a variável 'cont' a quantidade de bytes lidos. Usando o 'Encoding.Default', armazenamos na variável "temp" a conversão da resposta para 'string'. Como ja vimos anteriormente, juntamos os dados na variável 'sb', formando o texto.
        cont = stream.Read(buffer, 0, buffer.Length);
        temp = Encoding.UTF8.GetString(buffer, 0, cont).Trim();
        sb.Append(temp);
      } while (cont > 0);
      // O loop continua até não ter mais dados para ler, então abaixo retornamos os dados em forma de 'string'.
      return sb.ToString();
    }
    public static bool Valida(string cpf)
    {
      int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
      int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
      string tempCpf;
      string digito;
      int soma;
      int resto;
      cpf = cpf.Trim();
      cpf = cpf.Replace(".", "").Replace("-", "");
      if (cpf.Length != 11)
        return false;
      tempCpf = cpf.Substring(0, 9);
      soma = 0;
      for (int i = 0; i < 9; i++)
        soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
      resto = soma % 11;
      if (resto < 2)
        resto = 0;
      else
        resto = 11 - resto;
      digito = resto.ToString();
      tempCpf = tempCpf + digito;
      soma = 0;
      for (int i = 0; i < 10; i++)
        soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
      resto = soma % 11;
      if (resto < 2)
        resto = 0;
      else
        resto = 11 - resto;
      digito = digito + resto.ToString();
      return cpf.EndsWith(digito);
    }
  }

  public class ChecaForcaSenha
  {
    public enum ForcaDaSenha
    {
      Inaceitavel,
      Fraca,
      Aceitavel,
      Forte,
      Segura
    }
    public int geraPontosSenha(string senha)
    {
      if (senha == null) return 0;
      int pontosPorTamanho = GetPontoPorTamanho(senha);
      int pontosPorMinusculas = GetPontoPorMinusculas(senha);
      int pontosPorMaiusculas = GetPontoPorMaiusculas(senha);
      int pontosPorDigitos = GetPontoPorDigitos(senha);
      int pontosPorSimbolos = GetPontoPorSimbolos(senha);
      int pontosPorRepeticao = GetPontoPorRepeticao(senha);
      return pontosPorTamanho + pontosPorMinusculas + pontosPorMaiusculas + pontosPorDigitos + pontosPorSimbolos - pontosPorRepeticao;
    }
    private int GetPontoPorTamanho(string senha)
    {
      return Math.Min(10, senha.Length) * 7;
    }
    private int GetPontoPorMinusculas(string senha)
    {
      int rawplacar = senha.Length - Regex.Replace(senha, "[a-z]", "").Length;
      return Math.Min(2, rawplacar) * 5;
    }
    private int GetPontoPorMaiusculas(string senha)
    {
      int rawplacar = senha.Length - Regex.Replace(senha, "[A-Z]", "").Length;
      return Math.Min(2, rawplacar) * 5;
    }

    private int GetPontoPorDigitos(string senha)
    {
      int rawplacar = senha.Length - Regex.Replace(senha, "[0-9]", "").Length;
      return Math.Min(2, rawplacar) * 6;
    }

    private int GetPontoPorSimbolos(string senha)
    {
      int rawplacar = Regex.Replace(senha, "[a-zA-Z0-9]", "").Length;
      return Math.Min(2, rawplacar) * 5;
    }

    private int GetPontoPorRepeticao(string senha)
    {
      System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(@"(\w)*.*\1");
      bool repete = regex.IsMatch(senha);
      if (repete)
      {
        return 30;
      }
      else
      {
        return 0;
      }
    }
    public ForcaDaSenha GetForcaDaSenha(string senha)
    {
      int placar = geraPontosSenha(senha);

      if (placar < 50)
        return ForcaDaSenha.Inaceitavel;
      else if (placar < 60)
        return ForcaDaSenha.Fraca;
      else if (placar < 80)
        return ForcaDaSenha.Aceitavel;
      else if (placar < 100)
        return ForcaDaSenha.Forte;
      else
        return ForcaDaSenha.Segura;
    }
  }
}
