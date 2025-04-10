namespace BlueBoxApi.Tests;
using NewLibre;
using System.IO;

public class MailServiceTests 
{
   //Redirect Console output to the terminal
   TextWriter terminalWriter; 
   public MailServiceTests(){
      terminalWriter = Console.Out;
      Console.SetOut(terminalWriter);
   }
    [Fact]
    public void GetInboxCount(){
      var pwd = File.ReadAllText(Path.Combine(AppContext.BaseDirectory.Split("bin")[0],"test.pwd"));
      var email = File.ReadAllText(Path.Combine(AppContext.BaseDirectory.Split("bin")[0],"email.pwd"));
      Console.WriteLine($"email: {email}");
      var server = File.ReadAllText(Path.Combine(AppContext.BaseDirectory.Split("bin")[0],"server.pwd"));
      Console.WriteLine($"server: {server}");
      ServerConfiguration sc = new(server, email, pwd, "./"); 
      Console.WriteLine($"error count: {sc.ValidationErrors.Count}");
      MailService ms = new(sc);
      ms.GetInboxMsgCount();
    }

    [Fact]
    public void GetTestDirectory(){
       Console.WriteLine($"Test proj file location: {AppContext.BaseDirectory}");
    }
}
