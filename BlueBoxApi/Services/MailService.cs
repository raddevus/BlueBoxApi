using System;

namespace NewLibre;

class MailService: IMailService{
   public ServerConfiguration Config{get;set;}
   MailService(ServerConfiguration config){
      this.Config = config;
   }

   public int GetMail(int numberOfMessages){
      
    return 0;
   }
}
