using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace CarAds.Models
{
    [Index(nameof(BrandName), IsUnique = true)]
    public class BrandEntity
    {
        public int Id { get; set; }
        public string BrandName { get; set; }
        public byte? IsDeleted { get; set; }
        public virtual List<ModelEntity> Models { get; set; }
    }
}
