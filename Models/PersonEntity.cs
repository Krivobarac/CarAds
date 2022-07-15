namespace CarAds.Models
{
    public class PersonEntity
    {
        public int Id { get; set; }
        public string? Phone { get; set; }
        public byte? IsDeleted { get; set; }
        public virtual List<CarEntity>? Cars { get; set; }
    }
}
