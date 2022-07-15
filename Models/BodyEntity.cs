using Microsoft.EntityFrameworkCore;

namespace CarAds.Models
{
    [Index(nameof(BodyName), IsUnique = true)]
    public class BodyEntity
    {
        public int Id { get; set; }
        public string BodyName { get; set; }
    }
}
