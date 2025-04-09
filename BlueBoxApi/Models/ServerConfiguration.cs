using System;
namespace NewLibre;

class ServerConfiguration{
   string AccountName{get;set;} // for user reminder
   string ServerUri{get;set;}
   string EmailAddress{get;set;}
   string Password{get;set;} // encryption to be done later
   string LocalStorePath{get;set;} // where all email for this account will be saved locally
   int Port{get;set;} = 993;
}
