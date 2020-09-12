using PUL.GS.Helpers;
using PUL.GS.Models;
using PUL.GS.Models.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace PUL.GS.DataAgents
{
    public class FoodData
    {
        private readonly AppSettings settings;

        public FoodData(AppSettings configuration)
        {
            settings = configuration;
        }

        public Response<IEnumerable<Food>> GetFoods(string userId, string establishmentId)
        {
            var response = new Response<IEnumerable<Food>>() { Success = true };
            try
            {
                var client = new HttpClientWrapper<IEnumerable<Food>, IEnumerable<Food>>();
                var serviceResponse = client.Consume(new Uri(settings.baseUrl),
                    $"{ServiceURIs.Food.GetAllFoods}/{userId}/{establishmentId}", HttpVerb.Get).Result;
                response.objectResult = serviceResponse;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Error = new Error() { Message = ex.Message };
            }
            return response;
        }

        public Response<Food> GetFoodById(int foodId)
        {
            var response = new Response<Food>() { Success = true };
            try
            {
                var client = new HttpClientWrapper<Food, Food>();
                var serviceResponse = client.Consume(new Uri(settings.baseUrl),
                    $"{ServiceURIs.Food.GetFoodById}/{foodId}", HttpVerb.Get).Result;
                response.objectResult = serviceResponse;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Error = new Error() { Message = ex.Message };
            }
            return response;
        }

        public Response<Food> CreateFood(Food food)
        {
            var response = new Response<Food>() { Success = true };
            try
            {
                var service = new HttpClientWrapper<Food, Food>();
                var serviceResponse = service.Consume(new Uri(settings.baseUrl),
                    $"{ServiceURIs.Food.CreateFood}", HttpVerb.Post, food).Result;
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
