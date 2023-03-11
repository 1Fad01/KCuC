using System;
using System.Net;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Введите DNS - имя: ");
        string dnsName = Console.ReadLine();
        try
        {
            IPHostEntry hostEntry = Dns.GetHostEntry(dnsName);

            Console.WriteLine($"IPv4 адрес ({hostEntry.AddressList.Length}):");
            foreach (IPAddress address in hostEntry.AddressList)
            {
                if (address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {
                    Console.WriteLine($"  {address}");
                }
            }

            Console.WriteLine($"IPv6 адрес ({hostEntry.AddressList.Length}):");
            foreach (IPAddress address in hostEntry.AddressList)
            {
                if (address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetworkV6)
                {
                    Console.WriteLine($"  {address}");
                }
            }

            Console.WriteLine($"Имя хоста: {hostEntry.HostName}");

            Console.WriteLine($"Имена-псевдонимы ({hostEntry.Aliases.Length}):");
            foreach (string alias in hostEntry.Aliases)
            {
                Console.WriteLine($"  {alias}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }
    }
}