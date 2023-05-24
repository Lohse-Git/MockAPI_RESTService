using MockAPI.Data;
using MockAPI.Model;
using System.Net.Sockets;
using System.Net;
using System.Text;

namespace MockAPI.UDP
{
    public class UDP_Receiver
    {
        //private readonly MockAPI.Data.MockDataContext _context;

        //public UDP_Receiver(MockAPI.Data.MockDataContext context)
        //{
        //    _context = context;
        //}


        //private static readonly IPAddress IpAddress = IPAddress.Parse("127.0.0.1");


        //public static async Task MainTask()
        //{
        //    int port = 7000;

        //    UdpClient udpClient = new UdpClient(port);



        //    try
        //    {
        //        while (true)
        //        {


        //            IPEndPoint remoteEP = null;

        //            byte[] data = udpClient.Receive(ref remoteEP);

        //            string receivingData = Encoding.ASCII.GetString(data);

        //            using (HttpClient httpClient = new HttpClient())
        //            {
        //                string api = "api/data/receive";
        //                var content = new StringContent(receivingData, Encoding.UTF8, "application/json");
        //                await httpClient.PostAsync(api, content);
        //            }

        //            using (var Context = new MockDataContext(null))
        //            {
        //                var mockData = new MockDataSet
        //                {
        //                    Temp = receivingData
        //                };

        //                Context.MockDataSets.Add(mockData);
        //                Context.SaveChanges();
        //            }

        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.ToString());
        //    }
        //    finally
        //    {
        //        udpClient.Close();
        //    }
        //}
    }
}
