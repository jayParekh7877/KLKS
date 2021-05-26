using System.Windows.Media;

namespace ContentControlDemo
{
    public class UserControl2WithBlueBackgroudViewModel : BaseViewModel
    {
        public UserControl2WithBlueBackgroudViewModel()
        {
            base.BackGroundColor = Brushes.Blue;
        }
    }
}