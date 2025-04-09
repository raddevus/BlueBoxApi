using System;
using MailKit.Net.Imap;
using MailKit;
using MimeKit;

namespace NewLibre;

class MailService: IMailService{
   public ServerConfiguration Config{get;set;}
   MailService(ServerConfiguration config){
      this.Config = config;
   }

   public int GetMail(int numberOfMessages){
      var email = Config.EmailAddress;
      var password = Config.Password;
      var server = Config.ServerUri;
      var port = Config.Port;
      return 0;
   }
}
