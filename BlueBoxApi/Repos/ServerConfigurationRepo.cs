using System;
namespace NewLibre;

public class ServerConfigurationRepo: IServerConfigurationRepo{
   public bool Save(ServerConfiguration config){
      Console.WriteLine("Saving the ServerConfig to the db.");
      return true;
   }
}
