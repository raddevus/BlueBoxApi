namespace BlueBoxApi.Tests;
using NewLibre;
using System.IO;

public class MailHelperTests{
  

   private string pwd, email, server;
   //Redirect Console output to the terminal
   TextWriter terminalWriter; 
   public MailHelperTests(){
      terminalWriter = Console.Out;
      Console.SetOut(terminalWriter);
      pwd = File.ReadAllText(Path.Combine(AppContext.BaseDirectory.Split("bin")[0],"test.pwd"));
      email = File.ReadAllText(Path.Combine(AppContext.BaseDirectory.Split("bin")[0],"email.pwd"));
      Console.WriteLine($"email: {email}");
      server = File.ReadAllText(Path.Combine(AppContext.BaseDirectory.Split("bin")[0],"server.pwd"));
   }

    [Fact]
    public void RetrieveMessagesToFiles(){
      Console.WriteLine($"server: {server}");
      ServerConfiguration sc = new(server, email, pwd, "./"); 
      Console.WriteLine($"error count: {sc.ValidationErrors.Count}");
      MailService ms = new(sc);
      var message = ms.GetMessage(); 
      MailHelper.SaveMessage(message, email);
    }
}
