using PUL.GS.Helpers;
using PUL.GS.Models;
using PUL.GS.Models.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace PUL.GS.DataAgents
{
    public class EstablishmentData
    {
        private readonly AppSettings settings;

        public EstablishmentData(AppSettings configuration)
        {
            settings = configuration;
        }

        public Response<Establishment> GetEstablishmentById(string userId)
        {
            var response = new Response<Establishment>() { Success = true };
            try
            {
                var client = new HttpClientWrapper<Establishment,Establishment>();
                var serviceResponse = client.Consume(new Uri(settings.baseUrl),
                    $"{ServiceURIs.Establishment.GetEstablishmentByUserId}/{userId}", HttpVerb.Get).Result;
                response.objectResult = serviceResponse;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Error = new Error() { Message = ex.Message };
            }
            return response;
        }

        public Response<Establishment> CreateEstablishment(Establishment establishment)
        {
            var response = new Response<Establishment>() { Success = true };
            try
            {
                var service = new HttpClientWrapper<Establishment, Establishment>();
                var serviceResponse = service.Consume(new Uri(settings.baseUrl),
                    $"{ServiceURIs.Establishment.CreateEstablishment}", HttpVerb.Post, establishment).Result;
                response.objectResult = serviceResponse;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Error = new Error() { Message = ex.Message };
            }
            return response;
        }
    }
}
