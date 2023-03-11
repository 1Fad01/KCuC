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
                IPGlobalProperties computerProperties = IPGlobalProperties.GetIPGlobalProperties();
                Console.WriteLine("Имя компьютера: {0}", computerProperties.HostName);
                Console.WriteLine("Имя домен: {0}", computerProperties.DomainName);

                NetworkInterface[] adapters = NetworkInterface.GetAllNetworkInterfaces();
                if (adapters == null || adapters.Length < 1)
                {
                    Console.WriteLine("Сетевые адаптеры не найдены");
                    return;
                }
                Console.WriteLine("Количество сетевых интерфейсов: {0}\n", adapters.Length);

                foreach (NetworkInterface adapter in adapters)
                {
                    Console.WriteLine(String.Empty.PadLeft(50,'='));
                    Console.WriteLine("Имя сетевого адаптера: {0}", adapter.Name);
                    Console.WriteLine("Тип сетевого интерфейса: {0}", adapter.NetworkInterfaceType);
                    Console.WriteLine("Описание интерфейса: {0}", adapter.Description);
                    Console.WriteLine("Состояние сетевого подключения: {0}", adapter.OperationalStatus);
                    PhysicalAddress physicalAddress = adapter.GetPhysicalAddress();
                    byte[] bytes = physicalAddress.GetAddressBytes();
                    Console.WriteLine("Физический адресс: ");
                    for (int i = 0; i < bytes.Length; i++)
                    {
                        Console.WriteLine("{0}", bytes[i].ToString("X2"));
                        if (i != bytes.Length - 1) { Console.WriteLine("-"); }
                    }
                    Console.WriteLine();
                    Console.WriteLine("Размер физического адреса: {0} байт", bytes.Length);

                    IPInterfaceProperties adaptersProperties = adapter.GetIPProperties();
                            
                    UnicastIPAddressInformationCollection unicastCollection = adaptersProperties.UnicastAddresses;
                    if (unicastCollection.Count > 0)
                    {
                        foreach (UnicastIPAddressInformation unicastAddr in unicastCollection)
                        {
                            if (unicastAddr.Address.AddressFamily == AddressFamily.InterNetwork)
                            {
                                Console.WriteLine("IPv4 адрес: {0}", unicastAddr.Address);
                                Console.WriteLine("Макса: {0}", unicastAddr.IPv4Mask);
                                Console.WriteLine("IPv4 размер: {0}", unicastAddr.Address.ToString().Length);
                                Console.WriteLine("Размер префикса: {0}", unicastAddr.PrefixLength.ToString());
                            }

                            if (unicastAddr.Address.AddressFamily == AddressFamily.InterNetworkV6)
                            {
                                Console.WriteLine("IPv6 адрес: {0}", unicastAddr.Address);
                                Console.WriteLine("Размер IPv6: {0}", unicastAddr.Address.ToString().Length);
                                Console.WriteLine("Размер префикса: {0}", unicastAddr.PrefixLength.ToString());
                            }
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally { Console.ReadLine(); }
        }
    }
}