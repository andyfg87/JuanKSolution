using System.Diagnostics;
using System.Net;
using System.Net.NetworkInformation;

namespace JuanK.Maui.Services
{
    public static class NetworkDiagnostics
    {
        public static async Task<bool> CanPingServer(string ipAddress)
        {
            try
            {
                using var ping = new Ping();
                var reply = await ping.SendPingAsync(ipAddress, 3000);
                Debug.WriteLine($"Ping to {ipAddress}: {reply.Status} - {reply.RoundtripTime}ms");
                return reply.Status == IPStatus.Success;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Ping failed: {ex.Message}");
                return false;
            }
        }

        public static async Task TestNetworkConnection()
        {
            try
            {
                Debug.WriteLine("🌐 Starting network diagnostics...");

                // Test DNS resolution
                try
                {
                    var hostEntry = await Dns.GetHostEntryAsync("147.185.238.132");
                    Debug.WriteLine($"DNS Resolution: {hostEntry.HostName}");
                }
                catch (Exception dnsEx)
                {
                    Debug.WriteLine($"DNS Error: {dnsEx.Message}");
                }

                // Test Ping
                var canPing = await CanPingServer("147.185.238.132");
                Debug.WriteLine($"Ping Test: {(canPing ? "SUCCESS" : "FAILED")}");

                // Test HTTP connection
                using var testClient = new HttpClient { Timeout = TimeSpan.FromSeconds(10) };
                var response = await testClient.GetAsync("http://147.185.238.132:81");
                Debug.WriteLine($"HTTP Test: {response.StatusCode}");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Network Diagnostic Error: {ex.Message}");
            }
        }
    }
}