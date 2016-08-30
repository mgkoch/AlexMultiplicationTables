using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;

namespace AlexMultiplicationMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> hor = new List<int> { 3, 4, 5, 6, 7, 8, 9, 11 };
            List<int> ver = new List<int> { 3, 4, 5, 6, 7, 8, 9, 11 };
            using (Socket printer = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
            {
                StringBuilder sb = new StringBuilder();
                Random rnd = new Random();
                sb.AppendLine("Alex se maalsomme: " + DateTime.Now);
                sb.Append("|    |");
                while (hor.Count > 0)
                {
                    int index = rnd.Next(0, hor.Count);
                    sb.Append(String.Format(" {0,2} |", hor[index]));
                    hor.RemoveAt(index);
                }
                sb.AppendLine();
                sb.AppendLine("+----+----+----+----+----+----+----+----+----+");
                while (ver.Count > 0)
                {
                    int index = rnd.Next(0, ver.Count);
                    sb.AppendLine(string.Format("| {0,2} |    |    |    |    |    |    |    |    |", ver[index]));
                    sb.AppendLine("+----+----+----+----+----+----+----+----+----+");
                    ver.RemoveAt(index);
                }
                sb.AppendLine();
                printer.Connect(args[0], 9100);
                printer.Send(Encoding.ASCII.GetBytes(sb.ToString()));
                printer.Close();
            }
        }
    }
}
