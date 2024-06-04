using System;

namespace NetworkTrafficMonitor.Models
{
    public class SuspiciousActivity
    {
        public DateTime Timestamp { get; set; }
        public string Description { get; set; } = string.Empty;
        public Packet Packet { get; set; } = new Packet();
    }
}
