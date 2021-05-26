using System;

namespace EventsAndDelegates3
{
    public class Speedometer
    {
        private event Action<int> speedMofified;

        private void SetCurrentSpeed(int speed)
        {
            if(speedMofified != null) speedMofified.Invoke(speed);
        }

        // Do not modify this method
        public void DeviceDriverLoop()
        {

            Console.WriteLine("Please enter option");
            Console.WriteLine("Press 8 to increase speed");
            Console.WriteLine("Press 2 to decrease speed");
            Console.WriteLine("Press 6 to maintain speed");
            Console.WriteLine("Press 4 to exit");

            Console.WriteLine();
            Console.WriteLine();

            int speed = 0;
            var loop = true;
            while (loop)
            {
                var x = Console.ReadKey().KeyChar;
                switch (x)
                {
                    case '8':
                        speed = speed + 10;
                        if (speed > 220) speed = 220;
                        break;
                    case '2':
                        speed = speed - 10;
                        if (speed < 0) speed = 0;
                        break;
                    case '6':
                        break;
                    default:
                        loop = false;
                        break;
                }
                Console.WriteLine("The speed is " + speed);
                SetCurrentSpeed(speed);
                Console.WriteLine();
            }
        }
    }
}