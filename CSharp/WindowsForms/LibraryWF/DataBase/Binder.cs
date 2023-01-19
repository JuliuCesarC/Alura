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
  }
}
