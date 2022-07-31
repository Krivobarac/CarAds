using AutoMapper;
using CarAds.DTOs;
using CarAds.Models;
using NetVips;

namespace CarAds.Managers
{
    public class ImageManager
    {
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _hostEnvironment;

        public ImageManager(IMapper mapper, IWebHostEnvironment environment)
        {
            _mapper = mapper;
            _hostEnvironment = environment;
        }

        public void AddImages(CarDTO carDTO, CarEntity carEntity, CarAdsContext ctx)
        {
            List<Image> images = new List<Image>();
            List<ImageEntity> imageEntities = new List<ImageEntity>();

            if (carDTO.ImageFiles == null)
            {
                images.Add(GetReplacementImage());
                imageEntities.Add(
                    new ImageEntity
                    {
                        Car = carEntity,
                        Image = images.First().Filename.Split('\\').Last(),
                    });
            } else
            {
                imageEntities = _mapper.Map<List<ImageEntity>>(carDTO.ImageFiles);
                images = ConvertIFormFilesToImageList(carDTO.ImageFiles);
            }

            foreach (ImageEntity imageEntity in imageEntities)
            {
                imageEntity.Car = carEntity;
                imageEntity.Image = @"\assets\images\car-images\" + imageEntity.Image;
            }

            ctx.Images.AddRange(imageEntities);
            ResizeAndSaveImages(images, 700, 700);
            DeleteTempImages();
        }

        private Image GetReplacementImage()
        {
            List<string> imagesPath = GetImagesFromDisk("car-replacement-images");
            return Image.NewFromFile(imagesPath[new Random().Next(imagesPath.Count)]) ;
        }

        private void DeleteTempImages()
        {
            List<string> imagesPath = GetImagesFromDisk("car-temp-images");
            foreach (string imagePath in imagesPath)
            {
                File.Delete(imagePath);
            }
        }

        private List<string> GetImagesFromDisk(string folderPath)
        {
            return Directory.GetFiles(
                                _hostEnvironment.WebRootPath + @$"\assets\images\{folderPath}\",
                                "*.jpg",
                                SearchOption.TopDirectoryOnly
                            ).ToList();
        }

        private void ResizeAndSaveImages(List<Image> imagesToResize, int width, int height)
        {
            foreach (var image in imagesToResize)
            {
                Image img = Image.Thumbnail(image.Filename, width, height);
                string replacementString = image.Filename.Contains("car-replacement-images") ? "car-replacement-images" : "car-temp-images";
                img.WriteToFile(image.Filename.Replace(replacementString, "car-images"));
            }
        }

        private List<Image> ConvertIFormFilesToImageList(List<IFormFile> files)
        {
            List<Image> images = new List<Image>();

            
            files.ForEach(f =>
            {
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    var tempFilepath = _hostEnvironment.WebRootPath + @$"\assets\images\car-temp-images\{f.FileName}";
                    f.CopyTo(memoryStream);
                    using (Image image = Image.NewFromBuffer(memoryStream.ToArray()))
                    {
                        image.WriteToFile(tempFilepath);
                    }
                }
            });

            List<string> imagesPath = GetImagesFromDisk("car-temp-images");
            foreach (string imagePath in imagesPath)
            {
                Image image = Image.NewFromFile(imagePath);
                images.Add(image);
            }
            return images;
        }

        private void SaveImagesTo(List<Image> images)
        {
            foreach (var image in images)
            {
                image.WriteToFile(_hostEnvironment.WebRootPath + @$"\assets\images\car-images\{image.Filename}.jpg");
            }
        }
    }
}
