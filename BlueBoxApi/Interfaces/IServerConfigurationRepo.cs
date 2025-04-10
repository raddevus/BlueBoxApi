using System;
namespace NewLibre;

public interface IServerConfigurationRepo{
   bool Save(ServerConfiguration config);
}
