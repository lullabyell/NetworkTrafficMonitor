using System;
using NetworkTrafficMonitor.Models;

namespace NetworkTrafficMonitor
{
    public static class Logger
    {
        public static void SetupLogging()
        {
            // Placeholder for setting up logging configuration if needed
        }

        public static void LogSuspiciousActivity(SuspiciousActivity activity)
        {
            if (activity == null)
            {
                throw new ArgumentNullException(nameof(activity));
            }

            if (activity.Packet == null)
            {
                throw new ArgumentNullException(nameof(activity.Packet));
            }

            string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss,fff");
            Console.WriteLine($"{timestamp} - INFO - Suspicious activity detected: {activity.Description}");
            Console.WriteLine($"Packet from {activity.Packet.SourceIP} to {activity.Packet.DestinationIP}");
            Console.WriteLine($"Data: {activity.Packet.Data}");
        }
    }
}
