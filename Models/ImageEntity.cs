namespace CarAds.Models
{
    public class ImageEntity
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public int CarId { get; set; }
        public virtual CarEntity Car { get; set; }
    }
}
