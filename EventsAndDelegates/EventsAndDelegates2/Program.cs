using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsAndDelegates2
{
    class Program
    {
        static void Main(string[] args)
        {
            //The requirment is 
            //The lock should be engaged when the car speed increases above 30
            //The Speed alarm should be sounded when the care speed increases above 120
            
            //Modifiable code start
            Speedometer speedometer = new Speedometer();

            SpeedAlarm speedAlarm = new SpeedAlarm();

            AutoLock autoLock = new AutoLock();

            
            
            
            //Modifiable code end




            speedometer.DeviceDriverLoop();
        }

        
        
    }
}
