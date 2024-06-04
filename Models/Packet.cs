namespace NetworkTrafficMonitor.Models
{
    public class Packet
    {
        public string SourceIP { get; set; } = string.Empty;
        public string DestinationIP { get; set; } = string.Empty;
        public string Data { get; set; } = string.Empty;
    }
}
