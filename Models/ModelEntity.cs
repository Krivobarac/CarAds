namespace CarAds.Models
{
    public class ModelEntity
    {
        public int Id { get; set; }
        public string ModelName { get; set; }
        public byte? IsDeleted { get; set; }
        public int BrandId { get; set; }
        public virtual BrandEntity Brand { get; set; }
    }
}
