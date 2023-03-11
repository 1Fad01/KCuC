using System;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;


namespace Addresses
{
    class Program
    {
        static void Main()
        {
            try
            {
                string remoteFilePath = @"\\remote-computer\shared-folder\file.txt";
                using (FileStream fileStream = File.Create(remoteFilePath))
                {
                    string surname = "Ivanov";
                    int groupNumber = 123;
                    string text = $"{surname}, {groupNumber}";
                    byte[] bytes = Encoding.UTF8.GetBytes(text);
                    fileStream.Write(bytes, 0, bytes.Length);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally { Console.ReadLine(); }
        }
    }
}

