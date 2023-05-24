using MockAPI.Model;
using System.Net.Sockets;
using System.Net;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using MockAPI.Controllers;
using System.Diagnostics;

namespace MockAPI.Repositories

{
    public class MockRepos
    {
        public int _Nextid;
        public List<MockDataSet> mockDataSets;

        public MockDataSet Add(MockDataSet newData)
        {
            newData.Id = 0;
            return newData;
        }

        public MockRepos()
        {
            mockDataSets = new List<MockDataSet>()
           {
               new MockDataSet () {Id = _Nextid++, Temperature = "Test Temp"},
               new MockDataSet () {Id = _Nextid++, Temperature = "Test Temp2"},
               new MockDataSet () {Id = _Nextid++, Temperature = "Test Temp3"},
               new MockDataSet () {Id = _Nextid++, Temperature = "Test Temp4"}
           };
            _Nextid++;
        }

        public IEnumerable<MockDataSet> GetAll()
        {
            if (mockDataSets == null || mockDataSets.Count() <= 0) throw new ArgumentNullException("No Data Found");
            return mockDataSets;
        }

    }
}
