using PUL.GS.Helpers;
using PUL.GS.Models;
using PUL.GS.Models.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace PUL.GS.DataAgents
{
    public class ComboData
    {
        private readonly AppSettings settings;

        public ComboData(AppSettings configuration)
        {
            settings = configuration;
        }


        public Response<IEnumerable<Combo>> GetCombos(string userId, string establishmentId)
        {
            var response = new Response<IEnumerable<Combo>>() { Success = true };
            try
            {
                var client = new HttpClientWrapper<IEnumerable<Combo>, IEnumerable<Combo>>();
                var serviceResponse = client.Consume(new Uri(settings.baseUrl),
                    $"{ServiceURIs.Combo.GetAllCombos}/{userId}/{establishmentId}", HttpVerb.Get).Result;
                response.objectResult = serviceResponse;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Error = new Error() { Message = ex.Message };
            }
            return response;
        }

        public Response<IEnumerable<Combo>> GetComboById(string userId)
        {
            var response = new Response<IEnumerable<Combo>>() { Success = true };
            try
            {
                var client = new HttpClientWrapper<Combo, IEnumerable<Combo>>();
                var serviceResponse = client.Consume(new Uri(settings.baseUrl),
                    $"{ServiceURIs.Combo.GetComboById}/{userId}", HttpVerb.Get).Result;
                response.objectResult = serviceResponse;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Error = new Error() { Message = ex.Message };
            }
            return response;
        }

        public Response<Combo> CreateCombo(Combo book)
        {
            var response = new Response<Combo>() { Success = true };
            try
            {
                var service = new HttpClientWrapper<Combo, Combo>();
                var serviceResponse = service.Consume(new Uri(settings.baseUrl),
                    $"{ServiceURIs.Combo.CreateCombo}", HttpVerb.Post, book).Result;
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
