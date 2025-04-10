using System;

namespace NewLibre; 

public class ServerConfigService : IServerConfigService{
   private IServerConfigurationRepo _serverConfigRepo;
   public ServerConfigService(IServerConfigurationRepo serverConfigRepo){
      _serverConfigRepo = serverConfigRepo;
   }
   
   public bool Save(ServerConfiguration config){
      _serverConfigRepo.Save(config);
      return true;
   }
}
