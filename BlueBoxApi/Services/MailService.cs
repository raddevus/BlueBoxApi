using System;
using MailKit.Net.Imap;
using MailKit;
using MimeKit;

namespace NewLibre;

public class MailService: IMailService{
   public ServerConfiguration Config{get;set;}
   public MailService(ServerConfiguration config){
      this.Config = config;
   }

   public int GetMail(int numberOfMessages){
      var email = Config.EmailAddress;
      var password = Config.Password;
      var server = Config.ServerUri;
      var port = Config.Port;
      return 0;
   }

   public int GetInboxMsgCount(){
      using (var client = new ImapClient())
      {
         try
         {
            Console.WriteLine($"In GetInboxMsgCount...{Config.ServerUri}");
            // Connect to the mail server
            client.Connect(Config.ServerUri, Config.Port, true);
            Console.WriteLine("Connected.");
            // Authenticate
            client.Authenticate(Config.EmailAddress, Config.Password);

            Console.WriteLine("Successfully connected and authenticated.");

            // Access the inbox
            var inbox = client.Inbox;
            inbox.Open(FolderAccess.ReadOnly);
            var msgCount = inbox.Count;
            Console.WriteLine($"You're inbox contains {msgCount} messages, ready for retrieval.");
            // Disconnect
            client.Disconnect(true);
            return msgCount;
         }
         catch (Exception ex){
            Console.WriteLine($"Failed! {ex.Message}");
            return -1; // error return
         }
      }
   }
}
