using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using MockAPI.Model;
using System.Net;
using System.Net.Sockets;
using System.Text;
using MockAPI.Repositories;
using Microsoft.EntityFrameworkCore;
using MockAPI.Data;
using Microsoft.Identity.Client;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace MockAPI.Controllers
{
    public class ValuesController : Controller
    {
       
        private UdpClient udpClient;

        private readonly DbContextOptions<MockDataContext> dbContextOptions;

        public ValuesController(DbContextOptions<MockDataContext> dbContextOptions)
        {
            this.dbContextOptions = dbContextOptions;
        }

        [HttpPost]
        [Route("receive")]
        public ActionResult StartReceivingData()
        {
            udpClient = new UdpClient(7000);
            Task.Run(() => ReceiveData());

            return Ok();
        }

        public void ReceiveData()
        {
            try
            {
                while (true)
                {
                    using (var localDbContext = new MockDataContext(dbContextOptions))
                    {
                        IPEndPoint remoteEP = null;
                        byte[] data = udpClient.Receive(ref remoteEP);

                        string receivedData = Encoding.ASCII.GetString(data);

                        // Create a new instance of MockDataSet
                        var mockDataSet = new MockDataSet(receivedData);

                        // Add the MockDataSet to the database
                        localDbContext.MockDataSets.Add(mockDataSet);
                        localDbContext.SaveChanges();
                    }
                }
            }
            catch (SocketException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        [HttpGet]
        [Route("mockdata")]
        public ActionResult<IEnumerable<MockDataSet>> GetMockData()
        {
            try
            {
                using (var localDbContext = new MockDataContext(dbContextOptions))
                {
                    var mockData = localDbContext.MockDataSets.ToList();
                    return Ok(mockData);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500);
            }
        }

        [HttpPost]
        [Route("api/stop")]
        public ActionResult StopReceivingData()
        {
            udpClient.Close();
            return Ok();
        }

        // Decided not To Use = 

        //[ProducesResponseType(StatusCodes.Status204NoContent)]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[HttpGet]
        //[Route("Get")]
        //public IActionResult GetData()
        //{
        //    var data = dbContextOptions.ToList();

        //    return Ok(data);
        //}

        public IActionResult Index()
        {
            return View();
        }
    }
}
