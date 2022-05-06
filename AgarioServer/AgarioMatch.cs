using System.Net.Sockets;
using AgarioServer.Messages;

namespace AgarioServer;

public class AgarioMatch
{
   Connection? Onga{ get; set; }
   Connection? Bonga{ get; set; }
   public MatchInfo matchInfo = new MatchInfo();

   public void InitOnga(TcpClient client){
      Onga = new Connection(client, this, matchInfo.Onga);
   }
   public void InitBonga(TcpClient client){
      Bonga = new Connection(client, this, matchInfo.Bonga);
   }

   public void DistributeMatchInfo(){
      var message = new MatchInfoMessage{
         matchInfo = this.matchInfo
      };
      Onga?.SendMessage(message);
      Bonga?.SendMessage(message);
   }

   public void Start(){
      while (true){
         if (!matchInfo.started){
            if (matchInfo.Onga.ready && matchInfo.Bonga.ready){
               Console.WriteLine("Start game!");
               matchInfo.started = true;
               DistributeMatchInfo();
            }
         }
         else{
            //can someone even win this game??
         }
      }
   }
}