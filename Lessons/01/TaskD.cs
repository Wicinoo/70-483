using System;

namespace Lessons._01
{
    /// <summary>
    /// Write your own example to demonstrate "covariance" of delegates.
    /// </summary>
    public class TaskD
    {
        delegate IDevice GetDevice();

        delegate MobileDevice GetMobileDevice();

        delegate DesktopDevice GetDesktopDevice();

        public static void Run()
        {
            GetDevice getDevice = GetRandomDevice;
            getDevice += GetSomeMobileDevice;
            getDevice += GetSomeDesktopDevice;
            getDevice();

            GetMobileDevice getMobileDevice = GetSomeMobileDevice;
            getMobileDevice();

            GetDesktopDevice getDesktopDevice = GetSomeDesktopDevice;
            getDesktopDevice();
        }

        static IDevice GetRandomDevice() {
            if (DateTime.Now.Second % 2 == 1)
            {
                return GetSomeMobileDevice();
            }
            else
            {
                return GetSomeDesktopDevice();
            }
        }

        static MobileDevice GetSomeMobileDevice()
        {
            Console.WriteLine("Mobile device created.");
            return new MobileDevice();
        }

        static DesktopDevice GetSomeDesktopDevice()
        {
            Console.WriteLine("Desktop device created.");
            return new DesktopDevice();
        }

    }

    interface IDevice {}

    class MobileDevice : IDevice {}

    class DesktopDevice : IDevice {}
}