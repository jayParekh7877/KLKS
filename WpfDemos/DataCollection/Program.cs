using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Win32;

namespace DataCollection
{
    class Program
    {
        static void Main(string[] args)
        {


            var cpuInfo = GetCpuProcessorId();
            Console.WriteLine("Cpu Info : " + cpuInfo);
            Console.ReadLine();


            //var s = "testData";
            //var utf8Length = System.Text.Encoding.UTF8.GetByteCount(s);
            //var bytes = new byte[utf8Length + 1];
            //var utf8Lengthbytes = System.Text.Encoding.UTF8.GetBytes(s, 0, s.Length, bytes, 0);

            //var getstringfrombytes = System.Text.Encoding.UTF8.GetString(utf8Lengthbytes);

            //var data = new List<double>() {0,0,0,0,0,0};
            //var temp = GetUserNameFromProgramConfiguration(data);


            //var userNameInBytes = System.Text.Encoding.UTF8.GetBytes("a中文显示d");
            //var tempdata = System.Text.Encoding.UTF8.GetString(userNameInBytes);

            //var data = SetUserNameToProgramConfiguration("this is test data");
            //var temp = GetUserNameFromProgramConfiguration(data);

            //Console.ReadLine();



            //try
            //{
            //    Console.WriteLine("Line 1");
            //    Console.ReadLine();
            //    var userId = DataCollectionUserIdProviderService.GetUserId();
            //    Console.WriteLine("test Id :-> {0}",userId);
            //    Console.ReadLine();
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine(e);
            //}
        }

        public static string GetCpuProcessorId()
        {
            try
            {
                Console.WriteLine("Line 1 ");
                var mc = new ManagementClass("win32_processor");
                Console.WriteLine("Line 2 ");
                var moc = mc.GetInstances();
                Console.WriteLine("Line 3 ");
                var enumerator = moc.GetEnumerator();
                Console.WriteLine("Line 4 ");
                throw new InvalidOperationException("This is for test");
                if (enumerator.MoveNext() && enumerator.Current.Properties["processorID"].Value != null)
                {
                    Console.WriteLine("Line 5");
                    return enumerator.Current.Properties["processorID"].Value.ToString();
                }
               

            }
            catch (Exception exception)
            {
                var data  = new Exception(exception.Message,exception.InnerException);
                Console.WriteLine("Cpu id could not be found. Error :"+ exception);
            }
            return string.Empty;
        }

        private static string GetUserNameFromProgramConfiguration(IEnumerable<double> elements)
        {
            //TODO : if all are ZERO then its default value dont proccess and send null
            var userNameInBytes = elements.Select(element => (byte)element).ToArray();
            return System.Text.Encoding.UTF8.GetString(userNameInBytes);
        }


        private static IEnumerable<double> SetUserNameToProgramConfiguration(string userName)
        {
            //TODO : if all are ZERO then its default value dont proccess and dont store anything
            var userNameInBytes = System.Text.Encoding.UTF8.GetBytes(userName);
            return userNameInBytes.ToList().ConvertAll(characterByte => (double)characterByte).ToList();
        }

        static byte[] GetNullTerminatedUtf8(string s)
        {
            var utf8Length = System.Text.Encoding.UTF8.GetByteCount(s);
            var bytes = new byte[utf8Length + 1];
            utf8Length = System.Text.Encoding.UTF8.GetBytes(s, 0, s.Length, bytes, 0);
            return bytes;
        }
    }

    public class DataCollectionEncryptionProvider

    {
        public static byte[] GetMd5Hash(string input)

        {

            try
            {
                using (var md5Hash = MD5.Create())

                {

                    var inputBytes = Encoding.ASCII.GetBytes(input);

                    var hashValue = md5Hash.ComputeHash(inputBytes);

                    return hashValue;

                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error in Method Name :GetMd5Hash :-> {0}", e);
                Console.ReadLine();
                throw;
            }
        }

        public static string GetHexRepresentation(byte[] hash)

        {
            try
            {
                var sb = new StringBuilder();
                foreach (var _byte in hash)
                {

                    sb.Append(_byte.ToString("X2"));
                }

                return sb.ToString();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error in Method Name :GetHexRepresentation :-> {0}", e);
                Console.ReadLine();
                throw;
            }
        }

        public static string GetOddCharactersInHexRepresentation(string hexRepresentation)

        {
            try
            {
                var charArray = hexRepresentation.ToCharArray();

                var oddCharArray = charArray.ToList().Where((c, i) => i % 2 != 0);

                return string.Join("", oddCharArray);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error in Method Name :GetOddCharactersInHexRepresentation :-> {0}", e);
                Console.ReadLine();
                throw;
            }

           

        }
    }

    public class DataCollectionMachineGuidProvider
    {
        public static string GetMachineGuid()

        {

            const string location = @"SOFTWARE\Microsoft\Cryptography";

            const string name = "MachineGuid";

            try

            {

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

            catch (Exception e)

            {

                Console.WriteLine("Error in Method Name :GetMachineGuid :-> {0}", e);
                Console.ReadLine();
                throw;
            }

        }
    }

    public class DataCollectionCpuInformationProvider
    {
        public static string GetCpuProcessorId()

        {
            try
            {
                var mc = new ManagementClass("win32_processor");

                var moc = mc.GetInstances();

                var enumerator = moc.GetEnumerator();

                return enumerator.MoveNext() ? enumerator.Current.Properties["processorID"].Value.ToString() : string.Empty;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error in Method Name :GetCpuProcessorId :-> {0}", e);
                Console.ReadLine();
                throw;
            }

           

        }
    }

    public class DataCollectionUserIdProviderService 
    {
        public static string GetUserId()

        {
            try
            {
                var uniqueUserIdIdentifier = GetUniqueUserIdIdentifier();

                var hexRepresentationIn16Characters = GetHexRepresentationIn16Characters(uniqueUserIdIdentifier);

                return hexRepresentationIn16Characters;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error in Method Name :GetUserId :-> {0}", e);
                Console.ReadLine();
                throw;
            }

          

        }

        private static string GetUniqueUserIdIdentifier()
        {
            try
            {
                Console.WriteLine("Line 1.1");Console.ReadLine();
                var machineName = System.Environment.MachineName;
                Console.WriteLine("Line 1.2"); Console.ReadLine();
                var machineGuid = DataCollectionMachineGuidProvider.GetMachineGuid();
                Console.WriteLine("Line 1.3 {0}",machineGuid); Console.ReadLine();
                var cpuInfo = DataCollectionCpuInformationProvider.GetCpuProcessorId();
                Console.WriteLine("Line 1.4 {0}",cpuInfo); Console.ReadLine();
                var uniqueUserIdIdentifier = cpuInfo + machineGuid + machineName;
                Console.WriteLine("Line 1.5"); Console.ReadLine();
                return uniqueUserIdIdentifier;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error in Method Name :GetUniqueUserIdIdentifier :-> {0}", e);
                Console.ReadLine();
                throw;
            }
        }

        private static string GetHexRepresentationIn16Characters(string uniqueUserIdIdentifier)

        {
            try
            {
                var hash = DataCollectionEncryptionProvider.GetMd5Hash(uniqueUserIdIdentifier);

                var hexRepresentationForHash = DataCollectionEncryptionProvider.GetHexRepresentation(hash);

                var hexRepresentationIn16Characters =

                    DataCollectionEncryptionProvider.GetOddCharactersInHexRepresentation(hexRepresentationForHash);

                return hexRepresentationIn16Characters;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error in Method Name :GetHexRepresentationIn16Characters :-> {0}", e);
                Console.ReadLine();
                throw;
            }
           

        }
    }
}