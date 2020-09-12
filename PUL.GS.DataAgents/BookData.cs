using PUL.GS.Helpers;
using PUL.GS.Models;
using PUL.GS.Models.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace PUL.GS.DataAgents
{
    public class BookData
    {
        private readonly AppSettings settings;

        public BookData(AppSettings configuration)
        {
            settings = configuration;
        }

        public Response<IEnumerable<Book>> GetBooks(int managerId, int insuranceTypeId)
        {
            var response = new Response<IEnumerable<Book>>() { Success = true };
            try
            {
                var client = new HttpClientWrapper<IEnumerable<Book>, IEnumerable<Book>>();
                var serviceResponse = client.Consume(new Uri(settings.baseUrl),
                    $"{ServiceURIs.Book.GetAllBooks}/{managerId}/{insuranceTypeId}", HttpVerb.Get).Result;
                response.objectResult = serviceResponse;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Error = new Error() { Message = ex.Message };
            }
            return response;
        }

        public Response<IEnumerable<GeneralReportStatusBooks>> GeneralReportStatusBooks(string establishmentId)
        {
            var response = new Response<IEnumerable<GeneralReportStatusBooks>>() { Success = true };
            try
            {
                var client = new HttpClientWrapper<IEnumerable<GeneralReportStatusBooks>, IEnumerable<GeneralReportStatusBooks>>();
                var serviceResponse = client.Consume(new Uri(settings.baseUrl),
                    $"{ServiceURIs.Book.GeneralReportStatusBooks}/{establishmentId}", HttpVerb.Get).Result;
                response.objectResult = serviceResponse;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Error = new Error() { Message = ex.Message };
            }
            return response;
        }

        public Response<Book> GetBookById(int bookId)
        {
            var response = new Response<Book>() { Success = true };
            try
            {
                var client = new HttpClientWrapper<Book, Book>();
                var serviceResponse = client.Consume(new Uri(settings.baseUrl),
                    $"{ServiceURIs.Book.GetBookById}/{bookId}", HttpVerb.Get).Result;
                response.objectResult = serviceResponse;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Error = new Error() { Message = ex.Message };
            }
            return response;
        }

        public Response<string> CreateBook(Book book)
        {
            var response = new Response<string>() { Success = true };
            try
            {
                var service = new HttpClientWrapper<Book, string>();
                var serviceResponse = service.Consume(new Uri(settings.baseUrl),
                    $"{ServiceURIs.Book.CreateBook}", HttpVerb.Post, book).Result;
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
