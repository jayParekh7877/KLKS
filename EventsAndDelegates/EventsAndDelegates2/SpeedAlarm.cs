using System;

namespace EventsAndDelegates2
{
    public class SpeedAlarm
    {
        private bool isLocked = false;

        //Do not modify this method
        private void AlarmUsingDriver()
        {
            if (isLocked == false)
            {
                Console.WriteLine("You are exceeding the set speed limit of the car");
                isLocked = true;
            }
        }
    }
}