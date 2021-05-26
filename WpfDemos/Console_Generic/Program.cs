using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Management;

namespace Console_Generic
{
    class Program
    {
        public class A
        {
            //public A()
            //{
            //    Console.WriteLine("I am from A ctor");
            //}

            public virtual void Method1()
            {
                Console.WriteLine("I am from A Method1");
            }
        }

        public class B : A
        {
            //public B()
            //{
            //    Console.WriteLine("I am from B ctor");
            //}

            public void Method1()
            {
                Console.WriteLine("I am from B Method1");
            }
        }

        public class C : B
        {
            //public C()
            //{
            //    Console.WriteLine("I am from C ctor");
            //}

            public void Method1()
            {
                Console.WriteLine("I am from C Method1");
            }
        }

        public class Ab
        {
            public Ab()
            {
                var a = new A();
                var c = new C();
                //Not working c = a;
                a = c;
                a.Method1();
            }
        }

        static void Main(string[] args)
        {
            //var data = new Ab();
            //Console.ReadLine();

            var mc = new ManagementClass("win32_processor");
            var moc = mc.GetInstances();
            var enumerator = moc.GetEnumerator();
            var data = enumerator.MoveNext() ? enumerator.Current.Properties["processorID"].Value.ToString() : string.Empty;

            //var userNameInBytes = System.Text.Encoding.UTF8.GetBytes(string.Empty);
            //var temp = userNameInBytes.ToList().Select(characterByte => (double) characterByte).ToList();
            //var data = temp.Select(inBytes => (byte) inBytes).ToArray();
            //var stringdata = System.Text.Encoding.UTF8.GetString(data);

            Console.ReadLine();
        }

        static void ShowConfig()
        {
            // For read access you do not need to call OpenExeConfiguraton
            foreach (string key in ConfigurationManager.AppSettings)
            {
                string value = ConfigurationManager.AppSettings[key];
                Console.WriteLine("Key: {0}, Value: {1}", key, value);
            }
        }

        private static void TempMethod()
        {
            // Open App.Config of executable
            System.Configuration.Configuration config =
                ConfigurationManager.OpenExeConfiguration
                    (ConfigurationUserLevel.None);

            // Add an Application Setting.
            config.AppSettings.Settings.Add("ModificationDate",
                DateTime.Now.ToLongTimeString() + " ");

            // Save the changes in App.config file.
            config.Save(ConfigurationSaveMode.Modified);

            // Force a reload of a changed section.
            ConfigurationManager.RefreshSection("appSettings");
            ShowConfig();
        }
    }
}