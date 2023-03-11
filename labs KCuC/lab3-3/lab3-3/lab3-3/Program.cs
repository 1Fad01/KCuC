using System;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;

namespace Addresses
{
    class Program
    {
        static void Main()
        {
            try
            {
                Console.WriteLine("Адрес петли обратной связи: {0}", IPAddress.Loopback);
                Console.WriteLine("Широковещательный IP-адрес: {0}", IPAddress.Broadcast);
                Console.WriteLine("Aдрес, обозначающий все сетевые интерфейсы данного узла: {0}", IPAddress.Any);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally { Console.ReadLine(); }
        }
    }
}