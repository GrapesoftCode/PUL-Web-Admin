using PUL.GS.Helpers;
using PUL.GS.Models;
using PUL.GS.Models.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace PUL.GS.DataAgents
{
    public class PromotionData
    {
        private readonly AppSettings settings;

        public PromotionData(AppSettings configuration)
        {
            settings = configuration;
        }

        public Response<IEnumerable<Promotion>> GetPromotions(string userId, string establishmentId)
        {
            var response = new Response<IEnumerable<Promotion>>() { Success = true };
            try
            {
                var client = new HttpClientWrapper<IEnumerable<Promotion>, IEnumerable<Promotion>>();
                var serviceResponse = client.Consume(new Uri(settings.baseUrl),
                    $"{ServiceURIs.Promotion.GetAllPromotions}/{userId}/{establishmentId}", HttpVerb.Get).Result;
                response.objectResult = serviceResponse;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Error = new Error() { Message = ex.Message };
            }
            return response;
        }

        public Response<Promotion> GetPromotionById(int promotionId)
        {
            var response = new Response<Promotion>() { Success = true };
            try
            {
                var client = new HttpClientWrapper<Promotion, Promotion>();
                var serviceResponse = client.Consume(new Uri(settings.baseUrl),
                    $"{ServiceURIs.Promotion.GetPromotionById}/{promotionId}", HttpVerb.Get).Result;
                response.objectResult = serviceResponse;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Error = new Error() { Message = ex.Message };
            }
            return response;
        }

        public Response<Promotion> CreatePromotion(Promotion promotion)
        {
            var response = new Response<Promotion>() { Success = true };
            try
            {
                var service = new HttpClientWrapper<Promotion, Promotion>();
                var serviceResponse = service.Consume(new Uri(settings.baseUrl),
                    $"{ServiceURIs.Promotion.CreatePromotion}", HttpVerb.Post, promotion).Result;
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
