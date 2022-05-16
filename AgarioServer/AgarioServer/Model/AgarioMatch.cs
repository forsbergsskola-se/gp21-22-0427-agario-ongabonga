using System.Net.Sockets;
using AgarioServer.Networking;
using AgarioShared.AgarioShared.Model;
using AgarioShared.Messages;


namespace AgarioServer;

public class AgarioMatch
{
   AgarioClient? Onga{ get; set; }
   AgarioClient? Bonga{ get; set; }
   readonly MatchInfo matchInfo = new();

   public void InitOnga(TcpClient client)
   {
      Onga = new AgarioClient(client, this, matchInfo.onga);
   }
   public void InitBonga(TcpClient client)
   {
      Bonga = new AgarioClient(client, this, matchInfo.bonga);
   }

   public void DistributeMatchInfo()
   {
      var message = new MatchInfoMessage
      {
         matchInfo = this.matchInfo
      };
      Onga?.Connection.SendMessage(message);
      Bonga?.Connection.SendMessage(message);
   }

   public void Start()
   {
      while (true){
         if (!matchInfo.started)
         {
            if (matchInfo.onga.ready && matchInfo.bonga.ready)
            {
               Console.WriteLine("Start game!");
               matchInfo.started = true;
               DistributeMatchInfo();
            }
         }
      }
   }
}