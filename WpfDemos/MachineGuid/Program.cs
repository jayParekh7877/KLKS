using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace MachineGuid
{
    class Program
    {
        static void Main(string[] args)
        {
            var data = GetMachineGuid();
            Console.WriteLine($"MachineGuid = {data}");
            Console.ReadLine();
        }

        public static string GetMachineGuid()
        {
            const string location = @"SOFTWARE\Microsoft\Cryptography";
            const string name = "MachineGuid";

            using (var localMachineX64View =
                RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64))
            {
                using (var registryKey = localMachineX64View.OpenSubKey(location))
                {
                    if (registryKey == null) return string.Empty;

                    var machineGuid = registryKey.GetValue(name);
                    if (machineGuid == null) return string.Empty;

                    return machineGuid.ToString();
                }
            }
        }
    }
}
