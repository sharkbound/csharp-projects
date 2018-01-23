using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace UCC.Extensions
{
    public static class ExtensionMethods
    {
        public static string GetEndPointIP(this TcpClient c)
        {
            return ((IPEndPoint)c.Client.RemoteEndPoint).Address.ToString();
        }

        public static string GetEndPointPort(this TcpClient c)
        {
            return ((IPEndPoint)c.Client.RemoteEndPoint).Port.ToString();
        }

        public static async Task SendText(this TcpClient c, string text)
        {
            byte[] bytes = Encoding.ASCII.GetBytes(text+Environment.NewLine);
            await MainWindow.NwStream.WriteAsync(bytes, 0, bytes.Length);
        }

        public static async Task<string> Receive(this TcpClient c, bool trimNL = false)
        {
            byte[] bytesRecieved = new byte[c.ReceiveBufferSize];
            int readBytes = await MainWindow.NwStream.ReadAsync(bytesRecieved, 0, c.ReceiveBufferSize);
            //string txtRecieved = Encoding.ASCII.GetString(bytesRecieved, 0, readBytes);
            string txtRecieved = Encoding.UTF8.GetString(bytesRecieved, 0, readBytes);

            if (trimNL) txtRecieved = txtRecieved.Trim('\n');
            return txtRecieved;
        }
    }
}
