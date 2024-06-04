using System;
using System.Net.NetworkInformation;
using System.Threading;
using NetworkTrafficMonitor.Models;

namespace NetworkTrafficMonitor
{
    public class NetworkMonitor
    {
        public event EventHandler<Packet> PacketCaptured = delegate { };
        private string _networkInterface;
        private CancellationTokenSource _cancellationTokenSource;
        private Thread? _captureThread;

        public NetworkMonitor(string networkInterface)
        {
            _networkInterface = networkInterface;
            _cancellationTokenSource = new CancellationTokenSource();
        }

        public void Start()
        {
            Console.WriteLine($"{DateTime.Now:yyyy-MM-dd HH:mm:ss,fff} - INFO - Starting packet capture on interface {_networkInterface}");
            var cancellationToken = _cancellationTokenSource.Token;
            _captureThread = new Thread(() => CapturePackets(cancellationToken));
            _captureThread.Start();
        }

        public void Stop()
        {
            _cancellationTokenSource.Cancel();
            _captureThread?.Join(); // Ensure the thread is properly stopped
        }

        private void CapturePackets(CancellationToken cancellationToken)
        {
            int packetCount = 0;

            while (!cancellationToken.IsCancellationRequested)
            {
                packetCount++;
                Packet packet = new Packet
                {
                    SourceIP = "192.168.1.1",
                    DestinationIP = "192.168.1.2",
                    Data = packetCount % 2 == 0 ? "Example packet data suspicious" : "Example packet data " + packetCount
                };

                PacketCaptured?.Invoke(this, packet);
                Thread.Sleep(500); // Reduce the sleep time to make it more responsive
            }

            Console.WriteLine($"{DateTime.Now:yyyy-MM-dd HH:mm:ss,fff} - INFO - Packet capture stopped.");
        }
    }
}
