using Microsoft.AspNetCore.Http;
using PUL.GS.Models;
using PUL.GS.Web.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PUL.GS.Web.Profiles
{
    public static class EntityMapper
    {

        public static Establishment ToEstablishmentModel(this EstablishmentViewModel viewModel) => new Establishment
        {
            id = viewModel.id,
            Name = viewModel.Name,
            Rfc = viewModel.Rfc,
            Email = viewModel.Email,
            PhoneNumber = viewModel.PhoneNumber,
            CostLevel = viewModel.CostLevel,
            Cover = viewModel.Cover,
            MusicalGenre = viewModel.MusicalGenre,
            Type = viewModel.Type,
            userId = viewModel.userId,
            Logo = ToLogoModel(viewModel.Logo),
            Address = ToAddressModel(viewModel.Address),
            FiscalAddress = ToAddressModel(viewModel.FiscalAddress),
            Inside = ToListImageModel(viewModel.Inside),
            Outside = ToListImageModel(viewModel.Outside)
        };

        public static Address ToAddressModel(this AddressViewModel viewModel) => new Address
        {
            Country = viewModel.Country,
            PostalCode = viewModel.PostalCode,
            State = viewModel.State,
            Municipality = viewModel.Municipality,
            Street = viewModel.Street,
            Neighborhood = viewModel.Neighborhood,
            InteriorNumber = viewModel.InteriorNumber,
            OutdoorNumber = viewModel.OutdoorNumber
        };

        public static Food ToFoodModel(this FoodViewModel viewModel) => new Food
        {
            id = viewModel.id,
            Name = viewModel.Name,
            Category = viewModel.Category,
            Description = viewModel.Description,
            Portion = viewModel.Portion,
            Price = viewModel.Price,
            Grams = viewModel.Grams,
            Logo = viewModel.Logo != null ? ToLogoModel(viewModel.Logo) : null,
            userId = viewModel.userId,
            establishmentId = viewModel.establishmentId
        };

        public static Drink ToDrinkModel(this DrinkViewModel viewModel) => new Drink
        {
            id = viewModel.id,
            Name = viewModel.Name,
            Category = viewModel.Category,
            Description = viewModel.Description,
            Grades = viewModel.Grades,
            Milliliters =viewModel.Milliliters,
            Logo = viewModel.Logo != null ? ToLogoModel(viewModel.Logo) : null,
            Price = viewModel.Price,
            Stock = viewModel.Stock,
            userId = viewModel.userId,
            establishmentId = viewModel.establishmentId
        };

        public static Promotion ToPromotionModel(this PromotionViewModel viewModel) => new Promotion
        {
            id = viewModel.id,
            Name = viewModel.Name,
            Price = viewModel.Price,
            Description = viewModel.Description,
            Active = viewModel.Active,
            Logo = ToLogoModel(viewModel.Logo),
            StartDate = viewModel.StartDate,
            EndDate = viewModel.EndDate,
            userId = viewModel.userId,
            establishmentId = viewModel.establishmentId
        };

        public static Combo ToComboModel(this ComboViewModel viewModel) => new Combo
        {
            id = viewModel.id,
            Name = viewModel.Name,
            Price = viewModel.Price,
            Description = viewModel.Description,
            Active = viewModel.Active,
            Logo = ToLogoModel(viewModel.Logo),
            StartDate = viewModel.StartDate,
            EndDate = viewModel.EndDate,
            userId = viewModel.userId,
            establishmentId = viewModel.establishmentId
        };

        public static Logo ToLogoModel(this IFormFile file) => new Logo
        {
            Name = file.FileName,
            ByteArray = GetByteArray(file),
            MimeType = file.ContentType
        };

        public static List<Image> ToListImageModel(List<IFormFile> files)
        {
            List<Image> images = new List<Image>();
            foreach (var file in files)
            {
                Image image = new Image()
                {
                    Name = file.FileName,
                    ByteArray = GetByteArray(file),
                    MimeType = file.ContentType
                };
                images.Add(image);
            }

            return images;
        }

        private static byte[] GetByteArray(IFormFile file)
        {
            using (var ms = new MemoryStream())
            {
                file.CopyTo(ms);
                var fileBytes = ms.ToArray();
                return fileBytes;
            }
        }
    }
}
