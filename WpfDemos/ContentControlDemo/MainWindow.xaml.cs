using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            BaseViewModelProp = new UserControl2WithBlueBackgroudViewModel();
        }

        private BaseViewModel _baseViewModelProp;
        public BaseViewModel BaseViewModelProp
        {
            get { return _baseViewModelProp; }
            set
            {
                _baseViewModelProp = value;
                OnPropertyChanged(new PropertyChangedEventArgs("BaseViewModelProp"));
            }
        }

        private void BlueButton_Click(object sender, RoutedEventArgs e)
        {
            _baseViewModelProp = new UserControl2WithBlueBackgroudViewModel();

        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            _baseViewModelProp = new UserControlWithGreenBackgroundViewModel();

        }
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            PropertyChanged?.Invoke(this, e);
        }
    }
}
