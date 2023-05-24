using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MockAPI.Model;
using Newtonsoft.Json;

namespace MockAPI.Data
{
    public class MockDataContext : DbContext
    {
        
        public DbSet<MockDataSet> MockDataSets { get; set; }

        public MockDataContext(DbContextOptions<MockDataContext> options) : base(options)
        {

        }

        






    }
}
