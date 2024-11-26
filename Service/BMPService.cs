using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Book;
using api.Interfaces;
using api.Mappers;
using api.Models;
using Newtonsoft.Json;

namespace api.Service
{
    public class BMPService : IBMPService
    {
        private HttpClient _httpClient;
        private IConfiguration _config;
        public BMPService(HttpClient httpClient, IConfiguration config)
        {
            _httpClient = httpClient;
            _config = config;
        }   
        public async Task<Book> FindBookByTitleAsync(string title)
        {
            try{
                var result = await _httpClient.GetAsync($"https://openlibrary.org/search.json?title={title}");
                if(result.IsSuccessStatusCode)
                {
                    var content = await result.Content.ReadAsStringAsync();
                    var root = JsonConvert.DeserializeObject<BMPBook.Root>(content);
                    var book = root.docs.FirstOrDefault();
                    if(book != null)
                    {
                        return book.ToBookFromBMP();
                    }
                    return null;
                }
                return null;
            } catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }
    }
}