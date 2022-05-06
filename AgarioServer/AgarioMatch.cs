using System.Net.Sockets;

namespace AgarioServer;

public class AgarioMatch
{
   public TcpClient Onga;
   public TcpClient Bonga;
   public MatchInfo matchInfo = new MatchInfo();

   public void Start()
   {
      
   }
}