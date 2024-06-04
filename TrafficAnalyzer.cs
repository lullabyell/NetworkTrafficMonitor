using NetworkTrafficMonitor.Models;

namespace NetworkTrafficMonitor
{
    public class TrafficAnalyzer
    {
        public SuspiciousActivity? AnalyzePacket(Packet packet)
        {
            // Placeholder for actual analysis logic
            if (packet.Data.Contains("suspicious"))
            {
                return new SuspiciousActivity
                {
                    Timestamp = DateTime.Now,
                    Description = "Suspicious data detected",
                    Packet = packet
                };
            }
            return null;
        }
    }
}
