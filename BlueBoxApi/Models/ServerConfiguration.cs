using System;
namespace NewLibre;

class ServerConfiguration{
   public string AccountName{get;set;} // for user reminder
   public string ServerUri{get;set;}
   public string EmailAddress{get;set;}
   public string Password{get;set;} // encryption to be done later
   public string LocalStorePath{get;set;} // where all email for this account will be saved locally
   public int Port{get;set;} = 993;
   // Validate will run on construtor
   // Then user checks if ValidationErrors.Count > 0
   public List<string> ValidationErrors = new();
   
   public ServerConfiguration(string serverUri, string emailAddress, string password, string localStorePath){
      ServerUri = serverUri;
      EmailAddress = emailAddress;
      Password = password;
      LocalStorePath = localStorePath;
      Validate();
   }

   private void Validate(){

      if (!Directory.Exists(LocalStorePath)){
         ValidationErrors.Add($"LocalStorePath {LocalStorePath} doesn't exist."); 
      }

      if (String.IsNullOrEmpty(ServerUri)){
         ValidationErrors.Add($"ServerUri is blank. Please configure properly.");
      }
   }
}
