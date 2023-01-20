using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LibraryWF.DataBase
{
  public class Binder
  {
    public string directory { get; set; }
    public string message { get; set; }
    public bool status { get; set; }
    public Binder(string DirectoryFolder)
    {
      status = true;
      try
      {
        if( !Directory.Exists(DirectoryFolder) )
        {
          Directory.CreateDirectory(DirectoryFolder);
        }

        directory = DirectoryFolder;
        message = "Conexão criada com sucesso.";
      }
      catch( Exception Ex )
      {
        status = false;
        message = "Não foi possível efetuar a conexão: " + Ex.Message;
      }

    }

    public void AddClient(string id, string jsonUnit)
    {
      status = true;
      try
      {
        if( File.Exists(directory + "\\" + id + ".json") )
        {
          status = false;
          message = "Não é possivel incluir pois o ID ja esta sendo usado. ID: " + id;
        }
        else
        {
          File.WriteAllText(directory + "\\" + id + ".json", jsonUnit);
          status = true;
          message = "Cliente adicionado com sucesso.";
        }
      }
      catch( Exception Ex )
      {
        status = false;
        message = "Não foi possível efetuar a conexão: " + Ex.Message;
      }
    }
    public string Search(string id)
    {
      status = true;
      try
      {
        if( !File.Exists(directory + "\\" + id + ".json") )
        {
          status = false;
          message = "Identificador não existente: " + id;
        }
        else
        {
          string content = File.ReadAllText(directory + "\\" + id + ".json");
          status = true;
          message = "Cliente encontrado com sucesso.";
          return content;
        }

      }
      catch( Exception Ex )
      {
        status = false;
        message = "Não foi possível encontrar o cliente: " + Ex.Message;
      }
      return "";
    }
    public void Save(string id, string jsonUnit)
    {
      status = true;
      try
      {
        if( !File.Exists(directory + "\\" + id + ".json") )
        {
          status = false;
          message = "Cliente ainda não adicionado: " + id;
        }
        else
        {
          File.Delete(directory + "\\" + id + ".json");
          File.WriteAllText(directory + "\\" + id + ".json", jsonUnit);
          status = true;
          message = "Novos dados atualizados: " + id;
        }
      }
      catch( Exception Ex )
      {
        status = false;
        message = "Não foi possível efetuar a conexão: " + Ex.Message;
      }
    }
    public void Delete(string id)
    {
      status = true;
      try
      {
        if( !File.Exists(directory + "\\" + id + ".json") )
        {
          status = false;
          message = "Cliente não encontrado: " + id;
        }
        else
        {
          File.Delete(directory + "\\" + id + ".json");
          status = true;
          message = "Cliente excluido com sucesso: " + id;
        }
      }
      catch( Exception Ex )
      {
        status = false;
        message = "Não foi possível efetuar a conexão: " + Ex.Message;
      }
    }
    public List<string> SearchAll()
    {
      status = true;
      List<string> List = new List<string>();
      try
      {
        var files = Directory.GetFiles(directory, "*.json");
        for( int i = 0; i < files.Length - 1; i++ )
        {
          string content = File.ReadAllText(files[i]);
          List.Add(content);
        }
        return List;
      }
      catch( Exception Ex )
      {
        status = false;
        message = "Não foi possível encontrar o cliente: " + Ex.Message;
      }
      return List;
    }
  }
}
