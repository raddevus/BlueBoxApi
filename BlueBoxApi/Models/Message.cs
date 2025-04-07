using System;
namespace NewLibre;

class Message{
	public string From{get;set;}
	public string Body{get;set;}
	public string Subject{get;set;}
   public string FileName{get;set;} // file where email is saved
}
