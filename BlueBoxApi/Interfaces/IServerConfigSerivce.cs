using System;

namespace NewLibre;

public interface IServerConfigService{
   public bool Save(ServerConfiguration config);
}
