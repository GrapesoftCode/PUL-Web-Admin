using Microsoft.AspNetCore.Http;
using PUL.GS.Models;
using PUL.GS.Web.Models;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PUL.GS.Web.Profiles
{
    public class PulAdminProfile: AutoMapper.Profile
    {
        public PulAdminProfile()
        {
            this.CreateMap<Establishment, EstablishmentViewModel>().ReverseMap();
            //.ForMember(u => u.Logo.FileName, p => p.MapFrom(m => m.Logo.Name))
            //.ForMember(u => u.Logo.ContentType, p => p.MapFrom(m => m.Logo.MimeType))
            //.ForMember(u => GetByteArray(u.Logo), p => p.MapFrom(m => m.Logo.ByteArray))

        }


        private byte[] GetByteArray(IFormFile file)
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
