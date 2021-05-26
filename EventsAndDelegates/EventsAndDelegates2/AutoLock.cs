using System;

namespace EventsAndDelegates2
{
    public class AutoLock
    {
        private bool isLocked = false;

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