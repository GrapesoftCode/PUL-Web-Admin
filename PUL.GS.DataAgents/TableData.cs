using PUL.GS.Helpers;
using PUL.GS.Models;
using PUL.GS.Models.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace PUL.GS.DataAgents
{
    public class TableData
    {
        private readonly AppSettings settings;

        public TableData(AppSettings configuration)
        {
            settings = configuration;
        }

        public Response<IEnumerable<Table>> GetTables(string userId, string establishmentId)
        {
            var response = new Response<IEnumerable<Table>>() { Success = true };
            try
            {
                var client = new HttpClientWrapper<IEnumerable<Table>, IEnumerable<Table>>();
                var serviceResponse = client.Consume(new Uri(settings.baseUrl),
                    $"{ServiceURIs.Table.GetAllTables}/{userId}/{establishmentId}", HttpVerb.Get).Result;
                response.objectResult = serviceResponse;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Error = new Error() { Message = ex.Message };
            }
            return response;
        }

        public Response<Table> GetTableById(int promotionId)
        {
            var response = new Response<Table>() { Success = true };
            try
            {
                var client = new HttpClientWrapper<Table, Table>();
                var serviceResponse = client.Consume(new Uri(settings.baseUrl),
                    $"{ServiceURIs.Table.GetTableById}/{promotionId}", HttpVerb.Get).Result;
                response.objectResult = serviceResponse;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Error = new Error() { Message = ex.Message };
            }
            return response;
        }

        public Response<Table> CreateTable(Table table)
        {
            var response = new Response<Table>() { Success = true };
            try
            {
                var service = new HttpClientWrapper<Table, Table>();
                var serviceResponse = service.Consume(new Uri(settings.baseUrl),
                    $"{ServiceURIs.Table.CreateTable}", HttpVerb.Post, table).Result;
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
