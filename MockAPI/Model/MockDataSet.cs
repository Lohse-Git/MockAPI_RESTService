using System.ComponentModel.DataAnnotations;

namespace MockAPI.Model
{
    public class MockDataSet
    {

        // DB Key
        [Key]
        public int Id { get; set; }


        // Current Temperature Updates every second
        public string Temperature { get; set; }

        public MockDataSet(string temperature)
        {
            Temperature = temperature;
        }
        public MockDataSet()
        {
            this.Temperature = Temperature;
        }


    }
}
