using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConnectUraFromHome
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                DisplayMenu();
                var data = ReadKeyData();
                var datastring = DisplayPressedKey(data);

                const string hostFilePath = @"C:\Windows\System32\drivers\etc\hosts";
                const string uraFromOffice = "10.50.38.3 ura-emea.audiology-solutions.net";
                const string uraFromHome = "#10.50.38.3 ura-emea.audiology-solutions.net";
                Execute(datastring, hostFilePath, uraFromOffice, uraFromHome);
            }
        }

        private static string DisplayPressedKey(ConsoleKeyInfo data)
        {
            var datastring = data.KeyChar.ToString();
            Console.WriteLine("Key Pressed:" + datastring);
            return datastring;
        }

        private static ConsoleKeyInfo ReadKeyData()
        {
            var data = Console.ReadKey();
            Console.WriteLine();
            return data;
        }

        private static void DisplayMenu()
        {
            Console.WriteLine("Menu");
            Console.WriteLine("1 : Connect Ura from Home");
            Console.WriteLine("2 : Connect Ura from Office");
            Console.WriteLine("3 : Exit");
            Console.Write("Enter the option :");
        }

        private static void Execute(string datastring, string hostFilePath, string uraFromOffice, string uraFromHome)
        {
            if (datastring.Equals("1"))
            {
                ReplaceString(hostFilePath, uraFromOffice, uraFromHome);
                StartInternetExplorerWithUra();
            }
            else if (datastring.Equals("2"))
            {
                ReplaceString(hostFilePath, uraFromHome, uraFromOffice);
                StartInternetExplorerWithUra();
            }
            else if (datastring.Equals("3"))
            {
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("BHAG.....");
                Console.ReadLine();
            }
        }

        private static void StartInternetExplorerWithUra()
        {
            Process.Start("IExplore.exe",
                @"https://ura-emea.audiology-solutions.net/dana-na/auth/url_13/welcome.cgi");
        }


        private static void ReplaceString(string filename, string search, string replace)
        {
            var sr = new StreamReader(filename);
            var rows = Regex.Split(sr.ReadToEnd(), "\r\n");
            sr.Close();

            var sw = new StreamWriter(filename);
            for (var i = 0; i < rows.Length; i++)
            {
                if (rows[i].Contains(search))
                {
                    rows[i] = rows[i].Replace(search, replace);
                }
                sw.WriteLine(rows[i]);
            }
            sw.Close();
        }

        #region UseFul Code

        //open URA
        //Process.Start("IExplore.exe", @"https://ura-emea.audiology-solutions.net/dana-na/auth/url_13/welcome.cgi");


        //Process.Start("notepad.exe", @"C:\Windows\System32\drivers\etc\hosts");

        //ReplaceString(@"C:\Windows\System32\drivers\etc\hosts", "10.50.38.3 ura-emea.audiology-solutions.net", "#10.50.38.3 ura-emea.audiology-solutions.net");
        //ReplaceString(@"C:\Windows\System32\drivers\etc\hosts", "#10.50.38.3 ura-emea.audiology-solutions.net", "10.50.38.3 ura-emea.audiology-solutions.net");
        #endregion
    }
}
