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

      int numberToFetch = 10; // X messages

      using (var client = new ImapClient())
      {

            client.ServerCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) =>
          {
              // Log errors for diagnostics
              Console.WriteLine($"SSL Errors: {sslPolicyErrors}");
              // Accept if you trust the server
              return true;
          };
         client.Connect(server, port , true);
          client.Authenticate(email, password);

          var inbox = client.Inbox;


          inbox.Open(FolderAccess.ReadOnly); // ReadOnly ensures no changes

          // Fetch the first X messages
          for (int i = 0; i < Math.Min(numberToFetch, inbox.Count); i++)
          {
              var message = inbox.GetMessage(i);
              Console.WriteLine($"Subject: {message.Subject}");
          }

          client.Disconnect(true);
      }
      return 0;
   }

   public int GetInboxMsgCount(){
      using (var client = new ImapClient())
      {
         try
         {

            client.ServerCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) =>
          {
              // Log errors for diagnostics
              Console.WriteLine($"SSL Errors: {sslPolicyErrors}");
              // Accept if you trust the server
              return true;
          };
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
