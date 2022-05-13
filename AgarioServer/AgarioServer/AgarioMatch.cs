using System.Net.Sockets;
using AgarioShared.AgarioShared.Messages;
using AgarioShared.AgarioShared.Model;

namespace AgarioServer.Networking;

public class AgarioMatch
{
   AgarioClient? Onga{ get; set; }
   AgarioClient? Bonga{ get; set; }
   private readonly MatchInfo matchInfo = new MatchInfo();

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
      Onga?.SendMessage(message);
      Bonga?.SendMessage(message);
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
         else
         {
            //can someone even win this game??
         }
      }
   }
}