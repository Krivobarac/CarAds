namespace CarAds.Models
{
    public class CarEntity
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Year { get; set; }
        public int EngineDisplacement { get; set; }
        public string HP { get; set; }
        public string Fuel { get; set; }
        public string Body { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        virtual public string Person { get; set; }
    }
}
