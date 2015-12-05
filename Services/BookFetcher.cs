using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Services
{
    public class BookFetcher : IBookFetcher
    {
        public async Task<string> FetchBook() {
            // ... Target page.
            string page = @"http://www.gutenberg.org/cache/epub/24486/pg24486.txt"; //"http://en.wikipedia.org/";
            
            // ... Use HttpClient.
            using (HttpClient client = new HttpClient())
            using (HttpResponseMessage response = await client.GetAsync(page))
            using (HttpContent content = response.Content)
            {
                // ... Read the string.
                string result = await content.ReadAsStringAsync();
                return result;
                // // ... Display the result.
                // if (result != null &&
                // result.Length >= 50)
                // {
                // Console.WriteLine(result.Substring(0, 50) + "...");
                // }
            }            
        }
    }
}
