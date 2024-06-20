using System.Runtime.InteropServices;

namespace nudge.Utilities
{
    /// <summary>
    /// Provides helper methods to monitor user activity.
    /// </summary>
    public static partial class ActivityHelper
    {
        /// <summary>
        /// Contains information about the last input event.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        private struct LASTINPUTINFO
        {
            public uint cbSize;
            public uint dwTime;
        }

        /// <summary>
        /// Retrieves the time of the last input event, in milliseconds.
        /// </summary>
        /// <param name="plii"></param>
        /// <returns></returns>
        [LibraryImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static partial bool GetLastInputInfo(ref LASTINPUTINFO plii);

        /// <summary>
        /// Gets the time since the last user input.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.ComponentModel.Win32Exception"></exception>
        public static TimeSpan GetIdleTime()
        {
            LASTINPUTINFO lastInputInfo = new();
            lastInputInfo.cbSize = (uint)Marshal.SizeOf(lastInputInfo);
            if (!GetLastInputInfo(ref lastInputInfo))
            {
                throw new System.ComponentModel.Win32Exception(Marshal.GetLastWin32Error());
            }

            uint idleTime = unchecked((uint)Environment.TickCount - lastInputInfo.dwTime);
            return TimeSpan.FromMilliseconds(idleTime);
        }

        /// <summary>
        /// Monitors user inactivity and invokes the specified action when inactivity is detected.
        /// </summary>
        /// <param name="inactivityThreshold"></param>
        /// <param name="onInactivityDetected"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static async Task MonitorInactivityAsync(TimeSpan inactivityThreshold, Action onInactivityDetected, CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                TimeSpan idleTime = GetIdleTime();

                if (idleTime >= inactivityThreshold)
                {
                    onInactivityDetected();
                }

                await Task.Delay(inactivityThreshold, cancellationToken);
            }
        }
    }
}
