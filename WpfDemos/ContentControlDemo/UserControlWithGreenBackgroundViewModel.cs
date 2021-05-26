using System.Windows.Media;

namespace ContentControlDemo
{
    public class UserControlWithGreenBackgroundViewModel : BaseViewModel
    {
        public UserControlWithGreenBackgroundViewModel()
        {
            base.BackGroundColor = Brushes.Green;
        }
    }
}