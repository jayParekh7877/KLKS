using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ShowConfig();
            Add();
        }

        static void ShowConfig()
        {

            // Read a particular key from the config file            
           var sAttr = ConfigurationManager.AppSettings.Get("Key0");

            // For read access you do not need to call OpenExeConfiguraton
            foreach (string key in ConfigurationManager.AppSettings)
            {
                string value = ConfigurationManager.AppSettings[key];
            }
        }

        public void Add()
        {
            // Open App.Config of executable
           

            // Add an Application Setting.
            ConfigurationManager.AppSettings.Add("ModificationDate",
                DateTime.Now.ToLongTimeString() + " ");

            //// Save the changes in App.config file.
            //ConfigurationManager.AppSettings..Save(ConfigurationSaveMode.Modified);

            // Force a reload of a changed section.
            ConfigurationManager.RefreshSection("appSettings");
            ShowConfig();
        }
    }
}
