using AutoMapper;
using CarAds.DTOs;
using CarAds.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CarAds.Managers
{
    public class CarManager
    {
        private readonly IMapper _mapper;
        private readonly ImageManager _imageManager;

        public CarManager(IMapper mapper, ImageManager imageManager)
        {
            _mapper = mapper;
            _imageManager = imageManager;
        }

        public void AddCar(CarDTO carDto)
        {
            PersonEntity person = _mapper.Map<PersonEntity>(carDto);
            CarEntity carEntity = _mapper.Map<CarEntity>(carDto);
            carEntity.Person = person;

            using (CarAdsContext ctx = new CarAdsContext())
            {
                carEntity = ctx.Cars.Add(carEntity).Entity;
                _imageManager.AddImages(carDto, carEntity, ctx);
                ctx.SaveChanges();
            }
        }

        public List<CarDTO> GetCars()
        {
            using (CarAdsContext ctx = new CarAdsContext())
            {
                return _mapper
                    .Map<List<CarDTO>>(
                        ctx.Cars
                        .Include(c => c.Model)
                        .ThenInclude(m => m.Brand)
                        .Include(c => c.Fuel)
                        .Include(c => c.Person)
                        .Include(c => c.Body)
                        .Include(c => c.Images)
                        .Where(c => c.IsDeleted != 1).ToList()
                    );
            }
        }

        public IEnumerable<SelectListItem> GetBrands()
        {
            using (CarAdsContext ctx = new CarAdsContext())
            {
                return _mapper.Map<List<SelectListItem>>(ctx.Brands.ToList());
            }
        }

        public List<SelectListItem> GetModels(int brandId)
        {
            using (CarAdsContext ctx = new CarAdsContext())
            {
                return _mapper.Map<List<SelectListItem>>(ctx.Models.Where(m => m.BrandId == brandId).ToList());
            }
        }

        public IEnumerable<SelectListItem> GetBodies()
        {
            using (CarAdsContext ctx = new CarAdsContext())
            {
                return _mapper.Map<List<SelectListItem>>(ctx.Bodies.ToList());
            }
        }

        public IEnumerable<SelectListItem> GetFuels()
        {
            using (CarAdsContext ctx = new CarAdsContext())
            {
                return _mapper.Map<List<SelectListItem>>(ctx.Fuels.ToList());
            }
        }

        public List<SelectListItem> GetYears()
        {
            int yearsNumber = 20;
            List<SelectListItem> years = new List<SelectListItem>();

            while (yearsNumber >= 0)
            {
                string year = DateTime.Now.AddYears(-yearsNumber).Year.ToString();
                years.Add(new SelectListItem { Text = year, Value = year });
                yearsNumber--;
            }

            years.Reverse();
            return years;
        }
    }
}
