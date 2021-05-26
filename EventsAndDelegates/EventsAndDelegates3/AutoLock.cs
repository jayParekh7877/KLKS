using System;

namespace EventsAndDelegates3
{
    public class AutoLock
    {
       
        private event Action<int> _autoLockModified;

        private bool isLocked = false;

        public AutoLock(Speedometer speedometer)
        {
            speedometer.SpeedModified += (speed) =>
            {
                if(speed > 30) LockUsingDriver();
            };
        }

        //Do not modify this method
        private void LockUsingDriver()
        {
            if (isLocked == false)
            {
                Console.WriteLine("Door is locked");
                isLocked = true;
            }
        }
    }
}