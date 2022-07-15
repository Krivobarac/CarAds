namespace CarAds.Models
{
    public class CarEntity
    {
        public int Id { get; set; }
        public int ModelId { get; set; }
        public virtual ModelEntity Model { get; set; }
        public string Year { get; set; }
        public int EngineDisplacement { get; set; }
        public string HP { get; set; }
        public int FuelId { get; set; }
        public virtual FuelEntity Fuel { get; set; }
        public int BodyId { get; set; }
        public virtual BodyEntity Body { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public byte? IsDeleted { get; set; }
        public int PersonId { get; set; }
        public virtual PersonEntity Person { get; set; }
    }
}
