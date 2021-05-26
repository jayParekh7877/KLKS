using System;
using System.Collections.Generic;
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

namespace ContentControlDemo
{
    /// <summary>
    /// Interaction logic for UserControl2WithBlueBackgroud.xaml
    /// </summary>
    public partial class UserControl2WithBlueBackgroud : UserControl
    {
        public UserControl2WithBlueBackgroud()
        {
            InitializeComponent();
            DataContext = new UserControl2WithBlueBackgroudViewModel();
        }
    }
}
