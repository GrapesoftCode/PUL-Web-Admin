using PUL.GS.Helpers;
using PUL.GS.Models;
using PUL.GS.Models.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace PUL.GS.DataAgents
{
    public class DrinkData
    {
        private readonly AppSettings settings;

        public DrinkData(AppSettings configuration)
        {
            settings = configuration;
        }

        public Response<IEnumerable<Drink>> GetDrinks(string userId, string establishmentId)
        {
            var response = new Response<IEnumerable<Drink>>() { Success = true };
            try
            {
                var client = new HttpClientWrapper<IEnumerable<Drink>, IEnumerable<Drink>>();
                var serviceResponse = client.Consume(new Uri(settings.baseUrl),
                    $"{ServiceURIs.Drink.GetAllDrinks}/{userId}/{establishmentId}", HttpVerb.Get).Result;
                response.objectResult = serviceResponse;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Error = new Error() { Message = ex.Message };
            }
            return response;
        }

        public Response<Drink> GetDrinkById(int bookId)
        {
            var response = new Response<Drink>() { Success = true };
            try
            {
                var client = new HttpClientWrapper<Drink, Drink>();
                var serviceResponse = client.Consume(new Uri(settings.baseUrl),
                    $"{ServiceURIs.Drink.GetDrinkById}/{bookId}", HttpVerb.Get).Result;
                response.objectResult = serviceResponse;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Error = new Error() { Message = ex.Message };
            }
            return response;
        }

        public Response<Drink> CreateDrink(Drink book)
        {
            var response = new Response<Drink>() { Success = true };
            try
            {
                var service = new HttpClientWrapper<Drink, Drink>();
                var serviceResponse = service.Consume(new Uri(settings.baseUrl),
                    $"{ServiceURIs.Drink.CreateDrink}", HttpVerb.Post, book).Result;
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
