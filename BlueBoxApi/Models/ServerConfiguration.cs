using System;
namespace NewLibre;

class ServerConfiguration{
   public string AccountName{get;set;} // for user reminder
   public string ServerUri{get;set;}
   public string EmailAddress{get;set;}
   public string Password{get;set;} // encryption to be done later
   public string LocalStorePath{get;set;} // where all email for this account will be saved locally
   public int Port{get;set;} = 993;
}
