using System.ComponentModel.DataAnnotations;

namespace CarAds.DTOs
{
    public class CarDTO
    {
        public int CarId { get; set; }
        [Required(ErrorMessage = "Brand is required")]
        public string Brand { get; set; }
        [Required(ErrorMessage = "Model is required")]
        public string Model { get; set; }
        [Required(ErrorMessage = "Year is required")]
        public string Year { get; set; }
        [Required(ErrorMessage = "Engine displacement is required")]
        public string EngineDisplacement { get; set; }
        [Required(ErrorMessage = "HP is required")]
        public string HP { get; set; }
        [Required(ErrorMessage = "Fuel is required")]
        public string Fuel { get; set; }
        [Required(ErrorMessage = "Body is required")]
        public string Body { get; set; }
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Price is required")]
        public string Price { get; set; }
        [Required(ErrorMessage = "Phone number is required")]
        public string Phone { get; set; }
        public virtual List<IFormFile>? ImageFiles { get; set; }
        public virtual List<string>? ImagePaths { get; set; }
    }
}
