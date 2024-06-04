using System;
using NetworkTrafficMonitor.Models;

namespace NetworkTrafficMonitor
{
    class Program
    {
        static void Main(string[] args)
        {
            Logger.SetupLogging();

            string networkInterface = args.Length > 0 ? args[0] : "default";
            NetworkMonitor monitor = new NetworkMonitor(networkInterface);
            TrafficAnalyzer analyzer = new TrafficAnalyzer();

            monitor.PacketCaptured += (sender, packet) =>
            {
                var activity = analyzer.AnalyzePacket(packet);
                if (activity != null)
                {
                    Logger.LogSuspiciousActivity(activity);
                }
            };

            monitor.Start();

            Console.WriteLine("Press any key to stop...");
            Console.ReadKey();

            monitor.Stop();
        }
    }
}
