using System;

namespace EventsAndDelegates3
{
    public class SpeedAlarm
    {
        private bool isOkay = true;
        public SpeedAlarm(Speedometer speedometer)
        {
            speedometer.SpeedModified += (speed) =>
            {
                if (speed > 120 && isOkay == true)
                {
                    AlarmUsingDriver();
                    isOkay = false;
                }

                if (speed <= 120)
                {
                    isOkay = true;
                }
            };
        }
        
        //Do not modify this method
        private void AlarmUsingDriver()
        {
            Console.WriteLine("You are exceeding the set speed limit of the car");
        }
    }
}